﻿using SkylightEmulator.Communication.Headers;
using SkylightEmulator.Messages;
using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Communication.Messages.Outgoing.r63c
{
    class NewItemsMessageResponse : OutgoingPacket
    {
        public ServerMessage Handle(ValueHolder valueHolder = null)
        {
            List<uint> newFloorItems = valueHolder.GetValueOrDefault<List<uint>>("Floors");
            List<uint> newWallItems = valueHolder.GetValueOrDefault<List<uint>>("Walls");
            List<uint> newPets = valueHolder.GetValueOrDefault<List<uint>>("Pets");

            ServerMessage message = BasicUtilies.GetRevisionServerMessage(Revision.PRODUCTION_201601012205_226667486);
            message.Init(r63cOutgoing.NewItemAdded);
            int amount_ = 0;
            if ((newFloorItems != null && newFloorItems.Count > 0) | (newWallItems != null && newWallItems.Count > 0) | (newPets != null && newPets.Count > 0))
            {
                amount_++;
            }
            message.AppendInt32(amount_);

            if (newFloorItems != null && newFloorItems.Count > 0)
            {
                message.AppendInt32(1);
                message.AppendInt32(newFloorItems.Count);
                foreach (uint itemId_ in newFloorItems)
                {
                    message.AppendUInt(itemId_);
                }
            }

            if (newWallItems != null && newWallItems.Count > 0)
            {
                message.AppendInt32(2);
                message.AppendInt32(newWallItems.Count);
                foreach (uint itemId_ in newWallItems)
                {
                    message.AppendUInt(itemId_);
                }
            }

            if (newPets!= null && newPets.Count > 0)
            {
                message.AppendInt32(3);
                message.AppendInt32(newPets.Count);
                foreach (uint petId in newPets)
                {
                    message.AppendUInt(petId);
                }
            }
            return message;
        }
    }
}
