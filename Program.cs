using System;
using System.Collections.Generic;
using System.IO;

namespace FinalPractical
{
    class Program
    {
        //DO NOT MODIFY EXCEPT TO CHANGE QUANTITY OF PLAYERS AND/OR MONSTERS

        //a single Random instance for the entire aplication
        public static Random rand = new Random();
        static string[] characterNames = new string[] { "Garviel", "Potonoodle", "Tummyache", "Solex", "Livec", "Depress" };
        static string[] monsterNames = new string[] { "Ochu", "Giant", "Dragon", "Lizardman", "Golem", "Demon" };

        static void Main(string[] args)
        {
            List<Character> characters = new List<Character>();
            for(int i = 0; i < 5; i++)
            {
                characters.Add(new Player(characterNames[i]));
            }
            for (int i = 0; i < 5; i++)
            {
                characters.Add(new Monster(monsterNames[i]));
            }
            CombatEnvironment env = new CombatEnvironment(characters);
            env.ResolveCombat();
            using (StreamWriter writer = new StreamWriter(@"../../Report.txt"))
            {
              
            }
            Console.ReadLine();
        }
    }
}
