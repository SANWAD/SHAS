using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class HrAidRepair : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    SqlDataAdapter da;
    DataSet ds;
    double id;
    int a;
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
                btnsave.Enabled = true;
                txtptnt_nm.Focus();
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
                btnPrint.Enabled = false;
                Select();
            }
        }
    }
    public void Select()
    {
        if (Request.QueryString["Repair_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                int PTA = 0, Bera = 0, Imp = 0, TDT = 0, SisiT = 0, FFA = 0, SE = 0, StD = 0, StM = 0, HAP = 0, Coun = 0;
                string acc1 = "";
                string id1;
                id1 = (Request.QueryString["Repair_Id"].ToString());
                double hr_job_id = System.Convert.ToInt32(id1);                
                cn.Open();
                cmd = new SqlCommand("tbl_hm_rep_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@phr_job_id", hr_job_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);               
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbljob_id.Value  = DT1.Rows[0][0].ToString();
                lblptnt_id.Value = DT1.Rows[0][15].ToString();
                lblmach_id.Value = DT1.Rows[0][16].ToString();
                txtptnt_nm.Text = DT1.Rows[0][1].ToString();
                txtvisu_rpt.Text = DT1.Rows[0][4].ToString();

                string Sit = DT1.Rows[0][6].ToString();
                if (Sit == "Rigth")
                {
                    rbte_site.SelectedIndex = 0;
                }
                else if (Sit == "Left")
                {
                    rbte_site.SelectedIndex = 1;
                }
                else
                {
                    rbte_site.SelectedIndex = 2;
                }
                string Rep_To = DT1.Rows[0][3].ToString();
                if (Rep_To == "In House")
                {
                    rbtrep_to.SelectedIndex = 0;
                }
                else
                {
                    rbtrep_to.SelectedIndex = 1;
                }
                txtexpchg.Text = DT1.Rows[0][7].ToString();
                txtadv_paid.Text = DT1.Rows[0][8].ToString();
                txtdate.Text = DT1.Rows[0][9].ToString();
                txtaccess.Text = DT1.Rows[0][10].ToString();
                string Rep_ret = DT1.Rows[0][11].ToString();
                if (Rep_ret == "Y")
                {
                    chkRap_ret.Checked = true;
                }
                else
                {
                    chkRap_ret.Checked = false;
                }
                string Rep_ret_rec = DT1.Rows[0][12].ToString();
                if (Rep_ret_rec == "Y")
                {
                    chkPtnt_Rcv.Checked = true;
                }
                else
                {
                    chkPtnt_Rcv.Checked = false;
                }
                dr = null;
                cn.Close();
                //Response.Write("<script language='JavaScript'>alert('')</script>");
                 btnsave.Text = "Edit";
                 btnPrint.Enabled = true;
                // }
            }
            catch
            { }
            #endregion
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if(btnsave.Text=="Edit")
        {
            #region Edit
            try
            {
                int PTA = 0, Bera = 0, Imp = 0, TDT = 0, SisiT = 0, FFA = 0, SE = 0, StD = 0, StM = 0, HAP = 0, Coun = 0;
                string acc1 = txtaccess.Text;
                int ptnt_id = Convert.ToInt32(lblptnt_id.Value ) ;
                int hr_job_id = Convert.ToInt32(lbljob_id.Value );
                string Ptnt_nm = txtptnt_nm.Text.ToString();
                string rep_to = rbtrep_to.SelectedItem.Text.ToString();
                string visual_rpt = txtvisu_rpt.Text;
                int mach_id = Convert.ToInt32(lblmach_id.Value);
                string ear_site = rbte_site.SelectedItem.Text.ToString();
                double exp_chg = Convert.ToDouble(txtexpchg.Text);
                double amt_paid = Convert.ToDouble(txtadv_paid.Text);
                DateTime exp_dt = Convert.ToDateTime(txtdate.Text);
                string acc = txtaccess.Text;
                string Ret_Com;
                if (chkRap_ret.Checked == true)
                {
                    Ret_Com = "Y";
                }
                else
                {
                    Ret_Com = "N";
                }
                string Ptnt_Rcv;
                if (chkPtnt_Rcv.Checked == true)
                {
                    Ptnt_Rcv = "Y";
                }
                else
                {
                    Ptnt_Rcv = "N";
                }
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                int bill_no = 0;
                string InvcNo = "ABC";
                cn.Open();
                cmd = new SqlCommand("tbl_hm_rep_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@phr_job_id", hr_job_id);
                cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                //cmd.Parameters.AddWithValue("@P_Ptnt_nm", Ptnt_nm);
                cmd.Parameters.AddWithValue("@phr_rep_to", rep_to);
                cmd.Parameters.AddWithValue("@phr_visual_rpt", visual_rpt);
                cmd.Parameters.AddWithValue("@pMachine", mach_id);
                cmd.Parameters.AddWithValue("@phr_ear_site", ear_site);
                cmd.Parameters.AddWithValue("@phr_exp_chg", exp_chg);
                cmd.Parameters.AddWithValue("@phr_amt_paid", amt_paid);
                cmd.Parameters.AddWithValue("@phr_exp_date", exp_dt);
                cmd.Parameters.AddWithValue("@phr_access", acc);
                cmd.Parameters.AddWithValue("@pMach_Rtn_Com", Ret_Com);
                cmd.Parameters.AddWithValue("@pMach_Rcv_ptnt", Ptnt_Rcv);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                //cmd = new SqlCommand("tbl_test_bill_c", connection.con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@pFlag", Flag);
                //cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                //cmd.Parameters.AddWithValue("@ptest_bill_no", bill_no);
                //cmd.Parameters.AddWithValue("@pInvcNo", InvcNo);
                //cmd.Parameters.AddWithValue("@pptnt_nm", Ptnt_nm);
                //cmd.Parameters.AddWithValue("@pparticulars", acc1);
                //cmd.Parameters.AddWithValue("@pPTA", PTA);
                //cmd.Parameters.AddWithValue("@pBera", Bera);
                //cmd.Parameters.AddWithValue("@pImp", Imp);
                //cmd.Parameters.AddWithValue("@pTDT", TDT);
                //cmd.Parameters.AddWithValue("@pSisiT", SisiT);
                //cmd.Parameters.AddWithValue("@pFFA", FFA);
                //cmd.Parameters.AddWithValue("@pSE", SE);
                //cmd.Parameters.AddWithValue("@pStD", StD);
                //cmd.Parameters.AddWithValue("@pStM", StM);
                //cmd.Parameters.AddWithValue("@pHAP", HAP);
                //cmd.Parameters.AddWithValue("@pCoun", Coun);
                //cmd.Parameters.AddWithValue("@pamt", amt_paid);
                //cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                //cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                //cn.executeprocedure(cmd);
                //cn.Close();
                Response.Write("<script language='JavaScript'>alert('Record is Update')</script>");
                Response.Redirect("HrAidRepair_Grid.aspx");
                btnsave.Enabled = false;
                //btn_print.Enabled = true;
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
            int PTA = 0, Bera = 0, Imp = 0, TDT = 0, SisiT = 0, FFA = 0, SE = 0, StD = 0, StM = 0, HAP = 0, Coun = 0;
            string acc1 = RemoveAllWhitespace(System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_mach_type.SelectedItem.Text));            
            //string acc1 = "MICROPHONE";
            string ptnt_nm1 = txtptnt_nm.Text;
            string[] WordArray = ptnt_nm1.Split('-');
            string Name = WordArray[0].ToString();
            lblptnt_id.Value = WordArray[1];
            int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
            int hr_job_id = 0;
            string Ptnt_nm = txtptnt_nm.Text.ToString();
            string rep_to = rbtrep_to.SelectedItem.Text.ToString();
            string visual_rpt = txtvisu_rpt.Text;
            int mach_id = Convert.ToInt32(lblmach_id.Value);
            string ear_site = rbte_site.SelectedItem.Text.ToString();
            double exp_chg = Convert.ToDouble(txtexpchg.Text);
            double amt_paid = Convert.ToDouble(txtadv_paid.Text);
            DateTime exp_dt = Convert.ToDateTime(txtdate.Text);
            string acc = txtaccess.Text;
            string Ret_Com;
            if (chkRap_ret.Checked == true)
            {
                Ret_Com = "Y";
            }
            else
            {
                Ret_Com = "N";
            }
            string Ptnt_Rcv;
            if (chkPtnt_Rcv.Checked == true)
            {
                Ptnt_Rcv = "Y";
            }
            else
            {
                Ptnt_Rcv = "N";
            }
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            string Flag = "I";
            int bill_no = 0;
            string InvcNo = "ABC";
            cn.Open();
            cmd = new SqlCommand("tbl_hm_rep_trn_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@phr_job_id", hr_job_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            //cmd.Parameters.AddWithValue("@P_Ptnt_nm", Ptnt_nm);
            cmd.Parameters.AddWithValue("@phr_rep_to", rep_to);
            cmd.Parameters.AddWithValue("@phr_visual_rpt", visual_rpt);
            cmd.Parameters.AddWithValue("@pMachine", mach_id);
            cmd.Parameters.AddWithValue("@phr_ear_site", ear_site);
            cmd.Parameters.AddWithValue("@phr_exp_chg", exp_chg);
            cmd.Parameters.AddWithValue("@phr_amt_paid", amt_paid);
            cmd.Parameters.AddWithValue("@phr_exp_date", exp_dt);
            cmd.Parameters.AddWithValue("@phr_access", acc);
            cmd.Parameters.AddWithValue("@pMach_Rtn_Com", Ret_Com);
            cmd.Parameters.AddWithValue("@pMach_Rcv_ptnt", Ptnt_Rcv);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            a=cn.executeprocedure(cmd);
            
            lbljob_id.Value = a.ToString();
            btnsave.Enabled = false;
            btnPrint.Enabled = true;
            cn.Close();


            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record is Save Succesfuly')", true);
                int billno = Convert.ToInt32(lbljob_id.Value);
                Response.Redirect("~/hm_rep.aspx?job_id=" + billno);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
                Response.Redirect("HrAidRepair_Grid.aspx");                
            }
            
            //cmd = new SqlCommand("tbl_test_bill_c", connection.con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@pFlag", Flag);
            //cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            //cmd.Parameters.AddWithValue("@ptest_bill_no", bill_no);
            //cmd.Parameters.AddWithValue("@pInvcNo", InvcNo);
            //cmd.Parameters.AddWithValue("@pptnt_nm", Ptnt_nm);
            //cmd.Parameters.AddWithValue("@pparticulars", acc1);
            //cmd.Parameters.AddWithValue("@pPTA", PTA);
            //cmd.Parameters.AddWithValue("@pBera", Bera);
            //cmd.Parameters.AddWithValue("@pImp", Imp);
            //cmd.Parameters.AddWithValue("@pTDT", TDT);
            //cmd.Parameters.AddWithValue("@pSisiT", SisiT);
            //cmd.Parameters.AddWithValue("@pFFA", FFA);
            //cmd.Parameters.AddWithValue("@pSE", SE);
            //cmd.Parameters.AddWithValue("@pStD", StD);
            //cmd.Parameters.AddWithValue("@pStM", StM);
            //cmd.Parameters.AddWithValue("@pHAP", HAP);
            //cmd.Parameters.AddWithValue("@pCoun", Coun);
            //cmd.Parameters.AddWithValue("@pamt", amt_paid);
            //cmd.Parameters.AddWithValue("@pcreated_by", cr_by);            
            //cn.Close();
            
            //Response.Redirect("HrAidRepair_Grid.aspx");
            
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");            
        }
        catch
        {           
            Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
        }
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
                ddl_mach_model.Enabled  = true;
                ddl_mach_model.Focus();
            }
            catch 
            { 
                //Response.Redirect("~/error.aspx"); 
            }
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
            catch 
            { 
                //Response.Redirect("~/error.aspx");
            }
            #endregion
        }
    }
    protected void ddl_mach_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type.SelectedIndex > 0)
        {
            #region Machine Final
            txt_mach.Enabled = true;
            txt_mach.Text = (System.Convert.ToString(ddl_mach_type.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_comp.SelectedItem.Text));
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
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                lblmach_id.Value = machid;
            }
            rbte_site.Focus();
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
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/HrAidRepair_Grid.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        int billno = Convert.ToInt32(lbljob_id.Value);
        Response.Redirect("~/hm_rep.aspx?job_id=" + billno);
    }


   

}
