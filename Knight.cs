namespace WhoWouldWin
{
    class Knight : Fighter
    {
        public Knight() : base()
        {
            Name = "Knight";
            HP = 300;
            Attack = 80;
            Defense = 30;
            DodgeChance = 0.9;
        }

        public override int PerformAttack(Fighter target)
        {
            var damage = this.Attack - target.Defense;
            var critChance = rng.NextDouble();

            if (critChance <= 0.33)
            {
                damage *= 3;
            }

            return damage;
        }

        public override void TakeDamage(int damage)
        {
            var dodgeChance = rng.NextDouble();

            if (dodgeChance <= DodgeChance)
            {
                damage = 0;
            }

            HP -= damage;
        }
    }
}