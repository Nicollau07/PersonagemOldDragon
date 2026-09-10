using OldDragonCriacao.Modelo;

namespace OldDragonCriacao.Strategies;

public interface IEstrategiaCriacaoAtributos
{
    string Nome { get; }
    Atributos CriarAtributos();
}
