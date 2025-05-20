using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Place_the_Parenthesis;
using Place_the_Parenthesis.Classes;
using System.IO;
using NUnit.Framework.Legacy;

namespace Place_the_Parenthesis.Test
{
    [TestFixture]
    internal class EquationFunctionTest
    {

        [OneTimeSetUp]
        //public void SetUp()
        //{
        //    List<string> paths = Directory.GetFiles("../../../Files", "*.txt").ToList();
        //    Equation.ReadInAll(paths);
            
        //}

        [Test]
        public void EquationMakerTest()
        {
            string expected = "-9-8+6";
            List<string> eq_number = new List<string>(2) { "-9", "8", "6" };
            List<string> eq_intreger = new List<string>(1) { "-", "+" };
            string result = EquationFunction.EquationMaker(eq_number, eq_intreger);

            ClassicAssert.AreEqual(result, expected);
        }

        [Test]
        public void EqParenthesisPlacerTest()
        {
            string eq = "16-10*2";
            int ans = 12;
            string expected = "(16-10)*2";

            string result = EquationFunction.EqParenthesisPlacer(eq, ans);

            ClassicAssert.AreEqual(result, expected);
        }

        //[Test]
        //public void EquationsSolverTest() 
        //{
        //    EquationFunction.EquationsSolver();

        //    string expected = "(1+3)*5=20\n\n4=4\n-18=-18\n1*2=2\n\n6/(6-12)=-1\n(-6+3)*4-2=-14\n-5*5/(4+1)+5=0\n\n12-(4*6/2+7)=-7\n1+6*(5-2)=19\n-16/(4-6)*7=56";

        //    string result = Equation.AllCorrectEquationSelecter();

        //    ClassicAssert.AreEqual(expected, result);
        //}

        [Test]
        public void EquationIsCorrectTest()
        {
            string equation = "6+6";
            int ans = 12;

            ClassicAssert.IsTrue(equation.EquationIsCorrect(ans));
        }


        [TearDown]
        public void TearDown()
        {
            Equation.equations.Clear();
        }
    }
}
