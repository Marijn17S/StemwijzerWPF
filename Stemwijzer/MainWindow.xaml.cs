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

            activeTable = Partijen;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Partijen.Visibility == Visibility.Visible && Themas.Visibility == Visibility.Hidden)
            {
                if (!(Partijen.SelectedItem is DataRowView selected)) return;
                int id = Convert.ToInt32(selected.Row.ItemArray[0]);

                MessageBox.Show(db.DeletePartij(id) ? "Gelukt" : "Mislukt");
            }
            else if (Themas.Visibility == Visibility.Visible && Partijen.Visibility == Visibility.Hidden)
            {
                if (!(Themas.SelectedItem is DataRowView selected)) return;
                int id = Convert.ToInt32(selected.Row.ItemArray[0]);

                MessageBox.Show(db.DeleteThema(id) ? "Gelukt" : "Mislukt");
            }
            loadPartijen();
            loadThemas();
        }

        public void loadPartijen()
        {
            var data = db.getPartijen();
            Partijen.ItemsSource = data;
        }

        public void loadThemas()
        {
            var data = db.getThemas();
            Themas.ItemsSource = data;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(Partijen.SelectedItem is DataRowView selected)) return;
            string name = selected.Row.ItemArray[1].ToString();
            string carnumber = selected.Row.ItemArray[2].ToString();
            string teamid = selected.Row.ItemArray[3].ToString();
            string teammatecarnumber = selected.Row.ItemArray[5].ToString();
            MessageBox.Show(db.AddPartij(name, carnumber, teamid, teammatecarnumber) ? "Gelukt!" : "Er ging iets mis");

            loadPartijen();
            loadThemas();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(activeTable.SelectedItem is DataRowView selected)) return;
            MessageBox.Show(selected.Row.ItemArray[0].ToString());
            /*if (Partijen.Visibility == Visibility.Visible && Themas.Visibility == Visibility.Hidden)
            {
                if (!(Partijen.SelectedItem is DataRowView selected)) return;
                int id = Convert.ToInt32(selected.Row.ItemArray[0]);
                string name = selected.Row.ItemArray[1].ToString();
                string carnumber = selected.Row.ItemArray[2].ToString();
                string teamid = selected.Row.ItemArray[3].ToString();
                string teammatecarnumber = selected.Row.ItemArray[5].ToString();
                if (name == string.Empty || carnumber == string.Empty || teamid == string.Empty || carnumber == null) return;
                MessageBox.Show(db.UpdateDriver(id, name, carnumber, teamid, teammatecarnumber) ? "Het is gelukt" : "Het is mislukt", "Uitvoering", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Themas.Visibility == Visibility.Visible && Partijen.Visibility == Visibility.Hidden)
            {
                if (!(Themas.SelectedItem is DataRowView selected)) return;
                int teamid = Convert.ToInt32(selected.Row.ItemArray[0]); // team id
                string teamname = selected.Row.ItemArray[1].ToString(); // teamname
                string engineid = selected.Row.ItemArray[2].ToString(); // engine id
                string mainsponsor = selected.Row.ItemArray[3].ToString(); // main sponsor
                if (teamname == string.Empty || engineid == string.Empty || mainsponsor == null) return;
                MessageBox.Show(db.UpdateTeam(teamid, teamname, engineid, mainsponsor) ? "Het is gelukt" : "Het is mislukt", "Uitvoering", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else return;*/

            loadPartijen();
            loadThemas();
        }

        private void Partijen_OnChecked(object sender, RoutedEventArgs e)
        {
            if (Themas == null || Partijen == null) return;
            Themas.Visibility = Visibility.Hidden;
            Partijen.Visibility = Visibility.Visible;
            activeTable = Partijen;
        }

        private void Themas_OnChecked(object sender, RoutedEventArgs e)
        {
            if (Themas == null || Partijen == null) return;
            Themas.Visibility = Visibility.Visible;
            Partijen.Visibility = Visibility.Hidden;
            activeTable = Themas;
        }
    }
}
