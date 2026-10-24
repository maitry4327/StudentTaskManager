using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTaskManager.Data;
using StudentTaskManager.Models;

namespace StudentTaskManager.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ: Display all assignments
        public async Task<IActionResult> Index(string? searchString, string? statusFilter)
        {
            var assignments = _context.Assignments.AsQueryable();

        // Search by assignment title or subject
        if (!string.IsNullOrWhiteSpace(searchString))
            {
                assignments = assignments.Where(a =>
                    a.Title.Contains(searchString) ||
                    a.Subject.Contains(searchString));
            }

            // Filter by assignment status
            if (!string.IsNullOrWhiteSpace(statusFilter) &&
                statusFilter != "All")
            {
                assignments = assignments.Where(a =>
                    a.Status == statusFilter);
            }

            // Display assignments in due-date order
            var result = await assignments
                .OrderBy(a => a.DueDate)
                .ToListAsync();

            ViewBag.SearchString = searchString;
            ViewBag.StatusFilter = statusFilter ?? "All";

            return View(result);

}


        // READ: Display assignment details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignment == null)
                return NotFound();

            return View(assignment);
        }

        // CREATE: Open the form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Save a new assignment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Assignments.Add(assignment);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Assignment added successfully!";

                return RedirectToAction(nameof(Index));
            }

            return View(assignment);
        }

        // UPDATE: Open the edit form
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null)
                return NotFound();

            return View(assignment);
        }

        // UPDATE: Save edited assignment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, Assignment assignment)
        {
            if (id != assignment.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();

                    TempData["Success"] =
                        "Assignment updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AssignmentExists(assignment.Id))
                        return NotFound();

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(assignment);
        }

        // DELETE: Show confirmation page
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignment == null)
                return NotFound();

            return View(assignment);
        }

        // DELETE: Remove assignment
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();

                TempData["Success"] =
                    "Assignment deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AssignmentExists(int id)
        {
            return await _context.Assignments
                .AnyAsync(a => a.Id == id);
        }
    }
}

