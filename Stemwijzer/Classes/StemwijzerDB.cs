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

        // READ

        public DataView getData(string table)
        {
            _connection.Open();
            DataTable uitslag = new DataTable();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = $"SELECT * from {table}";
                MySqlDataReader reader = cmd.ExecuteReader();

                uitslag.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _connection.Close();
            }

            return uitslag.DefaultView;
        }

        // CREATE

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

        public bool AddVerkiezingspartij(string partij_id, string verkiezingID)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO partij_verkiezing (partij_id, verkiezingID) VALUES (@partij_id, @verkiezingID)";
                cmd.Parameters.AddWithValue("@partij_id", partij_id);
                cmd.Parameters.AddWithValue("@verkiezingID", verkiezingID);
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

        // UPDATE

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

        public bool UpdateStandpunt(string standpunt_id, string standpunt)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "UPDATE standpunt SET standpunt = @standpunt WHERE standpunt_id = @standpunt_id";
                cmd.Parameters.AddWithValue("@standpunt_id", standpunt_id);
                cmd.Parameters.AddWithValue("@standpunt", standpunt);
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

        public bool UpdateVerkiezingsoort(string id, string verkiezingsoort)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "UPDATE verkiezingsoort SET verkiezingsoort = @verkiezingsoort WHERE verkiezingsoort_id = @verkiezingsoort_id";
                cmd.Parameters.AddWithValue("@verkiezingsoort_id", id);
                cmd.Parameters.AddWithValue("@verkiezingsoort", verkiezingsoort);
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

        public bool UpdateVerkiezing(string id, string verkiezingsoortID, string datum)
        {
            MessageBox.Show(verkiezingsoortID);
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "UPDATE verkiezing SET verkiezingsoortID = @verkiezingsoortID, datum = @datum WHERE verkiezing_id = @verkiezing_id";
                // Datum toevoegen aan query met datum picker control in column
                cmd.Parameters.AddWithValue("@verkiezing_id", id);
                cmd.Parameters.AddWithValue("@verkiezingsoortID", verkiezingsoortID);
                cmd.Parameters.AddWithValue("@datum", datum);
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

        public bool UpdateVerkiezingspartij(string partij_id, string verkiezingID)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "UPDATE partij_verkiezing SET partij_id = @partij_id WHERE verkiezingID = @verkiezingID";
                cmd.Parameters.AddWithValue("@partij_id", partij_id);
                cmd.Parameters.AddWithValue("@verkiezingID", verkiezingID);
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

        /*public bool DeletePartij(int id)
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
        }*/

        // DELETE
        public bool DeleteRow(string id, string table, string identifier)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = $"DELETE FROM {table} WHERE {identifier} = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool DeletePartij(string id)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = $"DELETE FROM partij_standpunt WHERE partij_id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"DELETE FROM partij_verkiezing WHERE partij_id = @id";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"DELETE FROM partij WHERE partij_id = @id";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
