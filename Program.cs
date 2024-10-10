using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EF.Exemplo6;
using Microsoft.EntityFrameworkCore;

while (true)
{
    Console.WriteLine("======== Menu");
    Console.WriteLine("11. Cadastrar autor");
    Console.WriteLine("12. Alterar autor");
    Console.WriteLine("13. Remover autor");
    Console.WriteLine("14. Listar autores");
    Console.WriteLine("21. Cadastrar livro");
    Console.WriteLine("22. Alterar livro");
    Console.WriteLine("23. Remover livro");
    Console.WriteLine("24. Listar livros");
    Console.WriteLine("31. Cadastrar gênero");
    Console.WriteLine("32. Alterar gênero");
    Console.WriteLine("33. Remover gênero");
    Console.WriteLine("34. Listar gêneros");
    Console.WriteLine("0. Sair");
    Console.Write("Digite sua opção: ");
    var opcao = Console.ReadLine().Trim();
    switch (opcao)
    {
        case "11": // Incluir autor
            OperacoesAutor.Incluir();
            break;
        case "12": // Alterar autor
            break;
        case "13": // Remover autor
            break;
        case "14": // Listar autores
            OperacoesAutor.Listar();
            break;
        case "21": // Incluir livro
            OperacoesLivro.Incluir();
            break;
        case "22": // Alterar livro
            break;
        case "23": // Remover livro
            break;
        case "24": // Listar livros
            OperacoesLivro.Listar();
            break;
        case "31": // Incluir gênero
            break;
        case "32": // Alterar gênero
            break;
        case "33": // Remover gênero
            break;
        case "34": // Listar gêneros
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


public static class OperacoesLivro
{
    public static void Incluir()
    {
        using var db = new AplicacaoDbContext();
        var livro = new Livro();
        Console.WriteLine("ISBN do livro: ");
        livro.ISBN = Console.ReadLine();
        Console.WriteLine("Título do livro: ");
        livro.Titulo = Console.ReadLine();
        Console.WriteLine("Número de páginas (opcional): ");
        var tmp = Console.ReadLine().Trim();
        if (tmp != "")
            livro.Paginas = Convert.ToInt32(tmp);
        Console.WriteLine("Escolha o autor: ");
        OperacoesAutor.ListarComChave();
        var autorid = Convert.ToInt32(Console.ReadLine());
        var autor = db.Autor.First(p => p.AutorID == autorid);
        livro.Autor = autor;
        db.Livro.Add(livro);
        db.SaveChanges();
    }

    public static void Listar()
    {
        var db = new AplicacaoDbContext();
        var livros = db.Livro
            .Include(p => p.Autor)
            .ThenInclude(p => p.Endereco);
        Console.WriteLine("ISBN, Titulo, Paginas, Autor, UFdoAutor");
        foreach (var livro in livros)
        {
            Console.WriteLine($"{livro.ISBN}, {livro.Titulo}, " +
                              $"{livro.Paginas}, {livro.Autor.Nome}, " +
                              $"{livro.Autor.Endereco.UF}");
        }
    }
}
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
    public static void ListarComChave()
    {
        using var db = new AplicacaoDbContext();
        var autores = db.Autor.
            Include(p => p.Endereco);
        Console.WriteLine("ID, Nome");
        foreach (var autor in autores)
        {
            Console.WriteLine($"{autor.AutorID}, {autor.Nome}");
        }
    }

}