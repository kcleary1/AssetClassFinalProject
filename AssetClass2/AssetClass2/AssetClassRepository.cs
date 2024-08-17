using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using MySql.Data.MySqlClient;
using System.Windows;

namespace AssetClass2
{
    public class AssetClassRepository  // class that is used for MySQL interaction
    {
        private string _connectionString; // field to store database connection string
        public AssetClassRepository(string connectionString) //assigns connection string to above field
        {
            _connectionString = connectionString;
        }
        private IDbConnection Connection // creates and returns new MySQLConnection object with connection string
        {
            get
            {
                return new MySqlConnection(_connectionString);
            }
        }
        public IEnumerable<AssetClass> GetLargeGrowthInfo() //pulls required data from the database for the US Large Growth index
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<AssetClass>("SELECT * FROM uslargegrowth");
            }
        }

        public IEnumerable<AssetClass> GetSmallValueInfo() //pulls required data from the database for the US Small Value index
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<AssetClass>("SELECT * FROM ussmallvalue");
            }
        }
        public IEnumerable<AssetClass> GetTotalBondInfo() //pulls required data from the database for the US Total Bond index
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<AssetClass>("SELECT * FROM ustotalbond");
            }
        }

        public IEnumerable<double> RollingAverage(string tableName, int? year) // method used for getting and returning appropriate rolling average for selected index and year length
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT Highest, Lowest, Average FROM {tableName} WHERE Years = @years";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Years", year);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            double lowest = reader.GetDouble(1);
                            double average = reader.GetDouble(2);
                            double highest = reader.GetDouble(0);
                            return new List<double> { highest, lowest, average }; 
                        }
                        else
                        {
                            return new List<double>();
                        }
                    }
                }
            }
        }

    }
}
