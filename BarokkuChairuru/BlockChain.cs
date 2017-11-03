using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BrockuChainuru
{
    public class BlockChain
    {
        private static List<Block> _blocks { get; set; } = new List<Block>();

        public Block[] Blocks
        {
            get
            {
                return _blocks.ToArray();
            }
        }

        public string State
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var block in Blocks)
                {
                    builder.Append(block.Data);
                }

                return builder.ToString();
            }
        }

        public BlockChain()
        {
            // Add the genesis block
            var terminatorGenesis = new Block(0, "0", new DateTime(1465154705), "CyberdyneSystems");
            terminatorGenesis.Hash = CalculateHash(terminatorGenesis);
            _blocks.Add(terminatorGenesis);
        }

        public Block GenerateNextBlock(string blockData)
        {
            var previousBlock = _blocks.Last();
            var nextIndex = previousBlock.Index + 1;
            var nextTimestamp = DateTime.Now;
            
            var nextBlock = new Block(nextIndex, previousBlock.Hash, DateTime.Now, blockData);
            nextBlock.Hash = CalculateHash(nextBlock);
            return nextBlock;
        }

        public void Add(Block newBlock)
        {
            if (ValidateBlock(newBlock))
            {
                _blocks.Add(newBlock);
            }
        }

        private string CalculateHash(Block block)
        {
            var hashString = $"{block.Index}{block.PreviousHash}{block.TimeStamp.Ticks}{block.Data}";
            var hash = SHA256.Create();
            var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(hashString));
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        private bool ValidateBlock(Block newBlock)
        {
            var previousBlock = _blocks.Last();

            if (previousBlock.Index + 1 != newBlock.Index)
            {
                Console.WriteLine("invalid index");
                return false;
            }
            else if (previousBlock.Hash != newBlock.PreviousHash)
            {
                // Make sure that no block can be added further down the chain. This prevents changing the history.
                Console.WriteLine("invalid previous hash");
            }
            else if (newBlock.Hash != CalculateHash(newBlock))
            {
                Console.WriteLine("invalid hash");
                return false;
            }

            return true;
        }
    }
}
