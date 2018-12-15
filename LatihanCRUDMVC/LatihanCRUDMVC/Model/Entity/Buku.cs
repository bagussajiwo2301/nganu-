using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanCRUDMVC.Model.Entity
{
    public class Buku
    {
        public string isbn { get; set; }
        public string judul { get; set; }
        public string thn_terbit { get; set; }
        public string bahasa { get; set; }
    }
}
