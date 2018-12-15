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
    public class BukuRepository
    {
        public DbContext _context;

        public BukuRepository(DbContext context)
        {
            _context = context;
        }

        public int Save(Buku obj)
        {
            var result = 0;

            var sql = @"insert into buku (isbn, judul, thn_terbit, bahasa)
                        values (@isbn, @judul, @thn_terbit, @bahasa)";
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                cmd.Parameters.AddWithValue("@isbn", obj.isbn);
                cmd.Parameters.AddWithValue("@judul", obj.judul);
                cmd.Parameters.AddWithValue("@thn_terbit", obj.thn_terbit);
                cmd.Parameters.AddWithValue("@bahasa", obj.bahasa);

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Update(Buku obj)
        {
            var result = 0;

            var sql = @"update buku set judul = @judul, thn_terbit = @thn_terbit, bahasa = @bahasa where isbn = @isbn";
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                cmd.Parameters.AddWithValue("@isbn", obj.isbn);
                cmd.Parameters.AddWithValue("@judul", obj.judul);
                cmd.Parameters.AddWithValue("@thn_terbit", obj.thn_terbit);
                cmd.Parameters.AddWithValue("@bahasa", obj.bahasa);

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Delete(Buku obj)
        {
            var result = 0;

            var sql = @"delete from buku where isbn =@isbn";
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                cmd.Parameters.AddWithValue("@isbn", obj.isbn);
                cmd.Parameters.AddWithValue("@judul", obj.judul);
                cmd.Parameters.AddWithValue("@thn_terbit", obj.thn_terbit);
                cmd.Parameters.AddWithValue("@bahasa", obj.bahasa);

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public List<Buku> GetAll()
        {
            var List = new List<Buku>();

            var sql = @"select isbn, judul, thn_terbit, bahasa form buku order by judul";

            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                using (var dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        var bku = new Buku();

                        bku.isbn = dtr["isbn"] == DBNull.Value ? string.Empty : dtr["isbn"].ToString();
                        bku.judul = dtr["judul"] == DBNull.Value ? string.Empty : dtr["judul"].ToString();
                        bku.thn_terbit = dtr["thn_terbit"] == DBNull.Value ? string.Empty : dtr["thn_terbit"].ToString();
                        bku.bahasa = dtr["bahasa"] == DBNull.Value ? string.Empty : dtr["bahasa"].ToString();


                        List.Add(bku);
                    }
                }
            }
            return List;
        }
    }


}
