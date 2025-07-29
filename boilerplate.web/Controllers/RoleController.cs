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
    public class RoleController : Controller
    {
        private readonly MasterDbContext _context;

        public RoleController(MasterDbContext context)
        {
            _context = context;
        }

        // GET: Role
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        // GET: Role/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mRoles = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mRoles == null)
            {
                return NotFound();
            }

            return View(mRoles);
        }

        // GET: Role/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] MRoles mRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mRoles);
        }

        // GET: Role/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mRoles = await _context.Roles.FindAsync(id);
            if (mRoles == null)
            {
                return NotFound();
            }
            return View(mRoles);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] MRoles mRoles)
        {
            if (id != mRoles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MRolesExists(mRoles.Id))
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
            return View(mRoles);
        }

        // GET: Role/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mRoles = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mRoles == null)
            {
                return NotFound();
            }

            return View(mRoles);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mRoles = await _context.Roles.FindAsync(id);
            if (mRoles != null)
            {
                _context.Roles.Remove(mRoles);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MRolesExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
