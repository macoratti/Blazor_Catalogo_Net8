using Blazor_Catalogo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Catalogo.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Categoria> Categorias { get; set; }

}
