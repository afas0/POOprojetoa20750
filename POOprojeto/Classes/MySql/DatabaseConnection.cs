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
                    if (OpenConnection())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    //MessageBox.Show("Connection successful");

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                    Console.WriteLine("test)");
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
                string query = $"SELECT nome FROM cliente";
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


        //ADD 
        public bool AddNewTicketToDb(string nomeCliente, string ticketDescricao, DateTime dataCriacao, string tipoAssistencia, string estadoAssistencia)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO Ticket (nomeCliente, ticketDescricao, dataCriacao, tipoAssistencia, estadoAssistencia) VALUES (@nomeCliente, @ticketDescricao, @dataCriacao, @tipoAssistencia, @estadoAssistencia)";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@nomeCliente", nomeCliente);
                cmd.Parameters.AddWithValue("@ticketDescricao", ticketDescricao);
                cmd.Parameters.AddWithValue("@dataCriacao", dataCriacao);
                cmd.Parameters.AddWithValue("@tipoAssistencia", tipoAssistencia);
                cmd.Parameters.AddWithValue("@estadoAssistencia", estadoAssistencia);

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
        //cria uma lista para depois listar 
        public List<Ticket> RetrieveTickets()
        {
            List<Ticket> tickets = new List<Ticket>();

            try
            {
                connection.Open();
                string query = "SELECT * FROM Ticket";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            Console.WriteLine($"NomeCliente: {reader.GetString("NomeCliente")}"); //testar a ver se esta a ler
                            Console.WriteLine($"TicketDescricao: {reader.GetString("TicketDescricao")}");
                            Ticket ticket = new Ticket()
                            {
                                // Retrieve values only after calling Read()
                                TicketId = reader.GetInt32("TicketId"),
                                NomeCliente = reader.GetString("NomeCliente"),
                                TicketDescricao = reader.GetString("TicketDescricao"),
                                DataCriacao = reader.GetDateTime("DataCriacao"),
                                Operador = reader.IsDBNull(reader.GetOrdinal("Operador")) ? null : reader.GetString("Operador"),
                                TipoAssistencia = reader.GetString("TipoAssistencia"),
                                EstadoAssistencia = reader.GetString("EstadoAssistencia")
                            };
                            tickets.Add(ticket);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error reading values: " + ex.Message);
                            // Handle or log the exception as needed
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                foreach (Ticket ticket in tickets)
                {
                    Console.WriteLine($"Ticket ID: {ticket.TicketId}");
                    Console.WriteLine($"NomeCliente: {ticket.NomeCliente}");
                    Console.WriteLine($"TicketDescricao: {ticket.TicketDescricao}");
                    Console.WriteLine($"DataCriacao: {ticket.DataCriacao}");
                    Console.WriteLine($"Operador: {ticket.Operador}");
                    Console.WriteLine($"TipoAssistencia: {ticket.TipoAssistencia}");
                    Console.WriteLine($"EstadoAssistencia: {ticket.EstadoAssistencia}");
                    Console.WriteLine(); // Empty line for separation between tickets
                }
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return tickets;
        }

        public bool AddNewOperadorToDb(string nome, string especialidade)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO operador (nome, especialidade) VALUES (@nome, @especialidade)";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@especialidade", especialidade);

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
        //atribur ticket
        public bool AtribuirOperadorToDb(string nome, int id)
        {
            try
            {
                connection.Open();

                string query = "UPDATE ticket SET operador = @newValue WHERE ticketid = @ticketid";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                

                cmd.Parameters.AddWithValue("@newValue", nome);
                cmd.Parameters.AddWithValue("@ticketid", id);


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
       
        public List<Operador> RetrieveOperadores()
        {
            List<Operador> operadores = new List<Operador>();

            try
            {
                connection.Open();
                string query = "SELECT * FROM operador";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            Operador operador = new Operador()
                            {
                                // Retrieve values only after calling Read()
                                Id = reader.GetInt32("id"),
                                Nome = reader.GetString("nome"),
                            };
                            operadores.Add(operador);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error reading values: " + ex.Message);
                            // Handle or log the exception as needed
                        }
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

            return operadores;
        }

        public bool AddNewProdutoToDb(string nome, string descricao)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO produto (nome, descricao) VALUES (@nome, @descricao)";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@descricao", descricao);

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
    }
}