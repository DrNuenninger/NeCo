using Neco.Infrastructure.Protocol;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace Neco.Client.Network
{
    public class BackendConnector
    {
        private TcpClient client;
        private IMessage messageHandler;
        private Thread receiveThread;
        private Dictionary<CommandTypes, Action<Byte[]>> handlers;

        // Experimental fallback
        private UdpClient fallbackClient;
        private string target;
        private int tPort;

        public BackendConnector(String host)
        {
            handlers = new Dictionary<CommandTypes, Action<Byte[]>>();
            messageHandler = DependencyService.Get<IMessage>();

            var separator = host.LastIndexOf(':');
            if (separator < 0) throw new ArgumentException();

            int port = Convert.ToInt32(host.Substring(separator + 1));
            String server = host.Substring(0, separator);

            receiveThread = new Thread(() => Runner(server, port));
            receiveThread.Start();
        }

        public bool Connected
        {
            get
            {
                return client != null && client.Connected;
            }
        }


        public void Stop()
        {
            client?.Close();
            fallbackClient?.Close();
            receiveThread?.Join();
        }

        public void Send(CommandTypes type, byte[] data)
        {
            byte[] outData = new byte[data.Length + 8];
            Array.Copy(data, 0, outData, 8, data.Length);
            Array.Copy(BitConverter.GetBytes(outData.Length), 0, outData, 0, 4);
            Array.Copy(BitConverter.GetBytes((int)type), 0, outData, 4, 4);
           

            if (client != null && client.Connected)
            {
                NetworkStream stream = client.GetStream();
                stream.Write(outData, 0, outData.Length);
            }
            else if(fallbackClient != null)
            {
                fallbackClient.Send(outData, outData.Length, target, tPort);
            }
        }

        private void Runner(String server, int port)
        {
            client = new TcpClient();
            if (true || !client.ConnectAsync(server, port).Wait(2000))
            {
                /*Device.BeginInvokeOnMainThread(() =>
                {
                    messageHandler.ShowToast("Unable to connect to backend");
                });*/

                client = null;
                FallbackRunner(server, port);
                return;
            }

            NetworkStream stream = client.GetStream();
            byte[] bytes = new byte[client.ReceiveBufferSize];
            while (client.Connected && stream != null && stream.CanRead)
            {
                if (stream.DataAvailable)
                {
                    stream.Read(bytes, 0, (int)bytes.Length);
                    HandleData(bytes);
                }
                else
                {
                    Thread.Sleep(10);
                }
            }
        }

        public void FallbackRunner(String server, int port)
        {
            target = server;
            tPort = port;

            fallbackClient = new UdpClient(port);
            fallbackClient.BeginReceive(DataReceived, fallbackClient);
        }

        private void DataReceived(IAsyncResult ar)
        {
            UdpClient c = (UdpClient)ar.AsyncState;
            IPEndPoint receivedIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Byte[] receivedBytes = c.EndReceive(ar, ref receivedIpEndPoint);

            HandleData(receivedBytes);

            // Restart listening for udp data packages
            c.BeginReceive(DataReceived, ar.AsyncState);
        }

        private void HandleData(byte[] bytes)
        {
            int length = Math.Min(BitConverter.ToInt32(bytes, 0), bytes.Length) - 8;
            CommandTypes type = (CommandTypes)BitConverter.ToInt32(bytes, 4);

            if (handlers.ContainsKey(type))
            {
                byte[] data = new byte[length];
                Array.Copy(bytes, 8, data, 0, length);

                handlers[type](data);
            }
        }

        public void Receive(CommandTypes type, Action<Byte[]> handler)
        {
            if(handlers.ContainsKey(type))
            {
                handlers.Remove(type);
            }

            handlers.Add(type, handler);
        }
    }
}
