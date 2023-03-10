//using Microsoft.AspNetCore.Mvc; 
//using Microsoft.EntityFrameworkCore;
//using lagalt_web_api.Data;
//using lagalt_web_api.Models;

//namespace lagalt_web_api.Controllers
//{
//    public class AdminsController : ControllerBase
//    {
//        private readonly LagaltDbContext _context;

//        public AdminsController(LagaltDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Admins
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Admins.ToListAsync());
//        }

//        // GET: Admins/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Admins == null)
//            {
//                return NotFound();
//            }

//            var admin = await _context.Admins
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (admin == null)
//            {
//                return NotFound();
//            }

//            return View(admin);
//        }

//        // GET: Admins/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Admins/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Username,FirstName,LastName,Email,UserStatus,MotivationLetter")] Admin admin)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(admin);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(admin);
//        }

//        // GET: Admins/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Admins == null)
//            {
//                return NotFound();
//            }

//            var admin = await _context.Admins.FindAsync(id);
//            if (admin == null)
//            {
//                return NotFound();
//            }
//            return View(admin);
//        }

//        // POST: Admins/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,FirstName,LastName,Email,UserStatus,MotivationLetter")] Admin admin)
//        {
//            if (id != admin.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(admin);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AdminExists(admin.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(admin);
//        }

//        // GET: Admins/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Admins == null)
//            {
//                return NotFound();
//            }

//            var admin = await _context.Admins
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (admin == null)
//            {
//                return NotFound();
//            }

//            return View(admin);
//        }

//        // POST: Admins/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Admins == null)
//            {
//                return Problem("Entity set 'LagaltDbContext.Admins'  is null.");
//            }
//            var admin = await _context.Admins.FindAsync(id);
//            if (admin != null)
//            {
//                _context.Admins.Remove(admin);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool AdminExists(int id)
//        {
//            return _context.Admins.Any(e => e.Id == id);
//        }
//    }
//}
