using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Noums_eCommerce_UI.Areas.AdminNoums.Controllers
{
    [Area("AdminNoums")]

    public class CategoryController : Controller
    {
        readonly ICategory categoryService;
        readonly IProduct productService;
        readonly IPicture pictureService;

        public CategoryController(ICategory categoryService, IProduct productService, IPicture pictureService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.pictureService = pictureService;
        }


        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
          return View(await categoryService.GetAllCategoryAsync());
        }

        // GET: CategoryController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View( await categoryService.GetAllCategoryByIdAsync(id));
        }

        // GET: CategoryController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                await categoryService.CreateCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public IActionResult Edit()
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category NewCategory)
        {
            try
            {
                if(id > 0)
                {
                   var currentCategory = await categoryService.GetAllCategoryByIdAsync(id);
                    await categoryService.UpdateCategoryAsync(currentCategory, NewCategory);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            return View(await categoryService.GetAllCategoryByIdAsync(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, List<string> imgProduct, List<int> picturesId)
        {
            try
            {
                if (picturesId.Count > 0 && id > 0)
                {


                    foreach (var i in picturesId.ToList())
                    {
                        var productUrl =  pictureService.GetAllPictureAsync().Result.Where(a => a.Product.IdProduct == i).ToList();

                        foreach (var u in productUrl.ToList())
                        {
                            string PathRootPicture = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\Pictures", u.UrlPicture);
                            System.IO.File.Delete(PathRootPicture);
                           await  pictureService.RemovePictureAsync(u);
                        }

                    }

                }


                foreach (var im in imgProduct.ToList())
                {
                    string PathRoot = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\ProductsImages", im);
                    System.IO.File.Delete(PathRoot);

                }
            if(id > 0)
                {
                    var delcategory = await categoryService.GetAllCategoryByIdAsync(id);
                    await categoryService.RemoveCategoryAsync(delcategory);

                }
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

    }
}
