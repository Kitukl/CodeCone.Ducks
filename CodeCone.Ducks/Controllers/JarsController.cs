using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeCone.Ducks.Data;
using CodeCone.Ducks.Models;

namespace CodeCone.Ducks.Controllers
{
    [Route ("Jars")]
    public class JarsController : Controller
    {
        private readonly CodeConeDucksContext _context;

        public JarsController(CodeConeDucksContext context)
        {
            _context = context;
        }

        // GET: Jars
        public async Task<IActionResult> Index()
        {
            return Json(await _context.Jar.ToListAsync());
        }

        // GET: Jars/Details/5
        [HttpGet("Details/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jar = await _context.Jar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jar == null)
            {
                return NotFound();
            }

            return Json(jar);
        }

        // GET: Jars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Link,ZvitLink")] Jar jar)
        {
            if (ModelState.IsValid)
            {
                jar.Id = Guid.NewGuid();
                _context.Add(jar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Json(jar);
        }

        // GET: Jars/Edit/5
        [HttpGet("Edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jar = await _context.Jar.FindAsync(id);
            if (jar == null)
            {
                return NotFound();
            }
            return Json(jar);
        }

        // POST: Jars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [HttpGet("Edit/{id:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,Link,ZvitLink")] Jar jar)
        {
            if (id != jar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JarExists(jar.Id))
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
            return Json(jar);
        }

        // GET: Jars/Delete/5
        [HttpDelete("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jar = await _context.Jar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jar == null)
            {
                return NotFound();
            }

            return Json(jar);
        }

        // POST: Jars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jar = await _context.Jar.FindAsync(id);
            if (jar != null)
            {
                _context.Jar.Remove(jar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JarExists(Guid id)
        {
            return _context.Jar.Any(e => e.Id == id);
        }
    }
}
