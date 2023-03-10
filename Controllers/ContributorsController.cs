﻿//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using lagalt_web_api.Data;
//using lagalt_web_api.Models;

//namespace lagalt_web_api.Controllers
//{
//    public class ContributorsController : ControllerBase
//    {
//        private readonly LagaltDbContext _context;

//        public ContributorsController(LagaltDbContext context)
//        {
//            _context = context;
//        }

//        GET: Contributors
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Contributors.ToListAsync());
//        }

//        GET: Contributors/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Contributors == null)
//            {
//                return NotFound();
//            }

//            var contributor = await _context.Contributors
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (contributor == null)
//            {
//                return NotFound();
//            }

//            return View(contributor);
//        }

//        GET: Contributors/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        POST: Contributors/Create
//        To protect from overposting attacks, enable the specific properties you want to bind to.
//        For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

//       [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Username,FirstName,LastName,Email,UserStatus,MotivationLetter")] Contributor contributor)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(contributor);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(contributor);
//        }

//        GET: Contributors/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Contributors == null)
//            {
//                return NotFound();
//            }

//            var contributor = await _context.Contributors.FindAsync(id);
//            if (contributor == null)
//            {
//                return NotFound();
//            }
//            return View(contributor);
//        }

//        POST: Contributors/Edit/5
//         To protect from overposting attacks, enable the specific properties you want to bind to.
//         For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,FirstName,LastName,Email,UserStatus,MotivationLetter")] Contributor contributor)
//        {
//            if (id != contributor.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(contributor);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ContributorExists(contributor.Id))
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
//            return View(contributor);
//        }

//        GET: Contributors/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Contributors == null)
//            {
//                return NotFound();
//            }

//            var contributor = await _context.Contributors
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (contributor == null)
//            {
//                return NotFound();
//            }

//            return View(contributor);
//        }

//        POST: Contributors/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Contributors == null)
//            {
//                return Problem("Entity set 'LagaltDbContext.Contributors'  is null.");
//            }
//            var contributor = await _context.Contributors.FindAsync(id);
//            if (contributor != null)
//            {
//                _context.Contributors.Remove(contributor);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ContributorExists(int id)
//        {
//            return _context.Contributors.Any(e => e.Id == id);
//        }
//    }
//}
