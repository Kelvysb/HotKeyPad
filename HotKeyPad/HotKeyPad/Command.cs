using System.Collections.Generic;

namespace HotKeyPad
{
    internal class Command
    {
        public int Position { get; set; }

        public CommandMode Mode { get; set; }

        public byte HoldTime { get; set; }

        public byte DelayTime { get; set; }

        public bool Ctrl { get; set; }

        public bool Alt { get; set; }

        public bool Shift { get; set; }

        public bool Gui { get; set; }

        public List<byte> Keys { get; set; }
    }
}