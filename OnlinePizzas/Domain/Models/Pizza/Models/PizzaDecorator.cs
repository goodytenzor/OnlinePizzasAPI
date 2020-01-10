using OnlinePizzas.API.Models.Pizza.Interfaces;

namespace OnlinePizzas.API.Models.Pizza.Models
{
    /// <summary>
    /// Each type of pizza will be responsible for providing
    /// implementations for the methods exposed by this class
    /// </summary>
    abstract class PizzaDecorator : IPizza
    {
        protected IPizza _pizza;

        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public abstract double ToppingCost();

        public abstract double TotalCost();

        public abstract string GetDescription();

        public abstract int TotalPizzas();

    }
}
