﻿using SkylightEmulator.Core;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.HabboHotel.Rooms.Commands
{
    class MOTDAlert : Command
    {
        public override string CommandInfo()
        {
            return ":motd [user] [message] - Sends MOTD to user";
        }

        public override string RequiredPermission()
        {
            return "cmd_motd";
        }

        public override bool ShouldBeLogged()
        {
            return true;
        }

        public override bool OnUse(GameClient session, string[] args)
        {
            if (args.Length >= 3)
            {
                if (session.GetHabbo().HasPermission("cmd_motd"))
                {
                    GameClient target = Skylight.GetGame().GetGameClientManager().GetGameClientByUsername(args[1]);
                    if (target != null)
                    {
                        target.SendNotif(TextUtilies.MergeArrayToString(args, 2), 2);
                    }
                    else
                    {
                        session.SendNotif("Unable to find user!");
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
