using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace POOprojeto.Classes
{
    public class ReadFromDb : DatabaseConnection
    {
        readonly private MySqlConnection connection;
        public ReadFromDb()
        {
            connection = new MySqlConnection(GetConnectionString());
        }
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
                            Ticket ticket = new Ticket()
                            {
                                TicketId = reader.GetInt32("TicketId"),
                                NomeCliente = reader.GetString("NomeCliente"),
                                TicketDescricao = reader.GetString("TicketDescricao"),
                                DataCriacao = reader.GetDateTime("DataCriacao"),
                                Operador = reader.IsDBNull(reader.GetOrdinal("Operador")) ? null : reader.GetString("Operador"),
                                TipoAssistencia = reader.GetString("TipoAssistencia"),
                                EstadoAssistencia = reader.GetString("EstadoAssistencia"),
                                NotaAssistencia = reader.IsDBNull(reader.GetOrdinal("avaliacao")) ? (int?)null : reader.GetInt32("avaliacao"),


                            };
                            tickets.Add(ticket);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error reading values: " + ex.Message);
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

            return tickets;
        }

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
                                Especialidade = reader.GetString("especialidade"),
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

        public List<Classes.ResolucaoProblema> RetrieveProblemas()
        {
            List<Classes.ResolucaoProblema> problemas = new List<Classes.ResolucaoProblema>();

            try
            {
                connection.Open();
                string query = "SELECT * FROM problema";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            Classes.ResolucaoProblema problema = new Classes.ResolucaoProblema()
                            {
                                // Retrieve values only after calling Read()
                                IdProblema = reader.GetInt32("id"),
                                Titulo = reader.GetString("titulo"),
                                DescricaoProblema = reader.GetString("descricao"),
                                Id = reader.GetInt32("produtoid")
                            };
                            problemas.Add(problema);
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

            return problemas;
        }

        public List<Classes.Produto> RetrieveProdutos()
        {
            List<Classes.Produto> produtos = new List<Classes.Produto>();

            try
            {
                connection.Open();
                string query = "SELECT * FROM produto";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            Classes.Produto produto = new Classes.Produto()
                            {
                                // Retrieve values only after calling Read()
                                Id = reader.GetInt32("id"),
                                Nome = reader.GetString("nome"),
                                Descricao = reader.GetString("descricao"),
                            };
                            produtos.Add(produto);
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

            return produtos;
        }

        public byte[] GetPdfFileFromDatabase(int id)
        {
            byte[] fileData = null;


            string query = "SELECT documento FROM problema WHERE produtoid = @produtoid"; // Replace with your table and column names
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@produtoid", id);

            try
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Assuming the PDF file content is stored in a column named 'pdf_data'
                        fileData = (byte[])reader["documento"];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                // Handle exceptions as needed
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return fileData;
        }
    }
}
