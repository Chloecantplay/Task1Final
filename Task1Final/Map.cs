using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1Final
{
    class Map
    {
        public Unit[,] MapArr = new Unit[20, 20];
        int FactionAs;
        int ClassAs;
        int UnitNum;
        Random r = new Random();
        int numUnits = 0;
        List<Unit> units;
        TextBox txtInfo;
        public List<Unit> Units
        {
            get { return units; }
            set { units = value; }
        }

        public Map(int n, TextBox txt)
        {
            units = new List<Unit>();
            numUnits = n;
            txtInfo = txt;
        }

        
        public void Generate()
        {
            for (int i = 0; i < numUnits; i++)
            {
                if (r.Next(0, 2) == 0) //Generate Melee Unit
                {
                    MeleeUnit m = new MeleeUnit(r.Next(0, 20),r.Next(0, 20),100,1,20,(i % 2 == 0 ? 1 : 0),"M");
                    units.Add(m);
                }
                else // Generate Ranged Unit
                {
                    RangedUnit ru = new RangedUnit(r.Next(0, 20), r.Next(0, 20),100,1,20,5,(i % 2 == 0 ? 1 : 0),"R");
                    units.Add(ru);
                }
            }
        }

        public void MakeMap()//creates the map
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; i < 20; j++)
                {
                    foreach (Unit c in units)
                    {
                        if (c.GetType() == typeof(MeleeUnit))
                        {
                            if (i == (((MeleeUnit)c).xPos) && (j == ((MeleeUnit)c).yPos))
                            {
                                MapArr[i, j] = c;
                            }
                        }
                        else if (c.GetType() == typeof(RangedUnit))
                        {
                            if (i == (((RangedUnit)c).xPos) && (j == ((RangedUnit)c).yPos))
                            {
                                MapArr[i, j] = c;
                            }
                        }
                    }
                }
            }
        }
        public void UpdateMap()// updates the map with units 
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; i < 20; j++)
                {
                    foreach (Unit c in MapArr)
                    {
                        if (c.GetType() == typeof(MeleeUnit))
                        {
                            if (i == (((MeleeUnit)c).xPos) && (j == ((MeleeUnit)c).yPos))
                            {
                                MapArr[i, j] = c;
                            }
                        }
                        else if (c.GetType() == typeof(RangedUnit))
                        {
                            if (i == (((RangedUnit)c).xPos) && (j == ((RangedUnit)c).yPos))
                            {
                                MapArr[i, j] = c;
                            }
                        }
                    }
                }
            }
        }
    }
}
