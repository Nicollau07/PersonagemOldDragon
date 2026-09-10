using System.Collections.Generic;
using OldDragonCriacao.Utils;

namespace OldDragonCriacao.Strategies;

public class EstiloHeroico : EstrategiaDistribuicaoLivreBase
{
    public override string Nome => "Estilo Heroico (4d6 descarta menor, distribuível)";

    protected override List<int> RolarSeisValores()
    {
        return new List<int>
        {
            RolagemDados.Rolar4d6DescartandoMenor(),
            RolagemDados.Rolar4d6DescartandoMenor(),
            RolagemDados.Rolar4d6DescartandoMenor(),
            RolagemDados.Rolar4d6DescartandoMenor(),
            RolagemDados.Rolar4d6DescartandoMenor(),
            RolagemDados.Rolar4d6DescartandoMenor()
        };
    }
}
