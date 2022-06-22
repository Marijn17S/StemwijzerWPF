using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Stemwijzer.Classes
{
    class StemwijzerDB
    {
        private MySqlConnection _connection = new MySqlConnection("Server=5.255.90.119;Database=verkiezingenprj3;Uid=school;Pwd=NlZR+3!?*q&-S@X4X1;SslMode=None;PORT=3306;");

        public DataView getData(string table)
        {
            _connection.Open();
            DataTable uitslag = new DataTable();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                //cmd.CommandText = "SELECT d.driver_id, d.name, d.car_number, d.team_id, t.teamname, d.teammate_carnumber, tm.driver_id as teammate_id, tm.name as tmname FROM drivers d INNER JOIN teams t on d.team_id = t.team_id INNER JOIN drivers tm ON tm.teammate_carnumber = d.car_number ORDER BY d.driver_id";
                cmd.CommandText = $"SELECT * from {table}";
                //cmd.Parameters.AddWithValue("@table", table);
                MySqlDataReader reader = cmd.ExecuteReader();

                uitslag.Load(reader);
            }
            catch (Exception)
            {
                
            }
            finally
            {
                _connection.Close();
            }

            return uitslag.DefaultView;
        }

        public DataView getPartijen()
        {
            _connection.Open();
            DataTable uitslag = new DataTable();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                //cmd.CommandText = "SELECT d.driver_id, d.name, d.car_number, d.team_id, t.teamname, d.teammate_carnumber, tm.driver_id as teammate_id, tm.name as tmname FROM drivers d INNER JOIN teams t on d.team_id = t.team_id INNER JOIN drivers tm ON tm.teammate_carnumber = d.car_number ORDER BY d.driver_id";
                cmd.CommandText = "SELECT * from partij";

                MySqlDataReader reader = cmd.ExecuteReader();

                uitslag.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }

            return uitslag.DefaultView;
        }

        public bool AddPartij(string naam, string adres, string postcode, string gemeente, string emailadres, string telefoonnummer)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO partij (naam, adres, postcode, gemeente, emailadres, telefoonnummer) VALUES (@naam, @adres, @postcode, @gemeente, @emailadres, @telefoonnummer)";
                cmd.Parameters.AddWithValue("@naam", naam);
                cmd.Parameters.AddWithValue("@adres", adres);
                cmd.Parameters.AddWithValue("@postcode", postcode);
                cmd.Parameters.AddWithValue("@gemeente", gemeente);
                cmd.Parameters.AddWithValue("@emailadres", emailadres);
                cmd.Parameters.AddWithValue("@telefoonnummer", telefoonnummer);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool AddThema(string thema)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO thema (thema) VALUES (@thema)";
                cmd.Parameters.AddWithValue("@thema", thema);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool AddStandpunt(string thema_id, string standpunt)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO standpunt (thema_id, standpunt) VALUES (@thema_id, @standpunt)";
                cmd.Parameters.AddWithValue("@thema_id", thema_id);
                cmd.Parameters.AddWithValue("@standpunt", standpunt);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }
        public bool AddVerkiezingsoort(string verkiezingsoort)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO verkiezingsoort (verkiezingsoort) VALUES (@verkiezingsoort)";
                cmd.Parameters.AddWithValue("@verkiezingsoort", verkiezingsoort);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }
        public bool AddVerkiezing(string verkiezingsoortID, string datum)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO verkiezing (verkiezingsoortID, datum) VALUES (@verkiezingsoortID, @datum)";
                cmd.Parameters.AddWithValue("@verkiezingsoortID", verkiezingsoortID);
                cmd.Parameters.AddWithValue("@datum", datum);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool AddVerkiezingspartij(string verkiezingID)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO partij_verkiezing (verkiezingID) VALUES (@verkiezingID)";
                cmd.Parameters.AddWithValue("@verkiezingID", verkiezingID);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool UpdatePartij(string id, string naam, string adres, string postcode, string gemeente, string emailadres, string telefoonnummer)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "UPDATE partij SET naam = @naam, adres = @adres, postcode = @postcode, gemeente = @gemeente, emailadres = @emailadres, telefoonnummer = @telefoonnummer WHERE partij_id = @partij_id";
                cmd.Parameters.AddWithValue("@partij_id", id);
                cmd.Parameters.AddWithValue("@naam", naam);
                cmd.Parameters.AddWithValue("@adres", adres);
                cmd.Parameters.AddWithValue("@postcode", postcode);
                cmd.Parameters.AddWithValue("@gemeente", gemeente);
                cmd.Parameters.AddWithValue("@emailadres", emailadres);
                cmd.Parameters.AddWithValue("@telefoonnummer", telefoonnummer);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool UpdateThema(string id, string thema)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "UPDATE thema SET thema = @thema WHERE thema_id = @thema_id";
                cmd.Parameters.AddWithValue("@thema_id", id);
                cmd.Parameters.AddWithValue("@thema", thema);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool DeletePartij(int id)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "DELETE FROM partij WHERE partij_id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool DeleteThema(int id)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "DELETE FROM teams WHERE team_id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
