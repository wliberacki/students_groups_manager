using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace SysZarzGr
{
    [Serializable]
    public enum Przedmioty{PO,FiR,RPiSM}
    public class Grupa: ICloneable, IGrupa
    {
        int liczbaAktywnychCzlonkowGrupy;
        Przedmioty przedmiot;
        string numerGrupy;
        Prowadzacy prowadzacy;
        List<Student> studenci = new List<Student>();
        

        public int LiczbaAktywnychCzlonkowGrupy { get => liczbaAktywnychCzlonkowGrupy; set => liczbaAktywnychCzlonkowGrupy = value; }
        public string NumerGrupy { get => numerGrupy; set => numerGrupy = value; }
        public Prowadzacy Prowadzacy { get => prowadzacy; set => prowadzacy = value; }
        public List<Student> Studenci { get => studenci; set => studenci = value; }
        
        public Przedmioty Przedmiot { get => przedmiot; set => przedmiot = value; }
        /// <summary>
        /// Konstruktor nieparametryczny przyjmujący wartości dla właściwości(liczbaAktywnychCzlonkowGrupy = 0,numerGrupy = null,prowadzacy = null) i inicjujący nowe właściwości(przedmiot, studenci)
        /// </summary>
        public Grupa()
        {
            liczbaAktywnychCzlonkowGrupy = 0;
            przedmiot = new Przedmioty();
            numerGrupy = null;
            prowadzacy = null;
            studenci = new List<Student>();
            
        }
        /// <summary>
        /// Konstruktor parametryczny ustawiający pola NumerGrupy, Prowadzacy i Przedmiot 
        /// </summary>
        /// <param name="numerGrupy"></param>
        /// <param name="prowadzacy"></param>
        /// <param name="przedmiot"></param>
        public Grupa (string numerGrupy, Prowadzacy prowadzacy, Przedmioty przedmiot) : this()
        {
            this.NumerGrupy = "Grupa" + " " + numerGrupy;
            this.Prowadzacy = prowadzacy;
            this.Przedmiot = przedmiot;
            
        }
        /// <summary>
        /// Metoda(Student student) dodająca studenta do listy Studenci i zwiększający LiczbaAktywnychCzlonkow o 1
        /// </summary>
        /// <param name="student"></param>
        public void DodajStudenta(Student student)
        {
            Studenci.Add(student);
            LiczbaAktywnychCzlonkowGrupy++;
        }
        /// <summary>
        /// Metoda(string nralbumu) usuwająca studenta z listy i zmniejszająca LiczbaAktywnychCzlonkow o 1
        /// </summary>
        /// <param name="nralbumu"></param>
        public void UsunStudenta(string nralbumu)
        {
            if (this.Studenci.FirstOrDefault(c => c.Pesel == nralbumu) == null)
                return;

            this.Studenci.Remove(this.Studenci.FirstOrDefault(c => c.Pesel == nralbumu));
            LiczbaAktywnychCzlonkowGrupy--;
        }

        /// <summary>
        /// Metoda zwracająca "{Przedmiot} {NumerGrupy}"
        /// </summary>
        /// <returns></returns>
        public string NazwaGrupy()
        {
            return Przedmiot + " " + NumerGrupy;
        }
        /// <summary>
        /// Metoda wypisująca prowadzącego i członków grupy
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(NazwaGrupy());
            sb.AppendLine(prowadzacy.ToString());
            foreach (Student czlonek in studenci)
                sb.AppendLine(czlonek.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// Metoda(string nazwa, Grupa g) zapisująca grupe do pliku XML
        /// </summary>
        /// <param name="nazwa"></param>
        /// <param name="g"></param>
        public static void ZapiszXML(string nazwa, Grupa g)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Grupa));
            TextWriter writer = new StreamWriter($"{nazwa}.xml");
            serializer.Serialize(writer, g);
            writer.Close();
        }
        /// <summary>
        /// Metoda(string nazwa) odczytująca plik XML i zwracająca go
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Grupa OdczytajXML(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Grupa));
            FileStream fs = new FileStream(filePath, FileMode.Open);
            return (Grupa)serializer.Deserialize(fs);
        }
        /// <summary>
        /// Metoda sortująca Studentów
        /// </summary>
        public void Sortuj()
        {
            this.Studenci.Sort();
        }
        /// <summary>
        /// Metoda sortująca Studentów według NrAlbumu
        /// </summary>
        public void SortujNrAlbumu()
        {
            this.Studenci.Sort(new NrAlbumuComparator());
        }
        /// <summary>
        /// Klonowanie płytkie
        /// </summary>
        /// <returns></returns>
        public object Clone() => this.MemberwiseClone();
        /// <summary>
        /// Klonowanie głębokie
        /// </summary>
        /// <returns></returns>
        public object DeepClone()
        {
            Grupa grupa = new Grupa();
            grupa = (Grupa)this.MemberwiseClone();
            grupa.Studenci = new List<Student>();
            foreach (Student czlonek in this.Studenci)
                grupa.DodajStudenta((Student)czlonek.Clone());

            grupa.Prowadzacy = (Prowadzacy)this.Prowadzacy.Clone();
            return grupa;
        }

    }
}
