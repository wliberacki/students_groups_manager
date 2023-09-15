using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SysZarzGr;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Interfejs
{
    /// <summary>
    /// Logika interakcji dla klasy osoba_window.xaml
    /// </summary>
    public partial class osoba_window : Window
    {
        
        Osoba osoba;
        public osoba_window()
        {
            InitializeComponent();
            txtNumerAlbumu.IsEnabled = false;
            txtStopienNaukowy.IsEnabled = false;
        }

        public osoba_window(Osoba os) : this()
        {
            osoba = os;
            if (osoba is Prowadzacy prowadzacy)
            {
                txtStopienNaukowy.IsEnabled = true;
            }
            else
            {
                txtNumerAlbumu.IsEnabled = true;
            }


        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (txtPesel.Text == "" || txtImie.Text == "" || txtNazwisko.Text == "")
            {
                MessageBox.Show("Wprowadzone dane są niepoprawne. Proszę poprawić.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            osoba.Pesel = txtPesel.Text;
                osoba.Imie = txtImie.Text;
                osoba.Nazwisko = txtNazwisko.Text;
                DateTime.TryParseExact(txtDataUrodzenia.Text, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy","dd-MMM-yy" }, null, DateTimeStyles.None, out DateTime date);
                osoba.DataUrodzenia = date;
                osoba.Miasto = txtMiasto.Text;
                

                if (cbPlec.Text == "Kobieta")                
                    osoba.plec = Plcie.K;                
                else               
                    osoba.plec = Plcie.M;

                DialogResult = true;
          
        }
    }
}
