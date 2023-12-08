using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatroom
{
    public class Query 
    {
        ChatRoomForm chatRoomForm;

        public Query(ChatRoomForm _chatRoomForm)
        {
            chatRoomForm = _chatRoomForm;
        }
        //public string LogData = "";
        private string LogData = "server=192.168.156.7;user=igor;database=chatroom;port=3306;password=Database123";
        private string SqlQuery = "SELECT * FROM `test1`";
        private bool LoggedInCheck = true;

        public string Login(string LoginData)
        {
            string data = "connection failed";
            LogData = LoginData;
            MySqlConnection conn = new MySqlConnection(LoginData);
            try
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    data = rdr[0] + " -- " + rdr[1];
                    if (data == "1 -- test")
                    {
                        data = "connected succesfully";
                        LoggedInCheck = true;
                    }
                    else
                    {
                        data = "connection failed";
                        LoggedInCheck = false;
                    }
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                data = ex.ToString();
            }
            conn.Close();
            return data;
        }

        public string SendQuery(string LoginData, string SqlQueryRequest)
        {
            if (LoggedInCheck)
            {
                string result = "failure";
                MySqlConnection conn = new MySqlConnection(LoginData);
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(SqlQueryRequest, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        result = rdr[0].ToString();
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    result = ex.ToString();
                }
                conn.Close();
                return result;
            }
            else
            {
                return "Not logged in yet";
            }
        }

        public string GetChatHistory(string LoginData, string SqlQueryRequest, int TableLength)
        {
                string result = "succes";
                MySqlConnection conn = new MySqlConnection(LoginData);
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(SqlQueryRequest, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                            int pos = 0;
                            chatRoomForm.DataToList(rdr[pos].ToString(), rdr[pos + 1].ToString(), Convert.ToDateTime(rdr[pos + 2]));
                            pos =+ 3;                      
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    result = ex.ToString();
                }
                conn.Close();
                return result;
        }

        public string InsertData(string LoginData, string Query)
        {
            string result = "fail";
            MySqlConnection conn = new MySqlConnection(LoginData);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                result = "Database updated succesfully";
            }
            catch (Exception ex)
            {
                result = "Error:" + ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}
