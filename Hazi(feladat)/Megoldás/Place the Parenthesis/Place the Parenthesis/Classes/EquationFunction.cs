using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Place_the_Parenthesis;

namespace Place_the_Parenthesis.Classes
{
    static class EquationFunction
    {
        static public bool EquationIsCorrect(this string equation, int answer)
        {
            if (string.IsNullOrWhiteSpace(equation))
            {
                return false;
            }

            try
            {
                
                DataTable dt = new DataTable();
                var result = dt.Compute(equation, null);


                if (result is double.PositiveInfinity || result is double.NegativeInfinity)
                {
                    throw new Exception("Math.Error");
                }
                else if (result is int intResult)
                {
                    return intResult == answer;
                }
                else if (result is double doubleResult)
                {

                    return Math.Abs(doubleResult - answer) < 0.0001;
                }
                else if (result is decimal decimalResult)
                {
                    return decimalResult == (decimal)answer;
                }
                

                return false;
            }
            catch 
            {
                throw new Exception("Syntax.Error");
            }
        }


        static public string EquationsSolver(List<Equation> equations)
        {
            if (equations.Count == 0)
            {
                return "";
            }

            List<string> solved = new List<string>();
            for (int i = 0; i < equations.Count; i++)
            {

                string eq = equations[i].equation;
                int ans = equations[i].answer;

                if (!eq.EquationIsCorrect(ans))
                {

                    solved.Add(EqParenthesisPlacer(eq, ans));
                }
                else
                {
                    solved.Add(eq + $"={ans}");
                }

            }

            return CorrectEquationSelecter(solved);

        }

        static public string CorrectEquationSelecter(List<string> solved)
        {
            if (solved.Count == 0)
            {
                return "";
            }

            string solution = "";

            foreach (var item in solved)
            {
                solution += $"{item}\n";
            }
            solution = solution.Remove(solution.Length - 1);

            Console.WriteLine(solution);

            return solution;

        }

        static public string EqParenthesisPlacer(string eq, int ans)
        {
            if (eq == "")
            {
                return "";
            }


            string[] eq_a = eq.Split('*', '+', '/', '-');

            List<string> eq_number = new List<string>(eq_a);

            string[] eq_b = eq.Split('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');

            List<string> eq_intreger = new List<string>(eq_b);

            eq_intreger = eq_intreger.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();


            for (int i = 0; i < eq_number.Count - 1; i++)
            {
                string eq_number_i_og = eq_number[i];
                eq_number[i] = "(" + eq_number[i];

                for (int j = eq_number.Count - 1; j >= i + 1; j--)
                {
                    string eq_number_j_og = eq_number[j];
                    eq_number[j] = eq_number[j] + ")";

                    string equation = EquationMaker(eq_number, eq_intreger);
                    if (equation.EquationIsCorrect(ans))
                    {
                        return equation + $"={ans}";
                    }
                    else
                    {
                        eq_number[j] = eq_number_j_og;
                    }
                }

                eq_number[i] = eq_number_i_og;
            }

            return "Megoldhatatlan egyenlet!";

        }

        static public string EquationMaker(List<string> eq_number, List<string> eq_intreger)
        {
            if (eq_number.Count == 0 || eq_intreger.Count == 0) 
            {
                return ""; 
            }

            string eq = "";
            for (int i = 0; i < eq_intreger.Count; i++)
            {
                eq += eq_number[i];
                eq += eq_intreger[i];
            }
            eq += eq_number[eq_number.Count - 1];



            return eq;
        }
    }
}
