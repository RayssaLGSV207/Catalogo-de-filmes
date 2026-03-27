using System;
using System.Collections.Generic;
using System.Linq; // Adicionado para usar LINQ nas estatísticas

// Classe Filme
public class Filme
{
    //Atributos
    public string Titulo;
    public int Ano;
    public string Genero;
    public int Duracao;
    public string Sinopse;
    public string Classificacao; // Classificação Indicativa
    public List<string> Plataforma; // Lista de Plataformas de Streaming

    //inicio da construção do code
    public Filme(string Titulo, int Ano, string Genero, int Duracao, string Sinopse, string Classificacao)
    {
        this.Titulo = Titulo;
        this.Ano = Ano;
        this.Genero = Genero;
        this.Duracao = Duracao;
        this.Sinopse = Sinopse;
        this.Classificacao = Classificacao;
        Plataforma = new List<string>(); // inicia com a lista vazia
    }

    // Metodo do Objeto
    public void ExibirInformacao()
    {
        // Cabeçalho
        Console.WriteLine("╔════════════════════════════════╗");
        Console.WriteLine($"║ {Titulo.ToUpper()} ║");
        Console.WriteLine("╚════════════════════════════════╝");

        // Informações Basicas do filme
        Console.WriteLine($"📅 Ano de Lançamento: {Ano}");
        Console.WriteLine($"🎭 Genero: {Genero}");
        Console.WriteLine($"⏱️ Duração: {Duracao} minutos");
        Console.WriteLine($"🔞 Classificação Indicativa: {Classificacao}");
        Console.WriteLine($"📝 Sinopse: {Sinopse}");

        // Lista de Plataformas
        Console.WriteLine($"\n📺 Plataformas de Streaming:");
        if (Plataforma.Count > 0)
        {
            for (int i = 0; i < Plataforma.Count; i++)
            {
                Console.WriteLine($"   {i + 1}. {Plataforma[i]}");
            }
        }
        else
        {
            Console.WriteLine("   Nenhuma Plataforma Cadastrada");
        }
        Console.WriteLine("\n" + new string('—', 40) + "\n");
    }

    public void AdicionarPlataforma(string plataforma)
    {
        if (!string.IsNullOrWhiteSpace(plataforma))
        {
            Plataforma.Add(plataforma);
            Console.WriteLine($" Plataforma '{plataforma}' adicionada ao filme {Titulo}");
        }
    }
}

// Classe para gerenciar o catálogo
public class Catalogo
{
    private List<Filme> filmes;

    public Catalogo()
    {
        filmes = new List<Filme>();
    }

    // Método para adicionar um novo filme
    public void AdicionarFilme(Filme filme)
    {
        filmes.Add(filme);
        Console.WriteLine($"\n Filme '{filme.Titulo}' adicionado com sucesso!");
    }

    // Método para obter todos os filmes
    public List<Filme> ObterTodosFilmes()
    {
        return filmes;
    }

    // Método para obter o total de filmes
    public int ObterTotalFilmes()
    {
        return filmes.Count;
    }

    // Método para obter todas as plataformas únicas
    public List<string> ObterPlataformasUnicas()
    {
        // Usando LINQ para coletar todas as plataformas e remover duplicatas
        var plataformasUnicas = new HashSet<string>();
        
        foreach (var filme in filmes)
        {
            foreach (var plataforma in filme.Plataforma)
            {
                plataformasUnicas.Add(plataforma);
            }
        }
        
        return plataformasUnicas.ToList();
    }

    // Método para exibir estatísticas
    public void ExibirEstatisticas()
    {
        Console.WriteLine("\n📊 ESTATÍSTICAS DO CATÁLOGO:");
        Console.WriteLine($"🎬 Total de filmes: {ObterTotalFilmes()}");
        
        var plataformasUnicas = ObterPlataformasUnicas();
        if (plataformasUnicas.Count > 0)
        {
            Console.WriteLine($"📺 Plataformas disponíveis: {string.Join(", ", plataformasUnicas)}");
            Console.WriteLine($"   Total de plataformas: {plataformasUnicas.Count}");
        }
        else
        {
            Console.WriteLine("📺 Nenhuma plataforma cadastrada ainda.");
        }
        
        // Estatística adicional: filmes por gênero
        Console.WriteLine($"\n🎭 Filmes por gênero:");
        var generosAgrupados = filmes.GroupBy(f => f.Genero);
        foreach (var grupo in generosAgrupados)
        {
            Console.WriteLine($"   • {grupo.Key}: {grupo.Count()} filme(s)");
        }
        
        // Estatística adicional: filmes por classificação
        Console.WriteLine($"\n🔞 Filmes por classificação indicativa:");
        var classificacoesAgrupadas = filmes.GroupBy(f => f.Classificacao);
        foreach (var grupo in classificacoesAgrupadas)
        {
            Console.WriteLine($"   • {grupo.Key}: {grupo.Count()} filme(s)");
        }
    }
}

// Programa principal
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(new string('═', 60));
        Console.WriteLine("🎬 SISTEMA DE CATÁLOGO DE FILMES 🎬");
        Console.WriteLine(new string('═', 60) + "\n");
        
        // Criando o catálogo
        Catalogo catalogo = new Catalogo();
        
        // INSTANCIANDO TRÊS OBJETOS DIFERENTES
        // Filme 1 - Ação/Ficção
        Filme filme1 = new Filme(
            "Matrix", 
            1999, 
            "Ação/Ficção científica", 
            136, 
            "Um programador descobre que a realidade é uma simulação e luta contra as máquinas.",
            "14 anos"
        );
        
        // Adicionando plataformas ao filme1
        filme1.AdicionarPlataforma("Netflix");
        filme1.AdicionarPlataforma("Prime Video");
        filme1.AdicionarPlataforma("HBO Max");
        
        // Adicionando filme1 ao catálogo
        catalogo.AdicionarFilme(filme1);
        
        // Filme 2 - Animação/Aventura
        Filme filme2 = new Filme(
            "Toy Story", 
            1995, 
            "Infantil/Comédia", 
            81, 
            "O aniversário do garoto Andy está chegando e seus brinquedos ficam nervosos, temendo que ele ganhe novos brinquedos que possam substituí-los. Liderados pelo caubói Woody, o brinquedo predileto de Andy, eles recebem Buzz Lightyear, o boneco de um patrulheiro espacial, que logo passa a receber mais atenção do garoto. Com ciúmes, Woody tenta ensiná-lo uma lição, mas Buzz cai pela janela. É o início da aventura do caubói, que precisa resgatar Buzz para limpar sua barra com os outros brinquedos.",
            "Livre"
        );
        
        // Adicionando plataformas ao filme2
        filme2.AdicionarPlataforma("Disney+");
        
        // Adicionando filme2 ao catálogo
        catalogo.AdicionarFilme(filme2);
        
        // Filme 3 - Drama/Crime
        Filme filme3 = new Filme(
            "O Poderoso Chefão", 
            1972, 
            "Crime/Ficção policial", 
            175, 
            "Herói de guerra e filho caçula de um poderoso chefe do crime de Nova York, Michael Corleone se envolve nos negócios da família depois que tentam assassinar seu pai.",
            "14 anos"
        );
        
        filme3.AdicionarPlataforma("Prime Video");
        filme3.AdicionarPlataforma("Paramount+");
        
        // Adicionando filme3 ao catálogo
        catalogo.AdicionarFilme(filme3);
        
        // EXECUTANDO O PROGRAMA - chamando o método para cada objeto
        Console.WriteLine("\n" + new string('═', 40));
        Console.WriteLine("📋 EXIBINDO FILMES CADASTRADOS");
        Console.WriteLine(new string('═', 40) + "\n");
        
        foreach (var filme in catalogo.ObterTodosFilmes())
        {
            filme.ExibirInformacao();
        }
        
        // EXIBINDO ESTATÍSTICAS DINÂMICAS
        catalogo.ExibirEstatisticas();
        
        // DEMONSTRAÇÃO: Adicionando um novo filme dinamicamente
        Console.WriteLine("\n" + new string('═', 40));
        Console.WriteLine("➕ DEMONSTRAÇÃO: ADICIONANDO UM NOVO FILME");
        Console.WriteLine(new string('═', 40));
        
        Filme filme4 = new Filme(
            "Interestelar",
            2014,
            "Ficção científica/Aventura",
            169,
            "Com a humanidade à beira da extinção, um grupo de astronautas viaja por um buraco de minhoca em busca de outro planeta habitável.",
            "10 anos"
        );
        
        filme4.AdicionarPlataforma("HBO Max");
        filme4.AdicionarPlataforma("Prime Video");
        filme4.AdicionarPlataforma("Mercado Livre");

        catalogo.AdicionarFilme(filme4);
        
        // Exibindo o novo filme
        Console.WriteLine("\n📋 NOVO FILME ADICIONADO:");
        filme4.ExibirInformacao();
        
        // Exibindo estatísticas atualizadas automaticamente
        Console.WriteLine("\n📊 ESTATÍSTICAS ATUALIZADAS (APÓS NOVO CADASTRO):");
        catalogo.ExibirEstatisticas();
        
        Console.WriteLine("\n✅ Programa executado com sucesso!");
    }
}