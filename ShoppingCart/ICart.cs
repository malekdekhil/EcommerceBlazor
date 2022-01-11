using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public interface ICart
    {
        Cart getAll();
        Task<Cart> AddCart(int id);
        Task<Cart> InitializeShoppingCart();
        Task ClearCart();
        Task DeleteCartItem(int id);
        Task DeleteItem(int id);
 
    }
}
