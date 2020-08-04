namespace DesignPatterns
{
// Visitee
    interface ISummerOlympicSport
    {
        void Accept(ICompetitionVisitor visitor);
    }

    class DivingCompetition : ISummerOlympicSport
    {
        public void Jump() { }
        public void Accept(ICompetitionVisitor visitor) => visitor.WatchDiving(this);
    }

    class CyclingTrackRace : ISummerOlympicSport
    {
        public void Ride() { }
        public void Accept(ICompetitionVisitor visitor) => visitor.WatchCycling(this);
    }

    class BadmintonMatch : ISummerOlympicSport
    {
        public void Hit() { }
        public void Accept(ICompetitionVisitor visitor) => visitor.WatchBadminton(this);
    }

    
// Visitor
    interface ICompetitionVisitor
    {
        void WatchDiving(DivingCompetition divingCompetition);
        void WatchCycling(CyclingTrackRace cyclingTrackRace);
        void WatchBadminton(BadmintonMatch badmintonMatch);
    }
    
    class CompetitionVisitor : ICompetitionVisitor
    {
        public void WatchBadminton(BadmintonMatch badmintonMatch) => badmintonMatch.Hit();
        public void WatchCycling(CyclingTrackRace cyclingTrackRace) => cyclingTrackRace.Ride();
        public void WatchDiving(DivingCompetition divingCompetition) => divingCompetition.Jump();
    }
}