using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PS_Fatto.Data;
using PS_Fatto.Models;

namespace PS_Fatto.Controllers
{
    public class TarefasController : Controller
    {
        private readonly PS_FattoContext _context;

        public TarefasController(PS_FattoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tarefas = await _context.Tarefa.OrderBy(t => t.Ordem).ToListAsync();
            return View(tarefas);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Custo,DataLimite")] Tarefa tarefa)
        {
            if (_context.Tarefa.Any(t => t.Nome == tarefa.Nome))
                ModelState.AddModelError("Nome", "Já existe uma tarefa com este nome.");

            if (ModelState.IsValid)
            {
                // Requisito: Novo registro deve ser o último na ordem
                int proximaOrdem = (_context.Tarefa.Max(t => (int?)t.Ordem) ?? 0) + 1;
                tarefa.Ordem = proximaOrdem;

                _context.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa == null) return NotFound();
            return View(tarefa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Custo,DataLimite,Ordem")] Tarefa tarefa)
        {
            if (id != tarefa.Id) return NotFound();

            if (_context.Tarefa.Any(t => t.Nome == tarefa.Nome && t.Id != id))
                ModelState.AddModelError("Nome", "Já existe outra tarefa com este nome.");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) { return NotFound(); }
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var tarefa = await _context.Tarefa.FirstOrDefaultAsync(m => m.Id == id);
            return tarefa == null ? NotFound() : View(tarefa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa != null) _context.Tarefa.Remove(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // REORDENAÇÃO (Subir/Descer)
        public async Task<IActionResult> Mover(int id, string direcao)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa == null) return RedirectToAction(nameof(Index));

            Tarefa outra = (direcao == "subir")
                ? await _context.Tarefa.Where(t => t.Ordem < tarefa.Ordem).OrderByDescending(t => t.Ordem).FirstOrDefaultAsync()
                : await _context.Tarefa.Where(t => t.Ordem > tarefa.Ordem).OrderBy(t => t.Ordem).FirstOrDefaultAsync();

            if (outra != null)
            {
                int temp = tarefa.Ordem;
                tarefa.Ordem = outra.Ordem;
                outra.Ordem = temp;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
