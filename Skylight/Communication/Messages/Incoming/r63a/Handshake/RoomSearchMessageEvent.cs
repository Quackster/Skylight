﻿using SkylightEmulator.Core;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Incoming.r63a.Handshake
{
    class RoomSearchMessageEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            string entry = message.PopFixedString();
            session.SendMessage(Skylight.GetGame().GetNavigatorManager().SearchRooms(entry, session.Revision));
        }
    }
}