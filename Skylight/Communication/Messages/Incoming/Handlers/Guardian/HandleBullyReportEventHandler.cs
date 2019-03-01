﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Messages;
using SkylightEmulator.Core;

namespace SkylightEmulator.Communication.Messages.Incoming.Handlers.Guardian
{
    public class HandleBullyReportEventHandler : IncomingPacket
    {
        protected bool Accepted;

        public virtual void Handle(GameClient session, ClientMessage message)
        {
            if (session?.GetHabbo() != null)
            {
                if (this.Accepted)
                {
                    Skylight.GetGame().GetGuideManager().AcceptBully(session);
                }
                else
                {
                    Skylight.GetGame().GetGuideManager().DeclineBully(session);
                }
            }
        }
    }
}
