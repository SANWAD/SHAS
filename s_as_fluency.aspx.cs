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
public partial class Clinical_Forms_s_as_fluency : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    double id,id1,id2,id3,id4,id5,id6;
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
               rbtn_fl_appl.Focus();
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
                txt_pauses.Text = DT1.Rows[0][193].ToString();
                ddl_repatation.SelectedItem.Text = DT1.Rows[0][194].ToString();
                ddl_read.SelectedItem.Text = DT1.Rows[0][195].ToString();
                ddl_strang.SelectedItem.Text = DT1.Rows[0][196].ToString();
                ddl_op_gender.SelectedItem.Text = DT1.Rows[0][197].ToString();
                ddl_var_lang.SelectedItem.Text = DT1.Rows[0][199].ToString();
                ddl_word_spec.SelectedItem.Text = DT1.Rows[0][200].ToString();
                ddl_secondries.SelectedItem.Text = DT1.Rows[0][202].ToString();
                string INIT = DT1.Rows[0][210].ToString();
                if (INIT == "Normal")
                {
                    rbtTInit.SelectedIndex = 0;
                }
                else if (INIT == "Inadequate")
                {
                    rbtTInit.SelectedIndex = 1;
                }
                else if (INIT == "Not Developed")
                {
                    rbtTInit.SelectedIndex = 3;
                }
                else
                {
                    rbtTInit.SelectedIndex = 2;
                }

                string TM = DT1.Rows[0][211].ToString();
                if (TM == "Normal")
                {
                    rbtTmain.SelectedIndex = 0;
                }
                else if (TM == "Inadequate")
                {
                    rbtTmain.SelectedIndex = 1;
                }
                else if (TM == "Not Developed")
                {
                    rbtTmain.SelectedIndex = 3;
                }
                else
                {
                    rbtTmain.SelectedIndex = 2;
                }

                string TC = DT1.Rows[0][212].ToString();
                if (TC == "Normal")
                {
                    rbtTClo.SelectedIndex = 0;
                }
                else if (TC == "Inadequate")
                {
                    rbtTClo.SelectedIndex = 1;
                }
                else if (TC == "Not Developed")
                {
                    rbtTClo.SelectedIndex = 3;
                }
                else
                {
                    rbtTClo.SelectedIndex = 2;
                }


                string ST = DT1.Rows[0][213].ToString();
                if (ST == "Normal")
                {
                    rbtSTell.SelectedIndex = 0;
                }
                else if (ST == "Inadequate")
                {
                    rbtSTell.SelectedIndex = 1;
                }
                else if (ST == "Not Developed")
                {
                    rbtSTell.SelectedIndex = 3;
                }
                else
                {
                    rbtSTell.SelectedIndex = 2;
                }

                txtmed_age.Text = DT1.Rows[0][206].ToString();
                txt_lang_mnths.Text = DT1.Rows[0][207].ToString();
                txtmed_age1.Text = DT1.Rows[0][208].ToString();
                txt_lang_mnths1.Text = DT1.Rows[0][209].ToString();
                txt_pro_diagn.Text = DT1.Rows[0][204].ToString();
                txtoverimpression.Text = DT1.Rows[0][205].ToString();
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
    protected void btn_save_Click1(object sender, EventArgs e)
    {
        try
        {
            #region Save
            int apt_id = Convert.ToInt32(lbl_aptid.Value);
            int ptnt_id = Convert.ToInt32(lbl_ptntid.Value);
            int as_id = Convert.ToInt32(lbl_asid.Value);
            //int as_id = 0;
            string s_fl_pause = txt_pauses.Text.ToString(); 
            string s_fl_repetation = ddl_repatation.SelectedItem.Text.ToString(); 
            string s_fl_reading = ddl_read.SelectedItem.Text.ToString(); 
            string s_fl_strangers = ddl_strang.SelectedItem.Text.ToString(); 
            string s_fl_opp_gender = ddl_op_gender.SelectedItem.Text.ToString(); 
            string s_fl_var_wit_lang = ddl_var_lang.SelectedItem.Text.ToString(); 
            string s_fl_var_lagn = txt_var_lang.Text.ToString();
            string s_fl_word_spec = ddl_word_spec.SelectedItem.Text.ToString();
            string s_fl_word_spec_pre = txt_word_spec.Text.ToString();
            string s_fl_secondries = ddl_secondries.SelectedItem.Text.ToString();
            string s_fl_sec_pres = txt_second.Text.ToString();
            string s_prov_dig=txt_pro_diagn.Text.ToString();
            string s_over_impression = txtoverimpression.Text.ToString();
            string s_med_age, s_med_age1, s_med_age2, s_med_age3;
            string ToppicI = rbtTInit.SelectedItem.Text;
            string ToppicM = rbtTmain.SelectedItem.Text;
            string ToppicC = rbtTClo.SelectedItem.Text;
            string STE = rbtSTell.SelectedItem.Text;
            DateTime cr_dt = Convert.ToDateTime(lblDate.Text);
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            if (txtmed_age.Text == "" && txt_lang_mnths.Text == "")
            {
                s_med_age = "NA";
                s_med_age1 = "NA";
            }
            else
            {
                s_med_age = txtmed_age.Text;
                s_med_age1 = txt_lang_mnths.Text;
            }

            if (txtmed_age1.Text == "" && txt_lang_mnths1.Text == "")
            {
                s_med_age2 = "NA";
                s_med_age3 = "NA";
            }
            else
            {               
                s_med_age2 = txtmed_age1.Text;                
                s_med_age3 = txt_lang_mnths1.Text;
            }
            //int s_med_age = System.Convert.ToInt32(txtmed_age.Text);
            //int s_med_age1 = System.Convert.ToInt32(txt_lang_mnths.Text);
            //int s_med_age2 = System.Convert.ToInt32(txtmed_age1.Text);
            //int s_med_age3 = System.Convert.ToInt32(txt_lang_mnths1.Text);
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_s_fluency_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ps_asses_id", as_id);
            cmd.Parameters.AddWithValue("@papt_id", apt_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);            
            cmd.Parameters.AddWithValue("@ps_fl_pause", s_fl_pause);
            cmd.Parameters.AddWithValue("@ps_fl_repetation", s_fl_repetation);
            cmd.Parameters.AddWithValue("@ps_fl_reading", s_fl_reading);
            cmd.Parameters.AddWithValue("@ps_fl_strangers", s_fl_strangers);
            cmd.Parameters.AddWithValue("@ps_fl_opp_gender", s_fl_opp_gender);
            cmd.Parameters.AddWithValue("@ps_fl_var_wit_lang", s_fl_var_wit_lang);
            cmd.Parameters.AddWithValue("@ps_fl_var_lagn", s_fl_var_lagn);
            cmd.Parameters.AddWithValue("@ps_fl_word_spec", s_fl_word_spec);
            cmd.Parameters.AddWithValue("@ps_fl_word_spec_pre", s_fl_word_spec_pre);
            cmd.Parameters.AddWithValue("@ps_fl_secondries", s_fl_secondries);
            cmd.Parameters.AddWithValue("@ps_fl_sec_pres", s_fl_sec_pres);
            cmd.Parameters.AddWithValue("@ps_over_impression", s_over_impression);
            cmd.Parameters.AddWithValue("@ps_prov_dig",s_prov_dig );
            cmd.Parameters.AddWithValue("@ps_med_age", s_med_age);
            cmd.Parameters.AddWithValue("@ps_med_age_1", s_med_age1);
            cmd.Parameters.AddWithValue("@ps_med_age2", s_med_age2);
            cmd.Parameters.AddWithValue("@ps_med_age_3", s_med_age3);
            cmd.Parameters.AddWithValue("@pTop_I", ToppicI);
            cmd.Parameters.AddWithValue("@pTop_M", ToppicM);
            cmd.Parameters.AddWithValue("@pTop_C", ToppicC);
            cmd.Parameters.AddWithValue("@pSTE", STE);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cn.executeprocedure(cmd);
            cn.Close();
            #endregion
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Print();
            }
            else
            {
                Response.Redirect("~/S_assessment_Grid.aspx");
            }
            btn_save.Enabled = false;
            btn_print.Enabled = true;
        }
        catch { /*Response.Redirect("~/error.aspx");*/ }
    }
    protected void ddl_var_lang_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_var_lang.SelectedIndex == 1)
        { txt_var_lang.Visible = true; }
        else
        { txt_var_lang.Visible = false; }
    }
    protected void ddl_word_spec_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_word_spec.SelectedIndex == 1)
        { txt_word_spec.Visible = true; }
        else
        { txt_word_spec.Visible = false; }
    }
    protected void ddl_secondries_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_secondries.SelectedIndex == 1)
        {
            txt_second.Visible = true;
        }
        else { txt_second.Visible = false; }
    }
    protected void page_validation_wiz6_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            if (rbtn_fl_appl.SelectedIndex == 0)
            {
                if ((txt_pauses.Text == "") || (ddl_repatation.SelectedIndex == 0) ||
               (ddl_read.SelectedIndex == 0) || (ddl_strang.SelectedIndex == 0) || (ddl_op_gender.SelectedIndex == 0) || (ddl_var_lang.SelectedIndex == 0) ||
               (ddl_word_spec.SelectedIndex == 0) || (ddl_secondries.SelectedIndex == 0) || (txtoverimpression.Text == "") || (txtmed_age.Text == ""))
                { args.IsValid = false; }
                else { args.IsValid = true; }
            }
        }
        catch {/* Response.Redirect("~/error.aspx");*/ }
    }
    protected void btn_prev_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_art_conso_2.aspx");
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {
        Print();
    }
    protected void btn_prev1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_art_conso_2.aspx");
     }

    protected void rbtn_fl_appl_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Applicable
        if(rbtn_fl_appl.SelectedIndex == 1)
        {
            txt_pauses.Text = "Normal";
            ddl_repatation.SelectedIndex = 5;
            ddl_read.SelectedIndex = 4;
            ddl_strang.SelectedIndex = 5;
            ddl_op_gender.SelectedIndex = 5;
            ddl_var_lang.SelectedIndex = 4;
            txt_var_lang.Text = "Normal";
            ddl_word_spec.SelectedIndex = 4;
            txt_word_spec.Text = "Normal";
            ddl_secondries.SelectedIndex = 4;
            txt_second.Text = "Not Applicable";
        }
        else if (rbtn_fl_appl.SelectedIndex == 2)
        {
            txt_pauses.Text = "Not Applicable";
            ddl_repatation.SelectedIndex = 4;
            ddl_read.SelectedIndex = 3;
            ddl_strang.SelectedIndex = 4;
            ddl_op_gender.SelectedIndex = 4;
            ddl_var_lang.SelectedIndex = 3;
            txt_var_lang.Text = "Not Applicable";
            ddl_word_spec.SelectedIndex = 3;
            txt_word_spec.Text = "Not Applicable";
            ddl_secondries.SelectedIndex = 3;
            txt_second.Text = "Not Applicable";
        }
        else 
        {
            txt_pauses.Text = "";
            ddl_repatation.SelectedIndex = 0;
            ddl_read.SelectedIndex = 0;
            ddl_strang.SelectedIndex = 0;
            ddl_op_gender.SelectedIndex = 0;
            ddl_var_lang.SelectedIndex = 0;
            txt_var_lang.Text = "";
            ddl_word_spec.SelectedIndex = 0;
            txt_word_spec.Text = "";
            ddl_secondries.SelectedIndex = 0;
            txt_second.Text = "";
        }
        #endregion
    }
    public void Print()
    {
        #region CHECK DATA
        //id1 = cn.getmaxid("Select max(s_asses_id)from tbl_as_s_l_assess", "tbl_as_s_l_assess");
        //id2 = cn.getmaxid("Select max(s_asses_id)from tbl_s_oral_peri", "tbl_s_oral_peri");
        //id3 = cn.getmaxid("Select max(s_asses_id)from tbl_s_art_vovels", "tbl_s_art_vovels");
        //id4 = cn.getmaxid("Select max(s_asses_id)from tbl_s_conso1", "tbl_s_conso1");
        //id5 = cn.getmaxid("Select max(s_asses_id)from tbl_s_conso2", "tbl_s_conso2");
        //id6 = cn.getmaxid("Select max(s_asses_id)from tbl_s_fluency", "tbl_s_fluency");

        //if (id != id1)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Speech and Language Development')</script>");
        //}
        //else if (id != id2)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Oral Motor Assesment')</script>");
        //}
        //else if (id != id3)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Articulation Vovels')</script>");
        //}
        //else if (id != id4)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Articulation Consonants 1')</script>");
        //}
        //else if (id != id5)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Articulation Consonants 2')</script>");
        //}
        //else if (id != id6)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Fluency')</script>");
        //}
        //else
        //{
            int ids = Convert.ToInt32(lbl_asid.Value);
            Response.Redirect("~/speech_as_rpt.aspx?asses_id=" + ids);
        //}
        #endregion
    }
}
