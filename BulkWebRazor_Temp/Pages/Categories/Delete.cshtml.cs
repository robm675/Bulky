using BulkWebRazor_Temp.Data;
using BulkWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkWebRazor_Temp.Pages.Categories;

[BindProperties]
public class DeleteModel(ApplicationDBContext ctx) : PageModel
{
    public Category Category { get; set; }

    public void OnGet(int? id)
    {
        if (id != null && id != 0)
        {
            Category = ctx.Categories.Find(id)!;
        }
    }

    public IActionResult OnPost()
    {
        var cat = ctx.Categories.Find(Category.Id);
        if (cat == null) return NotFound();
        ctx.Categories.Remove(cat);
        ctx.SaveChanges();

        TempData["success"] = "Cat deleted succ";
        return RedirectToPage(nameof(Index));
    }
}
