using System;
using System.ComponentModel.DataAnnotations;
using SistemaDeGestãoFinanceiraEmpresarial.Enums;


namespace SistemaDeGestãoFinanceiraEmpresarial
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string RazaoSocial { get; set; }

        [StringLength(200)]
        public string? NomeFantasia { get; set; }

        [StringLength(18)]
        public string? Cnpj { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Telefone { get; set; }

        [StringLength(9)]
        public string? Cep { get; set; }

        [StringLength(200)]
        public string? Endereco { get; set; }

        [StringLength(10)]
        public string? Numero { get; set; }

        [StringLength(100)]
        public string? Cidade { get; set; }

        [StringLength(2)]
        public string? Estado { get; set; }

        public string? Observacoes { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}