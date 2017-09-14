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
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

public partial class hm_Inward_Dt_Grid : System.Web.UI.Page
{
    #region Declaration
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    DataSet ds, ds1;
    SqlDataAdapter da;
    double id;
    public SqlConnection con = new SqlConnection();
    public void Connect()
    {
        con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connetionString"].ConnectionString);
    }
    DateTime dt = System.DateTime.Now.Date;
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
            #region Grid Load
            cmd = connection.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "sp_Inward_display";
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "tbl_inward_trn");
            if (ds.Tables["tbl_inward_trn"].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables["tbl_inward_trn"];
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Please Select Valid Inward')</script>");
            }
            #endregion
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("~/inward.aspx");
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("~/inward.aspx");
    }
}
