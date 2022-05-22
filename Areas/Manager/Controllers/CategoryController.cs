
namespace NET104.Areas.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NET104.Entities;

    [Area("Manager")]
    [Route("Manager/[controller]/[action]")]
    public class CategoryController : Controller
    {

        private readonly ShopContext context;

        public CategoryController(ShopContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await context.Categories.ToListAsync();
            
            return View(categories);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id is null) return NotFound();

            Category category = await context.Categories.SingleOrDefaultAsync(c => c.Category_Id == id);

            if(category is null) return NotFound();

            return View(category);
        }
    }
}