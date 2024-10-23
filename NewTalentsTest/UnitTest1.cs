using System.ComponentModel;
using NewTalents;

namespace NewTalentsTest;

public class UnitTest1
{

    //fazer metodos para evitar repetição casso precise passar instancia da classe 

    public Calculadora construirClasse()
    {
        Calculadora calc = new("23/10/2024");
        return calc;

    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(5, 5, 10)]
    public void TesteSomar(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        // Calculadora calc = new();

        int resultadoCalculadora = calc.Somar(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(2, 1, 1)]
    [InlineData(5, 3, 2)]
    public void TesteSubtrair(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();

        int resultadoCalculadora = calc.Subtrair(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(5, 5, 25)]
    public void TesteMultiplicar(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();

        int resultadoCalculadora = calc.Multiplicar(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(6, 2, 3)]
    [InlineData(5, 5, 1)]
    public void TesteDividir(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();

        int resultadoCalculadora = calc.Dividir(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        Calculadora calc = construirClasse();
        //tratando a excessão
        Assert.Throws<DivideByZeroException>(() => calc.Dividir(3, 0));
    }

    [Fact]
    public void TestarHistorico()
    {
        Calculadora calc = construirClasse();

        calc.Somar(1, 2);
        calc.Dividir(8, 2);
        calc.Somar(3, 5);

        var lista = calc.historico();

        Assert.NotEmpty(calc.historico());
        Assert.Equal(3, lista.Count);
    }
}
