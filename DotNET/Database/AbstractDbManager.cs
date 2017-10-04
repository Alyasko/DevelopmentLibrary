using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPages.DataAccess.Repositories.MsAccess
{
    public abstract class AbstractDbManager : IDisposable
    {
        protected String DatabaseFilePath = @"";

        protected String ConnectionString = @"";

        protected AbstractDbManager()
        {
            InitializeConnection();

            Connection = new OleDbConnection(ConnectionString);
            Connection.Open();
        }

        protected abstract void InitializeConnection();

        public OleDbCommand CreateCommand(String sql)
        {
            return Command ?? (Command = new OleDbCommand(sql) { Connection = Connection });
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public OleDbConnection Connection { get; private set; }
        public OleDbCommand Command { get; private set; }
    }
}
