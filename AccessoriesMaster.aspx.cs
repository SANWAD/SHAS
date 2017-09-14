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

public partial class AccessoriesMaster : System.Web.UI.Page
{
    SqlCommand cmd,cmd1,cmd2;
    connection cn;
    SqlDataReader dr;
    SqlDataAdapter da;
    DataSet ds;
    public DateTime Doc_Date;
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
            txt_ac_desc.Focus();
            Select();
        }
        
        //Button3.Visible = true;
        }
    }
    public void Select()
    {
        #region Loading
        if (Request.QueryString["Acc_Id"].ToString() != "0")
        {
            try
            {
                Clear();
                #region Select
                try
                {
                    string id1;
                    id1 = (Request.QueryString["Acc_Id"].ToString());
                    double h_ac_id = System.Convert.ToInt32(id1);
                    cn.Open();
                    cmd = new SqlCommand("tbl_h_acc_mast", connection.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ph_ac_id", h_ac_id);
                    cn.executeprocedure(cmd);
                    DataTable DT1 = new DataTable();
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    DT1.Load(dr);
                    lbl_ac_id.Value = DT1.Rows[0][0].ToString();
                    txt_ac_desc.Text = DT1.Rows[0][1].ToString();
                    txtPrice.Text = DT1.Rows[0][3].ToString();
                    lblQty.Text = DT1.Rows[0][4].ToString();
                    txtSale.Text = DT1.Rows[0][9].ToString();
                    dr = null;
                    cn.Close();
                    btn_save.Text = "Edit";
                }
                catch
                {
                    Response.Write("<script language='JavaScript'>alert('')</script>");
                }
                #endregion
            }
            catch
            {
            }
        }
        #endregion
    }
    public void Clear()
    {
        lbl_ac_id.Value  = "";
        txtPrice.Text = "0";
        txtQty.Text = "0";
        txt_ac_desc.Text = "";
        lblQty.Text = "";
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if(btn_save.Text=="Edit")
        {
            #region Edit
            try
            {
                int h_ac_id = Convert.ToInt32(lbl_ac_id.Value);                
                string desc = txt_ac_desc.Text.ToUpper();
                int price = System.Convert.ToInt32(txtPrice.Text);
                int SalePrice = System.Convert.ToInt32(txtSale.Text);
                int Qty;
                if (txtQty.Text == "")
                {
                    Qty = 0;
                }
                else
                {
                    Qty = System.Convert.ToInt32(txtQty.Text);
                }                
                int cr_by =Convert.ToInt32(Session["Name"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_h_ac_master_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@ph_ac_id", h_ac_id);
                cmd.Parameters.AddWithValue("@ph_ac_name", desc);
                cmd.Parameters.AddWithValue("@ph_ac_price", price);
                cmd.Parameters.AddWithValue("@ph_ac_SaleP", SalePrice);
                cmd.Parameters.AddWithValue("@ph_qty", Qty);
                cmd.Parameters.AddWithValue("@ph_ac_qty", Qty);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Write("<script language='JavaScript'>alert('Record is Update')</script>");
                Response.Redirect("AccMast_Grid.aspx");
                btn_save.Enabled = false;
                btnCancel.Text = "Exit";
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is not save')</script>");
            }
            #endregion
        }
        else
        {
            #region Save
            try
            {
               
                int h_ac_id = 0;                
                string desc = txt_ac_desc.Text.ToUpper();
                int price = System.Convert.ToInt32(txtPrice.Text);
                int SalePrice = System.Convert.ToInt32(txtSale.Text);
                int Qty;
                if (txtQty.Text == "")
                {
                    Qty = 0;
                }
                else
                {
                    Qty = System.Convert.ToInt32(txtQty.Text);
                }
                int cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_h_ac_master_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@ph_ac_id", h_ac_id);
                cmd.Parameters.AddWithValue("@ph_ac_name", desc);
                cmd.Parameters.AddWithValue("@ph_ac_price", price);
                cmd.Parameters.AddWithValue("@ph_ac_SaleP", SalePrice);
                cmd.Parameters.AddWithValue("@ph_qty", Qty);
                cmd.Parameters.AddWithValue("@ph_ac_qty", Qty);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                //cmd.Parameters.AddWithValue("@pCntr_id", cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();


                #region Quantity Insert
                int acc_sale_id = 0;
                string Doc_Type = "PA";
                DateTime dt = Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString());
                Doc_Date = DateTime.Now;
                //Doc_Date = DateTime.ParseExact(dt.ToShortDateString(), "dd/MM/yyyy", null);
                int Pid =Convert.ToInt32(0);
                string RegChk;
                string ptnt_nm="PURCHASE";
                RegChk = "R";

                 string acc = txt_ac_desc.Text;
                int qty = System.Convert.ToInt32(txtQty.Text);
                int amt = System.Convert.ToInt32(0);
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                int Q = Convert.ToInt32(txtQty.Text);
                if (Q > 0)
                {
                    if (Q >= qty)
                    {
                        cn.Open();
                        cmd1 = new SqlCommand("tbl_acc_sale_c", connection.con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@pFlag", Flag);
                        cmd1.Parameters.AddWithValue("@pacc_sale_id", acc_sale_id);
                        cmd1.Parameters.AddWithValue("@pDoc_Type", Doc_Type);
                        cmd1.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                        cmd1.Parameters.AddWithValue("@pptnt_id", Pid);
                        cmd1.Parameters.AddWithValue("@pptnt_nm", ptnt_nm);
                        cmd1.Parameters.AddWithValue("@pacc_desc", acc);
                        cmd1.Parameters.AddWithValue("@pacc_price", price);
                        cmd1.Parameters.AddWithValue("@pacc_qty", qty);
                        cmd1.Parameters.AddWithValue("@pacc_amt_rec", amt);
                        cmd1.Parameters.AddWithValue("@pcreated_by", cr_by);
                        cmd1.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                        int a = cn.executeprocedure(cmd1);
                        cn.Close();
                    }
                }

                string Doc_Type1 = "SA";
                string ptnt_nm1 = "SALE";
                RegChk = "R";
                int qty1 = System.Convert.ToInt32(0);
                cn.Open();
                cmd2 = new SqlCommand("tbl_acc_sale_c", connection.con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@pFlag", Flag);
                cmd2.Parameters.AddWithValue("@pacc_sale_id", acc_sale_id);
                cmd2.Parameters.AddWithValue("@pDoc_Type", Doc_Type1);
                cmd2.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                cmd2.Parameters.AddWithValue("@pptnt_id", Pid);
                cmd2.Parameters.AddWithValue("@pptnt_nm", ptnt_nm1);
                cmd2.Parameters.AddWithValue("@pacc_desc", acc);
                cmd2.Parameters.AddWithValue("@pacc_price", SalePrice);
                cmd2.Parameters.AddWithValue("@pacc_qty", qty1);
                cmd2.Parameters.AddWithValue("@pacc_amt_rec", amt);
                cmd2.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd2.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                int a1 = cn.executeprocedure(cmd2);
                cn.Close();



                #endregion
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                btn_save.Enabled = false;
                Response.Redirect("AccMast_Grid.aspx"); 
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is not save')</script>");
            }
            #endregion
        }       
    }  
    protected void Button2_Click(object sender, EventArgs e)
    {
        txt_ac_desc.Text = "";
        txtPrice.Text = "";
        Response.Redirect("hearing_acc.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("hearing_acc.aspx");
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        #region Search
        //try
        //{
        //    btn_save.Visible = false;
        //    ddl_h_ac_des.Visible = true;
        //    string nm = txt_ac_desc.Text.ToUpper();
        //    ddl_h_ac_des.Items.Clear();
        //    cmd = new SqlCommand("sp_h_ac_search", connection.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@p_h_ac_name", nm);
        //    cn.Open();
        //    cn.executeprocedure(cmd);
        //    cn.Close();
        //    DataTable DT1 = new DataTable();
        //    cn.Open();
        //    dr = cmd.ExecuteReader();
        //    DT1.Load(dr);
        //    DT1.Columns.Add("ptntnm", typeof(string), "h_ac_id+','+h_ac_name");
        //    ddl_h_ac_des.DataSource = DT1;
        //    ddl_h_ac_des.DataValueField = "h_ac_id";
        //    ddl_h_ac_des.DataTextField = "ptntnm";
        //    ddl_h_ac_des.DataBind();
        //    ddl_h_ac_des.Items.Insert(0, new ListItem("Select", "h_ac_name"));
        //    ddl_h_ac_des.SelectedIndex = 0;
        //    dr = null;
        //    cn.Close();
        //    EDIT.Visible = true;
        //}

        //catch
        //{
        //    Response.Write("<script language='JavaScript'>alert('Accesories Not Match')</script>");
        //    // Response.Redirect("~/error.aspx");
        //}
        #endregion
    }
    protected void ddl_h_ac_des_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Select Accessories
        //try
        //{
        //    lbl_ac_id.Text = "";
        //    txt_ac_desc.Text = "";
        //    txtPrice.Text = "";
        //    lblQty.Text = "";

        //    if (ddl_h_ac_des.SelectedIndex > 0)
        //    {
        //        string[] arrrSelVal = ddl_h_ac_des.SelectedValue.Split(',');
        //        double Hid = System.Convert.ToInt32(arrrSelVal[0]);

        //        cmd = new SqlCommand("sp_h_ac_search1", connection.con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@p_h_ac_id", Hid);
        //        cn.Open();
        //        cn.executeprocedure(cmd);
        //        DataTable DT1 = new DataTable();
        //        cn.Open();
        //        dr = cmd.ExecuteReader();
        //        DT1.Load(dr);
        //        lbl_ac_id.Text = DT1.Rows[0][1].ToString();
        //        txt_ac_desc.Text = DT1.Rows[0][2].ToString();
        //        txtPrice.Text = DT1.Rows[0][3].ToString();
        //        lblQty.Text = DT1.Rows[0][5].ToString();

        //        dr = null;
        //        cn.Close();
        //    }

        //}
        //catch
        //{
        //    Response.Write("<script language='JavaScript'>alert('Accesories Not Match')</script>");
        //    // Response.Redirect("~/error.aspx");
        //}
        #endregion
    }
    protected void btnSer1_Click(object sender, EventArgs e)
    {
        #region Search
        //btn_BackUp.Visible = false;
        //Button3.Visible = false;
       // EDIT.Visible = true;
        //Button1.Visible = false;
        //try
        //{
        //    string Desc = txt_ac_desc.Text.ToUpper();
        //    cmd = new SqlCommand("sp_h_ac_search", connection.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@p_h_ac_name", Desc);
        //    cn.Open();
        //    cn.executeprocedure(cmd);
        //    cn.Close();
        //    DataTable DT1 = new DataTable();
        //    cn.Open();
        //    dr = cmd.ExecuteReader();
        //    DT1.Load(dr);
        //    lbl_ac_id.Text = DT1.Rows[0][1].ToString();
        //    txt_ac_desc.Text = DT1.Rows[0][2].ToString();
        //    txtPrice.Text = DT1.Rows[0][3].ToString();
        //    lblQty.Text = DT1.Rows[0][5].ToString();
        //    dr = null;
        //    cn.Close();
        //}
        //catch
        //{
        //    Response.Write("<script language='JavaScript'>alert('Accesories Not Match')</script>");
        //    //Response.Redirect("~/error.aspx");
        //}
        #endregion
    }
    protected void BtnStock_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Transaction/AccStock.aspx");
    }
    protected void rbtReturn_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (cmbCenter.SelectedIndex == 1)
        //{
        //    cmbCenter.Visible = false;
        //    // Response.Redirect("~/Transaction/Mach_Stock_Transfer.aspx");
        //}
        //else
        //{
        //    cmbCenter.Visible = true;
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AccMast_Grid.aspx");
    }
    protected void txt_ac_desc_TextChanged(object sender, EventArgs e)
    {
        #region Acc Exists
        string Acc_nm = txt_ac_desc.Text.Trim();
        int Center_Id = Convert.ToInt32(Session["Cntr_id"].ToString());

        cmd = new SqlCommand("sp_Acc_Id_Search", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ph_ac_name", Acc_nm);
        cmd.Parameters.AddWithValue("@pCntr_id", Center_Id);
       
        cn.executeprocedure(cmd);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "tbl_h_ac_master");
        if (ds.Tables["tbl_h_ac_master"].Rows.Count > 0)
        {
            lblMsg.Visible = true;
            btn_save.Enabled = false;
            txt_ac_desc.Focus();
        }
        else
        {
            lblMsg.Visible = false;
            btn_save.Enabled = true;
            txtPrice.Focus();
        }
        #endregion
    }
}
