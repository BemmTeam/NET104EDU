using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET104;
using NET104.Entities;

namespace NET104.Areas.Controllers
{
    public class BillController : Controller
    {
        private readonly ShopContext _context;

        public BillController(ShopContext context)
        {
            _context = context;
        }

        // GET: Bill
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Bills.Include(b => b.Cart).Include(b => b.User);
            return View(await shopContext.ToListAsync());
        }

        // GET: Bill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.Cart)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Bill_Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bill/Create
        public IActionResult Create()
        {
            ViewData["Cart_Id"] = new SelectList(_context.Carts, "Cart_Id", "Cart_Id");
            ViewData["User_Id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Bill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bill_Id,Status,CreatedDate,Address,Total,Cart_Id,User_Id")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cart_Id"] = new SelectList(_context.Carts, "Cart_Id", "Cart_Id", bill.Cart_Id);
            ViewData["User_Id"] = new SelectList(_context.Users, "Id", "Id", bill.User_Id);
            return View(bill);
        }

        // GET: Bill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            ViewData["Cart_Id"] = new SelectList(_context.Carts, "Cart_Id", "Cart_Id", bill.Cart_Id);
            ViewData["User_Id"] = new SelectList(_context.Users, "Id", "Id", bill.User_Id);
            return View(bill);
        }

        // POST: Bill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Bill_Id,Status,CreatedDate,Address,Total,Cart_Id,User_Id")] Bill bill)
        {
            if (id != bill.Bill_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.Bill_Id))
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
            ViewData["Cart_Id"] = new SelectList(_context.Carts, "Cart_Id", "Cart_Id", bill.Cart_Id);
            ViewData["User_Id"] = new SelectList(_context.Users, "Id", "Id", bill.User_Id);
            return View(bill);
        }

        // GET: Bill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.Cart)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Bill_Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillExists(int id)
        {
            return _context.Bills.Any(e => e.Bill_Id == id);
        }
    }
}
