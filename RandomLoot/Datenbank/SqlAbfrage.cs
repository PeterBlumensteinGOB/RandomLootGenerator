using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flaschendrehen.SqlConn;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Flaschendrehen.Datenbank
{
    class SqlAbfrage
    {
        public void insertUser(string username, string groupname)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            string sql = "Insert into user (Name,`Group`) " +
                    " values (@username, @group) ";
            cmd.CommandText = sql;

            int groupId = getGroupId(groupname);
            if (groupId != 0)
            {
                // Ein Objekt Parameter erstellen. Kurzform siehe unten
                MySqlParameter usernameParameter = new MySqlParameter("@username", MySqlDbType.VarChar);
                usernameParameter.Value = username;
                cmd.Parameters.Add(usernameParameter);

                cmd.Parameters.Add("@group", MySqlDbType.Int32).Value = groupId;

                int rowCount = cmd.ExecuteNonQuery();
                //MessageBox.Show("Row Count affected = " + rowCount);
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        public void insertGroup(string groupname)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            string sql = "Insert into usergroups (Groupname) " +
                    " values (@groupname) ";
            cmd.CommandText = sql;

            int groupId = getGroupId(groupname);
            if (groupId == 0)
            {
                cmd.Parameters.Add("@groupname", MySqlDbType.VarChar).Value = groupname;

                int rowCount = cmd.ExecuteNonQuery();
                //MessageBox.Show("Row Count affected = " + rowCount);
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        public int getGroupId(string groupname)
        {
            string sql = "Select Id From usergroups Where Groupname = @groupname";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@groupname", MySqlDbType.VarChar).Value = groupname;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            return 0;
                        }
                        int empId = Convert.ToInt32(reader.GetValue(0));
                        return empId;
                    }
                }
            }
            return 0;
        }

        public List<string> getUserOfGroup(string groupname)
        {
            string sql = "Select Name From user" +
                " Join usergroups on user.Group = usergroups.Id" +
                " Where Groupname = @groupname";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@groupname", MySqlDbType.VarChar).Value = groupname;
            var users = new List<string>();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            return users;
                        }
                        string user = Convert.ToString(reader.GetValue(0));
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public List<string> getGroups()
        {
            string sql = "Select Groupname From usergroups";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;
            var users = new List<string>();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            return users;
                        }
                        string user = Convert.ToString(reader.GetValue(0));
                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}
