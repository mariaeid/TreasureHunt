using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TreasureHunt
{
    class Program
    {
        
        static void Main(string[] args)
        {
            HashSet<Point> treasureCoordinates = new HashSet<Point>(); //Unique list (HashSet) for random treasure coordinates
            HashSet<Point> foundTreasures = new HashSet<Point>(); //Unique list (HashSet) with hits

            int xInput = 0;
            int yInput = 0;

            //Generating random coordinates for the treasures
            var randomCoordinates = new RandomCoordinates();
            //var support = new SupportingMethods();
            randomCoordinates.RandomTreasureCoordinates(treasureCoordinates);

            //Printing welcome text
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("=====================");
            Console.WriteLine("   TREASURE HUNT");
            Console.WriteLine("=====================");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"Go ahead and search for the hidden treasures. There are {treasureCoordinates.Count()} to find. Good luck!");

            //Printing the gameboard to the console
            var printGameBoard = new GameBoard();
            printGameBoard.PrintGameBoard(treasureCoordinates, foundTreasures, xInput, yInput);
            while (true)
            {

                if (foundTreasures.Count == 3) //If the user has found 3 treasures the game is ended
                {
                    SupportingMethods.ClearOutputLine(17);
                    Console.WriteLine("Congratulations, you found all the treasures! \n");
                    break;
                }

                else //Asking for user coordinates as long as the user haven't found 3 treasures
                {
                    SupportingMethods.ClearOutputLine(4);
                    //Calling the method ReadNumber to verify that the user input is a number and convert the number to an int
                    yInput = SupportingMethods.ReadNumber("Y-coordinate: ");
                    xInput = SupportingMethods.ReadNumber("X-coordinate: ");
                }
                printGameBoard.PrintGameBoard(treasureCoordinates, foundTreasures, xInput, yInput);
            }
        }            
    }
}
