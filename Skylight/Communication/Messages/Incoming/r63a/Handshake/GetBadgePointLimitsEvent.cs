﻿using SkylightEmulator.Communication.Headers;
using SkylightEmulator.Core;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Incoming.r63a.Handshake
{
    class GetBadgePointLimitsEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            ServerMessage Message = BasicUtilies.GetRevisionServerMessage(Skylight.Revision);
            Message.Init(r63aOutgoing.BadgePoints);
            Message.AppendInt32(0); //achievement score
            session.SendMessage(Message);
        }
    }
}
