using System;
using System.Data;

namespace PROJEKANN.model
{
    public class ModelRiwayat
    {
        public string NamaAsliUser { get; set; }
        public string TeksStatistik { get; set; }
        public DataTable TabelRiwayatTransaksi { get; set; }
    }
}