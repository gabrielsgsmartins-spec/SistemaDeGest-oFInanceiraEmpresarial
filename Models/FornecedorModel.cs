using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestãoFinanceiraEmpresarial
{
    public class FornecedorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a razão social do fornecedor.")]
        [StringLength(200)]
        public string RazaoSocial { get; set; } = string.Empty;

        [StringLength(200)]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ do fornecedor.")]
        [StringLength(18)]
        public string CNPJ { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o e-mail do fornecedor.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o telefone do fornecedor.")]
        [StringLength(20)]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CEP do fornecedor.")]
        [StringLength(9)]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o endereço do fornecedor.")]
        [StringLength(200)]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o número do endereço.")]
        [StringLength(10)]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a cidade do fornecedor.")]
        [StringLength(100)]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o estado do fornecedor.")]
        [StringLength(2)]
        public string Estado { get; set; } = string.Empty;

        public string? Observacoes { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}