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

public partial class Enquiry : System.Web.UI.Page
{
    #region Declaration
    string[] adj ={"---SELECT---","08:00 AM","08:30 AM","09:00 AM","09:30 AM","10:00 AM", "10:30 AM", "11:00 AM","11:30 AM","12:00 PM","12:30 PM","01:00 PM","01:30 PM","02:00 PM","02:30 PM","03:00 PM",
                   "03:30 PM","04:00 PM","04:30 PM","05:00 PM","05:30 PM","06:00 PM","06:30 PM","07:00 PM","07:30 PM","08:00 PM"};
    SqlDataReader dr,dr2;
    SqlCommand cmd,cmd2;
    connection cn;
    // DataSet ds, ds1;
    double id;
    DateTime Enq_Dt, dt = System.DateTime.Now.Date;
    //DateTime aptdt;
    //string ptntfor, user_type;
    //string[] apt1;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new connection();
        RangeValidator1.MaximumValue = System.DateTime.Now.AddDays(0).ToShortDateString();
        #region Page Load Event
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
                cn.Open();
                ddlpatien_for.Items.Clear();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_Ptnt_Type_ddl";
                DataTable DT1 = new DataTable();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                ddlpatien_for.DataSource = DT1;
                ddlpatien_for.DataValueField = "PtntypeId";
                ddlpatien_for.DataTextField = "Ptntype";
                ddlpatien_for.DataBind();
                ddlpatien_for.Items.Insert(0, new ListItem("Select", "Ptntype"));
                dr = null;

                //ddlpatien_for.Items.Clear();
                //cmd2 = connection.con.CreateCommand();
                //cmd2.CommandType = CommandType.Text;
                //cmd2.CommandText = "sp_Ptnt_Apt_ddl";
                //DataTable DT3 = new DataTable();
                //dr2 = cmd2.ExecuteReader();
                //DT3.Load(dr2);
                //ddlpatien_for.DataSource = DT3;
                //ddlpatien_for.DataValueField = "AptTYpeId";
                //ddlpatien_for.DataTextField = "AptTYpe";
                //ddlpatien_for.DataBind();
                //ddlpatien_for.Items.Insert(0, new ListItem("Select Appointment Type", "AptTYpe"));
                //dr2 = null;
                cn.Close();
                Select();
            }
        }
        #endregion
         
    }
    public void Select()
    {
        if (Request.QueryString["Enq_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Enq_Id"].ToString());
                double fun_id = System.Convert.ToInt32(id1);
                // cmd = new SqlCommand("tbl_func_meet_Select", connection.con);
                cmd = new SqlCommand("tbl_Enquiry_ID", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pEnq_id", fun_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.Open();
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbleid.Value = DT1.Rows[0][0].ToString();

                ddlpatien_for.SelectedItem.Text = DT1.Rows[0][3].ToString();
                txtptnt_nm.Text = DT1.Rows[0][2].ToString();
                lblptnt_id.Value = DT1.Rows[0][1].ToString();
                txtAge.Text = DT1.Rows[0][4].ToString();
                txtDate.Text = DT1.Rows[0][5].ToString();
                txtEnquiry_by.Text = DT1.Rows[0][6].ToString();
                txtMob.Text = DT1.Rows[0][7].ToString();                
                string Comp = DT1.Rows[0][8].ToString();
                if (Comp == "True")
                {
                    chkenq.Checked = true;
                }
                else
                {
                    chkenq.Checked = false;
                }
                txtBrif.Text = DT1.Rows[0][9].ToString();
                dr = null;
                cn.Close();
                //Response.Write("<script language='JavaScript'>alert('')</script>");
                btnSave.Text = "Edit";
            }
            catch
            { }
            #endregion
        }
    }
    public void Clear()
    {
        txtptnt_nm.Text = "";
        txtEnquiry_by.Text = "";
        txtAge.Text = "";
        ddlpatien_for.SelectedIndex = -1;
        txtMob.Text = "";
        txtDate.Text = "";
        ddlpatien_for.Focus();
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {        
        Response.Redirect("~/EnqList_Grid.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Save
        try
        {
            if (btnSave.Text == "Edit")
            {
                 if (txtptnt_nm.Text=="")
            {
                
            }
            else
            {
                //string ptnt_nm1 = txtptnt_nm.Text;
                //string[] WordArray = ptnt_nm1.Split('-');
                //string Name = WordArray[0].ToString();
                //lblptnt_id.Value = WordArray[1];
                int Enq_id = Convert.ToInt32(lbleid.Value);
                int  Ptnt_for = ddlpatien_for.SelectedIndex;
                string ptnt_nm = txtptnt_nm.Text.ToString();
                int Age = Convert.ToInt32(txtAge.Text);
                string Enq_by = txtEnquiry_by.Text.ToString();
                //DateTime Enq_Dt = Convert.ToDateTime(txtDate.Text);
                Enq_Dt = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", null);
                double Mob = System.Convert.ToDouble(txtMob.Text);
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Brif = txtBrif.Text;
                int Com;
                if (chkenq.Checked == true)
                    Com = 1;
                else
                {
                    Com = 0;
                }
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_Enquiry_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pEnq_id", Enq_id);
                cmd.Parameters.AddWithValue("@pPtnt_nm", ptnt_nm);
                cmd.Parameters.AddWithValue("@pPtntypeId", Ptnt_for);
                cmd.Parameters.AddWithValue("@pAge", Age);
                cmd.Parameters.AddWithValue("@pEnq_By", Enq_by);
                cmd.Parameters.AddWithValue("@pEnq_Dt", Enq_Dt);
                cmd.Parameters.AddWithValue("@pMob", Mob);
                cmd.Parameters.AddWithValue("@pBrif", Brif);
                cmd.Parameters.AddWithValue("@pComplete", Com);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("EnqList_Grid.aspx");
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                Clear();
            }
            }
            else
            {
            if (txtptnt_nm.Text=="")
            {
                
            }
            else
            {
                //string ptnt_nm1 = txtptnt_nm.Text;
                //string[] WordArray = ptnt_nm1.Split('-');
                //string Name = WordArray[0].ToString();
                //lblptnt_id.Value = WordArray[1];
                int Enq_id = 0;
                int  Ptnt_for = ddlpatien_for.SelectedIndex;
                string ptnt_nm = txtptnt_nm.Text.ToString();
                int Age = Convert.ToInt32(txtAge.Text);
                string Enq_by = txtEnquiry_by.Text.ToString();
                //DateTime Enq_Dt = Convert.ToDateTime(txtDate.Text); 
                Enq_Dt = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", null);
                double Mob = System.Convert.ToDouble(txtMob.Text);
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Brif = txtBrif.Text;
                int Com;
                if (chkenq.Checked == true)
                    Com = 1;
                else
                {
                    Com = 0;
                }
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_Enquiry_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pEnq_id", Enq_id);
                cmd.Parameters.AddWithValue("@pPtnt_nm", ptnt_nm);
                cmd.Parameters.AddWithValue("@pPtntypeId", Ptnt_for);
                cmd.Parameters.AddWithValue("@pAge", Age);
                cmd.Parameters.AddWithValue("@pEnq_By", Enq_by);
                cmd.Parameters.AddWithValue("@pEnq_Dt", Enq_Dt);
                cmd.Parameters.AddWithValue("@pMob", Mob);
                cmd.Parameters.AddWithValue("@pBrif", Brif);
                cmd.Parameters.AddWithValue("@pComplete", Com);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("EnqList_Grid.aspx");
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                Clear();
            }
           }
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is not save')</script>");
        }
        #endregion
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EnqList_Grid.aspx");
    }
}
