using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas_Station
{
    public class DB_connector
    {
        public static void Createdb() //only the admin  //Ok
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();


            string sql = "CREATE TABLE workers ( worker_id TEXT, worker_name TEXT, worker_pass TEXT );"; //OK

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE shifts (shift_id TEXT, worker_id TEXT, mish1 TEXT ,mish2 TEXT ,mish3 TEXT ,mish4 TEXT);"; 

            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE deals( deal_id TEXT, deal_total TEXT, deal_type TEXT, deal_desc TEXT, shift_id TEXT);";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();


            m_dbConnection.Close(); 
        }

        internal static void AddNewWorker(string username, string pwd)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "INSERT INTO workers (worker_id,worker_name,worker_pass) " +
                            "VALUES (@worker_id,@worker_name, @worker_pass)";
            SQLiteParameter worker_id_param = new SQLiteParameter(@"worker_id", username); //add new deal id generator
            SQLiteParameter worker_name_param = new SQLiteParameter(@"worker_name", username);
            SQLiteParameter worker_pass_param = new SQLiteParameter(@"worker_pass", pwd);


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(worker_id_param);
            command.Parameters.Add(worker_name_param);
            command.Parameters.Add(worker_pass_param);


            command.Prepare();
            command.ExecuteNonQuery();
            command.Dispose();
            m_dbConnection.Close();
        }

        internal static void DeleteWorker(string worker_id)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "DELETE FROM workers WHERE worker_id like '" + worker_id + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            // command.Prepare();
            command.ExecuteNonQuery();
            // command.Dispose();
            m_dbConnection.Close();
        }

        internal static List<Deal> Get_All_Shift_Deals(string shift_id)
        {
            if (File.Exists("MyDatabase.sqlite") && (new FileInfo("MyDatabase.sqlite").Length != 0))
            {
                string connetion_string = null;
                string database_name = "MyDatabase.sqlite";
                SQLiteConnection connection;
                connetion_string = $"Data Source={database_name};Version=3;";
                connection = new SQLiteConnection(connetion_string);
                try
                {
                    connection.Open();
                    string sql123 = "select * from deals WHERE shift_id ='" + shift_id+"'";

                    List<Deal> tmpshifts = new List<Deal>();
                    SQLiteCommand c123 = new SQLiteCommand(sql123, connection);
                    SQLiteDataReader reader123 = c123.ExecuteReader();
                    while (reader123.Read())
                    {
                        if (!reader123.IsDBNull(1))
                        {
                            tmpshifts.Add(new Deal(reader123["deal_id"].ToString(), reader123["deal_total"].ToString(), reader123["deal_type"].ToString(), reader123["deal_desc"].ToString(), reader123["shift_id"].ToString()));
                        }
                    }
                    c123.Dispose();
                    connection.Close();

                    return tmpshifts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            return null;
        }

        internal static void DeleteShift(string shift_id)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "DELETE FROM shifts WHERE shift_id like '" + shift_id + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            // command.Prepare();
            command.ExecuteNonQuery();
            // command.Dispose();
            m_dbConnection.Close();
        }

        internal static Shift Get_Shift_ByID(string shift_id)
        {
            if (File.Exists("MyDatabase.sqlite") && (new FileInfo("MyDatabase.sqlite").Length != 0))
            {
                string connetion_string = null;
                string database_name = "MyDatabase.sqlite";
                SQLiteConnection connection;
                connetion_string = $"Data Source={database_name};Version=3;";
                connection = new SQLiteConnection(connetion_string);
                try
                {
                    connection.Open();
                    string sql123 = "select * from shifts where shift_id ='" + shift_id+"'";
                    SQLiteCommand c123 = new SQLiteCommand(sql123, connection);
                    SQLiteDataReader reader123 = c123.ExecuteReader();
                    Shift s1 = null;
                    while (reader123.Read())
                    {
                        if (!reader123.IsDBNull(1))
                        {
                            s1 = new Shift(reader123["shift_id"].ToString(), reader123["worker_id"].ToString(), reader123["mish1"].ToString(), reader123["mish2"].ToString(), reader123["mish3"].ToString(), reader123["mish4"].ToString());
                        }
                    }
                    c123.Dispose();
                    connection.Close();
                    return s1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            return null;
        }

        internal static void AddNewShiftToDB(Shift shift)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "INSERT INTO shifts (shift_id,worker_id,mish1,mish2,mish3,mish4) " +
                            "VALUES (@shift_id,@worker_id,@mish1,@mish2,@mish3,@mish4)";
            SQLiteParameter shiftid_param = new SQLiteParameter(@"shift_id", shift.shift_id);
            SQLiteParameter workerid_param = new SQLiteParameter(@"worker_id",shift.worker_id);
            SQLiteParameter mish1_param = new SQLiteParameter(@"mish1", "0");
            SQLiteParameter mish2_param = new SQLiteParameter(@"mish2", "0");
            SQLiteParameter mish3_param = new SQLiteParameter(@"mish3", "0");
            SQLiteParameter mish4_param = new SQLiteParameter(@"mish4", "0");


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(shiftid_param);
            command.Parameters.Add(workerid_param);

            command.Parameters.Add(mish1_param);
            command.Parameters.Add(mish2_param);
            command.Parameters.Add(mish3_param);
            command.Parameters.Add(mish4_param);

            command.Prepare();
            command.ExecuteNonQuery();
            command.Dispose();
            m_dbConnection.Close();
        }

        internal static void DeleteDeal(string deal_id)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
          
            string sql = "DELETE FROM deals WHERE deal_id like '" + deal_id+"'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
           // command.Prepare();
            command.ExecuteNonQuery();
           // command.Dispose();
            m_dbConnection.Close();
        }

        internal static List<Shift> Get_All_Shifts()
        {
            if (File.Exists("MyDatabase.sqlite") && (new FileInfo("MyDatabase.sqlite").Length != 0))
            {
                string connetion_string = null;
                string database_name = "MyDatabase.sqlite";
                SQLiteConnection connection;
                connetion_string = $"Data Source={database_name};Version=3;";
                connection = new SQLiteConnection(connetion_string);
                try
                {
                    connection.Open();
                    string sql123 = "select * from shifts";

                    List<Shift> tmpshifts = new List<Shift>();
                    SQLiteCommand c123 = new SQLiteCommand(sql123, connection);
                    SQLiteDataReader reader123 = c123.ExecuteReader();
                    while (reader123.Read())
                    {
                        if (!reader123.IsDBNull(1))
                        {
                            tmpshifts.Add(   new Shift(reader123["shift_id"].ToString(), reader123["worker_id"].ToString(), reader123["mish1"].ToString(), reader123["mish2"].ToString(), reader123["mish3"].ToString(), reader123["mish4"].ToString()  ));
                        }
                    }
                    c123.Dispose();
                    connection.Close();

                    return tmpshifts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            return null;
        }

        internal static List<Shift> getAllWorkerShifts(string worker_id)
        {
            if (File.Exists("MyDatabase.sqlite") && (new FileInfo("MyDatabase.sqlite").Length != 0))
            {
                string connetion_string = null;
                string database_name = "MyDatabase.sqlite";
                SQLiteConnection connection;
                connetion_string = $"Data Source={database_name};Version=3;";
                connection = new SQLiteConnection(connetion_string);
                try
                {
                    connection.Open();
                    string sql123 = "select * from shifts where worker_id ='" + worker_id+"'";
                    List<Shift> tmpshifts = new List<Shift>();
                    SQLiteCommand c123 = new SQLiteCommand(sql123, connection);
                    SQLiteDataReader reader123 = c123.ExecuteReader();
                    while (reader123.Read())
                    {
                        if (!reader123.IsDBNull(1))
                        {
                            tmpshifts.Add(new Shift(reader123["shift_id"].ToString(),  reader123["worker_id"].ToString(), reader123["mish1"].ToString(), reader123["mish2"].ToString(), reader123["mish3"].ToString(), reader123["mish4"].ToString()  )); //DB_connector.getAllShiftDeals(DB_connector.getShiftById(reader123["shift_id"].ToString()))
                        }
                    }
                    c123.Dispose();
                    connection.Close();

                    return tmpshifts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            return null;
        }

        /*
internal static void RemoveDeal(Deal m)
{
   SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
   m_dbConnection.Open();
   string sql = "DELETE FROM deals WHERE deal_id =" + m.deal_id;
   SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
   command.Prepare();
   command.ExecuteNonQuery();
   command.Dispose();
   m_dbConnection.Close();
}
*/
        internal static void Update_Mish(Service service, string text1, string text2, string text3, string text4)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");

            m_dbConnection.Open();

            string sql = "UPDATE shifts SET mish1 = '" + text1 + "'  WHERE shift_id = @shiftid";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.AddWithValue("@shiftid", service.shift.shift_id);
            command.ExecuteNonQuery();
            command.Dispose();

            sql = "UPDATE shifts SET mish2 = '" + text2 + "'  WHERE shift_id = @shiftid";


            command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.AddWithValue("@shiftid", service.shift.shift_id);
            command.ExecuteNonQuery();
            command.Dispose();

            sql = "UPDATE shifts SET mish3 = '" + text3 + "'  WHERE shift_id = @shiftid";


            command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.AddWithValue("@shiftid", service.shift.shift_id);
            command.ExecuteNonQuery();
            command.Dispose();

            sql = "UPDATE shifts SET mish4 = '" + text4 + "'  WHERE shift_id = @shiftid";


            command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.AddWithValue("@shiftid", service.shift.shift_id);
            command.ExecuteNonQuery();
            command.Dispose();

            m_dbConnection.Close();

        }

        internal static List<Worker> Get_All_Workers()
        {
            if (File.Exists("MyDatabase.sqlite") && (new FileInfo("MyDatabase.sqlite").Length != 0))
            {
                string connetion_string = null;
                string database_name = "MyDatabase.sqlite";
                SQLiteConnection connection;
                connetion_string = $"Data Source={database_name};Version=3;";
                connection = new SQLiteConnection(connetion_string);
                try
                {
                    connection.Open();
                    string sql123 = "select * from workers";
                    List<Worker> tmpworkers = new List<Worker>();
                    SQLiteCommand c123 = new SQLiteCommand(sql123, connection);
                    SQLiteDataReader reader123 = c123.ExecuteReader();
                    while (reader123.Read())
                    {
                        if (!reader123.IsDBNull(1))
                        {
                            tmpworkers.Add(new Worker(reader123["worker_id"].ToString(), reader123["worker_name"].ToString(), reader123["worker_pass"].ToString()));
                        }

                    }
                    c123.Dispose();
                    connection.Close();
                    return tmpworkers;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            return null;
        } //OK

        internal static void UpdateDeal(Deal deal1, string deal_id)
        {

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "UPDATE deals SET deal_type = @deal_type , deal_total =@deal_total , deal_desc = @deal_desc  WHERE deal_id = @deal_id";

            // string sql = "INSERT INTO deals (deal_id,deal_total,deal_type,deal_desc,shift_id,michal_number) " +
            //   "VALUES (@dealid,@dealtotal, @dealtype,@dealdesc,@shiftid,@michalnum)";

            //   SQLiteParameter shiftid_param = new SQLiteParameter(@"shiftid", deal1.shift.shift_id);



            SQLiteParameter deal_type_param = new SQLiteParameter(@"deal_type", deal1.deal_type);
            SQLiteParameter deal_total_param = new SQLiteParameter(@"deal_total", deal1.deal_total);
            SQLiteParameter deal_desc_param = new SQLiteParameter(@"deal_desc", deal1.deal_desc);
            SQLiteParameter deal_id_param = new SQLiteParameter(@"deal_id", deal1.deal_id); //add new deal id generator
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(deal_type_param);
            command.Parameters.Add(deal_total_param);
            command.Parameters.Add(deal_desc_param);
            command.Parameters.Add(deal_id_param);
            //command.Parameters.Add(shiftid_param);    
            command.Prepare();
            command.ExecuteNonQuery();
            command.Dispose();
            m_dbConnection.Close();
        }

        internal static void AddNewDeal(Deal deal1)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "INSERT INTO deals (deal_id,deal_total,deal_type,deal_desc,shift_id) " +
                            "VALUES (@dealid,@dealtotal, @dealtype,@dealdesc,@shiftid)";
            SQLiteParameter dealid_param = new SQLiteParameter(@"dealid", deal1.deal_id); //add new deal id generator
            SQLiteParameter dealtotal_param = new SQLiteParameter(@"dealtotal", deal1.deal_total);
            SQLiteParameter dealtype_param = new SQLiteParameter(@"dealtype", deal1.deal_type);
            SQLiteParameter dealdesc_param = new SQLiteParameter(@"dealdesc", deal1.deal_desc);
            SQLiteParameter shiftid_param = new SQLiteParameter(@"shiftid", deal1.shift_id);

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(dealid_param);
            command.Parameters.Add(dealtotal_param);
            command.Parameters.Add(dealtype_param);
            command.Parameters.Add(dealdesc_param);
            command.Parameters.Add(shiftid_param);

            command.Prepare();
            command.ExecuteNonQuery();
            command.Dispose();
            m_dbConnection.Close();
        }
    }
}

