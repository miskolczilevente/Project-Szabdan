using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;


namespace Place_the_Parenthesis.Classes
{
    class Equation
    {
        public static List<int> n = new List<int>();
        public static List<Equation> equations = new List<Equation>();
        public string equation, solved;
        public int answer;
        


        public Equation(string line)
        {
            string[] av = line.Split('=');
            this.equation = av[0];
            this.answer = Convert.ToInt32(av[1]);
        }

        public static void ReadInAll(List<string> hrefs)
        {
            for(int i = 0; i < hrefs.Count; i++)
            {
                ReadIn(hrefs[i]);
            }
        }

        public static void ReadIn(string href)
        {
            StreamReader r = new StreamReader(href);

            n.Add(Convert.ToInt32(r.ReadLine()));

            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                Equation equation = new Equation(line);
                equations.Add(equation);
            }

            r.Close();
        }

        static public string CorrectEquationSelecter(int i, bool write)
        {

            List<string> solvedEquations = new List<string>();

            solvedEquations.AddRange(equations.Select(eq => eq.solved));

            if (solvedEquations.Count == 0) { return ""; }

            int startIndex = n.Take(i).Sum();

            solvedEquations = solvedEquations.GetRange(startIndex, n[i]);

            string solution = "";

            for (int j = 0; j < solvedEquations.Count-1; j++)
            {
                solution += $"{solvedEquations[j]}\n";
            }
            solution += $"{solvedEquations[solvedEquations.Count - 1]}";



            if (write)
            {
                Console.WriteLine(solution);
            }


            return solution;

        }


        static public string AllCorrectEquationSelecter()
        {
            
            string allEquation = "";
            for (int i = 0; i < n.Count-1; i++)
            {
                if (CorrectEquationSelecter(i,false) == "") { return ""; }
                allEquation += $"{CorrectEquationSelecter(i, false)}\n\n" ;              
            }
            allEquation += $"{CorrectEquationSelecter(n.Count-1, false)}";

            Console.WriteLine(allEquation);

            return allEquation;

        }


    }
}
