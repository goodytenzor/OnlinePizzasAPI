using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzas.API.Domain.Models.Pizza.ViewModels
{
    /// <summary>
    /// Representational model that identifies a pizza and the type 
    /// of toppings it has.
    /// </summary>
    public class CustomPizza
    {
        public List<string> Toppings { get; set; }

        public string PizzaId { get; set; }
    }
}
