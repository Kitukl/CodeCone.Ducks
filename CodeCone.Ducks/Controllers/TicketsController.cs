using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeCone.Ducks.Models;
using CodeCone.Ducks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCone.Ducks.Controllers
{
    [Route("Tickets")]
    public class TicketController : Controller
    {
        private readonly CodeConeDucksContext _context;

        public TicketController(CodeConeDucksContext context)
        {
            _context = context;
        }
        // GET: Ticket

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return View(tickets);
        }

        [HttpGet("Details/{id:guid}")]
        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Json(ticket);
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            return Json(null);
        }

        // POST: Ticket/Create
        [HttpPost(Name = "Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,Title,Description,CreatedAt,UserId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Json(ticket);
        }

        // GET: Ticket/Edit/5
        [HttpGet("Edit/{id:guid}")]
        public async Task<IActionResult> Edit(int id)
        {

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Json(ticket);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,Title,Description,Submitter,CreatedAt")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            return Json(ticket);
        }

        // GET: Ticket/Delete/5
        [HttpDelete("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(int id)
        {

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Json(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Ticket/GetTicketsByUser/username
        public async Task<IActionResult> GetTicketsByUser(string username)
        {
            var tickets = await _context.Tickets
                .Where(t => t.User.UserName == username)
                .ToListAsync();

            return Json(tickets);
        }

        [HttpGet("TicketExists/{id:guid}")]
        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
