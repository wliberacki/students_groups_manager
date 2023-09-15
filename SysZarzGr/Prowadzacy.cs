using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysZarzGr
{
    [Serializable]
    public class Prowadzacy: Osoba, ICloneable
    {
        string stopienNaukowy;
        string kontakt;

        public string StopienNaukowy { get => stopienNaukowy; set => stopienNaukowy = value; }
        public string Kontakt { get => kontakt; set => kontakt = value; }
        /// <summary>
        /// Konstruktor nieparametryczny odwołujący się do klasy bazowej
        /// </summary>
        public Prowadzacy() : base() { }
        /// <summary>
        /// Konstruktor parametryczny inicjujacy pola StopienNaukowy i Kontakt
        /// </summary>
        /// <param name="imie"></param>
        /// <param name="nazwisko"></param>
        /// <param name="dataUrodzenia"></param>
        /// <param name="pesel"></param>
        /// <param name="plec"></param>
        /// <param name="ulica"></param>
        /// <param name="miasto"></param>
        /// <param name="kodPocztowy"></param>
        /// <param name="stopienNaukowy"></param>
        public Prowadzacy(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec, string ulica, string miasto, int kodPocztowy,
            string stopienNaukowy): base(imie, nazwisko, dataUrodzenia, pesel, plec, ulica, miasto, kodPocztowy)
        {
            StopienNaukowy = stopienNaukowy;
            Kontakt = $"{base.Imie.ToLower()[0]}{base.Nazwisko.ToLower()}@prowadzacy.com";
        }
        /// <summary>
        /// Metoda zwracająca "{Imie} {Nazwisko} {Wiek} {DataUrodzenia} {Pesel} {Plec}, {Ulica}, {KodPocztowy} {Miasto} {stopienNaukowy} {kontakt}"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{base.ToString()} {stopienNaukowy} {kontakt}";
        }
        /// <summary>
        /// Klonowanie płytkie
        /// </summary>
        /// <returns></returns>
        public object Clone() => this.MemberwiseClone();
    }
}
