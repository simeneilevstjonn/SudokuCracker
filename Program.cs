using System;
using SudokuSharp;

namespace SudokuCracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a board instance
            Board board = new Board();

            // Print information to user
            Console.WriteLine("Input sudoku board numbers, starting with top left. Use 0 for blank.");

            // Get user input for board
            for (int i = 0; i < 81; i++)
            {
                int cell;

                // Repeat until number is valid
                while (!int.TryParse(new char[]{ Console.ReadKey().KeyChar }, out cell))
                {
                    Console.WriteLine("\nInvalid input, please re-enter.");
                }

                // Check that number is in range
                if (cell < 0 || cell > 9)
                {
                    Console.WriteLine("\nNumber not in range, please re-enter.");
                    i--;
                }
                else
                {
                    // Append number to board
                    board.PutCell(i, cell);

                    // Give response
                    Console.WriteLine("\nok");
                }
            }

            // Check that puzzle is valid
            if (!board.IsValid)
            {
                Console.WriteLine("Puzzle is invalid.");
                return;
            }

            // Solve puzzle
            Board solved = board.Fill.Sequential();

            // Pretty print board
            Console.WriteLine("\nSolution:");
            Console.WriteLine(solved.ToString());

            // Hold program
            Console.ReadKey();
        }
    }
}
