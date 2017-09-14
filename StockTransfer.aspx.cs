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

public partial class StockTransfer : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd, cmd1;
    SqlDataReader dr, dr1;
    DataSet ds, ds1;
    SqlDataAdapter da;
    double id;
    int Tot;
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
        #region ACCESSORIES Loading
        cn.Open();
        ddlacc_desc.Items.Clear();
        cmd = connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "sp_Acc_Nm_ddl";
        DataTable DT_ac = new DataTable();

        dr = cmd.ExecuteReader();
        DT_ac.Load(dr);

        ddlacc_desc.DataSource = DT_ac;
        ddlacc_desc.DataValueField = "h_ac_id";

        ddlacc_desc.DataTextField = "h_ac_name";
        ddlacc_desc.DataBind();
        ddlacc_desc.Items.Insert(0, new ListItem("Select", "h_ac_name"));
        ddlacc_desc.SelectedIndex = 0;
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
       // string Doc_Type = "SA";
        DateTime Doc_Date = Convert.ToDateTime(txtDoc_Date.Text);
        int Pid = 0;
        int acc_sale_id = 0;
        string ptnt_nm = "Stock Transer";
        string acc = ddlacc_desc.SelectedItem.Text.ToString();
        double price = System.Convert.ToDouble(txtPrice.Text);
        int qty = System.Convert.ToInt32(txtQty.Text);
        int amt = System.Convert.ToInt32(txtrecamt.Text);
        int cr_by = Convert.ToInt32(Session["Name"].ToString());
        int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
        int TRCntr_id = Convert.ToInt32(ddlCent_Nm.SelectedValue);
        int Q = Convert.ToInt32(lblQty.Text);
        string Flag = "I";
        if (Q > 0)
        {
            if (Q >= qty)
            {
                cn.Open();
                cmd = new SqlCommand("tbl_acc_sale_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pacc_sale_id", acc_sale_id);
                cmd.Parameters.AddWithValue("@pDoc_Type", "TR");
                cmd.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                cmd.Parameters.AddWithValue("@pptnt_id", Pid);
                cmd.Parameters.AddWithValue("@pptnt_nm", ptnt_nm);
                cmd.Parameters.AddWithValue("@pacc_desc", acc);
                cmd.Parameters.AddWithValue("@pacc_price", price);
                cmd.Parameters.AddWithValue("@pacc_qty", qty);
                cmd.Parameters.AddWithValue("@pacc_amt_rec", amt);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cmd.Parameters.AddWithValue("@pTRCntr_id", TRCntr_id);
                int a = cn.executeprocedure(cmd);
                cn.Close();

                cn.Open();
                cmd1 = new SqlCommand("tbl_acc_sale_c", connection.con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@pFlag", Flag);
                cmd1.Parameters.AddWithValue("@pacc_sale_id", acc_sale_id);
                cmd1.Parameters.AddWithValue("@pDoc_Type", "PA");
                cmd1.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                cmd1.Parameters.AddWithValue("@pptnt_id", Pid);
                cmd1.Parameters.AddWithValue("@pptnt_nm", ptnt_nm);
                cmd1.Parameters.AddWithValue("@pacc_desc", acc);
                cmd1.Parameters.AddWithValue("@pacc_price", price);
                cmd1.Parameters.AddWithValue("@pacc_qty", qty);
                cmd1.Parameters.AddWithValue("@pacc_amt_rec", amt);
                cmd1.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd1.Parameters.AddWithValue("@pCntr_id", TRCntr_id);
                cmd1.Parameters.AddWithValue("@pTRCntr_id", Cntr_id);
                int b = cn.executeprocedure(cmd1);

                cn.Close();
                btn_save.Enabled = false;
                Response.Redirect("StockTransfer.aspx");
            }
            else
            {
                Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void ddlacc_desc_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if(Doc_Type="PA")
        //{
        //}
        //else
        //{
        if (ddlacc_desc.SelectedIndex > 0)
        {
            #region Acc Price
            try
            {
                string[] arrrSelVal = ddlacc_desc.SelectedValue.Split(',');
                double pid = System.Convert.ToInt32(arrrSelVal[0]);
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());

                //cmd = new SqlCommand("sp_Acc_Sale_H", connection.con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@p_Dd_id", pid);
                //cmd.Parameters.AddWithValue("@Cntr_id", Cntr_id);
                //cn.Open();
                //cn.executeprocedure(cmd);
                //DataTable DT1 = new DataTable();
                //cn.Open();
                //dr = cmd.ExecuteReader();
                //DT1.Load(dr);
                ////lblsale_id.Value = DT1.Rows[0][0].ToString();
                //txtPrice.Text = DT1.Rows[0][2].ToString();
                //txtPrice.Enabled = false;
                //string Qty = DT1.Rows[0][3].ToString();
                //int Qty1 = Convert.ToInt32(Qty);

                //lblQty.Text = DT1.Rows[0][3].ToString();
                //if (Qty1 > 0)
                //{
                //    btn_save.Enabled = true;
                //}
                //else
                //{
                //    Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
                //    btn_save.Enabled = false;
                //}
                cmd = new SqlCommand("Stok_ac_mast_g", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ph_ac_id", pid);
                cmd.Parameters.AddWithValue("@Cntr_id", Cntr_id);
                cn.Open();
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                //lblsale_id.Value = DT1.Rows[0][0].ToString();
                txtPrice.Text = DT1.Rows[0][3].ToString();
                txtPrice.Enabled = false;
                string Qty = DT1.Rows[0][6].ToString();
                int Qty1 = Convert.ToInt32(Qty);

                lblQty.Text = DT1.Rows[0][6].ToString();
                if (Qty1 > 0)
                {
                    btn_save.Enabled = true;
                }
                else
                {
                    Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
                    btn_save.Enabled = false;
                }
                dr = null;
                cn.Close();
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Please Add Purchase Entry')</script>");
            }
            #endregion
        }
        //}
    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtQty.Text) > (Convert.ToInt32(lblQty.Text)))
        {
            lblMsg.Visible = true;
            btn_save.Enabled = false;
            Tot=Convert.ToInt32(txtQty.Text)*Convert.ToInt32(txtPrice.Text);
            txtrecamt.Text = Tot.ToString();
        }
        else
        {
            lblMsg.Visible = false;
            btn_save.Enabled = true;
            Tot = Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtPrice.Text);
            txtrecamt.Text = Tot.ToString();
        }
    }
}
