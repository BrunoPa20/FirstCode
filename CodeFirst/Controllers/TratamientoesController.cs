using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;

namespace CodeFirst.Controllers
{
    public class TratamientoesController : Controller
    {
        private readonly MyDbContext _context;

        public TratamientoesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Tratamientoes
        public async Task<IActionResult> Index()
        {
              return _context.Tratamientos != null ? 
                          View(await _context.Tratamientos.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Tratamientos'  is null.");
        }

        // GET: Tratamientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tratamientos == null)
            {
                return NotFound();
            }

            var tratamiento = await _context.Tratamientos
                .FirstOrDefaultAsync(m => m.IDTratamiento == id);
            if (tratamiento == null)
            {
                return NotFound();
            }

            return View(tratamiento);
        }

        // GET: Tratamientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tratamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDTratamiento,T_Diagnostico,T_Procedimiento,T_Tipo,T_Monto,Saldo")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tratamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tratamiento);
        }

        // GET: Tratamientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tratamientos == null)
            {
                return NotFound();
            }

            var tratamiento = await _context.Tratamientos.FindAsync(id);
            if (tratamiento == null)
            {
                return NotFound();
            }
            return View(tratamiento);
        }

        // POST: Tratamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDTratamiento,T_Diagnostico,T_Procedimiento,T_Tipo,T_Monto,Saldo")] Tratamiento tratamiento)
        {
            if (id != tratamiento.IDTratamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tratamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TratamientoExists(tratamiento.IDTratamiento))
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
            return View(tratamiento);
        }

        // GET: Tratamientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tratamientos == null)
            {
                return NotFound();
            }

            var tratamiento = await _context.Tratamientos
                .FirstOrDefaultAsync(m => m.IDTratamiento == id);
            if (tratamiento == null)
            {
                return NotFound();
            }

            return View(tratamiento);
        }

        // POST: Tratamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tratamientos == null)
            {
                return Problem("Entity set 'MyDbContext.Tratamientos'  is null.");
            }
            var tratamiento = await _context.Tratamientos.FindAsync(id);
            if (tratamiento != null)
            {
                _context.Tratamientos.Remove(tratamiento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TratamientoExists(int id)
        {
          return (_context.Tratamientos?.Any(e => e.IDTratamiento == id)).GetValueOrDefault();
        }
    }
}
