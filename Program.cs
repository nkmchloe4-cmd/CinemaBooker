using System.Globalization;

namespace CinemaBooker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bokning = true;
            while (bokning)
            {
                Console.WriteLine("Biobokning meny");
                Console.WriteLine("1. Lista filmer");
                Console.WriteLine("2. Välj film, tid och biljetter");
                Console.WriteLine("3. Studentrabatt");
                Console.WriteLine("4. Skriv ut kvitto");
                Console.WriteLine("5. Avsluta");

                Console.WriteLine("\nVälj ett alternativ (1-5):");
                string menyVal = Console.ReadLine();
                if (int.TryParse(menyVal, out int val))
                {
                    switch (val)
                    {
                        case 1:
                            ListaFilmer();
                            break;
                        case 2:
                            BokaBiljetter();
                            break;
                        case 3:
                            studentRabatt = !studentRabatt;
                            Console.WriteLine(studentRabatt ? " Studentrabatt Godkänt" : "Studentrabatt Icke godkänt");
                            break;
                        case 4:
                            SkrivKvitto();
                            break;
                        case 5:
                            bokning = false;
                            Console.WriteLine("Avsluta biobokning.");
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning, vänligen ange en siffra mellan 1 och 5.");
                }
            }
        }

        static string[] filmer = { "Superman", "Barbie", "Avatar" };
        static string[,] tider = {
            { "12:00", "15:00" }, 
            { "18:00", "21:00" },
            { "14:00", "20:00"}
   
        };

        static double biljettPris = 130.0;
        static bool studentRabatt;
        static double rabattProcent = 0.2;

        static string valdFilm = "";
        static string valdTid = "";
        static int antalBiljetter = 0;

        static void ListaFilmer()
        {
            Console.WriteLine("Tillgängliga filmer:");
            for (int i = 0; i < filmer.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {filmer[i]} ({tider[i, 0]}, {tider[i, 1]})");
                
            }
        }

        static void BokaBiljetter()
        { 
        ListaFilmer();
            Console.WriteLine("Välj film (nummer): ");
            if (int.TryParse(Console.ReadLine(), out int filmVal) && filmVal >= 1 && filmVal <= filmer.Length)
            {
                valdFilm = filmer[filmVal - 1];
                Console.WriteLine($"Du valde: {valdFilm}");
                Console.WriteLine($"1. {tider[filmVal - 1, 0]}");
                Console.WriteLine($"2. {tider[filmVal - 1, 1]}");
                Console.WriteLine("Välj tid (nummer): ");

                if (int.TryParse(Console.ReadLine(), out int tidVal) && (tidVal == 1 || tidVal == 2))
                {
                    valdTid = tider[filmVal - 1, tidVal - 1];
                    Console.WriteLine("Ange antal biljetter: ");
                    if (int.TryParse(Console.ReadLine(), out int antal) && antal > 0)
                    {
                        antalBiljetter = antal;
                        Console.WriteLine($"Du har bokat {antalBiljetter} biljetter till {valdFilm} kl {valdTid}.");
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig antal biljetter");
                    }
                }                
               
                else
                {
                    Console.WriteLine("Ogiltig val av tid");
                }
                
            }
                else
                {
                   Console.WriteLine("Ogiltigt val, försök igen.");
                   return;
                }

        }
        static void SkrivKvitto()
        { 
        if (valdFilm == "" || valdTid == "" || antalBiljetter == 0)
            {
                Console.WriteLine("Du måste boka biljetter innan du kan skriva ut ett kvitto.");
                return;
            }
            double totalPris = antalBiljetter * biljettPris;
            if (studentRabatt)
            {
                totalPris -= totalPris * rabattProcent;
            }
            Console.WriteLine("----- Kvitto -----");
            Console.WriteLine($"Film: {valdFilm}");
            Console.WriteLine($"Tid: {valdTid}");
            Console.WriteLine($"Antal biljetter: {antalBiljetter}");
            if (studentRabatt) Console.WriteLine("Studentrabatt: 20%");
            Console.WriteLine($"Totalpris: {totalPris:F2} kr");
            Console.WriteLine("------------------");
        }


    }
}
