# 🎬 Catálogo de Filmes

Sistema console completo em C# para gerenciar um catálogo de filmes com persistência em JSON, suporte a múltiplas plataformas de streaming, pesquisa avançada, estatísticas detalhadas e **sistema completo de login com perfis diferenciados**.

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Arquitetura e Design Patterns](#arquitetura-e-design-patterns)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Como Executar](#como-executar)
- [Credenciais de Acesso](#credenciais-de-acesso)
- [Funcionalidades Detalhadas](#funcionalidades-detalhadas)
- [Exemplo de Saída](#exemplo-de-saída)
- [Estrutura JSON](#estrutura-json)
- [Diagrama de Classes](#diagrama-de-classes)
- [Conceitos Demonstrados](#conceitos-demonstrados)
- [Licença](#licença)

---

## 🎯 Sobre o Projeto

O **Catálogo de Filmes** é uma aplicação console robusta que demonstra conceitos avançados de Programação Orientada a Objetos (POO) em C#, com persistência de dados em JSON e sistema de login diferenciado. O sistema permite:

- Gerenciar filmes com informações completas (título, ano, gênero, duração, sinopse, classificação)
- Adicionar múltiplas plataformas de streaming com URLs específicas
- Persistência automática em arquivos JSON
- Pesquisa avançada por título, gênero, ano, classificação e plataforma
- Estatísticas detalhadas do catálogo (média, filmes mais longos/curtos, agrupamentos)
- **Sistema de autenticação com perfis de usuário e administrador**
- **Tratamento robusto de erros e validação de entradas**

### Objetivos Educacionais
Este projeto demonstra:
- ✅ Classes, objetos e construtores
- ✅ **Encapsulamento e imutabilidade** (propriedades com `private set` e `init`)
- ✅ **Classes seladas (`sealed`)** para segurança e performance
- ✅ Coleções genéricas (`List`, `HashSet`)
- ✅ **LINQ avançado** (`GroupBy`, `Where`, `Select`, `Average`, `First`, `OrderBy`)
- ✅ Persistência com JSON (`Newtonsoft.Json`)
- ✅ **Sistema de autenticação** com dois perfis
- ✅ **Tratamento de exceções e validação de dados**
- ✅ **DRY (Don't Repeat Yourself)** com `ConsoleHelper`
- ✅ **Expression-bodied members** (C# moderno)

---

## ✨ Funcionalidades

### 👤 Usuário Comum (acesso público)
- **Ver todos os filmes**: Listagem completa com detalhes
- **Pesquisar filmes**: Por título, gênero, ano ou classificação indicativa
- **Buscar por plataforma**: Ver todos os filmes disponíveis em uma plataforma específica
- **Estatísticas**: Visualizar dados agregados do catálogo

### 👑 Administrador (login necessário)
- **Todas as funcionalidades do usuário comum**
- **Adicionar filmes**: Cadastro completo com plataformas e URLs
- **Remover filmes**: Exclusão por seleção numérica
- **Persistência automática**: Dados salvos em JSON em tempo real
- **Gestão completa**: CRUD de filmes

### 📊 Funcionalidades Técnicas
- **Persistência em JSON**: Dados salvos em arquivos separados (`filmes.json`, `usuarios.json`)
- **Atualização em tempo real**: Estatísticas recalculadas automaticamente
- **Interface visual**: Formatação com linhas e organização clara
- **Validações robustas**: Tratamento de entradas inválidas, prevenção de quebras
- **Sistema de navegação**: Menus intuitivos com opção de retorno

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Versão | Finalidade |
|------------|--------|------------|
| **.NET** | 10.0+ | Framework de desenvolvimento |
| **C#** | 10.0+ | Linguagem de programação |
| **Newtonsoft.Json** | 13.0.4 | Serialização/Deserialização JSON |
| **LINQ** | - | Consultas avançadas em coleções |

### Package Instalado
```bash
dotnet add package Newtonsoft.Json
```

---

## 🏗️ Arquitetura e Design Patterns

### Padrões Utilizados

| Padrão | Implementação |
|--------|--------------|
| **Singleton** | `ConsoleHelper` (classe estática) |
| **Factory Method** | Construção de objetos `Filme` e `Usuario` |
| **Repository** | `CatalogoManager` gerencia acesso a dados |
| **MVC-like** | Separação entre modelo (`Filme`), controle (`CatalogoManager`) e visão (`Program`) |

### Boas Práticas Aplicadas

1. **Encapsulamento rigoroso**: Propriedades com `private set` ou `init`
2. **Classes seladas (`sealed`)**: Impede herança desnecessária e melhora performance
3. **DRY (Don't Repeat Yourself)**: `ConsoleHelper` centraliza formatações repetitivas
4. **C# Moderno**: Expression-bodied members, switch expressions, nullable reference types
5. **Tratamento de erros**: Validação em todas as entradas do usuário
6. **Nomes significativos**: Métodos e variáveis auto-descritivos

---

## 📁 Estrutura do Projeto

```
CatalogoFilmesFinal/
│
├── Program.cs                 # Código fonte principal (contém todas as classes)
├── CatalogoFilmesFinal.csproj # Arquivo de projeto
├── filmes.json                # Banco de dados de filmes (criado automaticamente na 1ª execução)
├── usuarios.json              # Banco de dados de usuários (criado automaticamente na 1ª execução)
│
└── README.md                  # Documentação
```

### Classes do Sistema

| Classe | Responsabilidade | Modificador |
|--------|------------------|-------------|
| **Filme** | Modelo de dados do filme | `sealed` |
| **Usuario** | Modelo de dados do usuário | `sealed` |
| **ConsoleHelper** | Utilitários de interface | `static` |
| **CatalogoManager** | Gerencia operações do catálogo | `sealed` |
| **Program** | Interface e fluxo principal | - |

---

## 🚀 Como Executar

### Pré-requisitos
- [.NET SDK 8.0 ou superior](https://dotnet.microsoft.com/download)
- Visual Studio Code (recomendado), Visual Studio 2022+ ou qualquer editor de código

### Passo a Passo

#### 1. Criar um novo projeto
```bash
dotnet new console -n CatalogoFilmesFinal
cd CatalogoFilmesFinal
```

#### 2. Adicionar o pacote Newtonsoft.Json
```bash
dotnet add package Newtonsoft.Json
```

#### 3. Substituir o conteúdo do arquivo Program.cs
Copie o código fonte fornecido e cole no arquivo `Program.cs`

#### 4. Executar o projeto
```bash
dotnet run
```

### Estrutura do csproj
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="13.0.4" />
  </ItemGroup>
</Project>
```

---

## 🔐 Credenciais de Acesso

| Perfil | Usuário | Senha | Acesso |
|--------|---------|-------|--------|
| **Administrador** | `admin` | `admin123` | Total (CRUD completo) |
| **Usuário Comum** | `visitante` | (vazio - apenas Enter) | Apenas leitura |

> ⚠️ **Importante**: O usuário `visitante` não precisa digitar senha, apenas pressionar Enter.

---

## 📖 Funcionalidades Detalhadas

### Menu Principal
```
════════════════════════════════════════════════════════════
CATALOGO DE FILMES
════════════════════════════════════════════════════════════

SELECIONE O PERFIL:

1 - USUARIO (Pesquisar filmes)
2 - ADMINISTRADOR (Gerenciar catalogo)
3 - SAIR

Opção: _
```

### Menu do Usuário Comum
| Opção | Funcionalidade | Descrição |
|-------|----------------|-----------|
| 1 | Ver todos os filmes | Listagem detalhada com sinopse e links |
| 2 | Pesquisar filmes | Busca por título, gênero, ano ou classificação |
| 3 | Ver filmes por plataforma | Seleciona streaming e lista filmes disponíveis |
| 4 | Ver estatísticas | Médias, totais, agrupamentos |
| 0 | Voltar | Retorna ao menu principal |

### Menu do Administrador
| Opção | Funcionalidade | Descrição |
|-------|----------------|-----------|
| 1 | Adicionar novo filme | Cadastro completo com plataformas/URLs |
| 2 | Remover filme | Seleção numérica para exclusão |
| 3 | Ver todos os filmes | Mesma listagem do usuário |
| 4 | Ver estatísticas | Análise detalhada do catálogo |
| 0 | Voltar | Retorna ao menu principal |

### Pesquisa Avançada
- **Por título**: Busca parcial (case insensitive) - ex: "matrix" encontra "Matrix"
- **Por gênero**: Filtra por categoria - ex: "Acao", "Drama", "Animacao"
- **Por ano**: Filmes de um ano específico - ex: 1994
- **Por classificação**: Livre, 12 anos, 14 anos, 16 anos, 18 anos

### Busca por Plataforma
1. Sistema extrai todas as plataformas únicas do catálogo
2. Exibe lista numerada para seleção
3. Usuário escolhe uma plataforma
4. Mostra todos os filmes com links diretos para assistir

### Estatísticas Geradas
- **Total de filmes**: Quantidade no catálogo
- **Plataformas disponíveis**: Lista única de streamings
- **Filmes por gênero**: Agrupamento com contagem
- **Filmes por classificação**: Agrupamento com contagem
- **Duração média**: Média aritmética em minutos
- **Filme mais longo**: Título e duração
- **Filme mais curto**: Título e duração

---

## 📺 Exemplo de Saída

### Listagem de Filmes
```
============================================================
TODOS OS FILMES CADASTRADOS
============================================================

============================================================
MATRIX (1999)
------------------------------------------------------------
Gênero: Acao/Ficcao Cientifica
Duração: 136 minutos
Classificação: 14 anos
Sinopse: Um programador descobre que a realidade e uma simulacao e luta contra as maquinas.

Onde assistir:
   - Netflix: https://www.netflix.com/br/title/20557937
   - Prime Video: https://www.primevideo.com/dp/amzn1.dv...
   - HBO Max: https://www.hbomax.com/br/pt/movies/matrix
============================================================

Total de filmes: 20
```

### Estatísticas do Catálogo
```
============================================================
ESTATISTICAS DO CATALOGO
============================================================

Total de filmes: 20
Plataformas disponíveis: Netflix, Prime Video, Disney+, HBO Max, Paramount+, Globoplay, Apple TV
Total de plataformas: 7

Filmes por gênero:
   - Acao/Ficcao Cientifica: 2 filme(s)
   - Animacao/Aventura: 2 filme(s)
   - Drama/Crime: 2 filme(s)
   - Ficcao Cientifica/Suspense: 1 filme(s)
   - Acao/Crime: 1 filme(s)
   - Drama/Suspense: 2 filme(s)
   - Drama/Musical: 1 filme(s)
   - Animacao/Acao: 1 filme(s)
   - Ficcao Cientifica/Aventura: 2 filme(s)
   - Acao/Drama: 1 filme(s)
   - Drama/Comedia: 1 filme(s)
   - Crime/Drama: 2 filme(s)
   - Terror/Suspense: 2 filme(s)
   - Musical/Romance: 1 filme(s)
   - Acao/Aventura: 1 filme(s)

Filmes por classificação:
   - 14 anos: 1 filme(s)
   - Livre: 1 filme(s)

Duração média: 139 minutos
Filme mais longo: O Poderoso Chefao
Filme mais curto: Toy Story
```

---

## 📦 Estrutura JSON

### filmes.json (formato completo)
```json
[
  {
    "Titulo": "Matrix",
    "Ano": 1999,
    "Genero": "Acao/Ficcao Cientifica",
    "Duracao": 136,
    "Sinopse": "Um programador descobre que a realidade e uma simulacao e luta contra as maquinas.",
    "ClassificacaoIndicativa": "14 anos",
    "Plataformas": [
      "Netflix|https://www.netflix.com/br/title/20557937",
      "Prime Video|https://www.primevideo.com/dp/amzn1.dv.gti.dea9f6b7-e0a0-38c9-7467-d6079c6fb4f0"
    ]
  }
]
```

### usuarios.json (credenciais)
```json
[
  {
    "Nome": "admin",
    "Senha": "admin123",
    "Tipo": "Admin"
  },
  {
    "Nome": "visitante",
    "Senha": "",
    "Tipo": "Comum"
  }
]
```

---

## 📊 Diagrama de Classes

```
┌──────────────────────────────────────────────────────────┐
│                      Filme (sealed)                       │
├──────────────────────────────────────────────────────────┤
│ - Titulo: string {private set}                          │
│ - Ano: int {init}                                        │
│ - Genero: string {private set}                          │
│ - Duracao: int {init}                                   │
│ - Sinopse: string {private set}                         │
│ - ClassificacaoIndicativa: string {private set}         │
│ - Plataformas: List<string> {private set}               │
├──────────────────────────────────────────────────────────┤
│ + Filme(titulo, ano, genero, duracao, sinopse, class)   │
│ + AdicionarPlataforma(plataforma, url)                  │
│ + ExibirDetalhes()                                      │
│ + ExibirResumo(indice)                                  │
└──────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────┐
│                    Usuario (sealed)                       │
├──────────────────────────────────────────────────────────┤
│ + Nome: string {init}                                    │
│ + Senha: string {init}                                   │
│ + Tipo: string {init}                                    │
├──────────────────────────────────────────────────────────┤
│ + Usuario(nome, senha, tipo)                            │
└──────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────┐
│                ConsoleHelper (static)                     │
├──────────────────────────────────────────────────────────┤
│ + ExibirDivisor(char, tamanho)                          │
│ + ConfigurarTela(titulo)                                │
│ + AguardarTecla()                                       │
│ + MostrarErro(mensagem)                                 │
└──────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────┐
│              CatalogoManager (sealed)                     │
├──────────────────────────────────────────────────────────┤
│ - filmes: List<Filme>                                    │
│ - usuarios: List<Usuario>                                │
│ - ARQUIVO_FILMES: const string                           │
│ - ARQUIVO_USUARIOS: const string                         │
├──────────────────────────────────────────────────────────┤
│ + CatalogoManager()                                      │
│ + FazerLogin(nome, senha): Usuario                      │
│ + AdicionarFilme()                                       │
│ + RemoverFilme()                                         │
│ + ListarTodosFilmes()                                    │
│ + PesquisarFilmes()                                      │
│ + PesquisarPorPlataforma()                               │
│ + ExibirEstatisticas()                                   │
└──────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────┐
│                      Program                              │
├──────────────────────────────────────────────────────────┤
│ - manager: CatalogoManager (static)                      │
│ - usuarioLogado: Usuario (static)                        │
├──────────────────────────────────────────────────────────┤
│ + Main()                                                 │
│ + MenuUsuario()                                          │
│ + MenuLoginAdmin()                                       │
│ + MenuAdministrador()                                    │
└──────────────────────────────────────────────────────────┘
```

---

## 📚 Conceitos Demonstrados

### 1. Programação Orientada a Objetos
| Conceito | Implementação |
|----------|--------------|
| **Classe** | `Filme`, `Usuario`, `CatalogoManager` |
| **Objeto** | Instâncias criadas e manipuladas |
| **Encapsulamento** | Propriedades `private set` / `init`, métodos públicos |
| **Abstração** | Modelagem de entidades reais (filme, usuário) |
| **Construtor** | Inicialização controlada de objetos |
| **Classe selada** | `sealed` impede herança e otimiza performance |
| **Classe estática** | `ConsoleHelper` para métodos utilitários |

### 2. LINQ em Ação
```csharp
// Busca case-insensitive com Contains
resultados = filmes.Where(f => f.Titulo.ToLower().Contains(busca)).ToList();

// Agrupamento com contagem
var agrupado = filmes.GroupBy(f => f.Genero);

// Agregação estatística
double duracaoMedia = filmes.Average(f => f.Duracao);

// Projeção e flattening
var plataformasUnicas = filmes.SelectMany(f => f.Plataformas)
                              .Select(p => p.Split('|')[0])
                              .Distinct()
                              .ToList();

// Ordenação com First
var maisLongo = filmes.OrderByDescending(f => f.Duracao).First();
```

### 3. Persistência com JSON
```csharp
// Serialização com formatação indentada
string json = JsonConvert.SerializeObject(filmes, Formatting.Indented);
File.WriteAllText(ARQUIVO_FILMES, json);

// Deserialização com fallback seguro
filmes = JsonConvert.DeserializeObject<List<Filme>>(json) ?? new List<Filme>();
```

### 4. C# Moderno (Features Avançadas)
```csharp
// Expression-bodied member
public void ExibirResumo(int indice) => 
    Console.WriteLine($"[{indice}] {Titulo} ({Ano}) - {Genero}");

// Switch expression com when (C# 8.0+)
string opcao = Console.ReadLine();
List<Filme> resultados = string.Empty switch
{
    _ when opcao == "1" => BuscarPorTexto("Título", f => f.Titulo),
    _ when opcao == "2" => BuscarPorTexto("Gênero", f => f.Genero),
    _ when opcao == "3" => BuscarPorAno(),
    _ => null
};

// Init-only properties (imutabilidade pós-construção)
public string Nome { get; init; }

// Nullable reference types
public string? ClassificacaoIndicativa { get; private set; }
```

### 5. Tratamento de Erros e Validação
```csharp
// Validação com loop até entrada válida
int ano;
while (!int.TryParse(ObterEntradaObrigatoria("Ano de Lançamento: "), out ano)) 
    Console.WriteLine("Por favor, digite um ano válido.");

// Verificação de existência antes de operações
if (!filmes.Any())
{
    ConsoleHelper.MostrarErro("Nenhum filme cadastrado para remover.");
    return;
}
```

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 👨‍💻 Autor

Projeto desenvolvido para fins educacionais, demonstrando conceitos de POO, LINQ, JSON, autenticação e arquitetura de software em C#.

---

## ⭐ Considerações Finais

Este projeto demonstra na prática como construir uma aplicação console profissional em C#, com:

- ✅ **Código limpo e organizado** (nomes significativos, métodos curtos)
- ✅ **Separação de responsabilidades** (cada classe tem um propósito claro)
- ✅ **Persistência de dados** (JSON com Newtonsoft.Json)
- ✅ **Sistema de autenticação** (login com perfis admin/comum)
- ✅ **Funcionalidades completas de CRUD** (Create, Read, Delete)
- ✅ **Interface amigável** (formatação consistente, menus intuitivos)
- ✅ **Tratamento robusto de erros** (validação em todas as entradas)
- ✅ **C# Moderno** (expression-bodied, init-only, switch expressions)
- ✅ **Design Patterns** (Repository, Helper, Factory)

### Possíveis Melhorias Futuras
- Implementar edição de filmes (Update)
- Adicionar busca combinada (múltiplos filtros)
- Sistema de avaliação/notas dos usuários
- Exportação para CSV/Excel
- Interface gráfica (WPF/MAUI)

**Divirta-se explorando o código!** 🎬
