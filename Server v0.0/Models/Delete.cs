using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Server_v0._0.Models
{
    public class Delete:Controller
    {
        private readonly ApplicationContext _context;

        public Delete(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AllDelete()
        {
            return View();
        }

        [HttpPost, ActionName("AllDelete")]
        public async Task<IActionResult> AllDeleteConfirmed()
        {
            await _context.Database.ExecuteSqlRawAsync("exec all_del");
            return RedirectToAction("Index","");
        }
    }
}
