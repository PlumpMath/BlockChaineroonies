using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BrockuChainuru
{
    public class Block
    {
        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }

        public Block(int index, string previousHash, DateTime timestamp, string data)
        {
            Index = index;
            PreviousHash = previousHash;
            TimeStamp = timestamp;
            Data = data;
        }
    }
}
