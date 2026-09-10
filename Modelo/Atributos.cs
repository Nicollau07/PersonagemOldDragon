namespace OldDragonCriacao.Modelo;

public class Atributos
{
    public int Forca { get; set; }
    public int Destreza { get; set; }
    public int Constituicao { get; set; }
    public int Inteligencia { get; set; }
    public int Sabedoria { get; set; }
    public int Carisma { get; set; }

    public static int CalcularModificador(int valor) => valor switch
    {
        <= 3 => -3,
        4 or 5 => -2,
        6 or 7 or 8 => -1,
        >= 9 and <= 12 => 0,
        13 or 14 or 15 => +1,
        16 or 17 => +2,
        >= 18 => +3
    };

    private static string FormatarModificador(int mod) => mod >= 0 ? $"+{mod}" : $"{mod}";

    public override string ToString()
    {
        return $"FOR: {Forca,2} ({FormatarModificador(CalcularModificador(Forca))})\n" +
               $"DES: {Destreza,2} ({FormatarModificador(CalcularModificador(Destreza))})\n" +
               $"CON: {Constituicao,2} ({FormatarModificador(CalcularModificador(Constituicao))})\n" +
               $"INT: {Inteligencia,2} ({FormatarModificador(CalcularModificador(Inteligencia))})\n" +
               $"SAB: {Sabedoria,2} ({FormatarModificador(CalcularModificador(Sabedoria))})\n" +
               $"CAR: {Carisma,2} ({FormatarModificador(CalcularModificador(Carisma))})";
    }
}