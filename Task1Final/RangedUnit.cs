using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Final
{
    class RangedUnit : Unit
    {
        public RangedUnit(int health, int maxHealth, int speed, int attack, int attackRange, string faction, string symbol, bool isAttacking)
        {
            this.health = health;
            this.maxHealth = maxHealth;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.faction = faction;
            this.symbol = symbol;
            this.isAttacking = isAttacking;
        }
        Random r = new Random();
        int movetimer = 1;
        public int Xpos
        {
            get { return xPos; }
            set { xPos = value; }
        }



        public int Ypos
        {
            get { return yPos; }
            set { yPos = value; }
        }



        public int health
        {
            get { return Health; }
            set { Health = value; }
        }



        public int maxHealth
        {
            get { return MaxHealth; }
            set { MaxHealth = value; }
        }


        public int speed
        {
            get { return Speed; }
            set { Speed = value; }
        }


        public int attack
        {
            get { return Attack; }
            set { Attack = value; }
        }



        public int attackRange
        {
            get { return AttackRange; }
            set { AttackRange = value; }
        }


        public string faction
        {
            get { return Faction; }
            set { Faction = value; }

        }
        public string symbol
        {
            get { return Symbol; }
            set { Symbol = value; }
        }


        public bool isAttacking
        {
            get { return IsAttacking; }
            set { IsAttacking = value; }
        }
        public override void Move(int dir) //switch statement to determine the direction of movement
        {
            switch (dir)
            {
                case 0: yPos--; break; //North
                case 1: xPos++; break; //East
                case 2: yPos++; break; //South
                case 3: xPos--; break; //West
                default: break;
            }
        }

        public override void Combat(Unit attacker) //Combat method to make units take damage
        {
            if (attacker is MeleeUnit)
            {
                Health = Health - ((MeleeUnit)attacker).attack;
            }
            else if (attacker is RangedUnit)
            {
                RangedUnit ru = (RangedUnit)attacker;
                Health = Health - (ru.Attack - ru.attackRange);
            }

            if (Health <= 0)
            {
                Death(); //DEATH !!!
            }
        }

        public override bool InRange(Unit other) //checks to see if the unit is in range of attack
        {
            int distance = 0;
            int otherX = 0;
            int otherY = 0;
            if (other is MeleeUnit)
            {
                otherX = ((MeleeUnit)other).xPos;
                otherY = ((MeleeUnit)other).yPos;
            }
            else if (other is RangedUnit)
            {
                otherX = ((RangedUnit)other).xPos;
                otherY = ((RangedUnit)other).yPos;
            }

            distance = Math.Abs(xPos - otherX) + Math.Abs(yPos - otherY);
            if (distance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override Unit ClosestUnit(Unit[] units) //checks to see where the closest unit is
        {
            Unit ClosestEnemy = this;
            int HowFar = 20;

            foreach (Unit u in units)
            {
                if (u.GetType() == typeof(MeleeUnit))
                {
                    if (((MeleeUnit)u).faction != faction)
                    {
                        if (Distance((MeleeUnit)u) < HowFar)
                        {
                            ClosestEnemy = u;
                            HowFar = Distance((MeleeUnit)u);
                        }
                    }
                }
                else if (u.GetType() == typeof(RangedUnit))
                {
                    if (((RangedUnit)u).faction != faction)
                    {
                        if (Distance((RangedUnit)u) < HowFar)
                        {
                            ClosestEnemy = u;
                            HowFar = Distance((RangedUnit)u);
                        }
                    }
                }
            }
            return ClosestEnemy;
        }

        public int Distance(Unit c) // checks the distance from the nearest unit to the unit
        {
            int Distance;
            int yDis;
            int xDis;

            if (c.GetType() == typeof(MeleeUnit))
            {
                xDis = (int)Math.Pow(((MeleeUnit)c).xPos - xPos, 2);
                yDis = (int)Math.Pow(((MeleeUnit)c).yPos - yPos, 2);

                Distance = (int)Math.Sqrt(xDis + yDis);

                return Distance;
            }
            else if (c.GetType() == typeof(RangedUnit))
            {
                xDis = (int)Math.Pow(((RangedUnit)c).xPos - xPos, 2);
                yDis = (int)Math.Pow(((RangedUnit)c).yPos - yPos, 2);

                Distance = (int)Math.Sqrt(xDis + yDis);

                return Distance;
            }
            else
            {
                return 0;
            }
        }

        public override bool Death() // checks to see if the unit is dead
        {
            if (Health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CheckHealth()//checks the health of the unit and determines if it must run away.
        {
            Random r = new Random();

            if (health < maxHealth / 4)
            {
                isAttacking = false;
                xPos += r.Next(-1, 1);
                yPos += r.Next(-1, 1);
            }
        }
        public override string Stats()// displays the info on the unit
        {
            return "Ranged Unit: " + health.ToString() + "Hp \n" + Attack.ToString() + "Damage \n" + Faction + " Team";
        }
    }
}
