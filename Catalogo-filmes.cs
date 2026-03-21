using System;
using System.Collections.Generic;

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
        this.Titulo = titulo;
        this.Ano = ano;
        this.Genero = genero;
        this.Duracao = duracao;
        this.Sinopse = sinopse;
        this.Classificacao = classificacao;
        Plataforma = new List<string>(); // inicia com a lista vazia
    }

    // Metodo do Objeto
    public void ExibirInformacao()
    {
        // Cabeçalho
        Console.WriteLine("《—————–—————–—————–—————–—————–—————–》");
        Console.WriteLine($"||        {Titulo.ToUpper()}        ||");
        Console.WriteLine("《—————–—————–—————–—————–—————–—————–》");

        // Informações Basicas di filme
        Console.WriteLine($"Ano de Lançamento: {Ano}");
        Console.WriteLine($"Genero: {Genero}");
        Console.WriteLine($"Duração: {Duracao} minutos");
        Console.WriteLine($"Classificação Indicativa: {Classificacao}");
        Console.WriteLine($"Sinopse: {Sinopse}");

        // Lista de Plataformas
        Console.WriteLine($"\nPlataformas de Streaming:");
        if (Plataforma.Count > 0)
        {
            for (int i = 0; i < Plataforma.Count; i++)
            {
                Console.WriteLine($" {i + 1}, {Plataforma[i]}");
            }
        }
        else
        {
            Console.WriteLine(" Nenhuma Plataforma Cadastrada");
        }
        Console.WriteLine("\n" + new string('—', 40) + "\n");
    }

    public void AdicionarPlataforma(string plataforma)
    {
        if (!string.IsNullOrWhiteSpace(plataforma))
        {
            Plataforma.Add(plataforma);
            Console.WriteLine($"Plataforma '{plataforma}' adicionada ao filme {Titulo}");
        }
    }
}
//ainda não finalizado o codigo
public class Program
{

}
