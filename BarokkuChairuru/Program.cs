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
                WriteBlockToConsole(block);
            }

            Console.WriteLine($"Block state: {chain.State}");
            Console.ReadLine();
        }

        private static void WriteBlockToConsole(Block block)
        {
            Console.WriteLine($"Block Height: {block.Index}");
            Console.WriteLine($"Hash: {block.Hash}");
            Console.WriteLine($"Previous Hash: {block.PreviousHash}");
            Console.WriteLine($"Timestamp: {block.TimeStamp.Ticks}");
            Console.WriteLine($"Data: {block.Data}");
            Console.WriteLine();
        }
    }
}
