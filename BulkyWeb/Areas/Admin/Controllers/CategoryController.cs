using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(IUnitOfWork uow) : Controller
{
    public IActionResult Index()
    {
        var recs = uow.Category.GetAll();
        //var recs = ctx.Categories.ToList();

        return View(recs);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category category)
    {
        //if (category.Name == category.DisplayOrder.ToString())
        //{
        //    ModelState.AddModelError("name", "The dispOrd can't be the same as Name!");
        //}
        //if (category.Name == "test")
        //{
        //    ModelState.AddModelError("", "'Test' is an invalid value");
        //}

        if (ModelState.IsValid)
        {
            uow.Category.Add(category);
            uow.Save();
            //ctx.Categories.Add(category);
            //ctx.SaveChanges();
            TempData["success"] = "Cat created succ";
            return RedirectToAction(nameof(Index));
        }
        return View();
    }




    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0) return NotFound();

        var cat = uow.Category.Get(z => z.Id == id);
        //var cat = ctx.Categories.Find(id);
        if (cat == null) return NotFound();

        return View(cat);
    }
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        //if (category.Name == category.DisplayOrder.ToString())
        //{
        //    ModelState.AddModelError("name", "The dispOrd can't be the same as Name!");
        //}
        //if (category.Name == "test")
        //{
        //    ModelState.AddModelError("", "'Test' is an invalid value");
        //}

        if (ModelState.IsValid)
        {
            uow.Category.Update(category);
            uow.Save();
            //ctx.Categories.Update(category);
            //ctx.SaveChanges();
            TempData["success"] = "Cat updated succ";
            return RedirectToAction(nameof(Index));
        }
        return View();
    }




    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0) return NotFound();

        var cat = uow.Category.Get(z => z.Id == id);
        //var cat = ctx.Categories.Find(id);
        if (cat == null) return NotFound();

        return View(cat);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        var cat = uow.Category.Get(z => z.Id == id);
        //var cat = ctx.Categories.Find(id);
        if (cat == null) return NotFound();
        uow.Category.Remove(cat);
        uow.Save();
        //ctx.Categories.Remove(cat);
        //ctx.SaveChanges();

        TempData["success"] = "Cat deleted succ";
        return RedirectToAction(nameof(Index));
    }

}
