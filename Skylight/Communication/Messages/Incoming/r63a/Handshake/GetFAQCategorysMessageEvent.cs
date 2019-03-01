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
    class GetFAQCategorysMessageEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            int categoryId = message.PopWiredInt32();
            session.SendMessage(Skylight.GetGame().GetHelpManager().GetCategorys(categoryId));
        }
    }
}
