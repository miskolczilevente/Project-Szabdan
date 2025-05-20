using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using Place_the_Parenthesis.Classes;




namespace Place_the_Parenthesis
{
    internal class Program 
    {
        
        static void Main(string[] args)
        {
            List<string> paths = Directory.GetFiles("../../../Files", "*.txt").ToList();
            //Equation.ReadInAll(paths);

            EquationFunction.EquationsSolver();

            //Equation.AllCorrectEquationSelecter();
            //Equation.CorrectEquationSelecter(1,true);
            
            Console.ReadLine();
        }

        
    }

    
}
