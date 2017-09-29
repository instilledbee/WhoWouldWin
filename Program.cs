using System;

namespace WhoWouldWin
{
    class Program
    {
        static void Main(string[] args)
        {
            var simCount = ParseArgs(args);
            var currSimCount = 0;
            var knightWins = 0;
            var dragonWins = 0;

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
                    ++dragonWins;
                }
                else if (dragon.HP < 1)
                {
                    Console.WriteLine("\nKnight wins\n");
                    ++knightWins;
                }
            }

            Console.WriteLine($"Dragon victories: {dragonWins}");
            Console.WriteLine($"Knight victories: {knightWins}");
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
