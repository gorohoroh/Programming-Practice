using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    internal class Program
    {
        private static void Main()
        {
            UseSingleton();
            UseStrategy();
            UseFactory();
            UseBuilder();
            UseAdapter();
            UseObserver();
            UseVisitor();
        }

        private static void UseVisitor()
        {
            var competitionsToVisit = new List<ISummerOlympicSport>
            {
                new DivingCompetition(), new BadmintonMatch(), new CyclingTrackRace()
            };

            var competitionVisitor = new CompetitionVisitor();
            
            foreach (var competition in competitionsToVisit)
            {
                competition.Accept(competitionVisitor);
            }
        }

        private static void UseObserver()
        {
            var driver = new CarsharingCustomer("Louise Sawyer");

            var availableCars = new CarsharingPool();
            availableCars.Subscribe(driver);
            availableCars.AddCar(new SharedCar("Ford Thunderbird"));
        }

        private static void UseAdapter()
        {
            var americanSocket = new USSocket();
            var americanSocketAdapter = new USSocketAdapter(americanSocket);

            var laptop = new Laptop();
            laptop.Charge(americanSocketAdapter);
        }

        private static void UseBuilder()
        {
            Pizza pizza = new PizzaBuilder(28)
                .AddMozzarella()
                .AddSalami()
                .AddRuccola()
                .Build();

            Console.WriteLine(pizza.GetDescription());
        }

        private static void UseFactory()
        {
            ITennisBall ball = TennisBallFactory.DeliverBall();
            Console.WriteLine($"This is a {ball.GetMake()} ball with a diameter of {ball.GetDiameter()} mm");
        }

        private static void UseStrategy()
        {
            Match match = new Match(new AggressiveMatchStrategy());

            Shot shot1 = match.HitTheBall();

            Console.WriteLine(match.MatchStrategy);
            Console.WriteLine(shot1.ToString());
            
            if (new Random().Next(1, 10) > 5)
                match.MatchStrategy = new DefensiveMatchStrategy();

            Shot shot2 = match.HitTheBall();
            
            Console.WriteLine(match.MatchStrategy);
            Console.WriteLine(shot2.ToString());
        }

        private static void UseSingleton()
        {
            // President constructed = new President("Bernie", "Sanders", "Democratic"); // Fails to compile because constructor is private
            President a = President.GetInstance();
            President b = President.GetInstance();

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(a == b); // Should be true
        }
    }
}