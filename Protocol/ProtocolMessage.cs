using System;
using System.Collections.Generic;
using System.Text;

namespace InfiniteHelper.Protocol
{
    public enum ProtocolMessage : int
    {
        CharacterQWordUpdate = 0x02CF,
        CharacterDWordUpdate = 0x02CD,
        OrderedMessage = 0xF7B0,
        CharacterLogin = 0x0013
    }
}
