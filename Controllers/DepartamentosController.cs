using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysPatrimonio.Models;

namespace SysPatrimonio.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly Context _context;

        public DepartamentosController(Context context)
        {
            _context = context;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
            List<DtoDepartamento> lista = (from d in _context.departamento
                                           join l in _context.local on d.idlocal equals l.id
                                           orderby d.nomedepartamento
                                           select new DtoDepartamento
                                           {
                                               id = d.id,
                                               nomedepartamento = d.nomedepartamento,
                                               descricaodepartamento = d.descricaodepartamento,
                                               nomelocal = l.nomelocal,
                                               idlocal = d.idlocal
                                           }).ToList();
            return View(lista);
            
            /*return _context.departamento != null ? 
                          View(await _context.departamento.ToListAsync()) :
                          Problem("Entity set 'Context.departamento'  is null.");*/
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var DtoDep = (from d in _context.departamento
                         join l in _context.local on d.idlocal equals l.id
                         where d.id == id
                         select new DtoDepartamento
                         {
                             id = d.id,
                             nomedepartamento = d.nomedepartamento,
                             descricaodepartamento = d.descricaodepartamento,
                             nomelocal = l.nomelocal,
                             idlocal = d.idlocal
                         }).First();

            if (DtoDep == null)
            {
                return NotFound();
            }

            return View(DtoDep);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            /*ViewBag.Local = (from c in _context.local
                             select c.nomelocal).Distinct();*/

            ViewBag.Local = new SelectList(_context.local, "id", "nomelocal");

            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomedepartamento,descricaodepartamento,idlocal")] DbDepartamento dbDepartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbDepartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbDepartamento);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var DtoDep = (from d in _context.departamento
                          join l in _context.local on d.idlocal equals l.id
                          where d.id == id
                          select new DtoDepartamento
                          {
                              id = d.id,
                              nomedepartamento = d.nomedepartamento,
                              descricaodepartamento = d.descricaodepartamento,
                              nomelocal = l.nomelocal,
                              idlocal = d.idlocal
                          }).First();

            if (DtoDep == null)
            {
                return NotFound();
            }

            ViewBag.Local = new SelectList(_context.local, "id", "nomelocal");

            return View(DtoDep);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomedepartamento,descricaodepartamento,idlocal")] DbDepartamento dbDepartamento)
        {


            if (id != dbDepartamento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbDepartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbDepartamentoExists(dbDepartamento.id))
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
            return View(dbDepartamento);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var DtoDep = (from d in _context.departamento
                          join l in _context.local on d.idlocal equals l.id
                          where d.id == id
                          select new DtoDepartamento
                          {
                              id = d.id,
                              nomedepartamento = d.nomedepartamento,
                              descricaodepartamento = d.descricaodepartamento,
                              nomelocal = l.nomelocal,
                              idlocal = d.idlocal
                          }).First();

            if (DtoDep == null)
            {
                return NotFound();
            }

            return View(DtoDep);    
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.departamento == null)
            {
                return Problem("Entity set 'Context.departamento'  is null.");
            }
            var dbDepartamento = await _context.departamento.FindAsync(id);
            if (dbDepartamento != null)
            {
                _context.departamento.Remove(dbDepartamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbDepartamentoExists(int id)
        {
          return (_context.departamento?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
