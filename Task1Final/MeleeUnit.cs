using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Final
{
    class MeleeUnit : Unit
    {
        public MeleeUnit(int xPos,int yPos, int maxHealth, int speed, int attack, string f, string symbol)
        {
            XPos = xPos;
            YPos = yPos;
            this.maxHealth = maxHealth;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.faction = f;
            this.symbol = symbol;
            this.isAttacking = isAttacking;
        }
        Random r = new Random();
        int movetimer=1;
        public int XPos
        {
            get { return base.xPos; }
            set { base.xPos = value; }
        }
        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
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


        public int faction
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

        public override string Stats()
        {
            return "Melee Unit: " + health.ToString() + "Hp \n" + Attack.ToString() + "Damage \n" + Faction + " Team";
        }

        public override void Move(int dir)
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

        public override void Combat(Unit attacker)
        {
            if (attacker is MeleeUnit)
            {
                Health = Health - ((MeleeUnit)attacker).Attack;
            }
            else if (attacker is RangedUnit)
            {
                RangedUnit ru = (RangedUnit)attacker;
                Health = Health - (ru.attack - ru.attackRange);
            }

            if (Health <= 0)
            {
                Death(); //DEATH !!!
            }
        }
        public void CheckHealth()
        {
            Random r = new Random();

            if (health < maxHealth / 4)
            {
                isAttacking = false;
                xPos += r.Next(-1, 1);
                yPos += r.Next(-1, 1);
            }
        }
        public override bool InRange(Unit other)
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
        public override Unit ClosestUnit(Unit[] units)
        {
            Unit ClosestEnemy = this;
            int HowFar = 20;

            foreach(Unit u in units)
            {
                if (u.GetType() == typeof(MeleeUnit))
                {
                    if(((MeleeUnit)u).faction!= faction)
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

        public int Distance(Unit c)
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

        public override bool Death()
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


    }
}
