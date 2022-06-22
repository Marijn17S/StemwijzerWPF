using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
using Stemwijzer.Classes;

//using Org.BouncyCastle.Asn1.Mozilla;

namespace Stemwijzer
{
    public partial class MainWindow : Window
    {
        StemwijzerDB db = new StemwijzerDB();

        DataGrid activeTable;

        public MainWindow()
        {
            InitializeComponent();
            loadPartijen();
            loadThemas();
            loadStandpunten();
            loadVerkiezingssoorten();
            loadVerkiezingen();
            loadVerkiezingspartijen();

            activeTable = Partijen;
        }

        // READ

        public void loadPartijen()
        {
            const string table = "partij";
            var data = db.getData(table);
            Partijen.ItemsSource = data;
        }

        public void loadThemas()
        {
            const string table = "thema";
            var data = db.getData(table);
            Themas.ItemsSource = data;
        }

        public void loadStandpunten()
        {
            const string table = "standpunt";
            var data = db.getData(table);
            Standpunten.ItemsSource = data;
        }

        public void loadVerkiezingssoorten()
        {
            const string table = "verkiezingsoort";
            var data = db.getData(table);
            Verkiezingssoorten.ItemsSource = data;
        }

        public void loadVerkiezingen()
        {
            const string table = "verkiezing";
            var data = db.getData(table);
            Verkiezingen.ItemsSource = data;
        }

        public void loadVerkiezingspartijen()
        {
            const string table = "partij_verkiezing";
            var data = db.getData(table);
            Verkiezingspartijen.ItemsSource = data;
        }

        // CREATE

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string id;
            if (!(activeTable.SelectedItem is DataRowView selected)) return;

            if (activeTable.Name == "Partijen")
            {
                string naam = selected.Row.ItemArray[1].ToString();
                string adres = selected.Row.ItemArray[2].ToString();
                string postcode = selected.Row.ItemArray[3].ToString();
                string gemeente = selected.Row.ItemArray[4].ToString();
                string emailadres = selected.Row.ItemArray[5].ToString();
                string telefoonnummer = selected.Row.ItemArray[6].ToString();
                if (string.IsNullOrEmpty(naam) || string.IsNullOrEmpty(adres) || 
                    string.IsNullOrEmpty(postcode) || string.IsNullOrEmpty(gemeente) || 
                    string.IsNullOrEmpty(emailadres) || string.IsNullOrEmpty(telefoonnummer)) return;
                MessageBox.Show(db.AddPartij(naam, adres, postcode, gemeente, emailadres, telefoonnummer) ? "Gelukt!" : "Er ging iets mis");
            }
            else if (activeTable.Name == "Themas")
            {
                id = selected.Row.ItemArray[0].ToString();
                MessageBox.Show(db.AddThema(id) ? "Gelukt" : "Mislukt");
            }
            else if (activeTable.Name == "Standpunten")
            {
                id = selected.Row.ItemArray[0].ToString();
                string standpunt = selected.Row.ItemArray[1].ToString();
                MessageBox.Show(db.AddStandpunt(id, standpunt) ? "Gelukt" : "Mislukt");
            }
            else if (activeTable.Name == "Verkiezingssoorten")
            {
                string verkiezingsoort = selected.Row.ItemArray[1].ToString();
                MessageBox.Show(db.AddVerkiezingsoort(verkiezingsoort) ? "Gelukt" : "Mislukt");
            }
            else if (activeTable.Name == "Verkiezingen")
            {
                id = selected.Row.ItemArray[0].ToString();

                MessageBox.Show(db.AddVerkiezing(id, MySqlTimeFormat(DateTime.Now)) ? "Gelukt" : "Mislukt");
            }
            else if (activeTable.Name == "Verkiezingspartijen")
            {
                id = selected.Row.ItemArray[0].ToString();
                MessageBox.Show(db.AddVerkiezingspartij(id) ? "Gelukt" : "Mislukt");
            }

            loadPartijen();
            loadThemas();
        }

        // UPDATE

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string id;
            if (!(activeTable.SelectedItem is DataRowView selected)) return;
            if (activeTable.Name == "Partijen")
            {
                id = selected.Row.ItemArray[0].ToString();
                string naam = selected.Row.ItemArray[1].ToString();
                string adres = selected.Row.ItemArray[2].ToString();
                string postcode = selected.Row.ItemArray[3].ToString();
                string gemeente = selected.Row.ItemArray[4].ToString();
                string emailadres = selected.Row.ItemArray[5].ToString();
                string telefoonnummer = selected.Row.ItemArray[6].ToString();
                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(naam) || string.IsNullOrEmpty(adres) ||
                    string.IsNullOrEmpty(postcode) || string.IsNullOrEmpty(gemeente) ||
                    string.IsNullOrEmpty(emailadres) || string.IsNullOrEmpty(telefoonnummer)) return;
                MessageBox.Show(db.UpdatePartij(id, naam, adres, postcode, gemeente, emailadres, telefoonnummer) ? "Het is gelukt" : "Het is mislukt", "Uitvoering", MessageBoxButton.OK, MessageBoxImage.Information);
                loadPartijen();
            }
            else if (activeTable.Name == "Themas")
            {
                id = selected.Row.ItemArray[0].ToString();
                string thema = selected.Row.ItemArray[1].ToString();
                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(thema)) return;
                MessageBox.Show(db.UpdateThema(id, thema) ? "Het is gelukt" : "Het is mislukt", "Uitvoering", MessageBoxButton.OK, MessageBoxImage.Information);
                loadThemas();
            }
            else return;
        }

        // DELETE

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!(activeTable.SelectedItem is DataRowView selected)) return;

            if (activeTable.Name == "Partijen")
            {
                id = Convert.ToInt32(selected.Row.ItemArray[0]);
                MessageBox.Show(db.DeletePartij(id) ? "Gelukt" : "Mislukt");
                loadPartijen();
            }
            else if (activeTable.Name == "Themas")
            {
                id = Convert.ToInt32(selected.Row.ItemArray[0]);
                MessageBox.Show(db.DeleteThema(id) ? "Gelukt" : "Mislukt");
                loadThemas();
            }
        }

        // SWITCHING

        private void Partijen_OnChecked(object sender, RoutedEventArgs e) { ActivateDataGrid(Partijen); }

        private void Themas_OnChecked(object sender, RoutedEventArgs e) { ActivateDataGrid(Themas); }

        private void Standpunten_OnChecked(object sender, RoutedEventArgs e) { ActivateDataGrid(Standpunten); }

        private void Verkiezingssoorten_OnChecked(object sender, RoutedEventArgs e) { ActivateDataGrid(Verkiezingssoorten); }

        private void Verkiezingen_OnChecked(object sender, RoutedEventArgs e) { ActivateDataGrid(Verkiezingen); }

        private void Verkiezingspartijen_OnChecked(object sender, RoutedEventArgs e) { ActivateDataGrid(Verkiezingspartijen); }

        // METHODS

        private void ActivateDataGrid(DataGrid dg)
        {
            if (Partijen == null || Themas == null || Standpunten == null || Verkiezingssoorten == null || Verkiezingen == null
                || Verkiezingspartijen == null || Verkiezingspartijen == null || activeTable == null) return;
            Partijen.Visibility = Visibility.Hidden;
            Themas.Visibility = Visibility.Hidden;
            Standpunten.Visibility = Visibility.Hidden;
            Verkiezingssoorten.Visibility = Visibility.Hidden;
            Verkiezingen.Visibility = Visibility.Hidden;
            Verkiezingspartijen.Visibility = Visibility.Hidden;

            activeTable = dg;
            dg.Visibility = Visibility.Visible;

            if (dg.Name == "Partijen") loadPartijen();
            if (dg.Name == "Themas") loadThemas();
            if (dg.Name == "Standpunten") loadStandpunten();
            if (dg.Name == "Verkiezingssoorten") loadVerkiezingssoorten();
            if (dg.Name == "Verkiezingen") loadVerkiezingen();
            if (dg.Name == "Verkiezingspartijen") loadVerkiezingspartijen();
        }

        private string MySqlTimeFormat(DateTime dt) { return dt.ToString("yyyy-MM-dd"); }
    }
}
