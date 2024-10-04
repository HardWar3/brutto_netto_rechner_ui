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

        private void krankenversicherung_combobox_onChanged(object sender,SelectionChangedEventArgs e)
        {
            if (privatversicherung_comboboxItem == null)
            {
                return;
            }

            if (privatversicherung_comboboxItem.IsSelected)
            {
                privatversicherung_Panel.Visibility = Visibility.Visible;
            }
            else
            {
                privatversicherung_Panel.Visibility = Visibility.Collapsed;
            }
        }

        private void kinder_ja_radioButton_onChecked(object sender, RoutedEventArgs e)
        {
            if (kinder_ja_radioButton == null)
            {
                return;
            }

            if (kinder_ja_radioButton.IsChecked.GetValueOrDefault())
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

            MessageBox.Show("KEKS");
        }
    }
}