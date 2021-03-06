﻿using SkylightEmulator.Communication.Headers;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Outgoing.r63a
{
    class UnseenItemMessageResponse : OutgoingPacket
    {
        public ServerMessage Handle(ValueHolder valueHolder = null)
        {
            ServerMessage message = BasicUtilies.GetRevisionServerMessage(Revision.RELEASE63_35255_34886_201108111108);
            message.Init(r63aOutgoing.NewItemAdded);
            message.AppendInt32(1);
            message.AppendInt32(valueHolder.GetValue<int>("Type"));
            message.AppendInt32(1);
            message.AppendInt32(valueHolder.GetValue<int>("ID"));
            return message;
        }
    }
}
