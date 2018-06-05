using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = false;

            // Arrange
            Random r = new Random();
            Main.Game game = new Main.Game();

            int xod = 0;
            int player = 1;
     int razm = r.Next(3, 6);
            int[,] mas = new int[7, 7];

            while (!result)
            {
                int i = r.Next(1, razm + 1);
                int j = r.Next(1, razm + 1);
                if (mas[i, j] != 1 & mas[i, j] != 2)
                {
                    mas[i, j] = player;

                    // Act
                    result = game.proverka(mas, razm);

                    //Счетчик количества ходов 
                    xod++;
                    if (xod % 2 == 0)
                    { player = 1; }
                    else
                    { player = 2; }
                }
            }

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            Random r = new Random();
            Main.Game game = new Main.Game();

            int player = 1;
            int razm = r.Next(3, 6);
            int[,] mas = new int[7, 7];
            int i = r.Next(1, razm + 1);
            int j = r.Next(1, razm + 1);
            mas[i, j] = player;
            // Act

            //Assert
            Assert.IsFalse(game.proverka(mas, razm));
        }
    }
}
