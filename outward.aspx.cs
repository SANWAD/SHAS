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
public partial class outward : System.Web.UI.Page
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
        if (Request.QueryString["Out_id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Out_id"].ToString());
                double h_t_id = System.Convert.ToInt32(id1);
                cn.Open();
                cmd = new SqlCommand("Outward_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pOut_id", h_t_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);

                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblout_no.Value = DT1.Rows[0][0].ToString();
                txtout_to.Text = DT1.Rows[0][1].ToString();
                txt_out_desc.Text = DT1.Rows[0][3].ToString();
                txtout_from.Text = DT1.Rows[0][2].ToString();
                txtcour_nm.Text = DT1.Rows[0][4].ToString();
                txtchg_paid.Text = DT1.Rows[0][5].ToString();
                txtrec_no.Text = DT1.Rows[0][6].ToString();
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
        lblout_no.Value = "";
        txtout_to.Text = "";
        txtout_from.Text = "";
        txtcour_nm.Text = "";
        txtchg_paid.Text = "";
        txtrec_no.Text = "";
        txt_out_desc.Text = "";
        txt_out_desc.Focus();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (btnsave.Text == "Edit")
        {
            #region Save
            try
            {
                int out_no = Convert.ToInt32(lblout_no.Value);
                string out_to = txtout_to.Text.ToString();
                string out_from = txtout_from.Text.ToString();
                string out_desc = txt_out_desc.Text.ToString();
                string c_nm = txtcour_nm.Text.ToString();
                double chgpaid = Convert.ToDouble(txtchg_paid.Text);
                string rec_no = txtrec_no.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_out_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pout_no", out_no);
                cmd.Parameters.AddWithValue("@pout_to", out_to);
                cmd.Parameters.AddWithValue("@pout_from", out_from);
                cmd.Parameters.AddWithValue("@pout_desc", out_desc);
                cmd.Parameters.AddWithValue("@pcourier_nm", c_nm);
                cmd.Parameters.AddWithValue("@pchg_paid", chgpaid);
                cmd.Parameters.AddWithValue("@prec_no", rec_no);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("outward_Grid.aspx");
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                //btnsave.Enabled = false;
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
            }
            #endregion
        }
        else
        {
            #region Save
            try
            {
                int out_no = 0;
                string out_to = txtout_to.Text.ToString();
                string out_from = txtout_from.Text.ToString();
                string out_desc = txt_out_desc.Text.ToString();
                string c_nm = txtcour_nm.Text.ToString();
                double chgpaid = Convert.ToDouble(txtchg_paid.Text);
                string rec_no = txtrec_no.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_out_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pout_no", out_no);
                cmd.Parameters.AddWithValue("@pout_to", out_to);
                cmd.Parameters.AddWithValue("@pout_from", out_from);
                cmd.Parameters.AddWithValue("@pout_desc", out_desc);
                cmd.Parameters.AddWithValue("@pcourier_nm", c_nm);
                cmd.Parameters.AddWithValue("@pchg_paid", chgpaid);
                cmd.Parameters.AddWithValue("@prec_no", rec_no);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("outward_Grid.aspx");
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                //btnsave.Enabled = false;
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
            }
            #endregion
        }       
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/outward_Grid.aspx");
    }
}
