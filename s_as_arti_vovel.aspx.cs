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

public partial class Clinical_Forms_s_as_arti_vovel : System.Web.UI.Page
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
                rbtn_vovel_apl.Focus();
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
                ddl_a_pos.SelectedItem.Text = DT1.Rows[0][95].ToString();
                string A = DT1.Rows[0][96].ToString();
                if (A == "Substitutation")
                {
                    rbtn_a.SelectedIndex = 0;
                }
                else if (A == "Omission")
                {
                    rbtn_a.SelectedIndex = 1;
                }
                else if (A == "Distortion")
                {
                    rbtn_a.SelectedIndex = 2;
                }
                else if (A == "Addition")
                {
                    rbtn_a.SelectedIndex = 3;
                }
                else if (A == "Normal")
                {
                    rbtn_a.SelectedIndex = 4;
                }
                else
                {
                    rbtn_a.SelectedIndex = 5;
                }

                ddl_aa_pos.SelectedItem.Text = DT1.Rows[0][97].ToString();
                string AA = DT1.Rows[0][98].ToString();
                if (AA == "Substitutation")
                {
                    rbtn_aa.SelectedIndex = 0;
                }
                else if (AA == "Omission")
                {
                    rbtn_aa.SelectedIndex = 1;
                }
                else if (AA == "Distortion")
                {
                    rbtn_aa.SelectedIndex = 2;
                }
                else if (AA == "Addition")
                {
                    rbtn_aa.SelectedIndex = 3;
                }
                else if (AA == "Normal")
                {
                    rbtn_aa.SelectedIndex = 4;
                }
                else
                {
                    rbtn_aa.SelectedIndex = 5;
                }

                ddl_i_pos.SelectedItem.Text = DT1.Rows[0][99].ToString();
                string I = DT1.Rows[0][100].ToString();
                if (I == "Substitutation")
                {
                    rbtn_i.SelectedIndex = 0;
                }
                else if (I == "Omission")
                {
                    rbtn_i.SelectedIndex = 1;
                }
                else if (I == "Distortion")
                {
                    rbtn_i.SelectedIndex = 2;
                }
                else if (I == "Addition")
                {
                    rbtn_i.SelectedIndex = 3;
                }
                else if (I == "Normal")
                {
                    rbtn_i.SelectedIndex = 4;
                }
                else
                {
                    rbtn_i.SelectedIndex = 5;
                }
                ddl_i1_pos.SelectedItem.Text = DT1.Rows[0][101].ToString();
                string I1 = DT1.Rows[0][102].ToString();
                if (I1 == "Substitutation")
                {
                    rbtn_i1.SelectedIndex = 0;
                }
                else if (I1 == "Omission")
                {
                    rbtn_i1.SelectedIndex = 1;
                }
                else if (I1 == "Distortion")
                {
                    rbtn_i1.SelectedIndex = 2;
                }
                else if (I1 == "Addition")
                {
                    rbtn_i1.SelectedIndex = 3;
                }
                else if (I1 == "Normal")
                {
                    rbtn_i1.SelectedIndex = 4;
                }
                else
                {
                    rbtn_i1.SelectedIndex = 5;
                }

                ddl_u_pos.SelectedItem.Text = DT1.Rows[0][103].ToString();
                string U = DT1.Rows[0][104].ToString();
                if (U == "Substitutation")
                {
                    rbtn_u.SelectedIndex = 0;
                }
                else if (U == "Omission")
                {
                    rbtn_u.SelectedIndex = 1;
                }
                else if (U == "Distortion")
                {
                    rbtn_u.SelectedIndex = 2;
                }
                else if (U == "Addition")
                {
                    rbtn_u.SelectedIndex = 3;
                }
                else if (U == "Normal")
                {
                    rbtn_u.SelectedIndex = 4;
                }
                else
                {
                    rbtn_u.SelectedIndex = 5;
                }
                ddl_u1_pos.SelectedItem.Text = DT1.Rows[0][105].ToString();
                string U1 = DT1.Rows[0][106].ToString();
                if (U1 == "Substitutation")
                {
                    rbtn_u1.SelectedIndex = 0;
                }
                else if (U1 == "Omission")
                {
                    rbtn_u1.SelectedIndex = 1;
                }
                else if (U1 == "Distortion")
                {
                    rbtn_u1.SelectedIndex = 2;
                }
                else if (U1 == "Addition")
                {
                    rbtn_u1.SelectedIndex = 3;
                }
                else if (U1 == "Normal")
                {
                    rbtn_u1.SelectedIndex = 4;
                }
                else
                {
                    rbtn_u1.SelectedIndex = 5;
                }

                ddl_e_pos.SelectedItem.Text = DT1.Rows[0][107].ToString();
                string A1 = DT1.Rows[0][108].ToString();
                if (A1 == "Substitutation")
                {
                    rbtn_e.SelectedIndex = 0;
                }
                else if (A1 == "Omission")
                {
                    rbtn_e.SelectedIndex = 1;
                }
                else if (A1 == "Distortion")
                {
                    rbtn_e.SelectedIndex = 2;
                }
                else if (A1 == "Addition")
                {
                    rbtn_e.SelectedIndex = 3;
                }
                else if (A1 == "Normal")
                {
                    rbtn_e.SelectedIndex = 4;
                }
                else
                {
                    rbtn_e.SelectedIndex = 5;
                }
                ddl_ai_pos.SelectedItem.Text = DT1.Rows[0][109].ToString();
                string AI1 = DT1.Rows[0][110].ToString();
                if (AI1 == "Substitutation")
                {
                    rbtn_ai.SelectedIndex = 0;
                }
                else if (AI1 == "Omission")
                {
                    rbtn_ai.SelectedIndex = 1;
                }
                else if (AI1 == "Distortion")
                {
                    rbtn_ai.SelectedIndex = 2;
                }
                else if (AI1 == "Addition")
                {
                    rbtn_ai.SelectedIndex = 3;
                }
                else if (AI1 == "Normal")
                {
                    rbtn_ai.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ai.SelectedIndex = 5;
                }
                ddl_o_pos.SelectedItem.Text = DT1.Rows[0][111].ToString();
                string O = DT1.Rows[0][112].ToString();
                if (O == "Substitutation")
                {
                    rbtn_o.SelectedIndex = 0;
                }
                else if (O == "Omission")
                {
                    rbtn_o.SelectedIndex = 1;
                }
                else if (O == "Distortion")
                {
                    rbtn_o.SelectedIndex = 2;
                }
                else if (O == "Addition")
                {
                    rbtn_o.SelectedIndex = 3;
                }
                else if (O == "Normal")
                {
                    rbtn_o.SelectedIndex = 4;
                }
                else
                {
                    rbtn_o.SelectedIndex = 5;
                }                
                ddl_au_pos.SelectedItem.Text = DT1.Rows[0][114].ToString();
                string AU = DT1.Rows[0][113].ToString();
                if (AU == "Substitutation")
                {
                    rbtn_au.SelectedIndex = 0;
                }
                else if (AU == "Omission")
                {
                    rbtn_au.SelectedIndex = 1;
                }
                else if (AU == "Distortion")
                {
                    rbtn_au.SelectedIndex = 2;
                }
                else if (AU == "Addition")
                {
                    rbtn_au.SelectedIndex = 3;
                }
                else if (AU == "Normal")
                {
                    rbtn_au.SelectedIndex = 4;
                }
                else
                {
                    rbtn_au.SelectedIndex = 5;
                }
                ddl_an_pos.SelectedItem.Text = DT1.Rows[0][116].ToString();
                string AN = DT1.Rows[0][115].ToString();
                if (AN == "Substitutation")
                {
                    rbtn_an.SelectedIndex = 0;
                }
                else if (AN == "Omission")
                {
                    rbtn_an.SelectedIndex = 1;
                }
                else if (AN == "Distortion")
                {
                    rbtn_an.SelectedIndex = 2;
                }
                else if (AN == "Addition")
                {
                    rbtn_an.SelectedIndex = 3;
                }
                else if (AN == "Normal")
                {
                    rbtn_an.SelectedIndex = 4;
                }
                else
                {
                    rbtn_an.SelectedIndex = 5;
                }

                ddl_ah_pos.SelectedItem.Text = DT1.Rows[0][118].ToString();
                string AH = DT1.Rows[0][117].ToString();
                if (AH == "Substitutation")
                {
                    rbtn_ah.SelectedIndex = 0;
                }
                else if (AH == "Omission")
                {
                    rbtn_ah.SelectedIndex = 1;
                }
                else if (AH == "Distortion")
                {
                    rbtn_ah.SelectedIndex = 2;
                }
                else if (AH == "Addition")
                {
                    rbtn_ah.SelectedIndex = 3;
                }
                else if (AH == "Normal")
                {
                    rbtn_ah.SelectedIndex = 4;
                }
                else
                {
                    rbtn_ah.SelectedIndex = 5;
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
   
    protected void rbtn_vovel_apl_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Vovel Normal
        if (rbtn_vovel_apl.SelectedItem.Text == "Normal")
        {
            ddl_a_pos.SelectedIndex = 1;
            rbtn_a.SelectedIndex = 4;
            ddl_aa_pos.SelectedIndex = 1;
            rbtn_aa.SelectedIndex = 4;
            ddl_i_pos.SelectedIndex = 1;
            rbtn_i.SelectedIndex = 4;
            ddl_i1_pos.SelectedIndex = 1;
            rbtn_i1.SelectedIndex = 4;
            ddl_u_pos.SelectedIndex = 1;
            rbtn_u.SelectedIndex = 4;
            ddl_u1_pos.SelectedIndex = 1;
            rbtn_u1.SelectedIndex = 4;
            ddl_e_pos.SelectedIndex = 1;
            rbtn_e.SelectedIndex = 4;
            ddl_ai_pos.SelectedIndex = 1;
            rbtn_ai.SelectedIndex = 4;
            ddl_o_pos.SelectedIndex = 1;
            rbtn_o.SelectedIndex = 4;
            ddl_au_pos.SelectedIndex = 1;
            rbtn_au.SelectedIndex = 4;
            ddl_an_pos.SelectedIndex = 1;
            rbtn_an.SelectedIndex = 4;
            ddl_ah_pos.SelectedIndex = 1;
            rbtn_ah.SelectedIndex = 4;
        }
        else
        {
            ddl_a_pos.SelectedIndex = 0;
            ddl_aa_pos.SelectedIndex = 0;
            ddl_i_pos.SelectedIndex = 0;
            ddl_i1_pos.SelectedIndex = 0;
            ddl_u_pos.SelectedIndex = 0;
            ddl_u1_pos.SelectedIndex = 0;
            ddl_e_pos.SelectedIndex = 0;
            ddl_ai_pos.SelectedIndex = 0;
            ddl_o_pos.SelectedIndex = 0;
            ddl_au_pos.SelectedIndex = 0;
            ddl_an_pos.SelectedIndex = 0;
            ddl_ah_pos.SelectedIndex = 0;
        }
        #endregion
    }
    protected void btn_save_Click1(object sender, EventArgs e)
    {
        try
        {
            #region Save
            int apt_id = Convert.ToInt32(lbl_aptid.Value);
            int ptnt_id = Convert.ToInt32(lbl_ptntid.Value);
            //int as_id = 0;
            int as_id = Convert.ToInt32(lbl_asid.Value);
            string s_v_a_pos = ddl_a_pos.SelectedItem.Text;
            string s_v_a_type = rbtn_a.SelectedItem.Text;
            string s_v_aa_pos = ddl_aa_pos.SelectedItem.Text;
            string s_v_aa_type = rbtn_aa.SelectedItem.Text;
            string s_v_i_pos = ddl_i_pos.SelectedItem.Text;
            string s_v_i_type = rbtn_i.SelectedItem.Text;
            string s_v_I1_pos = ddl_i1_pos.SelectedItem.Text;
            string s_v_I1_type = rbtn_i1.SelectedItem.Text;
            string s_v_u_pos = ddl_u_pos.SelectedItem.Text;
            string s_v_u_type = rbtn_u.SelectedItem.Text;
            string s_v_u1_pos = ddl_u1_pos.SelectedItem.Text;
            string s_v_u1_type = rbtn_u1.SelectedItem.Text;
            string s_v_e_pos = ddl_e_pos.SelectedItem.Text;
            string s_v_e_type = rbtn_e.SelectedItem.Text;
            string s_v_ai_pos = ddl_ai_pos.SelectedItem.Text;
            string s_v_ai_type = rbtn_ai.SelectedItem.Text;
            string s_v_o_pos = ddl_o_pos.SelectedItem.Text;
            string s_v_o_type = rbtn_o.SelectedItem.Text;
            string s_v_au_pos = ddl_au_pos.SelectedItem.Text;
            string s_v_au_type = rbtn_au.SelectedItem.Text;
            string s_v_an_type = ddl_an_pos.SelectedItem.Text;
            string s_v_an_pos = rbtn_an.SelectedItem.Text;
            string s_v_ah_type = ddl_ah_pos.SelectedItem.Text;
            string s_v_ah_pos = rbtn_ah.SelectedItem.Text;
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_s_art_vovels_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ps_asses_id", as_id);
            cmd.Parameters.AddWithValue("@papt_id", apt_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@ps_v_a_pos", s_v_a_pos);
            cmd.Parameters.AddWithValue("@ps_v_a_type", s_v_a_type);
            cmd.Parameters.AddWithValue("@ps_v_aa_pos", s_v_aa_pos);
            cmd.Parameters.AddWithValue("@ps_v_aa_type", s_v_aa_type);
            cmd.Parameters.AddWithValue("@ps_v_i_pos", s_v_i_pos);
            cmd.Parameters.AddWithValue("@ps_v_i_type", s_v_i_type);
            cmd.Parameters.AddWithValue("@ps_v_I1_pos", s_v_I1_pos);
            cmd.Parameters.AddWithValue("@ps_v_I1_type", s_v_I1_type);
            cmd.Parameters.AddWithValue("@ps_v_u_pos", s_v_u_pos);
            cmd.Parameters.AddWithValue("@ps_v_u_type", s_v_u_type);
            cmd.Parameters.AddWithValue("@ps_v_u1_pos", s_v_u1_pos);
            cmd.Parameters.AddWithValue("@ps_v_u1_type", s_v_u1_type);
            cmd.Parameters.AddWithValue("@ps_v_e_pos", s_v_e_pos);
            cmd.Parameters.AddWithValue("@ps_v_e_type", s_v_e_type);
            cmd.Parameters.AddWithValue("@ps_v_ai_pos", s_v_ai_pos);
            cmd.Parameters.AddWithValue("@ps_v_ai_type", s_v_ai_type);
            cmd.Parameters.AddWithValue("@ps_v_o_pos", s_v_o_pos);
            cmd.Parameters.AddWithValue("@ps_v_o_type", s_v_o_type);
            cmd.Parameters.AddWithValue("@ps_v_au_pos", s_v_au_pos);
            cmd.Parameters.AddWithValue("@ps_v_au_type", s_v_au_type);
            cmd.Parameters.AddWithValue("@ps_v_an_type", s_v_an_type);
            cmd.Parameters.AddWithValue("@ps_v_an_pos", s_v_an_pos);
            cmd.Parameters.AddWithValue("@ps_v_ah_type", s_v_ah_type);
            cmd.Parameters.AddWithValue("@ps_v_ah_pos", s_v_ah_pos);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            //cn.executeprocedure(cmd);
            int a=cn.executeprocedure(cmd);
            cn.Close();
            #endregion
            Response.Redirect("~/s_as_art_conso1.aspx");
            btn_save.Enabled = false;
            //Save.Enabled = false;
        }
        catch { /*Response.Redirect("~/error.aspx");*/ }

    }
    protected void page_validate_wiz3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (rbtn_vovel_apl.SelectedIndex == 1)
        {
            try
            {
                if ((ddl_a_pos.SelectedIndex == 0) || (rbtn_a.SelectedIndex == -1) || (ddl_aa_pos.SelectedIndex == 0) || (rbtn_aa.SelectedIndex == -1) ||
                   (ddl_i_pos.SelectedIndex == 0) || (rbtn_i.SelectedIndex == -1) || (ddl_i1_pos.SelectedIndex == 0) || (rbtn_i1.SelectedIndex == -1) || (ddl_u_pos.SelectedIndex == 0) ||
                   (rbtn_u.SelectedIndex == -1) || (ddl_u1_pos.SelectedIndex == 0) || (rbtn_u1.SelectedIndex == -1) || (ddl_e_pos.SelectedIndex == 0) || (rbtn_e.SelectedIndex == -1) ||
                   (ddl_ai_pos.SelectedIndex == 0) || (rbtn_ai.SelectedIndex == -1) || (ddl_o_pos.SelectedIndex == 0) || (rbtn_o.SelectedIndex == -1) || (ddl_au_pos.SelectedIndex == 0) ||
                   (rbtn_au.SelectedIndex == -1) || (ddl_an_pos.SelectedIndex == 0) || (rbtn_an.SelectedIndex == -1) || (ddl_ah_pos.SelectedIndex == 0) || (rbtn_ah.SelectedIndex == -1))
                { args.IsValid = false; }
                else { args.IsValid = true; }
            }
            catch {/* Response.Redirect("~/error.aspx");*/ }
        }
    }
    protected void btn_prev_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_oral_peri.aspx");
    }
    protected void btn_nxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_art_conso1.aspx");
    }
    protected void btn_pre1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_oral_peri.aspx");
    }
    protected void btn_nxt1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_art_conso1.aspx");
    }

    protected void btnPosAll_Click(object sender, EventArgs e)
    {
        ddl_a_pos.SelectedIndex = 2;
        ddl_aa_pos.SelectedIndex = 2;
        ddl_i_pos.SelectedIndex = 2;
        ddl_i1_pos.SelectedIndex = 2;
        ddl_u_pos.SelectedIndex = 2;
        ddl_u1_pos.SelectedIndex = 2;
        ddl_e_pos.SelectedIndex = 2;
        ddl_ai_pos.SelectedIndex = 2;
        ddl_o_pos.SelectedIndex = 2;
        ddl_au_pos.SelectedIndex = 2;
        ddl_an_pos.SelectedIndex = 2;
        ddl_ah_pos.SelectedIndex = 2;
    }
}
