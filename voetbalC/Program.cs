using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voetbalC
{
    class Program
    {

        static void Main(string[] args)
        {
            //Aantal spelers

            int AantalSpelers = 0;
            
            while (AantalSpelers <= 0)
            {
                Console.WriteLine("Met hoeveel spelers zijn jullie?");
                var intAantal = TryAnswer();


                if (!int.TryParse(intAantal, out AantalSpelers))
                {

                    // Foutmelding
                    TryAnswer();

                }
            
                //if (intAantal < 8 || intAantal > 22)
                //    {
                //    Console.WriteLine("Geef tussen de 8 en 22 spelers");
                //    Console.ReadLine();
                //}

            }

            //Namen spelers

            List<SpelerInfo> alleSpelers = new List<SpelerInfo>();

            for (int i = 0; i < AantalSpelers; i++)
            {
                Console.WriteLine(string.Format("Geeft de naam op van speler {0}.", i + 1));
                var naam = TryAnswer();

                //Nieuw item aan van het type SpelerInfo en sla daar de naam alvast in op.
                var nItem = new SpelerInfo
                {
                    Naam = naam
                };


                int pteller = 0;
                string positieNaam = null;
                while (true)
                {
                    // Sla de positie naam op in een variable

                    positieNaam = Enum.GetName(typeof(Positie), pteller);

                    if (string.IsNullOrWhiteSpace(positieNaam))
                    {
                        break;
                    }
                    else
                    {
                        int intSterkte = 0;
                        while (intSterkte <= 0)
                        {
                            // Vraag de gebruiker om zijn sterkte op te geven van de desbetreffende positie
                            Console.WriteLine("Geef de sterkte op van positie: {0} voor speler {1}", positieNaam, naam);
                            var answer = TryAnswer();

                            // Probeer de input om te zetten naar een geheel getal
                            if (!int.TryParse(answer, out intSterkte))
                            {
                                //Foutmelding als het geen getal is
                                TryAnswer();
                            }
                            if (intSterkte > 5 || intSterkte < 1)
                            {
                                Console.WriteLine("Niet hoger dan 5 of lager dan 1");
                                Console.WriteLine("Geef de sterkte op van positie: {0} voor speler {1}", positieNaam, naam);
                                Console.ReadLine();
                            }


                        }
                        // Sla de positie en waarde op
                        nItem.PositieInfo.Add(new PositieInfo { Positie = (Positie)pteller, PositieWaarde = intSterkte });
                    
                    }
                    pteller++;

                }
                alleSpelers.Add(nItem);
            }




            //Aantal teams

            int intAantalTeams = 2;
            
            List<Team> alleTeams = new List<Team>();


            for (int t = 0; t < intAantalTeams; t++)
            {
                Console.WriteLine(string.Format("Geeft de naam op voor team {0}.", t + 1));
                var naam = TryAnswer();

                //Nieuw item aan van het type Team en sla daar de naam alvast in op.
                var TeamItem = new Team
                {
                    Naam = naam
                };

                TeamItem.Spelers = AantalSpelers / 2;


                //Sterkte posities

                string positieNaamOpstelling = null;

                int pnteller = 0;



                while (true)
                {
                    // Sla de positie naam op in een variable
                    positieNaamOpstelling = Enum.GetName(typeof(Positie), pnteller);
                   

                    if (string.IsNullOrWhiteSpace(positieNaamOpstelling))
                    {
                        break;
                    }
                    else
                    {
                        int AantalPosities = 0;
                        while (AantalPosities == 0)
                        {
                            // Vraag de gebruiker om aantal per positie per team
                            Console.WriteLine("Geef het aantal voor {0} voor team {1}", positieNaamOpstelling, naam);
                            var answer = TryAnswer();

                            // Probeer de input om te zetten naar een geheel getal
                            if (!int.TryParse(answer, out AantalPosities))
                            {
                                TryAnswer();
                            }
                            int CalculatePlayerPositie = TeamItem.Spelers - AantalPosities;
                            
                            //Keeper positie mag niet meer of minder dan 1 zijn
                            Enum K = Positie.Keeper;
                            int Keep = Convert.ToInt32(K);
                            if (CalculatePlayerPositie < 3)
                            {
                                Console.WriteLine("Houdt de uitkomst gelijk aan het aantal spelers");
                                Console.WriteLine("Geef het aantal voor {0} voor team {1}", positieNaamOpstelling, naam);
                                TryAnswer();
                                Console.ReadLine();
                            }
                           else if (Keep < 1 || Keep > 1)
                            {
                                Console.WriteLine("Geef voor Keep 1");
                                Console.WriteLine("Geef het aantal voor {0} voor team {1}", positieNaamOpstelling, naam);
                                TryAnswer();
                                Console.ReadLine();
                            }

                        }
                        TeamItem.Opstellinginfo.Add(new OpstellingInfo { Positie = (Positie)pnteller, PositieAantal = AantalPosities });
                    }         
                    pnteller++;
                }
                    alleTeams.Add(TeamItem);
                    
                }






                //    // Loop alle spelers langs
                //    foreach (var item in alleSpelers)
                //    {
                //        // Haal de naam op van de positie met de hoogste waarde
                //        var sterkst = item.PositieInfo.OrderByDescending(o => o.PositieWaarde).FirstOrDefault();
                //        // Print de info
                //        Console.WriteLine(string.Format("Speler: {0} is het sterkt als {1}", item.Naam, Enum.GetName(typeof(Positie), sterkst.Positie)));
                //    }

            
                while(true)
                

                //foreach (var item in alleTeams)
                //{
                //    //Zoek uit hoe het laagste getal gepakt wordt
                //    var laagstePositie = item.Opstellinginfo.OrderByDescending(z => z.PositieAantal).FirstOrDefault();
                //    //var smallest_age = item.Opstellinginfo.SingleOrDefault(arg => arg.PositieAantal == item.Opstellinginfo.Min(arg => arg.PositieAantal));
                //    //var result2 = item.Opstellinginfo.FirstOrDefault(arg => arg.PositieAantal == item.Opstellinginfo.Min(arg => arg.PositieAantal));

                //    Console.WriteLine(string.Format("Team: {0} heeft het laagste {1}", item.Naam, Enum.GetName(typeof(Positie), laagstePositie.Positie)));
                //}

                // FIN!
                Console.ReadLine();

                

                //zet naam op positie



                //Geeft foutmelding, wanneer het niet goed is ingevuld
                string TryAnswer()
                {
                    var question = Console.ReadLine();
                    while (question == "")
                    {
                        Console.WriteLine("Dit is niet geldig, probeer het opnieuw: ");
                        return Console.ReadLine();
                    }


                    return question;
                }

            }

        }
    }



