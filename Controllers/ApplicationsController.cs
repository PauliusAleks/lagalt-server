//using Microsoft.AspNetCore.Mvc; 
//using Microsoft.EntityFrameworkCore;
//using lagalt_web_api.Data;
//using lagalt_web_api.Models;

//namespace lagalt_web_api.Controllers
//{
//    public class ApplicationsController : ControllerBase
//    {
//        private readonly LagaltDbContext _context;

//        public ApplicationsController(LagaltDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Applications
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Applications.ToListAsync());
//        }

//        // GET: Applications/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Applications == null)
//            {
//                return NotFound();
//            }

//            var application = await _context.Applications
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (application == null)
//            {
//                return NotFound();
//            }

//            return View(application);
//        }

//        // GET: Applications/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Applications/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,State,MotivationLetter")] Application application)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(application);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(application);
//        }

//        // GET: Applications/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Applications == null)
//            {
//                return NotFound();
//            }

//            var application = await _context.Applications.FindAsync(id);
//            if (application == null)
//            {
//                return NotFound();
//            }
//            return View(application);
//        }

//        // POST: Applications/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,State,MotivationLetter")] Application application)
//        {
//            if (id != application.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(application);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ApplicationExists(application.Id))
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
//            return View(application);
//        }

//        // GET: Applications/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Applications == null)
//            {
//                return NotFound();
//            }

//            var application = await _context.Applications
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (application == null)
//            {
//                return NotFound();
//            }

//            return View(application);
//        }

//        // POST: Applications/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Applications == null)
//            {
//                return Problem("Entity set 'LagaltDbContext.Applications'  is null.");
//            }
//            var application = await _context.Applications.FindAsync(id);
//            if (application != null)
//            {
//                _context.Applications.Remove(application);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ApplicationExists(int id)
//        {
//            return _context.Applications.Any(e => e.Id == id);
//        }
//    }
//}
