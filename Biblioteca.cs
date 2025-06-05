using System.Collections.Generic;

namespace SistemaBiblioteca
{
    public class Biblioteca
    {
        private List<Livro> livros = new List<Livro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        public void CadastrarLivro(Livro livro)
        {
            livros.Add(livro);
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void RegistrarEmprestimo(Livro livro, Usuario usuario)
        {
            if (livro.Quantidade > 0)
            {
                var emprestimo = new Emprestimo(livro, usuario);
                emprestimos.Add(emprestimo);
                livro.Quantidade--;
            }
        }

        public void RegistrarDevolucao(Emprestimo emprestimo)
        {
            emprestimo.RegistrarDevolucao();
            emprestimo.Livro.Quantidade++;
        }

        public List<Livro> ListarLivros()
        {
            return livros;
        }

        public List<Emprestimo> ListarEmprestimos()
        {
            return emprestimos;
        }
    }
}

