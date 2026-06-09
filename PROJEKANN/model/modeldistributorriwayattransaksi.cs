using System;
using System.Data;

namespace PROJEKANN.model
{
    public class ModelRiwayatDistributor
    {
        public string NamaUserReal { get; set; }
        public string TotalSelesai { get; set; }
        public decimal TotalPembayaran { get; set; }
        public DataTable TabelRiwayat { get; set; }
    }
}