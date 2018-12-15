using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using LatihanCRUDMVC.Model.Context;
using LatihanCRUDMVC.Model.Entity;

namespace LatihanCRUDMVC.Model.Repository
{
    public class MahasiswaRepository
    {
        public DbContext _context;

        public MahasiswaRepository(DbContext context)
        {
            _context = context;
        }

        public int Save(Mahasiswa obj)
        {
            var result = 0;

            var sql = @"insert into mahasiswa (npm, nama, angkatan)
                        values (@npm, @nama, @angkatan)";
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                cmd.Parameters.AddWithValue("@npm", obj.npm);
                cmd.Parameters.AddWithValue("@nama", obj.nama);
                cmd.Parameters.AddWithValue("@angkatan", obj.angkatan);

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Update(Mahasiswa obj)
        {
            var result = 0;

            var sql = @"update mahasiswa set nama = @nama, angkatan = @angkatan where npm = @npm";
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                cmd.Parameters.AddWithValue("@npm", obj.npm);
                cmd.Parameters.AddWithValue("@nama", obj.nama);
                cmd.Parameters.AddWithValue("@angkatan", obj.angkatan);

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Delete(Mahasiswa obj)
        {
            var result = 0;

            var sql = @"delete from mahasiswa where npm = @npm";
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                cmd.Parameters.AddWithValue("@npm", obj.npm);
                cmd.Parameters.AddWithValue("@nama", obj.nama);
                cmd.Parameters.AddWithValue("@angkatan", obj.angkatan);

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public List<Mahasiswa> GetAll()
        {
            var List = new List<Mahasiswa>();

            var sql = @"select npm, nama, angkatan form mahasiswa order by nama";

            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                using (var dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        var mhs = new Mahasiswa();

                        mhs.npm = dtr["npm"] == DBNull.Value ? string.Empty : dtr["npm"].ToString();
                        mhs.nama = dtr["nama"] == DBNull.Value ? string.Empty : dtr["nama"].ToString();
                        mhs.angkatan = dtr["angkatan"] == DBNull.Value ? string.Empty : dtr["angkatan"].ToString();


                        List.Add(mhs);
                    }
                }
            }
            return List;
        }
    }


}
