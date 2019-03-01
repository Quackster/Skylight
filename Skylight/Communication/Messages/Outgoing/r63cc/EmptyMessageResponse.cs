﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;

namespace SkylightEmulator.Communication.Messages.Outgoing.r63cc
{
    class EmptyMessageResponse : OutgoingPacket
    {
        public ServerMessage Handle(ValueHolder valueHolder = null)
        {
            return null;
        }
    }
}
