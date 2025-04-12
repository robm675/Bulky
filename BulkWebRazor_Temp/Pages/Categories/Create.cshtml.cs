using BulkWebRazor_Temp.Data;
using BulkWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkWebRazor_Temp.Pages.Categories;

[BindProperties]
public class CreateModel(ApplicationDBContext ctx) : PageModel
{
    public Category Category { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        ctx.Categories.Add(Category);
        ctx.SaveChanges();
            TempData["success"] = "Cat creted succ";
        return RedirectToPage("Index");
    }
}
