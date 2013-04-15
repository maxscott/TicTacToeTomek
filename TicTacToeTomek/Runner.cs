using System;
using System.ComponentModel;
using System.Linq;

namespace TicTacToeTomek
{
    class Runner
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine();
            var cases = int.Parse(firstLine ?? "0");

            for (int i = 0; i < cases; i++)
            {
                char[][] charGrid = new char[4][];

                charGrid[0] = Console.ReadLine().ToArray();
                charGrid[1] = Console.ReadLine().ToArray();
                charGrid[2] = Console.ReadLine().ToArray();
                charGrid[3] = Console.ReadLine().ToArray();

                Console.ReadLine();

                var outcome = new Case(charGrid).Run();

                Console.WriteLine(CasePart(i + 1) + outcome.GetDescription());
            }
        }

        public void printGrid(char[][] charGrid)
        {
            Console.WriteLine("----");
            Console.WriteLine(charGrid[0]);
            Console.WriteLine(charGrid[1]);
            Console.WriteLine(charGrid[2]);
            Console.WriteLine(charGrid[3]);
        }

        public static string CasePart(int caseNumber)
        {
            return "Case #" + caseNumber + ": ";
        } 
    }

    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            var attribute =
                Attribute.GetCustomAttribute
                (value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute))
                as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}