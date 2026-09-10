# Old Dragon — Criação de Atributos com Strategy

Implementa as 3 formas de criação de personagem do livro **Old Dragon 2 —
Regras Básicas** (pág. 15) usando o padrão de projeto **Strategy**.

## As 3 regras implementadas

| Estilo | Rolagem | Distribuição |
|---|---|---|
| **Clássico** | 3d6, seis vezes | Ordem fixa: Força, Destreza, Constituição, Inteligência, Sabedoria, Carisma |
| **Aventureiro** | 3d6, seis vezes | Livre — você escolhe onde cada valor vai |
| **Heroico** | 4d6 descartando o menor dado, seis vezes | Livre — você escolhe onde cada valor vai |

## Como rodar

```bash
cd OldDragonCriacao
dotnet run
```

(precisa do .NET SDK 8.0 instalado)

## Como o Strategy foi aplicado

**A ideia do padrão:** em vez de ter um método gigante com
`if (estilo == "classico") ... else if (estilo == "aventureiro") ...`,
cada algoritmo de criação vira uma **classe própria**, e todas elas
implementam a mesma **interface**. Quem usa o algoritmo (o `Personagem`)
não sabe qual classe concreta está por trás — ele só conhece a interface.

```
IEstrategiaCriacaoAtributos          <- interface (o "contrato" do Strategy)
   ├── EstiloClassico                <- rolagem em ordem fixa
   └── EstrategiaDistribuicaoLivreBase   <- abstrata, reaproveitada por:
          ├── EstiloAventureiro      <- 3d6 + distribuição livre
          └── EstiloHeroico          <- 4d6 (descarta menor) + distribuição livre

Personagem                           <- CONTEXTO: guarda uma referência à
                                         interface e delega a ela a criação
                                         dos atributos, sem saber qual estilo
                                         está sendo usado por baixo dos panos.
```

### Papéis de cada arquivo

- **`Strategies/IEstrategiaCriacaoAtributos.cs`** — a interface Strategy.
  Define o método `CriarAtributos()` que toda estratégia precisa ter.
- **`Strategies/EstiloClassico.cs`** — uma Strategy concreta. Rola 3d6 seis
  vezes e monta os atributos direto na ordem fixa do livro.
- **`Strategies/EstiloAventureiro.cs`** e **`Strategies/EstiloHeroico.cs`** —
  as outras duas Strategies concretas. Cada uma só define **como rolar os
  dados** (`RolarSeisValores()`); a lógica de perguntar ao jogador onde
  distribuir cada valor é herdada da classe base, então não é duplicada.
- **`Strategies/EstrategiaDistribuicaoLivreBase.cs`** — classe abstrata que
  concentra o código repetido entre Aventureiro e Heroico (a parte de
  "distribuir os valores como o jogador quiser"). Isso evita copiar e colar
  o mesmo código nas duas classes.
- **`Utils/RolagemDados.cs`** — utilitário estático com `RolarDado`,
  `Rolar3d6` e `Rolar4d6DescartandoMenor`. Centraliza a rolagem de dados
  para que nenhuma Strategy precise reimplementar `Random`.
- **`Modelo/Atributos.cs`** — apenas guarda os 6 valores e calcula o
  modificador de cada um (Tabela 1.1 do livro).
- **`Modelo/Personagem.cs`** — o **Contexto** do Strategy. Recebe uma
  `IEstrategiaCriacaoAtributos` no construtor e chama `CriarAtributos()`
  sem saber qual implementação concreta está sendo usada. Também expõe
  `DefinirEstrategia(...)`, mostrando que dá para trocar de algoritmo em
  tempo de execução.
- **`Program.cs`** — menu de console que pergunta o estilo ao jogador e
  instancia a Strategy correspondente (`new EstiloClassico()`,
  `new EstiloAventureiro()` ou `new EstiloHeroico()`), passando-a para o
  `Personagem`.

### Por que isso é Strategy e não outra coisa

- Existem **vários algoritmos que resolvem o mesmo problema** (gerar 6
  atributos), e eles são **intercambiáveis**: qualquer um pode substituir o
  outro sem que o `Personagem` mude uma linha de código.
- A seleção de qual algoritmo usar acontece **fora** das classes de
  algoritmo — quem decide é o `Program.cs` (o "cliente"), não a Strategy
  nem o Contexto.
- O Contexto (`Personagem`) depende apenas da **interface**
  (`IEstrategiaCriacaoAtributos`), nunca de uma classe concreta — isso é o
  Princípio da Inversão de Dependência, que é o que faz o Strategy
  funcionar.

## Roteiro sugerido para a defesa

1. Explique o problema: 3 formas diferentes de gerar os mesmos 6 atributos.
2. Mostre a interface `IEstrategiaCriacaoAtributos` e explique que ela é o
   contrato comum.
3. Mostre as 3 implementações e aponte a diferença de cada uma (ordem fixa
   x rolagem diferente x distribuição livre).
4. Explique a classe abstrata `EstrategiaDistribuicaoLivreBase` e por que
   ela existe (evitar duplicar a lógica de distribuição entre Aventureiro
   e Heroico).
5. Mostre o `Personagem` (contexto) e destaque que ele só conhece a
   interface — rode o programa trocando de opção no menu para provar que
   o mesmo `Personagem` funciona com qualquer uma das 3 estratégias.
6. Se perguntarem "por que não usar if/else direto": se um dia adicionarem
   um 4º estilo, não seria necessário alterar `Personagem` nem as
   estratégias existentes — só criar uma nova classe. Isso é o princípio
   Aberto/Fechado (open/closed).
