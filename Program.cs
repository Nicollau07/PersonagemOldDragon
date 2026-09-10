using System;
using OldDragonCriacao.Modelo;
using OldDragonCriacao.Strategies;

namespace OldDragonCriacao;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine(" OLD DRAGON - Criação de Atributos");
        Console.WriteLine(" (Padrão Strategy)");
        Console.WriteLine("==========================================");

        Console.Write("\nNome do personagem: ");
        string nome = Console.ReadLine() is { Length: > 0 } n ? n : "Aventureiro sem nome";

        IEstrategiaCriacaoAtributos estrategia = EscolherEstrategia();

        var personagem = new Personagem(nome, estrategia);
        Atributos atributos = personagem.GerarAtributos();

        Console.WriteLine($"\n===== {personagem.Nome} ({estrategia.Nome}) =====");
        Console.WriteLine(atributos);
    }

    static IEstrategiaCriacaoAtributos EscolherEstrategia()
    {
        while (true)
        {
            Console.WriteLine("\nEscolha o estilo de criação de atributos:");
            Console.WriteLine(" 1. Estilo Clássico  (3d6, ordem fixa)");
            Console.WriteLine(" 2. Estilo Aventureiro (3d6, você distribui)");
            Console.WriteLine(" 3. Estilo Heroico   (4d6 descarta o menor, você distribui)");
            Console.Write("Opção: ");

            switch (Console.ReadLine())
            {
                case "1": return new EstiloClassico();
                case "2": return new EstiloAventureiro();
                case "3": return new EstiloHeroico();
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }
}
