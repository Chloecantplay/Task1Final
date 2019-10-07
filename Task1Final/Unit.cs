using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Final
{
    abstract class Unit
    {

        protected int xPos;
        protected int yPos;
        protected int Health;
        protected int MaxHealth;
        protected int Speed; //How many rounds it takes to move
        protected int Attack;
        protected int AttackRange;
        protected int Faction;
        protected string Symbol;
        protected bool IsAttacking; //Shows if they unit is currently attacking or not

        public abstract void Move(int dir);
        public abstract void Combat(Unit attacker);
        public abstract bool InRange(Unit other);
        public abstract Unit ClosestUnit(Unit[] units);
        public abstract bool Death();
        public abstract string Stats();

        
        

        }

    }

   


