using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace GoSONICServer.Entity
{
    public class Character
    {
        public int CharacterType;
        public byte CharacterID;
        public Socket socket;
        public Character(int characterType, Socket socket)
        {
            this.CharacterType = characterType;
            this.socket = socket;
        }
    }
}
