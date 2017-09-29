using System;

namespace WhoWouldWin
{
    abstract class Fighter
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public double DodgeChance { get; set; }
        public abstract int PerformAttack(Fighter target);
        public abstract void TakeDamage(int damage);
        protected static Random rng;

        public Fighter()
        {
            if(rng == null)
            {
                rng = new Random();
            }
        }

        public override string ToString()
        {
            return $"{Name}: {HP}";
        }
    }
}