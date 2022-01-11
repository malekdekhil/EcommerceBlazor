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
    public class ClsOrder : IOrder
    {
        private readonly IUnitOfWork unitOfWork;

        public ClsOrder(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await unitOfWork.Orders.AddAsync(order);
            await unitOfWork.CommitAsync();
            return order;
        }

        public  async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await unitOfWork.Orders.GetAllAsync();
        }

        public async ValueTask<Order> GetAllOrderByIdAsync(int id)
        {
            return await unitOfWork.Orders.GetByIdAsync(id);
        }

        public async Task<Order> RemoveOrderAsync(Order delOrder)
        {
            unitOfWork.Orders.Remove(delOrder);
            await unitOfWork.CommitAsync();
            return delOrder;
        }

        public async Task UpdateOrderAsync(Order currentOrder, Order newOrder)
        {
            currentOrder.Status = newOrder.Status;
            currentOrder.TrakingNumber = newOrder.TrakingNumber;
            await unitOfWork.CommitAsync();
        }
    }
}
