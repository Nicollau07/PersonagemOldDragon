using System;
using System.Collections.Generic;
using OldDragonCriacao.Modelo;

namespace OldDragonCriacao.Strategies;

public abstract class EstrategiaDistribuicaoLivreBase : IEstrategiaCriacaoAtributos
{
    public abstract string Nome { get; }
    protected abstract List<int> RolarSeisValores();

    public Atributos CriarAtributos()
    {
        List<int> valores = RolarSeisValores();
        var atributos = new Atributos();
        var nomesAtributos = new List<string> { "Força", "Destreza", "Constituição", "Inteligência", "Sabedoria", "Carisma" };

        Console.WriteLine($"\nValores rolados: [ {string.Join(", ", valores)} ]");

        foreach (var nomeAttr in nomesAtributos)
        {
            while (true)
            {
                Console.WriteLine($"\nValores disponíveis: [ {string.Join(", ", valores)} ]");
                Console.Write($"Escolha o valor para {nomeAttr}: ");

                if (int.TryParse(Console.ReadLine(), out int escolhido) && valores.Contains(escolhido))
                {
                    valores.Remove(escolhido);

                    switch (nomeAttr)
                    {
                        case "Força": atributos.Forca = escolhido; break;
                        case "Destreza": atributos.Destreza = escolhido; break;
                        case "Constituição": atributos.Constituicao = escolhido; break;
                        case "Inteligência": atributos.Inteligencia = escolhido; break;
                        case "Sabedoria": atributos.Sabedoria = escolhido; break;
                        case "Carisma": atributos.Carisma = escolhido; break;
                    }
                    break;
                }

                Console.WriteLine("Valor inválido ou não disponível na lista. Tente novamente.");
            }
        }

        return atributos;
    }
}
