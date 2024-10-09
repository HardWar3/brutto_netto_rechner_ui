using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;
using System.Collections.Generic;

namespace brutto_netto_rechner_ui
{
    /// <summary>
    /// Interaction logic for Bruttonettogui.xaml
    /// </summary>
    public partial class Bruttonettogui : Window
    {
        private Dictionary<string, int> userValues = new Dictionary<string, int>();
        // enums schreiben für alle 0 1 2 fälle !!! LESBARKEIT !!!
        // members entfernen
        //private string  _brutto = "brutto";
        //private string  _abrechnungsart = "abrechnungsart";
        //private string  _abrechnungsjahr = "abrechnungsjahr";
        //private string  _versorgungsbezuege = "versorgungsbezuege";
        //private string  _steuerklasse = "steuerklasse";
        //private string  _kirche = "kirche";
        //private string  _bundesland = "bundesland";
        //private string  _alter = "alter";
        //private string  _kinder = "kinder";
        //private string  _kinderfreibetrag = "kinderfreibetrag";
        //private string  _krankenversicherung = "krankenversicherung";
        //private string  _privatversicherungsbetrag = "privatversicherungsbetrag";
        //private string  _arbeitgeberzuschuss = "arbeitgeberzuschuss";
        //private string  _rentenversicherung = "rentenversicherung";

        public Bruttonettogui()
        {
            InitializeComponent();
        }

        private void krankenversicherung_onChanged(object sender,SelectionChangedEventArgs e)
        {
            ComboBox krankenversicherung = (ComboBox) sender;
            int krankenkassenArt = 0;

            if (privatversicherung_Panel == null)
            {
                return;
            }

            if (krankenversicherung.Text.Equals("private Versicherung"))
            {
                privatversicherung_Panel.Visibility = Visibility.Collapsed;
                arbeitgeberzuschuss_Panel.Visibility = Visibility.Collapsed;
                krankenkassen_zusatzbeitrag_Panel.Visibility = Visibility.Visible;

                krankenkassenArt = 0;
            }
            else
            {
                privatversicherung_Panel.Visibility = Visibility.Visible;
                arbeitgeberzuschuss_Panel.Visibility = Visibility.Visible;
                krankenkassen_zusatzbeitrag_Panel.Visibility = Visibility.Collapsed;

                if (arbeitgeberzuschuss.IsChecked == false)
                {
                    krankenkassenArt = 1;
                } else
                {
                    krankenkassenArt = 2;
                }
            }


            userValues.Remove("krankenversicherung");
            userValues.Add("krankenversicherung", krankenkassenArt);
        }

        private void kinder_onChecked(object sender, RoutedEventArgs e)
        {
            int hasKinder = 0;
            int _kinderfreibetrag = 0;
            if (kinder == null)
            {
                return;
            }

            if (kinder.IsChecked.GetValueOrDefault())
            {
                kinderfreibetrag_Panel.Visibility = Visibility.Visible;
                hasKinder = 1;
                _kinderfreibetrag = Convert.ToInt32(kinderfreibetrag.Text) * 10;

            }
            else
            {
                kinderfreibetrag_Panel.Visibility = Visibility.Collapsed;
                kinderfreibetrag.SelectedIndex = 0;
                hasKinder = 0;
                _kinderfreibetrag = 0;
            }

            userValues.Remove("kinder");
            userValues.Add("kinder", hasKinder);
            userValues.Remove("kinderfreibetrag");
            userValues.Add("kinderfreibetrag", _kinderfreibetrag);
        }

        private void input_only_numbers(object sender, TextCompositionEventArgs e)
        {
            char input = char.Parse(e.Text);
            if (input < '0' || input > '9') {
                e.Handled = true; 
                return;
            }
        }

        private void on_submit_the_caluation(object sender, RoutedEventArgs e)
        {
            // view programm abgespeckte class der lohnsteuerprogramms (nur die sachen die benötigt werden)
            // caluation programm full class der lohnsteuerprogramms
            // MMF Memorey mapped file
            // 1 speichern von wichtigen sachen (class needs for the calcuation (values))
            // 2 startet er das prgamm
            // 3 warten auf endergebnis
            // 4 ausgabe in die view

            MessageBox.Show("KEKS " + abrechnungsjahr.Text);

            // "brutto 3000"
            // split ' '
            // "brutto" "3000"
            // key("brutto") value(Convert.ToInt32);

            using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("kekse",10000))
            {
                bool mutexCreated;
                Mutex mutex = new Mutex(true, "BruttoNettoRechner" , out mutexCreated);
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    BinaryWriter bwriter = new BinaryWriter(stream);
                }
            }
        }
    }
}