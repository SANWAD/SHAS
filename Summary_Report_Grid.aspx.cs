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

public partial class Summary_Report_Grid : System.Web.UI.Page
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
    DateTime Fdate,Edate, Fdate1;
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
                Fdate = Convert.ToDateTime(DateTime.Now);
                Edate = Convert.ToDateTime(DateTime.Now);
                Grid_Load(Fdate, Edate);
            }
        }
    }
    public void Grid_Load( DateTime FromDt,DateTime ToDt)
    {
        #region Accssories Grid Load
       // Fdate = Convert.ToDateTime(DateTime.Now);
        String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Summary_Report_Acc_g";
        cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
        cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
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
            // throw ex;
        }

        finally
        {
            con.Close();
            con.Dispose();
        }
        #endregion

        #region HAid Sale Grid Load
        //Fdate = Convert.ToDateTime(DateTime.Now);
        String strConnString1 = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con1 = new SqlConnection(strConnString1);
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.CommandText = "Summary_Report_HAid_Sale_g";
        cmd1.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
        cmd1.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
        cmd1.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        cmd1.Connection = con1;
        try
        {
            con1.Open();
            GridView2.EmptyDataText = "No Records Found";
            GridView2.DataSource = cmd1.ExecuteReader();
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
            // throw ex;
        }

        finally
        {
            con1.Close();
            con1.Dispose();
        }
        #endregion

        #region HAid Repair Grid Load
        //Fdate = Convert.ToDateTime(DateTime.Now);
        String strConnString2 = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con2 = new SqlConnection(strConnString2);
        SqlCommand cmd2 = new SqlCommand();
        cmd2.CommandType = CommandType.StoredProcedure;
        cmd2.CommandText = "Summary_Report_HAid_Repair_g";
        cmd2.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
        cmd2.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
        cmd2.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        cmd2.Connection = con2;
        try
        {
            con2.Open();
            GridView3.EmptyDataText = "No Records Found";
            GridView3.DataSource = cmd2.ExecuteReader();
            GridView3.DataBind();
        }
        catch (Exception ex)
        {
            // throw ex;
        }

        finally
        {
            con2.Close();
            con2.Dispose();
        }
        #endregion

        #region Pitty Cash Grid Load
        //Fdate = Convert.ToDateTime(DateTime.Now);
        String strConnString3 = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con3 = new SqlConnection(strConnString3);
        SqlCommand cmd3 = new SqlCommand();
        cmd3.CommandType = CommandType.StoredProcedure;
        cmd3.CommandText = "Petty_Cash_g";
        cmd3.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
        cmd3.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
        cmd3.Parameters.Add("@pCntr_id", Convert.ToInt32(Session["Cntr_id"]));
        cmd3.Connection = con3;
        try
        {
            con3.Open();
            GridView4.EmptyDataText = "No Records Found";
            GridView4.DataSource = cmd3.ExecuteReader();
            GridView4.DataBind();
        }
        catch (Exception ex)
        {
            // throw ex;
        }

        finally
        {
            con3.Close();
            con3.Dispose();
        }
        #endregion

        #region Inward Grid Load
        //Fdate = Convert.ToDateTime(DateTime.Now);
        String strConnString4 = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con4 = new SqlConnection(strConnString4);
        SqlCommand cmd4 = new SqlCommand();
        cmd4.CommandType = CommandType.StoredProcedure;
        cmd4.CommandText = "Summary_Report_Inward_g";
        cmd4.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
        cmd4.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
        cmd4.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        cmd4.Connection = con4;
        try
        {
            con4.Open();
            GridView5.EmptyDataText = "No Records Found";
            GridView5.DataSource = cmd4.ExecuteReader();
            GridView5.DataBind();
        }
        catch (Exception ex)
        {
            // throw ex;
        }

        finally
        {
            con4.Close();
            con4.Dispose();
        }
        #endregion

        #region Hearing Aid Inward Grid Load
        //Fdate = Convert.ToDateTime(DateTime.Now);
        String strConnString5 = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con5 = new SqlConnection(strConnString5);
        SqlCommand cmd5 = new SqlCommand();
        cmd5.CommandType = CommandType.StoredProcedure;
        cmd5.CommandText = "Summary_Report_HM_Inward_g";
        cmd5.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
        cmd5.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
        cmd5.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        cmd5.Connection = con5;
        try
        {
            con5.Open();
            GridView6.EmptyDataText = "No Records Found";
            GridView6.DataSource = cmd5.ExecuteReader();
            GridView6.DataBind();
        }
        catch (Exception ex)
        {
            // throw ex;
        }

        finally
        {
            con5.Close();
            con5.Dispose();
        }
        #endregion

        #region Enquiry Load
        //Fdate = Convert.ToDateTime(DateTime.Now);
        String strConnString6 = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con6 = new SqlConnection(strConnString6);
        SqlCommand cmd6 = new SqlCommand();
        cmd6.CommandType = CommandType.StoredProcedure;
        cmd6.CommandText = "Summary_Report_Enquary_g";
        cmd6.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
        cmd6.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
        cmd6.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        cmd6.Connection = con6;
        try
        {
            con6.Open();
            GridView7.EmptyDataText = "No Records Found";
            GridView7.DataSource = cmd6.ExecuteReader();
            GridView7.DataBind();
        }
        catch (Exception ex)
        {
            // throw ex;
        }

        finally
        {
            con6.Close();
            con6.Dispose();
        }
        #endregion

        #region Patient Register Load
        //Fdate = Convert.ToDateTime(DateTime.Now);
        String strConnString7 = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con7 = new SqlConnection(strConnString7);
        SqlCommand cmd7 = new SqlCommand();
        cmd7.CommandType = CommandType.StoredProcedure;
        cmd7.CommandText = "Summary_Report_Ptn_Reg_g";
        cmd7.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
        cmd7.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
        cmd7.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        cmd7.Connection = con7;
        try
        {
            con7.Open();
            GridView8.EmptyDataText = "No Records Found";
            GridView8.DataSource = cmd7.ExecuteReader();
            GridView8.DataBind();
        }
        catch (Exception ex)
        {
            // throw ex;
        }

        finally
        {
            con7.Close();
            con7.Dispose();
        }
        #endregion 

    }
    protected void btnSerch_Click(object sender, EventArgs e)
    {
        Fdate = DateTime.ParseExact(txtFr_Dt.Text, "dd/MM/yyyy", null);
        Edate = DateTime.ParseExact(txtTo_Dt.Text, "dd/MM/yyyy", null);
        Grid_Load(Fdate, Edate);
    }
}
