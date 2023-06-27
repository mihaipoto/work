using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursTestare.Teste;

public class Teste
{
    [Fact]
    public void TestAdd()
    {
        var calculator = new IntCalculator();

        var result = calculator.Add(5, 4);

        Assert.Equal(9, result);
    }
}
