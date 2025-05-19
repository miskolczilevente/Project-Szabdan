using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztTDD
{
    [TestFixture]
    internal class TestWithFilePath
    {
        List<string> paths;

        [SetUp]
        public void Setup()
        { 
            paths = Directory.GetFiles("../../../../Fajlok", "*.txt").ToList();
        }
        [TestCase(0,9)]
        [TestCase(1,0)]
        [TestCase(2,2)]
        [TestCase(3,4)]
        [TestCase(4,14)]
        [TestCase(5,34)]
        [TestCase(6,9)]
        [TestCase(7,90)]
        [TestCase(8,9)]
        public void Test(int index, int expected)
        {
            List<string> lines = File.ReadAllLines("../Fajlok/" + paths[index]).ToList();
            string[] input = lines.GetRange(2, int.Parse(lines[0])).ToArray(); 
            Room room = new Room(int.Parse(lines[0]), input);
            LightCalculator calc = new LightCalculator(room, int.Parse(lines[1]));
            calc.CalculateLight();
            int darkSpots = calc.CountDarkSpots();
            Assert.AreEqual(expected, darkSpots);

        }

        [TearDown]
        public void TearDown()
        {
            paths = null;
        }
        

    }
}
