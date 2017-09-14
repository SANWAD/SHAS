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
using System.Text.RegularExpressions;

public partial class h_m_inward : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    SqlDataAdapter da;
    DataSet ds;
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
                ddl_mach_type.Enabled = false;
                ddl_mach_model.Enabled = false;
                ddl_comp.Enabled = true;
                txt_mach.Enabled = false;
                Select();
          }
        }
                ddlordertype.Focus();
    }
    public void Select()
    {
        if (Request.QueryString["Inward_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Inward_Id"].ToString());
                double h_t_id = System.Convert.ToInt32(id1);
                cn.Open();
                cmd = new SqlCommand("sp_HM_Inward_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ph_t_id", h_t_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);

                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblhm_inw_id.Value = DT1.Rows[0][0].ToString();
                ddlordertype.SelectedValue  = DT1.Rows[0][2].ToString();
                txt_ordno.Text = DT1.Rows[0][1].ToString();
                //txt_mach.Text = DT1.Rows[0][3].ToString();
                txtqty.Text = DT1.Rows[0][4].ToString();
                txtsrno_from.Text = DT1.Rows[0][5].ToString();
                txtsrno_to.Text = DT1.Rows[0][6].ToString();
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
        lblhm_inw_id.Value = "";
        lblmach_id.Value = "";
        txt_ordno.Text = "";
        txtqty.Text = "";
        txtsrno_from.Text = "";
        txtsrno_to.Text = "";
    }
    protected void ddl_mach_model_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_model.SelectedIndex > 0)
        {
            #region Machine Type
            try
            {
                cn.Open();
                ddl_mach_type.Items.Clear();
                int Mach_Desc = Convert.ToInt32(ddl_comp.SelectedValue);
                string Mach_Model = ddl_mach_model.SelectedItem.Text;
                cmd = new SqlCommand("sp_Mach_Type_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
                cn.executeprocedure(cmd);
                DataTable DT_type = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_type.Load(dr);

                ddl_mach_type.DataSource = DT_type;
                ddl_mach_type.DataValueField = "mach_id";
                ddl_mach_type.DataTextField = "mach_type";
                ddl_mach_type.DataBind();
                ddl_mach_type.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_mach_type.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_type.Enabled  = true;
                ddl_mach_type.Focus();
            }
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
        }
    }
    protected void ddl_comp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_comp.SelectedIndex > 0)
        {
            #region Machine Model
            try
            {
                cn.Open();
                ddl_mach_model.Items.Clear();
                //string Mach_Desc = ddl_comp.SelectedItem.Text;
                int Mach_Desc = Convert.ToInt32(ddl_comp.SelectedValue);
                cmd = new SqlCommand("sp_Mach_Model_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cn.executeprocedure(cmd);
                DataTable DT_model = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_model.Load(dr);

                ddl_mach_model.DataSource = DT_model;
                ddl_mach_model.DataValueField = "mach_id";
                ddl_mach_model.DataTextField = "mach_model";
                ddl_mach_model.DataBind();
                ddl_mach_model.Items.Insert(0, new ListItem("Select", "mach_model"));
                ddl_mach_model.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_model.Enabled  = true;
                ddl_mach_model.Focus();
            }
            catch {/* Response.Redirect("~/error.aspx"); */}
            #endregion
        }
    }
    protected void ddl_mach_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type.SelectedIndex > 0)
        {
            #region Machine Final            
            //string Mach_Desc = ddl_comp.SelectedItem.Text;
            int Mach_Desc = Convert.ToInt32(ddl_comp.SelectedValue);
            string Mach_Model = ddl_mach_model.SelectedItem.Text;
            string Mach_Type = ddl_mach_type.SelectedItem.Text;
            cmd = new SqlCommand("sp_Mach_Id_Search", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
            cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
            cmd.Parameters.AddWithValue("@mach_Type", Mach_Type);
            cn.executeprocedure(cmd);           
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();         
            da.Fill(ds, "tbl_machine_master");
             if (ds.Tables["tbl_machine_master"].Rows.Count > 0)
             {
                 txt_mach.Visible = true;
                 txt_mach.Text = (System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_mach_type.SelectedItem.Text));
                 string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                 lblmach_id.Value = machid;
             }
            #endregion
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if(btnsave.Text=="Edit")
        {
            #region Save
            try
            {
                int hm_inw_id = 0;
                int ord_no = Convert.ToInt32(txt_ordno.Text);
                string inw_type = ddlordertype.SelectedItem.Text.ToString();
                int mach_id = Convert.ToInt32(lblmach_id.Value);
                int qty = System.Convert.ToInt32(txtqty.Text);
                string sr_no_from = txtsrno_from.Text.ToString();
                string sr_no_to = txtsrno_to.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_hm_inward_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@phm_inw_id", hm_inw_id);
                cmd.Parameters.AddWithValue("@pord_no", ord_no);
                cmd.Parameters.AddWithValue("@phm_inw_type", inw_type);
                cmd.Parameters.AddWithValue("@pmach_id", mach_id);
                cmd.Parameters.AddWithValue("@phm_qty", qty);
                cmd.Parameters.AddWithValue("@phm_srno_from", sr_no_from);
                cmd.Parameters.AddWithValue("@phm_srno_to", sr_no_to);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                btnsave.Enabled = false;
                Response.Redirect("h_m_inward_Grid.aspx");
            }
            catch
            {
                //Response.Redirect("~/error.aspx");
            }
            #endregion
        }
        else
        {
          #region Save
        try
        {
            int hm_inw_id = 0;
            int ord_no = Convert.ToInt32(txt_ordno.Text);
            string inw_type = ddlordertype.SelectedItem.Text.ToString();
            int mach_id = Convert.ToInt32(lblmach_id.Value);
            int qty = System.Convert.ToInt32(txtqty.Text);           
            string sr_no_from = txtsrno_from.Text.ToString();
            string sr_no_to = txtsrno_to.Text.ToString();
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_hm_inward_trn_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@phm_inw_id",hm_inw_id);
            cmd.Parameters.AddWithValue("@pord_no", ord_no);
            cmd.Parameters.AddWithValue("@phm_inw_type", inw_type);
            cmd.Parameters.AddWithValue("@pmach_id", mach_id);
            cmd.Parameters.AddWithValue("@phm_qty", qty);
            cmd.Parameters.AddWithValue("@phm_srno_from", sr_no_from);
            cmd.Parameters.AddWithValue("@phm_srno_to", sr_no_to);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            cn.executeprocedure(cmd);
            cn.Close();
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");            
            btnsave.Enabled = false;
            Response.Redirect("h_m_inward_Grid.aspx");
        }
        catch
        {
            //Response.Redirect("~/error.aspx");
        }
        #endregion
      }
       
    }
    protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlordertype.SelectedIndex == 1)
        {
            ddl_comp.Enabled = true;
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
        }
    }

    public string RemoveAllWhitespace(string str)
    {
        try
        {
            Regex reg = new Regex(@"\s*");
            str = reg.Replace(str, "");
            return str;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/h_m_inward_Grid.aspx");
    }
}
