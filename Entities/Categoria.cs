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
    [Required]
    [StringLength(150)]
    public string Descricao { get; set; } = string.Empty;
    [Column("ativo")]
    [Required]
    public bool Ativo { get; set; }
    [Column("data_cadastro")]
    [Required]
    public DateTime DataCadastro { get; set; }
}
