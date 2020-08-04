namespace DesignPatterns
{
    interface IMatchStrategy
    {
        Shot HitTheBall();
    }

    class DefensiveMatchStrategy : IMatchStrategy
    {
        public Shot HitTheBall()
        {
            return new Shot
            {
                Type = ShotTypes.Slice,
                Power = 0.7
            };
        }
    }

    class AggressiveMatchStrategy : IMatchStrategy
    {
        public Shot HitTheBall()
        {
            return new Shot
            {
                Type = ShotTypes.Flat,
                Power = 1.2
            };
        }
    }

    class Match
    {
        internal Match(IMatchStrategy matchStrategy) => MatchStrategy = matchStrategy;
        internal IMatchStrategy MatchStrategy { get; set; }
        internal Shot HitTheBall() => MatchStrategy.HitTheBall();
    }

    class Shot
    {
        internal ShotTypes Type { get; set; }
        internal double Power { get; set; }
        public override string ToString() => $"{Type}, {Power}";
    }

    enum ShotTypes
    {
        Slice, Topspin, Flat, Dropshot, Volley
    }
}