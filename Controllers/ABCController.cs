using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABC_OnlyFor_Revice_Perpose.Data;
using ABC_OnlyFor_Revice_Perpose.Models;

namespace ABC_OnlyFor_Revice_Perpose.Controllers  //here it added MVC controller with views using entity framework
{
    public class ABCController : Controller
    {
        private readonly TESTContext _context;

        public ABCController(TESTContext context)
        {
            _context = context;
        }

        // GET: ABC
        public async Task<IActionResult> Index()
        {
            return View(await _context.ABC_Table.ToListAsync());
        }

        // GET: ABC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDTO = await _context.ABC_Table
                .FirstOrDefaultAsync(m => m.ItemCode == id);
            if (testDTO == null)
            {
                return NotFound();
            }

            return View(testDTO);
        }

        // GET: ABC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ABC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemCode,ItemName")] TestDTO testDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testDTO);
        }

        // GET: ABC/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDTO = await _context.ABC_Table.FindAsync(id);
            if (testDTO == null)
            {
                return NotFound();
            }
            return View(testDTO);
        }

        // POST: ABC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemCode,ItemName")] TestDTO testDTO)
        {
            if (id != testDTO.ItemCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestDTOExists(testDTO.ItemCode))
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
            return View(testDTO);
        }

        // GET: ABC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDTO = await _context.ABC_Table
                .FirstOrDefaultAsync(m => m.ItemCode == id);
            if (testDTO == null)
            {
                return NotFound();
            }

            return View(testDTO);
        }

        // POST: ABC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testDTO = await _context.ABC_Table.FindAsync(id);
            _context.ABC_Table.Remove(testDTO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestDTOExists(int id)
        {
            return _context.ABC_Table.Any(e => e.ItemCode == id);
        }
    }
}
