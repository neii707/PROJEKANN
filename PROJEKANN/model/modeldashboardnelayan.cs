using System.Data;

namespace PROJEKANN.model
{
    public class ModelDashboardNelayan
        {
            public string StokPanen { get; set; } = "0";
            public string TotalPenjualan { get; set; } = "0";
            public decimal TotalPendapatan { get; set; } = 0;
            public DataTable? TabelDashboard { get; set; }
        }
    
}