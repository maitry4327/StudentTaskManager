using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTaskManager.Data;

namespace StudentTaskManager.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString("StudentName", "Maitry");
            var assignments = _context.Assignments;

            ViewBag.TotalAssignments = await assignments.CountAsync();

            ViewBag.PendingAssignments = await assignments
                .CountAsync(a => a.Status == "Pending");

            ViewBag.CompletedAssignments = await assignments
                .CountAsync(a => a.Status == "Completed");

            ViewBag.OverdueAssignments = await assignments
                .CountAsync(a =>
                    a.DueDate.Date < DateTime.Today &&
                    a.Status != "Completed");

            ViewBag.RecentAssignments = await assignments
                .OrderByDescending(a => a.CreatedAt)
                .Take(5)
                .ToListAsync();

            return View();
        }
    }

}
