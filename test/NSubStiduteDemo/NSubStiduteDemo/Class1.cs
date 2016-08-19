using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;

namespace NSubStiduteDemo
{
    public class Class
    {
        public ICalculator _calc;

        public Class(ICalculator calc)
        {
            _calc = calc;
        }

        public int add(int x, int y)
        {
            return _calc.add(x, y);
        }
    }

    public class UnitTest
    {
        [Fact]
        public void TestMethod()
        {
            int a = 1, b = 2;

            var substutite = Substitute.For<ICalculator>();
            substutite.add(a, b).Returns(3);
            substutite.State.Returns("On");

            Assert.Equal(substutite.State, "On");

            var Calc = new Class(substutite);
            var returnVaule = Calc.add(a, b);
            Assert.Equal(3, returnVaule);
        }
    }
}
