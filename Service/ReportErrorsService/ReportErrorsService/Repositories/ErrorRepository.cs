using ReportErrorsService.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ReportErrorsService.Repositories
{
    public class ErrorRepository
    {
        public List<Error> GetLastError(int intervalInMinutes, string connectionString)
        {
            var actualTime = DateTime.Now;

            SqlConnection connection;
            List<Error> errorList = new List<Error>();
            string sql = "SELECT * FROM ERROR WHERE CheckErrors IS NULL";

            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var command = new SqlCommand(sql, connection);
                
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var error = new Error();
                        error.ErrorMessage = dataReader["ErrorMessage"].ToString();
                        error.ErrorDate = (DateTime)dataReader["ErrorDate"];
                        errorList.Add(error);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return errorList;
        }
    }
}
