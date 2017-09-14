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

public partial class Clinical_Forms_Report_previous : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    SqlDataAdapter da;
    DataSet ds;
    double pid;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new connection();         
    }
    protected void btn_nm_Click(object sender, EventArgs e)
    {
        //#region Search
        //try
        //{
          
        //    string nm = txtptnt_nm.Text.ToUpper();
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
        //    Response.Redirect("~/error.aspx");
        //}
        //#endregion
    }
    //protected void ddl_ptnt_nm_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    #region Patient Search
    //    if(ddl_ptnt_nm.SelectedIndex==0)
    //    {
    //        Response.Write("<script>alert('Please Select Valid Patient')</script>");
    //    }
    //    else
    //    {
    //    string[] arrrSelVal = ddl_ptnt_nm.SelectedValue.Split(',');
    //    pid = System.Convert.ToInt32(arrrSelVal[0]);


    //    cmd = connection.con.CreateCommand();
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = "select * from tbl_h_as_trn where ptnt_id=" + pid + "";

    //    da = new SqlDataAdapter(cmd);
    //    ds = new DataSet();
    //    da.Fill(ds, "tbl_h_as_trn");

    //    if (ds.Tables["tbl_h_as_trn"].Rows.Count > 0)
    //    {
    //        GridView1.DataSource = ds.Tables["tbl_h_as_trn"];
    //        GridView1.DataBind();
    //        Label1.Text=(ds.Tables["tbl_h_as_trn"].Rows[0][1].ToString());
    //    }
    //    else
    //     {
    //        Response.Write("<script>alert('Please Select Valid Patient')</script>");
    //     }
    //    }
    //    #endregion
    //}
    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    #region selected index
       
    //    int billno =Convert.ToInt32( GridView1.SelectedRow.Cells[1].Text);
    //     Response.Redirect("~/Clinical Forms/h_as.aspx?bill_no=" + billno);

    //    #endregion
    //}    
}
