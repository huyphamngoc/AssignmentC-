using Assignment1.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Model
{
    class InforModel
    {
        private static ObservableCollection<Infor> listInfor;

        public static ObservableCollection<Infor> GetInfor()
        {
            DataAccess.InitializeDatabase();

            if (listInfor == null)
            {
                listInfor = new ObservableCollection<Entity.Infor>();
            }
            using (SqliteConnection db = new SqliteConnection("Filename=infors_manager.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT * FROM infors";
                SqliteDataReader sqliteData = selectCommand.ExecuteReader();
                Entity.Infor infor;
                while (sqliteData.Read())
                {
                    infor = new Entity.Infor
                    {
                        Id = Convert.ToInt16(sqliteData["id"]),
                        Name = Convert.ToString(sqliteData["name"]),
                        Email = Convert.ToString(sqliteData["email"]),
                        Phone = Convert.ToString(sqliteData["phone"]),
                        Avatar = Convert.ToString(sqliteData["avatar"]),
                        Address = Convert.ToString(sqliteData["address"]),
                    };
                    listInfor.Add(infor);
                }
                db.Close();
            }
            if (listInfor == null)
            {
                listInfor = new ObservableCollection<Entity.Infor>();
            }
            return listInfor;
        }

        public static void SetSongs(ObservableCollection<Entity.Infor> infors)
        {
            listInfor = infors;
        }

        public static void AddInfor(Entity.Infor infor)
        {
            DataAccess.InitializeDatabase();

            using (SqliteConnection db = new SqliteConnection("Filename=infors_manager.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO infors (name, email, phone, address, avatar) VALUES (@name, @email, @phone, @address, @avatar);";
                insertCommand.Parameters.AddWithValue("@name", infor.Name);
                insertCommand.Parameters.AddWithValue("@email", infor.Email);
                insertCommand.Parameters.AddWithValue("@phone", infor.Phone);
                insertCommand.Parameters.AddWithValue("@address", infor.Address);
                insertCommand.Parameters.AddWithValue("@avatar", infor.Avatar);

                insertCommand.ExecuteReader();

                db.Close();
            }
            if (listInfor == null)
            {
                listInfor = new ObservableCollection<Entity.Infor>();
            }
            listInfor.Add(infor);
        }
    }
}
