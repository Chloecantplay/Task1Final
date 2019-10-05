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
        public override void Move(Unit c)
        {
            if (IsAttacking == false)
            {
                if (movetimer == speed)
                {
                    if (c.GetType() == typeof(RangedUnit))
                    {
                        if (((RangedUnit)c).xPos < xPos)
                        {
                            xPos -= 1;

                            if (((RangedUnit)c).yPos < yPos)
                            {
                                yPos -= 1;

                                movetimer--;
                            }
                            else if (((RangedUnit)c).yPos > yPos)
                            {
                                yPos += 1;

                                movetimer--;
                            }
                            else if (((RangedUnit)c).yPos == yPos)
                            {
                                yPos += 0;

                                movetimer--;
                            }
                        }
                        else if (((RangedUnit)c).xPos > xPos)
                        {
                            xPos += 1;

                            if (((RangedUnit)c).yPos < yPos)
                            {
                                yPos -= 1;

                                movetimer--;
                            }
                            else if (((RangedUnit)c).yPos > yPos)
                            {
                                yPos += 1;

                                movetimer--;
                            }
                            else if (((RangedUnit)c).yPos == yPos)
                            {
                                yPos += 0;

                                movetimer--;
                            }
                        }
                        else if (((RangedUnit)c).xPos == xPos)
                        {
                            xPos += 0;

                            if (((RangedUnit)c).yPos < yPos)
                            {
                                yPos -= 1;

                                movetimer--;
                            }
                            else if (((RangedUnit)c).yPos > yPos)
                            {
                                yPos += 1;

                                movetimer--;
                            }
                            else if (((RangedUnit)c).yPos == yPos)
                            {
                                yPos += 0;

                                movetimer--;
                            }
                        }
                    }
                }
            }
        }

        public override void Combat(Unit c)
        {
            CheckHealth();
            if (isAttacking)
            {
                if (movetimer == speed)
                {
                    movetimer = 1;
                    if (Range(c))
                    {
                        IsAttacking = true;

                        if (c.GetType() == typeof(MeleeUnit))
                        {
                            ((MeleeUnit)c).health -= attack;
                        }
                        else if (c.GetType() == typeof(RangedUnit))
                        {
                            ((RangedUnit)c).health -= attack;
                        }
                    }
                }
                else
                {
                    movetimer++;
                }
            }
        }
        public override bool Range(Unit c)
        {
            if (Distance(c) < AttackRange)
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
        public override string Stats()
        {
            return "Ranged Unit: " + health.ToString() + "Hp \n" + Attack.ToString() + "Damage \n" + Faction + " Team";
        }
    }
}
