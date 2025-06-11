using System;

namespace BibliotecaApp.Models
{
    public class Emprestimo
    {
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
        public PeriodoEmprestimo Periodo { get; set; }
        public bool Finalizado => Periodo.DataDevolucao.HasValue;

        public Emprestimo(Usuario usuario, Livro livro)
        {
            Usuario = usuario;
            Livro = livro;
            Periodo = new PeriodoEmprestimo(DateTime.Now);
        }

        public void Devolver()
        {
            var periodo = this.Periodo;
            periodo.DataDevolucao = DateTime.Now;
            this.Periodo = periodo;

            Livro.Quantidade++;
        }
    }
}
