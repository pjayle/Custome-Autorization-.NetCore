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
    [ServiceFilter(typeof(MyAuthorization))]
    public class PermissionsController : Controller
    {
        private readonly MasterDbContext _context;

        public PermissionsController(MasterDbContext context)
        {
            _context = context;
        }

        // GET: Permissions
        public async Task<IActionResult> Index()
        {
            return View(await _context.MPermissions.ToListAsync());
        }

        // GET: Permissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mPermissions = await _context.MPermissions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mPermissions == null)
            {
                return NotFound();
            }

            return View(mPermissions);
        }

        // GET: Permissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModuleName,ActionName,Description,Url,Icon,ParentId,IsMenu")] MPermissions mPermissions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mPermissions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mPermissions);
        }

        // GET: Permissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mPermissions = await _context.MPermissions.FindAsync(id);
            if (mPermissions == null)
            {
                return NotFound();
            }
            return View(mPermissions);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModuleName,ActionName,Description,Url,Icon,ParentId,IsMenu")] MPermissions mPermissions)
        {
            if (id != mPermissions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mPermissions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MPermissionsExists(mPermissions.Id))
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
            return View(mPermissions);
        }

        // GET: Permissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mPermissions = await _context.MPermissions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mPermissions == null)
            {
                return NotFound();
            }

            return View(mPermissions);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mPermissions = await _context.MPermissions.FindAsync(id);
            if (mPermissions != null)
            {
                _context.MPermissions.Remove(mPermissions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MPermissionsExists(int id)
        {
            return _context.MPermissions.Any(e => e.Id == id);
        }
    }
}
