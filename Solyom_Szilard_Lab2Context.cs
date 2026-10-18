using Microsoft.EntityFrameworkCore;

public class Solyom_Szilard_Lab2Context(DbContextOptions<Solyom_Szilard_Lab2Context> options) : DbContext(options)
{
    public DbSet<Solyom_Szilard_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Solyom_Szilard_Lab2.Models.Publisher> Publisher { get; set; } = default!;
}
