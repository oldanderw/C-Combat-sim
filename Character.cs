using System;
using System.Collections.Generic;
using System.IO;

namespace FinalPractical
{
    //this class must remain abstract
    abstract class Character
    {
        //these are the only required member variables of this class
        //other than name, these will need to be randomly generated when the class is instantiated
        string name;
        int health;
        int attack;
        int defense;
        double accuracy;
        int speed;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }
        public int Defense
        {
            get
            {
                return defense;
            }

            set
            {
                defense = value;
            }
        }
        public double Accuracy
        {
            get
            {
                return accuracy;
            }

            set
            {
                accuracy = value;
            }
        }
        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }
        public int Attack
        {
            get
            {
                return attack;
            }

            set
            {
                attack = value;
            }
        }

        public Character(string stringName)
        {
            Name = stringName;
            Health = Program.rand.Next(40, 60);
            Defense = Program.rand.Next(5, 10);
            Attack = Program.rand.Next(15, 20);
            Accuracy = Program.rand.Next(60, 80) + Program.rand.NextDouble();
            Speed = Program.rand.Next(1, 10);

        }

        //Fight the provided Character parameter
        //The damage dealt to the combatant is this Character's attack minus the target's defense
        //Negative damage should not be applied
        //The Character should have a chance to miss. Its percent chance to successfully hit is its accuracy value
        //Output the results of combat to the console. Indicate whether the attack missed and if it didn't show how much damage was dealt by who and to who
        public void Combat(Character combatant)
        {
           
            double HitOrMiss = Program.rand.Next(0, 100) + Program.rand.NextDouble();
            Console.Write(Name + " battles " + combatant.Name + ".");
            if (Accuracy < HitOrMiss)
            {
                 
                Console.WriteLine("Attack misses.");
            }
            else
            {
                Character health = combatant;
                health.Health = health.Health - (Attack - combatant.Defense);
                Console.WriteLine("Attack deals " + (Attack - combatant.Defense) + " damage.");
            }
        }
        public override string ToString()
        {
            string outputString = "";
            if (!(this is Player)){
                
                outputString = outputString + "Enemy: ";
            }
            else
            {
               outputString = outputString + "Player: ";
            }
            outputString = string.Concat(new object[] { outputString, Name, ", Health: ", Health, ", Attack: ", Attack, ", Defense: ", Defense, ", Speed: ", Speed });
            return outputString;
        }
    }
}