using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
    // A classe que representa o nosso recurso 
    [Table("TB_CLIENTES")]
    public class Cliente
    {
        [Key]
        [Column("id_cliente")]
        public int Id { get; set; }
        [Column("nome_cliente")]
        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome do cliente deve ter entre 3 e 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;
        [Column("email_cliente")]
        [Required(ErrorMessage = "O email do cliente é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email do cliente deve ser válido.")]
        public string Email { get; set; } = string.Empty;
        [Column("ativo")]
        [Required(ErrorMessage = "O status do cliente é obrigatório.")]
        public bool Ativo { get; set; }
        [Column("data_cadastro")]
        [Required(ErrorMessage = "A data de cadastro do cliente é obrigatória.")]
        public DateTime DataCadastro { get; set; }
    }
}
