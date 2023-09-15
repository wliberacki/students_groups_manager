using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysZarzGr
{
    [Serializable]
    public enum Plcie { K, M }
    public abstract class Osoba : IEquatable<Osoba>
    {
        protected string imie;
        protected string nazwisko;
        protected string ulica;
        protected string miasto;
        protected int kodPocztowy;
        protected DateTime dataUrodzenia;
        protected string pesel;
        public Plcie plec;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Ulica { get => ulica; set => ulica = value; }
        public string Miasto { get => miasto; set => miasto = value; }
        public int KodPocztowy { get => kodPocztowy; set => kodPocztowy = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public string Pesel
        {
            get
            {
                return pesel;
            }
            set
            {
                if (value.ToString().Length != 11)
                    throw new BlednyPeselException();
                pesel = value;
            }
        }

        public Plcie Plec { get => plec; set => plec = value; }

        /// <summary>
        /// Konstruktor nieparametryczny przyjmujacy bazowy pesel na "00000000000"
        /// </summary>
        public Osoba()
        {
            this.Pesel = "00000000000";
        }
        /// <summary>
        /// Kondtruktor przyjmuje imie i nazwisko Osoby
        /// </summary>
        /// <param name="imie"></param>
        /// <param name="nazwisko"></param>
        public Osoba(string imie, string nazwisko) : this()
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }
        /// <summary>
        /// Konstruktor paramatryczny inicjujący pola DataUrodzenia, Pesel i Plec 
        /// </summary>
        /// <param name="imie"></param>
        /// <param name="nazwisko"></param>
        /// <param name="dataUrodzenia"></param>
        /// <param name="pesel"></param>
        /// <param name="plec"></param>
        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec) : this(imie, nazwisko)
        {
            DateTime date;
            DateTime.TryParseExact(dataUrodzenia, new[] { "yyyy-MMM-dd", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out date);
            DataUrodzenia = date;
            Pesel = pesel;
            Plec = plec;
        }
        /// <summary>
        /// Konstruktor paramatryczny inicjujący pola Ulica, Miasto i KodPocztowy
        /// </summary>
        /// <param name="imie"></param>
        /// <param name="nazwisko"></param>
        /// <param name="dataUrodzenia"></param>
        /// <param name="pesel"></param>
        /// <param name="plec"></param>
        /// <param name="ulica"></param>
        /// <param name="miasto"></param>
        /// <param name="kodPocztowy"></param>
        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec, string ulica, string miasto, int kodPocztowy) : this(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            Ulica = ulica;
            Miasto = miasto;
            KodPocztowy = kodPocztowy;
        }

        /// <summary>
        /// Metoda zwracająca wiek Osoby
        /// </summary>
        /// <returns></returns>
        public int Wiek() => DateTime.Today.Year - DataUrodzenia.Date.Year;

        /// <summary>
        /// Metoda zwracająca "{Imie} {Nazwisko}"
        /// </summary>
        /// <returns></returns>
        public string PolaczImieINazwisko()
        {
            return Imie + " " + Nazwisko;
        }
        /// <summary>
        /// Metoda zwracająca "{Ulica}, {KodPocztowy} {Miasto}"
        /// </summary>
        /// <returns></returns>
        public string PolaczAdres()
        {
            return $"ul.{Ulica}, {KodPocztowy.ToString("##-###")} {Miasto}";
        }
        /// <summary>
        /// Metoda zwracająca "{Imie} {Nazwisko} {Wiek} {DataUrodzenia} {Pesel} {Plec}, {Ulica}, {KodPocztowy} {Miasto}"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $@"{Imie} {Nazwisko} ({this.Wiek()}) {DataUrodzenia.ToString("yyyy-MM-dd")} {Pesel} {Plec}, {this.PolaczAdres()}";
        }

        
        public bool Equals(Osoba other)
        {
            if (other.Pesel == this.Pesel)
                return true;
            return false;
        }
    }
}
