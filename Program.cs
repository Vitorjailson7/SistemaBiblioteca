using System;
using SistemaBiblioteca;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var biblioteca = new Biblioteca();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== SISTEMA BIBLIOTECA ======");
            Console.WriteLine("1. Cadastrar Livro");
            Console.WriteLine("2. Cadastrar Usuário");
            Console.WriteLine("3. Registrar Empréstimo");
            Console.WriteLine("4. Registrar Devolução");
            Console.WriteLine("5. Listar Livros");
            Console.WriteLine("6. Exibir Relatórios de Empréstimos");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("== Cadastro de Livro ==");
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();
                    Console.Write("Quantidade: ");
                    int quantidade = int.Parse(Console.ReadLine());

                    var novoLivro = new Livro { Titulo = titulo, Autor = autor, Quantidade = quantidade };
                    biblioteca.CadastrarLivro(novoLivro);

                    Console.WriteLine("Livro cadastrado com sucesso!");
                    break;

                case "2":
                    Console.WriteLine("== Cadastro de Usuário ==");
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("CPF: ");
                    string cpf = Console.ReadLine();

                    var novoUsuario = new Usuario { Nome = nome, CPF = cpf };
                    biblioteca.CadastrarUsuario(novoUsuario);

                    Console.WriteLine("Usuário cadastrado com sucesso!");
                    break;

                case "3":
                    Console.WriteLine("== Registrar Empréstimo ==");
                    Console.Write("Título do Livro: ");
                    string tituloEmprestimo = Console.ReadLine();
                    Console.Write("CPF do Usuário: ");
                    string cpfEmprestimo = Console.ReadLine();

                    var livroEmprestimo = biblioteca.BuscarLivroPorTitulo(tituloEmprestimo);
                    var usuarioEmprestimo = biblioteca.BuscarUsuarioPorCPF(cpfEmprestimo);

                    if (livroEmprestimo != null && usuarioEmprestimo != null)
                    {
                        biblioteca.RegistrarEmprestimo(livroEmprestimo, usuarioEmprestimo);
                        Console.WriteLine("Empréstimo registrado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Livro ou Usuário não encontrado!");
                    }
                    break;

                case "4":
                    Console.WriteLine("== Registrar Devolução ==");
                    Console.Write("Título do Livro: ");
                    string tituloDevolucao = Console.ReadLine();
                    Console.Write("CPF do Usuário: ");
                    string cpfDevolucao = Console.ReadLine();

                    biblioteca.RegistrarDevolucao(tituloDevolucao, cpfDevolucao);
                    break;

                case "5":
                    Console.WriteLine("== Lista de Livros ==");
                    foreach (var l in biblioteca.ListarLivros())
                    {
                        Console.WriteLine($"Título: {l.Titulo}, Autor: {l.Autor}, Quantidade: {l.Quantidade}");
                    }
                    break;

                case "6":
                    Console.WriteLine("== Relatório de Empréstimos ==");
                    foreach (var e in biblioteca.ListarEmprestimos())
                    {
                        Console.WriteLine($"Livro: {e.Livro.Titulo}, Usuário: {e.Usuario.Nome}, Data: {e.Periodo.DataEmprestimo}");
                    }
                    break;

                case "0":
                    Console.WriteLine("Saindo do sistema...");
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}

