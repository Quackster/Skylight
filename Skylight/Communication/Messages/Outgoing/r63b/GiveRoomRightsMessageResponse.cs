﻿using SkylightEmulator.Communication.Headers;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Outgoing.r63b
{
    class GiveRoomRightsMessageResponse : OutgoingPacket
    {
        public ServerMessage Handle(ValueHolder valueHolder = null)
        {
            ServerMessage roomRights = BasicUtilies.GetRevisionServerMessage(Revision.RELEASE63_201211141113_913728051);
            roomRights.Init(r63bOutgoing.GiveRoomRights);
            roomRights.AppendInt32(valueHolder.GetValue<int>("RightsLevel")); //0 = No rights, 1 = Basic rights, 2 = Can place, 3 = Pickup, 4 = IDK, 5 = IDK
            return roomRights;
        }
    }
}
