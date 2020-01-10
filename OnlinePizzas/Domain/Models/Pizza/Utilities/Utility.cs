using OnlinePizzas.API.Domain.Models.Order.ViewModels;
using OnlinePizzas.API.Models.Pizza.Interfaces;
using OnlinePizzas.API.Models.Pizza.Models;
using System;
using System.Collections.Generic;

namespace OnlinePizzas.API.Domain.Models.Pizza.Methods
{
    public static class Utility
    {
        
        /// <summary>
        /// Uses the new order request model to calculate the cost for each pizza and
        /// their toppings with the distance for delivery as total cost factor.
        /// </summary>
        /// <param name="order">Represents a pizza order request</param>
        /// <returns>A price for the order, description of the order, order ID, total pizzas
        /// and the delivery cost.</returns>
        public static OrderVm GetPriceQuoteForCustomerOrder(NewOrderVm order)
        {
            IPizza appliedTopping = BasicPizza.TakeOrder(order.CustomPizzas.Count, order.Distance);

            if (appliedTopping == null)
                return new OrderVm();

            List<string> itemDescriptions = new List<string>();

            foreach (var cp in order.CustomPizzas)
            {
                string desc = cp.Toppings.Count > 0 ? "Yummy crust pizza with" : "Yummy crust pizza";

                foreach (string topping in cp.Toppings)
                {   
                    switch (topping.ToUpper())
                    {
                        case "TOMATOSAUCE":
                            appliedTopping = new TomatoSaucePizza(appliedTopping);
                            desc += appliedTopping.GetDescription();
                            break;
                        case "MOZARELLACHEESE":
                            appliedTopping = new MozarellaCheesePizza(appliedTopping);
                            desc += appliedTopping.GetDescription();
                            break;
                        case "HAM":
                            appliedTopping = new HamPizza(appliedTopping);
                            desc += appliedTopping.GetDescription();
                            break;
                        case "KEBAB":
                            appliedTopping = new KebabPizza(appliedTopping);
                            desc += appliedTopping.GetDescription();
                            break;
                        default:
                            break;
                    }
                    
                }

                itemDescriptions.Add(desc);
            }

            return new OrderVm() { 
                TotalCost = Math.Round(appliedTopping.TotalCost(),2), 
                TotalPizzas = order.CustomPizzas.Count,
                OrderedItems = itemDescriptions 
            };
        }

        /// <summary>
        /// Validates if the order can be accepted based on the distance.
        /// </summary>
        /// <param name="distance">Distance cannot be more than 5 and less than 0.</param>
        /// <returns>Cost for delivery</returns>
        public static double GetDistanceCost(int distance)
        {
            double cost;

            if (distance >= 0 && distance <= 2)
            {
                cost = 1;
            }
            else if (distance > 2 && distance < 6)
            {
                cost = 2;
            }
            else
            {
                cost = -1; // if we need to deliver far far far away, greater than 5 kms - too costly to deliver
            }

            return cost;
        }
    }

}
