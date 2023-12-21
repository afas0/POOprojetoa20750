using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        readonly private MySqlConnection connection;

        public DatabaseConnection()
        {
            connection = new MySqlConnection(GetConnectionString());
        }

        public string GetConnectionString()
        {
            //define as settings do server
            return $"Server={server};Database={database};Uid={usernamedb};Pwd={passworddb};";
        }

        
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
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
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
        public bool AtribuirOperadorToDb(string nome, int id, string estado)
        {
            try
            {
                connection.Open();

                string query = "UPDATE ticket SET operador = @newValue, EstadoAssistencia = @newValueE WHERE ticketid = @ticketid";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@newValue", nome);
                cmd.Parameters.AddWithValue("@newValueE", estado);
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
        public bool AddNewResolucaoProblemaToDb(string titulo, string descricao, string filepath, int produtoid)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO problema (titulo, descricao, documento, produtoid) VALUES (@titulo, @descricao, @documento, @produtoid)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                byte[] fileContent;
                fileContent = File.ReadAllBytes(filepath);
                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@documento", fileContent);
                cmd.Parameters.AddWithValue("@produtoid", produtoid);
                
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
        public bool AddNewAvaliacaoTicketToDb(int nota, int id, string estado)
        {
            try
            {
                connection.Open();

                string query = "UPDATE ticket SET avaliacao = @newValue, estadoassistencia = @newValueE WHERE ticketid = @ticketid";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@newValue", nota);
                cmd.Parameters.AddWithValue("@newValueE", estado);
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
        public bool AlterarEspecialidadeToDb(string especialidade, int id)
        {
            try
            {
                connection.Open();

                string query = "UPDATE operador SET especialidade = @newValue WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@newValue", especialidade);
                cmd.Parameters.AddWithValue("@id", id);


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