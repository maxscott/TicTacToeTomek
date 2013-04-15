using System.ComponentModel;

namespace TicTacToeTomek
{
    public enum Outcome
    {
        [Description("X won")] 
        XWon,
        [Description("O won")]
        OWon,
        [Description("Draw")]
        Draw,
        [Description("Game has not completed")]
        Unfinished
    }
}