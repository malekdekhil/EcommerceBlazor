using AutoFixture;
using Business_Logic.Interfaces;
using Business_Logic.Repositories;
using Data;
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

namespace TU_Sln_Noums
{
    public class Business_Logic_Test
    {
      
        [Fact]
        public async void GetAllProductTest_return_ListOfProduct()
        {
            //arrange

             Mock<IUnitOfWork> ProductsRepo = new Mock<IUnitOfWork>();

            //act

            ProductsRepo.Setup(a => a.Products.GetAllAsync()).Returns(GetAllProductsTest());

            //assert
            var sut = new ClsProduct(ProductsRepo.Object);

            var actual =await  sut.GetAllProductsAsync();
            var actualCount = sut.GetAllProductsAsync().Result.Count();

            actualCount.Should().BeGreaterThan(0);
            actualCount.Should().BeLessThanOrEqualTo(1);
            actual.Should().HaveCount(1);
            Assert.True(actual.ToArray()[0].IdProduct.Equals(1)); 
            actual.Should().NotBeNull();
            actual.Should().BeOfType<List<Product>>();
        }
        public  IEnumerable<Product> GetAllProductsTest()
        {
            List<Product> Products = new List<Product>
            {
                new Product
                {
                    IdProduct = 1, Name = "Product1", SalesPrice = 10,
                    IdCategory_Fk = 1, PurchasePrice = 11, SeoName = "cd",
                    ShippingPrice = 44, Quantity = 5, ImageUrl = "ss", InPromo = false,
                    CreationDate = DateTime.Now, Tva = 1, LongDescription = "ssqq",ShortDescription="qscdq"
                },
             };
            return Products;
        }
       

    }
}
