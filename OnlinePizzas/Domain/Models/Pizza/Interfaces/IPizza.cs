using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzas.API.Models.Pizza.Interfaces
{
    /// <summary>
    /// Represents a type of pizza (basic or tomato, ham, etc).
    /// Each pizza provides information about thier total cost, 
    /// total number of pizzas, total cost for toppings and 
    /// provides a description about the pizza
    /// </summary>
    interface IPizza
    {
        abstract int TotalPizzas();

        abstract double ToppingCost();

        abstract double TotalCost();

        abstract string GetDescription();
    }
}
