using System;

namespace BibliotecaApp.Models
{
    public struct PeriodoEmprestimo
    {
        public DateTime DataEmprestimo;
        public DateTime? DataDevolucao;

        public PeriodoEmprestimo(DateTime dataEmprestimo)
        {
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = null;
        }
    }
}
