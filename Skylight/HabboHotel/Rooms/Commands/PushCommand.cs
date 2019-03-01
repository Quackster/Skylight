﻿using SkylightEmulator.Core;
using SkylightEmulator.HabboHotel.Data.Enums;
using SkylightEmulator.HabboHotel.GameClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.HabboHotel.Rooms.Commands
{
    class PushCommand : Command
    {
        public override string CommandInfo()
        {
            return ":push [user] - Push user one tile";
        }

        public override string RequiredPermission()
        {
            return "cmd_push";
        }

        public override bool ShouldBeLogged()
        {
            return false;
        }

        public override bool OnUse(GameClient session, string[] args)
        {
            if (args.Length >= 2)
            {
                if (session.GetHabbo().HasPermission("cmd_push"))
                {
                    GameClient target = Skylight.GetGame().GetGameClientManager().GetGameClientByUsername(args[1]);
                    if (target != null)
                    {
                        RoomUnit me = session.GetHabbo().GetRoomSession().GetRoomUser();
                        RoomUnit other = target.GetHabbo().GetRoomSession().GetRoomUser();
                        if (target.GetHabbo().GetRoomSession().IsInRoom && target.GetHabbo().GetRoomSession().CurrentRoomID == session.GetHabbo().GetRoomSession().CurrentRoomID && (other.RestrictMovementType & RestrictMovementType.Client) == 0)
                        {
                            bool doit = true;
                            if ((me.X + 1 != other.X || me.Y != other.Y) && (me.X - 1 != other.X || me.Y != other.Y) && (me.Y + 1 != other.Y || me.X != other.X))
                            {
                                bool skip = false;
                                if (me.X - 1 == other.X)
                                {
                                    if (me.Y == other.Y)
                                    {
                                        skip = true;
                                    }
                                }

                                if (!skip)
                                {
                                    doit = me.X == other.X || me.Y == other.Y;
                                }
                            }

                            if (doit)
                            {
                                me.Speak("*pushes " + target.GetHabbo().Username + "*", false);
                                if (me.HeadRotation == 0)
                                {
                                    other.MoveTo(target.GetHabbo().GetRoomSession().GetRoomUser().X, target.GetHabbo().GetRoomSession().GetRoomUser().Y - 1);
                                }
                                else if (me.HeadRotation == 2)
                                {
                                    other.MoveTo(target.GetHabbo().GetRoomSession().GetRoomUser().X + 1, target.GetHabbo().GetRoomSession().GetRoomUser().Y);
                                }
                                else if (me.HeadRotation == 4)
                                {
                                    other.MoveTo(target.GetHabbo().GetRoomSession().GetRoomUser().X, target.GetHabbo().GetRoomSession().GetRoomUser().Y + 1);
                                }
                                else if (me.HeadRotation == 6)
                                {
                                    other.MoveTo(target.GetHabbo().GetRoomSession().GetRoomUser().X - 1, target.GetHabbo().GetRoomSession().GetRoomUser().Y);
                                }
                                else
                                {
                                    other.MoveTo(target.GetHabbo().GetRoomSession().GetRoomUser().X, target.GetHabbo().GetRoomSession().GetRoomUser().Y + 1);
                                }
                            }

                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
