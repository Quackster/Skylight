﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Messages;

namespace SkylightEmulator.Communication.Messages.Incoming.r26
{
    class GetHandMessageEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            session.SendMessage(session.GetHabbo().GetInventoryManager().OldSchoolGetHand(message.PopStringUntilBreak(null)));
        }
    }
}
