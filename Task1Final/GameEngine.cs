using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Final
{
    class GameEngine
    {
        int round;
        List<Unit> units = new List<Unit>();

        Map map = new Map(20);

        public void Initialise()
        {
            units.Clear();
            units = map.CreateUnit();
        }
        public void Round()
        {
            List<Unit> temp = new List<Unit>();
            temp = units;
            foreach (Unit c in map.Units)
            {
                if (c.Death())
                {
                    temp.Remove(c);
                }
                else if (c.Range(c.ClosestUnit(map.Units)))
                {
                    c.Combat(c.ClosestUnit(map.Units));
                }
                else
                {
                    c.Move(c.ClosestUnit(map.Units));
                }
                units = temp;
                map.UpdateMap();
            }
            round++;
        }
    }
    }
}
