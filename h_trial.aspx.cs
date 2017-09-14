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

public partial class h_trial : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlDataReader dr;
    SqlDataAdapter da;
    connection cn;
    DataSet ds;
    double id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            cn = new connection();
            PtntNm.ContextKey = Session["Cntr_id"].ToString();
            if (!IsPostBack)
            {
                ddl_comp.Enabled = false;
                ddl_mach_model.Enabled = false;
                ddl_mach_type.Enabled = false;
                txt_mach.Enabled = false;
                ddl_comp1.Enabled = false;
                ddl_model1.Enabled = false;
                ddl_type1.Enabled = false;
                txt_mach1.Enabled = false;
                Label16.Enabled = false;
                #region machine Company
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
                Clear();
                Select();
                
            }
       }
    }
    public void Clear()
    {
        ddl_mach_model.Enabled = false;
        ddl_mach_type.Enabled = false;
        txt_mach.Enabled = false;
    }
    public void Select()
    {
        if (Request.QueryString["trial_id"].ToString() != "0")
        {
            #region Select
            try
            {               
                string id1;
                id1 = (Request.QueryString["trial_id"].ToString());
                double h_t_id = System.Convert.ToInt32(id1);               
                cn.Open();
                cmd = new SqlCommand("hm_trial_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ph_t_id", h_t_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);

                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbtrial_id.Value = DT1.Rows[0][0].ToString();
                lblptnt_id.Value = DT1.Rows[0][1].ToString();
                ddl_complete.SelectedValue = DT1.Rows[0][3].ToString();
                lbl_mach_id_rt.Value = DT1.Rows[0][5].ToString();
                lbl_mach_id_lt.Value = DT1.Rows[0][6].ToString(); 
                txtptnt_nm.Text = DT1.Rows[0][2].ToString();
                string Sit = DT1.Rows[0][4].ToString();
                if (Sit == "Right")
                {
                    rbte_site.SelectedIndex = 0;
                }
                else if (Sit == "Left")
                {
                    rbte_site.SelectedIndex = 1;
                }
                else if (Sit == "Both")
                {
                    rbte_site.SelectedIndex = 2;
                }
                else 
                {
                    rbte_site.SelectedIndex = 3;
                }
                txtcomment.Text = DT1.Rows[0][7].ToString();
                dr = null;
                cn.Close();
                btnsave.Text = "Edit";
                btnPrint.Enabled = true;
            }
            catch
            { }
            #endregion
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
                //string Mach_Desc = ddl_comp.SelectedItem.Text;
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
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
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
                int Mach_Desc = Convert.ToInt32(ddl_comp.SelectedValue);
                string Mach_Model = ddl_mach_model.SelectedItem.Text;
                ddl_mach_type.Items.Clear();
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
                ddl_mach_type.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_mach_type.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_type.Enabled = true;
                ddl_mach_type.Focus();
            }
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
        }
    }
    protected void ddl_mach_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type.SelectedIndex > 0)
        {
            #region Machine Final            
            //string Mach_Desc = ddl_comp.SelectedItem.Text;
            int Mach_Desc = Convert.ToInt32(ddl_comp.SelectedValue);
            string Mach_Model = ddl_mach_model.SelectedItem.Text;
            string Mach_Type = ddl_mach_type.SelectedItem.Text;
            cmd = new SqlCommand("sp_Mach_Id_Search", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
            cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
            cmd.Parameters.AddWithValue("@mach_Type", Mach_Type);
            cn.executeprocedure(cmd);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "tbl_machine_master");
            //if (ds.Tables["tbl_machine_master"].Rows.Count > 0)
            //{
                txt_mach.Visible = true;
                txt_mach.Text = (System.Convert.ToString(ddl_mach_type.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_comp.SelectedItem.Text));
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                lbl_mach_id_rt.Value = machid;               
            //}
            #endregion
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {    
        if( btnsave.Text=="Edit")
        {
        #region Edit
        try
        {
           int hmsale_id = Convert.ToInt32(lbtrial_id.Value);
            int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
            string Trial = ddl_complete.Text.ToString();
            string ear_site = rbte_site.SelectedItem.Text.ToString();
            int hm_mach_id_rt;
             int hm_mach_id_lt;
             int def = 0;
                if (lbl_mach_id_rt.Value  == "")
                { hm_mach_id_rt = def; }
                else
                { hm_mach_id_rt = Convert.ToInt32(lbl_mach_id_rt.Value); }
                if (lbl_mach_id_lt.Value  == "")
                { hm_mach_id_lt = def; }
                else { hm_mach_id_lt = Convert.ToInt32(lbl_mach_id_lt.Value); }
            string comm = txtcomment.Text.ToString();
            string hm_sale_ear_site = rbte_site.SelectedItem.Text.ToString();
            string hm_nm_rt = txt_mach.Text.ToString();
            string hm_nm_lt = txt_mach1.Text.ToString();
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            string Flag = "E";
            cn.Open();
            cmd = new SqlCommand("tbl_hm_Trial_Only_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@phm_sale_id", hmsale_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@phm_Trial", Trial);
            cmd.Parameters.AddWithValue("@ph_ear_site", ear_site);
            cmd.Parameters.AddWithValue("@pMach_rt_id", hm_mach_id_rt);
            cmd.Parameters.AddWithValue("@pMach_lt_id", hm_mach_id_lt);                          
            cmd.Parameters.AddWithValue("@ph_m_sale_comment", comm);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            cn.executeprocedure(cmd);
            cn.Close();
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
            Response.Redirect("h_trial_Grid.aspx");
            //btnprt_bil.Enabled = true;
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
        }
        #endregion
        }
        else
        {
        #region Save
        try
        {
            int def = 0;
            string ptnt_nm1 = txtptnt_nm.Text;
            string[] WordArray = ptnt_nm1.Split('-');
            string Name = WordArray[0].ToString();
            lblptnt_id.Value = WordArray[1];
            int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
            int hmsale_id = 0;
            string Trial = ddl_complete.Text.ToString();
            string ear_site = rbte_site.SelectedItem.Text.ToString();
            int hm_mach_id_rt;
             int hm_mach_id_lt;
                if (lbl_mach_id_rt.Value  == "")
                { hm_mach_id_rt = def; }
                else
                { hm_mach_id_rt = Convert.ToInt32(lbl_mach_id_rt.Value); }
                if (lbl_mach_id_lt.Value  == "")
                { hm_mach_id_lt = def; }
                else { hm_mach_id_lt = Convert.ToInt32(lbl_mach_id_lt.Value); }
            string comm = txtcomment.Text.ToString();
            string hm_sale_ear_site = rbte_site.SelectedItem.Text.ToString();
            string hm_nm_rt = txt_mach.Text.ToString();
            string hm_nm_lt = txt_mach1.Text.ToString();
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_hm_Trial_Only_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@phm_sale_id", hmsale_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@phm_Trial", Trial);
            cmd.Parameters.AddWithValue("@ph_ear_site", ear_site);
            cmd.Parameters.AddWithValue("@pMach_rt_id", hm_mach_id_rt);
            cmd.Parameters.AddWithValue("@pMach_lt_id", hm_mach_id_lt);                          
            cmd.Parameters.AddWithValue("@ph_m_sale_comment", comm);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            int a=cn.executeprocedure(cmd);
            lbtrial_id.Value = a.ToString();
            cn.Close();
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                print();
            }
            else
            {
                Response.Redirect("~/h_trial_Grid.aspx");
            }
            btnPrint.Enabled = true;
            btnsave.Enabled = false;
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
            //Response.Redirect("h_trial_Grid.aspx");            
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
        }
        #endregion
        }
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
//        int def = 0;
        #region Search
        try
        {
           // btnprt_bil.Visible = true;
            string Ptid = lblptnt_id.Value.ToUpper();
            cmd = new SqlCommand("sp_Trial_search", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_h_m_ptid", Ptid);
            cn.Open();
            cn.executeprocedure(cmd);
            cn.Close();
            DataTable DT1 = new DataTable();
            cn.Open();
            dr = cmd.ExecuteReader();
            DT1.Load(dr);
            rbte_site.Visible = true;
            string Site = DT1.Rows[0][2].ToString();
            if (Site == "Right")
            {
                rbte_site.SelectedIndex = 0;
            }
            else if (Site == "Left")
            {
                rbte_site.SelectedIndex = 1;
            }
            else
            {
                rbte_site.SelectedIndex = 2;
            }
            string No = DT1.Rows[0][3].ToString();
            lbl_mach_id_rt.Value  = DT1.Rows[0][1].ToString();
            string A, B, C;
            A = DT1.Rows[0][13].ToString();
            B = DT1.Rows[0][14].ToString();
            C = DT1.Rows[0][15].ToString();
            txt_mach.Text = "A" + "B" + "C";
            lbtrial_id.Value = "";
            lbtrial_id.Value = DT1.Rows[0][16].ToString();
            
            dr = null;
            cn.Close();
            //btnEDIT.Visible = true;
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Patient Not Match')</script>");
        }
        #endregion
        //btnEDIT.Visible = true;
    }
    protected void rbte_site_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region machine Company
        btnsave.Enabled = true;
        try
        {
            cn.Open();
            cmd = connection.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "sp_Mach_Desc_ddl";
            DataTable DT_comp = new DataTable();

            dr = cmd.ExecuteReader();
            DT_comp.Load(dr);

            if (rbte_site.SelectedIndex == 0)
            {
                ddl_comp.Enabled = true;
                Label17.Enabled = false;
                ddl_comp1.Enabled = false;
                Label16.Enabled = false;
                Label17.Enabled = false;

                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp.SelectedIndex = 0;
            }
            else if (rbte_site.SelectedIndex == 1)
            {
                Label17.Enabled = true;
                ddl_comp1.Enabled = true;
                Label16.Enabled = true;
                ddl_comp.Enabled = false;


                ddl_comp1.DataSource = DT_comp;
                ddl_comp1.DataValueField = "Comp_id";
                ddl_comp1.DataTextField = "Comp_nm";
                ddl_comp1.DataBind();
                ddl_comp1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp1.SelectedIndex = 0;
            }

            else if (rbte_site.SelectedIndex == 2)
            {
                Label17.Enabled = true;
                ddl_comp1.Enabled = true;
                Label16.Enabled = true;
                ddl_comp.Enabled = true;

                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));

                ddl_comp1.Enabled = true;

                ddl_comp1.DataSource = DT_comp;
                ddl_comp1.DataValueField = "Comp_id";
                ddl_comp1.DataTextField = "Comp_nm";
                ddl_comp1.DataBind();
                ddl_comp1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp1.SelectedIndex = 0;
            }
            else
            {
                ddl_comp.Enabled = true;
                Label17.Enabled = false;
                ddl_comp1.Enabled = false;
                Label16.Enabled = false;

                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp.SelectedIndex = 0;
            }

            dr = null;
            cn.Close(); ;
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
        #endregion
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/h_trial_Grid.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        print();
    }
    protected void ddl_complete_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_complete.SelectedIndex > 0)
        {
            rbte_site.Enabled  = true;
            Label5.Enabled  = true;           
        }
    }
    protected void ddl_comp1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_comp1.SelectedIndex > 0)
        {
            #region Machine Model
            try
            {
                cn.Open();
                ddl_model1.Items.Clear();
                int Mach_Desc = Convert.ToInt32(ddl_comp1.SelectedValue);
                cmd = new SqlCommand("sp_Mach_Model_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cn.executeprocedure(cmd);
                DataTable DT_model = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_model.Load(dr);

                ddl_model1.DataSource = DT_model;
                ddl_model1.DataValueField = "mach_id";
                ddl_model1.DataTextField = "mach_model";
                ddl_model1.DataBind();
                ddl_model1.Items.Insert(0, new ListItem("MODEL", "mach_model"));
                ddl_model1.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_model1.Enabled = true;
                ddl_model1.Focus();
            }
            catch { /*Response.Redirect("~/error.aspx");*/ }
            #endregion
        }
    }
    protected void ddl_model1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_model1.SelectedIndex > 0)
        {
            #region Machine Type
            try
            {
                cn.Open();
                ddl_type1.Items.Clear();
                int Mach_Desc = Convert.ToInt32(ddl_comp1.SelectedValue);
                string Mach_Model = ddl_model1.SelectedItem.Text;
                cmd = new SqlCommand("sp_Mach_Type_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
                cn.executeprocedure(cmd);
                DataTable DT_type = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_type.Load(dr);

                ddl_type1.DataSource = DT_type;
                ddl_type1.DataValueField = "mach_id";
                ddl_type1.DataTextField = "mach_type";
                ddl_type1.DataBind();
                ddl_type1.Items.Insert(0, new ListItem("Type", "ptnt_nm"));
                ddl_type1.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_type1.Enabled = true;
                ddl_type1.Focus();
            }
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
        }
    }
    protected void ddl_type1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_type1.SelectedIndex > 0)
        {
            #region Machine Final
            int Mach_Desc = Convert.ToInt32(ddl_comp1.SelectedValue);
            string Mach_Model = ddl_model1.SelectedItem.Text;
            string Mach_Type = ddl_type1.SelectedItem.Text;
            cmd = new SqlCommand("sp_Mach_Id_Search", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
            cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
            cmd.Parameters.AddWithValue("@mach_Type", Mach_Type);
            cn.executeprocedure(cmd);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "tbl_machine_master");
            if (ds.Tables["tbl_machine_master"].Rows.Count > 0)
            {
                txt_mach1.Enabled = true;
                txt_mach1.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp1.SelectedItem.Text + "," + ddl_model1.SelectedItem.Text + "," + ddl_type1.SelectedItem.Text));
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                lbl_mach_id_lt.Value = machid;
                lblQty1.Text = ds.Tables["tbl_machine_master"].Rows[0][2].ToString();
                int Qty1 = Convert.ToInt32(lblQty1.Text);
                if (Qty1 > 0)
                { }
                else
                {
                    Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
                }
            }
            #endregion
        }
    }
    public void print()
    {
        if (lbtrial_id.Value!="")
        {
        int billno = Convert.ToInt32(lbtrial_id.Value);
        Response.Redirect("~/home_trial_rpt.aspx?bill_no=" + billno);
        }        
    }
}
