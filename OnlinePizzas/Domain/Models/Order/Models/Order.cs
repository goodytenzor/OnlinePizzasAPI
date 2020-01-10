using OnlinePizzas.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzas.API.Domain.Models.Order
{
    /// <summary>
    /// Persistence model for Pizza Orders
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        [Range(1, 100)]
        public int TotalPizzas { get; set; }

        [Required]
        public double TotalCost { get; set; }

    }
}
