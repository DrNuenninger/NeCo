﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace Neco.Server.Infrastructure.Commands
{
    public class CommandHandler : NecoCommandBase
    {
        private String user = "NO_NAME_GIVEN";

        public override void ExecuteCommand(NecoSession session, BinaryRequestInfo requestInfo)
        {
            String body = requestInfo.Body.ToString();
            if (body.StartsWith("user:"))
            {
                user = body.Split(':')[1];
                session.Send(" Hello " + user + Environment.NewLine);
            } else
            {
                session.Send(" Message recieved from " + user + Environment.NewLine);
            }
        }

        protected override CommandTypes CommandType
        {
            get { return CommandTypes.Request; }
        }
    }
}