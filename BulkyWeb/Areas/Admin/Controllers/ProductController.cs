using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BulkyBookWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController(IUnitOfWork uow, IWebHostEnvironment webHostEnvironment) : Controller
{
    public IActionResult Index()
    {
        var recs = uow.Product.GetAll();
        //var recs = ctx.Categories.ToList();

        return View(recs);
    }

    public IActionResult Upsert(int? id)
    {
        IEnumerable<SelectListItem> Cats = uow.Category.GetAll()
                            .Select(z => new SelectListItem { Text = z.Name, Value = z.Id.ToString() });

        ProductVM productVM = new()
        {
            CategoryList = Cats,
            Product = new Product(),
        };

        if (id == null || id == 0)
        {
            return View(productVM); //for create
        }
        else
        {
            productVM.Product = uow.Product.Get(u => u.Id == id)!;  //for edit
            return View(productVM);
        }
    }
    [HttpPost]
    public IActionResult Upsert(ProductVM prod, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;

            if (file != null)
            {
                string fn = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\product");

                using (var filestream = new FileStream(Path.Combine(productPath, fn), FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
                prod.Product.ImageUrl = @"\images\product\" + fn;
            }

            uow.Product.Add(prod.Product);
            uow.Save();
            //ctx.Categories.Add(category);
            //ctx.SaveChanges();
            TempData["success"] = "Product created succ";
            return RedirectToAction(nameof(Index));
        }
        else
        {
            prod.CategoryList = uow.Category.GetAll()
                            .Select(z => new SelectListItem { Text = z.Name, Value = z.Id.ToString() });
            return View(prod);
        }
    }




    //public IActionResult Edit(int? id)
    //{
    //    if (id == null || id == 0) return NotFound();

    //    var prod = uow.Product.Get(z => z.Id == id);
    //    //var cat = ctx.Categories.Find(id);
    //    if (prod == null) return NotFound();

    //    return View(prod);
    //}
    //[HttpPost]
    //public IActionResult Edit(ProductVM prod)
    //{
    //    //if (category.Name == category.DisplayOrder.ToString())
    //    //{
    //    //    ModelState.AddModelError("name", "The dispOrd can't be the same as Name!");
    //    //}
    //    //if (category.Name == "test")
    //    //{
    //    //    ModelState.AddModelError("", "'Test' is an invalid value");
    //    //}

    //    if (ModelState.IsValid)
    //    {
    //        uow.Product.Update(prod.Product);
    //        uow.Save();
    //        //ctx.Categories.Update(category);
    //        //ctx.SaveChanges();
    //        TempData["success"] = "Product updated succ";
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View();
    //}




    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0) return NotFound();

        var prod = uow.Product.Get(z => z.Id == id);
        //var cat = ctx.Categories.Find(id);
        if (prod == null) return NotFound();

        return View(prod);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        var prod = uow.Product.Get(z => z.Id == id);
        //var cat = ctx.Categories.Find(id);
        if (prod == null) return NotFound();
        uow.Product.Remove(prod);
        uow.Save();
        //ctx.Categories.Remove(cat);
        //ctx.SaveChanges();

        TempData["success"] = "Product deleted succ";
        return RedirectToAction(nameof(Index));
    }

}
