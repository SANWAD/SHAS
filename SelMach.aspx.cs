using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Master_SelMach : System.Web.UI.Page
{
    #region Declaration
    string[] adj ={"--SELECT--","1000","1500","5000","10000","15000","20000", "25000", "30000","35000","40000","45000","50000","55000","60000","65000","70000",
                   "80000","90000","100000","110000","120000","130000","140000","150000","170000","180000"};
    string[] adk ={"5000","10000","15000","20000", "25000", "30000","35000","40000","45000","50000","55000","60000","65000","70000",
                   "80000","90000","100000","110000","120000","130000","140000","150000","170000","180000","250000"};
    string N, Y;    
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    DataSet ds;
    SqlDataAdapter da;
    int From_Price;
        
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new connection();
        #region Loading
        if (!IsPostBack)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                cn = new connection();
                cn.Open();
                ddlType.Items.Clear();
                cmd = new SqlCommand("select distinct mach_type from tbl_machine_master order by mach_type", connection.con);
                DataTable DT1 = new DataTable();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                ddlType.DataSource = DT1;
                ddlType.DataTextField = "mach_type";
                ddlType.Items.Insert(0, new ListItem("Machine Type", "mach_type"));
                ddlType.SelectedIndex = 0;
                ddlType.DataBind();
                dr = null;
                cn.Close();

                //cn.Open();
                //ddlComp.Items.Clear();
                //cmd = new SqlCommand("select distinct mach_Desc from tbl_machine_master order by mach_cmp", connection.con);
                //DataTable DT2 = new DataTable();
                //dr = cmd.ExecuteReader();
                //DT2.Load(dr);
                //ddlComp.DataSource = DT2;
                ////ddlComp.DataValueField = "mach_id";
                //ddlComp.DataTextField = "mach_Desc";
                //ddlComp.Items.Insert(0, new ListItem("Machine Company", "mach_Desc"));
                //ddlComp.SelectedIndex = 0;
                //ddlComp.DataBind();
                //dr = null;
                //cn.Close();
            }
            ddlFrom_Price.DataSource = adj;
            ddlFrom_Price.DataBind();
            ddlTo_Price.DataSource = adk;
            ddlTo_Price.DataBind();
        #endregion
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        #region Search
        if (txtComp.Text == "")
        {
            string A, B;
            if (ddlFrom_Price.SelectedIndex == 0)
            {
                A = "0";
            }
            else
            {
                A = ddlFrom_Price.SelectedValue.ToString();
            }
            if (ddlTo_Price.SelectedIndex == 0)
            {
                B = "0";
            }
            else
            {
                B = ddlTo_Price.SelectedValue.ToString();
            }
            if (ddlFrom_Price.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Please Select Price')</script>");
                From_Price = 0;
            }
            else
            {
                From_Price = Convert.ToInt32(A);
            }
            int To_Price = Convert.ToInt32(B);

            string Typ = ddlType.SelectedValue.ToString();
            string Tech;
            if (ddlTech.SelectedIndex == 0)
            {
                Tech = "A";
            }
            else if (ddlTech.SelectedIndex == 1)
            {
                Tech = "T";
            }
            else if (ddlTech.SelectedIndex == 2)
            {
                Tech = "P";
            }
            else
            {
                Tech = "F";
            }
            if (rbtStock.SelectedIndex == 1)
            {
                string CompNm = txtComp.Text;
                cmd = new SqlCommand("sp_Sel_Mach", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFrom_Price", From_Price);
                cmd.Parameters.AddWithValue("@pTo_Price", To_Price);
                cmd.Parameters.AddWithValue("@pType", Typ);
                cmd.Parameters.AddWithValue("@pComp", CompNm);
                cmd.Parameters.AddWithValue("@pTech", Tech);
            }
            else
            {
                string CompNm = txtComp.Text;
                cmd = new SqlCommand("sp_Sel_Mach", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFrom_Price", From_Price);
                cmd.Parameters.AddWithValue("@pTo_Price", To_Price);
                cmd.Parameters.AddWithValue("@pType", Typ);
                cmd.Parameters.AddWithValue("@pComp", CompNm);
                cmd.Parameters.AddWithValue("@pTech", Tech);
            }

            //cmd.Parameters.AddWithValue("@p_Stock", AStock);                
        }
        else
        {
            string A, B;
            if (ddlFrom_Price.SelectedIndex==0)
            {
                A = "0";
            }
            else
            {
                A = ddlFrom_Price.SelectedValue.ToString();
            }
            if (ddlTo_Price.SelectedIndex == 0)
            {
                B = "0";
            }
            else
            {
                B = ddlTo_Price.SelectedValue.ToString();
            }
            int To_Price = Convert.ToInt32(B);            
            int From_Price = Convert.ToInt32(A);
            string Typ = ddlType.SelectedValue.ToString();
            string Tech;
            if (ddlTech.SelectedIndex == 0)
            {
                Tech = "A";
            }
            else if (ddlTech.SelectedIndex == 1)
            {
                Tech = "T";
            }
            else if (ddlTech.SelectedIndex == 2)
            {
                Tech = "P";
            }
            else
            {
                Tech = "F";
            }
            if (rbtStock.SelectedIndex == 1)
            {
                string CompNm = txtComp.Text;
                cmd = new SqlCommand("sp_Sel_Mach", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFrom_Price", From_Price);
                cmd.Parameters.AddWithValue("@pTo_Price", To_Price);
                cmd.Parameters.AddWithValue("@pType", Typ);
                cmd.Parameters.AddWithValue("@pComp", CompNm);
                cmd.Parameters.AddWithValue("@pTech", Tech);
            }
            else
            {
                string CompNm = txtComp.Text;
                cmd = new SqlCommand("sp_Sel_Mach", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFrom_Price", From_Price);
                cmd.Parameters.AddWithValue("@pTo_Price", To_Price);
                cmd.Parameters.AddWithValue("@pType", Typ);
                cmd.Parameters.AddWithValue("@pComp", CompNm);
                cmd.Parameters.AddWithValue("@pTech", Tech);
            }

        }
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        da.Fill(ds, "tbl_machine_master");
        if (ds.Tables["tbl_machine_master"].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables["tbl_machine_master"];
            GridView1.DataBind();
            ds.Dispose();
        }
        else
        {
            Response.Write("<script>alert('Hearing Aid is Not Selected Because of stock is not purched or not Available') </script>");
        }
        cn.Close();
        #endregion 
    }
    protected void btnPtn_Search_Click(object sender, EventArgs e)
    {
        //#region Search
        //try
        //{           
        //    ddl_ptnt_nm.Visible = true;
        //    string nm = txtPtnt_nm.Text.ToUpper();
        //    ddl_ptnt_nm.Items.Clear();
        //    cmd = new SqlCommand("sp_ptnt_hearing_search", connection.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@p_ptnt_nm", nm);            
        //    cn.Open();
        //    cn.executeprocedure(cmd);
        //    DataTable DT1 = new DataTable();
        //    cn.Open();
        //    dr = cmd.ExecuteReader();
        //    DT1.Load(dr);
        //    DT1.Columns.Add("ptntnm", typeof(string), "ptnt_id+','+ptnt_nm");
        //    ddl_ptnt_nm.DataSource = DT1;
        //    ddl_ptnt_nm.DataValueField = "ptnt_id";
        //    ddl_ptnt_nm.DataTextField = "ptntnm";
        //    ddl_ptnt_nm.DataBind();
        //    ddl_ptnt_nm.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
        //    ddl_ptnt_nm.SelectedIndex = 0;
        //    dr = null;
        //    cn.Close();        
        //}
        //catch
        //{
        //    Response.Write("<script>alert('Patient Not Search') </script>");
        //    //Response.Redirect("~/error.aspx");
        //}
        //#endregion
    }
    protected void ddlComp_SelectedIndexChanged(object sender, EventArgs e)
    {
     //   txtComp.Text = ddlComp.SelectedItem.Text;
    }
    protected void btnSelCom_Click(object sender, EventArgs e)
    {
       // ddlComp.Visible = true;
    }
    protected void btnAllComp_Click(object sender, EventArgs e)
    {
        //txtComp.Text = "";
        //ddlComp.Visible = false;
    }
    protected void ddlFrom_Price_SelectedIndexChanged(object sender, EventArgs e)
    {

    }   
}
