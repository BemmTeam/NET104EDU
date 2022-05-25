using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET104;
using NET104.Entities;
using NET104.Helper;
using Z.PagedList;
namespace NET104.Areas.Controllers
{
    [Area("Manager")]
    [Route("Manager/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly ShopContext _context;

        [TempData]
        public string Message {get;set;}

        [TempData]

        public string MessageType {get;set;}
        public ProductController(ShopContext context)
        {
            _context = context;
        }

        // GET: Product
        [HttpGet("/Manager")]
        public async Task<IActionResult> Index(int? page , string searchString)
        {
            page??= 1;
            var shopContext = _context.Products.Include(p => p.Category);
            
            IQueryable<Product> products =  shopContext;

            if(!string.IsNullOrEmpty(searchString)) 
            {
                products = products.Where(product => product.Name.ToLower().Contains(searchString.ToLower()));
                ViewBag.searchString = searchString;
            }
            return View (await products.ToPagedListAsync((int)page, 5));
        }
        // IEnumrable (List, string[] , array ...) => in-memory
            // IEnumrable<Product> products = context.Products.Select(p => p).Take(10);
                // B1. products = select * form Products 
                // B2. Select top products
        // Iqueryable => out-memory 
            // Iqueryable<Product> products = context.Products.Select(p => p).Take(10);
                // B1. products = select top 10 * form products 
        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Product_Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Product_Id,Name,Desc,Quantity,Price,Image_Url,Category_Id")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                Message = "Thêm sản phẩm thành công !"; 
                MessageType = MessageHelper.success;
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Name", product.Category_Id);
             Message = "Thêm sản phẩm thất bại !"; 
             MessageType = MessageHelper.error;
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Name", product.Category_Id);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product_Id,Name,Desc,Quantity,Price,Image_Url,Category_Id")] Product product)
        {
            if (id != product.Product_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                     Message = "Cập nhật sản phẩm thành công !"; 
                    MessageType = MessageHelper.success;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Product_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            Message = "Cập nhật sản phẩm thất bại !"; 
            MessageType = MessageHelper.error;
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Name", product.Category_Id);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Product_Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            Message = "Xóa sản phẩm thành công !"; 
            MessageType = MessageHelper.success;
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Product_Id == id);
        }
    }
}
