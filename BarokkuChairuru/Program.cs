using System;
using System.Collections.Generic;

namespace BrockuChainuru
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup blockchain
            var chain = new BlockChain();

            // Generate block + validate + add block to chain
            chain.Add(chain.GenerateNextBlock(";Nieuwe update!"));
            chain.Add(chain.GenerateNextBlock(";Meer data"));

            foreach (var block in chain.Blocks)
            {
                Console.WriteLine($"{block.Index}:{block.PreviousHash}:{block.Hash}:{block.TimeStamp.Ticks}:{block.Data}");
            }

            Console.WriteLine($"Block state: {chain.State}");

            Console.ReadLine();
        }

    }
}
