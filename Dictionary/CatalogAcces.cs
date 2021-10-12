using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Dictionary
{
    class CatalogAcces
    {
        private string connectionString;

        public CatalogAcces(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }


        /// <summary>
        /// Getting data from the SQLite database
        /// </summary>
        /// <param name="unit">number of the Unit</param>
        /// <returns>Array with all information about certain Unit from the params</returns>
        public DictClass[] GetInfoByUnit(int unit = 1)
        {
            List<DictClass> result = new List<DictClass>();
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();

                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT * FROM units WHERE unit = @unit";
                command.Parameters.AddWithValue("@unit", unit);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new DictClass(id: reader.GetInt32(0),
                                                unit: reader.GetInt32(1),
                                                name: reader.GetString(2),
                                                info: reader.GetString(3),
                                                pic: reader.GetString(4),
                                                link: reader.GetString(5)));
                    }
                }
                Connection.Close();
            }
            return result.ToArray();
        }
        /// <summary>
        /// Get all Fields from the database
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>Array with all fields of data from database</returns>
        public DictClass[] ShowAll()
        {
            List<DictClass> result = new List<DictClass>();
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();

                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT * FROM units";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new DictClass(id: reader.GetInt32(0),
                                                unit: reader.GetInt32(1),
                                                name: reader.GetString(2),
                                                info: reader.GetString(3),
                                                pic: reader.GetString(4),
                                                link: reader.GetString(5)));
                    }
                }
                Connection.Close();
            }
            return result.ToArray();
        }
        /// <summary>
        /// Create new field in the database
        /// </summary>
        /// <param name="field"></param>
        public void CreateNewField(DictClass field)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO 
                units ( unit, name, info, pic, link ) 
                VALUES ( @unit, @name, @info, @pic, @link )";

                command.Parameters.AddWithValue("@unit", field.Unit);
                command.Parameters.AddWithValue("@name", field.Name);
                command.Parameters.AddWithValue("@info", field.Info);
                command.Parameters.AddWithValue("@pic", field.Pic);
                command.Parameters.AddWithValue("@link", field.Link);
                
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }
        /// <summary>
        /// Update field by ID
        /// </summary>
        /// <param name="field"></param>
        public void UpdateField(DictClass field)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE units SET 
                unit = @unit, name = @name, info = @info, pic = @pic, link = @link
                WHERE id = @id";

                command.Parameters.AddWithValue("@id", field.Id);
                command.Parameters.AddWithValue("@unit", field.Unit);
                command.Parameters.AddWithValue("@name", field.Name);
                command.Parameters.AddWithValue("@info", field.Info);
                command.Parameters.AddWithValue("@pic", field.Pic);
                command.Parameters.AddWithValue("@link", field.Link);

                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        /// <summary>
        /// Delete field by ID
        /// </summary>
        /// <param name="field"></param>
        public void DeleteField(DictClass field)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM units
                                      WHERE id = @id";

                command.Parameters.AddWithValue("@id", field.Id);

                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public DictClass GetInfoById(int id)
        {
            int unit = 0;
            string name = "name";
            string info = "info";
            string pic = "picture";
            string link = "link";
            var result = new DictClass(unit, name, info, pic, link);
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();

                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT * FROM units WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = (new DictClass(id: reader.GetInt32(0),
                                                unit: reader.GetInt32(1),
                                                name: reader.GetString(2),
                                                info: reader.GetString(3),
                                                pic: reader.GetString(4),
                                                link: reader.GetString(5)));
                    }
                }
                Connection.Close();
            }
            return result;
        }
    }
}