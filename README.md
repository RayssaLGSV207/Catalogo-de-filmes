# 🎬 Catálogo de Filmes

Sistema console completo em C# para gerenciar um catálogo de filmes com persistência em JSON, suporte a múltiplas plataformas de streaming, pesquisa avançada e estatísticas detalhadas.

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Como Executar](#como-executar)
- [Credenciais de Acesso](#credenciais-de-acesso)
- [Funcionalidades Detalhadas](#funcionalidades-detalhadas)
- [Exemplo de Saída](#exemplo-de-saída)
- [Estrutura JSON](#estrutura-json)
- [Diagrama de Classes](#diagrama-de-classes)
- [Licença](#licença)

---

## 🎯 Sobre o Projeto

O **Catálogo de Filmes** é uma aplicação console que demonstra conceitos avançados de Programação Orientada a Objetos (POO) em C#, com persistência de dados em JSON e sistema de login diferenciado. O sistema permite:

- Gerenciar filmes com informações completas
- Adicionar múltiplas plataformas de streaming com URLs
- Persistência automática em arquivos JSON
- Pesquisa avançada por título, gênero, ano, classificação e plataforma
- Estatísticas detalhadas do catálogo
- Sistema de login com perfis de usuário e administrador

### Objetivos Educacionais
Este projeto demonstra:
- ✅ Classes, objetos e construtores
- ✅ Encapsulamento e abstração
- ✅ Coleções genéricas (List, HashSet)
- ✅ LINQ (GroupBy, Where, Select, Average)
- ✅ Persistência com JSON (Newtonsoft.Json)
- ✅ Sistema de autenticação
- ✅ Tratamento de exceções
- ✅ Boas práticas de programação

---

## ✨ Funcionalidades

### 👤 Usuário Comum (sem login)
- **Ver todos os filmes**: Listagem completa com detalhes
- **Pesquisar filmes**: Por título, gênero, ano ou classificação
- **Buscar por plataforma**: Ver todos os filmes disponíveis em uma plataforma específica
- **Estatísticas**: Visualizar dados agregados do catálogo

### 👑 Administrador (login necessário)
- **Todas as funcionalidades do usuário**
- **Adicionar filmes**: Cadastro completo com plataformas e URLs
- **Remover filmes**: Exclusão por seleção numérica
- **Persistência automática**: Dados salvos em JSON
- **Ver todos os filmes**: Listagem com detalhes completos
- **Estatísticas**: Análise detalhada do catálogo

### 📊 Funcionalidades Técnicas
- **Persistência em JSON**: Dados salvos em arquivos separados (filmes.json, usuarios.json)
- **Atualização em tempo real**: Estatísticas recalculadas automaticamente
- **Interface visual**: Formatação com linhas e organização clara
- **Validações**: Tratamento de entradas inválidas
- **Sistema de navegação**: Menus intuitivos com opção de retorno

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Versão | Finalidade |
|------------|--------|------------|
| **.NET** | 10.0+ | Framework de desenvolvimento |
| **C#** | 10.0+ | Linguagem de programação |
| **Newtonsoft.Json** | 13.0.4 | Serialização/Deserialização JSON |
| **LINQ** | - | Consultas em coleções |

### Package Instalado
```bash
dotnet add package Newtonsoft.Json
```

---

## 📁 Estrutura do Projeto

```
CatalogoFilmesFinal/
│
├── Program.cs                 # Código fonte principal
├── CatalogoFilmesFinal.csproj # Arquivo de projeto
├── filmes.json                # Banco de dados de filmes (criado automaticamente)
├── usuarios.json              # Banco de dados de usuários (criado automaticamente)
│
└── README.md                  # Documentação
```

### Classes do Sistema

| Classe | Responsabilidade |
|--------|------------------|
| **Filme** | Modelo de dados do filme |
| **Usuario** | Modelo de dados do usuário |
| **CatalogoManager** | Gerencia operações do catálogo |
| **Program** | Interface e fluxo do programa |

---

## 🚀 Como Executar

### Pré-requisitos
- [.NET SDK 8.0 ou superior](https://dotnet.microsoft.com/download)
- Visual Studio Code (recomendado) ou qualquer editor de código

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
| **Administrador** | `admin` | `admin123` | Total (CRUD) |
| **Usuário Comum** | `visitante` | (vazio) | Apenas leitura |

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
```

### Menu do Usuário
| Opção | Funcionalidade |
|-------|----------------|
| 1 | Ver todos os filmes (detalhado) |
| 2 | Pesquisar filmes (título, gênero, ano, classificação) |
| 3 | Ver filmes por plataforma |
| 4 | Ver estatísticas do catálogo |
| 0 | Voltar ao menu principal |

### Menu do Administrador
| Opção | Funcionalidade |
|-------|----------------|
| 1 | Adicionar novo filme |
| 2 | Remover filme (por número) |
| 3 | Ver todos os filmes |
| 4 | Ver estatísticas |
| 0 | Voltar ao menu principal |

### Pesquisa Avançada
- **Por título**: Busca parcial (case insensitive)
- **Por gênero**: Filtra por categoria
- **Por ano**: Filmes de um ano específico
- **Por classificação**: Livre, 12 anos, 14 anos, 16 anos, 18 anos

### Busca por Plataforma
1. Exibe lista de plataformas disponíveis
2. Usuário seleciona uma plataforma
3. Mostra todos os filmes com links diretos

---

## 📺 Exemplo de Saída

```
============================================================
TODOS OS FILMES CADASTRADOS
============================================================

============================================================
MATRIX (1999)
------------------------------------------------------------
Genero: Acao/Ficcao Cientifica
Duracao: 136 minutos
Classificacao: 14 anos
Sinopse: Um programador descobre que a realidade e uma simulacao

Onde assistir:
   - Netflix: https://netflix.com/matrix
   - Prime Video: https://primevideo.com/matrix
============================================================

============================================================
ESTATISTICAS DO CATALOGO
============================================================

Total de filmes: 20
Plataformas disponiveis: Netflix, Prime Video, Disney+, HBO Max, Paramount+
Total de plataformas: 5

Filmes por genero:
   - Acao/Ficcao Cientifica: 2 filme(s)
   - Animacao/Aventura: 2 filme(s)
   - Drama/Crime: 2 filme(s)

Duracao media: 139 minutos
Filme mais longo: O Poderoso Chefao (175 min)
Filme mais curto: Toy Story (81 min)
```

---

## 📦 Estrutura JSON

### filmes.json
```json
[
  {
    "Titulo": "Matrix",
    "Ano": 1999,
    "Genero": "Acao/Ficcao Cientifica",
    "Duracao": 136,
    "Sinopse": "Um programador descobre que a realidade e uma simulacao.",
    "ClassificacaoIndicativa": "14 anos",
    "Plataformas": [
      "Netflix|https://netflix.com/matrix",
      "Prime Video|https://primevideo.com/matrix"
    ]
  }
]
```

### usuarios.json
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
┌─────────────────────────────────────────┐
│                Filme                     │
├─────────────────────────────────────────┤
│ + Titulo: string                        │
│ + Ano: int                              │
│ + Genero: string                        │
│ + Duracao: int                          │
│ + Sinopse: string                       │
│ + ClassificacaoIndicativa: string       │
│ + Plataformas: List<string>             │
├─────────────────────────────────────────┤
│ + Filme(titulo, ano, ...)               │
│ + AdicionarPlataforma(plataforma, url)  │
│ + ExibirDetalhes()                      │
│ + ExibirResumo(indice)                  │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│               Usuario                    │
├─────────────────────────────────────────┤
│ + Nome: string                          │
│ + Senha: string                         │
│ + Tipo: string                          │
├─────────────────────────────────────────┤
│ + Usuario(nome, senha, tipo)            │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│           CatalogoManager                │
├─────────────────────────────────────────┤
│ - filmes: List<Filme>                   │
│ - usuarios: List<Usuario>               │
├─────────────────────────────────────────┤
│ + CatalogoManager()                     │
│ + FazerLogin(nome, senha)               │
│ + AdicionarFilme()                      │
│ + RemoverFilme()                        │
│ + ListarTodosFilmes()                   │
│ + PesquisarFilmes()                     │
│ + PesquisarPorPlataforma()              │
│ + ExibirEstatisticas()                  │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│               Program                    │
├─────────────────────────────────────────┤
│ - manager: CatalogoManager              │
│ - usuarioLogado: Usuario                │
├─────────────────────────────────────────┤
│ + Main()                                │
│ + MenuUsuario()                         │
│ + MenuLoginAdmin()                      │
│ + MenuAdministrador()                   │
└─────────────────────────────────────────┘
```
## 📚 Conceitos Demonstrados

### 1. Programação Orientada a Objetos
| Conceito | Implementação |
|----------|--------------|
| Classe | `Filme`, `Usuario`, `CatalogoManager` |
| Objeto | Instâncias criadas no programa |
| Encapsulamento | Propriedades privadas com métodos públicos |
| Abstração | Modelagem de entidades reais |
| Construtor | Inicialização de objetos |

### 2. LINQ em Ação
```csharp
// Pesquisa
resultados = filmes.Where(f => f.Titulo.ToLower().Contains(busca)).ToList();

// Agrupamento
var generosAgrupados = filmes.GroupBy(f => f.Genero);

// Agregação
double duracaoMedia = filmes.Average(f => f.Duracao);
```

### 3. Persistência com JSON
```csharp
// Salvar
string json = JsonConvert.SerializeObject(filmes, Formatting.Indented);
File.WriteAllText(ARQUIVO_FILMES, json);

// Carregar
string json = File.ReadAllText(ARQUIVO_FILMES);
filmes = JsonConvert.DeserializeObject<List<Filme>>(json);
```

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 👨‍💻 Autor

Projeto desenvolvido para fins educacionais, demonstrando conceitos de POO, LINQ, JSON e arquitetura de software em C#.

---

## ⭐ Considerações Finais

Este projeto demonstra na prática como construir uma aplicação console profissional em C#, com:

- ✅ Código limpo e organizado
- ✅ Separação de responsabilidades
- ✅ Persistência de dados
- ✅ Sistema de autenticação
- ✅ Funcionalidades completas de CRUD
- ✅ Interface amigável

**Divirta-se explorando o código!** 🎬
