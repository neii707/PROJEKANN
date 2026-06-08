using System;
using System.Collections.Generic;

namespace PROJEKANN.model
{
    public class ModelMonitorStok
    {
        public string NamaUserReal { get; set; }
        public List<int> DataGradeA { get; set; } = new List<int>();
        public List<int> DataGradeB { get; set; } = new List<int>();
        public List<int> DataGradeC { get; set; } = new List<int>();
        public List<string> LabelBulan { get; set; } = new List<string>();
    }
}