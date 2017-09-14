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
                #region machine Company
                cn.Open();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_Mach_Desc_ddl";
                DataTable DT_comp = new DataTable();
                dr = cmd.ExecuteReader();
                DT_comp.Load(dr);
                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp.SelectedIndex = 0;
                dr = null;
                cn.Close();
                #endregion
                Clear();
                //Select();
            }
        }
    }
    public void Select()
    {
        if (Request.QueryString["Ord_id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Ord_id"].ToString());
                double h_t_id = System.Convert.ToInt32(id1);
                cn.Open();
                cmd = new SqlCommand("tbl_ord_nhm_trn_Id", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pord_id", h_t_id);
                //cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);

                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblOrd_no.Value = DT1.Rows[0][0].ToString();                
                txtOrder_desc.Text = DT1.Rows[0][1].ToString();
                txtOrder_from.Text = DT1.Rows[0][2].ToString();
                ddl_comp.SelectedItem.Text= DT1.Rows[0][3].ToString();
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
        lblOrd_no.Value = "";
        ddl_comp.SelectedIndex=0;
        txtOrder_from.Text = "";
        txtOrder_desc.Text = "";
        txtOrder_desc.Focus();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (btnsave.Text == "Edit")
        {
            #region Save
            try
            {
                int out_no = Convert.ToInt32(lblOrd_no.Value);
                string out_to = ddl_comp.SelectedItem.Text;
                string out_from = txtOrder_from.Text.ToString();
                string out_desc = txtOrder_desc.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_ord_nhm_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pord_no", out_no);
                cmd.Parameters.AddWithValue("@porder_To", out_to);
                cmd.Parameters.AddWithValue("@porder_by", out_from);
                cmd.Parameters.AddWithValue("@pordItem_Desc", out_desc);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("OrderForm_Grid.aspx");
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
                string out_to = ddl_comp.SelectedItem.Text;
                string out_from = txtOrder_from.Text.ToString();
                string out_desc = txtOrder_desc.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_ord_nhm_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pord_no", out_no);
                cmd.Parameters.AddWithValue("@porder_To", out_to);
                cmd.Parameters.AddWithValue("@porder_by", out_from);
                cmd.Parameters.AddWithValue("@pordItem_Desc", out_desc);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("OrderForm_Grid.aspx");
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
        Response.Redirect("~/OrderForm_Grid.aspx");
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

    }
}
