using MBiblioteca.Data;
using MBiblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBiblioteca.Controllers
{
    public class LeitoresController : Controller
    {
        private readonly AppDbContext _context;

        public LeitoresController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Leitores.ToListAsync());
        }

        [Route("cadastro-leitor")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("cadastro-leitor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,Email,Telefone,CEP,Logadouro,Numero,Complemento,Bairro,Localidade,UF,DataNascimento")] LeitorModel leitorModel)
        {

            if (ModelState.IsValid)
            {
                _context.Add(leitorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leitorModel);
        }

        [Route("editar-leitor/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            var leitorModel = await _context.Leitores.FindAsync(id);

            if (leitorModel == null)
            {
                return NotFound();
            }
            return View(leitorModel);
        }

        [HttpPost("editar-leitor/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,Email,Telefone,CEP,Logadouro,Numero,Complemento,Bairro,Localidade,UF,DataNascimento")] LeitorModel leitorModel)
        {
            if (id != leitorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(leitorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leitorModel);
        }

        [Route("detalhes-leitor/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            var leitorModel = await _context.Leitores.FindAsync(id);

            if(leitorModel == null)
            {
                return NotFound();
            }
            return View(leitorModel);
        }

        [Route("excluir-leitor/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {

            var leitorModel = await _context.Leitores.FindAsync(id);

            if (leitorModel == null)
            {
                return NotFound();
            }

            return View(leitorModel);
        }

        [HttpPost("excluir-leitor/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var leitorModel = await _context.Leitores.FindAsync(id);

            if (leitorModel != null)
            {
                _context.Leitores.Remove(leitorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
