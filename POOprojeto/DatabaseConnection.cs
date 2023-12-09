using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace POOprojeto
{
    public class DatabaseConnection
    {
        private readonly string server = "localhost";
        private readonly string database = "dbpoo";
        private static string usernamedb; //se nao for static nao guarda a variavel
        private static string passworddb;  //se nao for static nao guarda a variavel
        private MySqlConnection connection;

        public DatabaseConnection()
        {
            // Initialize the connection string
            //string connectionString = $"Server={server};Database={database};Uid={usernamedb};Pwd={passworddb};";
            ////this.database = database;
            //this.username = username;
            //this.passoword = passoword;
            connection = new MySqlConnection(GetConnectionString());
        }

        public string GetConnectionString()
        {
            // Construct and return the connection string
            return $"Server={server};Database={database};Uid={usernamedb};Pwd={passworddb};";
        }

        //define as settings do server
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool CheckCredentials(string username, string password)
        {
            if (username == "root")  //admin nao esta em uso para ja na db
            {
                return false;
            }
            else
            {
                usernamedb = username;
                passworddb = password;
                //string connectionString = $"Server={server};Database={database};Uid={usernamedb};Pwd={passworddb};";
                //MySqlConnection connection = new MySqlConnection(connectionString);
                try
                {
                    connection.ConnectionString = GetConnectionString();
                    //connection.Open();
                    //MessageBox.Show("Connection successful");
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    //connection.Close();
                }
            }

        }
        public bool AddNewClientToDb(string clientNome, string clientEmpresa, string clientContacto)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO cliente (nome, empresa, contacto) VALUES (@nome, @empresa, @contacto)";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@nome", clientNome);
                cmd.Parameters.AddWithValue("@empresa", clientEmpresa);
                cmd.Parameters.AddWithValue("@contacto", clientContacto);

                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if rows were affected by the query
                if (rowsAffected > 0)
                {
                    return true; // Insert successful
                }
                else
                {
                    return false; // Insert failed
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; // Insert failed due to exception
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }


        //recebe nomes para uma lista
        public List<string> RetrieveClients()
        {
            List<string> clientes = new List<string>();

            try
            {
                connection.Open();
                //vai procurar o nome apenas da table
                string query = $"SELECT nome FROM cliente"; // Replace 'clients' with your actual table name
                MySqlCommand cmd = new MySqlCommand(query, connection);
                string columnName = "nome";

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string value = reader.GetString(columnName);
                        clientes.Add(value); // Add the created Client object to the list
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return clientes;
        }
    }
}