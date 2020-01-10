using OnlinePizzas.API.Domain.Models.Order;
using OnlinePizzas.API.Domain.Models.Order.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzas.API.Domain.Repositories
{
    /// <summary>
    /// Exposes various operations on the Order entity.
    /// </summary>
    public interface IPizzaOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<OrderVm> CreateOrderAsync(Order order);
    }
}
