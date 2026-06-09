using System;
using System.Data;

namespace PROJEKANN.model
{
    public class ModelTransaksi
    {
        public string NamaAsliUser { get; set; }
        public DataTable TabelTransaksiAktif { get; set; }
    }
}