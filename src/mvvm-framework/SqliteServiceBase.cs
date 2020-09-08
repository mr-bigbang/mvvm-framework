using Microsoft.Data.Sqlite;
using System;

namespace Baumann
{
    public abstract class SqliteServiceBase : ServiceBase
    {
        protected string ConnectionString { get; private set; }

        public SqliteServiceBase(string connectionString) : base()
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            var csb = new SqliteConnectionStringBuilder(connectionString)
            {
                // We always want foreign key support
                ForeignKeys = true
            };
            ConnectionString = csb.ConnectionString;
        }
    }
}
