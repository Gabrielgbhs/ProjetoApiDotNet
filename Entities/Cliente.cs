using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
    public class Cliente
    {
        public int Id { get; set; }public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        // Propriedade de Navegação para o relacionamento 1:1
        public Endereco? Endereco { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
