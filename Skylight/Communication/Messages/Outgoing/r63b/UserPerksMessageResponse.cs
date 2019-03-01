﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using SkylightEmulator.Communication.Headers;

namespace SkylightEmulator.Communication.Messages.Outgoing.r63b
{
    class UserPerksMessageResponse : OutgoingPacket
    {
        public ServerMessage Handle(ValueHolder valueHolder = null)
        {
            ServerMessage message = BasicUtilies.GetRevisionServerMessage(Revision.RELEASE63_201211141113_913728051);
            message.Init(r63bOutgoing.UserPerks);
            message.AppendInt32(2); //count

            message.AppendString("SAFE_CHAT");
            message.AppendBoolean(true);
            message.AppendString("");

            message.AppendString("FULL_CHAT");
            message.AppendBoolean(true);
            message.AppendString("");
            return message;
        }
    }
}
