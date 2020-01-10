using Microsoft.EntityFrameworkCore;
using OnlinePizzas.API.Domain.Models.Order;
using OnlinePizzas.API.Domain.Models.Order.ViewModels;
using OnlinePizzas.API.Domain.Repositories;
using OnlinePizzas.API.Models;
using OnlinePizzas.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzas.API.Persistence.Repositories
{
    public class PizzaOrderRepository : BaseRepository, IPizzaOrderRepository
    {
        //AppDbContext _context;
        public PizzaOrderRepository(AppDbContext context): base(context)
        {
            //_context = context;
        }

        public async Task<OrderVm> CreateOrderAsync(Order order)
        {
            var newOrder = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var vm = new OrderVm
            {
                OrderId = newOrder.Entity.OrderId,
                TotalCost = newOrder.Entity.TotalCost,
                TotalPizzas = newOrder.Entity.TotalPizzas
            };

            return vm;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }
    }
}
