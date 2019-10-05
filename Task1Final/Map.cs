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
        private Unit[] units;
        
        public Unit[] Units
        {
            get { return units; }
            set { units = value; }
        }


        public Map(int NumUnits)
        {
            units = new Unit[NumUnits];
            UnitNum = NumUnits;
        }
        public List<Unit> CreateUnit()
        {
            Form1 form1 = new Form1();
            for (int i = 0; i < UnitNum; i++)
            {

                ClassAs = r.Next(0, 2);
                FactionAs = r.Next(0, 2);

                if (ClassAs == 0)
                {
                    if (FactionAs == 0)
                    {
                        MeleeUnit Barbarian = new MeleeUnit(30, 30, 1, 10, 1, "Encampment", "#", false);
                        Barbarian.xPos = r.Next(0, 20);
                        Barbarian.yPos = r.Next(0, 20);
                        units[i] = Barbarian;

                        form1.StatsBox.Text += Barbarian.Stats() + "\n";
                    }
                    else if (FactionAs == 1)
                    {
                        MeleeUnit Barbarian = new MeleeUnit(30, 30, 1, 10, 1, "Adventurer", "#", false);
                        Barbarian.xPos = r.Next(0, 20);
                        Barbarian.yPos = r.Next(0, 20);
                        units[i] = Barbarian;

                        form1.StatsBox.Text += Barbarian.Stats() + "\n";
                    }
                }
                else if (ClassAs == 1)
                {
                    if (FactionAs == 0)
                    {
                        RangedUnit Archer = new RangedUnit(20, 20, 2, 15, 3, "Encampment", "☼", false);
                        Archer.xPos = r.Next(0, 20);
                        Archer.yPos = r.Next(0, 20);
                        units[i] = Archer;

                        form1.StatsBox.Text += Archer.Stats() + "\n";
                    }
                    else if (FactionAs == 1)
                    {
                        RangedUnit Archer = new RangedUnit(20, 20, 2, 15, 3, "Adventurer", "☼", false);
                        Archer.xPos = r.Next(0, 20);
                        Archer.yPos = r.Next(0, 20);
                        units[i] = Archer;

                        form1.StatsBox.Text += Archer.Stats() + "\n";
                    }
                }
            }
            return units.ToList();
        }

        public void MakeMap()
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
        public void UpdateMap()
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
