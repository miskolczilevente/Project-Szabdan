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
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Place_the_Parenthesis.Test
{
    [TestFixture]
    internal class EquationFunctionTest
    {
        List<string> paths;
        List<List<string>> eq_number;
        List<List<string>> eq_intreger;
        List<List<string>> solved;
        List<Equation> equations;
        

        [SetUp]
        public void SetUp()
        {
            paths = Directory.GetFiles("../../../Files", "*.txt").ToList();
            eq_number = new List<List<string>>
            {
                new List<string> { "9", "5", "7" },
                new List<string> { "", "205", "380" },
                new List<string> { "0.8", "(7.5", "3.6)" },
                new List<string> { }
            };
            eq_intreger = new List<List<string>>
            {
                new List<string> { "+","-" },
                new List<string> { "-", "/" },
                new List<string> { "+", "-" },
                new List<string> { }
            };
            solved = new List<List<string>>
            {
                new List<string> { "-9=-9","8=8" },
                new List<string> {  },
                new List<string> { "-6=-6" },
                new List<string> { "2-4=-2","6-5=-1","12+16=28","20/2=10" }
            };

            equations = new List<Equation>
            {
                new Equation("16+8*4",48),
                new Equation("2*10",20),
                new Equation("17-3",20),
                new Equation("16+8-5*8",152),
            };
        }

        [TestCase(0, "9+5-7")]
        [TestCase(1, "-205/380")]
        [TestCase(2,"0.8+(7.5-3.6)")]
        [TestCase(3,"")]
        public void EquationMakerTest(int index , string expected)
        {
            
            string result = EquationFunction.EquationMaker(eq_number[index], eq_intreger[index]);

            ClassicAssert.AreEqual(expected, result);
        }

        [TestCase("16-10*2", 12, "(16-10)*2=12")]
        [TestCase("-8+6*10", -20, "(-8+6)*10=-20")]
        [TestCase("",0,"")]
        [TestCase("-8+3",20, "Megoldhatatlan egyenlet!")]
        public void EqParenthesisPlacerTest(string eq,int ans,string expected)
        {
            string result = EquationFunction.EqParenthesisPlacer(eq, ans);

            ClassicAssert.AreEqual(result, expected);
        }

        
        [Test]
        public void EquationsSolverTest()
        {
            string expected = "16+8*4=48\n2*10=20\nMegoldhatatlan egyenlet!\n(16+8-5)*8=152";

            string result = EquationFunction.EquationsSolver(equations);

            ClassicAssert.AreEqual(expected, result);
        }

        
        [TestCase("6+6", 12, true)]
        [TestCase("", 0, false)]
        [TestCase("-6-6", -12, true)]
        [TestCase("6*6", 36, true)]
        [TestCase("6/6", 1, true)]
        [TestCase("6*(6+6)", 72, true)]
        public void EquationIsCorrectTest(string eq,int ans, bool expected)
        {

            ClassicAssert.AreEqual(expected, eq.EquationIsCorrect(ans));
        }

        [TestCase("--fkwm43", 0)]
        [TestCase("7/0", 0)]
        [TestCase("7/-0", 0)]
        public void InvalidEquation(string eq, int ans)
        {

            ClassicAssert.Throws<Exception>(() => eq.EquationIsCorrect(ans));
        }

        [TestCase(0, "-9=-9\n8=8")]
        [TestCase(1, "")]
        [TestCase(2, "-6=-6")]
        [TestCase(3, "2-4=-2\n6-5=-1\n12+16=28\n20/2=10")]
        public void CorrectEquationSelecterTest(int index, string expected)
        {
            string result = EquationFunction.CorrectEquationSelecter(solved[index]);

            ClassicAssert.AreEqual(expected, result);
        }


        [TearDown]
        public void TearDown()
        {
            paths.Clear();
            eq_number.Clear();
            eq_intreger.Clear();
            solved.Clear();
            equations.Clear();
        }
    }
}
