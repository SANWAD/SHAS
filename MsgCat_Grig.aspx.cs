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
using System.Collections.Generic;

public partial class MsgCat_Grig : System.Web.UI.Page
{
    #region Declaration
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    DataSet ds, ds1;
    SqlDataAdapter da;
    double id;
    int ptnt_id;
    string ptnt_nm;
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
            if (!IsPostBack)
            {
                #region Grid Load
                ptnt_id = 0;
                ptnt_nm = "-1";
                String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MessageCat_g";
                cmd.Parameters.Add("@pCATID", SqlDbType.Int).Value = ptnt_id;
                cmd.Parameters.Add("@pFlag", SqlDbType.VarChar).Value = ptnt_nm;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    if (GridView1.Columns.Count > 1)
                    {
                        GridView1.Columns[1].Visible = false;
                    } 
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                finally
                {
                    con.Close();
                    con.Dispose();
                }
                #endregion
            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Cent_Id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        Response.Redirect("~/MsgCat.aspx?Msg_Id=" + Cent_Id);
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int Cent_Id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        Response.Redirect("~/MsgCat.aspx?Msg_Id=" + Cent_Id);
    }
    protected void btnAdSearch_Click(object sender, EventArgs e)
    {
        if (btnAdSearch.Text == "Advance Search")
        {
            Panel1.Visible = true;
            lblFr_dt.Visible = true;
            lblTo_Dt.Visible = true;
            btnAdSearch.Text = "Close";
        }
        else
        {
            Panel1.Visible = false;
            btnAdSearch.Text = "Advance Search";
        }
    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        int Cent_Id = 0;
        Response.Redirect("~/MsgCat.aspx?Msg_Id=" + Cent_Id);
    }
    protected void btnSerch_Click(object sender, EventArgs e)
    {
        #region Grid Load
        ptnt_id = 0;
        ptnt_nm = txtDesc.Text;
        String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "MessageCat_g";
        cmd.Parameters.Add("@pCATID", SqlDbType.Int).Value = ptnt_id;
        cmd.Parameters.Add("@pFlag", SqlDbType.VarChar).Value = ptnt_nm;
        cmd.Connection = con;
        try
        {
            con.Open();
            GridView1.EmptyDataText = "No Records Found";
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            if (GridView1.Columns.Count > 1)
            {
                GridView1.Columns[1].Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            con.Close();
            con.Dispose();
        }
        #endregion
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int indexOfColumn = 1;
        if (e.Row.Cells.Count > indexOfColumn)
        {
            e.Row.Cells[indexOfColumn].Visible = false;
        }
    }
}
