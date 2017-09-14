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

public partial class inward : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
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
            if (!IsPostBack)
            {                
                Clear();
                Select();
            }
        }
    }
    public void Select()
    {
        if (Request.QueryString["ind_id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["ind_id"].ToString());
                double h_t_id = System.Convert.ToInt32(id1);
                cn.Open();
                cmd = new SqlCommand("Inward_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pInd_id", h_t_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);

                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblinw_no.Value = DT1.Rows[0][0].ToString();
                txtinwto.Text  = DT1.Rows[0][1].ToString();
                txtinwfrom.Text=DT1.Rows[0][2].ToString();
                dr = null;
                cn.Close();
                btnsave.Text = "Edit";
            }
            catch
            { }
            #endregion
        }
    }
    public void Clear()
    {
        lblinw_no.Value = "";
        txtinwfrom.Text = "";
        txtinwto.Text = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        #region Save
        if(btnsave.Text=="Edit")
        {
            try
            {
                int inw_no = Convert.ToInt32(lblinw_no.Value);
                string inw_to = txtinwto.Text.ToUpper();
                string inw_from = txtinwfrom.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_inward_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pinw_no", inw_no);
                cmd.Parameters.AddWithValue("@pinw_to", inw_to);
                cmd.Parameters.AddWithValue("@pinw_from", inw_from);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                Response.Redirect("inward_Grid.aspx");
                btnsave.Enabled = false;
                Clear();
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
            }
        }
        else
        {
        try
        {
            int inw_no = 0;
            string inw_to = txtinwto.Text.ToUpper();
            string inw_from = txtinwfrom.Text.ToString();
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_inward_trn_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@pinw_no", inw_no);
            cmd.Parameters.AddWithValue("@pinw_to", inw_to);
            cmd.Parameters.AddWithValue("@pinw_from", inw_from);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            cn.executeprocedure(cmd);
            cn.Close();
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
            Response.Redirect("inward_Grid.aspx");
            btnsave.Enabled = false;
            Clear();
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
        }
        #endregion
        }
    }
    protected void btnCanel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inward_Grid.aspx");
    }
}
