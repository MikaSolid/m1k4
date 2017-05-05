using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace m1k4.MsSql
{
    public static class DbConnectionExtensions
    {
        public static int ExecuteNonQuery(this DbContext context, string commandText, int timeout = 30) => ExecuteNonQuery(context.Database.GetDbConnection(), commandText, timeout);

        public static int ExecuteNonQuery(this DbConnection connection, string commandText, int timeout = 30)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandTimeout = timeout;
            command.CommandText = commandText;
            return command.ExecuteNonQuery();
        }

        public static T ExecuteScalar<T>(this DbContext context, string commandText, int timeout = 30) => (T)context.Database.GetDbConnection().ExecuteScalar(commandText, timeout);

        public static T ExecuteScalar<T>(this DbConnection connection, string commandText, int timeout = 30) =>  (T) connection.ExecuteScalar(commandText, timeout);

        private static object ExecuteScalar(this DbContext context, string commandText, int timeout) => ExecuteScalar(context.Database.GetDbConnection(), commandText, timeout);

        private static object ExecuteScalar(this DbConnection connection, string commandText, int timeout)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandTimeout = timeout;
            command.CommandText = commandText;
            return command.ExecuteScalar();
        }

        public static DbDataReader ExecuteReader(this DbContext context, string commandText) => ExecuteReader(context.Database.GetDbConnection(), commandText);

        public static DbDataReader ExecuteReader(this DbConnection connection, string commandText)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandText = commandText;
            return command.ExecuteReader();
        }
    }
}
