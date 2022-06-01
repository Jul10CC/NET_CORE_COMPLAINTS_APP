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
    public class ComerciosController : Controller
    {
        private readonly DB_Contexto _context;

        public ComerciosController(DB_Contexto context)
        {
            _context = context;
        }

        // GET: Comercios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Comercio.ToListAsync());
        }

        // GET: Comercios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comercio == null)
            {
                return NotFound();
            }

            var comercio = await _context.Comercio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comercio == null)
            {
                return NotFound();
            }

            return View(comercio);
        }

        // GET: Comercios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comercios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,NIT,Descripcion")] Comercio comercio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comercio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comercio);
        }

        // GET: Comercios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comercio == null)
            {
                return NotFound();
            }

            var comercio = await _context.Comercio.FindAsync(id);
            if (comercio == null)
            {
                return NotFound();
            }
            return View(comercio);
        }

        // POST: Comercios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,NIT,Descripcion")] Comercio comercio)
        {
            if (id != comercio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comercio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComercioExists(comercio.Id))
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
            return View(comercio);
        }

        // GET: Comercios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comercio == null)
            {
                return NotFound();
            }

            var comercio = await _context.Comercio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comercio == null)
            {
                return NotFound();
            }

            return View(comercio);
        }

        // POST: Comercios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comercio == null)
            {
                return Problem("Entity set 'DB_Contexto.Comercio'  is null.");
            }
            var comercio = await _context.Comercio.FindAsync(id);
            if (comercio != null)
            {
                _context.Comercio.Remove(comercio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComercioExists(int id)
        {
          return _context.Comercio.Any(e => e.Id == id);
        }
    }
}
