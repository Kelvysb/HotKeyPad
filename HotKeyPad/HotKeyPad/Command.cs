using System.Collections.Generic;

namespace HotKeyPad
{
    internal class Command
    {
        public int Position { get; set; }

        public CommandMode Mode { get; set; }

        public char HoldTime { get; set; }

        public char DelayTime { get; set; }

        public bool Ctrl { get; set; }

        public bool Alt { get; set; }

        public bool Shift { get; set; }

        public bool Gui { get; set; }

        public List<char> Keys { get; set; }
    }
}