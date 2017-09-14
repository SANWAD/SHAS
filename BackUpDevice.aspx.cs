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

public partial class BackUpDevice : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlCommand sqlcmd = new SqlCommand(); 
    connection cn;
    SqlConnection con = new SqlConnection();
    SqlDataReader dr;
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
                txtPath.Focus();
            }
        }        

    }
    protected void btnBackUp_Click(object sender, EventArgs e)
    {
        //con.ConnectionString = "Data Source=SANWAD;UID='sa';Initial Catalog=DB_SANWAD;pwd='sanwad';integrated security=true;";
        //string backupDIR = "D:\\Organiser Delly Back Up";
        //if (!System.IO.Directory.Exists(backupDIR))
        //{
        //    System.IO.Directory.CreateDirectory(backupDIR);
        //}
        //try
        //{
        //    con.Open();
        //    sqlcmd = new SqlCommand("backup database test to disk='" + backupDIR + "\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'", con);
        //    sqlcmd.ExecuteNonQuery();
        //    con.Close();
        //    lblError.Text = "Backup database successfully";
        //}
        //catch (Exception ex)
        //{
        //    lblError.Text = "Error Occured During DB backup process !<br>" + ex.ToString();
        //} 
        #region BackUp
        //string backupDIR = @"D:\Delly Back Up";
        string backupDIR = txtPath.Text.ToString();
        if (!System.IO.Directory.Exists(backupDIR))
        {
            System.IO.Directory.CreateDirectory(backupDIR);
        }
            try
            {
                string Path = txtPath.Text.ToString() + "" + DateTime.Now.ToString("dd-MM-yyyy_HHmmss") + ".Bak'";
                string DbName = txtDbNm.Text.ToString();
                cn.Open();
                cmd = new SqlCommand("sp_BackUp", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_Disk", Path);
                cmd.Parameters.AddWithValue("@P_Bak_Name", DbName);
                cn.executeprocedure(cmd);
                cn.Close();
                lblError.Text = "Backup database successfully";
            }
            catch (Exception ex)
            {
                lblError.Text = "Error Occured During DB backup process !<br>" + ex.ToString();
            }
        #endregion
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Appointments_Grid.aspx");
    }
}
