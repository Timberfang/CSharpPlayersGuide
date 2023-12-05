using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningProgram.Solutions;

namespace LearningProgram.Solutions
{
    public class Level16
    {
        public static void SimulasTest()
        {
            LockState currentstate = LockState.Locked;
            while (true)
            {
                string action = Toolbox.AskForString($"The chest is {currentstate}. What do you want to do? ");

                if (action == "open" && currentstate == LockState.Closed) { currentstate = LockState.Open; }        // Player can open the chest if it is closed, but not locked
                if (action == "close" && currentstate == LockState.Open) { currentstate = LockState.Closed; }       // Player can close the chest if it is opened
                if (action == "lock" && currentstate == LockState.Closed) { currentstate = LockState.Locked; }      // Player can lock the chest if it is closed, but not already locked
                if (action == "unlock" && currentstate == LockState.Locked) { currentstate = LockState.Closed; }    // Player can unlock the chest if it is closed AND locked
            }
        }
    }
}
enum LockState { Open, Closed, Locked }