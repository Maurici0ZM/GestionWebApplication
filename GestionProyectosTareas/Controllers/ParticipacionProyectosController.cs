using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionProyectosTareas.Models;

namespace GestionProyectosTareas.Controllers
{
    public class ParticipacionProyectosController : Controller
    {
        private readonly GestionDBProyectosContext _context;

        public ParticipacionProyectosController(GestionDBProyectosContext context)
        {
            _context = context;
        }

        // GET: ParticipacionProyectos
        public async Task<IActionResult> Index()
        {
            var gestionDBProyectosContext = _context.ParticipacionProyecto.Include(p => p.Proyecto).Include(p => p.Usuario);
            return View(await gestionDBProyectosContext.ToListAsync());
        }

        // GET: ParticipacionProyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParticipacionProyecto == null)
            {
                return NotFound();
            }

            var participacionProyecto = await _context.ParticipacionProyecto
                .Include(p => p.Proyecto)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participacionProyecto == null)
            {
                return NotFound();
            }

            return View(participacionProyecto);
        }

        // GET: ParticipacionProyectos/Create
        public IActionResult Create()
        {
            ViewData["ProyectoId"] = new SelectList(_context.Proyecto, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: ParticipacionProyectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,ProyectoId")] ParticipacionProyecto participacionProyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participacionProyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProyectoId"] = new SelectList(_context.Proyecto, "Id", "Id", participacionProyecto.ProyectoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", participacionProyecto.UsuarioId);
            return View(participacionProyecto);
        }

        // GET: ParticipacionProyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParticipacionProyecto == null)
            {
                return NotFound();
            }

            var participacionProyecto = await _context.ParticipacionProyecto.FindAsync(id);
            if (participacionProyecto == null)
            {
                return NotFound();
            }
            ViewData["ProyectoId"] = new SelectList(_context.Proyecto, "Id", "Id", participacionProyecto.ProyectoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", participacionProyecto.UsuarioId);
            return View(participacionProyecto);
        }

        // POST: ParticipacionProyectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,ProyectoId")] ParticipacionProyecto participacionProyecto)
        {
            if (id != participacionProyecto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participacionProyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipacionProyectoExists(participacionProyecto.Id))
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
            ViewData["ProyectoId"] = new SelectList(_context.Proyecto, "Id", "Id", participacionProyecto.ProyectoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", participacionProyecto.UsuarioId);
            return View(participacionProyecto);
        }

        // GET: ParticipacionProyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParticipacionProyecto == null)
            {
                return NotFound();
            }

            var participacionProyecto = await _context.ParticipacionProyecto
                .Include(p => p.Proyecto)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participacionProyecto == null)
            {
                return NotFound();
            }

            return View(participacionProyecto);
        }

        // POST: ParticipacionProyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParticipacionProyecto == null)
            {
                return Problem("Entity set 'GestionDBProyectosContext.ParticipacionProyecto'  is null.");
            }
            var participacionProyecto = await _context.ParticipacionProyecto.FindAsync(id);
            if (participacionProyecto != null)
            {
                _context.ParticipacionProyecto.Remove(participacionProyecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipacionProyectoExists(int id)
        {
          return (_context.ParticipacionProyecto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
