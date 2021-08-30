/*
 *project = DBAutomation
 * Author = Lavanya Gollapudi
 * Created Date = 20/08/2021
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace DataBaseAutomation
{
    public class SpotifyAutomation
    {
        SpotifyTable table = new SpotifyTable();
        public static string connectionString = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog = SpotifyApp";
        //creating sql connection
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public int InsertRecord_InDatabase()
        {
            using (sqlConnection)
            {
                SqlCommand insertCommand1 = new SqlCommand("INSERT INTO  UsersProfile (Username,Country,Email) VALUES (@0,@1,@2)", sqlConnection);

                //performing insert command
                insertCommand1.Parameters.Add(new SqlParameter("0", "pqr"));
                insertCommand1.Parameters.Add(new SqlParameter("1", "IN"));
                insertCommand1.Parameters.Add(new SqlParameter("2", "pqr@gmail.com"));
                sqlConnection.Open();
                int rows = insertCommand1.ExecuteNonQuery();
                return rows;
            }
        }


        public int retriveData()
        {
            SpotifyTable model = new SpotifyTable();
            int count = 0;
            try
            {
                using (sqlConnection)
                {
                    //Retrieve query
                    string query = @"select * from UsersProfile";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    //open sql connection
                    sqlConnection.Open();
                    //sql reader to read data
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            DisplayDetails(sqlDataReader);
                            count++;
                        }

                    }
                    //close reader
                    sqlDataReader.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                sqlConnection.Close();
            }
            return count;

        }
        //Display the details
        public void DisplayDetails(SqlDataReader sqlDataReader)
        {

            SpotifyTable table = new SpotifyTable();
            table.Id = Convert.ToInt32(sqlDataReader["Id"]);
            table.Username = Convert.ToString(sqlDataReader["Username"]);
            table.Country = Convert.ToString(sqlDataReader["Country"]);
            table.Email = Convert.ToString(sqlDataReader["Email"]);

            Console.WriteLine("Id :{0} Username :{1} Country :{2} Email :{3} ", table.Id, table.Username, table.Country, table.Email);
            Console.WriteLine("\n");
        }
        public int Updatingtable(SpotifyTable table)
        {

            int count = 0;
            try
            {
                using (sqlConnection)
                {
                    //Query Execution(Update)

                    string query = @"update UsersProfile set Country = 'US' where Username='Lalitha'";
                    //Passing the query and dbconnection
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    //Opening the connection
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();

                    if (result != 0)
                    {
                        count++;
                        Console.WriteLine("Updated SuccessFully");

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //closes the connection
                sqlConnection.Close();
            }
            return count;

        }
        public int Delete(SpotifyTable table)
        {
            int count = 0;
            try
            {
                using (sqlConnection)
                {
                    //Query Execution(Delete)
                    string query = @"delete from UsersProfile where Country='IN' and Username='xyz'";
                    //Passing the query and dbconnection
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    //Opening the connection
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        count++;
                        Console.WriteLine("Deleted SuccessFully");

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //closes the connection
                sqlConnection.Close();
            }
            return count;

        }




    }
}
