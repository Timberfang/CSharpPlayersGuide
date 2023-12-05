using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public class Level9
    {
        public static void Watchtower()
        {
            // Watchtower
            Console.Write("What is the enemy's position? First, the X coordinate relative to our position, which is zero: ");
            int XCoordinate = Convert.ToInt32(Console.ReadLine());
            Console.Write("Now, the Y coordinate: ");
            int YCoordinate = Convert.ToInt32(Console.ReadLine());
            if (XCoordinate == 0 && YCoordinate == 0) { Console.WriteLine("The enemy is here!"); }
            else if (XCoordinate == 0 && YCoordinate > 0) { Console.WriteLine("The enemy is to the north!"); }
            else if (XCoordinate == 0 && YCoordinate < 0) { Console.WriteLine("The enemy is to the south!"); }
            else if (XCoordinate > 0 && YCoordinate == 0) { Console.WriteLine("The enemy is to the east!"); }
            else if (XCoordinate < 0 && YCoordinate == 0) { Console.WriteLine("The enemy is to the west!"); }
            else if (XCoordinate > 0 && YCoordinate > 0) { Console.WriteLine("The enemy is to the northeast!"); }
            else if (XCoordinate > 0 && YCoordinate < 0) { Console.WriteLine("The enemy is to the southeast!"); }
            else if (XCoordinate < 0 && YCoordinate > 0) { Console.WriteLine("The enemy is to the northwest!"); }
            else if (XCoordinate < 0 && YCoordinate < 0) { Console.WriteLine("The enemy is to the southwest!"); }
            else { Console.WriteLine("That's odd, we don't see anything at those coordinates. Can you double check them and make sure they're correct?"); }
        }
    }
}