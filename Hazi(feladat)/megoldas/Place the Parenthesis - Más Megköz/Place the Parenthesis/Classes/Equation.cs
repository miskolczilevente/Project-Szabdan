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
        public static int n;
        public static List<Equation> equations = new List<Equation>();
        public string equation, solved;
        public int answer;
        


        public Equation(string line)
        {
            string[] av = line.Split('=');
            this.equation = av[0];
            this.answer = Convert.ToInt32(av[1]);
        }


        public static void ReadIn(string href)
        {
            StreamReader r = new StreamReader(href);

            n = Convert.ToInt32(r.ReadLine());

            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                Equation equation = new Equation(line);
                equations.Add(equation);
            }

            r.Close();
        }

        



    }
}
