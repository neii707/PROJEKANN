using System;
using System.Collections.Generic;

namespace PROJEKANN.model
{
    public class ModelMonitorTransaksi
    {
        public string NamaUserReal { get; set; }
        public List<int> DataGradeA { get; set; } = new List<int>();
        public List<int> DataGradeB { get; set; } = new List<int>();
        public List<int> DataGradeC { get; set; } = new List<int>();
        public List<string> LabelBulan { get; set; } = new List<string>();
        public List<int> DataTotalBerat { get; set; } = new List<int>();
        public List<int> DataTotalTransaksi { get; set; } = new List<int>();
    }
}