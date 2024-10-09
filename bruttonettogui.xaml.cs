using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace brutto_netto_rechner_ui
{
    /// <summary>
    /// Interaction logic for Bruttonettogui.xaml
    /// </summary>
    public partial class Bruttonettogui : Window
    {
        public Bruttonettogui()
        {
            InitializeComponent();
        }

        private void krankenversicherung_onChanged(object sender,SelectionChangedEventArgs e)
        {
            ComboBox krankenversicherung = (ComboBox) sender;

            if (privatversicherung_Panel == null)
            {
                return;
            }

            if (krankenversicherung.Text.Equals("private Versicherung"))
            {
                privatversicherung_Panel.Visibility = Visibility.Collapsed;
                arbeitgeberzuschuss_Panel.Visibility = Visibility.Collapsed;
                krankenkassen_zusatzbeitrag_Panel.Visibility = Visibility.Visible;
            }
            else
            {
                privatversicherung_Panel.Visibility = Visibility.Visible;
                arbeitgeberzuschuss_Panel.Visibility = Visibility.Visible;
                krankenkassen_zusatzbeitrag_Panel.Visibility = Visibility.Collapsed;
            }
        }

        private void kinder_onChecked(object sender, RoutedEventArgs e)
        {
            if (kinder == null)
            {
                return;
            }

            if (kinder.IsChecked.GetValueOrDefault())
            {
                kinderfreibetrag_Panel.Visibility = Visibility.Visible;
            }
            else
            {
                kinderfreibetrag_Panel.Visibility = Visibility.Collapsed;
            }
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


        }
    }
}