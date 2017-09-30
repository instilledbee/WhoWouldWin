using System;
using System.Threading;

namespace WhoWouldWin
{
    class Program
    {
        const int MAX_THREADS = 4;

        static void Main(string[] args)
        {
            var simCount = ParseArgs(args);
            var threadsToUse = (simCount > MAX_THREADS) ? MAX_THREADS : simCount;
            var simPerThread = (simCount > MAX_THREADS) ? (simCount / threadsToUse) : 1;
            var extraSims = (simCount > MAX_THREADS) ? (simCount % MAX_THREADS) : 0;
            
            ManualResetEvent[] doneEvents = new ManualResetEvent[threadsToUse];  
            FightSimulation[] simArray = new FightSimulation[threadsToUse];

            Console.WriteLine($"Launching {threadsToUse} thread(s)...");  
            for (int i = 0; i < threadsToUse; i++)  
            {  
                doneEvents[i] = new ManualResetEvent(false);
                // add remainder sims on the 1st thread
                simArray[i] = new FightSimulation(i == 0 ? (simPerThread + extraSims) : simPerThread, doneEvents[i]);  
                ThreadPool.QueueUserWorkItem(simArray[i].ThreadPoolCallback, i);  
            }

            WaitHandle.WaitAll(doneEvents);  
            Console.WriteLine("All calculations are complete.");

            for (int i = 0; i < threadsToUse; i++)  
            {
                Console.WriteLine(simArray[i].Result);  
            } 
        }

        static int ParseArgs(String[] args)
        {
            var arg = 0;

            if (args.Length == 0)
            {
                // Default to 1 simulation
                arg = 1;
            }
            else
            {
                if (!int.TryParse(args[0], out arg))
                {
                    arg = 1;
                }
            }

            return arg;
        }
    }
}
