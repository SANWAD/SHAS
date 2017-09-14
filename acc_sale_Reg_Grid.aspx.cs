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
using System.Drawing;
using iTextSharp.text;

public partial class acc_sale_Reg_Grid : System.Web.UI.Page
{
    #region Declaration
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    DataSet ds, ds1;
    SqlDataAdapter da;
    double id;
    int ptnt_id ;
    string ptnt_nm ;
    DateTime  Fdate,Edate;
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
                cmd.CommandText = "tbl_acc_sale_g";
                cmd.Parameters.Add("@pAcc_id", SqlDbType.Int).Value = ptnt_id;
                cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
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
                    if (GridView1.Columns.Count > 1)
                    {
                        GridView1.Columns[1].Visible = false;
                    }
                   // AddLinkButton();
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
    private void AddLinkButton()
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = new LinkButton();
                lb.Text = "Print";
                lb.CommandName = "Print";
                lb.Command += LinkButton_Command;
                row.Cells[10].Controls.Add(lb);
            }
        }
    }
    protected void LinkButton_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Print")
        {
            //This is to test  
            LinkButton lb = (LinkButton)sender;
            lb.Text = "OK";
        }
    } 
    protected void btn_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "btn","<script type = 'text/javascript'>alert('Button Clicked');</script>");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Doc_Type"] = "SA";
        int Acc_Id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        Response.Redirect("~/acc_sale_Reg.aspx?Acc_Id=" + Acc_Id);
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int Acc_Id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        Response.Redirect("~/acc_sale_Reg.aspx?Acc_Id=" + Acc_Id);
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
        int Acc_Id = 0;
        Session["Doc_Type"] = "SA";
        Response.Redirect("acc_sale_Reg.aspx?Acc_Id=" + Acc_Id);
    }
    protected void btnSerch_Click(object sender, EventArgs e)
    {
        #region Grid Load
        ptnt_id = 0;
        ptnt_nm = txtDesc.Text;
        if ((txtFr_Dt.Text == "" && txtTo_Dt.Text=="") || (txtFr_Dt.Text == "" || txtTo_Dt.Text==""))
        {
            Fdate = Convert.ToDateTime(null);
            Edate =Convert.ToDateTime(null);
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
        cmd.CommandText = "tbl_acc_sale_g";
        cmd.Parameters.Add("@pAcc_id", SqlDbType.Int).Value = ptnt_id;
        cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
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
            if (GridView1.Columns.Count > 1)
            {
                GridView1.Columns[1].Visible = false;
            }
            //AddLinkButton();
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
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    var firstCell = e.Row.Cells[1];
        //    firstCell.Controls.Clear();
        //    Button btn_Check = new Button();
        //    btn_Check.ID = "btn_Check";
        //    btn_Check.Text = firstCell.Text;
        //    btn_Check.Click += new EventHandler(btn_Check_Click);
        //    firstCell.Controls.Add(btn_Check);
        //}
    }
    protected void btn_Check_Click(object sender, EventArgs e)
    {
        int billno = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        Response.Redirect("~/acc_bill.aspx?bill_no=" + billno);
    }
    protected void btnPur_Click(object sender, EventArgs e)
    {
        int Acc_Id = 0;
        Session["Doc_Type"] = "PA";
        Response.Redirect("acc_sale_Reg.aspx?Acc_Id=" + Acc_Id);
    }
}
