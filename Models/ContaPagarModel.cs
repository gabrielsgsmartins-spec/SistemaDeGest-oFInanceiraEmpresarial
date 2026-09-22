using System;
using System.ComponentModel.DataAnnotations;
using SistemaDeGestãoFinanceiraEmpresarial.Enums;

namespace SistemaDeGestãoFinanceiraEmpresarial
{
    public class ContaPagarModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Selecione o fornecedor.")]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "Informe a descrição da conta.")]
        [StringLength(200)]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o valor da conta.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Informe a data de emissão.")]
        public DateTime DataEmissao { get; set; }

        [Required(ErrorMessage = "Informe a data de vencimento.")]
        public DateTime DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

        [Required(ErrorMessage = "Informe o status da conta.")]
        public StatusContaEnum Status { get; set; }

        [Required(ErrorMessage = "Informe a forma de pagamento.")]
        public FormaPagamentoEnum FormaPagamento { get; set; }

        public int? CategoriaFinanceiraId { get; set; }

        public int? CentroCustoId { get; set; }

        public string? Observacao { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public string? UsuarioCriacaoId { get; set; }


     
        public FornecedorModel? Fornecedor { get; set; }

        // Relacionamento com Categoria Financeira
        public CategoriaFinanceiraModel? CategoriaFinanceira { get; set; }

        // Relacionamento com Centro de Custo
        public CentroCustoModel? CentroCusto { get; set; }
    }
}