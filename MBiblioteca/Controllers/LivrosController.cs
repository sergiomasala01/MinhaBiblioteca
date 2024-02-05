using MBiblioteca.Data;
using MBiblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [Route("Cadastrar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Cadastrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Autor,Genero,Sinopse,AnoPublicacao")] LivroModel livroModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livroModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livroModel);
        }
        
    }
}
