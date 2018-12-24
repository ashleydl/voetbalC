using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voetbalC
{
    class BerekeningAantalPosities
    {

        static void Posities(string[] args)
        {
            //Aantal spelers

            int intAantal = 0;
            while (intAantal <= 0)
            {
                Console.WriteLine("Hoeveel teams hebben jullie");
                var AantalTeams = TryAnswer();

                if (!int.TryParse(AantalTeams, out intAantal))
                {
                    // Foutmelding
                    TryAnswer();
                }
            }

            //Namen spelers

            List<SpelerInfo> alleSpelers = new List<SpelerInfo>();

            for (int i = 0; i < intAantal; i++)
            {
                Console.WriteLine(string.Format("Geeft de naam op voor team {0}.", i + 1));
                var naam = TryAnswer();

                //Nieuw item aan van het type Team en sla daar de naam alvast in op.
                var nItem = new Team
                {
                    Naam = naam
                };


                //Sterkte posities

                string positieNaam = null;
                string TeamNaam = null;
               
                int pteller = 0;
                int pateller = 0;

                List<OpstellingInfo> allePosities = new List<OpstellingInfo>();



                while (true)
                {
                    // Sla de positie naam op in een variable
                    positieNaam = Enum.GetName(typeof(Positie), pteller);
                    TeamNaam = Enum.GetName(typeof(Team), pateller);
                    
                  
               

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
                            Console.WriteLine("Geef het aantal voor {0} voor team {1}", positieNaam, TeamNaam);
                            var answer = TryAnswer();

                            // Probeer de input om te zetten naar een geheel getal
                            if (!int.TryParse(answer, out intSterkte))
                            {
                                //Foutmelding als het geen getal is
                                TryAnswer();
                            }

                        }
                        // Sla de positie en waarde op
                       
                        nItem.Opstellinginfo.Add(new OpstellingInfo { Positie = (Positie)pateller, PositieAantal = intSterkte  });

                    }
                    pateller++;
                }
                
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
