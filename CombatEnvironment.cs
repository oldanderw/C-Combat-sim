using System;
using System.Collections.Generic;
using System.IO;

namespace FinalPractical
{
    class CombatEnvironment
    {
        //probably need to store the combatants

        
        
        private List<Character> combatants;
        public CombatEnvironment(List<Character> combatantsInput)
        {
            //sorting combatants by speed would be a good idea
            combatants = combatantsInput;
            combatants.Sort((Character one, Character two) => two.Speed.CompareTo(one.Speed));
        }

        public void ResolveCombat()
        {
            

            //to start, display information about all combatants
            //when displaying information include the type of Character(Monster or Player), health, attack, defense, and speed

            //every round each Character should attack one other Character of the opposing type (Players attack Monsters, and Monsters attack Players)
            //The Characters should attack in the order of highest speed to lowest speed
            //If a Character's health falls to 0 or below 0 then it has died and should be removed from the CombatEnvironment
            //After each round of combat each Character's information should be displayed with updated health values
            //After each round of combat, check to see if all Players or all Monsters have died. If one side has died, end the combat and display which side was victorious
            foreach (Character combatant in combatants)
                {
              //      writer.WriteLine(combatant);
                    Console.WriteLine(combatant);
                }
                // to add space for the first time it runs
             //   writer.WriteLine();
                Console.WriteLine();
                while (true)
                {

                    for (int i = 0; i < combatants.Count; i++)
                    {
                        if (!(combatants[i] is Monster))
                        {
                            int selectedMonster = 0;
                            while (selectedMonster < combatants.Count)
                            {
                                if (!(combatants[selectedMonster] is Monster))
                                {
                                    selectedMonster++;
                                }
                                else
                                {
                                    this.combatants[i].Combat(this.combatants[selectedMonster]);
                                    if (this.combatants[selectedMonster].Health <= 0)
                                    {
                                 //      writer.WriteLine(this.combatants[selectedMonster].Name + " died.");
                                        Console.WriteLine(this.combatants[selectedMonster].Name + " died.");
                                        this.combatants.RemoveAt(selectedMonster);
                                        selectedMonster++;
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            int selectedPlayer = 0;
                            while (selectedPlayer < this.combatants.Count)
                            {
                                // if selected player IS NOT equal to player then add 1 to selectedPlayer
                                if (!(this.combatants[selectedPlayer] is Player))
                                {
                                    selectedPlayer++;
                                }
                                else
                                {
                                    this.combatants[i].Combat(this.combatants[selectedPlayer]);
                                    //if selectedPlayer heath is or less than to 0 then report that the player died and remove them remove the list and then move on to next selectedPlayer
                                    if (this.combatants[selectedPlayer].Health <= 0)
                                    {
                             //           writer.WriteLine(this.combatants[selectedPlayer].Name + " died.");
                                        Console.WriteLine(this.combatants[selectedPlayer].Name + " died.");
                                        this.combatants.RemoveAt(selectedPlayer);
                                        selectedPlayer++;
                                    }
                                    break;
                                }
                            }
                        }
                    }
               //     writer.WriteLine("Combat Round Results:");
                    Console.WriteLine("Combat Round Results:");
                    int playersCount = 0;
                    int monstersCount = 0;
                    foreach (Character character in this.combatants)
                    {
                        if (!(character is Monster))
                        {
                            monstersCount++;
                        }
                        else
                        {
                            playersCount++;
                        }
                     //   writer.WriteLine(character);
                        Console.WriteLine(character);
                    }
               //     writer.WriteLine();
                    Console.WriteLine();
                    if (monstersCount == 0)
                    {
                      //  writer.WriteLine("Monsters Win!");
                        Console.WriteLine("Monsters Win!");
                        break;
                    }
                    else if (playersCount == 0)
                    {
                      // writer.WriteLine("Players Win!");
                        Console.WriteLine("Players Win!");
                        break;
                    }

                }
            }

       
    }
    }
