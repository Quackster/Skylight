﻿using SkylightEmulator.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylightEmulator.Messages
{
    public abstract class ServerMessage
    {
        public abstract void Init();
        public abstract void Init(uint id);
        public abstract uint GetID();
        public abstract int GetLenght();
        public abstract Revision GetRevision();
        public abstract void AppendShort(int s);
        public abstract void AppendInt32(int i);
        public abstract void AppendUInt(uint u);
        public abstract void AppendString(string s);
        public abstract void AppendString(string s, byte? b);
        public abstract void AppendBoolean(bool b);
        public abstract void AppendBytes(List<byte> bytes);
        public abstract void AppendBytes(byte[] bytes);
        public abstract byte[] GetBytes();
        public abstract string GetHeader();
        public abstract string GetBody();
    }
}
