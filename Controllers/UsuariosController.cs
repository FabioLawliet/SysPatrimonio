﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysPatrimonio.Models;

namespace SysPatrimonio.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Context _context;

        public UsuariosController(Context context)
        {
            _context = context;
        }

        // GET: DbUsuarios
        public async Task<IActionResult> Index()
        {
            ViewBag.Nome = (from c in _context.usuarios
                            select c.nome).Distinct();

            ViewBag.Login = (from c in _context.usuarios
                             select c.login).Distinct();

            return View(await _context.usuarios.ToListAsync());
            /* return _context.usuarios != null ? 
                          View(await _context.usuarios.ToListAsync()) :
                          Problem("Entity set 'Context.usuarios'  is null.");*/
        }

        // GET: DbUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }

            var dbUsuario = await _context.usuarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbUsuario == null)
            {
                return NotFound();
            }

            return View(dbUsuario);
        }

        // GET: DbUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,login,senha,status")] DbUsuario dbUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbUsuario);
        }

        // GET: DbUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }

            var dbUsuario = await _context.usuarios.FindAsync(id);
            if (dbUsuario == null)
            {
                return NotFound();
            }
            return View(dbUsuario);
        }

        // POST: DbUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,login,senha,status")] DbUsuario dbUsuario)
        {
            if (id != dbUsuario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbUsuarioExists(dbUsuario.id))
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
            return View(dbUsuario);
        }

        // GET: DbUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.usuarios == null)
            {
                return NotFound();
            }

            var dbUsuario = await _context.usuarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbUsuario == null)
            {
                return NotFound();
            }

            return View(dbUsuario);
        }

        // POST: DbUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.usuarios == null)
            {
                return Problem("Entity set 'Context.usuarios'  is null.");
            }
            var dbUsuario = await _context.usuarios.FindAsync(id);
            if (dbUsuario != null)
            {
                _context.usuarios.Remove(dbUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbUsuarioExists(int id)
        {
          return (_context.usuarios?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
