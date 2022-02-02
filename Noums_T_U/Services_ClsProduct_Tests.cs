using AutoFixture.Xunit2;
using Domains;
using FluentAssertions;
using Moq;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkManager;
using Xunit;

namespace Noums_T_U
{
    public class Services_ClsProduct_Tests
    {
        [Theory]
        [InlineAutoData(1, 1, "product1", "Category1", 5, 15)]
        [InlineAutoData(2, 1, "product2", "Category1", 8, 23)]
        private async void Retrun_Products_Include_Category_GetAllProductsAsync_Test(
            int idProduct, int idCategory, string productName,
            string category, int qte, decimal price
            )
        {
            //A
            var repo = new Mock<IUnitOfWork>();
            repo.Setup(layer => layer.Products.GetAllInclude()).Returns(ProductsIncludeCategories());
            //A
            var sut = await new ClsProduct(repo.Object).GetAllProductsIncludeCategoriesAsync();
            //A
            sut.Should().NotBeNullOrEmpty();
            sut.Should().BeOfType<List<Product>>();
            foreach (var product in sut.Where(a => a.IdProduct == idProduct))
            {
                product.Category.CategoryName.Should().Be(category);
                product.IdCategory_Fk.Should().Be(idCategory);
                product.Name.Should().Be(productName);
                product.SalesPrice.Should().Be(price);
                product.Quantity.Should().Be(qte);
                product.IdProduct.Should().Be(idProduct);
            }
        }
        [Theory]
        [InlineAutoData(1, 1, "product1", 5, 15, "picture1", "path\\picture1", 1)]
        private async void Retrun_Products_Include_Pictures_GetAllProductsAsync_Test(
            int idProduct, int idCategory, string productName, int qte, decimal price,
            string namePicture, string pathPicture, int idPicture
            )
        {
            //A
            var repo = new Mock<IUnitOfWork>();
            repo.Setup(layer => layer.Products.GetAllIncludePictures()).Returns(ProductsIncludePictures());
            //A
            var sut = await new ClsProduct(repo.Object).GetAllProductsIncludePicturesAsync();
            //A
            sut.Should().NotBeNullOrEmpty();
            sut.Should().BeOfType<List<Product>>();
            foreach (var product in sut.ToList())
            {
                product.IdCategory_Fk.Should().Be(idCategory);
                product.Name.Should().Be(productName);
                product.SalesPrice.Should().Be(price);
                product.Quantity.Should().Be(qte);
                product.IdProduct.Should().Be(idProduct);
                foreach (var pic in product.Pictures.ToList())
                {
                    pic.Name.Should().Be(namePicture);
                    pic.UrlPicture.Should().Be(pathPicture);
                    pic.IdPictures.Should().Be(idPicture);
                }
            }
        }
        [Theory]
        [AutoData]
        private async void Verify_Executing_Of_Update_UpdateProductAsync_Test([Frozen] Mock<IProduct> iproduct, [Frozen] Mock<IUnitOfWork> unit)
        {
            var currentProd = GetProductByIdIncludeCategories(1);
            var newProd = GetProductByIdIncludeCategories(2);
            //A
            iproduct.Setup(layer => layer.UpdateProductAsync(currentProd, newProd)).Verifiable();
            //A
            await new ClsProduct(unit.Object).UpdateProductAsync(currentProd, newProd);
            //A
            unit.Verify(a => a.CommitAsync(), Times.Once);
        }
        [Theory]
        [AutoData]
        private async void Verify_Delete_Product_RemoveProductAsync_Test([Frozen] Mock<IProduct> iproduct, [Frozen] Mock<IUnitOfWork> unit)
        {
            var currentProd = GetProductByIdIncludeCategories(1);
            //A
            iproduct.Setup(l => l.RemoveProductAsync(currentProd)).Verifiable();
            //A
            await new ClsProduct(unit.Object).RemoveProductAsync(currentProd);
            //A
            unit.Verify(a => a.Products.Remove(currentProd), Times.Once);
            unit.Verify(a => a.CommitAsync(), Times.Once);
        }
        private Product GetProductByIdIncludeCategories(int id)
        {
            return ProductsIncludeCategories().Result.FirstOrDefault(a => a.IdProduct == id);
        }
        private async Task<IEnumerable<Product>> ProductsIncludeCategories()
        {
            var cayegory = new Category { IdCategory = 1, CategoryName = "Category1" };
            return await Task.FromResult(new List<Product>
            {
                new Product{IdProduct=1,IdCategory_Fk=1,Name="product1",Quantity=5,Category=cayegory,ImageUrl="path\\picture1",SalesPrice=15,InPromo=false},
                new Product{IdProduct=2,IdCategory_Fk=1,Name="product2",Quantity=8,Category=cayegory,ImageUrl="path\\picture2",SalesPrice=23,InPromo=false},
            });
        }
        private async Task<IEnumerable<Product>> ProductsIncludePictures()
        {
            var pictures = new List<Picture> { new Picture { IdPictures = 1, IdProduct_Fk = 1, Name = "picture1", UrlPicture = "path\\Picture1" } };
            return await Task.FromResult(new List<Product>
            {
                new Product{IdProduct=1,IdCategory_Fk=1,Name="product1",Quantity=5,Pictures=pictures,ImageUrl="path\\picture1",SalesPrice=15,InPromo=false},
            });
        }
    }
}
