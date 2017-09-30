using System;
using System.Threading;

namespace WhoWouldWin
{
    public class FightSimulation
    {
        public SimulationResult Result { get; private set; }

        private ManualResetEvent _doneEvent;

        private Knight _knight;
        private Dragon _dragon;

        private int _simCount;

        public FightSimulation(int simCount, ManualResetEvent doneEvent)
        {
            _simCount = simCount;
            _doneEvent = doneEvent;
            _knight = new Knight();
            _dragon = new Dragon();
        }

        private SimulationResult Simulate(int simCount)
        {
            var currSimCount = 0;
            var result = new SimulationResult();

            while(currSimCount++ < simCount) 
            {
                Console.WriteLine($"--------------\nSim #{currSimCount}\n");
                var knight = new Knight();
                var dragon = new Dragon();
                var turnCount = 0;

                do
                {
                    Console.WriteLine($"Turn {turnCount++}");
                    Console.WriteLine(knight);
                    Console.WriteLine(dragon);

                    knight.TakeDamage(dragon.PerformAttack(knight));
                    dragon.TakeDamage(knight.PerformAttack(dragon));
                } while(knight.HP > 0 && dragon.HP > 0);

                if (knight.HP < 1)
                {
                    Console.WriteLine("\nDragon wins\n");
                    ++result.DragonWins;
                }
                else if (dragon.HP < 1)
                {
                    Console.WriteLine("\nKnight wins\n");
                    ++result.KnightWins;
                }
            }

            return result;
        }

        public void ThreadPoolCallback(Object threadContext)  
        {  
            int threadIndex = (int)threadContext;  
            Console.WriteLine($"Thread {threadIndex} started");  
            Result = Simulate(_simCount);
            Console.WriteLine($"Thread {threadIndex} result calculated...");  
            _doneEvent.Set();  
        }  
    }
}