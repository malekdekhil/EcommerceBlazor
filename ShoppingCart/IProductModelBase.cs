using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public interface IProductModelBase
    {
        Task CallAddToCart(int id);
        Task CallRemoveCartItem(int id);
        Task CallRemoveItem(int id);
        Task CallClearBasket();
         void GetPicturePath(int idPicture, int idProduct);
     }
}
