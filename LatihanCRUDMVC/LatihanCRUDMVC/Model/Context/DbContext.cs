using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data;
using System.Data.OleDb;
namespace LatihanCRUDMVC.Model.Context
{
    public class DbContext : IDisposable
    {
        public OleDbConnection _conn;
        // property Conn, untuk menyimpan objek koneksi
        public OleDbConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }
        private OleDbConnection GetOpenConnection()
        {
            var dbName = Directory.GetCurrentDirectory() + "\\DbPerpustakaan.mdb";
            var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", dbName);
            var conn = new OleDbConnection(connectionString);
            conn.Open();
            return conn;
        }
        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
