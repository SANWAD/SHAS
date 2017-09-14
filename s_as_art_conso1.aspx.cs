using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Clinical_Forms_s_as_art_conso1 : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    double id;
    string ptntid, aptid, asid;
    DataSet ds;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            cn = new connection();           
            if (!IsPostBack)
            {
                RadioButtonList1.Focus();
                lblDate.Text = DateTime.Now.Date.ToShortDateString();
                int S_ass_id = Convert.ToInt32(Session["S_as_id"].ToString());
                DataFill(S_ass_id);
                if (Convert.ToInt32(Session["S_as_id"].ToString()) > 0)
                {
                    Select();
                }
                //if (Convert.ToInt32(Session["S_as_id"].ToString()) == 0)
                //{
                //    S_ass_id = Convert.ToInt32(Session["S_as_id"].ToString());
                //    DataFill(S_ass_id);
                //}
                //else
                //{
                //    Select();
                //}
            }
       
         }        
    }
    public void Select()
    {
        if (Convert.ToInt32(Session["Ass_id"].ToString()) != 0)
        {
            #region Select
            try
            {
                string id1;
                id1 = (Session["Ass_id"].ToString());
                int Ass_id = System.Convert.ToInt32(id1);

                cn.Open();
                cmd = new SqlCommand("sp_S_Ass_Id_Rpt", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pS_as_id", Ass_id);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbl_asid.Value = DT1.Rows[0][1].ToString();
                lbl_aptid.Value = DT1.Rows[0][2].ToString();
                DataFill(Convert.ToInt32(lbl_ptntid.Value));

                ddl_ka_pos.SelectedItem.Text = DT1.Rows[0][119].ToString();
                string KA = DT1.Rows[0][120].ToString();
                if (KA == "Substitutation")
                {
                    rbtn_ka.SelectedIndex = 0;
                }
                else if (KA == "Omission")
                {
                    rbtn_ka.SelectedIndex = 1;
                }
                else if (KA == "Distortion")
                {
                    rbtn_ka.SelectedIndex = 2;
                }
                else if (KA == "Addition")
                {
                    rbtn_ka.SelectedIndex = 3;
                }
                else if (KA == "Normal")
                {
                    rbtn_ka.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ka.SelectedIndex = 5;
                }
                ddl_kha_pos.SelectedItem.Text = DT1.Rows[0][121].ToString();
                string KHA = DT1.Rows[0][122].ToString();
                if (KHA == "Substitutation")
                {
                    rbtn_kha.SelectedIndex = 0;
                }
                else if (KHA == "Omission")
                {
                    rbtn_kha.SelectedIndex = 1;
                }
                else if (KHA == "Distortion")
                {
                    rbtn_kha.SelectedIndex = 2;
                }
                else if (KHA == "Addition")
                {
                    rbtn_kha.SelectedIndex = 3;
                }
                else if (KHA == "Normal")
                {
                    rbtn_kha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_kha.SelectedIndex = 5;
                }
                ddl_ga_pos.SelectedItem.Text = DT1.Rows[0][123].ToString();
                string GA = DT1.Rows[0][124].ToString();
                if (GA == "Substitutation")
                {
                    rbtn_ga.SelectedIndex = 0;
                }
                else if (GA == "Omission")
                {
                    rbtn_ga.SelectedIndex = 1;
                }
                else if (GA == "Distortion")
                {
                    rbtn_ga.SelectedIndex = 2;
                }
                else if (GA == "Addition")
                {
                    rbtn_ga.SelectedIndex = 3;
                }
                else if (GA == "Normal")
                {
                    rbtn_ga.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ga.SelectedIndex = 5;
                }
                ddl_gha_pos.SelectedItem.Text = DT1.Rows[0][125].ToString();
                string GHA = DT1.Rows[0][126].ToString();
                if (GHA == "Substitutation")
                {
                    rbtn_gha.SelectedIndex = 0;
                }
                else if (GHA == "Omission")
                {
                    rbtn_gha.SelectedIndex = 1;
                }
                else if (GHA == "Distortion")
                {
                    rbtn_gha.SelectedIndex = 2;
                }
                else if (GHA == "Addition")
                {
                    rbtn_gha.SelectedIndex = 3;
                }
                else if (GHA == "Normal")
                {
                    rbtn_gha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_gha.SelectedIndex = 5;
                }
                ddl_na_pos.SelectedItem.Text = DT1.Rows[0][127].ToString();
                string Na = DT1.Rows[0][128].ToString();
                if (Na == "Substitutation")
                {
                    rbtn_na.SelectedIndex = 0;
                }
                else if (Na == "Omission")
                {
                    rbtn_na.SelectedIndex = 1;
                }
                else if (Na == "Distortion")
                {
                    rbtn_na.SelectedIndex = 2;
                }
                else if (Na == "Addition")
                {
                    rbtn_na.SelectedIndex = 3;
                }
                else if (Na == "Normal")
                {
                    rbtn_na.SelectedIndex = 4;
                }
                else
                {
                    rbtn_na.SelectedIndex = 5;
                }
                ddl_c_pos.SelectedItem.Text = DT1.Rows[0][129].ToString();
                string C = DT1.Rows[0][130].ToString();
                if (C == "Substitutation")
                {
                    rbtn_na.SelectedIndex = 0;
                }
                else if (C == "Omission")
                {
                    rbtn_na.SelectedIndex = 1;
                }
                else if (C == "Distortion")
                {
                    rbtn_na.SelectedIndex = 2;
                }
                else if (C == "Addition")
                {
                    rbtn_na.SelectedIndex = 3;
                }
                else if (C == "Normal")
                {
                    rbtn_na.SelectedIndex = 4;
                }
                else
                {
                    rbtn_na.SelectedIndex = 5;
                }
                ddl_cha_pos.SelectedItem.Text = DT1.Rows[0][131].ToString();
                string CHA = DT1.Rows[0][132].ToString();
                if (CHA == "Substitutation")
                {
                    rbtn_cha.SelectedIndex = 0;
                }
                else if (CHA == "Omission")
                {
                    rbtn_cha.SelectedIndex = 1;
                }
                else if (CHA == "Distortion")
                {
                    rbtn_cha.SelectedIndex = 2;
                }
                else if (CHA == "Addition")
                {
                    rbtn_cha.SelectedIndex = 3;
                }
                else if (CHA == "Normal")
                {
                    rbtn_cha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_cha.SelectedIndex = 5;
                }
                ddl_j_pos.SelectedItem.Text = DT1.Rows[0][133].ToString();
                string J = DT1.Rows[0][134].ToString();
                if (J == "Substitutation")
                {
                    rbtn_j.SelectedIndex = 0;
                }
                else if (J == "Omission")
                {
                    rbtn_j.SelectedIndex = 1;
                }
                else if (J == "Distortion")
                {
                    rbtn_j.SelectedIndex = 2;
                }
                else if (J == "Addition")
                {
                    rbtn_j.SelectedIndex = 3;
                }
                else if (J == "Normal")
                {
                    rbtn_j.SelectedIndex = 4;
                }
                else
                {
                    rbtn_j.SelectedIndex = 5;
                }

                ddl_jh_pos.SelectedItem.Text = DT1.Rows[0][135].ToString();
                string JHA = DT1.Rows[0][136].ToString();
                if (JHA == "Substitutation")
                {
                    rbtn_jha.SelectedIndex = 0;
                }
                else if (JHA == "Omission")
                {
                    rbtn_jha.SelectedIndex = 1;
                }
                else if (JHA == "Distortion")
                {
                    rbtn_jha.SelectedIndex = 2;
                }
                else if (JHA == "Addition")
                {
                    rbtn_jha.SelectedIndex = 3;
                }
                else if (JHA == "Normal")
                {
                    rbtn_jha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_jha.SelectedIndex = 5;
                }
                ddl_tra_pos.SelectedItem.Text = DT1.Rows[0][137].ToString();
                string TRA = DT1.Rows[0][138].ToString();
                if (TRA == "Substitutation")
                {
                    rbtn_tra.SelectedIndex = 0;
                }
                else if (TRA == "Omission")
                {
                    rbtn_tra.SelectedIndex = 1;
                }
                else if (TRA == "Distortion")
                {
                    rbtn_tra.SelectedIndex = 2;
                }
                else if (TRA == "Addition")
                {
                    rbtn_tra.SelectedIndex = 3;
                }
                else if (TRA == "Normal")
                {
                    rbtn_tra.SelectedIndex = 4;
                }
                else
                {
                    rbtn_tra.SelectedIndex = 5;
                }
                ddl_ta1_pos.SelectedItem.Text = DT1.Rows[0][139].ToString();
                string TA = DT1.Rows[0][140].ToString();
                if (TA == "Substitutation")
                {
                    rbtn_ta1.SelectedIndex = 0;
                }
                else if (TA == "Omission")
                {
                    rbtn_ta1.SelectedIndex = 1;
                }
                else if (TA == "Distortion")
                {
                    rbtn_ta1.SelectedIndex = 2;
                }
                else if (TA == "Addition")
                {
                    rbtn_ta1.SelectedIndex = 3;
                }
                else if (TA == "Normal")
                {
                    rbtn_ta1.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ta1.SelectedIndex = 5;
                }
                ddl_tha_pos.SelectedItem.Text = DT1.Rows[0][141].ToString();
                string THA = DT1.Rows[0][142].ToString();
                if (THA == "Substitutation")
                {
                    rbtn_tha.SelectedIndex = 0;
                }
                else if (THA == "Omission")
                {
                    rbtn_tha.SelectedIndex = 1;
                }
                else if (THA == "Distortion")
                {
                    rbtn_tha.SelectedIndex = 2;
                }
                else if (THA == "Addition")
                {
                    rbtn_tha.SelectedIndex = 3;
                }
                else if (THA == "Normal")
                {
                    rbtn_tha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_tha.SelectedIndex = 5;
                }

                ddl_d1_pos.SelectedItem.Text = DT1.Rows[0][143].ToString();
                string DA = DT1.Rows[0][144].ToString();
                if (DA == "Substitutation")
                {
                    rbn_da.SelectedIndex = 0;
                }
                else if (DA == "Omission")
                {
                    rbn_da.SelectedIndex = 1;
                }
                else if (DA == "Distortion")
                {
                    rbn_da.SelectedIndex = 2;
                }
                else if (DA == "Addition")
                {
                    rbn_da.SelectedIndex = 3;
                }
                else if (DA == "Normal")
                {
                    rbn_da.SelectedIndex = 4;
                }
                else
                {
                    rbn_da.SelectedIndex = 5;
                }
                ddl_dha_pos.SelectedItem.Text = DT1.Rows[0][145].ToString();
                string DHA = DT1.Rows[0][146].ToString();
                if (DHA == "Substitutation")
                {
                    rbtn_dha.SelectedIndex = 0;
                }
                else if (DHA == "Omission")
                {
                    rbtn_dha.SelectedIndex = 1;
                }
                else if (DHA == "Distortion")
                {
                    rbtn_dha.SelectedIndex = 2;
                }
                else if (DHA == "Addition")
                {
                    rbtn_dha.SelectedIndex = 3;
                }
                else if (DHA == "Normal")
                {
                    rbtn_dha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_dha.SelectedIndex = 5;
                }

                ddl_bign_pos.SelectedItem.Text = DT1.Rows[0][147].ToString();
                string BIG = DT1.Rows[0][148].ToString();
                if (BIG == "Substitutation")
                {
                    rbtn_bign.SelectedIndex = 0;
                }
                else if (BIG == "Omission")
                {
                    rbtn_bign.SelectedIndex = 1;
                }
                else if (BIG == "Distortion")
                {
                    rbtn_bign.SelectedIndex = 2;
                }
                else if (BIG == "Addition")
                {
                    rbtn_bign.SelectedIndex = 3;
                }
                else if (BIG == "Normal")
                {
                    rbtn_bign.SelectedIndex = 4;
                }
                else
                {
                    rbtn_bign.SelectedIndex = 5;
                }
                ddl_ta_pos.SelectedItem.Text = DT1.Rows[0][149].ToString();
                string T = DT1.Rows[0][150].ToString();
                if (T == "Substitutation")
                {
                    rbtn_ta.SelectedIndex = 0;
                }
                else if (T == "Omission")
                {
                    rbtn_ta.SelectedIndex = 1;
                }
                else if (T == "Distortion")
                {
                    rbtn_ta.SelectedIndex = 2;
                }
                else if (T == "Addition")
                {
                    rbtn_ta.SelectedIndex = 3;
                }
                else if (T == "Normal")
                {
                    rbtn_ta.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ta.SelectedIndex = 5;
                }
                ddl_tha1_pos.SelectedItem.Text = DT1.Rows[0][151].ToString();
                string THA1 = DT1.Rows[0][152].ToString();
                if (THA1 == "Substitutation")
                {
                    rbtn_tha1.SelectedIndex = 0;
                }
                else if (THA1 == "Omission")
                {
                    rbtn_tha1.SelectedIndex = 1;
                }
                else if (THA1 == "Distortion")
                {
                    rbtn_tha1.SelectedIndex = 2;
                }
                else if (THA1 == "Addition")
                {
                    rbtn_tha1.SelectedIndex = 3;
                }
                else if (THA1 == "Normal")
                {
                    rbtn_tha1.SelectedIndex = 4;
                }
                else
                {
                    rbtn_tha1.SelectedIndex = 5;
                }
                ddl_d_pos.SelectedItem.Text = DT1.Rows[0][153].ToString();
                string D = DT1.Rows[0][154].ToString();
                if (D == "Substitutation")
                {
                    rbtn_d.SelectedIndex = 0;
                }
                else if (D == "Omission")
                {
                    rbtn_d.SelectedIndex = 1;
                }
                else if (D == "Distortion")
                {
                    rbtn_d.SelectedIndex = 2;
                }
                else if (D == "Addition")
                {
                    rbtn_d.SelectedIndex = 3;
                }
                else if (D == "Normal")
                {
                    rbtn_d.SelectedIndex = 4;
                }
                else
                {
                    rbtn_d.SelectedIndex = 5;
                }
                ddl_dha1_pos.SelectedItem.Text = DT1.Rows[0][155].ToString();
                string DHA1 = DT1.Rows[0][156].ToString();
                if (DHA1 == "Substitutation")
                {
                    rbtn_dha1.SelectedIndex = 0;
                }
                else if (DHA1 == "Omission")
                {
                    rbtn_dha1.SelectedIndex = 1;
                }
                else if (DHA1 == "Distortion")
                {
                    rbtn_dha1.SelectedIndex = 2;
                }
                else if (DHA1 == "Addition")
                {
                    rbtn_dha1.SelectedIndex = 3;
                }
                else if (DHA1 == "Normal")
                {
                    rbtn_dha1.SelectedIndex = 4;
                }
                else
                {
                    rbtn_dha1.SelectedIndex = 5;
                }
                ddl_na1_pos.SelectedItem.Text = DT1.Rows[0][57].ToString();
                string NA1 = DT1.Rows[0][158].ToString();
                if (NA1 == "Substitutation")
                {
                    rbtn_na1.SelectedIndex = 0;
                }
                else if (NA1 == "Omission")
                {
                    rbtn_na1.SelectedIndex = 1;
                }
                else if (NA1 == "Distortion")
                {
                    rbtn_na1.SelectedIndex = 2;
                }
                else if (NA1 == "Addition")
                {
                    rbtn_na1.SelectedIndex = 3;
                }
                else if (NA1 == "Normal")
                {
                    rbtn_na1.SelectedIndex = 4;
                }
                else
                {
                    rbtn_na1.SelectedIndex = 5;
                }
                ddl_pa_pos.SelectedItem.Text = DT1.Rows[0][59].ToString();
                string PA = DT1.Rows[0][160].ToString();
                if (PA == "Substitutation")
                {
                    rbtn_pa.SelectedIndex = 0;
                }
                else if (PA == "Omission")
                {
                    rbtn_pa.SelectedIndex = 1;
                }
                else if (PA == "Distortion")
                {
                    rbtn_pa.SelectedIndex = 2;
                }
                else if (PA == "Addition")
                {
                    rbtn_pa.SelectedIndex = 3;
                }
                else if (PA == "Normal")
                {
                    rbtn_pa.SelectedIndex = 4;
                }
                else
                {
                    rbtn_pa.SelectedIndex = 5;
                }
                ddl_pha_pos.SelectedItem.Text = DT1.Rows[0][161].ToString();
                string PHA = DT1.Rows[0][162].ToString();
                if (PHA == "Substitutation")
                {
                    rbtn_pha.SelectedIndex = 0;
                }
                else if (PHA == "Omission")
                {
                    rbtn_pha.SelectedIndex = 1;
                }
                else if (PHA == "Distortion")
                {
                    rbtn_pha.SelectedIndex = 2;
                }
                else if (PHA == "Addition")
                {
                    rbtn_pha.SelectedIndex = 3;
                }
                else if (PHA == "Normal")
                {
                    rbtn_pha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_pha.SelectedIndex = 5;
                }
                
                dr = null;
                cn.Close();
                //GridLoad();
                btn_save.Text = "Edit";
            }
            catch
            { }

            #endregion
        }
    }
    public void DataFill(int S_ass_id)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["Sanwad"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_S_ass_apt_id";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_S_ass_id", S_ass_id);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        lbl_asid.Value = sdr["s_asses_id"].ToString();
                        lbl_aptid.Value = sdr["apt_id"].ToString();
                        lbl_ptntid.Value = sdr["ptnt_id"].ToString();
                    }
                }
                conn.Close();
            }
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region conso1
        if (RadioButtonList1.SelectedIndex == 2)
        {

            ddl_ka_pos.SelectedIndex = 9;
            rbtn_ka.SelectedIndex = 4;
            ddl_kha_pos.SelectedIndex = 9;
            rbtn_kha.SelectedIndex = 4;
            ddl_ga_pos.SelectedIndex = 9;
            rbtn_ga.SelectedIndex = 4;
            ddl_gha_pos.SelectedIndex = 9;
            rbtn_gha.SelectedIndex = 4;
            ddl_na_pos.SelectedIndex = 9;
            rbtn_na.SelectedIndex = 4;
            ddl_c_pos.SelectedIndex = 9;
            rbtn_c.SelectedIndex = 4;
            ddl_cha_pos.SelectedIndex = 9;
            rbtn_cha.SelectedIndex = 4;
            ddl_j_pos.SelectedIndex = 9;
            rbtn_j.SelectedIndex = 4;
            ddl_jh_pos.SelectedIndex = 9;
            rbtn_jha.SelectedIndex = 4;
            ddl_tra_pos.SelectedIndex = 9;
            rbtn_tra.SelectedIndex = 4;
            ddl_ta1_pos.SelectedIndex = 9;
            rbtn_ta1.SelectedIndex = 4;
            ddl_tha_pos.SelectedIndex = 9;
            rbtn_tha.SelectedIndex = 4;
            ddl_d1_pos.SelectedIndex = 9;
            rbn_da.SelectedIndex = 4;
            ddl_dha_pos.SelectedIndex = 9;
            rbtn_dha.SelectedIndex = 4;
            ddl_bign_pos.SelectedIndex = 9;
            rbtn_bign.SelectedIndex = 4;
            ddl_ta_pos.SelectedIndex = 9;
            rbtn_ta.SelectedIndex = 4;
            ddl_tha1_pos.SelectedIndex = 9;
            rbtn_tha1.SelectedIndex = 4;
            ddl_d_pos.SelectedIndex = 9;
            rbtn_d.SelectedIndex = 4;
            ddl_dha1_pos.SelectedIndex = 9;
            rbtn_dha1.SelectedIndex = 4;
            ddl_na1_pos.SelectedIndex = 9;
            rbtn_na1.SelectedIndex = 4;
            ddl_pa_pos.SelectedIndex = 9;
            rbtn_pa.SelectedIndex = 4;
            ddl_pha_pos.SelectedIndex = 9;
            rbtn_pha.SelectedIndex = 4;
        }
        else if (RadioButtonList1.SelectedIndex == 1)
        {
            ddl_ka_pos.SelectedIndex = 1;
            rbtn_ka.SelectedIndex = 5;
            ddl_kha_pos.SelectedIndex = 1;
            rbtn_kha.SelectedIndex = 5;
            ddl_ga_pos.SelectedIndex = 1;
            rbtn_ga.SelectedIndex = 5;
            ddl_gha_pos.SelectedIndex = 1;
            rbtn_gha.SelectedIndex = 5;
            ddl_na_pos.SelectedIndex = 1;
            rbtn_na.SelectedIndex = 5;
            ddl_c_pos.SelectedIndex = 1;
            rbtn_c.SelectedIndex = 5;
            ddl_cha_pos.SelectedIndex = 1;
            rbtn_cha.SelectedIndex = 5;
            ddl_j_pos.SelectedIndex = 1;
            rbtn_j.SelectedIndex = 5;
            ddl_jh_pos.SelectedIndex = 1;
            rbtn_jha.SelectedIndex = 5;
            ddl_tra_pos.SelectedIndex = 1;
            rbtn_tra.SelectedIndex = 5;
            ddl_ta1_pos.SelectedIndex = 1;
            rbtn_ta1.SelectedIndex = 5;
            ddl_tha_pos.SelectedIndex = 1;
            rbtn_tha.SelectedIndex = 5;
            ddl_d1_pos.SelectedIndex = 1;
            rbn_da.SelectedIndex = 5;
            ddl_dha_pos.SelectedIndex = 1;
            rbtn_dha.SelectedIndex = 5;
            ddl_bign_pos.SelectedIndex = 1;
            rbtn_bign.SelectedIndex = 5;
            ddl_ta_pos.SelectedIndex = 1;
            rbtn_ta.SelectedIndex = 5;
            ddl_tha1_pos.SelectedIndex = 1;
            rbtn_tha1.SelectedIndex = 5;
            ddl_d_pos.SelectedIndex = 1;
            rbtn_d.SelectedIndex = 5;
            ddl_dha1_pos.SelectedIndex = 1;
            rbtn_dha1.SelectedIndex = 5;
            ddl_na1_pos.SelectedIndex = 1;
            rbtn_na1.SelectedIndex = 5;
            ddl_pa_pos.SelectedIndex = 1;
            rbtn_pa.SelectedIndex = 5;
            ddl_pha_pos.SelectedIndex = 1;
            rbtn_pha.SelectedIndex = 5;
        }
        else
        {
            if ((ddl_ka_pos.SelectedIndex == 0) || (rbtn_ka.SelectedIndex == -1) || (ddl_kha_pos.SelectedIndex == 0) || (rbtn_kha.SelectedIndex == -1) || (ddl_ga_pos.SelectedIndex == 0) ||
(rbtn_ga.SelectedIndex == -1) || (ddl_gha_pos.SelectedIndex == 0) || (rbtn_gha.SelectedIndex == -1) || (ddl_na_pos.SelectedIndex == 0) || (rbtn_na.SelectedIndex == -1) ||
(ddl_c_pos.SelectedIndex == 0) || (rbtn_c.SelectedIndex == -1) || (ddl_cha_pos.SelectedIndex == 0) || (rbtn_cha.SelectedIndex == -1) || (ddl_j_pos.SelectedIndex == 0) ||
(rbtn_j.SelectedIndex == -1) || (ddl_jh_pos.SelectedIndex == 0) || (rbtn_jha.SelectedIndex == -1) || (ddl_tra_pos.SelectedIndex == 0) || (rbtn_tra.SelectedIndex == -1) ||
(ddl_ta1_pos.SelectedIndex == 0) || (rbtn_ta1.SelectedIndex == -1) || (ddl_tha_pos.SelectedIndex == 0) || (rbtn_tha.SelectedIndex == -1) || (ddl_d1_pos.SelectedIndex == 0) ||
(rbtn_d.SelectedIndex == -1) || (ddl_dha_pos.SelectedIndex == 0) || (rbtn_dha.SelectedIndex == -1) || (ddl_bign_pos.SelectedIndex == 0) || (rbtn_bign.SelectedIndex == -1) ||
(ddl_ta_pos.SelectedIndex == 0) || (rbtn_ta.SelectedIndex == -1) || (ddl_tha1_pos.SelectedIndex == 0) || (rbtn_tha1.SelectedIndex == -1) || (ddl_d_pos.SelectedIndex == 0) ||
(rbtn_d.SelectedIndex == -1) || (ddl_dha1_pos.SelectedIndex == 0) || (rbtn_dha1.SelectedIndex == -1) || (ddl_na1_pos.SelectedIndex == 0) || (rbtn_na1.SelectedIndex == -1) ||
(ddl_pa_pos.SelectedIndex == 0) || (rbtn_pa.SelectedIndex == -1) || (ddl_pha_pos.SelectedIndex == 0) || (rbtn_pha.SelectedIndex == -1))
            { lbl_msg2.Visible = true; }
            else { lbl_msg2.Visible = false; }
        }
        #endregion
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            #region Save
            int apt_id = Convert.ToInt32(lbl_aptid.Value);
            int ptnt_id = Convert.ToInt32(lbl_ptntid.Value);
            int as_id = Convert.ToInt32(lbl_asid.Value);
            //int as_id = 0;
            string s_c_ka_pos = ddl_ka_pos.SelectedItem.Text;
            string s_c_ka_type = rbtn_ka.SelectedItem.Text;
            string s_c_kha_pos = ddl_kha_pos.SelectedItem.Text;
            string s_c_kha_type = rbtn_kha.SelectedItem.Text;
            string s_c_ga_pos = ddl_ga_pos.SelectedItem.Text;
            string s_c_ga_type = rbtn_ga.SelectedItem.Text;
            string s_c_gha_pos = ddl_gha_pos.SelectedItem.Text;
            string s_c_gha_type = rbtn_gha.SelectedItem.Text;
            string s_c_na_pos = ddl_na_pos.SelectedItem.Text;
            string s_c_na_type = rbtn_na.SelectedItem.Text;
            string s_c_c_pos = ddl_c_pos.SelectedItem.Text;
            string s_c_c_type = rbtn_c.SelectedItem.Text;
            string s_c_cha_pos = ddl_cha_pos.SelectedItem.Text;
            string s_c_cha_type = rbtn_cha.SelectedItem.Text;
            string s_c_j_pos = ddl_j_pos.SelectedItem.Text;
            string s_c_j_type = rbtn_j.SelectedItem.Text;
            string s_c_jh_pos = ddl_jh_pos.SelectedItem.Text;
            string s_c_jh_type = rbtn_jha.SelectedItem.Text;
            string s_c_tra_pos = ddl_tra_pos.SelectedItem.Text;
            string s_c_tra_type = rbtn_tra.SelectedItem.Text;
            string s_c_ta1_pos = ddl_ta1_pos.SelectedItem.Text;
            string s_c_ta1_type = rbtn_ta1.SelectedItem.Text;
            string s_c_tha_pos = ddl_tha_pos.SelectedItem.Text;
            string s_c_tha_type = rbtn_tha.SelectedItem.Text;
            string s_c_d1_pos = ddl_d1_pos.SelectedItem.Text;
            string s_c_d1_type = rbtn_d.SelectedItem.Text;
            string s_c_dha_pos = ddl_dha_pos.SelectedItem.Text;
            string s_c_dha_type = rbtn_dha.SelectedItem.Text;
            string s_c_bign_pos = ddl_bign_pos.SelectedItem.Text;
            string s_c_bign_type = rbtn_bign.SelectedItem.Text;
            string s_c_ta_pos = ddl_ta_pos.SelectedItem.Text;
            string s_c_ta_type = rbtn_ta.SelectedItem.Text;
            string s_c_tha1_pos = ddl_tha1_pos.SelectedItem.Text;
            string s_c_tha1_type = rbtn_tha1.SelectedItem.Text;
            string s_c_d_pos = ddl_d_pos.SelectedItem.Text;
            string s_c_d_type = rbtn_d.SelectedItem.Text;
            string s_c_dha1_pos = ddl_dha1_pos.SelectedItem.Text;
            string s_c_dha1_type = rbtn_dha1.SelectedItem.Text;
            string s_c_na1_pos = ddl_na1_pos.SelectedItem.Text;
            string s_c_na1_type = rbtn_na1.SelectedItem.Text;
            string s_c_pa_pos = ddl_pa_pos.SelectedItem.Text;
            string s_c_pa_type = rbtn_pa.SelectedItem.Text;
            string s_c_pha_pos = ddl_pha_pos.SelectedItem.Text;
            string s_c_pha_type = rbtn_pha.SelectedItem.Text;
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_s_conso1_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ps_asses_id", as_id);
            cmd.Parameters.AddWithValue("@papt_id", apt_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@ps_c_ka_pos", s_c_ka_pos);
            cmd.Parameters.AddWithValue("@ps_c_ka_type", s_c_ka_type);
            cmd.Parameters.AddWithValue("@ps_c_kha_pos", s_c_kha_pos);
            cmd.Parameters.AddWithValue("@ps_c_kha_type", s_c_kha_type);
            cmd.Parameters.AddWithValue("@ps_c_ga_pos", s_c_ga_pos);
            cmd.Parameters.AddWithValue("@ps_c_ga_type", s_c_ga_type);
            cmd.Parameters.AddWithValue("@ps_c_gha_pos", s_c_gha_pos);
            cmd.Parameters.AddWithValue("@ps_c_gha_type", s_c_gha_type);
            cmd.Parameters.AddWithValue("@ps_c_na_pos", s_c_na_pos);
            cmd.Parameters.AddWithValue("@ps_c_na_type", s_c_na_type);
            cmd.Parameters.AddWithValue("@ps_c_c_pos", s_c_c_pos);
            cmd.Parameters.AddWithValue("@ps_c_c_type", s_c_c_type);
            cmd.Parameters.AddWithValue("@ps_c_cha_pos", s_c_cha_pos);
            cmd.Parameters.AddWithValue("@ps_c_cha_type", s_c_cha_type);
            cmd.Parameters.AddWithValue("@ps_c_j_pos", s_c_j_pos);
            cmd.Parameters.AddWithValue("@ps_c_j_type", s_c_j_type);
            cmd.Parameters.AddWithValue("@ps_c_jh_pos", s_c_jh_pos);
            cmd.Parameters.AddWithValue("@ps_c_jh_type", s_c_jh_type);
            cmd.Parameters.AddWithValue("@ps_c_tra_pos", s_c_tra_pos);
            cmd.Parameters.AddWithValue("@ps_c_tra_type", s_c_tra_type);
            cmd.Parameters.AddWithValue("@ps_c_ta1_pos", s_c_ta1_pos);
            cmd.Parameters.AddWithValue("@ps_c_ta1_type", s_c_ta1_type);
            cmd.Parameters.AddWithValue("@ps_c_tha_pos", s_c_tha_pos);
            cmd.Parameters.AddWithValue("@ps_c_tha_type", s_c_tha_type);
            cmd.Parameters.AddWithValue("@ps_c_d1_pos", s_c_d1_pos);
            cmd.Parameters.AddWithValue("@ps_c_d1_type", s_c_d1_type);
            cmd.Parameters.AddWithValue("@ps_c_dha_pos", s_c_dha_pos);
            cmd.Parameters.AddWithValue("@ps_c_dha_type", s_c_dha_type);
            cmd.Parameters.AddWithValue("@ps_c_bign_pos", s_c_bign_pos);
            cmd.Parameters.AddWithValue("@ps_c_bign_type", s_c_bign_type);
            cmd.Parameters.AddWithValue("@ps_c_ta_pos", s_c_ta_pos);
            cmd.Parameters.AddWithValue("@ps_c_ta_type", s_c_ta_type);
            cmd.Parameters.AddWithValue("@ps_c_tha1_pos", s_c_tha1_pos);
            cmd.Parameters.AddWithValue("@ps_c_tha1_type", s_c_tha1_type);
            cmd.Parameters.AddWithValue("@ps_c_d_pos", s_c_d_pos);
            cmd.Parameters.AddWithValue("@ps_c_d_type", s_c_d_type);
            cmd.Parameters.AddWithValue("@ps_c_dha1_pos", s_c_dha1_pos);
            cmd.Parameters.AddWithValue("@ps_c_dha1_type", s_c_dha1_type);
            cmd.Parameters.AddWithValue("@ps_c_na1_pos", s_c_na1_pos);
            cmd.Parameters.AddWithValue("@ps_c_na1_type", s_c_na1_type);
            cmd.Parameters.AddWithValue("@ps_c_pa_pos", s_c_pa_pos);
            cmd.Parameters.AddWithValue("@ps_c_pa_type", s_c_pa_type);
            cmd.Parameters.AddWithValue("@ps_c_pha_pos", s_c_pha_pos);
            cmd.Parameters.AddWithValue("@ps_c_pha_type", s_c_pha_type);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            //cn.executeprocedure(cmd);
            int a = cn.executeprocedure(cmd);
            cn.Close();
            #endregion
            Response.Redirect("~/s_as_art_conso_2.aspx");
            btn_save.Enabled = false;
            Save.Enabled = false;
        }
        catch { /*Response.Redirect("~/error.aspx");*/ }
    }
    protected void btn_prev_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_arti_vovel.aspx");
    }
    protected void btn_nxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_art_conso_2.aspx");
    }
    protected void btn_pre1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_arti_vovel.aspx");
    }
    protected void btn_nxt1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_art_conso_2.aspx");
    }
    protected void btnAllP_Click(object sender, EventArgs e)
    {
        ddl_ka_pos.SelectedIndex = 2;
        ddl_kha_pos.SelectedIndex = 2;
        ddl_ga_pos.SelectedIndex = 2;
        ddl_gha_pos.SelectedIndex = 2;
        ddl_na_pos.SelectedIndex = 2;
        ddl_c_pos.SelectedIndex = 2;
        ddl_cha_pos.SelectedIndex = 2;
        ddl_j_pos.SelectedIndex = 2;
        ddl_jh_pos.SelectedIndex = 2;
        ddl_tra_pos.SelectedIndex = 2;
        ddl_ta1_pos.SelectedIndex = 2;
        ddl_tha_pos.SelectedIndex = 2;
        ddl_d1_pos.SelectedIndex = 2;
        ddl_dha_pos.SelectedIndex = 2;
        ddl_bign_pos.SelectedIndex = 2;
        ddl_ta_pos.SelectedIndex = 2;
        ddl_tha1_pos.SelectedIndex = 2;
        ddl_d_pos.SelectedIndex = 2;
        ddl_dha1_pos.SelectedIndex = 2;
        ddl_na1_pos.SelectedIndex = 2;
        ddl_pa_pos.SelectedIndex = 2;
        ddl_pha_pos.SelectedIndex = 2;
    }
}
