using Microsoft.Data.SqlClient;
using System.Data;

namespace PowerDiary.TestApp.EntityFrameworkCore
{
    public interface IDbCommands
    {
        DataTable ExecuteProcedure(string procedureName, SqlParameter[] parameters = null);
    }
}