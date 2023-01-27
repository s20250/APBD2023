using System.Data.Common;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;
using APBD_zad4.DBServices;
using APBD_zad4.Models;

namespace APBD_zad4.DBServices
{
    public class AnimalDbService : IAnimalDbService
    {
        private const string connectionString = "Data Source=db-mssql;Initial Catalog=jd;Integrated Security=True";

        public List<Animal> GetAnimals(string orderBy)
        {
            var animals = new List<Animal>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string[] columnsNames = { "name", "description", "category", "area" };
                    bool isMatched = false;

                    if (!string.IsNullOrEmpty(orderBy))
                    {
                        foreach (var columnName in columnsNames)
                            if (orderBy.ToLower().Equals(columnName))
                                isMatched = true;

                        if (isMatched)
                            command.CommandText = $"SELECT * FROM Animal ORDER BY {orderBy} ASC";
                        else throw new Exception("No Matched Column Name");
                    }
                    else command.CommandText = "SELECT * FROM Animal ORDER BY Name ASC";

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

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
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand())
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
        }
    }
}


    
