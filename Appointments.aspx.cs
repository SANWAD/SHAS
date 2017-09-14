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

public partial class Appointment : System.Web.UI.Page
{
    #region Declaration
    string[] adj ={"---SELECT---","08:00 AM","08:30 AM","09:00 AM","09:30 AM","10:00 AM", "10:30 AM", "11:00 AM","11:30 AM","12:00 PM","12:30 PM","01:00 PM","01:30 PM","02:00 PM","02:30 PM","03:00 PM","03:30 PM","04:00 PM","04:30 PM","05:00 PM","05:30 PM","06:00 PM","06:30 PM","07:00 PM","07:30 PM","08:00 PM"};
    SqlCommand cmd, cmd1, cmd2, cmd3;
    SqlDataReader dr, dr1, dr2, dr3;
    connection cn;
    DataSet ds, ds1;
    double id;
    DateTime dt = System.DateTime.Now.Date;
    DateTime aptdt;
    int ptnt_id;
    string ptntfor, user_type;
    string[] apt1;
    
    string CanApt;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {           
            cn = new connection();
            AutoPtntNm.ContextKey = Session["Cntr_id"].ToString();
            #region Page Load Event
            if (!IsPostBack)
            {
                txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
                if (Convert.ToInt32(Session["ptnt_id"].ToString()) == 0)
                {
                    //ptnt_id = Convert.ToInt32(Session["ptnt_id"].ToString());
                    ptnt_id = 0;
                }
                else
                {
                    ptnt_id = Convert.ToInt32(Session["ptnt_id"].ToString());
                    if (ptnt_id > 0)
                    {
                        try
                        {
                            cn.Open();
                            cmd = new SqlCommand("tbl_ptn_mast_Select", connection.con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                            cn.Open();
                            cn.executeprocedure(cmd);
                            DataTable DT5 = new DataTable();
                            cn.Open();
                            dr = cmd.ExecuteReader();
                            DT5.Load(dr);
                            lblptnt_id.Value = DT5.Rows[0][0].ToString();
                            ddl_ptnt_nm.Text = DT5.Rows[0][3].ToString() + "-" + ptnt_id;
                            dr = null;
                            cn.Close();
                        }
                        catch
                        {
                            Response.Write("<script language='JavaScript'>alert('')</script>");
                        }
                    }
                }
                cn.Open();
                ddltype.Items.Clear();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_Ptnt_Type_ddl";
                DataTable DT1 = new DataTable();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                ddltype.DataSource = DT1;
                ddltype.DataValueField = "PtntypeId";
                ddltype.DataTextField = "Ptntype";                
                ddltype.DataBind();
                ddltype.Items.Insert(0, new ListItem("Select", "Ptntype"));
                dr = null;

                ddl_apt_time.Items.Clear();
                cmd1 = connection.con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                //cmd1.CommandText = "sp_Ptnt_Time_ddl";
                cmd1 = new SqlCommand("sp_Ptnt_Time_ddl", connection.con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@pCntr_id", Convert.ToInt32(Session["Cntr_id"].ToString()));
                cmd1.Parameters.AddWithValue("@pADate", System.DateTime.Now);
                cn.executeprocedure(cmd1);
                DataTable DT2 = new DataTable();
                cn.Open();
                dr1 = cmd1.ExecuteReader();
                DT2.Load(dr1);
                ddl_apt_time.DataSource = DT2;
                ddl_apt_time.DataValueField = "time_id";
                ddl_apt_time.DataTextField = "apt_time";
                ddl_apt_time.DataBind();
                ddl_apt_time.Items.Insert(0, new ListItem("Select", "apt_time"));
                dr1 = null;

                ddlapt_type.Items.Clear();                
                cmd2 = connection.con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "sp_Ptnt_Apt_ddl";
                DataTable DT3 = new DataTable();
                dr2 = cmd2.ExecuteReader();
                DT3.Load(dr2);
                ddlapt_type.DataSource = DT3;
                ddlapt_type.DataValueField = "AptTYpeId";
                ddlapt_type.DataTextField = "AptTYpe";
                ddlapt_type.DataBind();
                ddlapt_type.Items.Insert(0, new ListItem("Select", "AptTYpe"));
                dr2 = null;

                //ddlDoctor.Items.Clear();
                //cmd3 = connection.con.CreateCommand();
                //cmd3.CommandType = CommandType.Text;
                //cmd3.CommandText = "sp_User_DDLDoct";
                //DataTable DT4 = new DataTable();
                //dr3 = cmd3.ExecuteReader();
                //DT4.Load(dr3);
                //ddlDoctor.DataSource = DT4;
                //ddlDoctor.DataValueField = "UserTypeId";
                //ddlDoctor.DataTextField = "USerType";
                //ddlDoctor.DataBind();
                //ddlDoctor.Items.Insert(0, new ListItem("Select", "USerType"));
                //dr3 = null;
                cn.Close();
                Select();
            }
            #endregion
            ddltype.Focus();
        }
    }
    public void Clear()
    {
        lblptnt_id.Value = "";       
        ddltype.SelectedIndex = 0;
        txtdate.Text = "";        
        lblptnttype.Value = "";       
    }
    public void Select()
    {        
        string Apt_Id = Session["Appo_Id"].ToString();
        if (Apt_Id != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Appo_Id"].ToString());
                double CtrID = System.Convert.ToInt32(id1);

                cn.Open();
                cmd = new SqlCommand("tbl_apointment_Cancel_trn_g", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pApt_id", CtrID);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblaptid.Value = DT1.Rows[0][0].ToString();
                txtdate.Text = DT1.Rows[0][1].ToString();
                ddltype.SelectedIndex = Convert.ToInt32(DT1.Rows[0][13].ToString());
                ddlapt_type.SelectedValue = DT1.Rows[0][15].ToString();
                ddl_ptnt_nm.Text = DT1.Rows[0][6].ToString() + "-" + DT1.Rows[0][12].ToString();
                lblptnt_id.Value = DT1.Rows[0][12].ToString();
                
                ddl_apt_time.SelectedIndex = Convert.ToInt32(DT1.Rows[0][14].ToString());
                dr = null;
                cn.Close();
                chkcan.Enabled = true;
                Label2.Enabled = true;
                btn_save.Text = "Edit";
            }
            catch
            { }

            #endregion
        }
        
    }
    #region Validation
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //if (txtptnt_nm.Text == "")

        //    args.IsValid = false;
        //else
        //    args.IsValid = true;
    }

    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtdate.Text == "")

            args.IsValid = false;
        else
            args.IsValid = true;
    }

    protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ddltype.SelectedIndex == 0) { args.IsValid = false; }
        else { args.IsValid = true; }

    }
    protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ddlapt_type.SelectedIndex == 0) { args.IsValid = false; }
        else { args.IsValid = true; }
    }
    #endregion
    protected void ddlapt_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        //#region user Selection
        //if (lblptnt_id.Text == "")
        //{

        //    string qry = "select * from tbl_user_master" +
        //                           @" where user_nm='" + Session["name"] + "'";
        //    ds1 = cn.GetData(qry, "tbl_user_master");
        //    try
        //    {
        //        user_type = ds1.Tables["tbl_user_master"].Rows[0][6].ToString();
        //    }
        //    catch { Response.Redirect("~/Login/login.aspx"); }
        //    if (ds1.Tables["tbl_user_master"].Rows.Count > 0)
        //    {
        //        if ((user_type) == "Reception")
        //        {
        //            Response.Write("<script>alert('Not Valid User')</script>");
        //        }
        //        else if (((user_type) == "Admin")||((user_type) == "Therapist")||((user_type) == "Audiologist"))
        //        {
        //            if (ddlapt_type.SelectedIndex == 3)
        //            {
        //                Response.Redirect("~/Reception Forms/Camps.aspx");
        //            }
        //            if (ddlapt_type.SelectedIndex == 2)
        //            {
        //                Response.Redirect("~/Reception Forms/Functions_meetings.aspx");
        //            }
        //        }
        //    }
        //    else {Response.Redirect("~/error.aspx"); }
        //}
        //else
        //{
        //    ddlapt_type.SelectedIndex = 1; 
        //}
        //#endregion
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if(btn_save.Text=="Edit")
        {
            #region Edit
            if (ddltype.SelectedItem.Text == "Select")
            {
                Response.Write("<script>alert('Please Select Patient Type')</script>");
            }
            //else if (ddlapt_type.SelectedItem.Text == "Select")
            //{
            //    Response.Write("<script>alert('Please Select Appointment Type')</script>");
            //}
            else if (ddl_apt_time.SelectedItem.Text == "Select")
            {
                Response.Write("<script>alert('Please Select Appointment Time')</script>");
            }
            else
            {
                string ptnt_nm = ddl_ptnt_nm.Text;
                string[] WordArray = ptnt_nm.Split('-');
                string Name = WordArray[0].ToString();
                lblptnt_id.Value = WordArray[1];
                //DateTime dt = Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString());
                dt = System.Convert.ToDateTime(txtdate.Text);
                //dt = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);
                int papt_id = Convert.ToInt32(lblaptid.Value);
                int ptntid = System.Convert.ToInt32(lblptnt_id.Value);
                int Ptntype = Convert.ToInt32(ddltype.SelectedValue);
                DateTime aptdt = System.Convert.ToDateTime(txtdate.Text);
                if (aptdt.DayOfWeek.ToString() == "Sunday")
                { aptdt.AddDays(1).ToShortDateString(); }
                else { aptdt.ToShortDateString(); }
                int apttime = Convert.ToInt32(ddl_apt_time.SelectedValue);
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_Id = Convert.ToInt32(Session["Cntr_id"].ToString());                
                    if(chkcan.Checked==true)
                    {
                        CanApt="True";
                    }
                    else
                    {
                        CanApt = "False";
                    }
                int Doc_ID = 1;
                int Rpt_View = 0;
                int For = Convert.ToInt32(ddlapt_type.SelectedValue);
                string Flag = "E";
                apt_sp(Flag, ptntid, Ptntype, aptdt, apttime, For, cr_by, papt_id, Cntr_Id, Doc_ID, Rpt_View, CanApt);
                btn_save.Enabled = false;
                btnCan.Text = "Exit";
            }
            #endregion
        }
        else
        {
            #region Save
            if (ddltype.SelectedItem.Text == "Select")
            {
                Response.Write("<script>alert('Please Select Patient Type')</script>");
            }
            else if (ddlapt_type.SelectedItem.Text == "Select")
            {
                Response.Write("<script>alert('Please Select Appointment Type')</script>");
            }
            else if (ddl_apt_time.SelectedItem.Text == "Select")
            {
                Response.Write("<script>alert('Please Select Appointment Time')</script>");
            }
            else
            {
                string Name = "";
                string ptnt_nm = ddl_ptnt_nm.Text;               
                string[] WordArray = ptnt_nm.Split('-');
                Name = WordArray[0].ToString();
                lblptnt_id.Value = WordArray[1];
                dt = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);
                int papt_id = 0;
                int ptntid = System.Convert.ToInt32(lblptnt_id.Value);
                int Ptntype = Convert.ToInt32(ddltype.SelectedValue);
                DateTime aptdt = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);
                if (aptdt.DayOfWeek.ToString() == "Sunday")
                { aptdt.AddDays(1).ToShortDateString(); }
                else { aptdt.ToShortDateString(); }
                int apttime = Convert.ToInt32(ddl_apt_time.SelectedValue);
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_Id = Convert.ToInt32(Session["Cntr_id"].ToString());
                if (chkcan.Checked == true)
                {
                    CanApt = "True";
                }
                else
                {
                    CanApt = "False";
                }
                int Doc_ID = 1;
                int Rpt_View = 0;
                int For = Convert.ToInt32(ddlapt_type.SelectedValue);
                string Flag = "I";
                apt_sp(Flag, ptntid, Ptntype, aptdt, apttime, For, cr_by, papt_id, Cntr_Id, Doc_ID, Rpt_View,CanApt);
                btn_save.Enabled = false;
                btnCan.Text = "Exit";
            }
            #endregion
        }        
    }
    public void apt_sp(string Flag, int id, int ptntfor, DateTime aptdt, int apttime, int For, int cr_by, int papt_id, int Cntr_Id, int Doc_ID, int Rpt_View, string  CanApt)
    {
        #region Function Save
        cmd = new SqlCommand("tbl_apointment_trn_c", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@pFlag", Flag);
        cmd.Parameters.AddWithValue("@pptnt_id", id);
        cmd.Parameters.AddWithValue("@papt_id", papt_id);
        cmd.Parameters.AddWithValue("@pPtntypeId", ptntfor);
        cmd.Parameters.AddWithValue("@papt_date", aptdt);
        cmd.Parameters.AddWithValue("@pTIME_ID", apttime);
        cmd.Parameters.AddWithValue("@pAptTYpeId", For);
        cmd.Parameters.AddWithValue("@pCntr_Id", Cntr_Id);
        cmd.Parameters.AddWithValue("@pDoc_ID", Doc_ID);
        cmd.Parameters.AddWithValue("@pRpt_View", Rpt_View);
        cmd.Parameters.AddWithValue("@pISAptCancel", CanApt);
        cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
        cn.Open();
        cn.executeprocedure(cmd);    
        //Response.Write("<script language='JavaScript'>alert('Appointment Date & Time Is " + aptdt + " , " + apttime + " ')</script>");
        cn.Close();
        btn_save.Enabled = false;
        #endregion
    }   
    protected void ddl_apt_time_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    public ArrayList ConvertDT(DataTable data)
    {
        ArrayList converted = new ArrayList(data.Rows.Count);
        foreach (DataRow row in data.Rows)
        {
            converted.Add(row).ToString();
            converted.ToArray().ToString();
        }
        return converted;
    }   
    protected void btnCan_Click(object sender, EventArgs e)
    {       
        Response.Redirect("~/Appointments_Grid.aspx");
    }
    protected void btnBill_Click(object sender, EventArgs e)
    {
        string ptnt_nm = ddl_ptnt_nm.Text;
        string[] WordArray = ptnt_nm.Split('-');
        string Name = WordArray[0].ToString();
        lblptnt_id.Value = WordArray[1];
        Session["ptnt_id"] = lblptnt_id.Value;
        Session["Bill_Id"] = "0";
        int Bill_Id = 0;
        Response.Redirect("bill.aspx?Bill_Id=" + Bill_Id);
    }   
}
