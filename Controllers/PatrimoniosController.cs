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
    public class PatrimoniosController : Controller
    {
        private readonly Context _context;

        public PatrimoniosController(Context context)
        {
            _context = context;
        }

        // GET: Patrimonios
        public async Task<IActionResult> Index()
        {
            List<DtoPatrimonio> lista = (from pat in _context.patrimonio
                                         join loc in _context.local on pat.idlocal equals loc.id
                                         join fnc in _context.fornecedor on pat.idfornecedor equals fnc.id
                                         join dep in _context.departamento on pat.iddepartamento equals dep.id
                                         join cat in _context.categoria on pat.idcategoria equals cat.id
                                         select new DtoPatrimonio
                                         {
                                             id = pat.id,
                                             numetiqueta = pat.numetiqueta,
                                             nomepatrimonio = pat.nomepatrimonio,
                                             descricaopatrimonio = pat.descricaopatrimonio,
                                             idcategoria = pat.idcategoria,
                                             nomecategoria = cat.descricaocategoria,
                                             idlocal = pat.idlocal,
                                             nomelocal = loc.nomelocal,
                                             idfornecedor = pat.idfornecedor,
                                             nomefornecedor = fnc.nomefornecedor,
                                             iddepartamento = pat.iddepartamento,
                                             nomedepartamento = dep.nomedepartamento,
                                             valorpatrimonio = pat.valorpatrimonio,
                                             marcamodelo = pat.marcamodelo,
                                             numnf = pat.numnf,
                                             numserie = pat.numserie,
                                             situacao = pat.situacao,
                                             dataaquisicao = pat.dataaquisicao,
                                             databaixa = pat.databaixa,
                                             datagarantia = pat.datagarantia
                                         }).ToList();
            return View(lista);
        }

        // GET: Patrimonios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.patrimonio == null)
            {
                return NotFound();
            }

            var DtoPatrim = (from pat in _context.patrimonio
                          join loc in _context.local on pat.idlocal equals loc.id
                          join fnc in _context.fornecedor on pat.idfornecedor equals fnc.id
                          join dep in _context.departamento on pat.iddepartamento equals dep.id
                          join cat in _context.categoria on pat.idcategoria equals cat.id
                          where pat.id == id
                          select new DtoPatrimonio
                          {
                              id = pat.id,
                              numetiqueta = pat.numetiqueta,
                              nomepatrimonio = pat.nomepatrimonio,
                              descricaopatrimonio = pat.descricaopatrimonio,
                              idcategoria = pat.idcategoria,
                              nomecategoria = cat.descricaocategoria,
                              idlocal = pat.idlocal,
                              nomelocal = loc.nomelocal,
                              idfornecedor = pat.idfornecedor,
                              nomefornecedor = fnc.nomefornecedor,
                              iddepartamento = pat.iddepartamento,
                              nomedepartamento = dep.nomedepartamento,
                              valorpatrimonio = pat.valorpatrimonio,
                              marcamodelo = pat.marcamodelo,
                              numnf = pat.numnf,
                              numserie = pat.numserie,
                              situacao = pat.situacao,
                              dataaquisicao = pat.dataaquisicao,
                              databaixa = pat.databaixa,
                              datagarantia = pat.datagarantia
                          }).First();

            if (DtoPatrim == null)
            {
                return NotFound();
            }

            return View(DtoPatrim);
        }

        // GET: Patrimonios/Create
        public IActionResult Create()
        {
            ViewBag.Local = new SelectList(_context.local, "id", "nomelocal");

            ViewBag.Departamento = new SelectList(_context.departamento, "id", "nomedepartamento");

            ViewBag.Fornecedor = new SelectList(_context.fornecedor, "id", "nomefornecedor");

            ViewBag.Categoria = new SelectList(_context.categoria, "id", "descricaocategoria");

            return View();
        }

        // POST: Patrimonios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,numetiqueta,nomepatrimonio,descricaopatrimonio,valorpatrimonio,idcategoria,idlocal,iddepartamento,idfornecedor,marcamodelo,dataaquisicao,databaixa,numnf,numserie,situacao,datagarantia")] DbPatrimonio dbPatrimonio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbPatrimonio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbPatrimonio);
        }

        // GET: Patrimonios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.patrimonio == null)
            {
                return NotFound();
            }

            var DtoPatrim = (from pat in _context.patrimonio
                             join loc in _context.local on pat.idlocal equals loc.id
                             join fnc in _context.fornecedor on pat.idfornecedor equals fnc.id
                             join dep in _context.departamento on pat.iddepartamento equals dep.id
                             join cat in _context.categoria on pat.idcategoria equals cat.id
                             where pat.id == id
                             select new DtoPatrimonio
                             {
                                 id = pat.id,
                                 numetiqueta = pat.numetiqueta,
                                 nomepatrimonio = pat.nomepatrimonio,
                                 descricaopatrimonio = pat.descricaopatrimonio,
                                 idcategoria = pat.idcategoria,
                                 nomecategoria = cat.descricaocategoria,
                                 idlocal = pat.idlocal,
                                 nomelocal = loc.nomelocal,
                                 idfornecedor = pat.idfornecedor,
                                 nomefornecedor = fnc.nomefornecedor,
                                 iddepartamento = pat.iddepartamento,
                                 nomedepartamento = dep.nomedepartamento,
                                 valorpatrimonio = pat.valorpatrimonio,
                                 marcamodelo = pat.marcamodelo,
                                 numnf = pat.numnf,
                                 numserie = pat.numserie,
                                 situacao = pat.situacao,
                                 dataaquisicao = pat.dataaquisicao,
                                 databaixa = pat.databaixa,
                                 datagarantia = pat.datagarantia
                             }).First();

            if (DtoPatrim == null)
            {
                return NotFound();
            }

            ViewBag.Local = new SelectList(_context.local, "id", "nomelocal");
            ViewBag.Departamento = new SelectList(_context.departamento, "id", "nomedepartamento");
            ViewBag.Fornecedor = new SelectList(_context.fornecedor, "id", "nomefornecedor");
            ViewBag.Categoria = new SelectList(_context.categoria, "id", "descricaocategoria");

            return View(DtoPatrim);
        }

        // POST: Patrimonios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,numetiqueta,nomepatrimonio,descricaopatrimonio,valorpatrimonio,idcategoria,idlocal,iddepartamento,idfornecedor,marcamodelo,dataaquisicao,databaixa,numnf,numserie,situacao,datagarantia")] DbPatrimonio dbPatrimonio)
        {
            if (id != dbPatrimonio.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbPatrimonio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbPatrimonioExists(dbPatrimonio.id))
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
            return View(dbPatrimonio);
        }

        // GET: Patrimonios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.patrimonio == null)
            {
                return NotFound();
            }

            var DtoPatrim = (from pat in _context.patrimonio
                             join loc in _context.local on pat.idlocal equals loc.id
                             join fnc in _context.fornecedor on pat.idfornecedor equals fnc.id
                             join dep in _context.departamento on pat.iddepartamento equals dep.id
                             join cat in _context.categoria on pat.idcategoria equals cat.id
                             where pat.id == id
                             select new DtoPatrimonio
                             {
                                 id = pat.id,
                                 numetiqueta = pat.numetiqueta,
                                 nomepatrimonio = pat.nomepatrimonio,
                                 descricaopatrimonio = pat.descricaopatrimonio,
                                 idcategoria = pat.idcategoria,
                                 nomecategoria = cat.descricaocategoria,
                                 idlocal = pat.idlocal,
                                 nomelocal = loc.nomelocal,
                                 idfornecedor = pat.idfornecedor,
                                 nomefornecedor = fnc.nomefornecedor,
                                 iddepartamento = pat.iddepartamento,
                                 nomedepartamento = dep.nomedepartamento,
                                 valorpatrimonio = pat.valorpatrimonio,
                                 marcamodelo = pat.marcamodelo,
                                 numnf = pat.numnf,
                                 numserie = pat.numserie,
                                 situacao = pat.situacao,
                                 dataaquisicao = pat.dataaquisicao,
                                 databaixa = pat.databaixa,
                                 datagarantia = pat.datagarantia
                             }).First();

            if (DtoPatrim == null)
            {
                return NotFound();
            }

            return View(DtoPatrim);
        }

        // POST: Patrimonios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.patrimonio == null)
            {
                return Problem("Entity set 'Context.patrimonio'  is null.");
            }
            var dbPatrimonio = await _context.patrimonio.FindAsync(id);
            if (dbPatrimonio != null)
            {
                _context.patrimonio.Remove(dbPatrimonio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbPatrimonioExists(int id)
        {
          return (_context.patrimonio?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
