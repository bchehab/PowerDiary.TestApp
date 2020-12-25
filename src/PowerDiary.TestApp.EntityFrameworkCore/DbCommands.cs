using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace PowerDiary.TestApp.EntityFrameworkCore
{
    public class DbCommands: IDbCommands
    {
        private readonly IConfiguration _configuration;

        public DbCommands(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataTable ExecuteProcedure(string procedureName, SqlParameter[] parameters = null)
        {
            var connectionString = _configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand()
                {
                    CommandText = procedureName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection,
                };

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();

                DataTable table = new DataTable();
                using (var da = new SqlDataAdapter(command))
                {
                    da.Fill(table);
                }
                return table;
            }
        }
    }
}
