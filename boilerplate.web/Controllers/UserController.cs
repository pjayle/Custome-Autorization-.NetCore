using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using boilerplate.web.Data;
using boilerplate.web.Models;

namespace boilerplate.web.Controllers
{
    public class UserController : Controller
    {
        private readonly MasterDbContext _context;

        public UserController(MasterDbContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var masterDbContext = _context.Users.Include(m => m.Roles);
            return View(await masterDbContext.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mUser = await _context.Users
                .Include(m => m.Roles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mUser == null)
            {
                return NotFound();
            }

            return View(mUser);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewData["RolesId"] = new SelectList(_context.Roles, "Id", "Title");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,Password,RolesId")] MUser mUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolesId"] = new SelectList(_context.Roles, "Id", "Id", mUser.RolesId);
            return View(mUser);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mUser = await _context.Users.FindAsync(id);
            if (mUser == null)
            {
                return NotFound();
            }
            ViewData["RolesId"] = new SelectList(_context.Roles, "Id", "Id", mUser.RolesId);
            return View(mUser);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,Password,RolesId")] MUser mUser)
        {
            if (id != mUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MUserExists(mUser.Id))
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
            ViewData["RolesId"] = new SelectList(_context.Roles, "Id", "Id", mUser.RolesId);
            return View(mUser);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mUser = await _context.Users
                .Include(m => m.Roles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mUser == null)
            {
                return NotFound();
            }

            return View(mUser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mUser = await _context.Users.FindAsync(id);
            if (mUser != null)
            {
                _context.Users.Remove(mUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MUserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
