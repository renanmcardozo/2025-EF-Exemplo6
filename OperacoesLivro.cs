using EF.Exemplo6;
using Microsoft.EntityFrameworkCore;

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