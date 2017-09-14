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

public partial class ChangePwd : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    double id;
    SqlDataReader dr1;
    SqlDataAdapter da;
    DataSet ds,ds1;

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
                cn.Open();
                ddlUser.Items.Clear();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_User_DDL";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "tbl_user_master");

                DataTable DT2 = new DataTable();
                dr1 = cmd.ExecuteReader();
                DT2.Load(dr1);
                ddlUser.DataSource = DT2;
                ddlUser.DataValueField = "USER_ID";
                ddlUser.DataTextField = "user_nm";
                ddlUser.DataBind();
                ddlUser.Items.Insert(0, new ListItem("Select", "user_nm"));
                ddlUser.SelectedIndex = 0;
                dr1 = null;
                cn.Close();                
                Clear();
            }
        }
    }
    public void Clear()
    {
        lblinw_no.Value = "";       
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string User = ddlUser.SelectedItem.Text;
        int Cntr_id = Convert.ToInt32(Session["Cntr_id"]);       
        cmd = connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd = new SqlCommand("sp_ChkUser_Pwd", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@puser_nm", User);
        cmd.Parameters.AddWithValue("@Cntr_id", Cntr_id);
        da = new SqlDataAdapter(cmd);
        ds1 = new DataSet();
        string user_type, User_Pwd;
        da.Fill(ds1, "tbl_user_master");
        try
        {
          user_type = ds1.Tables["tbl_user_master"].Rows[0][0].ToString();
          User_Pwd = ds1.Tables["tbl_user_master"].Rows[0][1].ToString();

        string UPwd = txtOldPwd.Text;
        string UNPwd = txtNewPwd.Text;
        string UserChk = Session["UserName"].ToString();
        if (UPwd == User_Pwd)
        {
            #region SelectUser
           // int Cntr_id = Convert.ToInt32(Session["Cntr_id"]);
            cmd = new SqlCommand("UChanPwd", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserChk);
            cmd.Parameters.AddWithValue("@UPwd", UPwd);
            cmd.Parameters.AddWithValue("@UNPwd", UNPwd);
            cmd.Parameters.AddWithValue("@created_by", Session["Name"].ToString());
            cmd.Parameters.AddWithValue("@Cntr_id", Cntr_id);
            cn.executeprocedure(cmd);
            #endregion
            Response.Write("<script>alert('Changed Password Successfully')</Script>");
        }
        else
        {
            Response.Write("<script>alert('Check New & Confirm Password Or Old Password Does'not Match')</Script>");
        }
        }
        catch { Response.Write("<script>alert('Check New & Confirm Password Or Old Password Does'not Match')</Script>"); }
    }
    protected void btnCanel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Appointments_Grid.aspx");
    }
}
