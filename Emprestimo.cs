namespace SistemaBiblioteca
{
    public class Emprestimo
    {
        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }
        public PeriodoEmprestimo Periodo { get; set; }

        public Emprestimo(Livro livro, Usuario usuario)
        {
            Livro = livro;
            Usuario = usuario;
            Periodo = new PeriodoEmprestimo
            {
                DataEmprestimo = DateTime.Now,
                DataDevolucao = null
            };
        }

        public void RegistrarDevolucao()
        {
            var periodo = Periodo;
            periodo.DataDevolucao = DateTime.Now;
            Periodo = periodo;
        }
    }
}
