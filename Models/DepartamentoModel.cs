using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestãoFinanceiraEmpresarial
{
    public class DepartamentoModel
    {
        public int Id { get; set; }
        public string Departamento { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }

}
