using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppdrag3_GissaTalet_Fortsättning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> antalGissningarPerOmgång = new List<int>();
            bool fortsattaSpela = true;

            do
            {
                Console.WriteLine("Gissa talet");
                Console.WriteLine("Du ska nu gissa ett tal mellan 1 och 100, så varsågod...");
                int antalGissningar = 0;

                Random random = new Random();
                int slumpatTal = random.Next(1, 101);

                do
                {
                    Console.WriteLine("Skriv in ett tal:");
                    int tal = Convert.ToInt32(Console.ReadLine());
                    int skillnad = Math.Abs(tal - slumpatTal);

                    antalGissningar++;

                    if (tal == slumpatTal)
                    {
                        Console.WriteLine($"Grattis! Du gissade rätt, det hemliga talet var {slumpatTal} och du behövde {antalGissningar} gissningar på dig!");

                        antalGissningarPerOmgång.Add(antalGissningar);

                        Console.WriteLine("Vill du spela igen? (ja/nej): ");
                        string svar = Console.ReadLine();

                        if (svar.ToLower() != "ja")
                        {
                            fortsattaSpela = false;
                        }
                        else
                        {
                            antalGissningar = 0;
                            slumpatTal = random.Next(1, 101);
                        }

                    }
                    else if (tal < slumpatTal)
                    {
                        Console.WriteLine("Ditt tal är för litet. Gissa på ett större tal.");
                        if (skillnad <= 3)
                        {
                            Console.WriteLine("Du är dock nära och det bränns...");
                        }
                    }
                    else if (tal > slumpatTal)
                    {
                        Console.WriteLine("Ditt tal är för högt. Gissa på ett mindre tal.");
                        if (skillnad <= 3)
                        {
                            Console.WriteLine("Du är dock nära och det bränns...");
                        }
                    }

                } while (fortsattaSpela);

            } while (fortsattaSpela);

            int bästaOmgång = HittaBästaOmgång(antalGissningarPerOmgång);
            int bästaOmgångGissningar = antalGissningarPerOmgång[bästaOmgång];
            Console.WriteLine($"Din bästa omgång var omgång nummer {bästaOmgång + 1} med {bästaOmgångGissningar} antal gissningar.");
        }

        private static int HittaBästaOmgång(List<int> antalGissningarPerOmgång)
        {
            int bästaGissningar = int.MaxValue;
            int bästaOmgång = -1;

            for (int i = 0; i < antalGissningarPerOmgång.Count; i++)
            {
                int antalGissningar = antalGissningarPerOmgång[i];
                if (antalGissningar < bästaGissningar)
                {
                    bästaGissningar = antalGissningar;
                    bästaOmgång = i;
                }
            }

            return bästaOmgång;
        }
    }
}
