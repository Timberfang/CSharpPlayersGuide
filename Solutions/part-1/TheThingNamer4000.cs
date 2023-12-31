﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Level13
    {
        public static void TheThingNamer4000()
        {
            // The Thing Namer 3000, updated based on "Taking a Number" from Level 13, albeit using a string instead of an integer.
            string a = Toolbox.AskForString("What kind of thing are we talking about?"); // Noun
            string b = Toolbox.AskForString("How would you describe it? Big? Azure? Tattered?"); // Adjective
            string c = "Doom"; // add "Doom"
            string d = "4000"; // add "3000".
            Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!"); // "of" is already included, so it was removed from "c".
        }
    }
}
