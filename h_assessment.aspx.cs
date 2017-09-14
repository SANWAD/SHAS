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
using System.Text.RegularExpressions;

public partial class Inward : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    SqlDataAdapter da;
    DataSet ds,ds1;
    string aptid, apt_for;
    double id;
    DateTime dt, Birth_Dt;
    int a;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new connection();
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
         if (!IsPostBack)
            {
                txtptntNm.Focus();
                #region Load Event

                btn_inf.Enabled  = false;
                txt_inf_other.Enabled = false;
                btn_disease.Enabled = false;
                txt_disease_other.Enabled = false;
                ddl_duration.Enabled = false;
                ddltoxnm.Enabled = false;
                lblot_tox.Enabled = false;
                txt_noi_exp.Enabled = false;
                rbtearsite.Enabled = false;
                Label3.Enabled = false;
                Label26.Enabled = false;
                txtprevexp.Enabled = false;

                #region machine Company

                Image1.Visible = false;
                cn.Open();
                
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_Mach_Desc_ddl";
                DataTable DT_comp = new DataTable();

                dr = cmd.ExecuteReader();
                DT_comp.Load(dr);

                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp.SelectedIndex = 0;
                dr = null;
                cn.Close();

                #endregion
                ddl_comp.Enabled = false;
                ddl_mach_model.Enabled = false;
                ddl_mach_type.Enabled = false;
                txt_mach.Enabled = false;
                ddl_comp.Enabled = false;
                txt_mach.Enabled = false;
                txt_comp.Enabled = false;
                             
                inf();
                dis();
                #endregion

                if (Convert.ToInt32(Session["Ass_id"].ToString())==0)
                {
                    int Apt_id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    aptid = Request.QueryString["id"].ToString();
                    DataFill(Apt_id);
                    btn_print.Visible = false;
                }
                else
                {
                    btn_print.Visible = true;
                    Select();  
                }
            }
        }
        // txtptntNm.Focus();
   }
    public void GridLoad()
    {
        double pid = System.Convert.ToInt32(lblptnt_id.Value);
        cn.Open();
        cmd = connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from tbl_h_as_trn where ptnt_id=" + pid + "";
        //cmd.CommandText = "select   H_Ass.h_as_id, H_Ass.apt_id, H_Ass.ptnt_id, h_comp, h_as_birth_histry, h_as_med_histry, h_as_consagnuinity, h_as_infection, h_as_diesase, h_as_noise_exposure,h_as_ototoxicity, h_trauma, h_as_prev_hear_aid_user, h_as_ear_site, h_prev_h_aid, h_as_exp_wit_haid, H_Ass.created_by, H_Ass.revised_by, H_Ass.created_dt, H_Ass.revised_dt from tbl_h_as_trn AS H_Ass INNER JOIN dbo.tbl_h_digno_trn AS DT ON H_Ass.h_as_id = DT.h_as_id where ptnt_id=" + pid + "";

        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "tbl_assess");

        if (ds.Tables["tbl_assess"].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables["tbl_assess"];
            GridView1.DataBind();
            Label1.Text = (ds.Tables["tbl_assess"].Rows[0][2].ToString());
        }
        else
        {
            Response.Write("<script>alert('Please Select Valid Patient')</script>");
        }
        cn.Close();
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
                cmd = new SqlCommand("sp_H_Ass_Id_Rpt", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ph_as_id", Ass_id);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblas_id.Value= DT1.Rows[0][0].ToString();
                lblaptid.Value = DT1.Rows[0][1].ToString();
                DataFill(Convert.ToInt32(lblaptid.Value));
                txt_comp.Text  = DT1.Rows[0][4].ToString();
                txtbirthhistry.Text = DT1.Rows[0][5].ToString();
                txtmedhistry.Text = DT1.Rows[0][6].ToString();
                txtcons.Text = DT1.Rows[0][7].ToString();
                txt_inf_other.Text = DT1.Rows[0][8].ToString();
                txt_disease_other.Text = DT1.Rows[0][9].ToString();
                txt_noi_exp.Text  = DT1.Rows[0][10].ToString();
                ddltoxnm.SelectedItem.Text = DT1.Rows[0][11].ToString();
                txttrauma.Text = DT1.Rows[0][12].ToString();
                string Prev = DT1.Rows[0][13].ToString();
                if (Prev=="Yes")
                {
                    rbtp_h_a_user.SelectedIndex = 0;
                }
                else
                {
                    rbtp_h_a_user.SelectedIndex = 1;
                }
                string Site = DT1.Rows[0][14].ToString();
                if (Site == "Left")
                {
                    rbtearsite.SelectedIndex = 0;
                }
                else if (Site == "Right")
                {
                    rbtearsite.SelectedIndex = 1;
                }
                else
                {
                    rbtearsite.SelectedIndex = 2;
                }
                txt_mach.Text = DT1.Rows[0][15].ToString();
                txtprevexp.Text = DT1.Rows[0][16].ToString();
                dr = null;
                cn.Close();
                GridLoad();
                btn_save.Text = "Edit";
            }
            catch
            { }

            #endregion
        }
    }
    public void DataFill(int Apt_id)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Sanwad"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_ptnt_info_Apt_id";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_apt_id", Apt_id);
                lblaptid.Value = Apt_id.ToString();
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {                    
                    while (sdr.Read())
                    {                       
                        lblptnt_id.Value = sdr["ptnt_id"].ToString();
                        lblptnttype.Text = sdr["Ptntype"].ToString();
                        txtptntNm.Text = sdr["ptnt_nm"].ToString();
                        lblptntdob.Text = sdr["ptnt_dob"].ToString();
                        lblgender.Text = sdr["ptnt_gender"].ToString();
                        lblprofession.Text = sdr["ptnt_prof"].ToString();
                        dt = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
                        Birth_Dt = DateTime.ParseExact(lblptntdob.Text, "MM/dd/yyyy", null);
                        string Year = Convert.ToString((dt.Year) - (Birth_Dt.Year));
                        string Month = Convert.ToString((dt.Month) - (Birth_Dt.Month));
                        string Days = Convert.ToString((dt.Day) - (Birth_Dt.Day));
                        lblptntage.Text = (Year + " Year" + ',' + Month + " Month" + ',' + Days + " Days");
                        txtptntNm.Enabled = false;
                        lblptntdob.Enabled = false;
                        lblgender.Enabled = false;
                        lblprofession.Enabled = false;
                        lblptntage.Enabled = false;
                        lblptnttype.Enabled = false;
                        ddl_complaints.Focus();
                    }
                }
                conn.Close();
            }
        }
    }
    protected void rbtototxo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtototxo.SelectedIndex == 0)
        {
            ddl_duration.Enabled  = true;
            ddltoxnm.Enabled = true;
            lblot_tox.Enabled = true;
            ddltoxnm.Focus();
        }
        else
        {
            ddl_duration.Enabled = false;
            ddltoxnm.Enabled = false;
            lblot_tox.Enabled = false;
            lblot_tox.Text = "NA"; 
        }
    }
    protected void ddl_duration_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblot_tox.Text = (System.Convert.ToString(ddltoxnm.SelectedItem.Text + "," + ddl_duration.SelectedItem.Text));
        rbtp_h_a_user.Focus();
    } 
    #region Disease & Infection
    protected void lst_infection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lst_infection.SelectedIndex == 0)
        { Response.Write("<script>alert('Please Select Valid Infection !!!')</script>");        }
        else
        {            
            if (lst_infection.SelectedIndex ==1)
            {
                txt_inf_other.Text = "";
                btn_inf.Enabled  = true;
                txt_inf_other.Enabled = true;
            }
            else
            {
                txt_inf_other.Enabled  = true;
                btn_inf.Enabled = false;
                txt_inf_other.Text = lst_infection.SelectedItem.Text;
            }
            //lst_disease.Focus();
        }
    }
    protected void lst_disease_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lst_disease.SelectedIndex == 0)
        { Response.Write("<script>alert('Please Select Valid Disease !!!')</script>"); }
        else
        {            
            if (lst_disease.SelectedIndex == 1)
            {
                txt_disease_other.Text = "";
                btn_disease.Enabled  = true;
                txt_disease_other.Enabled = true;
            }
            else
            {
                btn_disease.Enabled = false;
                txt_disease_other.Enabled = true;
                txt_disease_other.Text = lst_disease.SelectedItem.Text;
            }
            //txt_n_i.Focus();
        }
    }
    protected void btn_disease_Click(object sender, EventArgs e)
    {
        if (txt_disease_other.Text == "")
        {
            txt_disease_other.Focus();
        }
        else
        {
            string inf = txt_disease_other.Text;
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_lst_disease_master_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@pdisease_id", 0);
            cmd.Parameters.AddWithValue("@p_disease", inf);
            cn.executeprocedure(cmd);
            cn.Close();
            txt_disease_other.Text = "";

            btn_disease.Enabled  = false;
            txt_disease_other.Enabled  = false;
            dis();
        }
    }
    protected void btn_inf_Click(object sender, EventArgs e)
    {
        if (txt_inf_other.Text == "")
        {
            txt_inf_other.Focus();
        }
        else
        {
            string inf1 = txt_inf_other.Text;
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_lst_infection_master_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@pinfe_id", 0);
            cmd.Parameters.AddWithValue("@p_infection", inf1);          
            cn.executeprocedure(cmd);
            cn.Close();
            txt_inf_other.Text = "";
            //btn_inf.Visible = false;
            //txt_inf_other.Visible = false;

            btn_inf.Enabled  = false;
            txt_inf_other.Enabled  = false;
            inf();
        }
    }
    #endregion
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtptntNm.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }    
    #region Previous H User
    protected void rbtp_h_a_user_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtp_h_a_user.SelectedIndex == 0)
        {
            rbtearsite.Enabled = true;            
            ddl_comp.Enabled = true;
            Label3.Enabled = true;
            Label26.Enabled = true;
            txtprevexp.Enabled = true;
            Label21.Enabled = true;
            rbtearsite.Focus();
            txt_mach.Enabled = true;
        }
        else
        {            
            Label3.Enabled = false;
            Label26.Enabled = false;
            ddl_comp.SelectedIndex = 0;
            //ddl_mach_model.SelectedIndex = 0;
            //ddl_mach_type.SelectedIndex = 0;
            ddl_comp.Enabled = false;
            ddl_mach_model.Enabled = false;
            ddl_mach_type.Enabled = false;
            txtprevexp.Enabled = false;
            Label21.Enabled = false;
            txt_mach.Enabled = true;
         }
    }
    #endregion
    protected void ddl_premach_type_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {       
        #region Save
        int h_ass_id = 0;
        int aptid = System.Convert.ToInt32(lblaptid.Value);
        //string ptnt_nm1 = txtptntNm.Text;
        //string[] WordArray = ptnt_nm1.Split('-');
        //string Name = WordArray[0].ToString();
        //lblptnt_id.Value = WordArray[1];
        int ptntid = System.Convert.ToInt32(lblptnt_id.Value);
        string comp = txt_comp.Text.ToString();
        string birth_h = txtbirthhistry.Text.ToString();
        string med_h = txtmedhistry.Text.ToString();
        string cons = txtcons.Text.ToString();
        string inf = txt_inf_other.Text.ToString();
        string dis = txt_disease_other.Text.ToString();
        string n_e;
        if (txt_noi_exp.Text=="")
        {
            n_e = "NA";
        }
        else
        {
            n_e = txt_noi_exp.Text.ToString();
        }
        string oto = lblot_tox.Text.ToString();
        string traum = txttrauma.Text.ToString();
        string p_h_u = (rbtp_h_a_user.SelectedItem.Text).ToString();
        string ear_sit;
        string p_h_aid = txt_mach.Text;
        string p_h_exp = txtprevexp.Text.ToString();
        string Flag = "I";
        int cr_by = Convert.ToInt32(Session["Name"].ToString());
        string Cur_Age = lblptntage.Text;
        if (rbtp_h_a_user.SelectedIndex == 1)
        {
            ear_sit = "N.A.";
            p_h_aid = "N.A.";
            p_h_exp = "N.A.";
        }
        else
        {
            ear_sit = rbtearsite.SelectedItem.Text;
            p_h_aid = txt_mach.Text;
            p_h_exp = txtprevexp.Text;
        }        
            try
            {
                cn.Open();
                cmd = new SqlCommand("tbl_h_as_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@ph_as_id", h_ass_id);
                cmd.Parameters.AddWithValue("@papt_id", aptid);
                cmd.Parameters.AddWithValue("@pptnt_id", ptntid);
                cmd.Parameters.AddWithValue("@ph_comp", comp);
                cmd.Parameters.AddWithValue("@ph_as_birth_histry", birth_h);
                cmd.Parameters.AddWithValue("@ph_as_med_histry", med_h);
                cmd.Parameters.AddWithValue("@ph_as_consagnuinity", cons);
                cmd.Parameters.AddWithValue("@ph_as_infection", inf);
                cmd.Parameters.AddWithValue("@ph_as_diesase", dis);
                cmd.Parameters.AddWithValue("@ph_as_noise_exposure", n_e);
                cmd.Parameters.AddWithValue("@ph_as_ototoxicity", oto);
                cmd.Parameters.AddWithValue("@ph_trauma", traum);
                cmd.Parameters.AddWithValue("@ph_as_prev_hear_aid_user", p_h_u);
                cmd.Parameters.AddWithValue("@ph_as_ear_site", ear_sit).ToString();
                cmd.Parameters.AddWithValue("@ph_prev_h_aid", p_h_aid);
                cmd.Parameters.AddWithValue("@ph_as_exp_wit_haid", p_h_exp);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCur_Age", Cur_Age);    
                //cn.executeprocedure(cmd);
                a = cn.executeprocedure(cmd);
                Session["H_as_id"] = a.ToString();
                cn.Close();
                //Session["Apt_Id"] = Request.QueryString["id"].ToString();
                //Session["Ptnt_Id"] = lblptnt_id.Value;
                string bill = txtptntNm.Text.ToString();
                Response.Redirect("~/h_digno.aspx?bill_no=" + bill);


                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                btn_save.Enabled = false;
                btnnxt.Enabled = true;
                //Button1.Enabled = true;
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
                //Response.Redirect("~/error.aspx");
            }
            #endregion
    }
    protected void ddlnoise_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlnoise.SelectedIndex==1)&(txt_n_i.Text == ""))
        {
            txt_n_i.Enabled = false;
            txt_n_i.Text="Not Applicable";
            txt_noi_exp.Enabled  = true;
            txt_noi_exp.Text = "Not Applicable";
        }        
        else
        {
            txt_noi_exp.Enabled  = true;
            txt_noi_exp.Text = System.Convert.ToString(txt_n_i.Text + "," + ddlnoise.SelectedItem.Text + "");
        }
        txttrauma.Focus();
    }
    public string RemoveAllWhitespace(string str)
    {
        try
        {
            Regex reg = new Regex(@"\s*");
            str = reg.Replace(str, "");
            return str;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddl_mach_model_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_model.SelectedIndex > 0)
        {
            #region Machine Type
            try
            {
                cn.Open();
                ddl_mach_type.Items.Clear();
                int Mach_Desc = Convert.ToInt32(ddl_comp.SelectedValue);
                string Mach_Model = ddl_mach_model.SelectedItem.Text;
                cmd = new SqlCommand("sp_Mach_Type_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
                cn.executeprocedure(cmd);
                DataTable DT_type = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_type.Load(dr);

                ddl_mach_type.DataSource = DT_type;
                ddl_mach_type.DataValueField = "mach_id";
                ddl_mach_type.DataTextField = "mach_type";
                ddl_mach_type.DataBind();
                ddl_mach_type.Items.Insert(0, new ListItem("Type", "ptnt_nm"));
                ddl_mach_type.SelectedIndex = 0;

                dr = null;
                cn.Close();
                //ddl_mach_type.Visible = true;
                ddl_mach_type.Enabled  = true;
                ddl_mach_type.Focus();
            }
            catch {/* Response.Redirect("~/error.aspx");*/ }
            #endregion
        }
    }
    protected void ddl_mach_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type.SelectedIndex > 0)
        {
            #region Machine Final
            txt_mach.Visible = true;
            txt_mach.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_mach_type.SelectedItem.Text));
            #endregion
            txtprevexp.Focus();
        }
    }
    protected void ddl_comp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_comp.SelectedIndex > 0)
        {
            #region Machine Model
            try
            {
                cn.Open();
                ddl_mach_model.Items.Clear();
                // string Mach_Desc = ddl_comp.SelectedItem.Text;
                int Mach_Desc = Convert.ToInt32(ddl_comp.SelectedValue);
                cmd = new SqlCommand("sp_Mach_Model_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cn.executeprocedure(cmd);
                DataTable DT_model = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_model.Load(dr);

                ddl_mach_model.DataSource = DT_model;
                ddl_mach_model.DataValueField = "mach_id";
                ddl_mach_model.DataTextField = "mach_model";
                ddl_mach_model.DataBind();
                ddl_mach_model.Items.Insert(0, new ListItem("Select", "mach_model"));
                ddl_mach_model.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_model.Enabled = true;
                ddl_mach_model.Focus();
            }
            catch {/* Response.Redirect("~/error.aspx");*/ }
            #endregion            
        }   
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {     
        Session["H_as_id"] = lblas_id.Value;
        //Session["Apt_Id"] = Request.QueryString["id"].ToString();
        //Session["Ptnt_Id"] = lblptnt_id.Value;
        string bill = txtptntNm.Text.ToString();
        Response.Redirect("~/h_digno.aspx?bill_no=" + bill);

    }
    public void Image()
    {
        #region Image
        try
        {
            cn.Open();
            double id = Convert.ToDouble(lblptnt_id.Value);
            string qry = "select * from tbl_ptnt_image" +
                                     @" where ptnt_id='" + id + "' ";
            ds1 = cn.GetData(qry, "tbl_ptnt_image");
            //cmd = new SqlCommand("tbl_ptn_mast_Select", connection.con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@pptnt_id", id);
            //cn.Open();
            //cn.executeprocedure(cmd);
            //DataTable DT1 = new DataTable();
            //SqlDataSource ds1=new SqlDataSource();
            //cn.Open();
            //dr = cmd.ExecuteReader();
            //DT1.Load(dr);
            if (ds1.Tables["tbl_ptnt_image"].Rows.Count == 0)
            {
                Image1.Visible = false;
            }
            else
            {
                qry = ds1.Tables["tbl_ptnt_image"].Rows[0][0].ToString();

                if (ds1.Tables["tbl_ptnt_image"].Rows.Count > 0)
                {
                    Image1.ImageUrl = "~/ShowImage.ashx?id=" + id;
                    Image1.Visible = true;
                }
            }
        }
        catch
        {
            //Response.Redirect("~/error.aspx");
        }
      #endregion
    }
    protected void inf()
    {
        #region Infection Function
        cn.Open();
        string inf1 = ("select * from lst_infection_master");
        ds = cn.GetData(inf1, "lst_infection_master");
        if (ds.Tables["lst_infection_master"].Rows.Count==0)
        {
           string[] infection={"Select","Other","Nil"};
            for(int i=0;i<infection.Length;i++) 
            {
            cn.Open();
            cmd = new SqlCommand("sp_infection_master_insert", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_infection", infection[i].ToString());
            cn.executeprocedure(cmd);
            }
            cn.Open();
            cmd = connection.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "sp_Infe_Select";
            DataTable dtinf = new DataTable();
            dr = cmd.ExecuteReader();
            dtinf.Load(dr);
            lst_infection.DataSource = dtinf;
            lst_infection.DataValueField = "infe_id";
            lst_infection.DataTextField = "infection";
            lst_infection.DataBind();
            cn.Close();
        }
        else
        {
            cn.Open();
            cmd = connection.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "sp_Infe_Select";
            DataTable dtinf = new DataTable();
            dr = cmd.ExecuteReader();
            dtinf.Load(dr);
            lst_infection.DataSource = dtinf;
            lst_infection.DataValueField = "infe_id";
            lst_infection.DataTextField = "infection";
            lst_infection.DataBind();
            dr = null;
            cn.Close();
        }
        #endregion
    }
    protected void dis()
    {
        #region Disease Function
        cn.Open();
        string dis1 = ("select * from lst_disease_master");
          ds = cn.GetData(dis1, "lst_disease_master");
          if (ds.Tables["lst_disease_master"].Rows.Count == 0)
          {
              string[] disease ={ "Select", "Other", "Nil" };
              for (int i = 0; i < disease.Length; i++)
              {
                  cn.Open();
                  cmd = new SqlCommand("sp_disease_master_insert", connection.con);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@p_disease", disease[i].ToString());
                  cn.executeprocedure(cmd);
                  cn.Close();
             }
             cn.Open();
             cmd = connection.con.CreateCommand();
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "sp_dise_Select";
             DataTable dt_dis = new DataTable();
             dr = cmd.ExecuteReader();
             dt_dis.Load(dr);
             lst_disease.DataSource = dt_dis;
             lst_disease.DataValueField = "disease_id";
             lst_disease.DataTextField = "disease";
             lst_disease.DataBind();
             dr = null;
             cn.Close();             
          }
          else
          {
              cn.Open();
              cmd = connection.con.CreateCommand();
              cmd.CommandType = CommandType.Text;
              cmd.CommandText = "sp_dise_Select";
              DataTable dt_dis = new DataTable();
              dr = cmd.ExecuteReader();
              dt_dis.Load(dr);
              lst_disease.DataSource = dt_dis;
              lst_disease.DataValueField = "disease_id";
              lst_disease.DataTextField = "disease";
              lst_disease.DataBind();
              dr = null;
              cn.Close();
          }
        #endregion
      }
    protected void ddl_complaints_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_complaints.SelectedIndex > 0)
        {
            txt_comp.Enabled = true;
            txt_comp.Text = (ddl_complaints.SelectedItem.Text);
            //txtbirthhistry.Focus();
        }        
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Session["Apt_Id"] = Request.QueryString["id"].ToString(); 
        Session["Ptnt_Id"] = lblptnt_id.Value;
        Session["H_as_id"] = lblas_id.Value;
        string bill = txtptntNm.Text.ToString();
        Response.Redirect("~/h_digno.aspx?bill_no=" + bill);        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime dt;
        dt = Convert.ToDateTime(GridView1.SelectedRow.Cells[0].Text);
        int id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);       
        lblas_id.Value  = "";
        lblptnt_id.Value  = "";
        Session["Ass_id"] = id.ToString();
        Select();
    }
    protected void rbtearsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtearsite.SelectedIndex == 0)
        {
            ddl_comp.Enabled = true;
        }
        else if (rbtearsite.SelectedIndex == 1)
        {
            ddl_comp.Enabled = true;
        }
        else
        {
            ddl_comp.Enabled = true;
        }
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {
        print();
    }
    public void print()
    {
        Session["H_as_id"] = Session["Ass_id"].ToString();
        int billno = Convert.ToInt32(Session["H_as_id"].ToString());
        Response.Redirect("~/h_as.aspx?bill_no=" + billno);
    }
}
