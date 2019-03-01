﻿using SkylightEmulator.Core;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.HabboHotel.Support;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.HabboHotel.Rooms.Commands
{
    class MachineBanCommand : Command
    {
        public override string CommandInfo()
        {
            return ":mban [name] <time/P> <reason> - Machien bans the user";
        }

        public override bool OnUse(GameClient session, string[] args)
        {
            if (args.Length >= 2)
            {
                if (session.GetHabbo().HasPermission("cmd_mban"))
                {
                    GameClient target = Skylight.GetGame().GetGameClientManager().GetGameClientByUsername(args[1]);
                    if (target != null)
                    {
                        if (target.GetHabbo().Rank < session.GetHabbo().Rank)
                        {
                            string banLenghtString = "P";
                            if (args.Length >= 3)
                            {
                                banLenghtString = args[2];

                                if (banLenghtString != "P")
                                {
                                    if (!Char.IsNumber(banLenghtString.Substring(banLenghtString.Length - 1)[0]))
                                    {
                                        int lenght;
                                        if (!int.TryParse(banLenghtString.Substring(0, banLenghtString.Length - 1), out lenght))
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        int lenght;
                                        if (!int.TryParse(banLenghtString, out lenght))
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }

                            string banReason = "No reason";
                            if (args.Length >= 4)
                            {
                                banReason = TextUtilies.MergeArrayToString(args, 3);
                            }

                            bool banned = false;
                            if (Skylight.GetGame().GetBanManager().BanUser(session, target, BanType.Machine, target.MachineID, banReason, banLenghtString, false) | Skylight.GetGame().GetBanManager().BanUser(session, target, BanType.IP, target.GetIP(), banReason, banLenghtString, false) | Skylight.GetGame().GetBanManager().BanUser(session, target, BanType.User, target.GetHabbo().ID.ToString(), banReason, banLenghtString))
                            {
                                banned = true;
                            }
                            return banned;
                        }
                        else
                        {
                            session.SendNotif("You are not allowed to ban that user.");
                        }
                    }
                    else
                    {
                        session.SendNotif("User not found.");
                    }

                    return true;
                }
            }

            return false;
        }

        public override string RequiredPermission()
        {
            return "cmd_mban";
        }

        public override bool ShouldBeLogged()
        {
            return true;
        }
    }
}
