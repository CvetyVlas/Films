using Films.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Data
{
    class FilmData
    {
        public List<Film> GetAll()
        {
            var FilmList = new List<Film>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM film_records", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                        while (reader.Read())
                        {
                            var Film = new Film(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3)
                            );

                            FilmList.Add(Film);
                        }

                }
                connection.Close();
            }

            return FilmList;
        }

        public Film Get(int id)
        {
            Film Film = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM film_records WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        Film = new Film(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3)
                        );
                    }
                }

                connection.Close();
            }

            return Film;
        }

        public void Add(Film Film)
        {
            using (var connection = Database.GetConnection()){
                var command = new SqlCommand("INSERT INTO film_records (Title, Fans, Year) VALUES(@title, @fans, @year)", connection);
                command.Parameters.AddWithValue("title", Film.Title);
                command.Parameters.AddWithValue("fans", Film.Fans);
                command.Parameters.AddWithValue("year", Film.Year);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Film Film)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("UPDATE film_records SET Title=@title, Fans=@fans, Year=@year WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", Film.Id);
                command.Parameters.AddWithValue("title", Film.Title);
                command.Parameters.AddWithValue("fans", Film.Fans);
                command.Parameters.AddWithValue("year", Film.Year);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("DELETE film_records WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
