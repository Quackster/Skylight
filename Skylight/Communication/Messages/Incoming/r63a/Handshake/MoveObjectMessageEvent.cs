﻿using SkylightEmulator.Core;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.HabboHotel.Rooms;
using SkylightEmulator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Incoming.r63a.Handshake
{
    class MoveObjectMessageEvent : IncomingPacket
    {
        public void Handle(GameClient session, ClientMessage message)
        {
            if (session != null && session.GetHabbo() != null && session.GetHabbo().GetRoomSession() != null)
            {
                Room room = session.GetHabbo().GetRoomSession().GetRoom();
                if (room != null && room.GaveRoomRights(session))
                {
                    RoomItem item = room.RoomItemManager.TryGetFloorItem(message.PopWiredUInt());
                    if (item != null)
                    {
                        int x = message.PopWiredInt32();
                        int y = message.PopWiredInt32();
                        int rot = message.PopWiredInt32();
                        
                        if (room.RoomItemManager.MoveFloorItemOnRoom(session, item, x, y, rot))
                        {

                        }
                    }
                }
            }
        }
    }
}
