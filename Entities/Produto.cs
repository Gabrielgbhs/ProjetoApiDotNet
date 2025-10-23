using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LojaApi.Entities;

public class Produto
{
  public int Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public decimal Valor { get; set; } = 0.0m;
  public string Descricao { get; set; } = string.Empty;
  public int Estoque { get; set; } = 0;
  public bool Ativo { get; set; }
  public DateTime DataCadastro { get; set; }
  public int CategoriaId { get; set; }
  public Categoria? Categoria { get; set; }
    public ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();
}
