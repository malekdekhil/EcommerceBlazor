using Domains;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWorkManager;

namespace Services.Implementations
{
    public class ClsProduct : IProduct
    {
        private readonly IUnitOfWork unitOfWork;

        public ClsProduct(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await unitOfWork.Products.AddAsync(product);
            await unitOfWork.CommitAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await unitOfWork.Products.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsIncludeCategoriesAsync()
        {
            return await unitOfWork.Products.GetAllInclude();
        }

        public async Task<IEnumerable<Product>> GetAllProductsIncludeOpinionsAsync()
        {
            return await unitOfWork.Products.GetAllIncludeOpinions();
        }

        public async Task<IEnumerable<Product>> GetAllProductsIncludePicturesAsync()
        {
            return await unitOfWork.Products.GetAllIncludePictures();
        }

        public async Task GetPicturePath(int idPicture, int idProduct)
        {
            await unitOfWork.Products.PicturePath(idPicture, idProduct);
        }

        public async ValueTask<Product> GetProductByIdAsync(int id)
        {
            return await unitOfWork.Products.GetByIdAsync(id);
        }

        public async ValueTask<Product> GetProductByIdIncludePictureAsync(int idProduct)
        {
            return await unitOfWork.Products.GetByIdIncludePictures(idProduct);
        }

        public async Task<IEnumerable<Product>> GetRandomProductsAsync()
        {
            return await unitOfWork.Products.GetRandomProducts();

        }

        public async Task<IEnumerable<Product>> GetSearchProducAsync(string term)
        {
            return await unitOfWork.Products.GetSearchProducts(term);
        }

        public async Task RemoveProductAsync(Product delProduct)
        {
            unitOfWork.Products.Remove(delProduct);
            await unitOfWork.CommitAsync();
        }

        public async Task UpdateProductAsync(Product currentProduct, Product newProduct)
        {
            currentProduct.Name = newProduct.Name;
            currentProduct.ImageUrl = newProduct.ImageUrl;
            currentProduct.LongDescription = newProduct.LongDescription;
            currentProduct.ShortDescription = newProduct.ShortDescription;
            currentProduct.SalesPrice = newProduct.SalesPrice;
            currentProduct.InPromo = newProduct.InPromo;
            currentProduct.SeoName = newProduct.SeoName;
            currentProduct.Quantity = newProduct.Quantity;
            currentProduct.PurchasePrice = newProduct.PurchasePrice;
            currentProduct.ShippingPrice = newProduct.ShippingPrice;
            currentProduct.CreationDate = newProduct.CreationDate;
            currentProduct.IdCategory_Fk = newProduct.IdCategory_Fk;
            await unitOfWork.CommitAsync();
        }
    }
}
