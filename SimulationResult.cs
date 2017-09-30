namespace WhoWouldWin
{
    public class SimulationResult
    {
        public int KnightWins { get; set; }
        public int DragonWins { get; set; }

        public int TotalTries
        {
            get { return KnightWins + DragonWins; }
        }

        public override string ToString()
        {
            double dragonPercentage = (double)DragonWins / TotalTries * 100.0;
            double knightPercentage = (double)KnightWins / TotalTries * 100.0;
            return $"Dragon victories: {DragonWins}/{TotalTries} ({dragonPercentage}%)\n" + 
                        $"Knight victories: {KnightWins}/{TotalTries} ({knightPercentage}%)";
        }
    }
}