using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public interface IShoppingUserTmp
    {
        Task<UserTmp> InitializeShoppingUserTmp();
        Task TransactionOrderUserTmp();
        Task ClearInfoUserTmp();
    }
}
