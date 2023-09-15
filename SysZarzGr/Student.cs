using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysZarzGr
{
    
    [Serializable]
    public class Student: Osoba, ICloneable, IComparable<Student>
    {
        string numerAlbumu;
        bool aktywny = true;
        string adresEmail;

        public string NumerAlbumu
        {
            get
            {
                return numerAlbumu;
            }
            set
            {
                if (value.ToString().Length != 6)
                    throw new ArgumentException("Numer Albumu składa się z 6 znakow");
                numerAlbumu = value;
            }
        }
        public bool Aktywny { get => aktywny; set => aktywny = value; }
        public string AdresEmail { get => adresEmail; set => adresEmail = value; }

        /// <summary>
        /// Konstruktor nieparametryczny
        /// </summary>
        public Student() { }

        /// <summary>
        /// Konstruktor parametryczny ustawiający pola NumerAlbumu, Aktywny, AdresEmail
        /// </summary>
        /// <param name="imie"></param>
        /// <param name="nazwisko"></param>
        /// <param name="dataUrodzenia"></param>
        /// <param name="pesel"></param>
        /// <param name="plec"></param>
        /// <param name="ulica"></param>
        /// <param name="miasto"></param>
        /// <param name="kodPocztowy"></param>
        /// <param name="numerAlbumu"></param>
        /// <param name="aktywny"></param>
        public Student(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec, string ulica, string miasto, int kodPocztowy,
           string numerAlbumu, bool aktywny): base(imie, nazwisko, dataUrodzenia, pesel, plec, ulica, miasto, kodPocztowy)
        {
            NumerAlbumu = numerAlbumu;
            Aktywny = aktywny;
            AdresEmail = $"{base.Imie.ToLower()[0]}{base.Nazwisko.ToLower()}@student.com";
        }
        /// <summary>
        /// Metoda zwracająca "{Imie} {Nazwisko} {Wiek} {DataUrodzenia} {Pesel} {Plec}, {Ulica}, {KodPocztowy} {Miasto} {NumerAlbumu} {AdresEmail} - Aktywny/Nieaktywny"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{base.ToString()} {NumerAlbumu} {AdresEmail} - {(Aktywny == true ? "Aktywny" : "Nieaktywny")}";
        }

        /// <summary>
        /// Klonowanie płytkie
        /// </summary>
        /// <returns></returns>
        public object Clone() => this.MemberwiseClone();

        /// <summary>
        /// Metoda porównująca Nazwisko alfabetycznie, jak takie samo porównuje Imie
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Student other)
        {
            if (object.ReferenceEquals(other, null))
                return 1;
            int wynik = Nazwisko.CompareTo(other.Nazwisko);
            if (wynik == 0)
                return Imie.CompareTo(other.Imie);
            return wynik;
        }
    }
}
