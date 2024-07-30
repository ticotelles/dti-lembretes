using Microsoft.EntityFrameworkCore;

namespace SistemaDeLembretes.Models
{
    public class ContextoDB : DbContext
    {
        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options)
        {
        }

        public DbSet<Lembrete> Lembretes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=sistema-de-lembretes;Uid=root;Pwd=ddfe2ff9;");

        }
    }
}