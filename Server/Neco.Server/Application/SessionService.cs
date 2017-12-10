﻿using Neco.DataTransferObjects;
using Neco.Server.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neco.Server.Application
{
    public class SessionService : BaseService
    {
        public async Task<SessionResponse> Session(ClientSession session, SessionRequest request)
        {
            var response = request.CreateResponse<SessionResponse>();
            response.Token = request.Token;
            if (session.HasChat) session.LeaveChatSession();
            try
            {
                if (ChatLobbyManager.HasMemberSession(session.ChatLobbyId, request.MemberKey))
                {
                    response.PublicKey = ChatLobbyManager.JoinSession(session.ChatLobbyId, request.MemberKey, session);
                    response.Success = true;
                    return response;
                }
                else
                {
                    var publicKey = await ChatLobbyManager.OpenSession(session.ChatLobbyId, session);
                    response.Success = true;
                    response.PublicKey = publicKey;
                    return response;
                }
            }
            catch (Exception exc)
            {
                response.Success = false;
                return response;
            }
        }
        public SessionCloseResponse SessionClose(ClientSession session, SessionCloseRequest request)
        {
            var response = request.CreateResponse<SessionCloseResponse>();
            response.Token = request.Token;
            try
            {
                if (session.HasChat) session.LeaveChatSession();
                response.Success = true;
                return response;
            } catch(Exception e)
            {
                response.Success = false;
                return response;
            }
        }
    }
}
