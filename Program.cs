using System;
using BibliotecaApp.Services;

namespace BibliotecaApp
{
    public class Program
    {
        public static void Main()
        {
            var biblioteca = new Biblioteca();
            bool rodando = true;

            while (rodando)
            {
                Console.WriteLine("\n--- BEM-VINDO À BIBLIOTECA ---");
                Console.WriteLine("1. Adicionar Novo Livro");
                Console.WriteLine("2. Registrar Novo Usuário");
                Console.WriteLine("3. Efetuar Empréstimo");
                Console.WriteLine("4. Registrar Devolução");
                Console.WriteLine("5. Exibir Lista de Livros");
                Console.WriteLine("6. Relatórios de Empréstimos");
                Console.WriteLine("0. Sair do Sistema");
                Console.Write("Escolha: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Quantidade: ");
                        if (!int.TryParse(Console.ReadLine(), out int qtd))
                        {
                            Console.WriteLine("Quantidade inválida.");
                            break;
                        }
                        biblioteca.CadastrarLivro(titulo, autor, isbn, qtd);
                        break;

                    case "2":
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Matrícula: ");
                        string matricula = Console.ReadLine();
                        biblioteca.CadastrarUsuario(nome, matricula);
                        break;

                    case "3":
                        Console.Write("Matrícula do usuário: ");
                        string matEmp = Console.ReadLine();
                        Console.Write("ISBN do livro: ");
                        string isbnEmp = Console.ReadLine();
                        biblioteca.RegistrarEmprestimo(matEmp, isbnEmp);
                        break;

                    case "4":
                        Console.Write("Matrícula do usuário: ");
                        string matDev = Console.ReadLine();
                        Console.Write("ISBN do livro: ");
                        string isbnDev = Console.ReadLine();
                        biblioteca.RegistrarDevolucao(matDev, isbnDev);
                        break;

                    case "5":
                        biblioteca.ListarLivros();
                        break;

                    case "6":
                        biblioteca.ExibirRelatorios();
                        break;

                    case "0":
                        rodando = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}