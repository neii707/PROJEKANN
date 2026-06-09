using System;
using System.Data;

namespace PROJEKANN.model
{
    public class ModelDashboardNelayan
    {
        public string NamaUserReal { get; set; }
        public string TeksStok { get; set; }
        public string TeksPenawaran { get; set; }
        public string TeksPenjualan { get; set; }
        public DataTable TabelAktivitasBersih { get; set; }
    }
}