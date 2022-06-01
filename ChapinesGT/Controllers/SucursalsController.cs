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
    public class SucursalsController : Controller
    {
        private readonly DB_Contexto _context;

        public SucursalsController(DB_Contexto context)
        {
            _context = context;
        }

        // GET: Sucursals
        public async Task<IActionResult> Index()
        {
            var dB_Contexto = _context.Sucursal.Include(s => s.Comercio).Include(s => s.Departamento).Include(s => s.Municipio).Include(s => s.Region);
            return View(await dB_Contexto.ToListAsync());
        }

        // GET: Sucursals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sucursal == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursal
                .Include(s => s.Comercio)
                .Include(s => s.Departamento)
                .Include(s => s.Municipio)
                .Include(s => s.Region)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // GET: Sucursals/Create
        public IActionResult Create()
        {
            ViewData["Comercio_ID"] = new SelectList(_context.Comercio, "Id", "Nombre");
            ViewData["Departamento_ID"] = new SelectList(_context.Departamento, "Id", "Nombre");
            ViewData["Municipio_ID"] = new SelectList(_context.Municipio, "Id", "Nombre");
            ViewData["Region_ID"] = new SelectList(_context.Region, "Id", "Nombre");
            return View();
        }

        // POST: Sucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Comercio_ID,Departamento_ID,Municipio_ID,Region_ID")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Comercio_ID"] = new SelectList(_context.Comercio, "Id", "Id", sucursal.Comercio_ID);
            ViewData["Departamento_ID"] = new SelectList(_context.Departamento, "Id", "Id", sucursal.Departamento_ID);
            ViewData["Municipio_ID"] = new SelectList(_context.Municipio, "Id", "Id", sucursal.Municipio_ID);
            ViewData["Region_ID"] = new SelectList(_context.Region, "Id", "Id", sucursal.Region_ID);
            return View(sucursal);
        }

        // GET: Sucursals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sucursal == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursal.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            ViewData["Comercio_ID"] = new SelectList(_context.Comercio, "Id", "Nombre", sucursal.Comercio_ID);
            ViewData["Departamento_ID"] = new SelectList(_context.Departamento, "Id", "Nombre", sucursal.Departamento_ID);
            ViewData["Municipio_ID"] = new SelectList(_context.Municipio, "Id", "Nombre", sucursal.Municipio_ID);
            ViewData["Region_ID"] = new SelectList(_context.Region, "Id", "Nombre", sucursal.Region_ID);
            return View(sucursal);
        }

        // POST: Sucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Comercio_ID,Departamento_ID,Municipio_ID,Region_ID")] Sucursal sucursal)
        {
            if (id != sucursal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalExists(sucursal.Id))
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
            ViewData["Comercio_ID"] = new SelectList(_context.Comercio, "Id", "Id", sucursal.Comercio_ID);
            ViewData["Departamento_ID"] = new SelectList(_context.Departamento, "Id", "Id", sucursal.Departamento_ID);
            ViewData["Municipio_ID"] = new SelectList(_context.Municipio, "Id", "Id", sucursal.Municipio_ID);
            ViewData["Region_ID"] = new SelectList(_context.Region, "Id", "Id", sucursal.Region_ID);
            return View(sucursal);
        }

        // GET: Sucursals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sucursal == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursal
                .Include(s => s.Comercio)
                .Include(s => s.Departamento)
                .Include(s => s.Municipio)
                .Include(s => s.Region)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // POST: Sucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sucursal == null)
            {
                return Problem("Entity set 'DB_Contexto.Sucursal'  is null.");
            }
            var sucursal = await _context.Sucursal.FindAsync(id);
            if (sucursal != null)
            {
                _context.Sucursal.Remove(sucursal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalExists(int id)
        {
          return _context.Sucursal.Any(e => e.Id == id);
        }
    }
}
