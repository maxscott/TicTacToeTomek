using System.Diagnostics;
using System.Linq;

namespace TicTacToeTomek
{
    public class Case
    {
        readonly char[][] charGrid;

        public Case(char[][] charGrid)
        {
            this.charGrid = charGrid;
        }

        public Outcome Run()
        {
            if (DidWin('X')) return Outcome.XWon;
            if (DidWin('O')) return Outcome.OWon;

            if (GameFinished()) return Outcome.Draw;
            return Outcome.Unfinished;
        }

        bool GameFinished()
        {
            return charGrid.All(row => row.All(c => c != '.'));
        }

        bool DidWin(char player)
        {
            // Downs
            for (int i = 0; i < 4; i++)
            {
                var row = new char[]
                    {
                        charGrid[i][0],
                        charGrid[i][1],
                        charGrid[i][2],
                        charGrid[i][3],
                    };

                Debug.Write(new string(row));

                if (AllCharsBelongTo(new string(row), player)) return true;
            }

            // Sides
            for (int i = 0; i < 4; i++)
            {
                var row = new char[]
                    {
                        charGrid[0][i],
                        charGrid[1][i],
                        charGrid[2][i],
                        charGrid[3][i],
                    };

                Debug.Write(new string(row));

                if (AllCharsBelongTo(new string(row), player)) return true;
            }
            
            // Diagonals
            var diag1 = new char[]
                    {
                        charGrid[0][0],
                        charGrid[1][1],
                        charGrid[2][2],
                        charGrid[3][3],
                    };

            Debug.Write(new string(diag1));

            if (AllCharsBelongTo(new string(diag1), player)) return true;

            var diag2 = new char[]
                    {
                        charGrid[0][3],
                        charGrid[1][2],
                        charGrid[2][1],
                        charGrid[3][0],
                    };

            Debug.Write(new string(diag2));

            if (AllCharsBelongTo(new string(diag2), player)) return true;

            // met no winning case
            return false;
        }

        static bool AllCharsBelongTo(string row, char tChar)
        {
            return row.Replace('T', tChar).All(c => c == tChar);
        }
    }
}
