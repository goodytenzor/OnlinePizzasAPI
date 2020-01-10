using OnlinePizzas.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzas.API.Domain.Models.Order.ViewModels
{
    /// <summary>
    /// Representational model of an invoiced pizza order retuned to the requesting client application
    /// </summary>
    public class OrderVm
    {
        public int OrderId { get; set; }

        public int TotalPizzas { get; set; }

        public double DeliveryCost { get; set; }

        public double TotalCost { get; set; }

        public List<string> OrderedItems { get; set; }

    }
}
