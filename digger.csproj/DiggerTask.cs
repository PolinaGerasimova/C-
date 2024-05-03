using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    //Напишите здесь классы Player, Terrain и другие.
    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }

    public class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            if (Game.KeyPressed == Keys.Up && y - 1 >= 0 ) result.DeltaY = -1;
            if (Game.KeyPressed == Keys.Down && y + 1< Game.MapHeight) result.DeltaY = 1;
            if (Game.KeyPressed == Keys.Left && x - 1>= 0) result.DeltaX = -1;
            if (Game.KeyPressed == Keys.Right && x + 1 < Game.MapWidth) result.DeltaX = 1; 

            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }

}
