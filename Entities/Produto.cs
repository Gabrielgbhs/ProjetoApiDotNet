using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities;

[Table("TB_PRODUTO")]
public class Produto
{
  [Key]
  [Column("id_produto")]
  public int Id { get; set; }
  [Column("nome_produto")]
  [Required]
  [StringLength(150)]
  public string Nome { get; set; } = string.Empty;
  [Column("valor_produto")]
  [Required]
  public decimal Valor { get; set; } = 0.0m;
  [Column("descricao_produto")]
  [Required]
  public string Descricao { get; set; } = string.Empty;
  [Column("estoque_produto")]
  [Required]
  public int Estoque { get; set; } = 0;
  [Column("ativo")]
  [Required]
  public bool Ativo { get; set; }
  [Column("data_cadastro")]
  [Required]
  public DateTime DataCadastro { get; set; }
}
