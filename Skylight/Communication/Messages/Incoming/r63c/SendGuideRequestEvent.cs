﻿using SkylightEmulator.Communication.Messages.Incoming.Handlers.Guide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Messages;
using SkylightEmulator.HabboHotel.Data.Enums;

namespace SkylightEmulator.Communication.Messages.Incoming.r63c
{
    class SendGuideRequestEvent : SendGuideRequestEventHandler
    {
        public override void Handle(GameClient session, ClientMessage message)
        {
            this.Type = message.PopWiredInt32();
            this.Message = message.PopFixedString();

            base.Handle(session, message);
        }
    }
}
