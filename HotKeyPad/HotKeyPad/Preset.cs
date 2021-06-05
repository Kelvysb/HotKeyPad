using System.Collections.Generic;

namespace HotKeyPad
{
    internal class Preset
    {
        public string Name { get; set; }

        public List<Command> Commands { get; set; }
    }
}