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
public partial class Clinical_Forms_s_as_art_conso_2 : System.Web.UI.Page
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
                rbtn_art_conso2.Focus();
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

                ddl_ba_pos.SelectedItem.Text = DT1.Rows[0][163].ToString();
                string BA = DT1.Rows[0][164].ToString();
                if (BA == "Substitutation")
                {
                    rbtn_ba.SelectedIndex = 0;
                }
                else if (BA == "Omission")
                {
                    rbtn_ba.SelectedIndex = 1;
                }
                else if (BA == "Distortion")
                {
                    rbtn_ba.SelectedIndex = 2;
                }
                else if (BA == "Addition")
                {
                    rbtn_ba.SelectedIndex = 3;
                }
                else if (BA == "Normal")
                {
                    rbtn_ba.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ba.SelectedIndex = 5;
                }
                ddl_bha_pos.SelectedItem.Text = DT1.Rows[0][165].ToString();
                string BHA = DT1.Rows[0][166].ToString();
                if (BHA == "Substitutation")
                {
                    rbtn_bha.SelectedIndex = 0;
                }
                else if (BHA == "Omission")
                {
                    rbtn_bha.SelectedIndex = 1;
                }
                else if (BHA == "Distortion")
                {
                    rbtn_bha.SelectedIndex = 2;
                }
                else if (BHA == "Addition")
                {
                    rbtn_bha.SelectedIndex = 3;
                }
                else if (BHA == "Normal")
                {
                    rbtn_bha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_bha.SelectedIndex = 5;
                }
                ddl_ma_pos.SelectedItem.Text = DT1.Rows[0][167].ToString();
                string MA = DT1.Rows[0][168].ToString();
                if (MA == "Substitutation")
                {
                    rbtn_ma.SelectedIndex = 0;
                }
                else if (MA == "Omission")
                {
                    rbtn_ma.SelectedIndex = 1;
                }
                else if (MA == "Distortion")
                {
                    rbtn_ma.SelectedIndex = 2;
                }
                else if (MA == "Addition")
                {
                    rbtn_ma.SelectedIndex = 3;
                }
                else if (MA == "Normal")
                {
                    rbtn_ma.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ma.SelectedIndex = 5;
                }
                ddl_ya_pos.SelectedItem.Text = DT1.Rows[0][169].ToString();
                string YA = DT1.Rows[0][170].ToString();
                if (YA == "Substitutation")
                {
                    rbtn_ya.SelectedIndex = 0;
                }
                else if (YA == "Omission")
                {
                    rbtn_ya.SelectedIndex = 1;
                }
                else if (YA == "Distortion")
                {
                    rbtn_ya.SelectedIndex = 2;
                }
                else if (YA == "Addition")
                {
                    rbtn_ya.SelectedIndex = 3;
                }
                else if (YA == "Normal")
                {
                    rbtn_ya.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ya.SelectedIndex = 5;
                }
                ddl_ra_pos.SelectedItem.Text = DT1.Rows[0][171].ToString();
                string RA = DT1.Rows[0][172].ToString();
                if (RA == "Substitutation")
                {
                    rbtn_ra.SelectedIndex = 0;
                }
                else if (RA == "Omission")
                {
                    rbtn_ra.SelectedIndex = 1;
                }
                else if (RA == "Distortion")
                {
                    rbtn_ra.SelectedIndex = 2;
                }
                else if (RA == "Addition")
                {
                    rbtn_ra.SelectedIndex = 3;
                }
                else if (RA == "Normal")
                {
                    rbtn_ra.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ra.SelectedIndex = 5;
                }
                ddl_la_pos.SelectedItem.Text = DT1.Rows[0][173].ToString();
                string LA = DT1.Rows[0][174].ToString();
                if (LA == "Substitutation")
                {
                    rbtn_la.SelectedIndex = 0;
                }
                else if (LA == "Omission")
                {
                    rbtn_la.SelectedIndex = 1;
                }
                else if (LA == "Distortion")
                {
                    rbtn_la.SelectedIndex = 2;
                }
                else if (LA == "Addition")
                {
                    rbtn_la.SelectedIndex = 3;
                }
                else if (LA == "Normal")
                {
                    rbtn_la.SelectedIndex = 4;
                }
                else
                {
                    rbtn_la.SelectedIndex = 5;
                }
                ddl_va_pos.SelectedItem.Text = DT1.Rows[0][175].ToString();
                string VA = DT1.Rows[0][176].ToString();
                if (VA == "Substitutation")
                {
                    rbtn_va.SelectedIndex = 0;
                }
                else if (VA == "Omission")
                {
                    rbtn_va.SelectedIndex = 1;
                }
                else if (VA == "Distortion")
                {
                    rbtn_va.SelectedIndex = 2;
                }
                else if (VA == "Addition")
                {
                    rbtn_va.SelectedIndex = 3;
                }
                else if (VA == "Normal")
                {
                    rbtn_va.SelectedIndex = 4;
                }
                else
                {
                    rbtn_va.SelectedIndex = 5;
                }

                ddl_sha_pos.SelectedItem.Text = DT1.Rows[0][177].ToString();
                string SHA = DT1.Rows[0][178].ToString();
                if (SHA == "Substitutation")
                {
                    rbtn_sha.SelectedIndex = 0;
                }
                else if (SHA == "Omission")
                {
                    rbtn_sha.SelectedIndex = 1;
                }
                else if (SHA == "Distortion")
                {
                    rbtn_sha.SelectedIndex = 2;
                }
                else if (SHA == "Addition")
                {
                    rbtn_sha.SelectedIndex = 3;
                }
                else if (SHA == "Normal")
                {
                    rbtn_sha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_sha.SelectedIndex = 5;
                }
                ddl_pot_sha_pos.SelectedItem.Text = DT1.Rows[0][179].ToString();
                string PSHA = DT1.Rows[0][180].ToString();
                if (PSHA == "Substitutation")
                {
                    rbtn_pot_sha.SelectedIndex = 0;
                }
                else if (PSHA == "Omission")
                {
                    rbtn_pot_sha.SelectedIndex = 1;
                }
                else if (PSHA == "Distortion")
                {
                    rbtn_pot_sha.SelectedIndex = 2;
                }
                else if (PSHA == "Addition")
                {
                    rbtn_pot_sha.SelectedIndex = 3;
                }
                else if (PSHA == "Normal")
                {
                    rbtn_pot_sha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_pot_sha.SelectedIndex = 5;
                }
                ddl_sa_pos.SelectedItem.Text = DT1.Rows[0][181].ToString();
                string SA = DT1.Rows[0][182].ToString();
                if (SA == "Substitutation")
                {
                    rbtn_sa.SelectedIndex = 0;
                }
                else if (SA == "Omission")
                {
                    rbtn_sa.SelectedIndex = 1;
                }
                else if (SA == "Distortion")
                {
                    rbtn_sa.SelectedIndex = 2;
                }
                else if (SA == "Addition")
                {
                    rbtn_sa.SelectedIndex = 3;
                }
                else if (SA == "Normal")
                {
                    rbtn_sa.SelectedIndex = 4;
                }
                else
                {
                    rbtn_sa.SelectedIndex = 5;
                }
                ddl_ha_pos.SelectedItem.Text = DT1.Rows[0][183].ToString();
                string HA = DT1.Rows[0][184].ToString();
                if (HA == "Substitutation")
                {
                    rbtn_ha.SelectedIndex = 0;
                }
                else if (HA == "Omission")
                {
                    rbtn_ha.SelectedIndex = 1;
                }
                else if (HA == "Distortion")
                {
                    rbtn_ha.SelectedIndex = 2;
                }
                else if (HA == "Addition")
                {
                    rbtn_ha.SelectedIndex = 3;
                }
                else if (HA == "Normal")
                {
                    rbtn_ha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ha.SelectedIndex = 5;
                }
                ddl_la1_pos.SelectedItem.Text = DT1.Rows[0][185].ToString();
                string LA1 = DT1.Rows[0][186].ToString();
                if (LA1 == "Substitutation")
                {
                    rbtn_la1.SelectedIndex = 0;
                }
                else if (LA1 == "Omission")
                {
                    rbtn_la1.SelectedIndex = 1;
                }
                else if (LA1 == "Distortion")
                {
                    rbtn_la1.SelectedIndex = 2;
                }
                else if (LA1 == "Addition")
                {
                    rbtn_la1.SelectedIndex = 3;
                }
                else if (LA1 == "Normal")
                {
                    rbtn_la1.SelectedIndex = 4;
                }
                else
                {
                    rbtn_la1.SelectedIndex = 5;
                }
                ddl_ksha_pos.SelectedItem.Text = DT1.Rows[0][187].ToString();
                string KSHA = DT1.Rows[0][188].ToString();
                if (KSHA == "Substitutation")
                {
                    rbtn_ksha.SelectedIndex = 0;
                }
                else if (KSHA == "Omission")
                {
                    rbtn_ksha.SelectedIndex = 1;
                }
                else if (KSHA == "Distortion")
                {
                    rbtn_ksha.SelectedIndex = 2;
                }
                else if (KSHA == "Addition")
                {
                    rbtn_ksha.SelectedIndex = 3;
                }
                else if (KSHA == "Normal")
                {
                    rbtn_ksha.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ksha.SelectedIndex = 5;
                }
                ddl_gya_pos.SelectedItem.Text = DT1.Rows[0][189].ToString();
                string GYA = DT1.Rows[0][190].ToString();
                if (GYA == "Substitutation")
                {
                    rbtn_gya.SelectedIndex = 0;
                }
                else if (GYA == "Omission")
                {
                    rbtn_gya.SelectedIndex = 1;
                }
                else if (GYA == "Distortion")
                {
                    rbtn_gya.SelectedIndex = 2;
                }
                else if (GYA == "Addition")
                {
                    rbtn_gya.SelectedIndex = 3;
                }
                else if (GYA == "Normal")
                {
                    rbtn_gya.SelectedIndex = 4;
                }
                else
                {
                    rbtn_gya.SelectedIndex = 5;
                }
                ddl_sra_pos.SelectedItem.Text = DT1.Rows[0][191].ToString();
                string SRA = DT1.Rows[0][192].ToString();
                if (SRA == "Substitutation")
                {
                    rbtn_sra.SelectedIndex = 0;
                }
                else if (SRA == "Omission")
                {
                    rbtn_sra.SelectedIndex = 1;
                }
                else if (SRA == "Distortion")
                {
                    rbtn_sra.SelectedIndex = 2;
                }
                else if (SRA == "Addition")
                {
                    rbtn_sra.SelectedIndex = 3;
                }
                else if (SRA == "Normal")
                {
                    rbtn_sra.SelectedIndex = 4;
                }
                else
                {
                    rbtn_sra.SelectedIndex = 5;
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
    protected void rbtn_art_conso2_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Conso2
        if (rbtn_art_conso2.SelectedIndex == 2)
        {
            ddl_ba_pos.SelectedIndex = 9;
            rbtn_ba.SelectedIndex = 4;
            ddl_bha_pos.SelectedIndex = 9;
            rbtn_bha.SelectedIndex = 4;
            ddl_ma_pos.SelectedIndex = 9;
            rbtn_ma.SelectedIndex = 4;
            ddl_ya_pos.SelectedIndex = 9;
            rbtn_ya.SelectedIndex = 4;
            ddl_ra_pos.SelectedIndex = 9;
            rbtn_ra.SelectedIndex = 4;
            ddl_la_pos.SelectedIndex = 9;
            rbtn_la.SelectedIndex = 4;
            ddl_va_pos.SelectedIndex = 9;
            rbtn_va.SelectedIndex = 4;
            ddl_sha_pos.SelectedIndex = 9;
            rbtn_sha.SelectedIndex = 4;
            ddl_pot_sha_pos.SelectedIndex = 9;
            rbtn_pot_sha.SelectedIndex = 4;
            ddl_sa_pos.SelectedIndex = 9;
            rbtn_sa.SelectedIndex = 4;
            ddl_ha_pos.SelectedIndex = 9;
            rbtn_ha.SelectedIndex = 4;
            ddl_la1_pos.SelectedIndex = 9;
            rbtn_la1.SelectedIndex = 4;
            ddl_ksha_pos.SelectedIndex = 9;
            rbtn_ksha.SelectedIndex = 4;
            ddl_gya_pos.SelectedIndex = 9;
            rbtn_gya.SelectedIndex = 4;
            ddl_sra_pos.SelectedIndex = 9;
            rbtn_sra.SelectedIndex = 4;
        }

        else if (rbtn_art_conso2.SelectedIndex == 1)
        {

            ddl_ba_pos.SelectedIndex = 1;
            rbtn_ba.SelectedIndex = 5;
            ddl_bha_pos.SelectedIndex = 1;
            rbtn_bha.SelectedIndex = 5;
            ddl_ma_pos.SelectedIndex = 1;
            rbtn_ma.SelectedIndex = 5;
            ddl_ya_pos.SelectedIndex = 1;
            rbtn_ya.SelectedIndex = 5;
            ddl_ra_pos.SelectedIndex = 1;
            rbtn_ra.SelectedIndex = 5;
            ddl_la_pos.SelectedIndex = 1;
            rbtn_la.SelectedIndex = 5;
            ddl_va_pos.SelectedIndex = 1;
            rbtn_va.SelectedIndex = 5;
            ddl_sha_pos.SelectedIndex = 1;
            rbtn_sha.SelectedIndex = 5;
            ddl_pot_sha_pos.SelectedIndex = 1;
            rbtn_pot_sha.SelectedIndex = 5;
            ddl_sa_pos.SelectedIndex = 1;
            rbtn_sa.SelectedIndex = 5;
            ddl_ha_pos.SelectedIndex = 1;
            rbtn_ha.SelectedIndex = 5;
            ddl_la1_pos.SelectedIndex = 1;
            rbtn_la1.SelectedIndex = 5;
            ddl_ksha_pos.SelectedIndex = 1;
            rbtn_ksha.SelectedIndex = 5;
            ddl_gya_pos.SelectedIndex = 1;
            rbtn_gya.SelectedIndex = 5;
            ddl_sra_pos.SelectedIndex = 1;
            rbtn_sra.SelectedIndex = 5;
        }
        else
        {
            if ((ddl_ba_pos.SelectedIndex == 0) || (rbtn_ba.SelectedIndex == -1) ||
    (ddl_bha_pos.SelectedIndex == 0) || (rbtn_bha.SelectedIndex == -1) || (ddl_ma_pos.SelectedIndex == 0) || (rbtn_ma.SelectedIndex == -1) ||
    (ddl_ya_pos.SelectedIndex == 0) || (rbtn_ya.SelectedIndex == -1) || (ddl_ra_pos.SelectedIndex == 0) || (rbtn_ra.SelectedIndex == -1) ||
    (ddl_la_pos.SelectedIndex == 0) || (rbtn_la.SelectedIndex == -1) || (ddl_va_pos.SelectedIndex == 0) || (rbtn_va.SelectedIndex == -1) ||
    (ddl_sha_pos.SelectedIndex == 0) || (rbtn_sha.SelectedIndex == -1) || (ddl_pot_sha_pos.SelectedIndex == 0) || (rbtn_pot_sha.SelectedIndex == -1) ||
    (ddl_sa_pos.SelectedIndex == 0) || (rbtn_sa.SelectedIndex == -1) || (ddl_ha_pos.SelectedIndex == 0) || (rbtn_ha.SelectedIndex == -1) || (ddl_la1_pos.SelectedIndex == 0) ||
    (rbtn_la1.SelectedIndex == -1) || (ddl_ksha_pos.SelectedIndex == 0) || (rbtn_ksha.SelectedIndex == -1) || (ddl_gya_pos.SelectedIndex == 0) || (rbtn_gya.SelectedIndex == -1) ||
    (ddl_sra_pos.SelectedIndex == 0) || (rbtn_sra.SelectedIndex == -1))
            { lbl_msg3.Visible = true; }
            else { lbl_msg3.Visible = false; }
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
            string s_c_ba_pos = ddl_ba_pos.SelectedItem.Text;
            string s_c_ba_type = rbtn_ba.SelectedItem.Text;
            string s_c_bha_pos = ddl_bha_pos.SelectedItem.Text;
            string s_c_bha_type = rbtn_bha.SelectedItem.Text;
            string s_c_ma_pos = ddl_ma_pos.SelectedItem.Text;
            string s_c_ma_type = rbtn_ma.SelectedItem.Text;
            string s_c_ya_pos = ddl_ya_pos.SelectedItem.Text;
            string s_c_ya_type = rbtn_ya.SelectedItem.Text;
            string s_c_ra_pos = ddl_ra_pos.SelectedItem.Text;
            string s_c_ra_type = rbtn_ra.SelectedItem.Text;
            string s_c_la_pos = ddl_la_pos.SelectedItem.Text;
            string s_c_la_type = rbtn_la.SelectedItem.Text;
            string s_c_va_pos = ddl_va_pos.SelectedItem.Text;
            string s_c_va_type = rbtn_va.SelectedItem.Text;
            string s_c_sha_pos = ddl_sha_pos.SelectedItem.Text;
            string s_c_sha_type = rbtn_sha.SelectedItem.Text;
            string s_c_potsha_pos = ddl_pot_sha_pos.SelectedItem.Text;
            string s_c_potsha_type = rbtn_pot_sha.SelectedItem.Text;
            string s_c_sa_pos = ddl_sa_pos.SelectedItem.Text;
            string s_c_sa_type = rbtn_sa.SelectedItem.Text;
            string s_c_ha_pos = ddl_ha_pos.SelectedItem.Text;
            string s_c_ha_type = rbtn_ha.SelectedItem.Text;
            string s_c_la1_pos = ddl_la1_pos.SelectedItem.Text;
            string s_c_la1_type = rbtn_la1.SelectedItem.Text;
            string s_c_ksha_pos = ddl_ksha_pos.SelectedItem.Text;
            string s_c_ksha_type = rbtn_ksha.SelectedItem.Text;
            string s_c_gya_pos = ddl_gya_pos.SelectedItem.Text;
            string s_c_gya_type = rbtn_gya.SelectedItem.Text;
            string s_c_sra_pos = ddl_sra_pos.SelectedItem.Text;
            string s_c_sra_type = rbtn_sra.SelectedItem.Text;
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_s_conso2_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ps_asses_id", as_id);
            cmd.Parameters.AddWithValue("@papt_id", apt_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@ps_c_ba_pos", s_c_ba_pos);
            cmd.Parameters.AddWithValue("@ps_c_ba_type", s_c_ba_type);
            cmd.Parameters.AddWithValue("@ps_c_bha_pos", s_c_bha_pos);
            cmd.Parameters.AddWithValue("@ps_c_bha_type", s_c_bha_type);
            cmd.Parameters.AddWithValue("@ps_c_ma_pos", s_c_ma_pos);
            cmd.Parameters.AddWithValue("@ps_c_ma_type", s_c_ma_type);
            cmd.Parameters.AddWithValue("@ps_c_ya_pos", s_c_ya_pos);
            cmd.Parameters.AddWithValue("@ps_c_ya_type", s_c_ya_type);
            cmd.Parameters.AddWithValue("@ps_c_ra_pos", s_c_ra_pos);
            cmd.Parameters.AddWithValue("@ps_c_ra_type", s_c_ra_type);
            cmd.Parameters.AddWithValue("@ps_c_la_pos", s_c_la_pos);
            cmd.Parameters.AddWithValue("@ps_c_la_type", s_c_la_type);
            cmd.Parameters.AddWithValue("@ps_c_va_pos", s_c_va_pos);
            cmd.Parameters.AddWithValue("@ps_c_va_type", s_c_va_type);
            cmd.Parameters.AddWithValue("@ps_c_sha_pos", s_c_sha_pos);
            cmd.Parameters.AddWithValue("@ps_c_sha_type", s_c_sha_type);
            cmd.Parameters.AddWithValue("@ps_c_potsha_pos", s_c_potsha_pos);
            cmd.Parameters.AddWithValue("@ps_c_potsha_type", s_c_potsha_type);
            cmd.Parameters.AddWithValue("@ps_c_sa_pos", s_c_sa_pos);
            cmd.Parameters.AddWithValue("@ps_c_sa_type", s_c_sa_type);
            cmd.Parameters.AddWithValue("@ps_c_ha_pos", s_c_ha_pos);
            cmd.Parameters.AddWithValue("@ps_c_ha_type", s_c_ha_type);
            cmd.Parameters.AddWithValue("@ps_c_la1_pos", s_c_la1_pos);
            cmd.Parameters.AddWithValue("@ps_c_la1_type", s_c_la1_type);
            cmd.Parameters.AddWithValue("@ps_c_ksha_pos", s_c_ksha_pos);
            cmd.Parameters.AddWithValue("@ps_c_ksha_type", s_c_ksha_type);
            cmd.Parameters.AddWithValue("@ps_c_gya_pos", s_c_gya_pos);
            cmd.Parameters.AddWithValue("@ps_c_gya_type", s_c_gya_type);
            cmd.Parameters.AddWithValue("@ps_c_sra_pos", s_c_sra_pos);
            cmd.Parameters.AddWithValue("@ps_c_sra_type", s_c_sra_type);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            //cn.executeprocedure(cmd);
            int a = cn.executeprocedure(cmd); 
            cn.Close();
            #endregion
            Response.Redirect("~/s_as_fluency.aspx");
            btn_save.Enabled = false;
            Save.Enabled = false;
        }
        catch {/* Response.Redirect("~/error.aspx");*/ }
    }
    protected void btn_prev_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_art_conso1.aspx");
    }
    protected void btn_nxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_fluency.aspx");
    }
    protected void btn_pre1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_art_conso1.aspx");
    }
    protected void btn_nxt1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_fluency.aspx");
    }
    protected void btnPsit_Click(object sender, EventArgs e)
    {
        ddl_ba_pos.SelectedIndex = 2;
        ddl_bha_pos.SelectedIndex = 2;
        ddl_ma_pos.SelectedIndex = 2;
        ddl_ya_pos.SelectedIndex = 2;
        ddl_ra_pos.SelectedIndex = 2;
        ddl_la_pos.SelectedIndex = 2;
        ddl_va_pos.SelectedIndex = 2;
        ddl_sha_pos.SelectedIndex = 2;
        ddl_pot_sha_pos.SelectedIndex = 2;
        ddl_sa_pos.SelectedIndex = 2;
        ddl_ha_pos.SelectedIndex = 2;
        ddl_la1_pos.SelectedIndex = 2;
        ddl_ksha_pos.SelectedIndex = 2;
        ddl_gya_pos.SelectedIndex = 2;
        ddl_sra_pos.SelectedIndex = 2;
    }
}
