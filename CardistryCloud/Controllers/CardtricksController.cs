using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CardistryCloud.Models;

namespace CardistryCloud.Controllers
{
    public class CardtricksController : Controller
    {
        private readonly CardistryCloudContext _context;

        public CardtricksController(CardistryCloudContext context)
        {
            _context = context;    
        }

        // GET: Cardtricks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cardtrick.ToListAsync());
        }

        // GET: Cardtricks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardtrick = await _context.Cardtrick
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cardtrick == null)
            {
                return NotFound();
            }

            return View(cardtrick);
        }

        // GET: Cardtricks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cardtricks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titel,Kategorie,Schwierigkeitsgrad,Beschreibung")] Cardtrick cardtrick)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardtrick);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cardtrick);
        }

        // GET: Cardtricks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardtrick = await _context.Cardtrick.SingleOrDefaultAsync(m => m.ID == id);
            if (cardtrick == null)
            {
                return NotFound();
            }
            return View(cardtrick);
        }

        // POST: Cardtricks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titel,Kategorie,Schwierigkeitsgrad,Beschreibung")] Cardtrick cardtrick)
        {
            if (id != cardtrick.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardtrick);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardtrickExists(cardtrick.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(cardtrick);
        }

        // GET: Cardtricks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardtrick = await _context.Cardtrick
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cardtrick == null)
            {
                return NotFound();
            }

            return View(cardtrick);
        }

        // POST: Cardtricks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardtrick = await _context.Cardtrick.SingleOrDefaultAsync(m => m.ID == id);
            _context.Cardtrick.Remove(cardtrick);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CardtrickExists(int id)
        {
            return _context.Cardtrick.Any(e => e.ID == id);
        }
    }
}
