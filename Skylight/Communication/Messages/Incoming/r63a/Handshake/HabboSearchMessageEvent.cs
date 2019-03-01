﻿using SkylightEmulator.Communication.Messages.Incoming.Handlers.Messenger;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Incoming.r63a.Handshake
{
    class HabboSearchMessageEvent : MessengerSearchUserEventHandler
    {
        public override void Handle(GameClient session, ClientMessage message)
        {
            this.Username = message.PopFixedString();

            base.Handle(session, message);
        }
    }
}
