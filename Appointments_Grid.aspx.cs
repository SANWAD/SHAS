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

public partial class Appointments_Grid : System.Web.UI.Page
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
                        GridView1.Columns[3].Visible = false;
                        GridView1.Columns[6].Visible = false; 
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
        //int Appo_Id = GridView1.SelectedIndex;
        //Response.Redirect("~/Appointments.aspx?Appo_Id=" + Appo_Id);
        DateTime Apt_dt = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
        double id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        //string Time = GridView1.SelectedRow.Cells[7].Text;
        string Time = GridView1.SelectedRow.Cells[5].Text;
        cmd = connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        //cmd.CommandText = "select ptnt_for,ptnt_type from tbl_apointment_trn as APT inner join tbl_ptn_master as PT on PT.ptnt_id=Apt.ptnt_id where PT.ptnt_id=" + id + " and apt_date='" + dt + "'";
        cmd = new SqlCommand("sp_Apt_Sel_Form", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@p_ApT_Dt", Apt_dt);
        cmd.Parameters.AddWithValue("@p_apt_id", id);
        cmd.Parameters.AddWithValue("@p_Apt_Time", Time);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "tbl_ptn_master");
        if (ds.Tables["tbl_ptn_master"].Rows.Count > 0)
        {
            string For = ds.Tables["tbl_ptn_master"].Rows[0][1].ToString();
            if (For == "Hearing Problem")
            {
                Session["Ass_id"] = 0;
                Response.Redirect("~/h_assessment.aspx?id=" + id + "");
            }
            else if (For == "Speech Problem")
            {
                Session["Ass_id"] = 0;
                Response.Redirect("~/s_as_asses.aspx?id=" + id + "");
            }
            else if (For == "Both")
            {
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                // cmd = new SqlCommand("sp_Apt_Sel_Both_Form", connection.con);sp_Apt_Sel_Form
                cmd = new SqlCommand("sp_Apt_Sel_Form", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@p_ApT_Dt", Apt_dt);
                //cmd.Parameters.AddWithValue("@p_Ptnt_id", id);@p_apt_id
                cmd.Parameters.AddWithValue("@p_apt_id", id);
                cmd.Parameters.AddWithValue("@p_Apt_Time", Time);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "tbl_apointment_trn");
                string For1 = ds.Tables["tbl_apointment_trn"].Rows[0][0].ToString();
                if (For1 == "Hearing Testing" || For1 == "Hearing Aid Trial")
                {
                    Session["Ass_id"] = 0;
                    Response.Redirect("~/h_assessment.aspx?id=" + id + "");
                }
                else
                {
                    Session["Ass_id"] = 0;
                    Response.Redirect("~/s_as_asses.aspx?id=" + id + "");
                }
            }
            else
            {
                string For1 = ds.Tables["tbl_ptn_master"].Rows[0][1].ToString();

                if (For1 == "CI")
                {
                    Session["CoCh_Id"] = 0;
                    Response.Redirect("~/CochlearImplant.aspx?id=" + id + "");
                }
                else
                {
                    //Response.Redirect("~/Clinical Forms/CochlearImplant.aspx");
                }
            }
        }
        else
        {
            //    Response.Write("<script>alert('')</script>");                        
        }
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
        Session["ptnt_id"] = 0;
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
            if (e.Row.Cells[9].Text == "Done")
            {
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[9].ForeColor = System.Drawing.Color.LightSeaGreen;
                e.Row.Cells[6].Font.Bold = true;
                //e.Row.Cells[6].ForeColor = System.Drawing.Color.LightSeaGreen;
                e.Row.Cells[6].Width = 400;
                e.Row.Cells[11].Visible = false;
            }
            else
            {
                e.Row.Cells[9].ForeColor = System.Drawing.Color.IndianRed;
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[6].Font.Bold = true;
                //e.Row.Cells[6].ForeColor = System.Drawing.Color.IndianRed;
                e.Row.Cells[6].Width = 400;
                e.Row.Cells[11].Visible = false;
            }

        }
    }
    protected void btnPtn_New_Click(object sender, EventArgs e)
    {
        Response.Redirect("PtntList_Grid.aspx");
    }
    protected void btnApt_Tel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Apt_Tel_Grid.aspx");
    }
    protected void btnAptCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Appointment_Cancel_Grid.aspx");
    }
}
