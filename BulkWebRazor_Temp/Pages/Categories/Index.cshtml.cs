using BulkWebRazor_Temp.Data;
using BulkWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkWebRazor_Temp.Pages.Categories;

public class IndexModel(ApplicationDBContext ctx) : PageModel
{
    public List<Category> CategoryList { get; set; }

    public void OnGet()
    {
        CategoryList = ctx.Categories.ToList();
    }
}
