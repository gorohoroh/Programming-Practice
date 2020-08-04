namespace DesignPatterns
{
    class Pizza
    {
        public int Size { get; }
        public bool Salami { get; }
        public bool Mozzarella { get; }
        public bool Ruccola { get; }

        public Pizza(PizzaBuilder builder)
        {
            Size = builder.Size;
            Salami = builder.Salami;
            Mozzarella = builder.Mozzarella;
            Ruccola = builder.Ruccola;
        }

        public string GetDescription() => $"This is a {Size} cm pizza. ";
    }

    class PizzaBuilder
    {
        public int Size;
        public bool Salami { get; set; }
        public bool Mozzarella { get; set; }
        public bool Ruccola { get; set; }

        public PizzaBuilder(int size) => Size = size;

        public PizzaBuilder AddSalami()
        {
            Salami = true;
            return this;
        }

        public PizzaBuilder AddMozzarella()
        {
            Mozzarella = true;
            return this;
        }

        public PizzaBuilder AddRuccola()
        {
            Ruccola = true;
            return this;
        }

        public Pizza Build() => new Pizza(this);
    }
}