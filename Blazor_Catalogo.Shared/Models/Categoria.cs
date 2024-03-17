using System.ComponentModel.DataAnnotations;

namespace Blazor_Catalogo.Shared.Models;

public class Categoria
{
    [Key]
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório")]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A descricao da categoria é obrigatória")]
    [MaxLength(200)]
    public string? Descricao { get; set; }
}
