using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestãoFinanceiraEmpresarial.Enums
{
    public enum StatusContaEnum
    {
        Pendente = 1,
        AguardandoAprovacao = 2,
        Aprovada = 3,
        Vencida = 4,
        Paga = 5,
        Cancelada = 6
    }
}