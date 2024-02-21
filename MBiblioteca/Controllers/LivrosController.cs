using MBiblioteca.Data;
using MBiblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MBiblioteca.Controllers
{
    public class LivrosController : Controller
    {
        private readonly AppDbContext _context;

        public LivrosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Livros.ToListAsync());
        }

        [Route("cadastro-livro")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("cadastro-livro")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Autor,Genero,Sinopse,AnoPublicacao")] LivroModel livroModel)
        {
            if (ModelState.IsValid)
            {
                var livro = await _context.Livros.FirstOrDefaultAsync((v => v.Titulo == livroModel.Titulo && v.Autor == livroModel.Autor));

                if (livro != null)
                {         
                    livro.QuantidadeDisponivel += 1;
                    _context.Update(livro);                                               
                }                                                                                                                                                       
                else
                {
                    livroModel.QuantidadeDisponivel = 1;
                    _context.Add(livroModel);
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [Route("editar-livro/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            var livroModel = await _context.Livros.FindAsync(id);

            if (livroModel == null)
            {
                return NotFound();
            }
            return View(livroModel);
        }

        [HttpPost("editar-livro/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Autor,Genero,Sinopse,AnoPublicacao,QuantidadeDisponivel")] LivroModel livroModel)
        {
            if (id != livroModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(livroModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livroModel);
        }

        [Route("detalhes-livro/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.Livros.FindAsync(id);

            if (alunoModel == null)
            {
                return NotFound();
            }

            return View(alunoModel);
        }

        [Route("excluir-livro/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {

            var livroModel = await _context.Livros.FindAsync(id);

            if (livroModel == null)
            {
                return NotFound();
            }

            return View(livroModel);
        }

        [HttpPost("excluir-livro/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var livroModel = await _context.Livros.FindAsync(id);

            if (livroModel != null)
            {
                _context.Livros.Remove(livroModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
} 
