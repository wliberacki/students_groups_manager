using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysZarzGr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grupa grupa = new Grupa("1", new Prowadzacy("Adam","Kowalski","11-01-1950","11111111111",Plcie.M ,"Nowa","Krakow",12345,"profesor"),Przedmioty.PO);

            grupa.DodajStudenta(new Student("Wojciech", "Liberacki", "21-12-2001", "01322109156", Plcie.M, "Stara", "Krakow", 67890, "411236", true));
            grupa.DodajStudenta(new Student("Jan", "Nowak", "10-10-2001", "01311111156", Plcie.M, "Droga", "Krakow", 63120, "412351", true));
            grupa.DodajStudenta(new Student("Agata", "Kowalska", "11-02-2002", "12342109156", Plcie.K, "Dobra", "Krakow", 65690, "411109", false));

            Console.WriteLine("GRUPA:");
            Console.WriteLine(grupa);
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("POSORTOWANA GRUPA:");
            grupa.Sortuj();
            Console.WriteLine(grupa);
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("POSORTOWANA GRUPA PO NUMERZE ALBUMU:");
            grupa.SortujNrAlbumu();
            Console.WriteLine(grupa);
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("PŁYTKIE KOPIOWANIE");
            Grupa grupa2 = (Grupa)grupa.Clone();           
            grupa2.Prowadzacy.Imie = "Rafal";
            Console.WriteLine("GRUPA:");
            Console.WriteLine(grupa);

            Console.WriteLine("GRUPA KOPIA:");
            Console.WriteLine(grupa2);
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("GŁĘBOKIE KOPIOWANIE:");
            grupa2 = (Grupa)grupa.DeepClone();          
            grupa2.Prowadzacy.Imie = "Tomasz";
            Console.WriteLine("GRUPA:");
            Console.WriteLine(grupa);
            Console.WriteLine("GRUPA KOPIA:");
            Console.WriteLine(grupa2);

            Console.ReadKey();

        }
    }
}
