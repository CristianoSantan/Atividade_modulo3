using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroContext _context;

        public LivroController(LivroContext context)
        {
            _context = context;
        }

        // GET: Livro
        public async Task<IActionResult> Index()
        {
            var livroContext = _context.Livros.Include(l => l.Autor).Include(l => l.Editora);
            return View(await livroContext.ToListAsync());
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Editora)
                .FirstOrDefaultAsync(m => m.Id_livro == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livro/Create
        public IActionResult Create()
        {
            ViewData["AutorId_autor"] = new SelectList(_context.Autores, "Id_autor", "Nome");
            ViewData["EditoraId_editora"] = new SelectList(_context.Editoras, "Id_editora", "Nome");
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_livro,Nome,isbn,Preco,AutorId_autor,EditoraId_editora")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId_autor"] = new SelectList(_context.Autores, "Id_autor", "Nome", livro.AutorId_autor);
            ViewData["EditoraId_editora"] = new SelectList(_context.Editoras, "Id_editora", "Nome", livro.EditoraId_editora);
            return View(livro);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AutorId_autor"] = new SelectList(_context.Autores, "Id_autor", "Nome", livro.AutorId_autor);
            ViewData["EditoraId_editora"] = new SelectList(_context.Editoras, "Id_editora", "Nome", livro.EditoraId_editora);
            return View(livro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_livro,Nome,isbn,Preco,AutorId_autor,EditoraId_editora")] Livro livro)
        {
            if (id != livro.Id_livro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id_livro))
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
            ViewData["AutorId_autor"] = new SelectList(_context.Autores, "Id_autor", "Nome", livro.AutorId_autor);
            ViewData["EditoraId_editora"] = new SelectList(_context.Editoras, "Id_editora", "Nome", livro.EditoraId_editora);
            return View(livro);
        }

        // GET: Livro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Editora)
                .FirstOrDefaultAsync(m => m.Id_livro == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.Id_livro == id);
        }
    }
}
