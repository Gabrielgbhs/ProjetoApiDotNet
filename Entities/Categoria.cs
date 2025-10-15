using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities;

[Table("TB_CATEGORIA")]
public class Categoria
{
    [Key]
    [Column("id_categoria")]
    public int Id { get; set; }
    [Column("descricao_categoria")]
    [Required(ErrorMessage = "A descrição da categoria é obrigatória.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "A descrição da categoria deve ter entre 3 e 150 caracteres.")]
    public string Descricao { get; set; } = string.Empty;
    [Column("ativo")]
    [Required(ErrorMessage = "O status da categoria é obrigatório.")]
    public bool Ativo { get; set; }
    [Column("data_cadastro")]
    [Required(ErrorMessage = "A data de cadastro da categoria é obrigatória.")]
    public DateTime DataCadastro { get; set; }
    
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
