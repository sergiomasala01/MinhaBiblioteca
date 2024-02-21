using MBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace MBiblioteca.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<LeitorModel> Leitores { get; set; }
        public DbSet<EmprestimoModel> Emprestimos { get; set; }
    }
}
