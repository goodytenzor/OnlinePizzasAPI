using OnlinePizzas.API.Models.Pizza.Interfaces;

namespace OnlinePizzas.API.Models.Pizza.Models
{
    class MozarellaCheesePizza : PizzaDecorator
    {
        IPizza _thisPizza;
        private double _cost = 1.00;

        public MozarellaCheesePizza(IPizza pizza) : base(pizza)
        {
            _thisPizza = pizza;
        }

        public override double TotalCost()
        {
            return ToppingCost() + _thisPizza.TotalCost();
        }

        public override string GetDescription()
        {
           return ", Mozarella Cheese";
        }

        public override double ToppingCost()
        {
            return TotalPizzas() > 3 ? 0 : _cost;
        }

        public override int TotalPizzas()
        {
            return _thisPizza.TotalPizzas();
        }
    }
}
