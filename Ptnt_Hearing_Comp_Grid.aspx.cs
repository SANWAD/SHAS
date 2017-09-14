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

public partial class Ptnt_Hearing_Comp_Grid : System.Web.UI.Page
{
    connection cn;
    #region Declaration
    SqlCommand cmd;
    SqlDataReader dr;
    DataSet ds, ds1;
    SqlDataAdapter da;
    double id;
    DateTime dt = System.DateTime.Now.Date;
    int ptnt_id;
    string ptnt_nm,ptnt_nm1,ptnt_nm2;
    DateTime Fdate, Edate;
    public SqlConnection con = new SqlConnection();
    public void Connect()
    {
        con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connetionString"].ConnectionString);
    }
   // DateTime dt = System.DateTime.Now.Date;
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
                ptnt_nm = "";
                ptnt_nm1 = "";
                ptnt_nm2 = "";
                Fdate = Convert.ToDateTime(null);
                Edate = Convert.ToDateTime(null);
                String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Ptnt_Aid_and_Comp_g";
                cmd.Parameters.Add("@pSale_id", SqlDbType.Int).Value = ptnt_id;
                cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
                cmd.Parameters.Add("@pSEARCH1", SqlDbType.VarChar).Value = ptnt_nm1;
                cmd.Parameters.Add("@pSEARCH2", SqlDbType.VarChar).Value = ptnt_nm2;
                cmd.Parameters.Add("@pFDate", SqlDbType.VarChar).Value = Fdate;
                cmd.Parameters.Add("@pEDate", SqlDbType.VarChar).Value = Edate;
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
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

    }
    protected void btnSerch_Click(object sender, EventArgs e)
    {
        #region Grid Load
        ptnt_id = 0;
        ptnt_nm = txtDesc.Text;
        ptnt_nm1 = txtModel.Text;
        ptnt_nm2 = txtType.Text;
        if ((txtFr_Dt.Text == "" && txtTo_Dt.Text == "") || (txtFr_Dt.Text == "" || txtTo_Dt.Text == ""))
        {
            Fdate = Convert.ToDateTime(null);
            Edate = Convert.ToDateTime(null);
        }
        else
        {
            Fdate = DateTime.ParseExact(txtFr_Dt.Text, "dd/MM/yyyy", null);
            Edate = DateTime.ParseExact(txtTo_Dt.Text, "dd/MM/yyyy", null);
        }
        String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Ptnt_Aid_and_Comp_g";
        cmd.Parameters.Add("@pSale_id", SqlDbType.Int).Value = ptnt_id;
        cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
        cmd.Parameters.Add("@pSEARCH1", SqlDbType.VarChar).Value = ptnt_nm1;
        cmd.Parameters.Add("@pSEARCH2", SqlDbType.VarChar).Value = ptnt_nm2;
        cmd.Parameters.Add("@pFDate", SqlDbType.VarChar).Value = Fdate;
        cmd.Parameters.Add("@pEDate", SqlDbType.VarChar).Value = Edate;
        cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        cmd.Connection = con;
        try
        {
            con.Open();
            GridView1.EmptyDataText = "No Records Found";
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
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
