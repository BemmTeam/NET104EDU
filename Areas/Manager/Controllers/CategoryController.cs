
namespace NET104.Areas.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NET104.Entities;
    using NET104.Helper;

    [Area("Manager")]
    [Route("Manager/[controller]/[action]")]
    public class CategoryController : Controller
    {

        private readonly ShopContext context;

        [TempData]
        public string Message {get;set;}

         [TempData]
        public string MessageType {get;set;}

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
            if (id is null) return NotFound();

            Category category = await context.Categories.SingleOrDefaultAsync(c => c.Category_Id == id);

            if (category is null) return NotFound();

            return View(category);
        }

        [HttpGet] // select
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost] // create
        public async Task<IActionResult> Create([Bind("Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                Message = $"Thêm danh mục tên {category.Name} thành công ! ";
                MessageType = MessageHelper.success;
                return RedirectToAction(nameof(Index));

            }else {
                Message = $"Dữ liệu không chính xác ";
                MessageType = MessageHelper.error;
                return View(category);
            }

        }

        [HttpGet]

        public async Task<IActionResult> Delete(int? id) 
        {
            if(id is null) return NotFound();

            Category category = await context.Categories.FindAsync(id);

            if(category is null) NotFound();

            return View(category);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id) 
        {
         

            Category category = await context.Categories.FindAsync(id);

            if(category is null) NotFound();

            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                Message = "Xóa danh mục thành công !";
                MessageType = MessageHelper.success; 
            }
            catch 
            {
                Message = "Xóa danh mục không thành công !";
                MessageType = MessageHelper.error; 
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]

        public async Task<IActionResult> Edit(int? id) 
        {
            if(id is null) return NotFound();

            Category category = await context.Categories.FindAsync(id);

            if(category is null) NotFound();

            return View(category);
        }

        [HttpPost]

        public async Task<IActionResult> Edit([Bind("Category_Id , Name")]Category category) 
        {
            
            if(ModelState.IsValid)
            {
                try
                {
                    context.Categories.Update(category);
                    await context.SaveChangesAsync();
                    Message = "Cập nhật thành công !";
                    MessageType = MessageHelper.success;
                }
                catch 
                {
                    Message = "Cập nhật thất bại!";
                    MessageType = MessageHelper.error;
                    return View(category);
                }
                
            }
            else 
            {
                Message = "Cập nhật thất bại!";
                MessageType = MessageHelper.error;
               return View(category);
            }

            return RedirectToAction(nameof(Index));
        }
        
    }
}