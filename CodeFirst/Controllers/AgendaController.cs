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
    public class AgendaController : Controller
    {
        private readonly MyDbContext _context;

        public AgendaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Agenda
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.agendas.Include(a => a.Odontologo).Include(a => a.Paciente);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Agenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.agendas == null)
            {
                return NotFound();
            }

            var agenda = await _context.agendas
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .FirstOrDefaultAsync(m => m.IDPaciente == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // GET: Agenda/Create
        public IActionResult Create()
        {
            ViewData["IDOdontologo"] = new SelectList(_context.Odontologos, "IDOdontologo", "IDOdontologo");
            ViewData["IDPaciente"] = new SelectList(_context.Pacientes, "IDPaciente", "IDPaciente");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Motivo,Fecha_Hora_Inicio,Fecha_Hora_Fin,IDPaciente,IDOdontologo")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDOdontologo"] = new SelectList(_context.Odontologos, "IDOdontologo", "IDOdontologo", agenda.IDOdontologo);
            ViewData["IDPaciente"] = new SelectList(_context.Pacientes, "IDPaciente", "IDPaciente", agenda.IDPaciente);
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.agendas == null)
            {
                return NotFound();
            }

            var agenda = await _context.agendas.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }
            ViewData["IDOdontologo"] = new SelectList(_context.Odontologos, "IDOdontologo", "IDOdontologo", agenda.IDOdontologo);
            ViewData["IDPaciente"] = new SelectList(_context.Pacientes, "IDPaciente", "IDPaciente", agenda.IDPaciente);
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Motivo,Fecha_Hora_Inicio,Fecha_Hora_Fin,IDPaciente,IDOdontologo")] Agenda agenda)
        {
            if (id != agenda.IDPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaExists(agenda.IDPaciente))
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
            ViewData["IDOdontologo"] = new SelectList(_context.Odontologos, "IDOdontologo", "IDOdontologo", agenda.IDOdontologo);
            ViewData["IDPaciente"] = new SelectList(_context.Pacientes, "IDPaciente", "IDPaciente", agenda.IDPaciente);
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.agendas == null)
            {
                return NotFound();
            }

            var agenda = await _context.agendas
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .FirstOrDefaultAsync(m => m.IDPaciente == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.agendas == null)
            {
                return Problem("Entity set 'MyDbContext.agendas'  is null.");
            }
            var agenda = await _context.agendas.FindAsync(id);
            if (agenda != null)
            {
                _context.agendas.Remove(agenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaExists(int id)
        {
          return (_context.agendas?.Any(e => e.IDPaciente == id)).GetValueOrDefault();
        }
    }
}
