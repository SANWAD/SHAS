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

public partial class Login : System.Web.UI.Page
{
    connection cn;
    DataSet ds1;//ds;
    string user_type;
    //private int startTime;
    SqlCommand cmd;
    SqlDataAdapter da;
    //SqlDataReader dr1;
    string UCntr_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new connection();
        txtu_nm.Focus();
        //txtUsrNm.Focus();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetAllowResponseInBrowserHistory(false);    
         #region Loading
        if (!IsPostBack)
        {            
            //cn.Open();
            //ddlCenter_Nm.Items.Clear();            
            //cmd = connection.con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "sp_Center_nm";
            //da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds, "tbl_Center_master");

            //DataTable DT2 = new DataTable();                     
            //dr1 = cmd.ExecuteReader();
            //DT2.Load(dr1);
            //ddlCenter_Nm.DataSource = DT2;
            //ddlCenter_Nm.DataValueField = "Cntr_id";
            //ddlCenter_Nm.DataTextField = "Cntr_Nm"; 
            //ddlCenter_Nm.DataBind();
            //ddlCenter_Nm.Items.Insert(0, new ListItem("Select", "Cntr_Nm"));
            //dr1 = null;
            //cn.Close();
        }
        #endregion
        Session["Company Name"] = "Hearing & Health Care Clinic";
        Session["Company Address"] = "No 29, Sri Krishna , Magadi Main Road, M C Layout,Vijaynagar, Bangalore 560040 Ph: 080 40901188";
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        #region Login
        //if (ddlCenter_Nm.SelectedItem.Text == "Select")
        //{
        //    Response.Write("<script>alert('Please Select Center To Login')</script>");
        //}
        //else
        //{
            if (Page.IsValid == true)
            {
                string user_nm = txtu_nm.Text.ToString();
                string user_pwd = txtpwd.Text.ToString();
                 
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("sp_User_Login", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@puser_nm", user_nm);
                cmd.Parameters.AddWithValue("@puser_pwd", user_pwd);
                da = new SqlDataAdapter(cmd);
                ds1 = new DataSet();
                da.Fill(ds1, "tbl_user_master");
                try
                {
                    user_type = ds1.Tables["tbl_user_master"].Rows[0][1].ToString();
                    UCntr_id = ds1.Tables["tbl_user_master"].Rows[0][2].ToString();
                }
                catch { Response.Redirect("~/Login.aspx"); }

                if (ds1.Tables["tbl_user_master"].Rows.Count > 0)
                {
                    Session["Cntr_id"] = UCntr_id;
                    Session["Name"] = user_type;
                    Session["UserName"] = user_nm;
                    Response.Redirect("~/Appointments_Grid.aspx");
                }
            }

       // }
        #endregion
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtu_nm.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtpwd.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
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
}
