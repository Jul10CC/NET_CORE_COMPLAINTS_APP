using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChapinesGT.Data;
using ChapinesGT.Models;

namespace ChapinesGT.Controllers
{
    public class QuejasController : Controller
    {
        private readonly DB_Contexto _context;

        public QuejasController(DB_Contexto context)
        {
            _context = context;
        }

        // GET: Quejas
        public async Task<IActionResult> Index()
        {
            var dB_Contexto = _context.Queja.Include(q => q.Sucursal);
            return View(await dB_Contexto.ToListAsync());
        }

        // GET: Quejas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Queja == null)
            {
                return NotFound();
            }

            var queja = await _context.Queja
                .Include(q => q.Sucursal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (queja == null)
            {
                return NotFound();
            }

            return View(queja);
        }

        // GET: Quejas/Create
        public IActionResult Create()
        {
            ViewData["Sucursal_ID"] = new SelectList(_context.Sucursal, "Id", "Id");
            return View();
        }

        // POST: Quejas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Motivo,Fecha,Descripcion,Contacto,Usuario_ID,Sucursal_ID")] Queja queja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(queja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Sucursal_ID"] = new SelectList(_context.Sucursal, "Id", "Id", queja.Sucursal_ID);
            return View(queja);
        }

        // GET: Quejas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Queja == null)
            {
                return NotFound();
            }

            var queja = await _context.Queja.FindAsync(id);
            if (queja == null)
            {
                return NotFound();
            }
            ViewData["Sucursal_ID"] = new SelectList(_context.Sucursal, "Id", "Id", queja.Sucursal_ID);
            return View(queja);
        }

        // POST: Quejas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Motivo,Fecha,Descripcion,Contacto,Usuario_ID,Sucursal_ID")] Queja queja)
        {
            if (id != queja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(queja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuejaExists(queja.Id))
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
            ViewData["Sucursal_ID"] = new SelectList(_context.Sucursal, "Id", "Id", queja.Sucursal_ID);
            return View(queja);
        }

        // GET: Quejas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Queja == null)
            {
                return NotFound();
            }

            var queja = await _context.Queja
                .Include(q => q.Sucursal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (queja == null)
            {
                return NotFound();
            }

            return View(queja);
        }

        // POST: Quejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Queja == null)
            {
                return Problem("Entity set 'DB_Contexto.Queja'  is null.");
            }
            var queja = await _context.Queja.FindAsync(id);
            if (queja != null)
            {
                _context.Queja.Remove(queja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuejaExists(int id)
        {
          return _context.Queja.Any(e => e.Id == id);
        }
    }
}
