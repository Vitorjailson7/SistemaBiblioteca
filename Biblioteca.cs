using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaApp.Models;

namespace BibliotecaApp.Services
{
    public class Biblioteca
    {
        public List<Livro> Livros = new List<Livro>();
        public List<Usuario> Usuarios = new List<Usuario>();
        public List<Emprestimo> Emprestimos = new List<Emprestimo>();

        public void CadastrarLivro(string titulo, string autor, string isbn, int quantidade)
        {
            Livros.Add(new Livro(titulo, autor, isbn, quantidade));
        }

        public void CadastrarUsuario(string nome, string matricula)
        {
            Usuarios.Add(new Usuario(nome, matricula));
        }

        public void RegistrarEmprestimo(string matricula, string isbn)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Matricula == matricula);
            var livro = Livros.FirstOrDefault(l => l.ISBN == isbn);

            if (usuario == null || livro == null || livro.Quantidade <= 0)
            {
                Console.WriteLine("Usuário ou livro não encontrado ou sem disponibilidade.");
                return;
            }

            if (Emprestimos.Any(e => e.Usuario.Matricula == matricula && e.Livro.ISBN == isbn && !e.Finalizado))
            {
                Console.WriteLine("Este livro já foi emprestado para este usuário.");
                return;
            }

            livro.Quantidade--;
            Emprestimos.Add(new Emprestimo(usuario, livro));
            Console.WriteLine("Empréstimo registrado.");
        }

        public void RegistrarDevolucao(string matricula, string isbn)
        {
            var emprestimo = Emprestimos.FirstOrDefault(e =>
                e.Usuario.Matricula == matricula && e.Livro.ISBN == isbn && !e.Finalizado);

            if (emprestimo != null)
            {
                emprestimo.Devolver();
                Console.WriteLine("Devolução registrada.");
            }
            else
            {
                Console.WriteLine("Empréstimo não encontrado.");
            }
        }

        public void ListarLivros()
        {
            foreach (var livro in Livros)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, ISBN: {livro.ISBN}, Disponível: {livro.Quantidade}");
            }
        }

        public void ExibirRelatorios()
        {
            Console.WriteLine("\n--- Livros Disponíveis ---");
            ListarLivros();

            Console.WriteLine("\n--- Livros Emprestados ---");
            foreach (var emp in Emprestimos.Where(e => !e.Finalizado))
            {
                Console.WriteLine($"Livro: {emp.Livro.Titulo}, Usuário: {emp.Usuario.Nome}, Data: {emp.Periodo.DataEmprestimo}");
            }

            Console.WriteLine("\n--- Usuários com Livros ---");
            foreach (var usuario in Usuarios)
            {
                var emprestimos = Emprestimos.Where(e => e.Usuario.Matricula == usuario.Matricula && !e.Finalizado);
                if (emprestimos.Any())
                {
                    Console.WriteLine($"Usuário: {usuario.Nome} ({usuario.Matricula})");
                    foreach (var emp in emprestimos)
                        Console.WriteLine($"   - {emp.Livro.Titulo}");
                }
            }
        }
    }
}

