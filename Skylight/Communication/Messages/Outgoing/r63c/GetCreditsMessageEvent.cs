﻿using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Outgoing.r63c
{
    class GetCreditsMessageEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            if (session != null && session.GetHabbo() != null)
            {
                session.GetHabbo().UpdateCredits(false);
                session.GetHabbo().UpdateActivityPoints(-1, false);
                session.GetHabbo().SendOnlineUsersCount();
            }
        }
    }
}
