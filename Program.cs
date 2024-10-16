using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

while (true)
{
    Console.WriteLine("======== Menu");
    Console.WriteLine("11. Cadastrar autor");
    Console.WriteLine("12. Alterar autor"); // professor vai fazer
    Console.WriteLine("13. Remover autor"); // professor vai fazer
    Console.WriteLine("14. Listar autores");
    Console.WriteLine("21. Cadastrar livro");
    Console.WriteLine("22. Alterar livro");
    Console.WriteLine("23. Remover livro");
    Console.WriteLine("24. Listar livros com estoque");
    Console.WriteLine("31. Cadastrar gênero");
    Console.WriteLine("32. Alterar gênero");
    Console.WriteLine("33. Remover gênero");
    Console.WriteLine("34. Listar gêneros");
    Console.WriteLine("41. Vender livro");
    Console.WriteLine("42. Comprar livro");
    Console.WriteLine("0. Sair");
    Console.Write("Digite sua opção: ");
    var opcao = Console.ReadLine().Trim();
    switch (opcao)
    {
        case "11": // Incluir autor
            OperacoesAutor.Incluir();
            break;
        case "12": // Alterar autor
            OperacoesAutor.Alterar();
            break;
        case "13": // Remover autor
            OperacoesAutor.Remover();
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