using OnlinePizzas.API.Models.Pizza.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzas.API.Models.Pizza.Models
{
    class HamPizza : PizzaDecorator
    {
        IPizza _thisPizza;
        private double _cost = 1.49;

        public HamPizza(IPizza pizza) : base(pizza)
        {
            _thisPizza = pizza;
        }

        public override double TotalCost()
        {
            return ToppingCost() + _thisPizza.TotalCost();
        }

        public override string GetDescription()
        {
           return ", Ham ";
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
