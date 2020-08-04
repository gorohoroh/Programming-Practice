namespace DesignPatterns
{
    public interface ITennisBall
    {
        int GetDiameter();
        string GetMake();
    }

    public class GrassCourtTennisBall : ITennisBall
    {
        private string Color { get; set; }
        private int Diameter { get; set; }
        private int Bounce { get; set; }
        private string Make { get; set; }

        public GrassCourtTennisBall()
        {
            Color = "Optic yellow";
            Diameter = 67;
            Bounce = 145;
            Make = "Slazenger Wimbledon";
        }

        public int GetDiameter() => Diameter;
        public string GetMake() => Make;
    }
    
    public static class TennisBallFactory
    {
        public static ITennisBall DeliverBall() => new GrassCourtTennisBall();
    }
}
    
    