﻿using SkylightEmulator.Communication.Headers;
using SkylightEmulator.Core;
using SkylightEmulator.HabboHotel.GameClients;
using SkylightEmulator.HabboHotel.Items;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.HabboHotel.Rooms
{
    class RoomItemWiredUsersNotStandOnFurni : RoomItemWiredCondition
    {
        public List<RoomItem> SelectedItems;

        public RoomItemWiredUsersNotStandOnFurni(uint id, uint roomId, uint userId, Item baseItem, string extraData, int x, int y, double z, int rot, WallCoordinate wallCoordinate, Room room)
            : base(id, roomId, userId, baseItem, extraData, x, y, z, rot, wallCoordinate, room)
        {
            this.SelectedItems = new List<RoomItem>();
        }

        public override void OnUse(GameClient session, RoomItem item, int request, bool userHasRights)
        {
            if (userHasRights)
            {
                ServerMessage message = BasicUtilies.GetRevisionServerMessage(Revision.RELEASE63_35255_34886_201108111108);
                message.Init(r63aOutgoing.WiredCondition);
                message.AppendBoolean(false); //check box toggling
                message.AppendInt32(session.GetHabbo().GetWiredConditionLimit()); //furni limit
                message.AppendInt32(this.SelectedItems.Count); //furni count
                foreach (RoomItem item_ in this.SelectedItems.ToList())
                {
                    message.AppendUInt(item_.ID);
                }
                message.AppendInt32(this.GetBaseItem().SpriteID); //sprite id, show the help thing
                message.AppendUInt(this.ID); //item id
                message.AppendString(""); //data
                message.AppendInt32(0); //extra data count
                message.AppendInt32(0); //delay, not work with this wired

                message.AppendInt32(1); //type
                session.SendMessage(message);
            }
        }

        public override string GetItemData()
        {
            return string.Join(",", this.SelectedItems.Select(i => i.ID));
        }

        public override void LoadItemData(string data)
        {
            foreach (string sItemId in data.Split(','))
            {
                if (!string.IsNullOrEmpty(sItemId))
                {
                    RoomItem item = this.Room.RoomItemManager.TryGetRoomItem(uint.Parse(sItemId));
                    if (item != null)
                    {
                        this.SelectedItems.Add(item);
                    }
                }
            }
        }

        public override void OnLoad()
        {
            this.ExtraData = "0";
        }

        public override void OnPickup(GameClient session)
        {
            this.ExtraData = "0";
        }

        public override void OnPlace(GameClient session)
        {
            this.ExtraData = "0";
        }

        public override void OnCycle()
        {
            if (this.UpdateNeeded)
            {
                this.UpdateTimer--;
                if (this.UpdateTimer <= 0)
                {
                    this.UpdateNeeded = false;

                    this.ExtraData = "0";
                    this.UpdateState(false, true);
                }
            }
        }

        public override bool IsBlocking(RoomUnitUser triggerer)
        {
            int usersOnFurni = 0;
            foreach (RoomItem item_ in this.SelectedItems)
            {
                bool found = false;

                foreach (RoomUnitUser user in this.Room.RoomGamemapManager.GetTile(item_.X, item_.Y).UsersOnTile.Values)
                {
                    if (user.IsRealUser && user.Z >= item_.Z)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    usersOnFurni++;
                    continue;
                }

                foreach (AffectedTile tile in item_.AffectedTiles)
                {
                    foreach (RoomUnitUser user in this.Room.RoomGamemapManager.GetTile(tile.X, tile.Y).UsersOnTile.Values)
                    {
                        if (user.IsRealUser && user.Z >= item_.Z)
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (found)
                {
                    usersOnFurni++;
                }
                else
                {
                    return false;
                }
            }
            
            if (usersOnFurni >= this.SelectedItems.Count)
            {
                return true;
            }

            return false;
        }
    }
}