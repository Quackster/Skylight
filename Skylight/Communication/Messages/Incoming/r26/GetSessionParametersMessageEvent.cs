﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using SkylightEmulator.Communication.Headers;

namespace SkylightEmulator.Communication.Messages.Incoming.r26
{
    class GetSessionParametersMessageEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            ServerMessage Message = BasicUtilies.GetRevisionServerMessage(Revision.R26_20080915_0408_7984_61ccb5f8b8797a3aba62c1fa2ca80169);
            Message.Init(r26Outgoing.SendSessionParamenters);
            Message.AppendInt32(0); //count
            session.SendMessage(Message);
        }
    }
}
