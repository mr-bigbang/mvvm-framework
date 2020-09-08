using System;
using System.Data.SqlClient;

namespace Baumann
{
    public abstract class SqlServiceBase : ServiceBase
    {
        protected string ConnectionStringR { get; private set; }
        protected string ConnectionStringW { get; private set; }

        public SqlServiceBase(string connectionString) : base()
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            var csb = new SqlConnectionStringBuilder(connectionString)
            {
                ApplicationIntent = ApplicationIntent.ReadOnly
            };
            ConnectionStringR = csb.ConnectionString;

            csb.ApplicationIntent = ApplicationIntent.ReadWrite;
            ConnectionStringW = csb.ConnectionString;
        }
    }
}
