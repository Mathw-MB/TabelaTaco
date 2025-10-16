using Microsoft.EntityFrameworkCore;

namespace ProjetoDietas.Models;

public class AppDataContext : DbContext
{
    public DbSet<Alimento> Alimentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=taco.db");
    }
}
