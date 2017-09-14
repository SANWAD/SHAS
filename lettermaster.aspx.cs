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

public partial class transaction_lettermaster : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    double id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            cn = new connection();
            txtlet_type.Focus();
        //    id = cn.getmaxid("select max(let_id) from tbl_let_master", "tbl_let_master");
        //    if (id == 0) { lbllet_id.Text = Convert.ToString(id + 1); }
        //    else { lbllet_id.Text = Convert.ToString(id+1); }
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        #region Save
        try
        {
            int let_id = 0;
            string let_type = txtlet_type.Text.ToString();
            string desc = txtletdesc.Text.ToString();
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_let_master_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@plet_id", let_id);
            cmd.Parameters.AddWithValue("@plet_type", let_type);
            cmd.Parameters.AddWithValue("@plet_content", desc);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cn.executeprocedure(cmd);
            cn.Close();

            lbllet_id.Value  = "";
            txtlet_type.Text="";
            txtletdesc.Text="";
        }
        catch
        {
            //Response.Redirect("~/error.aspx");
        }
        #endregion
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("");
    }
}
