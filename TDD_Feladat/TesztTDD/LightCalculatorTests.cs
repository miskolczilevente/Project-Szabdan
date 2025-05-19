
using NUnit.Framework;
using System.Collections.Generic;

namespace RoomLightTests
{
    [TestFixture]
    public class LightCalculatorTests
    {
        [Test]
        public void RoomInitialization_CorrectlyParsesCandles()
        {
            string[] input = {
                "X X X",
                "X C X",
                "X X X"
            };
            Room room = new Room(3, input);
            Assert.AreEqual(1, room.Candles.Count);
            Assert.AreEqual('C', room.Grid[1, 1]);
        }

        [Test]
        public void CandlePlacement_LightMapCorrect_CenterCandle_LightLevel2()
        {
            string[] input = {
                "X X X",
                "X C X",
                "X X X"
            };
            Room room = new Room(3, input);
            LightCalculator calc = new LightCalculator(room, 2);
            calc.CalculateLight();

            int[,] expected = {
                {1, 1, 1},
                {1, 2, 1},
                {1, 1, 1}
            };

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], GetLightValue(calc, i, j), $"Mismatch at {i},{j}");
        }

        [Test]
        public void MultipleCandles_LightIsMaxOfSources()
        {
            string[] input = {
                "C X X",
                "X X X",
                "X X C"
            };
            Room room = new Room(3, input);
            LightCalculator calc = new LightCalculator(room, 2);
            calc.CalculateLight();

            int centerLight = GetLightValue(calc, 1, 1);
            Assert.AreEqual(1, centerLight);
        }

        [Test]
        public void DarkSpotsCount_ExampleInput_ReturnsCorrect()
        {
            string[] input = {
                "X X X X X",
                "X C X X X",
                "X X X X X",
                "X X X X X",
                "X X X X X"
            };
            Room room = new Room(5, input);
            LightCalculator calc = new LightCalculator(room, 3);
            calc.CalculateLight();
            int darkCount = calc.CountDarkSpots();

            Assert.AreEqual(9, darkCount);
        }

        [Test]
        public void NoCandles_AllSpotsAreDark()
        {
            string[] input = {
                "X X X",
                "X X X",
                "X X X"
            };
            Room room = new Room(3, input);
            LightCalculator calc = new LightCalculator(room, 3);
            calc.CalculateLight();
            Assert.AreEqual(9, calc.CountDarkSpots());
        }

        [Test]
        public void FullCandleRoom_NoDarkSpots()
        {
            string[] input = {
                "C C C",
                "C C C",
                "C C C"
            };
            Room room = new Room(3, input);
            LightCalculator calc = new LightCalculator(room, 1);
            calc.CalculateLight();
            Assert.AreEqual(0, calc.CountDarkSpots());
        }

        private int GetLightValue(LightCalculator calc, int x, int y)
        {
            return calc.LightMap[x, y];
        }

        [Test]
        public void ParseInput_OneCandleIsCorrectlyLocated()
        {
            string[] input = {
                    "X X X",
                    "X C X",
                    "X X X"
                };
            Room room = new Room(3, input);

            Assert.AreEqual(1, room.Candles.Count);
            Assert.AreEqual(1, room.Candles[0].X);
            Assert.AreEqual(1, room.Candles[0].Y);
        }

        [Test]
        public void IsInside_ReturnsTrueForValidPositions()
        {
            Room room = new Room(3, new[] { "X X X", "X X X", "X X X" });
            Assert.IsTrue(room.IsInside(0, 0));
            Assert.IsTrue(room.IsInside(2, 2));
        }

        [Test]
        public void IsInside_ReturnsFalseForOutOfBounds()
        {
            Room room = new Room(3, new[] { "X X X", "X X X", "X X X" });
            Assert.IsFalse(room.IsInside(-1, 0));
            Assert.IsFalse(room.IsInside(3, 1));
            Assert.IsFalse(room.IsInside(1, -1));
            Assert.IsFalse(room.IsInside(0, 3));
        }

        [Test]
        public void CandleDoesNotAffectOutsideRoom()
        {
            string[] input = {
                    "C X X",
                    "X X X",
                    "X X X"
                };
            Room room = new Room(3, input);
            LightCalculator calc = new LightCalculator(room, 1);
            calc.CalculateLight();
            int darkSpots = calc.CountDarkSpots();


            Assert.AreEqual(8, darkSpots);
        }

        [Test]
        public void MultipleCandlesWithOverlap_StillMaxLightApplied()
        {
            string[] input = {
                    "C X C",
                    "X X X",
                    "C X C"
                };
            Room room = new Room(3, input);
            LightCalculator calc = new LightCalculator(room, 1);
            calc.CalculateLight();
            int darkSpots = calc.CountDarkSpots();


            Assert.AreEqual(5, darkSpots);
        }

        [Test]
        public void CandleOnEdge_LightsProperlyWithinBounds()
        {
            string[] input = {
                    "X X C",
                    "X X X",
                    "X X X"
                };
            Room room = new Room(3, input);
            LightCalculator calc = new LightCalculator(room, 2);
            calc.CalculateLight();
            int darkSpots = calc.CountDarkSpots();
            Assert.Greater(darkSpots, 0);
        }




        [Test]
        public void ParseInput_GridIsFilledCorrectly()
        {
            string[] input = {
                    "X C X",
                    "C X C",
                    "X C X"
                };
            Room room = new Room(3, input);
            Assert.AreEqual('C', room.Grid[0, 1]);
            Assert.AreEqual('C', room.Grid[1, 0]);
            Assert.AreEqual('X', room.Grid[1, 1]);
        }

        [Test]
        public void CandleConstructor_SetsCoordinatesCorrectly()
        {
            Candle c = new Candle(2, 3);
            Assert.AreEqual(2, c.X);
            Assert.AreEqual(3, c.Y);
        }


        [Test]
        public void CandleAtCorner__LightsProperly5()
        {
            string[] input = {
                    "C X X",
                    "X X X",
                    "X X X"
                };
            Room room = new Room(3, input);
            LightCalculator calc = new LightCalculator(room, 5);
            calc.CalculateLight();
            int dark = calc.CountDarkSpots();

            Assert.AreEqual(0, dark);
        }

    }
}


