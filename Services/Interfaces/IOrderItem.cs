using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrderItem
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemAsync();
        ValueTask<OrderItem> GetAllOrderItemByIdAsync(int id);
        Task<OrderItem> RemoveOrderItemAsync(OrderItem delOrderItem);
        Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem);
        Task UpdateOrderItemAsync(OrderItem currentOrderItem, OrderItem newOrderItem);
    }
}
