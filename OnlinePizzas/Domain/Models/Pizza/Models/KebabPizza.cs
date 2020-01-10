using OnlinePizzas.API.Models.Pizza.Interfaces;

namespace OnlinePizzas.API.Models.Pizza.Models
{
    class KebabPizza: PizzaDecorator
    {
        IPizza _thisPizza;
        private double _cost = 2.99;

        public KebabPizza(IPizza pizza) : base(pizza)
        {
            _thisPizza = pizza;
        }

        public override double TotalCost()
        {
            return ToppingCost() + _thisPizza.TotalCost();
        }

        public override string GetDescription()
        {
           return ", Kebab";
        }

        public override double ToppingCost()
        {
            return _cost;
        }

        public override int TotalPizzas()
        {
            return _thisPizza.TotalPizzas();
        }
    }
}
