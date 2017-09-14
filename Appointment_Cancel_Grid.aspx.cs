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

public partial class Appointment_Cancel_Grid : System.Web.UI.Page
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
    DateTime Fdate, Edate;
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
                ptnt_nm = "";
                Fdate = Convert.ToDateTime(null);
                Edate = Convert.ToDateTime(null);
                String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "tbl_apointment_trn_g";                
                cmd.Parameters.Add("@pApt_id", SqlDbType.Int).Value = ptnt_id;
                cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
                cmd.Parameters.Add("@pFDate", SqlDbType.Date ).Value = Fdate;
                cmd.Parameters.Add("@pEDate", SqlDbType.Date ).Value = Edate;
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
                        GridView1.Columns[2].Visible = false;
                    } 
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
            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ptnt_id"] = GridView1.SelectedRow.Cells[11].Text;
        int Appo_Id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        Session["Appo_Id"] = GridView1.SelectedRow.Cells[1].Text;
        //Response.Redirect("~/Appointments.aspx?Appo_Id=" + Appo_Id);
        Response.Redirect("~/Appointments.aspx?Appo_Id=" + Appo_Id);
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int Appo_Id = GridView1.SelectedIndex;
        Response.Redirect("~/Appointments.aspx?Appo_Id=" + Appo_Id);
    }
    protected void btnAdSearch_Click(object sender, EventArgs e)
    {
        if (btnAdSearch.Text == "Advance Search")
        {
            Panel2.Visible = true;
            lblFr_dt.Visible = true;
            lblTo_Dt.Visible = true;
            btnAdSearch.Text = "Close";
        }
        else
        {
            Panel2.Visible = false;
            btnAdSearch.Text = "Advance Search";
        }
    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        Session["Appo_Id"] = 0;
        Response.Redirect("Appointments.aspx");
    }
    protected void btnSerch_Click(object sender, EventArgs e)
    {
        #region Grid Load
        ptnt_id = 0;
        ptnt_nm = txtDesc.Text;
        if ((txtFr_Dt.Text == "" && txtTo_Dt.Text == "") || (txtFr_Dt.Text == "" || txtTo_Dt.Text == ""))
        {
            Fdate = Convert.ToDateTime(null);
            Edate = Convert.ToDateTime(null);
        }
        else
        {
            //Fdate = Convert.ToDateTime(txtFr_Dt.Text);
            //Edate = Convert.ToDateTime(txtTo_Dt.Text);
            Fdate = DateTime.ParseExact(txtFr_Dt.Text, "dd/MM/yyyy", null);
            Edate = DateTime.ParseExact(txtTo_Dt.Text, "dd/MM/yyyy", null);
        }
        String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "tbl_apointment_trn_g";
        cmd.Parameters.Add("@pApt_id", SqlDbType.Int).Value = ptnt_id;
        cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
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
    //Note : Index will start with 0 so set this value accordingly
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int indexOfColumn = 1;
        if (e.Row.Cells.Count > indexOfColumn)
        {
            e.Row.Cells[indexOfColumn].Visible = false;
            e.Row.Cells[11].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if (e.Row.Cells[11].Text == "Done")
            //{
            //    e.Row.Cells[11].Font.Bold = true;
            //    e.Row.Cells[11].ForeColor = System.Drawing.Color.LightSeaGreen;
            //}
            //else
            //{
            //    e.Row.Cells[11].ForeColor = System.Drawing.Color.IndianRed;
            //    e.Row.Cells[11].Font.Bold = true;
            //}
            if (e.Row.Cells[9].Text == "Done")
            {
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[9].ForeColor = System.Drawing.Color.LightSeaGreen;
                e.Row.Cells[11].Visible = false;
            }
            else
            {
                e.Row.Cells[9].ForeColor = System.Drawing.Color.IndianRed;
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[11].Visible = false;
            }
        }

    }   
}
