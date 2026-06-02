using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CatalogoFilmesConsole
{
    // Classe Filme - Selada pois representa apenas uma entidade de dados final
    public sealed class Filme
    {
        // Encapsulamento: Setters privados ou init para garantir imutabilidade onde faz sentido
        public string Titulo { get; private set; }
        public int Ano { get; init; }
        public string Genero { get; private set; }
        public int Duracao { get; init; }
        public string Sinopse { get; private set; }
        public string ClassificacaoIndicativa { get; private set; }
        public List<string> Plataformas { get; private set; }

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
            if (!string.IsNullOrWhiteSpace(plataforma))
            {
                Plataformas.Add($"{plataforma.Trim()}|{(string.IsNullOrWhiteSpace(url) ? "#" : url.Trim())}");
            }
        }

        public void ExibirDetalhes()
        {
            ConsoleHelper.ExibirDivisor('=', 60);
            Console.WriteLine($"{Titulo.ToUpper()} ({Ano})");
            ConsoleHelper.ExibirDivisor('-', 60);
            Console.WriteLine($"Gênero: {Genero}");
            Console.WriteLine($"Duração: {Duracao} minutos");
            Console.WriteLine($"Classificação: {ClassificacaoIndicativa}");
            Console.WriteLine($"Sinopse: {Sinopse}");
            Console.WriteLine("\nOnde assistir:");
            
            if (Plataformas.Count > 0)
            {
                foreach (var plataforma in Plataformas)
                {
                    string[] partes = plataforma.Split('|');
                    Console.WriteLine($"   - {partes[0]}: {partes[1]}");
                }
            }
            else
            {
                Console.WriteLine("   Nenhuma plataforma cadastrada");
            }
            ConsoleHelper.ExibirDivisor('=', 60);
            Console.WriteLine();
        }

        // C# Moderno: Expression-bodied member
        public void ExibirResumo(int indice) => 
            Console.WriteLine($"[{indice}] {Titulo} ({Ano}) - {Genero}");
    }

    // Classe Usuario - Selada para segurança e performance
    public sealed class Usuario
    {
        public string Nome { get; init; }
        public string Senha { get; init; }
        public string Tipo { get; init; }

        public Usuario(string nome, string senha, string tipo)
        {
            Nome = nome;
            Senha = senha;
            Tipo = tipo;
        }
    }

    // ConsoleHelper: Classe estática aplicando DRY para centralizar formatações de tela repetitivas
    public static class ConsoleHelper
    {
        public static void ExibirDivisor(char caractere, int tamanho) => 
            Console.WriteLine(new string(caractere, tamanho));

        public static void ConfigurarTela(string titulo)
        {
            Console.Clear();
            ExibirDivisor('=', 60);
            Console.WriteLine(titulo.ToUpper());
            ExibirDivisor('=', 60);
        }

        public static void AguardarTecla()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public static void MostrarErro(string mensagem)
        {
            Console.WriteLine($"\n[ERRO] {mensagem}");
            AguardarTecla();
        }
    }

    // Gerenciador do Catálogo - Selado
    public sealed class CatalogoManager
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
            var filme1 = new Filme("Matrix", 1999, "Ação/Ficção Científica", 136, "Um programador descobre que a realidade é uma simulação...", "14 anos");
            filme1.AdicionarPlataforma("Netflix", "https://netflix.com/matrix");
            filme1.AdicionarPlataforma("Prime Video", "https://primevideo.com/matrix");
            filmes.Add(filme1);

            var filme2 = new Filme("Toy Story", 1995, "Animação/Aventura", 81, "Brinquedos ganham vida quando os humanos não estão por perto.", "Livre");
            filme2.AdicionarPlataforma("Disney+", "https://disneyplus.com/toystory");
            filmes.Add(filme2);
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
                usuarios = new List<Usuario>
                {
                    new Usuario("admin", "admin123", "Admin"),
                    new Usuario("visitante", "", "Comum")
                };
                SalvarUsuarios();
            }
        }

        private void SalvarFilmes() => File.WriteAllText(ARQUIVO_FILMES, JsonConvert.SerializeObject(filmes, Formatting.Indented));
        private void SalvarUsuarios() => File.WriteAllText(ARQUIVO_USUARIOS, JsonConvert.SerializeObject(usuarios, Formatting.Indented));

        public Usuario FazerLogin(string nome, string senha) => 
            usuarios.FirstOrDefault(u => u.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase) && u.Senha == senha);

        public void AdicionarFilme()
        {
            ConsoleHelper.ConfigurarTela("Cadastro de Novo Filme");

            Console.Write("\nTítulo: ");
            string titulo = Console.ReadLine();

            // Proteção contra entradas inválidas (Evita que o programa quebre)
            int ano;
            while (!int.TryParse(ObterEntradaObrigatoria("Ano de Lançamento: "), out ano)) 
                Console.WriteLine("Por favor, digite um ano válido.");

            Console.Write("Gênero: ");
            string genero = Console.ReadLine();

            int duracao;
            while (!int.TryParse(ObterEntradaObrigatoria("Duração (minutos): "), out duracao)) 
                Console.WriteLine("Por favor, digite uma duração válida.");

            Console.Write("Sinopse: ");
            string sinopse = Console.ReadLine();

            Console.Write("Classificação Indicativa: ");
            string classificacao = Console.ReadLine();

            Filme novoFilme = new Filme(titulo, ano, genero, duracao, sinopse, classificacao);

            Console.WriteLine("\n--- ADICIONAR PLATAFORMAS DE STREAMING ---");
            while (true)
            {
                Console.Write("Nome da Plataforma (ou 'sair' para finalizar): ");
                string nomePlataforma = Console.ReadLine();

                if (nomePlataforma?.ToLower() == "sair") break;

                Console.Write($"URL para assistir {titulo} no {nomePlataforma}: ");
                string urlPlataforma = Console.ReadLine();

                novoFilme.AdicionarPlataforma(nomePlataforma, urlPlataforma);
                Console.WriteLine("Plataforma adicionada!");
            }

            filmes.Add(novoFilme);
            SalvarFilmes();
            Console.WriteLine("\nFilme cadastrado com sucesso!");
            ConsoleHelper.AguardarTecla();
        }

        private string ObterEntradaObrigatoria(string texto)
        {
            Console.Write(texto);
            return Console.ReadLine();
        }

        public void RemoverFilme()
        {
            ConsoleHelper.ConfigurarTela("Remover um Filme");

            if (!filmes.Any())
            {
                ConsoleHelper.MostrarErro("Nenhum filme cadastrado para remover.");
                return;
            }

            Console.WriteLine();
            for (int i = 0; i < filmes.Count; i++)
            {
                filmes[i].ExibirResumo(i + 1);
            }

            Console.Write("\nDigite o número do filme que deseja remover: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= filmes.Count)
            {
                Filme removido = filmes[index - 1];
                filmes.RemoveAt(index - 1);
                SalvarFilmes();
                Console.WriteLine($"\nFilme '{removido.Titulo}' removido com sucesso!");
            }
            else
            {
                ConsoleHelper.MostrarErro("Número inválido.");
                return;
            }

            ConsoleHelper.AguardarTecla();
        }

        public void ListarTodosFilmes()
        {
            ConsoleHelper.ConfigurarTela("Todos os Filmes Cadastrados");

            if (!filmes.Any())
            {
                Console.WriteLine("\nNenhum filme cadastrado ainda.\n");
            }
            else
            {
                filmes.ForEach(f => f.ExibirDetalhes());
            }

            Console.WriteLine($"Total de filmes: {filmes.Count}");
            ConsoleHelper.AguardarTecla();
        }

        public void PesquisarFilmes()
        {
            ConsoleHelper.ConfigurarTela("Pesquisar Filmes");

            Console.WriteLine("\nPesquisar por:");
            Console.WriteLine("1 - Título\n2 - Gênero\n3 - Ano de Lançamento\n4 - Classificação Indicativa\n0 - Voltar");
            Console.Write("\nOpção: ");

            string opcao = Console.ReadLine();
            List<Filme> resultados = string.Empty switch
            {
                _ when opcao == "1" => BuscarPorTexto("Título", f => f.Titulo),
                _ when opcao == "2" => BuscarPorTexto("Gênero", f => f.Genero),
                _ when opcao == "3" => BuscarPorAno(),
                _ when opcao == "4" => BuscarPorTexto("Classificação", f => f.ClassificacaoIndicativa),
                _ => null
            };

            if (opcao == "0") return;
            if (resultados == null) { ConsoleHelper.MostrarErro("Opção inválida!"); return; }

            ExibirResultadosPesquisa(resultados);
        }

        private List<Filme> BuscarPorTexto(string campo, Func<Filme, string> seletor)
        {
            Console.Write($"\nDigite o {campo}: ");
            string busca = Console.ReadLine()?.ToLower() ?? "";
            return filmes.Where(f => seletor(f).ToLower().Contains(busca)).ToList();
        }

        private List<Filme> BuscarPorAno()
        {
            Console.Write("\nDigite o ano: ");
            if (int.TryParse(Console.ReadLine(), out int anoBusca))
                return filmes.Where(f => f.Ano == anoBusca).ToList();
            
            Console.WriteLine("\nAno inválido.");
            return new List<Filme>();
        }

        public void PesquisarPorPlataforma()
        {
            ConsoleHelper.ConfigurarTela("Pesquisar por Plataforma");

            var plataformasDisponiveis = filmes.SelectMany(f => f.Plataformas)
                                               .Select(p => p.Split('|')[0].Trim())
                                               .Distinct()
                                               .ToList();

            if (!plataformasDisponiveis.Any())
            {
                ConsoleHelper.MostrarErro("Nenhuma plataforma cadastrada ainda.");
                return;
            }

            Console.WriteLine("\nPlataformas Disponíveis:");
            for (int i = 0; i < plataformasDisponiveis.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {plataformasDisponiveis[i]}");
            }

            Console.Write("\nDigite o número da plataforma: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= plataformasDisponiveis.Count)
            {
                string plataformaEscolhida = plataformasDisponiveis[escolha - 1];
                var filmesNaPlataforma = filmes.Where(f => f.Plataformas.Any(p => p.Split('|')[0] == plataformaEscolhida)).ToList();

                ConsoleHelper.ConfigurarTela($"Filmes disponíveis na {plataformaEscolhida}");
                filmesNaPlataforma.ForEach(f => f.ExibirDetalhes());
            }
            else
            {
                ConsoleHelper.MostrarErro("Número inválido!");
                return;
            }

            ConsoleHelper.AguardarTecla();
        }

        public void ExibirEstatisticas()
        {
            ConsoleHelper.ConfigurarTela("Estatísticas do Catálogo");

            Console.WriteLine($"\nTotal de filmes: {filmes.Count}");

            var plataformasUnicas = filmes.SelectMany(f => f.Plataformas).Select(p => p.Split('|')[0]).Distinct().ToList();
            Console.WriteLine($"Plataformas disponíveis: {string.Join(", ", plataformasUnicas)}");
            Console.WriteLine($"Total de plataformas: {plataformasUnicas.Count}");

            ExibirAgrupamento("Filmes por gênero:", f => f.Genero);
            ExibirAgrupamento("Filmes por classificação:", f => f.ClassificacaoIndicativa);

            if (filmes.Any())
            {
                Console.WriteLine($"\nDuração média: {filmes.Average(f => f.Duracao):F0} minutos");
                Console.WriteLine($"Filme mais longo: {filmes.OrderByDescending(f => f.Duracao).First().Titulo}");
                Console.WriteLine($"Filme mais curto: {filmes.OrderBy(f => f.Duracao).First().Titulo}");
            }

            ConsoleHelper.AguardarTecla();
        }

        private void ExibirAgrupamento(string titulo, Func<Filme, string> propriedade)
        {
            Console.WriteLine($"\n{titulo}");
            var agrupado = filmes.GroupBy(propriedade);
            foreach (var grupo in agrupado)
            {
                Console.WriteLine($"   - {grupo.Key}: {grupo.Count()} filme(s)");
            }
        }

        private void ExibirResultadosPesquisa(List<Filme> resultados)
        {
            ConsoleHelper.ConfigurarTela("Resultados da Pesquisa");
            if (!resultados.Any())
            {
                Console.WriteLine("\nNenhum filme encontrado.\n");
            }
            else
            {
                Console.WriteLine($"\nEncontrados {resultados.Count} filme(s):\n");
                resultados.ForEach(f => f.ExibirDetalhes());
            }
            ConsoleHelper.AguardarTecla();
        }
    }

    // Programa Principal
    class Program
    {
        private static CatalogoManager manager;
        private static Usuario usuarioLogado;

        static void Main(string[] args)
        {
            manager = new CatalogoManager();

            while (true)
            {
                ConsoleHelper.ConfigurarTela("Catálogo de Filmes");
                Console.WriteLine("\nSELECIONE O PERFIL:\n");
                Console.WriteLine("1 - USUÁRIO (Pesquisar filmes)\n2 - ADMINISTRADOR (Gerenciar catálogo)\n3 - SAIR");
                Console.Write("\nOpção: ");

                switch (Console.ReadLine())
                {
                    case "1": MenuUsuario(); break;
                    case "2": MenuLoginAdmin(); break;
                    case "3": Console.WriteLine("\nPrograma encerrado!"); return;
                    default: ConsoleHelper.MostrarErro("Opção inválida!"); break;
                }
            }
        }

        static void MenuLoginAdmin()
        {
            ConsoleHelper.ConfigurarTela("Login Administrador");

            Console.Write("\nUsuário: ");
            string nome = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            usuarioLogado = manager.FazerLogin(nome, senha);

            if (usuarioLogado?.Tipo == "Admin")
            {
                ConsoleHelper.ConfigurarTela($"Bem-vindo, {usuarioLogado.Nome}!");
                Console.WriteLine("\nAcesso concedido ao painel administrativo.");
                ConsoleHelper.AguardarTecla();
                MenuAdministrador();
            }
            else
            {
                ConsoleHelper.MostrarErro("Usuário ou senha inválidos!");
            }
        }

        static void MenuUsuario()
        {
            while (true)
            {
                ConsoleHelper.ConfigurarTela("Menu do Usuário");
                Console.WriteLine("\n1 - Ver todos os filmes\n2 - Pesquisar filmes\n3 - Ver filmes por plataforma\n4 - Ver estatísticas\n0 - Voltar");
                Console.Write("\nOpção: ");

                switch (Console.ReadLine())
                {
                    case "1": manager.ListarTodosFilmes(); break;
                    case "2": manager.PesquisarFilmes(); break;
                    case "3": manager.PesquisarPorPlataforma(); break;
                    case "4": manager.ExibirEstatisticas(); break;
                    case "0": return;
                    default: ConsoleHelper.MostrarErro("Opção inválida!"); break;
                }
            }
        }

        static void MenuAdministrador()
        {
            while (true)
            {
                ConsoleHelper.ConfigurarTela($"Menu Administrador - {usuarioLogado.Nome}");
                Console.WriteLine("\n1 - Adicionar novo filme\n2 - Remover filme\n3 - Ver todos os filmes\n4 - Ver estatísticas\n0 - Voltar");
                Console.Write("\nOpção: ");

                switch (Console.ReadLine())
                {
                    case "1": manager.AdicionarFilme(); break;
                    case "2": manager.RemoverFilme(); break;
                    case "3": manager.ListarTodosFilmes(); break;
                    case "4": manager.ExibirEstatisticas(); break;
                    case "0": usuarioLogado = null; return;
                    default: ConsoleHelper.MostrarErro("Opção inválida!"); break;
                }
            }
        }
    }
}