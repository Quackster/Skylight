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
    class GetIgnoredUsersMessageEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            if (session != null && session.GetHabbo() != null && session.GetHabbo().IgnoredUsers.Count > 0)
            {
                ServerMessage message_ = BasicUtilies.GetRevisionServerMessage(Revision.RELEASE63_35255_34886_201108111108);
                message_.Init(r63aOutgoing.IgnoredList);
                message_.AppendInt32(session.GetHabbo().IgnoredUsers.Count);
                foreach (uint ignoredId in session.GetHabbo().IgnoredUsers)
                {
                    message_.AppendString(Skylight.GetGame().GetGameClientManager().GetUsernameByID(ignoredId));
                }
                session.SendMessage(message_);
            }
        }
    }
}
