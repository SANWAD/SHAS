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

public partial class AptCancle : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlDataReader dr;
    connection cn;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new connection();
        if (!IsPostBack)
        {
            ptnt_for.Focus();
            lbldate.Text = System.DateTime.Now.ToShortDateString();
        }
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
    protected void ddl_ptnt_nm_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region patient information
        try
        {
            //string[] arrrSelVal = ddl_ptnt_nm.SelectedValue.Split(',');
            //double pid = System.Convert.ToInt32(arrrSelVal[0]);
            //DateTime dat = System.DateTime.Now.Date;
            //cmd = new SqlCommand("sp_apt_select", connection.con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@p_ptnt_id", pid);
            //cmd.Parameters.AddWithValue("@p_apt_date", dat);
            //cn.Open();
            //cn.executeprocedure(cmd);
            //DataTable DT1 = new DataTable();
            //cn.Open();
            //dr = cmd.ExecuteReader();
            //DT1.Load(dr);

            //lblaptid.Text = DT1.Rows[0][1].ToString();
            //ptnt_for.Text = DT1.Rows[0][3].ToString();
            //txtdate.Text = DT1.Rows[0][6].ToString();
            //txt_time.Text = DT1.Rows[0][7].ToString();
            //dr = null;
            //cn.Close();
        }
        catch { Response.Redirect("~/error.aspx"); }
        #endregion
    }
    protected void btn_del_Click(object sender, EventArgs e)
    {
        #region DELETE
        //int apt_id = Convert.ToInt32(lblaptid.Text);
        //string time = txt_time.Text.ToString();
        //DateTime dt1 = Convert.ToDateTime(txtdate.Text);
        //cmd = new SqlCommand("sp_del_apt", connection.con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@p_apt_id", apt_id);
        //cmd.Parameters.AddWithValue("@p_apt_date", dt1);
        //cmd.Parameters.AddWithValue("@p_apt_time", time);
        //cmd.Parameters.AddWithValue("@p_revised_by", Session["Name"].ToString());
        //cn.Open();
        //cn.executeprocedure(cmd);
        //Response.Write("<script language='JavaScript'>alert('Appointment DAte & Time Is " + dt1 + " , " + time + " ')</script>");
        //cn.Close();

        //lblaptid.Text = "";
        ////ptnt_for.Text = "";
        //txtdate.Text = "";
        ////ddl_ptnt_nm.Items.Clear();
        //txt_time.Text = "";
        #endregion
    }
}
