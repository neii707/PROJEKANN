using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;

namespace PROJEKANN.controller
{
    public class ControllerMonitorStok
    {
        public ModelMonitorStok AmbilDataMonitorStok(string username)
        {
            ModelMonitorStok model = new ModelMonitorStok();
            model.NamaUserReal = username;

            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryNama, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) model.NamaUserReal = res.ToString();
                    }

                    string queryGrafik = "SELECT * FROM v_grafik_line_stok";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryGrafik, conn))
                    {
                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string bulan = dr["bulan"].ToString().Trim();
                                string grade = dr["grade"].ToString().Trim().ToUpper();
                                int total = Convert.ToInt32(dr["stok"]);

                                if (!model.LabelBulan.Contains(bulan))
                                {
                                    model.LabelBulan.Add(bulan);
                                }

                                if (grade == "A")
                                {
                                    model.DataGradeA.Add(total);
                                }
                                else if (grade == "B")
                                {
                                    model.DataGradeB.Add(total);
                                }
                                else if (grade == "C")
                                {
                                    model.DataGradeC.Add(total);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Controller Error: " + ex.Message, "Error");
            }

            return model;
        }
    }
}