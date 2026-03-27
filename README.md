# 🎬 Catálogo de Filmes - Sistema de Gerenciamento

Um sistema console desenvolvido em C# para gerenciar um catálogo de filmes com informações detalhadas, plataformas de streaming e estatísticas dinâmicas.

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Código](#estrutura-do-código)
- [Como Executar](#como-executar)
- [Exemplo de Saída](#exemplo-de-saída)
- [Conceitos Abordados](#conceitos-abordados)
- [Melhorias Futuras](#melhorias-futuras)
- [Licença](#licença)

---

## 🎯 Sobre o Projeto

O **Catálogo de Filmes** é uma aplicação console que demonstra conceitos fundamentais de Programação Orientada a Objetos (POO) em C#. O sistema permite:

- Cadastrar filmes com informações completas
- Adicionar plataformas de streaming para cada filme
- Visualizar detalhes dos filmes de forma organizada
- Gerar estatísticas automáticas sobre o catálogo
- Adicionar novos filmes dinamicamente com atualização instantânea das estatísticas

### Objetivos Educacionais
Este projeto foi desenvolvido para demonstrar:
- ✅ Uso de classes e objetos
- ✅ Encapsulamento e abstração
- ✅ Coleções genéricas (List, HashSet)
- ✅ Consultas LINQ
- ✅ Métodos de instância vs métodos estáticos
- ✅ Boas práticas de programação

---

## ✨ Funcionalidades

### Gerenciamento de Filmes
- **Cadastro Completo**: Título, ano, gênero, duração, sinopse e classificação indicativa
- **Múltiplas Plataformas**: Suporte para adicionar várias plataformas de streaming por filme
- **Exibição Detalhada**: Visualização formatada com emojis e caracteres especiais

### Estatísticas Dinâmicas
O sistema calcula automaticamente:
- 📊 **Total de filmes** no catálogo
- 📺 **Plataformas únicas** disponíveis (sem duplicatas)
- 🎭 **Distribuição por gênero**
- 🔞 **Distribuição por classificação indicativa**

### Características Técnicas
- **Atualização em Tempo Real**: Estatísticas recalculadas após cada operação
- **Prevenção de Duplicatas**: HashSet garante plataformas únicas
- **Interface Visual**: Formatação com caracteres especiais e emojis

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Versão | Finalidade |
|------------|--------|------------|
| **.NET** | 6.0 ou superior | Framework de desenvolvimento |
| **C#** | 10.0+ | Linguagem de programação |
| **LINQ** | - | Consultas e manipulação de coleções |
| **Console Application** | - | Interface de usuário |

### Namespaces Utilizados
```csharp
using System;              // Funcionalidades básicas (Console, etc.)
using System.Collections.Generic;  // Coleções genéricas (List<T>, HashSet<T>)
using System.Linq;         // Consultas LINQ (GroupBy, etc.)
```

---

## 📁 Estrutura do Código

```
📁 CatalogoFilmes/
│
├── 🎬 Filme.cs
│   ├── Atributos
│   │   ├── Titulo, Ano, Genero, Duracao
│   │   ├── Sinopse, Classificacao
│   │   └── Plataforma (List<string>)
│   ├── Construtor: Inicializa um novo filme
│   ├── ExibirInformacao(): Mostra detalhes do filme
│   └── AdicionarPlataforma(): Adiciona streaming
│
├── 📚 Catalogo.cs
│   ├── Atributos: filmes (List<Filme>)
│   ├── AdicionarFilme(): Insere filme no catálogo
│   ├── ObterTodosFilmes(): Retorna lista completa
│   ├── ObterTotalFilmes(): Calcula quantidade
│   ├── ObterPlataformasUnicas(): Retorna plataformas sem repetição
│   └── ExibirEstatisticas(): Gera relatórios
│
└── 🚀 Program.cs
    └── Main(): Ponto de entrada
        ├── Cria instância do catálogo
        ├── Cadastra 3 filmes de exemplo
        ├── Exibe filmes e estatísticas
        ├── Demonstra cadastro dinâmico
        └── Exibe estatísticas atualizadas
```

---

## 🚀 Como Executar

### Pré-requisitos
- [.NET SDK 6.0 ou superior](https://dotnet.microsoft.com/download)
- Editor de código (Visual Studio, VS Code, Rider, etc.)

### Passo a Passo

#### 1. Criar um novo projeto
```bash
dotnet new console -n CatalogoFilmes
cd CatalogoFilmes
```

#### 2. Substituir o conteúdo do Program.cs
Copie todo o código fornecido e cole no arquivo `Program.cs`

#### 3. Executar o projeto
```bash
dotnet run
```

### Alternativa - Compilação Manual
```bash
# Windows
csc Program.cs
Program.exe

# Linux/Mac (com Mono)
mcs Program.cs
mono Program.exe
```

---

## 📺 Exemplo de Saída

```
════════════════════════════════════════════════════════════
🎬 SISTEMA DE CATÁLOGO DE FILMES 🎬
════════════════════════════════════════════════════════════

✅ Filme 'Matrix' adicionado com sucesso!
✅ Filme 'Toy Story' adicionado com sucesso!
✅ Filme 'O Poderoso Chefão' adicionado com sucesso!

════════════════════════════════════════════════════════════
📋 EXIBINDO FILMES CADASTRADOS
════════════════════════════════════════════════════════════

╔════════════════════════════════╗
║ MATRIX ║
╚════════════════════════════════╝
📅 Ano de Lançamento: 1999
🎭 Genero: Ação/Ficção científica
⏱️ Duração: 136 minutos
🔞 Classificação Indicativa: 14 anos
📝 Sinopse: Um programador descobre que a realidade é uma simulação...

📺 Plataformas de Streaming:
   1. Netflix
   2. Prime Video
   3. HBO Max

————————————————————————————————

╔════════════════════════════════╗
║ TOY STORY ║
╚════════════════════════════════╝
📅 Ano de Lançamento: 1995
🎭 Genero: Infantil/Comédia
⏱️ Duração: 81 minutos
🔞 Classificação Indicativa: Livre
📝 Sinopse: O aniversário do garoto Andy está chegando...

📺 Plataformas de Streaming:
   1. Disney+

————————————————————————————————

[continuação dos demais filmes...]

📊 ESTATÍSTICAS DO CATÁLOGO:
🎬 Total de filmes: 3
📺 Plataformas disponíveis: Netflix, Prime Video, HBO Max, Disney+, Paramount+
   Total de plataformas: 5

🎭 Filmes por gênero:
   • Ação/Ficção científica: 1 filme(s)
   • Infantil/Comédia: 1 filme(s)
   • Crime/Ficção policial: 1 filme(s)

🔞 Filmes por classificação indicativa:
   • 14 anos: 2 filme(s)
   • Livre: 1 filme(s)
```

---

## 📚 Conceitos Abordados

### 1. Programação Orientada a Objetos (POO)

| Conceito | Implementação |
|----------|--------------|
| **Classe** | `Filme` e `Catalogo` definem modelos |
| **Objeto** | `filme1`, `filme2`, `filme3` são instâncias |
| **Atributos** | Características como `Titulo`, `Ano` |
| **Métodos** | Comportamentos como `ExibirInformacao()` |
| **Construtor** | `public Filme(...)` inicializa objetos |
| **Encapsulamento** | Atributos `public` (simplificado) |
| **Abstração** | Classes representam conceitos do mundo real |

### 2. Coleções e Estruturas de Dados

```csharp
// Lista dinâmica - permite crescimento automático
public List<string> Plataforma;

// HashSet - garante elementos únicos
var plataformasUnicas = new HashSet<string>();
```

### 3. LINQ (Language Integrated Query)

```csharp
// Agrupa filmes por gênero
var generosAgrupados = filmes.GroupBy(f => f.Genero);

// Conta elementos em cada grupo
grupo.Count()

// Junta strings com separador
string.Join(", ", plataformasUnicas)
```

### 4. Métodos e Parâmetros

| Tipo | Exemplo | Descrição |
|------|---------|----------|
| **Método de instância** | `filme.ExibirInformacao()` | Precisa de um objeto |
| **Método estático** | `Program.Main()` | Chamado pela classe |
| **Parâmetros** | `(string plataforma)` | Recebe dados |
| **Retorno** | `List<Filme>` | Retorna coleção |

### 5. Iterações e Loops

```csharp
// foreach - percorre coleções
foreach (var filme in filmes)
{
    filme.ExibirInformacao();
}

// for - percorre com índice
for (int i = 0; i < Plataforma.Count; i++)
{
    Console.WriteLine($"   {i + 1}. {Plataforma[i]}");
}
```

---

## 🔧 Melhorias Futuras

### Funcionalidades
- [ ] **Persistência de Dados**: Salvar em JSON, XML ou banco de dados
- [ ] **Interface de Menu**: Menu interativo com opções
- [ ] **Pesquisa Avançada**: Buscar por múltiplos critérios
- [ ] **Edição/Remoção**: Modificar ou excluir filmes existentes
- [ ] **Avaliações**: Adicionar notas e comentários dos usuários
- [ ] **Ordenação**: Ordenar por título, ano, etc.

### Experiência do Usuário
- [ ] **Cores no Console**: Destacar informações importantes
- [ ] **Validações**: Tratar entradas inválidas
- [ ] **Paginação**: Para catálogos grandes
- [ ] **Confirmações**: Antes de operações críticas

### Técnicas
- [ ] **Propriedades**: Substituir atributos públicos por propriedades com get/set
- [ ] **Tratamento de Exceções**: try-catch para erros
- [ ] **Interfaces**: Implementar `ICatalogo` para abstração
- [ ] **Testes Unitários**: Garantir funcionamento correto
- [ ] **Documentação XML**: Comentários de documentação

---

## 📊 Diagrama de Classes

```
┌─────────────────────────┐
│        Filme            │
├─────────────────────────┤
│ + Titulo: string        │
│ + Ano: int              │
│ + Genero: string        │
│ + Duracao: int          │
│ + Sinopse: string       │
│ + Classificacao: string │
│ + Plataforma: List<string>│
├─────────────────────────┤
│ + Filme(...)            │
│ + ExibirInformacao()    │
│ + AdicionarPlataforma() │
└─────────────────────────┘
           ↑
           │ usa
           │
┌─────────────────────────┐
│       Catalogo          │
├─────────────────────────┤
│ - filmes: List<Filme>   │
├─────────────────────────┤
│ + AdicionarFilme()      │
│ + ObterTodosFilmes()    │
│ + ObterTotalFilmes()    │
│ + ObterPlataformasUnicas()│
│ + ExibirEstatisticas()  │
└─────────────────────────┘
           ↑
           │ cria
           │
┌─────────────────────────┐
│        Program          │
├─────────────────────────┤
│ + Main()                │
└─────────────────────────┘
```

---

## 🎓 Aprendizados

Este projeto demonstra:

1. **Orientação a Objetos**: Modelagem de entidades do mundo real
2. **Organização de Código**: Separação de responsabilidades
3. **Manipulação de Coleções**: Uso eficiente de List e HashSet
4. **Consultas com LINQ**: Agrupamento e análise de dados
5. **Interface com Usuário**: Saída formatada no console
6. **Código Dinâmico**: Estatísticas que se atualizam automaticamente

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 👨‍💻 Autor

**Seu Nome** - [seu-email@exemplo.com](mailto:seu-email@exemplo.com)

Link do Projeto: [https://github.com/seu-usuario/catalogo-filmes](https://github.com/seu-usuario/catalogo-filmes)

---

## 🙏 Agradecimentos

- Microsoft pelo .NET Framework
- Comunidade C# pelo suporte e documentação
- Criadores dos emojis utilizados na interface

---

## ⭐ Avaliação

Se este projeto foi útil para seu aprendizado, considere:
- Dar uma ⭐ no repositório
- Compartilhar com outros estudantes
- Fazer um fork e melhorar o código

---
