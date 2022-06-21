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
            catch (Exception ex)
            {

            }
            finally
            {
                _connection.Close();
            }

            return uitslag.DefaultView;
        }

        public DataView getThemas()
        {
            _connection.Open();
            DataTable uitslag = new DataTable();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                //cmd.CommandText = "SELECT t.team_id, t.teamname, t.engine_id, t.main_sponsor, d1.name as driver1, d1.car_number as driver1number, d2.name as driver2, d2.car_number as driver2number, e.company as engine FROM teams t INNER JOIN drivers d1 on t.driver1 = d1.driver_id INNER JOIN drivers d2 ON t.driver2 = d2.driver_id INNER JOIN engines e on t.engine_id = e.engine_id";
                //cmd.CommandText = "SELECT t.team_id, t.teamname, t.engine_id, t.main_sponsor, e.company as engine FROM teams t INNER JOIN engines e on t.engine_id = e.engine_id ORDER BY t.team_id";
                cmd.CommandText = "SELECT * FROM thema";
                MySqlDataReader reader = cmd.ExecuteReader();

                uitslag.Load(reader);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _connection.Close();
            }

            return uitslag.DefaultView;
        }

        public bool AddPartij(string name, string carnumber, string team_id, string teammate_carnumber)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO drivers (name, car_number, team_id, teammate_carnumber) VALUES (@name, @car_number, @team_id, @teammate_carnumber)";

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@car_number", carnumber);
                cmd.Parameters.AddWithValue("@team_id", team_id);
                cmd.Parameters.AddWithValue("@teammate_carnumber", teammate_carnumber);

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

        public bool DeletePartij(int id)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "DELETE FROM drivers WHERE driver_id = @id";
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

        public bool UpdateDriver(int id, string name, string carnumber, string team_id, string teammate_carnumber)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "UPDATE drivers SET name = @name, car_number = @car_number, team_id = @team_id, teammate_carnumber = @teammate_carnumber WHERE driver_id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@car_number", carnumber);
                cmd.Parameters.AddWithValue("@team_id", team_id);
                cmd.Parameters.AddWithValue("@teammate_carnumber", teammate_carnumber);
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

        public bool UpdateTeam(int teamid, string teamname, string engineid, string mainsponsor)
        {
            _connection.Open();
            try
            {
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "UPDATE teams SET teamname = @teamname, engine_id = @engine_id, main_sponsor = @main_sponsor WHERE team_id = @team_id";
                cmd.Parameters.AddWithValue("@team_id", teamid);
                cmd.Parameters.AddWithValue("@teamname", teamname);
                cmd.Parameters.AddWithValue("@engine_id", engineid);
                cmd.Parameters.AddWithValue("@main_sponsor", mainsponsor);
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
