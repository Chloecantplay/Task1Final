using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Final
{
    abstract class Unit
    {

        public int xPos;
        public int yPos;
        public int Health;
        protected int MaxHealth;
        protected int Speed; //How many rounds it takes to move
        public int Attack;
        protected int AttackRange;
        public string Faction;
        public string Symbol;
        public bool IsAttacking;

        public abstract void Move(int dir);
        public abstract void Combat(Unit c);
        public abstract bool Range(Unit c);
        public abstract Unit ClosestUnit(Unit[] units);
        public abstract bool Death();
        public abstract string Stats();

        
        

        }

    }

   


