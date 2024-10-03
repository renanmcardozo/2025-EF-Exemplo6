using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using EF.Exemplo6;
using Microsoft.EntityFrameworkCore;

while (true)
{
    Console.WriteLine("======== Menu");
    Console.WriteLine("1. Cadastrar autor");
    Console.WriteLine("2. Alterar autor");
    Console.WriteLine("3. Remover autor");
    Console.WriteLine("4. Cadastrar livro");
    Console.WriteLine("5. Alterar livro");
    Console.WriteLine("6. Remover livro");
    Console.WriteLine("7. Listar autores");
    Console.WriteLine("8. Listar livros");
    Console.WriteLine("0. Sair");
    Console.Write("Digite sua opção: ");
    var opcao = Console.ReadLine().Trim();
    switch (opcao)
    {
        case "1": // Incluir autor
            OperacoesAutor.Incluir();
            break;
        case "2": // Alterar autor
            break;
        case "3": // Remover autor
            break;
        case "4": // Incluir livro
            break;
        case "5": // Alterar livro
            break;
        case "6": // Remover livro
            break;
        case "7": // Listar autores
            OperacoesAutor.Listar();
            break;
        case "8": // Listar livros
            break;
        case "0":
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
    if (opcao == "0") break;
}

Console.WriteLine("Aplicação finalizada");

public static class OperacoesAutor
{
    public static void Incluir()
    {
        using var db = new AplicacaoDbContext();
        var autor = new Autor();
        Console.Write("Nome do autor: ");
        autor.Nome = Console.ReadLine();
        Console.Write("Data de nascimento (yyyy-mm-dd): ");
        autor.DataNascimento = DateOnly.
            ParseExact(Console.ReadLine(),
                "yyyy-mm-dd", CultureInfo.InvariantCulture);

        var endereco = new Endereco();
        Console.Write("Logradouro: ");
        endereco.Logradouro = Console.ReadLine();
        Console.Write("Cidade: ");
        endereco.Cidade = Console.ReadLine();
        Console.Write("UF: ");
        endereco.UF = Console.ReadLine();
        Console.Write("CEP: ");
        endereco.CEP = Console.ReadLine();
        
        autor.Endereco = endereco;
        db.Autor.Add(autor);
        db.Endereco.Add(endereco);
        db.SaveChanges();
        Console.WriteLine("Autor adicionado!");
    }

    public static void Listar()
    {
        using var db = new AplicacaoDbContext();
        var autores = db.Autor.
            Include(p => p.Endereco);
        Console.WriteLine("Nome, DataNascimento, Endereço");
        foreach (var autor in autores)
        {
            Console.WriteLine($"{autor.Nome}, {autor.DataNascimento.ToString()}," +
                              $" {autor.Endereco.Logradouro}, {autor.Endereco.Cidade} " +
                              $"({autor.Endereco.UF}), {autor.Endereco.CEP}");
        }
    }
}