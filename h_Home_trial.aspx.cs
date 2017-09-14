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

public partial class h_Home_trial : System.Web.UI.Page
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
                Clear();
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
                ddl_mach_model.Enabled = false;
                ddl_mach_type.Enabled = false;
                txt_mach.Enabled = false;               
                Select();
            }
       }
    }
    public void Clear()
    {
        rbte_site.Focus();
        Label11.Enabled = false;
        txt_cash.Enabled = false;
        Label14.Enabled = false;
        txt_chq_no.Enabled = false;
        Label15.Enabled = false;
        txt_chq_det.Enabled = false;
        Label12.Enabled = true;
        txt_cash.Enabled = false;
        btnPrint.Enabled = true;
    }
    public void Select()
    {
        if (Request.QueryString["Hom_trial_id"].ToString() != "0")
        {
            #region Select
            try
            {               
                string id1;
                id1 = (Request.QueryString["Hom_trial_id"].ToString());
                double h_t_id = System.Convert.ToInt32(id1);               
                cn.Open();
                cmd = new SqlCommand("h_m_home_trial_Select_Rpt", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ph_t_id", h_t_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);

                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbtrial_id.Value = DT1.Rows[0][0].ToString();
                lblptnt_id.Value = DT1.Rows[0][3].ToString();
                lblmach_id.Value = DT1.Rows[0][4].ToString();
                txtptnt_nm.Text = DT1.Rows[0][1].ToString();   
                string Sit = DT1.Rows[0][5].ToString();
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

                string No_Mach = DT1.Rows[0][6].ToString();
                if (No_Mach == "Single")
                {
                    rbtn_no_mach.SelectedIndex = 0;
                }
                else 
                {
                    rbtn_no_mach.SelectedIndex = 1;
                }
                txt_hn_price.Text = DT1.Rows[0][7].ToString();
                txt_acc_given.Text = DT1.Rows[0][8].ToString();
                string Pay_Type = DT1.Rows[0][9].ToString();
                if (Pay_Type == "CASH")
                {
                    RadioButtonList1.SelectedIndex=0;
                }
                else if (Pay_Type == "CHEQUE")
                {
                    RadioButtonList1.SelectedIndex = 1;
                }
                else
                {
                    RadioButtonList1.SelectedIndex = 2;
                }
                txt_chq_no.Text = DT1.Rows[0][10].ToString();
                txt_chq_det.Text = DT1.Rows[0][11].ToString();
                txt_cash.Text = DT1.Rows[0][12].ToString();
                string Mach_Rtn=DT1.Rows[0][13].ToString();
                if (Mach_Rtn=="Y")
                {
                   chrtn.Checked=true;
                }
                else
                {
                    chrtn.Checked=false;
                }
                dr = null;
                cn.Close();
                btnsave.Text = "Edit";
                btnPrint.Enabled =true;
            }
            catch
            { }
            #endregion
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int def = 0;
        #region CASH/CHEQUE
        if (RadioButtonList1.SelectedIndex == 0)
        {
            Label11.Enabled  = true;
            txt_cash.Enabled = true;
            Label14.Enabled = false;
            txt_chq_no.Enabled = false;
            Label15.Enabled = false;
            txt_chq_det.Enabled = false;
            Label12.Enabled = true;   
            txt_chq_no.Text = def.ToString();
            txt_chq_det.Text = "Cash Payment";
        }
        else if (RadioButtonList1.SelectedIndex == 1)
        {
            Label11.Enabled = false;
            txt_cash.Enabled = false;
            Label14.Enabled = true;
            txt_chq_no.Enabled = true;
            Label15.Enabled = true;
            txt_chq_det.Enabled = true;
            Label12.Enabled = true;
            txt_chq_det.Text = "Cheque Detail";
        }
        else
        {
            Label11.Enabled = false;
            txt_cash.Enabled = false;
            Label14.Enabled = false;
            txt_chq_no.Enabled = false;
            Label15.Enabled = false;
            txt_chq_det.Enabled = false;
            Label12.Enabled = true;
            txt_cash.Enabled = false;
            txt_chq_no.Text = def.ToString();
            txt_chq_det.Text = "Cash Payment";
        }
        #endregion
    }
    protected void btn_nm_Click(object sender, EventArgs e)
    {
        #region Search
        try
        {
            //string nm = txtptnt_nm.Text.ToUpper();
            //ddl_ptnt_nm.Items.Clear();

            //cmd = new SqlCommand("sp_ptnt_search_by_name", connection.con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@p_ptnt_nm", nm);
            //cn.Open();
            //cn.executeprocedure(cmd);

            //DataTable DT1 = new DataTable();
            //cn.Open();
            //dr = cmd.ExecuteReader();
            //DT1.Load(dr);
            //DT1.Columns.Add("ptntnm", typeof(string), "ptnt_id+','+ptnt_nm");
            //ddl_ptnt_nm.DataSource = DT1;
            //ddl_ptnt_nm.DataValueField = "ptnt_id";
            //ddl_ptnt_nm.DataTextField = "ptntnm";
            //ddl_ptnt_nm.DataBind();
            //ddl_ptnt_nm.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
            //ddl_ptnt_nm.SelectedIndex = 0;
            //dr = null;
            //cn.Close();

        }

        catch
        {
            Response.Redirect("~/error.aspx");
        }
        #endregion
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
                //string Mach_Desc = ddl_comp.SelectedItem.Text;
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
            if (ds.Tables["tbl_machine_master"].Rows.Count > 0)
            {

                txt_mach.Visible = true;
                txt_mach.Text = (System.Convert.ToString(ddl_mach_type.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_comp.SelectedItem.Text));
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                lblmach_id.Value = machid;
                txt_hn_price.Text = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][1]).ToString();
            }
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
            DateTime dt = System.DateTime.Now.Date;
            int h_t_id = Convert.ToInt32(lbtrial_id.Value);
            int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
            int mach_id = Convert.ToInt32(lblmach_id.Value);
            string ear_site = rbte_site.SelectedItem.Text.ToString();
            string no_mach = "Single";
            string ac_given = txt_acc_given.Text.ToString();
            int price = Convert.ToInt32(txt_hn_price.Text);
            string type_pay = RadioButtonList1.SelectedItem.Text.ToString();
            int chq_no = Convert.ToInt32(txt_chq_no.Text);
            string chq_det = txt_chq_det.Text.ToString();
            int cash = Convert.ToInt32(txt_cash.Text);
            string H_Ret;
            if (chrtn.Checked == true)
            {
                H_Ret = "Y";
            }
            else
            {
                H_Ret = "N";
            }
            dt = System.Convert.ToDateTime(txtDate.Text);
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            string Flag = "E";
            cn.Open();
            cmd = new SqlCommand("h_m_home_trial_trn_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ph_t_id", h_t_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@pmach_id", mach_id);
            cmd.Parameters.AddWithValue("@ph_ear_site", ear_site);
            cmd.Parameters.AddWithValue("@ph_no_mach", no_mach);
            cmd.Parameters.AddWithValue("@ph_h_m_price", price);
            cmd.Parameters.AddWithValue("@pacc_given", ac_given);
            cmd.Parameters.AddWithValue("@ptype_of_pay", type_pay);
            cmd.Parameters.AddWithValue("@pchq_no", chq_no);
            cmd.Parameters.AddWithValue("@pchk_det", chq_det);
            cmd.Parameters.AddWithValue("@pcash", cash);
            cmd.Parameters.AddWithValue("@pRet_rn", H_Ret);
            cmd.Parameters.AddWithValue("@pRtn_dt", dt);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            cn.executeprocedure(cmd);
            cn.Close();
            Response.Write("<script language='JavaScript'>alert('Record is Update Succesfuly')</script>");
            Response.Redirect("h_trial_Grid.aspx");
           // btnsave.Enabled = false;
            //btnprt_bil.Enabled = true;
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is Not Update')</script>");
        }
        #endregion
        }
        else
        {
         #region Save
            try
            {
                DateTime dt = System.DateTime.Now.Date;
                int h_t_id = 0;
                string ptnt_nm1 = txtptnt_nm.Text;
                string[] WordArray = ptnt_nm1.Split('-');
                string Name = WordArray[0].ToString();
                lblptnt_id.Value = WordArray[1];
                int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
                int mach_id = Convert.ToInt32(lblmach_id.Value);
                string ear_site = rbte_site.SelectedItem.Text.ToString();
                string no_mach = "Single";
                string ac_given = txt_acc_given.Text.ToString();
                int price = Convert.ToInt32(txt_hn_price.Text);
                string type_pay = RadioButtonList1.SelectedItem.Text.ToString();
                int chq_no = Convert.ToInt32(txt_chq_no.Text);
                string chq_det = txt_chq_det.Text.ToString();
                int cash = Convert.ToInt32(txt_cash.Text);
                string H_Ret;
                if (chrtn.Checked == true)
                {
                    H_Ret = "Y";
                }
                else
                {
                    H_Ret = "N";
                }
                dt = System.Convert.ToDateTime(txtDate.Text);
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("h_m_home_trial_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@ph_t_id", h_t_id);
                cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                cmd.Parameters.AddWithValue("@pmach_id", mach_id);
                cmd.Parameters.AddWithValue("@ph_ear_site", ear_site);
                cmd.Parameters.AddWithValue("@ph_no_mach", no_mach);
                cmd.Parameters.AddWithValue("@ph_h_m_price", price);
                cmd.Parameters.AddWithValue("@pacc_given", ac_given);
                cmd.Parameters.AddWithValue("@ptype_of_pay", type_pay);
                cmd.Parameters.AddWithValue("@pchq_no", chq_no);
                cmd.Parameters.AddWithValue("@pchk_det", chq_det);
                cmd.Parameters.AddWithValue("@pcash", cash);
                cmd.Parameters.AddWithValue("@pRet_rn", H_Ret);
                cmd.Parameters.AddWithValue("@pRtn_dt", dt);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                int a=cn.executeprocedure(cmd);
                cn.Close();
                lbtrial_id.Value = a.ToString();
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    print();
                }
                else
                {
                    Response.Redirect("~/h_Home_trial_Grid.aspx");
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
        int def = 0;
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
            if (No == "Single")
            {
                rbtn_no_mach.SelectedIndex = 0;
            }
            else
            {
                rbtn_no_mach.SelectedIndex = 1;
            }
            lblmach_id.Value  = DT1.Rows[0][1].ToString();
            string A, B, C;
            A = DT1.Rows[0][13].ToString();
            B = DT1.Rows[0][14].ToString();
            C = DT1.Rows[0][15].ToString();
            txt_mach.Text = "A" + "B" + "C";
            lbtrial_id.Value = "";
            lbtrial_id.Value = DT1.Rows[0][16].ToString();
            txt_hn_price.Text = DT1.Rows[0][4].ToString();
            txt_acc_given.Text = DT1.Rows[0][5].ToString();
            string Chk_dtl = DT1.Rows[0][6].ToString();
            if (Chk_dtl == "CASH")
            {
                RadioButtonList1.SelectedIndex = 0;
                Label14.Visible = false;
                txt_chq_no.Visible = false;
                Label15.Visible = false;
                txt_chq_det.Visible = false;
                Label12.Visible = true;
                txt_cash.Visible = true;
                txt_chq_no.Text = def.ToString();
                txt_chq_det.Text = "Cash Payment";

            }
            else if (Chk_dtl == "CHEQUE")
            {
                RadioButtonList1.SelectedIndex = 1;
                Label14.Visible = true;
                txt_chq_no.Visible = true;
                Label15.Visible = true;
                txt_chq_det.Visible = true;
                Label12.Visible = false;
                txt_cash.Visible = false;

            }
            else
            {
                RadioButtonList1.SelectedIndex = 2;
                Label14.Visible = false;
                txt_chq_no.Visible = false;
                Label15.Visible = false;
                txt_chq_det.Visible = false;
                Label12.Visible = false;
                txt_cash.Visible = false;
                txt_chq_no.Text = def.ToString();

            }
            txt_chq_det.Text = DT1.Rows[0][8].ToString();
            txt_chq_no.Text = DT1.Rows[0][7].ToString();
            txt_cash.Text = DT1.Rows[0][9].ToString();
            txtDate.Text = DT1.Rows[0][11].ToString();
            string Rtn = DT1.Rows[0][10].ToString();
            if (Rtn == "Y")
            {
                chrtn.Checked = true;
            }
            else
            {
                chrtn.Checked = false;
            }
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
        try
        {
            cn.Open();
            cmd = connection.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "sp_Mach_Desc_ddl";
            DataTable DT_comp = new DataTable();

            dr = cmd.ExecuteReader();
            DT_comp.Load(dr);

            ddl_comp.DataSource = DT_comp;
            ddl_comp.DataValueField = "Comp_id";
            ddl_comp.DataTextField = "comp_nm";
            ddl_comp.DataBind();
            ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
            ddl_comp.SelectedIndex = 0;
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
        #endregion
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/h_Home_trial_Grid.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        print();
    }
    public void print()
    {
        if (lbtrial_id.Value != "")
        {
            int billno = Convert.ToInt32(lbtrial_id.Value);
            Response.Redirect("~/home_trial_rpt.aspx?bill_no=" + billno);
        }
    }
}
