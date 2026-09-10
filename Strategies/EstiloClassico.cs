using OldDragonCriacao.Modelo;
using OldDragonCriacao.Utils;

namespace OldDragonCriacao.Strategies;

public class EstiloClassico : IEstrategiaCriacaoAtributos
{
    public string Nome => "Estilo Clássico (3d6 na ordem)";

    public Atributos CriarAtributos()
    {
        return new Atributos
        {
            Forca = RolagemDados.Rolar3d6(),
            Destreza = RolagemDados.Rolar3d6(),
            Constituicao = RolagemDados.Rolar3d6(),
            Inteligencia = RolagemDados.Rolar3d6(),
            Sabedoria = RolagemDados.Rolar3d6(),
            Carisma = RolagemDados.Rolar3d6()
        };
    }
}
