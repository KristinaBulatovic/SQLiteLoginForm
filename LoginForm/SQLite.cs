using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace LoginForm
{
    class SQLite
    {
        SQLiteConnection sql_conn;
        public void Connection_SQLite(string url)
        {
            sql_conn = new SQLiteConnection("Data Source= " + url + ";Version=3;");
            sql_conn.Open();
        }
        public bool Read_SQLite(string username, string password, string account)
        {
            Connection_SQLite("login.db");

            string sql = "select * from login";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            bool t = false;
            if (account == "login")
            {
                while (reader.Read())
                {

                    if (username == reader.GetString(0) && password == reader.GetString(1))
                    {
                        t = true;
                    }
                }
            }
            else if (account == "signup")
            {
                while (reader.Read())
                {

                    if (username == reader.GetString(0))
                    {
                        t = true;
                    }
                }
            }

            return t;
        }

        public string Add_SQLite(string userename, string password, string permissions)
        {
            Connection_SQLite("login.db");
            using (SQLiteConnection con = new SQLiteConnection(sql_conn))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = "INSERT INTO login (username,password,permissions) VALUES (@username,@password,@permissions)";
                    cmd.Connection = con;

                    bool t = Read_SQLite(userename,password,"signup");
                    if (!t)
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@username", userename));
                        cmd.Parameters.Add(new SQLiteParameter("@password", password));
                        cmd.Parameters.Add(new SQLiteParameter("@permissions", permissions));

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            return "User Created Successfuly ......";
                        }
                        else return "User wasn't created successfuly ......";
                    }
                    else return "User already exists!!!";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            }
        }

        public string Permissions_SQLite(string username)
        {
            Connection_SQLite("login.db");

            string sql = "select * from login";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            string p = "";
            while (reader.Read())
            {

                if (username == reader.GetString(0))
                {
                    p = reader.GetString(2);
                }
            }

            return p;
        }

        public void Close_SQLite()
        {
            sql_conn.Close();
        }
      
    }
}
        
