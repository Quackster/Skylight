﻿using SkylightEmulator.Communication.Messages.Incoming.Handlers.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Messages;

namespace SkylightEmulator.Communication.Messages.Incoming.r63c
{
    class TradeCloseEvent : TradeCloseEventHandler
    {
        public override void Handle(GameClient session, ClientMessage message)
        {
            base.Handle(session, message);
        }
    }
}
