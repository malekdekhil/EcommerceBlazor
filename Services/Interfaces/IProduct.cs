using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetAllProductsIncludeCategoriesAsync();
        Task<IEnumerable<Product>> GetAllProductsIncludeOpinionsAsync();
        Task<IEnumerable<Product>> GetAllProductsIncludePicturesAsync();
        ValueTask<Product> GetProductByIdAsync(int id);
        Task RemoveProductAsync(Product delProduct);
        Task<Product> CreateProductAsync(Product product);
        Task UpdateProductAsync(Product currentProduct, Product newProduct);
        Task GetPicturePath(int idPicture, int idProduct);
        ValueTask<Product> GetProductByIdIncludePictureAsync(int idProduct);

    }
}
