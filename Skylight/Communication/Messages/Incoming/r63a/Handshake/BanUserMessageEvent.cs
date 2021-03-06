﻿using SkylightEmulator.Core;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.HabboHotel.Rooms;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Incoming.r63a.Handshake
{
    class BanUserMessageEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            Room room = Skylight.GetGame().GetRoomManager().TryGetRoom(session.GetHabbo().GetRoomSession().CurrentRoomID);
            if (room != null && room.HaveOwnerRights(session))
            {
                uint userId = message.PopWiredUInt();

                RoomUnitUser user = room.RoomUserManager.GetUserByID(userId);
                if (user != null && !room.HaveOwnerRights(user.Session) && !user.Session.GetHabbo().HasPermission("acc_unbannable"))
                {
                    room.RoomUserManager.BanUser(user.Session);
                }
            }
        }
    }
}
