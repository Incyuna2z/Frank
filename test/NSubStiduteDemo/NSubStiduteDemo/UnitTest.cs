//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using NSubstitute;
//using NSubStiduteDemo;

//namespace UnitTest
//{
//    class UnitTest
//    {
//        [Fact]
//        public void TestMethod()
//        {
//            int a = 1, b = 2;

//            var substutite = Substitute.For<ICalculator>();
//            substutite.add(a, b).Returns(3);
//            substutite.State.Returns("On");

//            var Calc = new Class(substutite);
//            var returnVaule = Calc.add(a, b);
//            Assert.Equal(3, returnVaule);
//        }
//    }
//}
