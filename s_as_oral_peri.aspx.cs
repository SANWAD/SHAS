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

public partial class Clinical_Forms_s_as_oral_peri : System.Web.UI.Page
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
            ddl_lips_struct.Focus();
            lbldate.Text = DateTime.Now.Date.ToShortDateString();       
            if (!IsPostBack)
            {
                InitList();
                lbl_msg.Visible = false;
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
                ddl_lips_struct.SelectedItem.Text = DT1.Rows[0][68].ToString();
                //string PUC = DT1.Rows[0][11].ToString();
                //if (PUC == "Adequate")
                //{
                //    rbtn_puck.SelectedIndex = 0;
                //}               
                //else
                //{
                //    rbtn_puck.SelectedIndex = 1;
                //}
                //string BLO = DT1.Rows[0][11].ToString();
                //if (BLO == "Adequate")
                //{
                //    rbtn_blow.SelectedIndex = 0;
                //}
                //else
                //{
                //    rbtn_blow.SelectedIndex = 1;
                //}
                //string SUC = DT1.Rows[0][11].ToString();
                //if (SUC == "Adequate")
                //{
                //    rbtn_suck.SelectedIndex = 0;
                //}
                //else
                //{
                //    rbtn_suck.SelectedIndex = 1;
                //}
                txt_lips.Text = DT1.Rows[0][69].ToString();
                ddl_teeth_struct.SelectedItem.Text = DT1.Rows[0][70].ToString();
                ddl_teeth_funct.SelectedItem.Text = DT1.Rows[0][71].ToString();
                ddl_tongue_struct.SelectedItem.Text = DT1.Rows[0][72].ToString();
                ddl_tongue_funct.SelectedItem.Text = DT1.Rows[0][73].ToString();
                ddl_hard_palate_struct.SelectedItem.Text = DT1.Rows[0][74].ToString();
                ddl_hard_palate_funct.SelectedItem.Text = DT1.Rows[0][75].ToString();
                ddl_soft_palate_struct.SelectedItem.Text = DT1.Rows[0][76].ToString();
                ddl_soft_pal_fun.SelectedItem.Text = DT1.Rows[0][77].ToString();                
               
                txt_par_obs.Text = DT1.Rows[0][78].ToString();
                txtcl_obs.Text = DT1.Rows[0][79].ToString();
                ddl_v_pitch.Text = DT1.Rows[0][80].ToString();
                ddl_voice_qual.SelectedItem.Text = DT1.Rows[0][81].ToString();
                ddl_intensity.SelectedItem.Text = DT1.Rows[0][82].ToString();
                txtmax_phon_dura.Text = DT1.Rows[0][83].ToString();
                ddl_inteligibility.SelectedItem.Text = DT1.Rows[0][84].ToString();
                ddlNasal.SelectedItem.Text = DT1.Rows[0][82].ToString();
                ddl_spont_vocal.SelectedItem.Text = DT1.Rows[0][85].ToString();
                ddl_drool_cont.SelectedItem.Text = DT1.Rows[0][86].ToString();
                ddl_int_cont.SelectedItem.Text = DT1.Rows[0][87].ToString();
                ddl_pitch_cont.SelectedItem.Text = DT1.Rows[0][88].ToString();
                ddl_breath_cont.SelectedItem.Text = DT1.Rows[0][89].ToString();
                ddlDena.SelectedItem.Text = DT1.Rows[0][90].ToString();
                ddl_pa.SelectedItem.Text = DT1.Rows[0][91].ToString();
                ddl_ta.SelectedItem.Text = DT1.Rows[0][92].ToString();
                ddl_ka.SelectedItem.Text = DT1.Rows[0][93].ToString();
                ddl_la.SelectedItem.Text = DT1.Rows[0][94].ToString();               
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

    #region INIT
    public void InitList()
    {
        if (!IsPostBack)
        {

            ddl_pa.Items.Clear();
            ddl_ta.Items.Clear();
            ddl_ka.Items.Clear();
            ddl_la.Items.Clear();

            for (int j = 1; j <= 50; j++)
                ddl_pa.Items.Add(j.ToString());
            ddl_pa.Items.Insert(0, "0");

            for (int k = 1; k <= 50; k++)
                ddl_ta.Items.Add(k.ToString());
            ddl_ta.Items.Insert(0, "0");

            for (int l = 1; l <= 200; l++)
                ddl_ka.Items.Add(l.ToString());
            ddl_ka.Items.Insert(0, "0");

            for (int m = 1; m <= 200; m++)
                ddl_la.Items.Add(m.ToString());
            ddl_la.Items.Insert(0, "0");
        }
    }
    #endregion

   
    protected void btn_save_Click1(object sender, EventArgs e)
    {
        try
        {
            #region Save
            int apt_id = Convert.ToInt32(lbl_aptid.Value);
            int ptnt_id = Convert.ToInt32(lbl_ptntid.Value);
            //int as_id = 0;
            int as_id = Convert.ToInt32(lbl_asid.Value);
            string s_lips_struct = ddl_lips_struct.SelectedItem.Text;
            string s_lips_funct = txt_lips.Text.ToString();
            string s_teeth_stuct = ddl_teeth_struct.SelectedItem.Text;
            string s_teeth_funct = ddl_teeth_funct.SelectedItem.Text;
            string s_tongue_struct = ddl_tongue_struct.SelectedItem.Text;
            string s_tongue_funct = ddl_tongue_funct.SelectedItem.Text;
            string s_hard_pal_struct = ddl_hard_palate_struct.SelectedItem.Text;
            string s_hard_pal_funct = ddl_hard_palate_funct.SelectedItem.Text;
            string s_soft_pal_struct = ddl_soft_palate_struct.SelectedItem.Text;
            string s_soft_pal_funct = ddl_soft_pal_fun.SelectedItem.Text;
            string s_parent_obs = txt_par_obs.Text;
            string s_clinical_obs = txtcl_obs.Text;
            string s_voice_pitch = ddl_v_pitch.SelectedItem.Text;
            string s_voice_quality;            
            if (ddl_voice_qual.SelectedIndex == 1)
            {
                s_voice_quality = ddlNasal.SelectedItem.Text;
            }
            else if (ddl_voice_qual.SelectedIndex == 2)
            {
                s_voice_quality = ddlDena.SelectedItem.Text;
            }   
            else
            {
                s_voice_quality = ddl_voice_qual.SelectedItem.Text;
            }
            string s_voice_intensity = ddl_intensity.SelectedItem.Text;
            int s_max_phon_duration;
            if (txtmax_phon_dura.Text=="")
            {
                s_max_phon_duration = 0;
            }
            else
            {
                s_max_phon_duration = System.Convert.ToInt32(txtmax_phon_dura.Text);
            }
            string s_intiligibility = ddl_inteligibility.SelectedItem.Text;
            string s_spont_vocal = ddl_spont_vocal.SelectedItem.Text;
            string s_drooling_cont = ddl_drool_cont.SelectedItem.Text;
            string s_intension_cont = ddl_int_cont.SelectedItem.Text;
            string s_pitch_cont = ddl_pitch_cont.SelectedItem.Text;
            string s_breath_cont = ddl_breath_cont.SelectedItem.Text;
            string s_dia = rbtn_dia.SelectedItem.Text;
            int s_dia_pa = System.Convert.ToInt32(ddl_pa.SelectedItem.Text);
            int s_dia_ta = System.Convert.ToInt32(ddl_ta.SelectedItem.Text);
            int s_dia_ka = System.Convert.ToInt32(ddl_ka.SelectedItem.Text);
            int s_dia_la = System.Convert.ToInt32(ddl_la.SelectedItem.Text);
            //DateTime cr_dt = Convert.ToDateTime(lbldate.Text);
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";
            
            cn.Open();
            cmd = new SqlCommand("tbl_s_oral_peri_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ps_asses_id", as_id);
            cmd.Parameters.AddWithValue("@papt_id", apt_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@ps_lips_struct", s_lips_struct);
            cmd.Parameters.AddWithValue("@ps_lips_funct", s_lips_funct);
            cmd.Parameters.AddWithValue("@ps_teeth_stuct", s_teeth_stuct);
            cmd.Parameters.AddWithValue("@ps_teeth_funct", s_teeth_funct);
            cmd.Parameters.AddWithValue("@ps_tongue_struct", s_tongue_struct);
            cmd.Parameters.AddWithValue("@ps_tongue_funct", s_tongue_funct);
            cmd.Parameters.AddWithValue("@ps_hard_pal_struct", s_hard_pal_struct);
            cmd.Parameters.AddWithValue("@ps_hard_pal_funct", s_hard_pal_funct);
            cmd.Parameters.AddWithValue("@ps_soft_pal_struct", s_soft_pal_struct);
            cmd.Parameters.AddWithValue("@ps_soft_pal_funct", s_soft_pal_funct);
            cmd.Parameters.AddWithValue("@ps_parent_obs", s_parent_obs);
            cmd.Parameters.AddWithValue("@ps_clinical_obs", s_clinical_obs);
            cmd.Parameters.AddWithValue("@ps_voice_pitch", s_voice_pitch);
            cmd.Parameters.AddWithValue("@ps_voice_quality", s_voice_quality);
            cmd.Parameters.AddWithValue("@ps_voice_intensity", s_voice_intensity);
            cmd.Parameters.AddWithValue("@ps_max_phon_duration", s_max_phon_duration);
            cmd.Parameters.AddWithValue("@ps_intiligibility", s_intiligibility);
            cmd.Parameters.AddWithValue("@ps_spont_vocal", s_spont_vocal);
            cmd.Parameters.AddWithValue("@ps_drooling_cont", s_drooling_cont);
            cmd.Parameters.AddWithValue("@ps_intension_cont", s_intension_cont);
            cmd.Parameters.AddWithValue("@ps_pitch_cont", s_pitch_cont);
            cmd.Parameters.AddWithValue("@ps_breath_cont", s_breath_cont);
            cmd.Parameters.AddWithValue("@ps_dia", s_dia);
            cmd.Parameters.AddWithValue("@ps_dia_pa", s_dia_pa);
            cmd.Parameters.AddWithValue("@ps_dia_ta", s_dia_ta);
            cmd.Parameters.AddWithValue("@ps_dia_ka", s_dia_ka);
            cmd.Parameters.AddWithValue("@ps_dia_la", s_dia_la);
            cmd.Parameters.AddWithValue("@pcreated_by",cr_by);
            //cmd.Parameters.AddWithValue("@pcreated_dt", cr_dt);
            //cn.executeprocedure(cmd);
            int a = cn.executeprocedure(cmd);
            cn.Close();
            #endregion
            Response.Redirect("~/s_as_arti_vovel.aspx");
            btn_save.Enabled = false;
            Save.Enabled = false;
        }
        catch { //Response.Redirect("~/error.aspx"); 
              }
    }
    protected void rbtn_dia_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region DIA
        int def = 0;
        if (rbtn_dia.SelectedIndex == 1)
        {
            ddl_pa.SelectedItem.Text = Convert.ToString(def);
            ddl_ta.SelectedItem.Text = Convert.ToString(def);
            ddl_ka.SelectedItem.Text = Convert.ToString(def);
            ddl_la.SelectedItem.Text = Convert.ToString(def);
           // lbl_msg.Visible = false;
        }
        else
        {
            ddl_pa.SelectedIndex = 0;
            ddl_ta.SelectedIndex = 0;
            ddl_ka.SelectedIndex = 0;
            ddl_la.SelectedIndex = 0;
            //if ((ddl_pa.SelectedIndex == 0) || (ddl_ta.SelectedIndex == 0) || (ddl_ka.SelectedIndex == 0) || (ddl_la.SelectedIndex == 0))
            //{ lbl_msg.Visible = true; }
            //else { lbl_msg.Visible = false; }
        }
        #endregion
    }
    protected void ddl_pa_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void pagevalidate_wiz3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            if ((ddl_lips_struct.SelectedIndex == 0) || (txt_lips.Text == "") || (ddl_teeth_struct.SelectedIndex == 0) || (ddl_teeth_funct.SelectedIndex == 0)
            || (ddl_tongue_struct.SelectedIndex == 0) || (ddl_tongue_funct.SelectedIndex == 0) || (ddl_hard_palate_struct.SelectedIndex == 0) || (ddl_hard_palate_funct.SelectedIndex == 0) ||
            (ddl_soft_palate_struct.SelectedIndex == 0) || (ddl_soft_pal_fun.SelectedIndex == 0) || (txt_par_obs.Text == "") || (txtcl_obs.Text == "") || (ddl_v_pitch.SelectedIndex == 0) ||
            (ddl_voice_qual.SelectedIndex == 0) || (ddl_intensity.SelectedIndex == 0) || (ddl_inteligibility.SelectedIndex == 0) ||
            (ddl_spont_vocal.SelectedIndex == 0) || (ddl_drool_cont.SelectedIndex == 0) || (ddl_int_cont.SelectedIndex == 0) || (ddl_pitch_cont.SelectedIndex == 0) ||
            (ddl_breath_cont.SelectedIndex == 0)) { args.IsValid = false; }
            else { args.IsValid = true; }
        }
        catch {/* Response.Redirect("~/error.aspx"); */}
    }
    protected void btn_prev_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_s_l_dev.aspx");
    }
    protected void btn_nxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_arti_vovel.aspx");
    }
    protected void rbtn_suck_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txt_lips.Text = ("Puckering" + " " + rbtn_puck.SelectedItem.Text + "," + "Blowing" + " " + rbtn_blow.SelectedItem.Text + "," + "Sucking" + " " + rbtn_suck.SelectedItem.Text);
        }
        catch { Response.Write("<script>alert('Please Select Appropriate Data')</script>"); }
    }
    protected void btn_pre_1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_s_l_dev.aspx");
    }
    protected void btn_nxt1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_arti_vovel.aspx");
    }
    protected void ddl_voice_qual_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddl_voice_qual.SelectedIndex==1)
        {
            ddlNasal.Visible = true;
            lblNasal.Visible = true;
            lblDena.Visible = false;
            ddlDena.Visible = false;
        }
        else if (ddl_voice_qual.SelectedIndex == 2)
        {
            ddlNasal.Visible = false;
            lblNasal.Visible = false;
            lblDena.Visible = true;
            ddlDena.Visible = true;
        }
        else
        {
            ddlNasal.Visible = false;
            lblNasal.Visible = false;
            lblDena.Visible = false;
            ddlDena.Visible = false;
        }


    }
}
