using System.Data.Common;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;
using APBD_zad4.DBServices;
using APBD_zad4.Models;
using Microsoft.Data.Sqlite;

namespace APBD_zad4.DBServices
{
    public class AnimalDbService : IAnimalDbService
    {
        private const string connectionString = "Data Source=db-mssql;Initial Catalog=jd;Integrated Security=True";

        public List<Animal> GetAnimals(string orderBy)
        {
            var animals = new List<Animal>();
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    string[] columnsNames = { "name", "description", "category", "area" };
                    bool isMatched = false;

                    if (!string.IsNullOrEmpty(orderBy))
                    {
                        foreach (var columnName in columnsNames)
                            if (orderBy.ToLower().Equals(columnName))
                                isMatched = true;

                        if (isMatched)
                        {
                            command.CommandText = @"SELECT * FROM Animal ORDER BY $orderBy ASC";
                            command.Parameters.AddWithValue("$orderBy", orderBy);
                        }

                        else throw new Exception("No Matched Column Name");
                    }
                    else command.CommandText = "SELECT * FROM Animal ORDER BY Name ASC";


                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        animals.Add(new Animal
                        {
                            IdAnimal = int.Parse(reader["IdAnimal"].ToString()),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            Category = reader["Category"].ToString(),
                            Area = reader["Area"].ToString()
                        });
                    connection.Close();
                }
            }

            return animals;
        }

        public void PostAnimal(Animal animal)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText =
                        $"INSERT INTO Animal(Name, Description, Category, Area) VALUES(@name, @description, @category, @area)";
                    command.Parameters.AddWithValue("name", animal.Name);
                    command.Parameters.AddWithValue("description", animal.Description);
                    command.Parameters.AddWithValue("category", animal.Category);
                    command.Parameters.AddWithValue("area", animal.Area);
                    connection.Open();

                    connection.Close();
                }
            }
        }


        public void PutAnimal(int idAnimal, Animal animal)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    connection.Open();

                    command.CommandText = @"SELECT * FROM Animal where ID = $idAnimal ASC";
                    command.Parameters.AddWithValue("$idAnimal", idAnimal);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        command.Parameters.AddWithValue("name", animal.Name);
                        command.Parameters.AddWithValue("description", animal.Description);
                        command.Parameters.AddWithValue("category", animal.Category);
                        command.Parameters.AddWithValue("area", animal.Area);
                    }

                    connection.Close();
                }
            }
        }

        public void DeleteAnimal(int idAnimal)
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Connection = connection;
                        connection.Open();

                        command.Connection = connection;
                        command.CommandText = @"DELETE FROM Animal WHERE idAnimal = @idAnimal";
                        command.Parameters.AddWithValue("idAnimal", idAnimal);


                        connection.Close();
                    }
                }
            }
        }
    }

