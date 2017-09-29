namespace WhoWouldWin
{
    class Dragon : Fighter
    {
        public Dragon() : base()
        {
            Name = "Dragon";
            HP = 1500;
            Attack = 120;
            Defense = 60;
            DodgeChance = 0;
        }

        public override int PerformAttack(Fighter target)
        {
            var damage = this.Attack - target.Defense;
            var critChance = rng.NextDouble();

            if (critChance <= 0.25)
            {
                damage = target.HP;
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