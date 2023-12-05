using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public class Level4
    {
        public static void TheThingNamer3000()
        {
            // The Thing Namer 3000 
            Console.WriteLine("What kind of thing are we talking about?");
            string a = Console.ReadLine(); // Noun
            Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
            string b = Console.ReadLine(); // Adjective
            string c = "Doom"; // add "Doom"
            string d = "3000"; // add "3000".
            Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!"); // "of" is already included, so it was removed from "c".
        }
    }
}
