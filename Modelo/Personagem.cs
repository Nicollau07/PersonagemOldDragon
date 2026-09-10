using OldDragonCriacao.Strategies;

namespace OldDragonCriacao.Modelo;

public class Personagem
{
    public string Nome { get; set; }
    private IEstrategiaCriacaoAtributos _estrategia;

    public Personagem(string nome, IEstrategiaCriacaoAtributos estrategia)
    {
        Nome = nome;
        _estrategia = estrategia;
    }

    public void DefinirEstrategia(IEstrategiaCriacaoAtributos novaEstrategia)
    {
        _estrategia = novaEstrategia;
    }

    public Atributos GerarAtributos()
    {
        return _estrategia.CriarAtributos();
    }
}