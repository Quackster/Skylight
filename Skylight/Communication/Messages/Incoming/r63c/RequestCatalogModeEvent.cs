﻿using SkylightEmulator.Communication.Messages.Incoming.Handlers.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Messages;

namespace SkylightEmulator.Communication.Messages.Incoming.r63c
{
    public class RequestCatalogModeEvent : RequestCatalogModeEventHandler
    {
        public override void Handle(GameClient session, ClientMessage message)
        {
            this.Mode = message.PopFixedString();

            base.Handle(session, message);
        }
    }
}
