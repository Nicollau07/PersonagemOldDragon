using System.Collections.Generic;
using OldDragonCriacao.Utils;

namespace OldDragonCriacao.Strategies;

public class EstiloAventureiro : EstrategiaDistribuicaoLivreBase
{
    public override string Nome => "Estilo Aventureiro (3d6 distribuível)";

    protected override List<int> RolarSeisValores()
    {
        return new List<int>
        {
            RolagemDados.Rolar3d6(),
            RolagemDados.Rolar3d6(),
            RolagemDados.Rolar3d6(),
            RolagemDados.Rolar3d6(),
            RolagemDados.Rolar3d6(),
            RolagemDados.Rolar3d6()
        };
    }
}
