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
    class ModeratorGetUserChatlogMessageEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            if (session.GetHabbo().HasPermission("acc_chatlogs"))
            {
                uint userId = message.PopWiredUInt();
                session.SendMessage(Skylight.GetGame().GetModerationToolManager().GetUserChatlog(userId));
            }
        }
    }
}
