using System.Data;

namespace PROJEKANN.model
{
    public class ModelDashboardNelayan
    {
        public string nama { get; set; } = "";

        public string StokPanen { get; set; } = "0";
        public string TotalPenjualan { get; set; } = "0";
        public decimal TotalPendapatan { get; set; } = 0;
        public DataTable? TabelDashboard { get; set; }
        public string username { get; internal set; }
    }
}