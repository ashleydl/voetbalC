﻿using System;
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

            int intAantal = 0;
            while (intAantal <= 0)
            {
                Console.WriteLine("Met hoeveel spelers zijn jullie?");
                var AantalSpelers = TryAnswer();

                if (!int.TryParse(AantalSpelers, out intAantal))
                {
                    // Foutmelding
                    TryAnswer();
                }
            }

            //Namen spelers

            List<SpelerInfo> alleSpelers = new List<SpelerInfo>();

            for (int i = 0; i < intAantal; i++)
            {
                Console.WriteLine(string.Format("Geeft de naam op van speler {0}.", i + 1));
                var naam = TryAnswer();

                //Nieuw item aan van het type SpelerInfo en sla daar de naam alvast in op.
                var nItem = new SpelerInfo
                {
                    Naam = naam
                };


                //Sterkte posities

                string positieNaam = null;
                int pteller = 0;

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
                        int intPositieAantal = 0;
                        while (intPositieAantal <= 0)
                        {
                            // Vraag de gebruiker om zijn sterkte op te geven van de desbetreffende positie
                            Console.WriteLine("Geef de sterkte op van positie: {0} voor speler {1}", positieNaam, naam);
                            var answer = TryAnswer();

                            // Probeer de input om te zetten naar een geheel getal
                            if (!int.TryParse(answer, out intPositieAantal))
                            {
                                //Foutmelding als het geen getal is
                                TryAnswer();
                            }
                            
                        }
                        // Sla de positie en waarde op
                        nItem.PositieInfo.Add(new PositieInfo { Positie = (Positie)pteller, PositieWaarde = intPositieAantal });
                    }
                    pteller++;
                }
                alleSpelers.Add(nItem);



                
                    //Aantal spelers

                    int intAantalTeams = 0;
                    while (intAantalTeams <= 0)
                    {
                        Console.WriteLine("Met hoeveel teams zijn jullie?");
                        var AantalTeams = TryAnswer();

                        if (!int.TryParse(AantalTeams, out intAantalTeams))
                        {
                            // Foutmelding
                            TryAnswer();
                        }
                    }
                    List<Team> alleTeams = new List<Team>();
               

                //Namen spelers

             

                for (int t = 0; t < intAantalTeams; t++)
                {
                    Console.WriteLine(string.Format("Geeft de naam op voor team {0}.", i + 1));
                    var Teamnaam = TryAnswer();

                    //Nieuw item aan van het type Team en sla daar de naam alvast in op.
                    var TeamItem = new Team
                    {
                        Naam = naam
                    };
                    //Sterkte posities

                    string positieNaamOpstelling = null;
                    string TeamNaam = null;

                    int pnteller = 0;
                    int pateller = 0;


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
                            int intSterkte = 0;
                            while (intSterkte <= 0)
                            {
                                // Vraag de gebruiker om zijn sterkte op te geven van de desbetreffende positie
                                Console.WriteLine("Geef het aantal voor {0} voor team {1}", positieNaamOpstelling, TeamNaam);
                                var answer = TryAnswer();

                                // Probeer de input om te zetten naar een geheel getal
                                if (!int.TryParse(answer, out intSterkte))
                                {
                                    //Foutmelding als het geen getal is
                                    TryAnswer();
                                }

                            }
                            // Sla de positie en waarde op

                            TeamItem.Opstellinginfo.Add(new OpstellingInfo { Positie = (Positie)pteller, PositieAantal = intSterkte });
                        }
                        pteller++;
                    }
                    alleTeams.Add(TeamItem);
                    

                }
                    // Loop alle spelers langs
                    foreach (var item in alleSpelers)
                    {
                        // Haal de naam op van de positie met de hoogste waarde
                        var sterkst = item.PositieInfo.OrderByDescending(o => o.PositieWaarde).FirstOrDefault();

                        // Print de info
                        Console.WriteLine(string.Format("Speler: {0} is het sterkt als {1}", item.Naam, Enum.GetName(typeof(Positie), sterkst.Positie)));
                    }

                // FIN!
                Console.ReadLine();
            }

            //Geeft foutmelding, wanneer het niet goed is ingevuld
            string TryAnswer()
            {
                var question = Console.ReadLine();
                if (question == "")
                {
                    Console.WriteLine("Dit is niet geldig, probeer het opnieuw: ");
                    return Console.ReadLine();
                }
                return question;
            }
        
        }

    }
}
