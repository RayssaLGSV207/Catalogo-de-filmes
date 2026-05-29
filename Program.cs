using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CatalogoFilmesConsole
{
    // Classe Filme
    public class Filme
    {
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public string Sinopse { get; set; }
        public string ClassificacaoIndicativa { get; set; }
        public List<string> Plataformas { get; set; }

        public Filme(string titulo, int ano, string genero, int duracao, string sinopse, string classificacao)
        {
            Titulo = titulo;
            Ano = ano;
            Genero = genero;
            Duracao = duracao;
            Sinopse = sinopse;
            ClassificacaoIndicativa = classificacao;
            Plataformas = new List<string>();
        }

        public void AdicionarPlataforma(string plataforma, string url)
        {
            Plataformas.Add($"{plataforma}|{url}");
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"{Titulo.ToUpper()} ({Ano})");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"Genero: {Genero}");
            Console.WriteLine($"Duracao: {Duracao} minutos");
            Console.WriteLine($"Classificacao: {ClassificacaoIndicativa}");
            Console.WriteLine($"Sinopse: {Sinopse}");
            Console.WriteLine($"\nOnde assistir:");
            
            if (Plataformas.Count > 0)
            {
                foreach (var plataforma in Plataformas)
                {
                    string[] partes = plataforma.Split('|');
                    string nome = partes[0];
                    string url = partes.Length > 1 ? partes[1] : "#";
                    Console.WriteLine($"   - {nome}: {url}");
                }
            }
            else
            {
                Console.WriteLine("   Nenhuma plataforma cadastrada");
            }
            Console.WriteLine(new string('=', 60) + "\n");
        }

        public void ExibirResumo(int indice)
        {
            Console.WriteLine($"[{indice}] {Titulo} ({Ano}) - {Genero}");
        }
    }

    // Classe Usuario
    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }

        public Usuario(string nome, string senha, string tipo)
        {
            Nome = nome;
            Senha = senha;
            Tipo = tipo;
        }
    }

    // Gerenciador do Catalogo
    public class CatalogoManager
    {
        private const string ARQUIVO_FILMES = "filmes.json";
        private const string ARQUIVO_USUARIOS = "usuarios.json";
        private List<Filme> filmes;
        private List<Usuario> usuarios;

        public CatalogoManager()
        {
            CarregarFilmes();
            CarregarUsuarios();
        }

        private void CarregarFilmes()
        {
            if (File.Exists(ARQUIVO_FILMES))
            {
                string json = File.ReadAllText(ARQUIVO_FILMES);
                filmes = JsonConvert.DeserializeObject<List<Filme>>(json) ?? new List<Filme>();
            }
            else
            {
                filmes = new List<Filme>();
                CarregarFilmesExemplo();
                SalvarFilmes();
            }
        }

        private void CarregarFilmesExemplo()
        {
            var filme1 = new Filme("Matrix", 1999, "Acao/Ficcao Cientifica", 136,
                "Um programador descobre que a realidade e uma simulacao e luta contra as maquinas.", "14 anos");
            filme1.AdicionarPlataforma("Netflix", "https://netflix.com/matrix");
            filme1.AdicionarPlataforma("Prime Video", "https://primevideo.com/matrix");
            filmes.Add(filme1);

            var filme2 = new Filme("Toy Story", 1995, "Animacao/Aventura", 81,
                "Brinquedos ganham vida quando os humanos nao estao por perto.", "Livre");
            filme2.AdicionarPlataforma("Disney+", "https://disneyplus.com/toystory");
            filmes.Add(filme2);

            var filme3 = new Filme("O Poderoso Chefao", 1972, "Drama/Crime", 175,
                "A historia da familia mafiosa Corleone.", "16 anos");
            filme3.AdicionarPlataforma("Prime Video", "https://primevideo.com/godfather");
            filme3.AdicionarPlataforma("Paramount+", "https://paramountplus.com/godfather");
            filmes.Add(filme3);
        }

        private void CarregarUsuarios()
        {
            if (File.Exists(ARQUIVO_USUARIOS))
            {
                string json = File.ReadAllText(ARQUIVO_USUARIOS);
                usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json) ?? new List<Usuario>();
            }
            else
            {
                usuarios = new List<Usuario>();
                usuarios.Add(new Usuario("admin", "admin123", "Admin"));
                usuarios.Add(new Usuario("visitante", "", "Comum"));
                SalvarUsuarios();
            }
        }

        private void SalvarFilmes()
        {
            string json = JsonConvert.SerializeObject(filmes, Formatting.Indented);
            File.WriteAllText(ARQUIVO_FILMES, json);
        }

        private void SalvarUsuarios()
        {
            string json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
            File.WriteAllText(ARQUIVO_USUARIOS, json);
        }

        public Usuario FazerLogin(string nome, string senha)
        {
            return usuarios.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);
        }

        public List<Filme> ObterTodosFilmes()
        {
            return filmes;
        }

        public void AdicionarFilme()
        {
            Console.Clear();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("CADASTRO DE NOVO FILME");
            Console.WriteLine(new string('=', 60));

            Console.Write("\nTitulo: ");
            string titulo = Console.ReadLine();

            Console.Write("Ano de Lancamento: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Genero: ");
            string genero = Console.ReadLine();

            Console.Write("Duracao (minutos): ");
            int duracao = int.Parse(Console.ReadLine());

            Console.Write("Sinopse: ");
            string sinopse = Console.ReadLine();

            Console.Write("Classificacao Indicativa: ");
            string classificacao = Console.ReadLine();

            Filme novoFilme = new Filme(titulo, ano, genero, duracao, sinopse, classificacao);

            Console.WriteLine("\n--- ADICIONAR PLATAFORMAS DE STREAMING ---");
            bool continuar = true;
            while (continuar)
            {
                Console.Write("Nome da Plataforma (ou 'sair' para finalizar): ");
                string nomePlataforma = Console.ReadLine();

                if (nomePlataforma.ToLower() == "sair")
                    break;

                Console.Write($"URL para assistir {titulo} no {nomePlataforma}: ");
                string urlPlataforma = Console.ReadLine();

                if (!string.IsNullOrEmpty(nomePlataforma))
                {
                    novoFilme.AdicionarPlataforma(nomePlataforma, urlPlataforma);
                }

                Console.Write("\nDeseja adicionar outra plataforma? (s/n): ");
                continuar = Console.ReadLine().ToLower() == "s";
            }

            filmes.Add(novoFilme);
            SalvarFilmes();
            Console.WriteLine("\nFilme cadastrado com sucesso!");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void RemoverFilme()
        {
            Console.Clear();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("REMOVER UM FILME");
            Console.WriteLine(new string('=', 60));

            if (filmes.Count == 0)
            {
                Console.WriteLine("\nNenhum filme cadastrado para remover.\n");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            for (int i = 0; i < filmes.Count; i++)
            {
                filmes[i].ExibirResumo(i + 1);
            }

            Console.Write("\nDigite o numero do filme que deseja remover: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= filmes.Count)
            {
                Filme removido = filmes[index - 1];
                filmes.RemoveAt(index - 1);
                SalvarFilmes();
                Console.WriteLine($"\nFilme '{removido.Titulo}' removido com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNumero invalido.");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ListarTodosFilmes()
        {
            Console.Clear();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("TODOS OS FILMES CADASTRADOS");
            Console.WriteLine(new string('=', 60));

            if (filmes.Count == 0)
            {
                Console.WriteLine("\nNenhum filme cadastrado ainda.\n");
            }
            else
            {
                foreach (var filme in filmes)
                {
                    filme.ExibirDetalhes();
                }
            }

            Console.WriteLine($"Total de filmes: {filmes.Count}");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void PesquisarFilmes()
        {
            Console.Clear();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("PESQUISAR FILMES");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine("\nPesquisar por:");
            Console.WriteLine("1 - Titulo");
            Console.WriteLine("2 - Genero");
            Console.WriteLine("3 - Ano de Lancamento");
            Console.WriteLine("4 - Classificacao Indicativa");
            Console.WriteLine("0 - Voltar");
            Console.Write("\nOpcao: ");

            string opcao = Console.ReadLine();
            List<Filme> resultados = new List<Filme>();

            switch (opcao)
            {
                case "1":
                    Console.Write("\nDigite o Titulo: ");
                    string tituloBusca = Console.ReadLine().ToLower();
                    resultados = filmes.Where(f => f.Titulo.ToLower().Contains(tituloBusca)).ToList();
                    break;
                case "2":
                    Console.Write("\nDigite o Genero: ");
                    string generoBusca = Console.ReadLine().ToLower();
                    resultados = filmes.Where(f => f.Genero.ToLower().Contains(generoBusca)).ToList();
                    break;
                case "3":
                    Console.Write("\nDigite o ano: ");
                    if (int.TryParse(Console.ReadLine(), out int anoBusca))
                        resultados = filmes.Where(f => f.Ano == anoBusca).ToList();
                    else
                        Console.WriteLine("\nAno invalido.");
                    break;
                case "4":
                    Console.Write("\nDigite a classificacao: ");
                    string classBusca = Console.ReadLine().ToLower();
                    resultados = filmes.Where(f => f.ClassificacaoIndicativa.ToLower().Contains(classBusca)).ToList();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("\nOpcao invalida!");
                    Console.ReadKey();
                    return;
            }

            ExibirResultadosPesquisa(resultados);
        }

        public void PesquisarPorPlataforma()
        {
            Console.Clear();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("PESQUISAR POR PLATAFORMA");
            Console.WriteLine(new string('=', 60));

            var plataformasDisponiveis = new HashSet<string>();
            foreach (var filme in filmes)
            {
                foreach (var plataforma in filme.Plataformas)
                {
                    string nomePlataforma = plataforma.Split('|')[0].Trim();
                    plataformasDisponiveis.Add(nomePlataforma);
                }
            }

            if (plataformasDisponiveis.Count == 0)
            {
                Console.WriteLine("\nNenhuma plataforma cadastrada ainda.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nPlataformas Disponiveis:");
            var listaPlataformas = plataformasDisponiveis.ToList();
            for (int i = 0; i < listaPlataformas.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {listaPlataformas[i]}");
            }

            Console.Write("\nDigite o numero da plataforma: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= listaPlataformas.Count)
            {
                string plataformaEscolhida = listaPlataformas[escolha - 1];
                var filmesNaPlataforma = filmes
                    .Where(f => f.Plataformas.Any(p => p.Split('|')[0] == plataformaEscolhida))
                    .ToList();

                Console.Clear();
                Console.WriteLine(new string('=', 60));
                Console.WriteLine($"FILMES DISPONIVEIS NA {plataformaEscolhida.ToUpper()}");
                Console.WriteLine(new string('=', 60));

                if (filmesNaPlataforma.Count == 0)
                {
                    Console.WriteLine($"\nNenhum filme encontrado na plataforma {plataformaEscolhida}.");
                }
                else
                {
                    foreach (var filme in filmesNaPlataforma)
                    {
                        filme.ExibirDetalhes();
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNumero invalido!");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ExibirEstatisticas()
        {
            Console.Clear();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("ESTATISTICAS DO CATALOGO");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine($"\nTotal de filmes: {filmes.Count}");

            var plataformasUnicas = filmes.SelectMany(f => f.Plataformas)
                .Select(p => p.Split('|')[0])
                .Distinct()
                .ToList();
            Console.WriteLine($"Plataformas disponiveis: {string.Join(", ", plataformasUnicas)}");
            Console.WriteLine($"Total de plataformas: {plataformasUnicas.Count}");

            Console.WriteLine("\nFilmes por genero:");
            var generosAgrupados = filmes.GroupBy(f => f.Genero);
            foreach (var grupo in generosAgrupados)
            {
                Console.WriteLine($"   - {grupo.Key}: {grupo.Count()} filme(s)");
            }

            Console.WriteLine("\nFilmes por classificacao:");
            var classificacoesAgrupadas = filmes.GroupBy(f => f.ClassificacaoIndicativa);
            foreach (var grupo in classificacoesAgrupadas)
            {
                Console.WriteLine($"   - {grupo.Key}: {grupo.Count()} filme(s)");
            }

            if (filmes.Any())
            {
                double duracaoMedia = filmes.Average(f => f.Duracao);
                Console.WriteLine($"\nDuracao media: {duracaoMedia:F0} minutos");
                
                var filmeMaisLongo = filmes.OrderByDescending(f => f.Duracao).First();
                Console.WriteLine($"Filme mais longo: {filmeMaisLongo.Titulo} ({filmeMaisLongo.Duracao} min)");
                
                var filmeMaisCurto = filmes.OrderBy(f => f.Duracao).First();
                Console.WriteLine($"Filme mais curto: {filmeMaisCurto.Titulo} ({filmeMaisCurto.Duracao} min)");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void ExibirResultadosPesquisa(List<Filme> resultados)
        {
            Console.Clear();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("RESULTADOS DA PESQUISA");
            Console.WriteLine(new string('=', 60));

            if (resultados.Count == 0)
            {
                Console.WriteLine("\nNenhum filme encontrado.\n");
            }
            else
            {
                Console.WriteLine($"\nEncontrados {resultados.Count} filme(s):\n");
                foreach (var filme in resultados)
                {
                    filme.ExibirDetalhes();
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    // Programa Principal
    class Program
    {
        static CatalogoManager manager;
        static Usuario usuarioLogado;

        static void Main(string[] args)
        {
            manager = new CatalogoManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("CATALOGO DE FILMES");
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("\nSELECIONE O PERFIL:\n");
                Console.WriteLine("1 - USUARIO (Pesquisar filmes)");
                Console.WriteLine("2 - ADMINISTRADOR (Gerenciar catalogo)");
                Console.WriteLine("3 - SAIR");
                Console.Write("\nOpcao: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MenuUsuario();
                        break;
                    case "2":
                        MenuLoginAdmin();
                        break;
                    case "3":
                        Console.WriteLine("\nPrograma encerrado!");
                        return;
                    default:
                        Console.WriteLine("\nOpcao invalida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MenuLoginAdmin()
        {
            Console.Clear();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("LOGIN ADMINISTRADOR");
            Console.WriteLine(new string('=', 60));

            Console.Write("\nUsuario: ");
            string nome = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            usuarioLogado = manager.FazerLogin(nome, senha);

            if (usuarioLogado != null && usuarioLogado.Tipo == "Admin")
            {
                Console.Clear();
                Console.WriteLine(new string('=', 60));
                Console.WriteLine($"Bem-vindo, {usuarioLogado.Nome}!");
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("\nAcesso concedido ao painel administrativo.");
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                MenuAdministrador();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("ERRO DE LOGIN");
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("\nUsuario ou senha invalidos!");
                Console.WriteLine("\nPressione qualquer tecla para tentar novamente...");
                Console.ReadKey();
            }
        }

        static void MenuUsuario()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("MENU DO USUARIO");
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("\n1 - Ver todos os filmes");
                Console.WriteLine("2 - Pesquisar filmes");
                Console.WriteLine("3 - Ver filmes por plataforma");
                Console.WriteLine("4 - Ver estatisticas");
                Console.WriteLine("0 - Voltar");
                Console.Write("\nOpcao: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        manager.ListarTodosFilmes();
                        break;
                    case "2":
                        manager.PesquisarFilmes();
                        break;
                    case "3":
                        manager.PesquisarPorPlataforma();
                        break;
                    case "4":
                        manager.ExibirEstatisticas();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("\nOpcao invalida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MenuAdministrador()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(new string('=', 60));
                Console.WriteLine($"MENU ADMINISTRADOR - Bem-vindo, {usuarioLogado.Nome}");
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("\n1 - Adicionar novo filme");
                Console.WriteLine("2 - Remover filme");
                Console.WriteLine("3 - Ver todos os filmes");
                Console.WriteLine("4 - Ver estatisticas");
                Console.WriteLine("0 - Voltar");
                Console.Write("\nOpcao: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        manager.AdicionarFilme();
                        break;
                    case "2":
                        manager.RemoverFilme();
                        break;
                    case "3":
                        manager.ListarTodosFilmes();
                        break;
                    case "4":
                        manager.ExibirEstatisticas();
                        break;
                    case "0":
                        usuarioLogado = null;
                        return;
                    default:
                        Console.WriteLine("\nOpcao invalida!");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
