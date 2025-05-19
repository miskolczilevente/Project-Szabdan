using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Place_the_Parenthesis.Classes;

namespace Place_the_Parenthesis.Test
{
    [TestFixture]
    internal class EquationTest
    {
        List<string> paths;

        [SetUp]
        public void Setup()
        {
            paths = Directory.GetFiles("../../../Files", "*.txt").ToList();
            
        }

        [TestCase(0, "(1+3)*5=20")]
        [TestCase(1, "4=4\n-18=-18\n1*2=2")]
        [TestCase(2, "6/(6-12)=-1\n(-6+3)*4-2=-14\n-5*5/(4+1)+5=0")]
        [TestCase(3, "12-(4*6/2+7)=-7\n1+6*(5-2)=19\n-16/(4-6)*7=56")]
        public void ReadInTest(int index, string expected)
        {
            Equation.ReadIn("../Files/" + paths[index]);

            EquationFunction.EquationsSolver();

            string result = Equation.CorrectEquationSelecter(index, false);

            ClassicAssert.AreEqual(expected, result);

        }

        [TestCase(0, "(1+3)*5=20")]
        [TestCase(1, "4=4\n-18=-18\n1*2=2")]
        [TestCase(2, "6/(6-12)=-1\n(-6+3)*4-2=-14\n-5*5/(4+1)+5=0")]
        [TestCase(3, "12-(4*6/2+7)=-7\n1+6*(5-2)=19\n-16/(4-6)*7=56")]
        public void ReadInAllTest(int index, string expected) 
        {
            Equation.ReadInAll(paths);

            EquationFunction.EquationsSolver();

            string result = Equation.CorrectEquationSelecter(index, false);

            ClassicAssert.AreEqual(result, expected);
        }



        [TestCase(0, "(1+3)*5=20")]
        [TestCase(1, "4=4\n-18=-18\n1*2=2")]
        [TestCase(2, "6/(6-12)=-1\n(-6+3)*4-2=-14\n-5*5/(4+1)+5=0")]
        [TestCase(3, "12-(4*6/2+7)=-7\n1+6*(5-2)=19\n-16/(4-6)*7=56")]
        public void CorrectEquationSelecterTest(int index, string expected)
        {
            Equation.ReadInAll(paths);

            EquationFunction.EquationsSolver();

            string result = Equation.CorrectEquationSelecter(index, false);

            ClassicAssert.AreEqual(expected, result);
        }

        [Test]
        public void AllCorrectEquationSelecterTest()
        {
            string expected = "(1+3)*5=20\n\n4=4\n-18=-18\n1*2=2\n\n6/(6-12)=-1\n(-6+3)*4-2=-14\n-5*5/(4+1)+5=0\n\n12-(4*6/2+7)=-7\n1+6*(5-2)=19\n-16/(4-6)*7=56";

            EquationFunction.EquationsSolver();

            string result = Equation.AllCorrectEquationSelecter();

            ClassicAssert.AreEqual(expected, result);
        }


        [TearDown]
        public void TearDown()
        {
            paths = null;
        }
    }
}
