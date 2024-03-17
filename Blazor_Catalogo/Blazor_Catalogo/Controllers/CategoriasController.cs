using Blazor_Catalogo.Context;
using Blazor_Catalogo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Catalogo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly AppDbContext context;
    public CategoriaController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Categoria>>> Get()
    {
        return await context.Categorias.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id}", Name = "GetCategoria")]
    public async Task<ActionResult<Categoria>> Get(int id)
    {
        var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.CategoriaId == id);

        if (categoria is null)
            return NotFound($"Categoria com {id} não encontrada");

        return categoria;
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> Post(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
        return new CreatedAtRouteResult("GetCategoria",
            new { id = categoria.CategoriaId }, categoria);
    }

    [HttpPut]
    public async Task<ActionResult<Categoria>> Put(Categoria categoria)
    {
        context.Entry(categoria).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok(categoria);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Categoria>> Delete(int id)
    {
        var categoria = new Categoria { CategoriaId = id };
        context.Remove(categoria);
        await context.SaveChangesAsync();
        return Ok(categoria);
    }
}
