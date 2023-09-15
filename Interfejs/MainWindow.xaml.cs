using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SysZarzGr;

namespace Interfejs
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grupa grupa = new Grupa();
        public MainWindow()
        {
            InitializeComponent();

            OpenXMLFile();

        }

        private void OpenXMLFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                grupa = (Grupa)Grupa.OdczytajXML(openFileDialog.FileName);
                if (grupa is object)
                {
                    lstStudenci.ItemsSource = new ObservableCollection<Student>(grupa.Studenci);
                    txtProwadzacy.Text = grupa.Prowadzacy.ToString();
                }
            }
        }




        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            
            Student st = new Student();
            osoba_window okno = new osoba_window(st);
            bool? result = okno.ShowDialog();
            if (result == true)
            {
                grupa.DodajStudenta(st); 
                lstStudenci.ItemsSource = new ObservableCollection<Student>(grupa.Studenci);
            }
        }

        private void btnZmien_Click(object sender, RoutedEventArgs e)
        {

            Prowadzacy pr = new Prowadzacy();
            osoba_window okno = new osoba_window(pr);
            bool? result = okno.ShowDialog();
            if (result == true)
            {
                grupa.Prowadzacy = pr;
                txtProwadzacy.Text = grupa.Prowadzacy.ToString();
            }

        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                if (cb2.Text == "Programowanie Obiektowe" && cb1.Text == "1")
                {
                    grupa.Przedmiot = Przedmioty.PO;
                    grupa.NumerGrupy = "1";
                }
                else if (cb2.Text == "Programowanie Obiektowe" && cb1.Text == "2")
                {
                    grupa.Przedmiot = Przedmioty.PO;
                    grupa.NumerGrupy = "2";
                }
                else if (cb2.Text == "Finanse i Rachunkowość" && cb1.Text == "1")
                {
                    grupa.Przedmiot = Przedmioty.FiR;
                    grupa.NumerGrupy = "1";
                }
                else if (cb2.Text == "Finanse i Rachunkowość" && cb1.Text == "2")
                {
                    grupa.Przedmiot = Przedmioty.FiR;
                    grupa.NumerGrupy = "2";
                }
                else if (cb2.Text == "RPiSM" && cb1.Text == "1")
                {
                    grupa.Przedmiot = Przedmioty.RPiSM;
                    grupa.NumerGrupy = "1";
                }
                else if (cb2.Text == "RPiSM" && cb1.Text == "2")
                {
                    grupa.Przedmiot = Przedmioty.RPiSM;
                    grupa.NumerGrupy = "2";
                }

                Grupa.ZapiszXML(filename, grupa);
            }
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (lstStudenci.SelectedIndex > -1)
            {
                grupa.UsunStudenta(((Student)lstStudenci.SelectedItem).Pesel);
                lstStudenci.ItemsSource = new ObservableCollection<Student>(grupa.Studenci);
            }

        }

        private void btnSortuj_Click(object sender, RoutedEventArgs e)
        {
            lstStudenci.Items.SortDescriptions.Clear();
            lstStudenci.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Imie", System.ComponentModel.ListSortDirection.Ascending));
            lstStudenci.Items.SortDescriptions.Clear();
            lstStudenci.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Nazwisko", System.ComponentModel.ListSortDirection.Ascending));

        }

        private void btnOtworz_Click(object sender, RoutedEventArgs e)
        {
            OpenXMLFile();
        }
    }
}
