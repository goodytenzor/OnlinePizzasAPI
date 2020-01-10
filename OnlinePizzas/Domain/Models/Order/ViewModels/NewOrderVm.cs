using OnlinePizzas.API.Domain.Models.Pizza.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzas.API.Domain.Models.Order.ViewModels
{
    /// <summary>
    /// Representational model for an incoming pizza order 
    /// </summary>
    public class NewOrderVm
    {
        public int Distance { get; set; }

        public int CustomerId { get; set; } // in-active

        public List<CustomPizza> CustomPizzas { get; set; }

    }
}
