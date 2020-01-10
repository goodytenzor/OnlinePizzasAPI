using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzas.API.Domain.Models.Order;
using OnlinePizzas.API.Domain.Models.Order.ViewModels;
using OnlinePizzas.API.Domain.Services;

namespace OnlinePizzas.Controllers
{
    /// <summary>
    /// Exposes endpoints for Ordering Pizzas and retrieving order information
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        protected readonly ICustomOnlinePizzaService _pizzaOrderService;
        private readonly IMapper _mapper;

        public OrderController(ICustomOnlinePizzaService pizzaOrderService)
        {
            _pizzaOrderService = pizzaOrderService;
        }

        // Get price model for the number of pizzas and distance to home
        [Route("GetPriceQuote")]
        [HttpPost]
        public OrderVm GetPriceQuote(NewOrderVm orderVm)
        {
            return _pizzaOrderService.GetPriceQuote(orderVm);
        }

        // Get all orders 
        [Route("GetAllOrders")]
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _pizzaOrderService.GetAllOrdersAsync();
        }

        // Make an order for the pizzas
        [Route("CreateOrder")]
        [HttpPost]
        public async Task<OrderVm> CreateOrder(NewOrderVm order)
        {
            var newOrder = await _pizzaOrderService.CreateOrderAsync(order);
            return newOrder;
        }
    }
}