using System;

namespace TDD_feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = File.ReadAllLines("../../../../Fajlok/Bemenet1.txt" ).ToList();
            string[] input = lines.GetRange(2, int.Parse(lines[0])).ToArray();

            int N = 5;
            int L = 3;

            //string[] input = new string[]
            //{
            //"X X X X X",
            //"X C X X X",
            //"X X X X X",
            //"X X X X X",
            //"X X X X X"
            //};

            Room room = new Room(N, input);
            LightCalculator calculator = new LightCalculator(room, L);

            calculator.CalculateLight();

            int darkSpots = calculator.CountDarkSpots();

            Console.WriteLine("Sötét foltok száma: " + darkSpots);
        }
    }
}
