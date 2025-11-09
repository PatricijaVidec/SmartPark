using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartPark.Data;
using SmartPark.Models;

namespace SmartPark.Controllers
{
    public class UserSMController : Controller
    {
        private readonly SmartParkContext _context;

        public UserSMController(SmartParkContext context)
        {
            _context = context;
        }

        // GET: UserSM
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserSMs.ToListAsync());
        }

        // GET: UserSM/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSM = await _context.UserSMs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSM == null)
            {
                return NotFound();
            }

            return View(userSM);
        }

        // GET: UserSM/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserSM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone")] UserSM userSM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userSM);
        }

        // GET: UserSM/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSM = await _context.UserSMs.FindAsync(id);
            if (userSM == null)
            {
                return NotFound();
            }
            return View(userSM);
        }

        // POST: UserSM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone")] UserSM userSM)
        {
            if (id != userSM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSMExists(userSM.Id))
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
            return View(userSM);
        }

        // GET: UserSM/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSM = await _context.UserSMs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSM == null)
            {
                return NotFound();
            }

            return View(userSM);
        }

        // POST: UserSM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userSM = await _context.UserSMs.FindAsync(id);
            if (userSM != null)
            {
                _context.UserSMs.Remove(userSM);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSMExists(int id)
        {
            return _context.UserSMs.Any(e => e.Id == id);
        }
    }
}
