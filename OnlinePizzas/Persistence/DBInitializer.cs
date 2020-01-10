using OnlinePizzas.API.Domain.Models.Order;
using OnlinePizzas.API.Persistence.Contexts;
using System.Linq;

namespace OnlinePizzas.API.Persistence
{
    public class DBInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Orders.Any())
            {
                return; // DB has been seeded
            }

            //var customer1 = new Customer()
            //{ 
            //    Id = 100,
            //    FullName = "Martin Fowler",
            //    Password = "Myanmar",
            //    Email = "martin@lander.com"
            //};

            //context.Customers.Add(customer1);
            //context.SaveChanges();

            //var order1 = new Order()
            //{
            //    OrderId = 1000,
            //    TotalCost = 13.00,
            //    TotalPizzas = 5,
            //    Customer = customer1
            //};

            //context.Orders.Add(order1);
            //context.SaveChanges();

            var order2 = new Order()
            {
                OrderId = 1001,
                TotalCost = 7.49,
                TotalPizzas = 3,
                //Customer = customer1
            };

            context.Orders.Add(order2);
            context.SaveChanges();
        }
    }
}
