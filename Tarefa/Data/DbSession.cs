using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Tarefa.Data
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public IConfiguration _configuration { get; }

        public DbSession(IConfiguration configuration)
        {
            _configuration = configuration;
            var conexaoSQLServer = _configuration.GetConnectionString("DefaultConnection");
            Connection = new SqlConnection(conexaoSQLServer);
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}
