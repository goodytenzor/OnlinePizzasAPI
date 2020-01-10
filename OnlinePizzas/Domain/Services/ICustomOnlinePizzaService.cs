using OnlinePizzas.API.Domain.Models.Order;
using OnlinePizzas.API.Domain.Models.Order.ViewModels;
using OnlinePizzas.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzas.API.Domain.Services
{
    /// <summary>
    /// Enforces operations for ordering pizzas and retreiving orders
    /// </summary>
    public interface ICustomOnlinePizzaService
    {
        OrderVm GetPriceQuote(NewOrderVm newOrder);

        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<OrderVm> CreateOrderAsync(NewOrderVm order);

    }
}
