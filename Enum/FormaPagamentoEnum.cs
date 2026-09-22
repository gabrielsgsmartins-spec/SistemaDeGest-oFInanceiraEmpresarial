using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestãoFinanceiraEmpresarial.Enums
{
    public enum FormaPagamentoEnum
    {
        Dinheiro = 1,
        Pix = 2,
        Boleto = 3,
        CartaoCredito = 4,
        CartaoDebito = 5,
        Transferencia = 6,
        DebitoAutomatico = 7
    }
}