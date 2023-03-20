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
    public class OdontologoesController : Controller
    {
        private readonly MyDbContext _context;

        public OdontologoesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Odontologoes
        public async Task<IActionResult> Index()
        {
              return _context.Odontologos != null ? 
                          View(await _context.Odontologos.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Odontologos'  is null.");
        }

        // GET: Odontologoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Odontologos == null)
            {
                return NotFound();
            }

            var odontologo = await _context.Odontologos
                .FirstOrDefaultAsync(m => m.IDOdontologo == id);
            if (odontologo == null)
            {
                return NotFound();
            }

            return View(odontologo);
        }

        // GET: Odontologoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Odontologoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDOdontologo,OD_Nombre,OD_Telefono,OD_Domicilio,OD_Turno,OD_Usuario,OD_Password")] Odontologo odontologo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odontologo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(odontologo);
        }

        // GET: Odontologoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Odontologos == null)
            {
                return NotFound();
            }

            var odontologo = await _context.Odontologos.FindAsync(id);
            if (odontologo == null)
            {
                return NotFound();
            }
            return View(odontologo);
        }

        // POST: Odontologoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDOdontologo,OD_Nombre,OD_Telefono,OD_Domicilio,OD_Turno,OD_Usuario,OD_Password")] Odontologo odontologo)
        {
            if (id != odontologo.IDOdontologo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odontologo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdontologoExists(odontologo.IDOdontologo))
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
            return View(odontologo);
        }

        // GET: Odontologoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Odontologos == null)
            {
                return NotFound();
            }

            var odontologo = await _context.Odontologos
                .FirstOrDefaultAsync(m => m.IDOdontologo == id);
            if (odontologo == null)
            {
                return NotFound();
            }

            return View(odontologo);
        }

        // POST: Odontologoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Odontologos == null)
            {
                return Problem("Entity set 'MyDbContext.Odontologos'  is null.");
            }
            var odontologo = await _context.Odontologos.FindAsync(id);
            if (odontologo != null)
            {
                _context.Odontologos.Remove(odontologo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdontologoExists(int id)
        {
          return (_context.Odontologos?.Any(e => e.IDOdontologo == id)).GetValueOrDefault();
        }
    }
}
