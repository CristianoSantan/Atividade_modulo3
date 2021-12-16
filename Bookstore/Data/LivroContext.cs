using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> opt) : base(opt)
        {
        }
        public DbSet<Autor> Autores {get; set;}
        public DbSet<Editora> Editoras {get; set;}
        public DbSet<Livro> Livros {get; set;}
    }
}