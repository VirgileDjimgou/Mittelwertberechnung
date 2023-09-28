using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Mittelwertberechnung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Initialisierung der mittelWert
        double bisher_eingegebenZahlen = 0.0;
        double mittelWert = 3.14159;
        double neuenZahl = 0;
        int anzahlWerte = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Configure the message box to be displayed
            string messageBoxText = "Programm beenden ?";
            string caption = "Mittelwertberechnung beenden";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            

            // Display message box
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button
                    // beenden oder Programmabschaltung ...
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    // User pressed No button
                    // ...
                    break;
                case MessageBoxResult.Cancel:
                    // User pressed Cancel button
                    // ...
                    break;
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string mValueEingegeben = Eingabe_Zahlen.Text.ToString();
            // zuerst überprüfen, ob es leer ist.
            if (string.IsNullOrEmpty(mValueEingegeben) == false)
            {

                // Berechnung der neue MittelWert  ... 

                // Ich addiere den aktuellen eingegebenen Wert zu dem zuvor eingegebenen Wert
                bisher_eingegebenZahlen = bisher_eingegebenZahlen + Double.Parse(mValueEingegeben);

                // Erhöhung von Anzahl der eingegebenen Werte um plus 1 
                anzahlWerte = anzahlWerte + 1;

                /*
                 * //Die Menge der gleitenden Durchschnitte wird iterativ („gleitend“) 
                 * über einen Ausschnitt, das „Fenster“, eines gegebenen Signals berechnet.
                 * 
                 Mit der Formel für das arithmetische Mittel
                 wird dann den gleitenden Durchschnitt für die voherigen Werte berechnen
                 * 
                 * 
                 */

                
                mittelwertTextBox.Text = (bisher_eingegebenZahlen / anzahlWerte).ToString();
                anzahl_werte.Text = anzahlWerte.ToString();

                // Zurücksetzen der Eingabefelder
                Eingabe_Zahlen.Text = "";


            }
            else
            {
                string msg = "Geben Sie einen gültigen Wert ein !";
                MessageBox.Show(msg);
            }

          

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string result = "";
            char[] validChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.' }; // these are ok
            foreach (char c in Eingabe_Zahlen.Text) // Überprüfen Sie jedes Zeichen in der Benutzereingabe
            {
                if (Array.IndexOf(validChars, c) != -1)
                    result += c; // Wenn dies in Ordnung ist, fügen Sie es zum Ergebnis hinzu
            }
            Eingabe_Zahlen.Text = result; // Ändern Sie den Text in die „saubere“ Version, in der illegale Zeichen entfernt wurden.

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
