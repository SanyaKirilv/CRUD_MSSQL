using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;

namespace Server_v0._0.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationContext _context;

        public TransactionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Transaction.Include(t => t.Work).Include(t => t.WorkType).Include(t => t.Worker);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionInfo = await _context.Transaction
                .Include(t => t.Work)
                .Include(t => t.WorkType)
                .Include(t => t.Worker)
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transactionInfo == null)
            {
                return NotFound();
            }

            return View(transactionInfo);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["WorkID"] = new SelectList(_context.Work, "WorkID", "WorkID");
            ViewData["WorkTypeID"] = new SelectList(_context.WorkType, "WorkTypeID", "Name");
            ViewData["WorkerID"] = new SelectList(_context.Worker, "WorkerID", "Email");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionID,WorkerID,WorkID,WorkTypeID,Name,IsDeleted")] Transaction transactionInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkID"] = new SelectList(_context.Work, "WorkID", "WorkID", transactionInfo.WorkID);
            ViewData["WorkTypeID"] = new SelectList(_context.WorkType, "WorkTypeID", "Name", transactionInfo.WorkTypeID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "WorkerID", "Email", transactionInfo.WorkerID);
            return View(transactionInfo);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionInfo = await _context.Transaction.FindAsync(id);
            if (transactionInfo == null)
            {
                return NotFound();
            }
            ViewData["WorkID"] = new SelectList(_context.Work, "WorkID", "WorkID", transactionInfo.WorkID);
            ViewData["WorkTypeID"] = new SelectList(_context.WorkType, "WorkTypeID", "Name", transactionInfo.WorkTypeID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "WorkerID", "Email", transactionInfo.WorkerID);
            return View(transactionInfo);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionID,WorkerID,WorkID,WorkTypeID,Name,IsDeleted")] Transaction transactionInfo)
        {
            if (id != transactionInfo.TransactionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transactionInfo.TransactionID))
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
            ViewData["WorkID"] = new SelectList(_context.Work, "WorkID", "WorkID", transactionInfo.WorkID);
            ViewData["WorkTypeID"] = new SelectList(_context.WorkType, "WorkTypeID", "Name", transactionInfo.WorkTypeID);
            ViewData["WorkerID"] = new SelectList(_context.Worker, "WorkerID", "Email", transactionInfo.WorkerID);
            return View(transactionInfo);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionInfo = await _context.Transaction
                .Include(t => t.Work)
                .Include(t => t.WorkType)
                .Include(t => t.Worker)
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transactionInfo == null)
            {
                return NotFound();
            }

            return View(transactionInfo);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionInfo = await _context.Transaction.FindAsync(id);
            _context.Transaction.Remove(transactionInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.TransactionID == id);
        }
    }
}
