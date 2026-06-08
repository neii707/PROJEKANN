using System;
using System.Data;

namespace PROJEKANN.model
{
    public class ModelDashboardDistributor
    {
        public string NamaUserReal { get; set; }
        public DataTable TabelTransaksiAkhir { get; set; }
        public string TeksJumlahPanen { get; set; }
        public string TeksDemand { get; set; }
        public string TeksTotalTransaksi { get; set; }
    }
}