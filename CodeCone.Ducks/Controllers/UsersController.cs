using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeCone.Ducks.Data;
using CodeCone.Ducks.Models;

namespace CodeCone.Ducks.Controllers
{
    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly CodeConeDucksContext _context;

        public UsersController(CodeConeDucksContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return Json(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            
            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        // POST: Users/Create
        [HttpPost ("Create")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            user.Id = Guid.NewGuid();
            _context.Add(user);
            await _context.SaveChangesAsync();
            return Json(user);
        }

        // POST: Users/Edit/5
        [HttpPost("Edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return Json(user);
        }

        // DELETE: Users/Delete/5
        [HttpDelete("Delete/{id:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("UserExists/{id:guid}")]
        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
