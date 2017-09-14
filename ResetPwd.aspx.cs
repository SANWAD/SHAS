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

public partial class ResetPwd : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    double id;
    SqlDataReader dr1;
    SqlDataAdapter da;
    DataSet ds;

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
        txtinwfrom.Text = "";        
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        #region Save
        try
        {
            int inw_no = 0;
            string inw_from = txtinwfrom.Text.ToString();
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_inward_trn_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);           
            cmd.Parameters.AddWithValue("@pinw_from", inw_from);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            cn.executeprocedure(cmd);
            cn.Close();
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
            Response.Redirect("inward_Grid.aspx");
            btnsave.Enabled = false;
            Clear();
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
        }
        #endregion
    }
    protected void btnCanel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inward_Grid.aspx");
    }
}
