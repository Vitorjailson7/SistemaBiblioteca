using System;
using SistemaBiblioteca;

class Program
{
    static void Main()
    {
        var biblioteca = new Biblioteca();

        var livro = new Livro { Titulo = "O Alquimista", Autor = "Paulo Coelho", Quantidade = 3 };
        var usuario = new Usuario { Nome = "João Silva", CPF = "123.456.789-00" };

        biblioteca.CadastrarLivro(livro);
        biblioteca.CadastrarUsuario(usuario);

        biblioteca.RegistrarEmprestimo(livro, usuario);

        foreach (var l in biblioteca.ListarLivros())
        {
            Console.WriteLine($"Título: {l.Titulo}, Autor: {l.Autor}, Quantidade: {l.Quantidade}");
        }

        foreach (var e in biblioteca.ListarEmprestimos())
        {
            Console.WriteLine($"Livro: {e.Livro.Titulo}, Usuário: {e.Usuario.Nome}, Data de Empréstimo: {e.Periodo.DataEmprestimo}");
        }
    }
}

