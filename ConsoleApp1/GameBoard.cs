using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TreasureHunt
{
    class GameBoard
    {
        List<Point> gameBoard = new List<Point>();
        //HashSet<Point> searchesNoTreasure = new HashSet<Point>(); //Unique list (HashSet) to store input coordinates from player
        int hintCounter = 0; //Counter to keep track of when to suggest to get a tip
        public GameBoard()
        {
            //Creating and adding points to the gameBoard list
            for (int y = 1; y <= 5; y++)
            {
                for (int x = 1; x <= 5; x++)
                {
                    gameBoard.Add(new Point(x, y));
                }
            }
        }
        
        public void PrintGameBoard(HashSet<Point> treasureCoordinates, HashSet<Point> foundTreasures, int xInput, int yInput)
        {
            int cursorStartX = 0;
            int cursorStartY = 7;

            //Printing the y-axis title reference points
            for (int i = 1; i <= 5; i++)
            {
                Console.SetCursorPosition(cursorStartX, cursorStartY + i);
                Console.Write(i);
            }

            //Printing the x-axis title reference points
            Console.SetCursorPosition(cursorStartX + 2, cursorStartY);
            Console.WriteLine("1 2 3 4 5");

            Point latestInputPoint = new Point(xInput, yInput); //X and Y input temporarily stored in a point

            //Printing the grid
            foreach (var area in gameBoard)
            {
                Console.SetCursorPosition(area.X * 2, area.Y + cursorStartY);

                //Checking if the area field exists in the found treasure list to mark previous found treasures
                if (foundTreasures.Contains(area))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("X ");
                    Console.ResetColor();

                    if (area == latestInputPoint)
                    {
                        SupportingMethods.ClearOutputLine(17);
                        Console.WriteLine("You have already found this. Go and find another one!");
                    }
                }

                //Cheking if the inserted X and y coordinates provided exists in the list of tresure coordinates and that the gameboard area field
                //corresponds to the inserted coordianates
                else if (treasureCoordinates.Contains(latestInputPoint) && area == latestInputPoint)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X ");
                    Console.ResetColor();
                    foundTreasures.Add(latestInputPoint);
                    SupportingMethods.ClearOutputLine(17);
                    Console.WriteLine("Yey, you found one!");
                    hintCounter = 0;
                }

                else if (!treasureCoordinates.Contains(latestInputPoint) && area == latestInputPoint)
                {
                    hintCounter++;
                    SupportingMethods.ClearOutputLine(17);
                    Console.WriteLine("Nothing here. Try somewhere else.");
                }

                else if (xInput > 5 || yInput > 5)
                {
                    SupportingMethods.ClearOutputLine(17);
                    Console.WriteLine("You have entered coordinates outside of the search area. Try again!");
                }

                //Printing area fields where no treasures have been found
                else
                {
                    Console.Write("~ ");
                }
            }

            if (hintCounter == 3 && foundTreasures.Count != 3)
            {
                hintCounter = 0;
                SupportingMethods.ClearOutputLine(17);
                Console.Write("Need a hint? Yes or no > ");
                string ans = Console.ReadLine();
                ans = ans.ToLower();
                if (ans == "yes")
                {
                    CreateTip(foundTreasures, treasureCoordinates);
                }
                if (ans == "no")
                {
                    SupportingMethods.ClearOutputLine(17);
                    Console.WriteLine("Ok, keep going.");
                }
            }
        }

        //Method that gives the user the Y coordinate of the first treasure not yet found.
        private static void CreateTip(HashSet<Point> alreadyFoundTreasures, HashSet<Point> allTreasurePositions)
        {
            HashSet<Point> remainingTreasurePositions = allTreasurePositions;
            foreach (Point position in alreadyFoundTreasures)
            {
                if (remainingTreasurePositions.Contains(position))
                {
                    remainingTreasurePositions.Remove(position);
                }
            }
            // Always tip about the first remaining treasure in the remainingTreasurePositions HashSet
            SupportingMethods.ClearOutputLine(17);
            Console.WriteLine($"Here is a tip for you my friend: Search more on row {remainingTreasurePositions.First().Y}");
        }
    }
}
