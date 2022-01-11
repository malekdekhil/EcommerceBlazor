using Domains;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkManager;

namespace Services.Implementations
{
    public class ClsOrderItem : IOrderItem
    {
        private IUnitOfWork unitOfWork;

        public ClsOrderItem(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderItem>> GetAllOrderItemAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<OrderItem> GetAllOrderItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> RemoveOrderItemAsync(OrderItem delOrderItem)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrderItemAsync(OrderItem currentOrderItem, OrderItem newOrderItem)
        {
          await unitOfWork.CommitAsync();
        }
    }
}
