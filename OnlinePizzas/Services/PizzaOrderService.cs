using OnlinePizzas.API.Domain.Models.Order;
using OnlinePizzas.API.Domain.Models.Order.ViewModels;
using OnlinePizzas.API.Domain.Repositories;
using OnlinePizzas.API.Domain.Services;
using OnlinePizzas.API.Models;
using OnlinePizzas.API.Models.Pizza.Interfaces;
using OnlinePizzas.API.Models.Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzas.API.Services
{
    /// <summary>
    /// Provides service endpoints for ordering pizzas and retreiving orders
    /// </summary>
    public class PizzaOrderService : ICustomOnlinePizzaService
    {
        protected readonly IPizzaOrderRepository _pizzaOrderRepository;
        public PizzaOrderService(IPizzaOrderRepository pizzaOrderRepository)
        {
            _pizzaOrderRepository = pizzaOrderRepository;
        }

        public async Task<OrderVm> CreateOrderAsync(NewOrderVm order)
        {
            var newOrder = Domain.Models.Pizza.Methods.Utility.GetPriceQuoteForCustomerOrder(order);
            var saveOrder = new Order
            {
                TotalPizzas = newOrder.TotalPizzas,
                TotalCost = newOrder.TotalCost
            };

            return await _pizzaOrderRepository.CreateOrderAsync(saveOrder);
        }

        

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _pizzaOrderRepository.GetAllOrdersAsync();
        }

        public OrderVm GetPriceQuote(NewOrderVm order)
        {
                OrderVm quote;
                quote = Domain.Models.Pizza.Methods.Utility.GetPriceQuoteForCustomerOrder(order);
                var deliveryCost = Domain.Models.Pizza.Methods.Utility.GetDistanceCost(order.Distance);
                quote.DeliveryCost = (deliveryCost < 0) ? 0 : deliveryCost;
                return quote;
        }
    }
}
