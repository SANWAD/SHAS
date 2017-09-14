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

public partial class HAStockTransfer : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd, cmd1;
    SqlDataReader dr, dr1;
    DataSet ds, ds1;
    SqlDataAdapter da;
    double id; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            DateTime dt = DateTime.Now;
            txtDoc_Date.Text = dt.ToShortDateString();
            cn = new connection();
            if (!IsPostBack)
            {               
                LoadPage();
            }
        }
    }
    public void LoadPage()
    {
        #region Hearing Aid & Center Loading
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

        ddlCent_Nm.Items.Clear();
        cmd = connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "sp_Center_nm";
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "tbl_Center_master");

        DataTable DT2 = new DataTable();
        dr1 = cmd.ExecuteReader();
        DT2.Load(dr1);
        ddlCent_Nm.DataSource = DT2;
        ddlCent_Nm.DataValueField = "Cntr_id";
        ddlCent_Nm.DataTextField = "Cntr_Nm";
        ddlCent_Nm.DataBind();
        ddlCent_Nm.Items.Insert(0, new ListItem("Select", "Cntr_Nm"));
        dr1 = null;       
        cn.Close();
        #endregion
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
         //string Doc_Type = Session["Doc_Type"].ToString();
        #region Save
        try
        {
            if ((lbl_mach_id_rt.Value  == ""))
            {
                Response.Write("<script>alert('Please Insert Right Ear Heaaring Aid Sr No')</script>)");
            }
            else
            {
                int def = 0;
                int hm_mach_id_rt;
                int hm_mach_id_lt;
                int ptnt_id;
                string ptnt_nm;
                if (lbl_mach_id_rt.Value == "")
                { hm_mach_id_rt = def; }
                else
                { hm_mach_id_rt = Convert.ToInt32(lbl_mach_id_rt.Value ); }
                hm_mach_id_lt = def; 
                DateTime hm_Warr_dt = DateTime.Now;
                if (txtDoc_Date.Text == "")
                {
                    Response.Write("<script language='JavaScript'>alert('Insert Warranty Date')</script>");
                }
                else
                {
                    hm_Warr_dt = Convert.ToDateTime(txtDoc_Date.Text);
                }
                int hmsale_id = 0;
                string comm ="Hearing Aid Transfer";
                ptnt_id = 0;    
                ptnt_nm ="";
                DateTime Doc_Date = System.Convert.ToDateTime(txtDoc_Date.Text);
                string hm_sale_ear_site ="";
                int hm_sale_aud_rat =0;
                string hm_nm_rt = txt_mach.Text.ToString();
                string hm_nm_lt ="";
                int hm_sale_ear_mould_to =0;
                string hm_sale_mach_srno ="";
                string hm_sale_mach_srno_lt ="";
                double hm_sale_mach_price_rt = Convert.ToDouble(txtmachprice.Text);
                int paid_chg = Convert.ToInt32(txtrecamt.Text);
                int dueamt = 0;
                double DisC =0;
                double Vat =0;
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                int TRCntr_id = Convert.ToInt32(ddlCent_Nm.SelectedValue);
                int Qty = Convert.ToInt32(txtQty.Text);
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_hm_sale_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@phm_sale_id", hmsale_id);
                cmd.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                cmd.Parameters.AddWithValue("@pDoc_Type", "TR");
                cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                cmd.Parameters.AddWithValue("@phm_sale_ear_site", hm_sale_ear_site);
                cmd.Parameters.AddWithValue("@phm_sale_aud_rat", hm_sale_aud_rat);
                cmd.Parameters.AddWithValue("@phm_mach_id_rt", hm_mach_id_rt);
                cmd.Parameters.AddWithValue("@phm_nm_rt", hm_nm_rt);
                cmd.Parameters.AddWithValue("@phm_mach_id_lt", hm_mach_id_lt);
                cmd.Parameters.AddWithValue("@phm_nm_lt", hm_nm_lt);
                cmd.Parameters.AddWithValue("@phm_sale_ear_mould_to", hm_sale_ear_mould_to);
                cmd.Parameters.AddWithValue("@phm_sale_mach_srno_rt", hm_sale_mach_srno);
                cmd.Parameters.AddWithValue("@phm_sale_mach_srno_lt", hm_sale_mach_srno_lt);
                cmd.Parameters.AddWithValue("@phm_sale_mach_price_rt", hm_sale_mach_price_rt);
                cmd.Parameters.AddWithValue("@pwarr_Period", hm_Warr_dt);
                cmd.Parameters.AddWithValue("@pDisc_Amt", DisC);
                cmd.Parameters.AddWithValue("@pVat_amt", Vat);
                cmd.Parameters.AddWithValue("@pDocCom",0);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cmd.Parameters.AddWithValue("@pQty", Qty);
                cmd.Parameters.AddWithValue("@pTRCntr_id", TRCntr_id);
                int a=cn.executeprocedure(cmd);
                cn.Close();

                cn.Open();
                cmd1 = new SqlCommand("tbl_hm_sale_trn_c", connection.con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@pFlag", Flag);
                cmd1.Parameters.AddWithValue("@phm_sale_id", hmsale_id);
                cmd1.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                cmd1.Parameters.AddWithValue("@pDoc_Type", "PA");
                cmd1.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                cmd1.Parameters.AddWithValue("@phm_sale_ear_site", hm_sale_ear_site);
                cmd1.Parameters.AddWithValue("@phm_sale_aud_rat", hm_sale_aud_rat);
                cmd1.Parameters.AddWithValue("@phm_mach_id_rt", hm_mach_id_rt);
                cmd1.Parameters.AddWithValue("@phm_nm_rt", hm_nm_rt);
                cmd1.Parameters.AddWithValue("@phm_mach_id_lt", hm_mach_id_lt);
                cmd1.Parameters.AddWithValue("@phm_nm_lt", hm_nm_lt);
                cmd1.Parameters.AddWithValue("@phm_sale_ear_mould_to", hm_sale_ear_mould_to);
                cmd1.Parameters.AddWithValue("@phm_sale_mach_srno_rt", hm_sale_mach_srno);
                cmd1.Parameters.AddWithValue("@phm_sale_mach_srno_lt", hm_sale_mach_srno_lt);
                cmd1.Parameters.AddWithValue("@phm_sale_mach_price_rt", hm_sale_mach_price_rt);
                cmd1.Parameters.AddWithValue("@pwarr_Period", hm_Warr_dt);
                cmd1.Parameters.AddWithValue("@pDisc_Amt", DisC);
                cmd1.Parameters.AddWithValue("@pVat_amt", Vat);
                cmd1.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd1.Parameters.AddWithValue("@pCntr_id", TRCntr_id);
                cmd1.Parameters.AddWithValue("@pQty", Qty);
                cmd1.Parameters.AddWithValue("@pTRCntr_id", Cntr_id);
                int b = cn.executeprocedure(cmd1);
                cn.Close();
                btn_save.Enabled = false;
                Response.Redirect("HAStockTransfer.aspx");
            }
        }
        catch
        {
            //Response.Redirect("~/error.aspx");
        }
        #endregion
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
                // string Mach_Desc = ddl_comp.SelectedItem.Text;
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
                ddl_mach_model.Enabled = true;
                //ddl_mach_model.Focus();
            }
            catch {/* Response.Redirect("~/error.aspx");*/ }
            #endregion
        }
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
                //string Mach_Desc = ddl_comp.SelectedItem.Text;
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
                ddl_mach_type.Enabled = true;
                //ddl_mach_type.Focus();
            }
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
        }
    }
    protected void ddl_mach_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type.SelectedIndex > 0)
        {
            #region Machine Final
            //txt_mach.Visible = true;
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
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                lbl_mach_id_rt.Value = machid;
                lblSale_price.Value = ds.Tables["tbl_machine_master"].Rows[0][1].ToString();
                lblQty.Text = ds.Tables["tbl_machine_master"].Rows[0][2].ToString();
                int Qty = Convert.ToInt32(lblQty.Text);
                if (Qty > 0)
                {
                    Stock();
                    MachVal();
                    txt_mach.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_mach_type.SelectedItem.Text));
                }
                else
                {
                }

            }

            #endregion
        }
    }
    public void MachVal()
    {
        #region MachVal
        try
        {
            if (lblSale_price.Value == "")
            {
                txtmachprice.Text = "0";
                Response.Write("<script>alert('Select Valid Machine')</script>");
            }
            else if (lblSale_price.Value != "")
            {
                txtmachprice.Text = (Convert.ToDouble(lblSale_price.Value)).ToString();
            }
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
        finally
        {

        }
        #endregion
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
        Response.Redirect("HAStockTransfer.aspx");
    }   
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        if(Convert.ToInt32(txtQty.Text)>(Convert.ToInt32(lblQty.Text)))
        {
            lblMsg.Visible = true;
            btn_save.Enabled = false;
        }
        else
        {
            lblMsg.Visible =false;
            btn_save.Enabled = true;
        }
    }
    public void Stock()
    {
        #region Machine Stock
        int Mach_id = Convert.ToInt32(lbl_mach_id_rt.Value);
        int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
        string Mach_Model = ddl_mach_model.SelectedItem.Text;
        cmd = new SqlCommand("Stok_H_Aid_g", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@pMach_id", Mach_id);
        cmd.Parameters.AddWithValue("@Cntr_id", Cntr_id);
        cn.executeprocedure(cmd);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "tbl_machine_master");
        if (ds.Tables["tbl_machine_master"].Rows.Count > 0)
        {
            string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
            lbl_mach_id_rt.Value = machid;
            lblSale_price.Value = ds.Tables["tbl_machine_master"].Rows[0][5].ToString();
            lblQty.Text = ds.Tables["tbl_machine_master"].Rows[0][7].ToString();
            int Qty = Convert.ToInt32(lblQty.Text);
            btn_save.Enabled = true;
        }

        #endregion
    }
}
