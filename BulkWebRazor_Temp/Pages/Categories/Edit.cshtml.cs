using BulkWebRazor_Temp.Data;
using BulkWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkWebRazor_Temp.Pages.Categories;

[BindProperties]
public class EditModel(ApplicationDBContext ctx) : PageModel
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
        if (ModelState.IsValid)
        {
            ctx.Categories.Update(Category);
            ctx.SaveChanges();
            TempData["success"] = "Cat updated succ";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
