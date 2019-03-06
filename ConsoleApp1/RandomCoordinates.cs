using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TreasureHunt
{
    class RandomCoordinates
    {
        public void RandomTreasureCoordinates(HashSet<Point> treasureCoordinates)
        {
            //Generates random coordinates.
            //The same coordinates can only be entered once to the list for treasure coordinates since treasureCoordinates a HashSet 
            while (treasureCoordinates.Count < 3) 
            {
                Random random = new Random();
                int treasureX = random.Next(1, 6);
                int treasureY = random.Next(1, 6);
                treasureCoordinates.Add(new Point(treasureX, treasureY));
            }

            //Printing the treasures to the console for testing purposes
            //Console.SetCursorPosition(0, 21);
            //foreach (var treasure in treasureCoordinates)
            //{
            //    Console.WriteLine(treasure);
            //}
        }

    }
}
