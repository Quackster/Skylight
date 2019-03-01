﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using SkylightEmulator.Communication.Headers;

namespace SkylightEmulator.Communication.Messages.Outgoing.r26
{
    class UserLeavedMessageResponse : OutgoingPacket
    {
        public ServerMessage Handle(ValueHolder valueHolder = null)
        {
            ServerMessage message = BasicUtilies.GetRevisionServerMessage(Revision.R26_20080915_0408_7984_61ccb5f8b8797a3aba62c1fa2ca80169);
            message.Init(r26Outgoing.UserLeaveRoom);
            message.AppendString(valueHolder.GetValue<int>("VirtualID").ToString());
            return message;
        }
    }
}
