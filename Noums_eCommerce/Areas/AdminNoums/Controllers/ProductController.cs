using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noums_eCommerce.Areas.AdminNoums.ViewsModels;
using Noums_eCommerce.Models;
using Noums_eCommerce.Pages.Ecommerce;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Noums_eCommerce.Areas.AdminNoums.Controllers
{
    [Area("AdminNoums")]
    public class ProductController : Controller
    {
        readonly IProduct productService;
        readonly ICategory  categoryService;
        readonly IPicture pictureService;

        public ProductController(IProduct productService, ICategory categoryService, IPicture pictureService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.pictureService = pictureService;
        }
        // GET: ProductController
        public IActionResult Index()
        {

            return View(productService.GetAllProductsIncludeCategoriesAsync().Result);
        }
        [HttpGet]
        public async Task<IActionResult> AddPictures(int id)
        {
            PicturesVM PictureVm = new PicturesVM();
            PictureVm.Pictures  =   pictureService.GetAllPictureAsync().Result.Where(a=>a.IdProduct_Fk == id).ToList();
            PictureVm.Picture = await pictureService.GetAllPictureByIdAsync(id);
            return View (PictureVm);
        }
        [HttpPost]
        public async Task<IActionResult> AddPictures(int id, PicturesVM pictureVm, IFormFile file)
        {
            try
            {
                string FileName = string.Empty;
                if (file != null && id >0 && file.FileName != string.Empty)
                {
                    FileName = Guid.NewGuid() + file.FileName;
                    pictureVm.Picture.UrlPicture = FileName;

                    var currentProduct = await productService.GetProductByIdAsync(id);
                    pictureVm.Picture.IdProduct_Fk = currentProduct.IdProduct;
                    var createPicture = await pictureService.CreatePictureAsync(pictureVm.Picture);
                    //Path du fichier pour enregistrer mes images
                    string ProductImage = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images/ProductsImages\Pictures\", FileName);
                    using (var stream = System.IO.File.Create(ProductImage))
                    {

                        file.CopyTo(stream);

                    }

                }
                return RedirectToAction(nameof(AddPictures));
            }
            catch (Exception)
            {

                return View();
            }

        }
         public async Task<IActionResult> DeletePicture(PicturesVM pictureVm)
        {

            var delPicture = await pictureService.GetAllPictureByIdAsync(pictureVm.Picture.IdPictures);

            string PathRoot = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\ProductsImages\Pictures\", delPicture.UrlPicture);
            try
            {

                if (pictureVm.Picture.IdPictures > 0 )
                {

                    System.IO.File.Delete(PathRoot);
                    //var delPicture = await pictureService.GetAllPictureByIdAsync(id);
                    await pictureService.RemovePictureAsync(delPicture);
                    return Redirect("AddPictures/" + delPicture.IdProduct_Fk);
                }

            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Index));
            }


            return View();



        }


        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {

            return View(await productService.GetProductByIdAsync(id));
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await categoryService.GetAllCategoryAsync();


            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Create(Product product, IFormFile file)
        {
            try
            {
                string FileName = string.Empty;
                if (file != null)
                {
                    // nom du fichier que je vais uploder
                    FileName = Guid.NewGuid() + file.FileName;
                    //path
                    string ProductImage = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images/ProductsImages", FileName);
                    string ProductImagePicture = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images/ProductsImages/Pictures/", FileName);
                
                    //bdd product
                    product.ImageUrl = FileName;
                    product.CreationDate = DateTime.Now;
                     var createProduct = await  productService.CreateProductAsync(product);

                    // enregistrer l'image 

                    using (var stream = System.IO.File.Create(ProductImage))
                    {
                        file.CopyTo(stream);
                    }
                    // create picture
                    var Picture = new Picture();
                    Picture.Name = product.Name;
                    Picture.UrlPicture = FileName;
                    Picture.IdProduct_Fk = product.IdProduct;
                    // bdd picture
                    var createPicture = await pictureService.CreatePictureAsync(Picture);
                    using (var stream = System.IO.File.Create(ProductImagePicture))
                    {
                        file.CopyTo(stream);
                    }
                }   
               
                //product.IdCategory_Fk = product.IdCategory_Fk;

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View(e.InnerException);
            }
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.categories = await categoryService.GetAllCategoryAsync();

            if (id != null)
            {
                return View(await productService.GetProductByIdAsync(Convert.ToInt32(id)));
            }
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Product product, IFormFile file)
        {
            try
            {
                var currentProductId = await productService.GetProductByIdAsync(product.IdProduct);

                //product.PurchasePrice = Convert.ToDecimal(purchase);
                string FileName = string.Empty;
                if (file != null)
                {
                    // create 
                    FileName = Guid.NewGuid() + file.FileName;
                    string OldPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images\ProductsImages", product.ImageUrl);
                    string NewPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images\ProductsImages", FileName);

                    //delete oldFile
                    if (product.ImageUrl != null)
                    {
                        System.IO.File.Delete(OldPath);

                    }
                    //copy new file 
                    using (var stream = System.IO.File.Create(NewPath))
                    {

                        file.CopyTo(stream);

                    }
 

                    product.ImageUrl = FileName;
                    product.CreationDate = DateTime.Now;
                    await productService.UpdateProductAsync(currentProductId, product);


                
                    // create picture
                    var Picture = new Picture();

                    Picture.Name = product.Name;
                    Picture.UrlPicture = FileName;
                    Picture.IdProduct_Fk = product.IdProduct;
                    var currentPicture = await pictureService.GetPictureByName(Picture.Name);
                    //traitement picture

                    string NewPathPicture = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images\ProductsImages\Pictures\", FileName);
                    string OldPathPicture = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images\ProductsImages\Pictures\", currentPicture.UrlPicture);

                    //copy new file Picture
                    if (Picture.UrlPicture != null)
                    {
                        System.IO.File.Delete(OldPathPicture);

                    }
                    using (var stream = System.IO.File.Create(NewPathPicture))
                    {

                        file.CopyTo(stream);

                    }
         
                    // bdd picture

                    
                       await pictureService.UpdatePictureAsync(currentPicture,Picture);
                    

                }
                else
                {
                    product.ImageUrl = product.ImageUrl;
                    product.CreationDate = DateTime.Now;
                    await productService.UpdateProductAsync(currentProductId, product);

                    
                }


                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return View();
            }
        }

        //GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.ListPicture = pictureService.GetAllPictureAsync().Result.Where(i => i.IdPictures == id);
            return View(await productService.GetProductByIdAsync(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Product product)
        {
            try
            {
                var pictures = pictureService.GetAllPictureAsync().Result.Where(p => p.IdProduct_Fk == product.IdProduct).ToList();
                string PathRoot = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\ProductsImages", product.ImageUrl);

                foreach (var i in pictures)
                {
                    string PathRootPicture = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\ProductsImages\Pictures", i.UrlPicture);
                    System.IO.File.Delete(PathRootPicture);
                    await pictureService.RemovePictureAsync(i);
                }


                System.IO.File.Delete(PathRoot);
                await productService.RemoveProductAsync(product);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return View();
            }
        }
    }
}
