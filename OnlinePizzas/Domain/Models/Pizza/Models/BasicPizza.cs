using OnlinePizzas.API.Domain.Models.Pizza.Methods;
using OnlinePizzas.API.Models.Pizza.Interfaces;

namespace OnlinePizzas.API.Models.Pizza.Models
{
    class BasicPizza : IPizza
    {
        private static int _totalPizzas;
        private static double _distanceCost;
        
        public BasicPizza(int count)
        {
            _totalPizzas = count;
        }

        public static BasicPizza TakeOrder(int numberOfPizzas, int distanceToCustomer)
        {
            _distanceCost = Utility.GetDistanceCost(distanceToCustomer);

            if (_distanceCost > 0 && numberOfPizzas > 0)
            {
                return new BasicPizza(numberOfPizzas);
            }

            return null;
        }

        private double _cost = 5.00;

        public double DeliveryCost { get { return _distanceCost; } }

        public double TotalCost()
        {
            return ToppingCost() + _distanceCost;
        }

        public string GetDescription()
        {
            return "Yummy crust pizza";
        }

        public double ToppingCost()
        {
            return _totalPizzas * _cost ;
        }

        int IPizza.TotalPizzas()
        {
            return _totalPizzas;
        }
    }
}
