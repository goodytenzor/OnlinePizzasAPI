using AutoMapper;
using OnlinePizzas.API.Domain.Models.Order;
using OnlinePizzas.API.Domain.Models.Order.ViewModels;

namespace OnlinePizzas.API.Mapping
{
    public class ModelToViewModel: Profile
    {
        public void ModelToResourceProfile()
        {
           CreateMap<Order, OrderVm>();
        }
    }
}
