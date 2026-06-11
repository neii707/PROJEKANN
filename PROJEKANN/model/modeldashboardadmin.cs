using System;
using System.Data;

namespace PROJEKANN.model
{
    public class DashboardAdminModel
    {
        public string username { get; set; }
        public string LabelAkun { get; set; }
        public string LabelStok { get; set; }
        public string LabelTransaksi { get; set; }
        public DataTable TabelAktivitas { get; set; }
    }
}