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
using System.Web.Script.Services;

public partial class MachineMaster : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd,cmd1;
    SqlDataReader dr;
    SqlDataAdapter da;
    DataSet ds;
    double id;
    int Cntr_id, cr_by;
    string Flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            cn = new connection();
            WebService MathServiceClass = new WebService();
            if (!IsPostBack)
            {
                lblmach_id1.Enabled = true;
                ddl_comp.Focus();
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
                Select();
            }            
        }
    }
    public void Select()
    {
        if (Request.QueryString["Mach_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Mach_Id"].ToString());
                int mach_id = Convert.ToInt32(id1);
              
                cn.Open();
                cmd = new SqlCommand("tbl_mach_mast_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pmach_id", mach_id); 
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblmach_id.Value  = DT1.Rows[0][0].ToString();
                lblmach_id1.Text = DT1.Rows[0][1].ToString();
                ddl_comp.SelectedValue = DT1.Rows[0][2].ToString();
                //txtmachcomp.Text = DT1.Rows[0][5].ToString();
                txtmodel_no.Text = DT1.Rows[0][3].ToString();
                txtmach_type.Text = DT1.Rows[0][4].ToString();
                txtmachdesc.Text = DT1.Rows[0][5].ToString();
                txtprice.Text = DT1.Rows[0][6].ToString();
                txtSale.Text = DT1.Rows[0][7].ToString();
                lblQty.Text = DT1.Rows[0][8].ToString();
                txtBtrSiz.Text = DT1.Rows[0][12].ToString();
                txtChan.Text = DT1.Rows[0][13].ToString();
                txtGain.Text = DT1.Rows[0][14].ToString();
                txtFit_Ran.Text = DT1.Rows[0][15].ToString();
                string Tec= DT1.Rows[0][16].ToString();
                if (Tec == "A")
                {
                    ddlTech.SelectedIndex = 0;
                }
                else if (Tec == "T")
                {
                    ddlTech.SelectedIndex = 1;
                }
                else if (Tec == "P")
                {
                    ddlTech.SelectedIndex = 2;
                }
                else 
                {
                    ddlTech.SelectedIndex = 3;
                }               
                dr = null;
                cn.Close();
                btnsave.Text = "Edit";
                ddl_comp.Focus();
                lblmach_id1.Enabled = false;
            }
            catch
            { }
            #endregion
        }
    }
    public void Clear()
    {
        //ddl_comp.SelectedValue = 0;
        txtmodel_no.Text = "";
        txtmach_type.Text = "";
        txtmachdesc.Text = "";       
        txtprice.Text = "";
        txtBtrSiz.Text = "";
        txtChan.Text = "";
        txtGain.Text = "";
        txtFit_Ran.Text = "";
        ddl_cur.SelectedIndex = 0;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (btnsave.Text == "Edit")
        {
            #region Edit Machine
            try
            {
                int mach_id = Convert.ToInt32(lblmach_id.Value);
                int Comp_ID = Convert.ToInt32(ddl_comp.SelectedValue);
                string model = txtmodel_no.Text.ToString().ToUpper();
                string type = txtmach_type.Text.ToString().ToUpper();
                string desc = txtmachdesc.Text.ToString();
                //int Qty = 0;
                int Qty;
                if (txtAdd.Text == "")
                {
                    Qty = 0;
                }
                else
                {
                    Qty = System.Convert.ToInt32(txtAdd.Text);
                }
                int Ret_qty = 0;
                double Price = System.Convert.ToDouble(txtprice.Text);
                double Sale_Price;
                string Stock_Trans_City = "K001";
                if (txtSale.Text == "")
                {
                    Sale_Price= 0;
                }
                else 
                {
                    Sale_Price = System.Convert.ToDouble(txtSale.Text);
                }
                string BatSiz = txtBtrSiz.Text.ToString();
                int Chan;
                int Gain;
                if (txtChan.Text == "")
                { Chan = 0; }
                else { Chan = System.Convert.ToInt32(txtChan.Text); }
                if (txtGain.Text == "")
                { Gain = 0; }
                else { Gain = System.Convert.ToInt32(txtGain.Text); }
                string Fit_Ran = txtFit_Ran.Text.ToString();
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
                string curr = ddl_cur.SelectedItem.Text.ToString();
                cr_by = Convert.ToInt32(Session["Name"].ToString());
                Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_machine_master_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pmach_id", mach_id);
                cmd.Parameters.AddWithValue("@pComp_ID", Comp_ID);
                cmd.Parameters.AddWithValue("@pmach_model", model);
                cmd.Parameters.AddWithValue("@pmach_type", type);
                cmd.Parameters.AddWithValue("@pmach_desc", desc);
                cmd.Parameters.AddWithValue("@pmach_qty", Qty);
                cmd.Parameters.AddWithValue("@pmach_purch_price", Price);
                cmd.Parameters.AddWithValue("@pmach_sale_price", Sale_Price);
                cmd.Parameters.AddWithValue("@pmach_minus_qty", Qty);
                cmd.Parameters.AddWithValue("@pStock_Trans_City", Stock_Trans_City);
                cmd.Parameters.AddWithValue("@pmach_cell_size", BatSiz);
                cmd.Parameters.AddWithValue("@pmach_channel", Chan);
                cmd.Parameters.AddWithValue("@pmach_Gain", Gain);
                cmd.Parameters.AddWithValue("@pmach_fitting_Range", Fit_Ran);
                cmd.Parameters.AddWithValue("@pTech", Tech);
                cmd.Parameters.AddWithValue("@pmach_cur", curr);
                cmd.Parameters.AddWithValue("@pReturn_qty", Ret_qty);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                //cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                //cn.executeprocedure(cmd);
                int a = cn.executeprocedure(cmd);
                string  Mach_id = a.ToString();
                cn.Close();
                #region Quantity Insert
                //string Doc_Type = "PA";
                //int def = 0;
                //int hm_mach_id_rt;
                //int hm_mach_id_lt;
                //int ptnt_id;
                //string ptnt_nm;
                //hm_mach_id_rt = Convert.ToInt32(Mach_id);
                //hm_mach_id_lt = def;
                //DateTime hm_Warr_dt = DateTime.Now;
                //int hmsale_id = 0;
                //string comm = "Purchase";
                //string ptnt_nm1 = "PURCHASE";
                //ptnt_id = Convert.ToInt32(0);
                //ptnt_nm = "PURCHASE";
                //DateTime Doc_Date = DateTime.Now;
                //string hm_sale_ear_site = "Right";
                //int hm_sale_aud_rat = 0;
                //string MName = (System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + txtmodel_no.Text + "," + txtmach_type.Text));
                //string hm_nm_rt = MName;
                //string hm_nm_lt = "";
                //int hm_sale_ear_mould_to = 0;
                //string hm_sale_mach_srno = "";
                //string hm_sale_mach_srno_lt = "";
                //double hm_sale_mach_price_rt = Convert.ToDouble(txtprice.Text);
                //int paid_chg = Convert.ToInt32(0);
                //int dueamt = Convert.ToInt32(0);
                //double DisC = Convert.ToDouble(0);
                //double Vat = Convert.ToDouble(0);
                //cr_by = Convert.ToInt32(Session["Name"].ToString());
                //Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                //Flag = "E";
                //cn.Open();
                //cmd1 = new SqlCommand("tbl_hm_sale_trn_c", connection.con);
                //cmd1.CommandType = CommandType.StoredProcedure;
                //cmd1.Parameters.AddWithValue("@pFlag", Flag);
                //cmd1.Parameters.AddWithValue("@phm_sale_id", hmsale_id);
                //cmd1.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                //cmd1.Parameters.AddWithValue("@pDoc_Type", Doc_Type);
                //cmd1.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                //cmd1.Parameters.AddWithValue("@phm_sale_ear_site", hm_sale_ear_site);
                //cmd1.Parameters.AddWithValue("@phm_sale_aud_rat", hm_sale_aud_rat);
                //cmd1.Parameters.AddWithValue("@phm_mach_id_rt", hm_mach_id_rt);
                //cmd1.Parameters.AddWithValue("@phm_nm_rt", hm_nm_rt);
                //cmd1.Parameters.AddWithValue("@phm_mach_id_lt", hm_mach_id_lt);
                //cmd1.Parameters.AddWithValue("@phm_nm_lt", hm_nm_lt);
                //cmd1.Parameters.AddWithValue("@phm_sale_ear_mould_to", hm_sale_ear_mould_to);
                //cmd1.Parameters.AddWithValue("@phm_sale_mach_srno_rt", hm_sale_mach_srno);
                //cmd1.Parameters.AddWithValue("@phm_sale_mach_srno_lt", hm_sale_mach_srno_lt);
                //cmd1.Parameters.AddWithValue("@phm_sale_mach_price_rt", hm_sale_mach_price_rt);
                //cmd1.Parameters.AddWithValue("@pwarr_Period", hm_Warr_dt);
                //cmd1.Parameters.AddWithValue("@pDisc_Amt", DisC);
                //cmd1.Parameters.AddWithValue("@pVat_amt", Vat);
                //cmd1.Parameters.AddWithValue("@pcreated_by", cr_by);
                //cmd1.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                ////cmd.Parameters.AddWithValue("@pTRCntr_id", null);
                //cn.executeprocedure(cmd1);
                //cn.Close();
                #endregion        
                Response.Redirect("MachineMaster_Grid.aspx");
                Response.Write("<script language='JavaScript'>alert('Record is Update')</script>");
                Clear();
                btnsave.Enabled = false;
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is not Update')</script>");
            }
            #endregion
        }
        else
        {
            #region Save Machine
            try
            {
                int mach_id = 0;
                int Comp_ID = Convert.ToInt32(ddl_comp.SelectedValue);
                string model = txtmodel_no.Text.ToString().ToUpper();
                string type = txtmach_type.Text.ToString().ToUpper();
                string desc = txtmachdesc.Text.ToString();
                //int Qty = 0;
                int Qty;
                if (txtAdd.Text == "")
                {
                    Qty = 0;
                }
                else
                {
                    Qty = System.Convert.ToInt32(txtAdd.Text);
                }
                int Ret_qty = 0;
                double Price = System.Convert.ToDouble(txtprice.Text);
                double Sale_Price;
                string Stock_Trans_City = "K001";
                if (txtSale.Text == "")
                {
                    Sale_Price = 0;
                }
                else
                {
                    Sale_Price = System.Convert.ToDouble(txtSale.Text);
                }
                string BatSiz = txtBtrSiz.Text.ToString();
                int Chan;
                int Gain;
                if (txtChan.Text == "")
                { Chan = 0; }
                else { Chan = System.Convert.ToInt32(txtChan.Text); }
                if (txtGain.Text == "")
                { Gain = 0; }
                else { Gain = System.Convert.ToInt32(txtGain.Text); }
                string Fit_Ran = txtFit_Ran.Text.ToString();
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
                string curr = ddl_cur.SelectedItem.Text.ToString();
                cr_by = Convert.ToInt32(Session["Name"].ToString());
                Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_machine_master_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pmach_id", mach_id);
                cmd.Parameters.AddWithValue("@pComp_ID", Comp_ID);
                cmd.Parameters.AddWithValue("@pmach_model", model);
                cmd.Parameters.AddWithValue("@pmach_type", type);
                cmd.Parameters.AddWithValue("@pmach_desc", desc);
                cmd.Parameters.AddWithValue("@pmach_qty", Qty);
                cmd.Parameters.AddWithValue("@pmach_purch_price", Price);
                cmd.Parameters.AddWithValue("@pmach_sale_price", Sale_Price);
                cmd.Parameters.AddWithValue("@pmach_minus_qty", Qty);
                cmd.Parameters.AddWithValue("@pStock_Trans_City", Stock_Trans_City);
                cmd.Parameters.AddWithValue("@pmach_cell_size", BatSiz);
                cmd.Parameters.AddWithValue("@pmach_channel", Chan);
                cmd.Parameters.AddWithValue("@pmach_Gain", Gain);
                cmd.Parameters.AddWithValue("@pmach_fitting_Range", Fit_Ran);
                cmd.Parameters.AddWithValue("@pTech", Tech);
                cmd.Parameters.AddWithValue("@pmach_cur", curr);
                cmd.Parameters.AddWithValue("@pReturn_qty", Ret_qty);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                //cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                int a = cn.executeprocedure(cmd);
                string Mach_id = a.ToString();
                cn.Close();
                #region Quantity Insert
                string Doc_Type = "PA";
                int def = 0;
                int hm_mach_id_rt;
                int hm_mach_id_lt;
                int ptnt_id;
                string ptnt_nm;
                hm_mach_id_rt = Convert.ToInt32(Mach_id);
                hm_mach_id_lt = def;
                DateTime hm_Warr_dt = DateTime.Now;
                int hmsale_id = 0;
                string comm = "Purchase";
                string ptnt_nm1 = "PURCHASE";
                ptnt_id = Convert.ToInt32(0);
                ptnt_nm = "PURCHASE";
                DateTime Doc_Date = DateTime.Now;
                string hm_sale_ear_site = "Right";
                int hm_sale_aud_rat = 0;
                string MName = (System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + txtmodel_no.Text + "," + txtmach_type.Text));
                string hm_nm_rt = MName;
                string hm_nm_lt = "";
                int hm_sale_ear_mould_to = 0;
                string hm_sale_mach_srno = "";
                string hm_sale_mach_srno_lt = "";
                double hm_sale_mach_price_rt = Convert.ToDouble(txtprice.Text);
                int paid_chg = Convert.ToInt32(0);
                int dueamt = Convert.ToInt32(0);
                double DisC = Convert.ToDouble(0);
                double Vat = Convert.ToDouble(0);
                cr_by = Convert.ToInt32(Session["Name"].ToString());
                Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
               int PurQty=Convert.ToInt32(txtAdd.Text);
                Flag = "I";
                cn.Open();
                cmd1 = new SqlCommand("tbl_hm_sale_trn_c", connection.con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@pFlag", Flag);
                cmd1.Parameters.AddWithValue("@phm_sale_id", hmsale_id);
                cmd1.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                cmd1.Parameters.AddWithValue("@pDoc_Type", Doc_Type);
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
                cmd1.Parameters.AddWithValue("@pQty", PurQty);
                cmd1.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                //cmd.Parameters.AddWithValue("@pTRCntr_id", null);
                cn.executeprocedure(cmd1);
                cn.Close();
                #endregion

                Response.Redirect("MachineMaster_Grid.aspx");                
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                Clear();
                btnsave.Enabled = false;
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is not save')</script>");
            }
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
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("h_mach_master.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("h_mach_master.aspx");
        btnsave.Visible = true;
    }
    protected void btnEdit_Click1(object sender, EventArgs e)
    {
        #region Update
        //try
        //{
        //    string comp = txtmachcomp.Text.ToString();
        //    string model = txtmodel_no.Text.ToString();
        //    string type = txtmach_type.Text.ToString();
        //    string desc = txtmachdesc.Text.ToString();
        //    int Qty;
        //    if (txtAdd.Text == "")
        //    {
        //        Qty = 0;
        //    }
        //    else
        //    {
        //        Qty = System.Convert.ToInt32(txtAdd.Text);
        //    }
        //    double price = System.Convert.ToDouble(txtprice.Text);
        //    double Sale_Price = System.Convert.ToDouble(txtSale.Text);
        //    string BatSiz = txtBtrSiz.Text.ToString();
        //    int Chan;
        //    int Gain;
        //    if (txtChan.Text == "")
        //    { Chan = 0; }
        //    else { Chan = System.Convert.ToInt32(txtChan.Text); }
        //    if (txtGain.Text == "")
        //    { Gain = 0; }
        //    else { Gain = System.Convert.ToInt32(txtGain.Text); }
        //    string Fit_Ran = txtFit_Ran.Text.ToString();
        //    string Tech;
        //    if (ddlTech.SelectedIndex == 0)
        //    {
        //        Tech = "A";
        //    }
        //    else if (ddlTech.SelectedIndex == 1)
        //    {
        //        Tech = "T";
        //    }
        //    else if (ddlTech.SelectedIndex == 2)
        //    {
        //        Tech = "P";
        //    }
        //    else
        //    {
        //        Tech = "F";
        //    }
        //    string cr_by = Session["Name"].ToString();
        //    string Trans_Stock_city = cmbCenter.SelectedItem.Text.ToString();

        //    string Ret;
        //    if (rbtReturn.SelectedIndex == 0)
        //    {
        //        Ret = "Y";
        //    }
        //    else if (rbtReturn.SelectedIndex == 1)
        //    {
        //        Ret = "N";
        //    }
        //    else
        //    {
        //        Ret = "S";
        //        //string Trans_Stock_city = cmbCenter.SelectedIndex.ToString();
        //    }
        //    // string curr = ddl_cur.SelectedItem.Text.ToString();
        //    cn.Open();
        //    cmd = new SqlCommand("sp_mach_Update", connection.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@p_Return", Ret);
        //    cmd.Parameters.AddWithValue("@p_mach_cmp", comp);
        //    cmd.Parameters.AddWithValue("@p_mach_model", model);
        //    cmd.Parameters.AddWithValue("@p_mach_type", type);
        //    cmd.Parameters.AddWithValue("@p_mach_desc", desc);
        //    cmd.Parameters.AddWithValue("@p_mach_Qty", Qty);
        //    cmd.Parameters.AddWithValue("@p_mach_price", price);
        //    cmd.Parameters.AddWithValue("@p_mach_Sale_price", Sale_Price);
        //    cmd.Parameters.AddWithValue("@p_Bat_Siz", BatSiz);
        //    cmd.Parameters.AddWithValue("@p_Chan", Chan);
        //    cmd.Parameters.AddWithValue("@p_Gain", Gain);
        //    cmd.Parameters.AddWithValue("@p_Fit_Rang", Fit_Ran);
        //    cmd.Parameters.AddWithValue("@p_Tech", Tech);
        //    cmd.Parameters.AddWithValue("@p_Trans_Stock_City", Trans_Stock_city);
        //    cmd.Parameters.AddWithValue("@p_created_by", cr_by);
        //    //cmd.Parameters.AddWithValue("@p_mach_cur", curr);
        //    cn.executeprocedure(cmd);
        //    cn.Close();
        //    lblmach_id.Text = "";
        //    txtmachcomp.Text = "";
        //    txtmodel_no.Text = "";
        //    txtmach_type.Text = "";
        //    txtAdd.Text = "";
        //    lblQty.Text = "";
        //    txtmachdesc.Text = "";
        //    txtprice.Text = "";
        //    txtSale.Text = "";
        //    txtBtrSiz.Text = "";
        //    txtChan.Text = "";
        //    txtGain.Text = "";
        //    txtFit_Ran.Text = "";
        //}
        //catch
        //{
        //    Response.Redirect("~/error.aspx");
        //}
        #endregion
    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        Response.Redirect("h_mach_master.aspx");
    }
    protected void BtnStock_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Transaction/MachinStock.aspx");
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        #region Search
        //try
        //{
        //    ddl_h_ac_des.Visible = true;
        //    string nm = txtmodel_no.Text.ToUpper();
        //    ddl_h_ac_des.Items.Clear();
        //    cmd = new SqlCommand("sp_mach_search", connection.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@p_mach_model_name", nm);
        //    cn.Open();
        //    cn.executeprocedure(cmd);
        //    cn.Close();
        //    DataTable DT1 = new DataTable();
        //    cn.Open();
        //    dr = cmd.ExecuteReader();
        //    DT1.Load(dr);
        //    DT1.Columns.Add("ptntnm", typeof(string), "mach_id+','+mach_model");
        //    ddl_h_ac_des.DataSource = DT1;
        //    ddl_h_ac_des.DataValueField = "mach_id";
        //    ddl_h_ac_des.DataTextField = "mach_model";
        //    ddl_h_ac_des.DataBind();
        //    ddl_h_ac_des.Items.Insert(0, new ListItem("Select", "mach_model"));
        //    ddl_h_ac_des.SelectedIndex = 0;
        //    dr = null;
        //    cn.Close();
        //    btnEdit.Visible = true;
        //    btnsave.Visible = false;
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
        //    lblmach_id.Text = "";
        //    txtmachcomp.Text = "";
        //    txtmodel_no.Text = "";
        //    txtmach_type.Text = "";
        //    txtmachdesc.Text = "";
        //    txtprice.Text = "";
        //    ddl_cur.SelectedIndex = 0;
        //    if (ddl_h_ac_des.SelectedIndex > 0)
        //    {
        //        string[] arrrSelVal = ddl_h_ac_des.SelectedValue.Split(',');
        //        double Hid = System.Convert.ToInt32(arrrSelVal[0]);
        //        cmd = new SqlCommand("sp_mach_search1", connection.con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@p_mach_id", Hid);
        //        cn.Open();
        //        cn.executeprocedure(cmd);
        //        DataTable DT1 = new DataTable();
        //        cn.Open();
        //        dr = cmd.ExecuteReader();
        //        DT1.Load(dr);
        //        lblmach_id.Text = DT1.Rows[0][1].ToString();
        //        txtmachcomp.Text = DT1.Rows[0][2].ToString();
        //        txtmodel_no.Text = DT1.Rows[0][3].ToString();
        //        txtmach_type.Text = DT1.Rows[0][4].ToString();
        //        txtmachdesc.Text = DT1.Rows[0][5].ToString();
        //        txtprice.Text = DT1.Rows[0][6].ToString();
        //        txtSale.Text = DT1.Rows[0][7].ToString();
        //        lblQty.Text = DT1.Rows[0][9].ToString();
        //        txtBtrSiz.Text = DT1.Rows[0][12].ToString();
        //        txtChan.Text = DT1.Rows[0][13].ToString();
        //        txtGain.Text = DT1.Rows[0][14].ToString();
        //        txtFit_Ran.Text = DT1.Rows[0][15].ToString();
        //        string Cur = DT1.Rows[0][10].ToString();
        //        if (Cur == "Rupees")
        //        {
        //            ddl_cur.SelectedIndex = 1;
        //        }
        //        else if (Cur == "Dollar")
        //        {
        //            ddl_cur.SelectedIndex = 2;
        //        }
        //        else if (Cur == "Euro")
        //        {
        //            ddl_cur.SelectedIndex = 3;
        //        }
        //        else if (Cur == "Australian Dollar")
        //        {
        //            ddl_cur.SelectedIndex = 4;
        //        }
        //        else if (Cur == "Pound")
        //        {
        //            ddl_cur.SelectedIndex = 5;
        //        }
        //        else if (Cur == "Yuan")
        //        {
        //            ddl_cur.SelectedIndex = 6;
        //        }
        //        else
        //        {
        //            ddl_cur.SelectedIndex = 0;
        //        }
        //        dr = null;
        //        cn.Close();
        //    }
        //}
        //catch
        //{
        //    Response.Write("<script language='JavaScript'>alert('Machine is  Not Match')</script>");
        //    // Response.Redirect("~/error.aspx");
        //}
        #endregion
    }
    protected void rbtReturn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtReturn.SelectedIndex == 2)
        {
            Response.Redirect("~/Transaction/Mach_Stock_Transfer.aspx");
            //cmbCenter.Visible = true;
        }
        else if (rbtReturn.SelectedIndex == 3)
        {
            Response.Redirect("~/Transaction/Mach_Stock_Transfer.aspx");
            //cmbCenter.Visible = true;
        }
    }
    protected void ddlCom_nm_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtmachcomp.Text = ddlCom_nm.SelectedItem.Text;
        //ddlCom_nm.Visible = false;
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MachineMaster_Grid.aspx");
    }
    protected void txtmach_type_TextChanged(object sender, EventArgs e)
    {
        #region Machine Final
        int Mach_Desc = Convert.ToInt32(ddl_comp.SelectedValue);
        string Mach_Model = txtmodel_no.Text;
        string Mach_Type = txtmach_type.Text;
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
            lblMsg.Visible = true;
            btnsave.Enabled = false;
            ddl_comp.Focus();
        }
        else
        {
            lblMsg.Visible = false;
            btnsave.Enabled = true;
            txtmachdesc.Focus();
        }
        #endregion
    }
}
