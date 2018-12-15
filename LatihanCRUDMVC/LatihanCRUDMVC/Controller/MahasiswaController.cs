using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using LatihanCRUDMVC.Model.Context;
using LatihanCRUDMVC.Model.Entity;
using LatihanCRUDMVC.Model.Repository;
using System.Data.OleDb;


namespace LatihanCRUDMVC.Controller
{
    public class MahasiswaController
    {

        private MahasiswaRepository _repository;

        public int Save(Mahasiswa obj)
        {
            var result = 0;

            if (string.IsNullOrEmpty(obj.npm))
            {
                MessageBox.Show("NPM harus Diisi !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(obj.nama))
            {
                MessageBox.Show("Nama harus Diisi !!!");
                return 0;
            }

            using (var context = new DbContext())
            {
                _repository = new MahasiswaRepository(context);
                result = _repository.Save(obj);
            }
            return result;
        }

    }
}