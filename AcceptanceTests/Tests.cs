using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeTomek;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GameUnfinished()
        {
            char[][] grid = new char[4][];

            grid[0] = "XOX.".ToArray();
            grid[1] = "OX..".ToArray();
            grid[2] = "....".ToArray();
            grid[3] = "....".ToArray();

            var outcome = new Case(grid).Run();

            Assert.AreEqual(Outcome.Unfinished, outcome);
        }
        
        [TestMethod]
        public void XWinsWithT()
        {
            char[][] grid = new char[4][];

            grid[0] = "XXXT".ToArray();
            grid[1] = "....".ToArray();
            grid[2] = "OO..".ToArray();
            grid[3] = "....".ToArray();

            var outcome = new Case(grid).Run();

            Assert.AreEqual(Outcome.XWon, outcome);
        }
    }
}
