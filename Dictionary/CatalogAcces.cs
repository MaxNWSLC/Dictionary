using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

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
    }
}