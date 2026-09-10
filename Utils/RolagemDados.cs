using System;
using System.Collections.Generic;
using System.Linq;

namespace OldDragonCriacao.Utils;

public static class RolagemDados
{
    private static readonly Random _rnd = new();

    public static int RolarDado(int lados = 6) => _rnd.Next(1, lados + 1);

    public static int Rolar3d6()
    {
        return RolarDado() + RolarDado() + RolarDado();
    }

    public static int Rolar4d6DescartandoMenor()
    {
        var dados = new List<int> { RolarDado(), RolarDado(), RolarDado(), RolarDado() };
        dados.Sort();
        dados.RemoveAt(0); // descarta o menor dado
        return dados.Sum();
    }
}
