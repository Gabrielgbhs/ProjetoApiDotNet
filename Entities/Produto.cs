using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LojaApi.Entities;

[Table("TB_PRODUTO")]
public class Produto
{
  [Key]
  [Column("id_produto")]
  public int Id { get; set; }
  [Column("nome_produto")]
  [Required(ErrorMessage = "O nome do produto é obrigatório.")]
  [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome do produto deve ter entre 3 e 150 caracteres.")]
  public string Nome { get; set; } = string.Empty;
  [Column("valor_produto", TypeName = "decimal(10, 2)")]
  [Required(ErrorMessage = "O valor é obrigatório.")]
  [Range(0.01, 100000.00, ErrorMessage = "O valor deve ser entre 0.01 e 100,000.00.")]
  public decimal Valor { get; set; } = 0.0m;
  [Column("descricao_produto")]
  [Required]
  public string Descricao { get; set; } = string.Empty;
  [Column("estoque_produto")]
  [Range(0, 9999, ErrorMessage = "O estoque deve ser entre 0 e 9999.")]
  public int Estoque { get; set; } = 0;
  [Column("ativo")]
  [Required(ErrorMessage = "O status do produto é obrigatório.")]
  public bool Ativo { get; set; }
  [Column("data_cadastro")]
  [Required(ErrorMessage = "A data de cadastro do produto é obrigatória.")]
  public DateTime DataCadastro { get; set; }
  [Column("id_categoria")]
  [Required(ErrorMessage = "O ID da categoria é obrigatório.")]
  public int CategoriaId { get; set; }

  [ForeignKey("CategoriaId")]
  [JsonIgnore]
  public Categoria? Categoria { get; set; }
}
