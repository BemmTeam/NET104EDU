using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NET104.Entities;
using NET104.Helper;

namespace NET104.Areas.Controllers
{
    [Area("Manager")]
    [Route("Manager/[controller]/[action]")]
    public class DbManagerController : Controller 
    { 

        // localhost:5001/Manager/DbManager/Index
        private readonly ShopContext _context;
        public DbManagerController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        { 
           
           return View(); // 1 phiên -> viewData
        }

        [TempData]
        public string Message {get;set;}

        [TempData]
        public string MessageType {get;set;}
        public async Task<IActionResult> InsertCategory()
        {
             List<Category> categories = new(){

                new Category(){
                   Name = "Apple"
                },

                new Category(){
                   Name = "Samsung"
                },

                new Category(){
                   Name = "Oppo"
                },
                  new Category(){
                   Name = "Nokia"
                },
            };

          try {
            await _context.Categories.AddRangeAsync(categories);
            await _context.SaveChangesAsync();
            Message = "Thêm dữ liệu thành công";
            MessageType = MessageHelper.success;
          }catch{
             Message = "Thêm dữ liệu thất bại";
            MessageType = MessageHelper.error;

              return RedirectToAction(nameof(Index)); //2 phiên -> Temdata
          
          }
            return RedirectToAction(nameof(Index));
        }

    }
}
