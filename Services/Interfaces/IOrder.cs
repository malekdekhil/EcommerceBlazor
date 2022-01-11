using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        ValueTask<Order> GetAllOrderByIdAsync(int id);
        Task<Order> RemoveOrderAsync(Order delOrder);
        Task<Order> CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order currentOrder, Order newOrder);
    }
}
