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
using System.Web.Services;
using System.Text.RegularExpressions;


public partial class h_mach_sale_Disc : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlDataReader dr;
    connection cn;
    DataSet ds;
    SqlDataAdapter da;
    double id;
    string Doc_Type;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
           cn = new connection();
           //RangeValidator1.MaximumValue = System.DateTime.Now.AddDays(0).ToShortDateString();
           PtntNm.ContextKey = Session["Cntr_id"].ToString();
           Doc_Type = Session["Doc_Type"].ToString();
           if (!IsPostBack)
           {
                rbte_site.Focus();
                Label4.Enabled  = false;
                Label18.Enabled = false;
                ddl_comp.Enabled = false;
                ddl_mach_model.Enabled = false;
                ddl_mach_type.Enabled = false;
                txt_mach.Enabled = false;
                Label13.Enabled = false;
                txtmach_serno_rt.Enabled = false;
                Label17.Enabled = false;
                Label8.Enabled = false;
               
                Label10.Enabled = false;
                ddl_comp1.Enabled = false;
                ddl_model1.Enabled = false;
                ddl_type1.Enabled = false;
                txt_mach1.Enabled = false;
                Label16.Enabled = false;
                txt_srno_lt.Enabled = false;
                //// btnprt_bil.Enabled = false;
                Select();
                if (Doc_Type == "PA")
                {                    
                    lblHeading.Text = "Hearing Aid Purchase Invoice";
                    Ptnt_Nm.Text = "PURCHASE";
                    Label3.Text = "Purchase";
                    lblDoc_Date.Text = "Purchase Date";
                    Label12.Text = "Purchase Price";
                    Label18.Text = "Name Of Hearing Aid";
                    Label13.Visible = false;
                    txtrecamt.Text = "0";
                    txtrecamt.Visible = false;
                    Label11.Visible = false;
                    txtmachprice.Text = "0";
                    txtmachprice.Visible = false;
                    Label14.Visible = false;
                    txtdueamt.Text="0";
                    txtdueamt.Visible = false;
                    //rbte_site.SelectedIndex = 0;
                    rbte_site.Visible = false;
                    Label4.Visible = false;
                    Label5.Visible = false;
                    txtaudrat.Visible = false;
                    Label6.Visible = false;
                    rbtem.SelectedIndex = 0;
                    rbtem.Visible = false;
                    ddl_comp.Enabled = true;
                    Label19.Visible = false;
                    Label8.Visible = false;
                    txtmach_serno_rt.Visible = false;
                    txtmach_serno_rt.Text = "0";
                    ddl_comp1.Visible = false;
                    ddl_model1.Visible = false;
                    ddl_type1.Visible = false;
                    txt_mach1.Visible = false;
                    txt_srno_lt.Visible = false;
                    lblQty1.Visible = false;
                    Label17.Visible = false;
                    Label10.Visible = false;
                    Label15.Visible = false;
                    txtcomment.Visible = false;
                    Label16.Visible = false;
                    txtdate.Visible = false;
                    Label1.Visible = true; ;
                    txtPurQty.Visible = true;
                    Label9.Visible = false;
                    rbtDisc.Visible = false;
                    lblDisc.Visible = false;
                    txtDisc.Visible = false;
                    lblVat.Visible = false;
                    txtVat.Visible = false;
                    Image.Visible = false;
                    txtDV.Visible = false;
                    Label12.Visible = false;
                    lblDocCom.Visible = false;
                    txtDocComm.Visible = false;
                    lblDocRup.Visible = false;
                    txtDocRup.Visible = false;
                    //txtDocComm.Text = "0";

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
                    //Label14.Text = "Add Quantity";
                    dr = null;
                    cn.Close();
                }
                else
                {
                    lblHeading.Text = "Hearing Aid Sale Invoice";
                    Label3.Text = "Patient Name";
                    lblDoc_Date.Text = "Sale Date";
                    //rbte_site.SelectedIndex = 0;
                    rbte_site.Visible = true;
                    Label4.Visible =true;
                    Label5.Visible = false;
                    Label12.Text = "Sale Price";
                    Label1.Visible = false;
                    txtPurQty.Visible = false;
                    txtPurQty.Text = "0";
                    lblDocCom.Visible = true;
                    txtDocComm.Visible = true;
                    lblQty.Visible = true;
                    lblQty1.Visible = true;

                    //txtDocComm.Text = "0";
                    //Label14.Text = "Sale Quantity";
                }
            }
        }
    }
    public void Select()
    {
        if (Request.QueryString["sale_id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["sale_id"].ToString());
                double SaleId = System.Convert.ToInt32(id1);
                cn.Open();
                // cmd = new SqlCommand("tbl_HM_Sale_Id", connection.con);
                cmd = new SqlCommand("tbl_HM_Sale_Id_Cntr", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_Hm_sale_id", SaleId);
                cmd.Parameters.AddWithValue("@pCntr_id", Convert.ToInt32(Session["Cntr_id"]));
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblsale_id.Value = DT1.Rows[0][0].ToString();
                Ptnt_Nm.Text = DT1.Rows[0][1].ToString();
                lblptnt_id.Value = DT1.Rows[0][15].ToString();
                txt_mach.Text = DT1.Rows[0][2].ToString();
                lbl_mach_id_rt.Value = DT1.Rows[0][6].ToString();
                lbl_mach_id_lt.Value = DT1.Rows[0][7].ToString();
                txtmach_serno_rt.Text = DT1.Rows[0][9].ToString();
                txt_srno_lt.Text = DT1.Rows[0][7].ToString();
                txtmachprice.Text = DT1.Rows[0][11].ToString();
                string Site = DT1.Rows[0][5].ToString().Trim();
                if (Site == "Right")
                {
                    rbte_site.SelectedIndex = 0;
                }
                else if (Site == "Left")
                {
                    rbte_site.SelectedIndex = 1;
                }
                else if (Site == "Both")
                {
                    rbte_site.SelectedIndex = 2;
                }
                else if (Site == "Bianaural Fitting")
                {
                    rbte_site.SelectedIndex = 3;
                }
                else
                {
                    rbte_site.SelectedIndex = 0;
                }
                txtDisc.Text = DT1.Rows[0][13].ToString();
                txtVat.Text = DT1.Rows[0][14].ToString();
                //rbtem.SelectedValue= DT1.Rows[0][9].ToString();
                txtDoc_Date.Text = DT1.Rows[0][19].ToString();
                txtrecamt.Text = DT1.Rows[0][17].ToString();
                txtdueamt.Text = DT1.Rows[0][18].ToString();
                txtcomment.Text = DT1.Rows[0][16].ToString();
                txtdate.Text = DT1.Rows[0][12].ToString();
                txtDocComm.Text = DT1.Rows[0][20].ToString();
                txtDocRup.Text = DT1.Rows[0][21].ToString();
                txtDV.Text = DT1.Rows[0][22].ToString();
                dr = null;
                cn.Close();
                btnsave.Text = "Edit";
                btnPrint.Enabled = true;
            }
            catch
            { }

            #endregion
        }
    }
    protected void btn_nm_Click(object sender, EventArgs e)
    {
        #region Search
        try
        {
            //string nm = txtptnt_nm.Text.ToUpper();
            //ddl_ptnt_nm.Items.Clear();

            //cmd = new SqlCommand("sp_ptnt_search_by_name", connection.con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@p_ptnt_nm", nm);
            //cn.Open();
            //cn.executeprocedure(cmd);

            //DataTable DT1 = new DataTable();
            //cn.Open();
            //dr = cmd.ExecuteReader();
            //DT1.Load(dr);
            //DT1.Columns.Add("ptntnm", typeof(string), "ptnt_id+','+ptnt_nm");
            //ddl_ptnt_nm.DataSource = DT1;
            //ddl_ptnt_nm.DataValueField = "ptnt_id";
            //ddl_ptnt_nm.DataTextField = "ptntnm";
            //ddl_ptnt_nm.DataBind();
            //ddl_ptnt_nm.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
            //ddl_ptnt_nm.SelectedIndex = 0;
            //dr = null;
            //cn.Close();
        }
        catch
        {
            Response.Redirect("~/error.aspx");
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
                ddl_mach_model.Enabled  = true;
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
                ddl_mach_type.Enabled  = true;
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
            if (Doc_Type == "PA")
            {
              #region Machine ID Search For Purchase
                //txt_mach.Visible = true;
                //string Mach_Desc = ddl_comp.SelectedItem.Text;
                int Mach_Desc = Convert.ToInt32(ddl_comp.SelectedValue);
                string Mach_Model = ddl_mach_model.SelectedItem.Text;
                string Mach_Type = ddl_mach_type.SelectedItem.Text;
                cmd = new SqlCommand("sp_Mach_Id_For_PA", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
                cmd.Parameters.AddWithValue("@mach_Type", Mach_Type);
                cn.executeprocedure(cmd);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "tbl_machine_master");
                //if (ds.Tables["tbl_machine_master"].Rows.Count > 0)
                //{
               
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                lbl_mach_id_rt.Value = machid;                
                lblSale_price.Value = ds.Tables["tbl_machine_master"].Rows[0][1].ToString();
                txt_mach.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_mach_type.SelectedItem.Text));
                txtmach_serno_rt.Focus();
              #endregion
            }
            else
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
                //if (ds.Tables["tbl_machine_master"].Rows.Count > 0)
                //{
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                lbl_mach_id_rt.Value = machid;
                if (Doc_Type == "PA")
                {
                    lblSale_price.Value = ds.Tables["tbl_machine_master"].Rows[0][4].ToString();
                    txt_mach.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_mach_type.SelectedItem.Text));
                    txtmach_serno_rt.Focus();
                }
                else
                {
                    if (ds.Tables["tbl_machine_master"].Rows.Count > 0)
                    {
                        machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                        lblSale_price.Value = ds.Tables["tbl_machine_master"].Rows[0][1].ToString();
                        lblQty.Text = ds.Tables["tbl_machine_master"].Rows[0][2].ToString();
                        int Qty = Convert.ToInt32(lblQty.Text);
                        if (Qty > 0)
                        {
                            MachVal();
                            txt_mach.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_mach_type.SelectedItem.Text));
                            txtmach_serno_rt.Focus();
                        }
                        else
                        {
                            // Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
                            txtmach_serno_rt.Text = "Machine Out Of Stock";
                            txtmach_serno_rt.Enabled = false;
                        }
                    }
                }


                //}              
                #endregion
            }
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
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //Doc_Type = Session["Doc_Type"].ToString();
        #region Save
        try
        {
            if ((lbl_mach_id_rt.Value  != "") && (txtmach_serno_rt.Text == ""))
            {
                Response.Write("<script>alert('Please Insert Right Ear Heaaring Aid Sr No')</script>)");
            }
            else if ((lbl_mach_id_lt.Value  != "") && (txt_srno_lt.Text == ""))
            {
                Response.Write("<script>alert('Please Insert Left Ear Heaaring Aid Sr No')</script>)");
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
                if (lbl_mach_id_lt.Value  == "")
                { hm_mach_id_lt = def; }
                else { hm_mach_id_lt = Convert.ToInt32(lbl_mach_id_lt.Value ); }
                DateTime hm_Warr_dt = DateTime.Now;
                if (txtdate.Text == "")
                {
                    Response.Write("<script language='JavaScript'>alert('Insert Warranty Date')</script>");
                }
                else
                {
                    //hm_Warr_dt = Convert.ToDateTime(txtdate.Text);
                    hm_Warr_dt = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);
                }
                int hmsale_id = 0;
                string comm = txtcomment.Text.ToString();
                string ptnt_nm1 = Ptnt_Nm.Text;
                string[] WordArray = ptnt_nm1.Split('-');
                string Name = WordArray[0].ToString();
                int PurQty=0;
                double DocCom ;
                double DocRup;
                if (Doc_Type == "PA")
                {
                    lblptnt_id.Value = null;
                    ptnt_id = Convert.ToInt32(0);
                    PurQty = Convert.ToInt32(txtPurQty.Text);
                    DocCom = 0;
                    DocRup = 0;
                }
                else
                {
                    lblptnt_id.Value = WordArray[1];
                    ptnt_id = Convert.ToInt32(lblptnt_id.Value);
                    PurQty = 1;
                    DocCom = Convert.ToDouble(txtDocComm.Text);
                    DocRup = Convert.ToDouble(txtDocRup.Text);
                }
                ptnt_nm = Ptnt_Nm.Text.ToString();
                //DateTime Doc_Date = System.Convert.ToDateTime(txtDoc_Date.Text);
                DateTime Doc_Date = DateTime.ParseExact(txtDoc_Date.Text, "dd/MM/yyyy", null);
                //lblptnt_id.Value = WordArray[1];
                //int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
                string hm_sale_ear_site = "";
                int hm_sale_aud_rat = Convert.ToInt32(txtaudrat.Text);
                string hm_nm_rt = txt_mach.Text.ToString();
                string hm_nm_lt = txt_mach1.Text.ToString();
                int hm_sale_ear_mould_to = rbtem.SelectedIndex;
                string hm_sale_mach_srno = txtmach_serno_rt.Text.ToString();
                string hm_sale_mach_srno_lt = txt_srno_lt.Text.ToString();
                double hm_sale_mach_price_rt = Convert.ToDouble(txtmachprice.Text);
                int paid_chg = Convert.ToInt32(txtrecamt.Text);
                int dueamt = Convert.ToInt32(txtdueamt.Text);
                double DisC = Convert.ToDouble(txtDisc.Text);
                double Vat = Convert.ToDouble(txtVat.Text);
                //double DocCom = Convert.ToDouble(txtDocComm.Text);
                //double DocRup = Convert.ToDouble(txtDocRup.Text);
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_hm_sale_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@phm_sale_id", hmsale_id);
                cmd.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                cmd.Parameters.AddWithValue("@pDoc_Type", Doc_Type);
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
                cmd.Parameters.AddWithValue("@pQty", PurQty);
                cmd.Parameters.AddWithValue("@pDocCom", DocCom);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
               //cmd.Parameters.AddWithValue("@pTRCntr_id", null);
                int a=cn.executeprocedure(cmd);                
                cn.Close();                
                lblsale_id.Value = a.ToString();
                string Qry, Qry1;
                //if (rbte_site.SelectedIndex == 0)
                //{
                //    string Right = ddl_mach_model.SelectedItem.Text.ToString();
                //    cn.Open();
                //    cmd = new SqlCommand("sp_update_mach_qty", connection.con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@p_Right", Right);
                //    // cmd.Parameters.AddWithValue("@p_Right", Left);
                //    cn.executeprocedure(cmd);
                //    cn.Close();
                //}
                //else if (rbte_site.SelectedIndex == 1)
                //{
                //    string Left = ddl_model1.SelectedItem.Text.ToString();
                //    cn.Open();
                //    cmd = new SqlCommand("sp_update_mach_Lqty", connection.con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@p_Left", Left);
                //    //cmd.Parameters.AddWithValue("@p_Right", Right);
                //    cn.executeprocedure(cmd);
                //    cn.Close();
                //}
                //else if (rbte_site.SelectedIndex == 3)
                //{
                //    string Right = ddl_mach_model.SelectedItem.Text.ToString();
                //    cn.Open();
                //    cmd = new SqlCommand("sp_update_mach_qty", connection.con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@p_Right", Right);
                //    // cmd.Parameters.AddWithValue("@p_Right", Left);
                //    cn.executeprocedure(cmd);
                //    cn.Close();
                //}
                //else
                //{
                //    string Right = ddl_mach_model.SelectedItem.Text.ToString();
                //    string Left = ddl_model1.SelectedItem.Text.ToString();
                //    cn.Open();
                //    cmd = new SqlCommand("sp_update_mach_RLqty", connection.con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@p_Left", Left);
                //    cmd.Parameters.AddWithValue("@p_Right", Right);
                //    cn.executeprocedure(cmd);
                //    cn.Close();
                //}
                int sale_charg_sale = 0;
                cn.Open();
                cmd = new SqlCommand("tbl_h_m_sale_charg_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@ph_m_sale_charg_sale_id", sale_charg_sale);
                //cmd.Parameters.AddWithValue("@phm_sale_id", hmsale_id);
                cmd.Parameters.AddWithValue("@phm_sale_id", lblsale_id.Value);
                cmd.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                cmd.Parameters.AddWithValue("@pDoc_Type", Doc_Type);
                cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                cmd.Parameters.AddWithValue("@ph_m_sale_price", hm_sale_mach_price_rt);
                cmd.Parameters.AddWithValue("@ph_m_sale_paid_charg", paid_chg);
                cmd.Parameters.AddWithValue("@ph_m_sale_due_charg", dueamt);
                cmd.Parameters.AddWithValue("@ph_m_sale_comment", comm);
                cmd.Parameters.AddWithValue("@pDocRup", DocRup);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();               
                
                if (Doc_Type == "PA")
                {
                    Response.Redirect("h_mach_sale_Grid.aspx");
                }
                else
                {
                    btnsave.Enabled = false;
                    btnPrint.Enabled = true;
                    //Response.Redirect("h_mach_sale_Grid.aspx");
                }
               
                //string confirmValue = Request.Form["confirm_value"];
                //if (confirmValue == "Yes")
                //{
                //    int billno = Convert.ToInt32(lblsale_id.Value);
                //    Response.Redirect("~/h_m_Chll.aspx?bill_no=" + billno);
                //}
                //else
                //{
                //    Response.Redirect("~/h_mach_sale_Grid.aspx");
                //}
                
            }
        }
        catch
        {
            //Response.Redirect("~/error.aspx");
        }
        #endregion
    }
    protected void btn_total_Click(object sender, EventArgs e)
    {
        try
        {
            double paid, price;
            paid = Convert.ToDouble(txtrecamt.Text);
            price = Convert.ToDouble(txtmachprice.Text);
            txtdueamt.Text = Convert.ToString(price - paid);
            btnsave.Enabled = true;
        }
        catch { Response.Redirect("~/error.aspx"); }
    }
    protected void btnprt_bil_Click(object sender, EventArgs e)
    {
        lblptnt_id.Value  = "";
        txtaudrat.Text = "";
        rbtem.SelectedIndex = -1;
        ddl_mach_model.Visible = false;
        ddl_mach_type.Visible = false;
        txt_mach.Visible = false;
        txtmach_serno_rt.Text = "";
        lbl_mach_id_rt.Value = "";
        txtmachprice.Text = "";
        rbte_site.SelectedIndex = -1;
        txtrecamt.Text = "";
        txtdueamt.Text = "";
        txtcomment.Text = "";
        int billno = Convert.ToInt32(lblsale_id.Value);
        Response.Redirect("~/h_m_Chll.aspx?bill_no=" + billno);
    }
    protected void ddl_comp1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_comp1.SelectedIndex > 0)
        {
            #region Machine Model
            try
            {
                cn.Open();
                ddl_model1.Items.Clear();                
               // string Mach_Desc = ddl_comp1.SelectedItem.Text;
                int Mach_Desc = Convert.ToInt32(ddl_comp1.SelectedValue);
                cmd = new SqlCommand("sp_Mach_Model_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cn.executeprocedure(cmd);
                DataTable DT_model = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_model.Load(dr);

                ddl_model1.DataSource = DT_model;
                ddl_model1.DataValueField = "mach_id";
                ddl_model1.DataTextField = "mach_model";
                ddl_model1.DataBind();
                ddl_model1.Items.Insert(0, new ListItem("MODEL", "mach_model"));
                ddl_model1.SelectedIndex = 0;

                dr = null;
                cn.Close();
                //ddl_model1.Visible = true;
                ddl_model1.Enabled = true;
                //ddl_model1.Focus();
            }
            catch { /*Response.Redirect("~/error.aspx");*/ }
            #endregion
        }
    }
    protected void ddl_model1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_model1.SelectedIndex > 0)
        {
            #region Machine Type
            try
            {
                cn.Open();
                ddl_type1.Items.Clear();               
                //string Mach_Desc = ddl_comp1.SelectedItem.Text;
                int Mach_Desc = Convert.ToInt32(ddl_comp1.SelectedValue);
                string Mach_Model = ddl_model1.SelectedItem.Text;
                cmd = new SqlCommand("sp_Mach_Type_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
                cn.executeprocedure(cmd);
                DataTable DT_type = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_type.Load(dr);

                ddl_type1.DataSource = DT_type;
                ddl_type1.DataValueField = "mach_id";
                ddl_type1.DataTextField = "mach_type";
                ddl_type1.DataBind();
                ddl_type1.Items.Insert(0, new ListItem("Type", "ptnt_nm"));
                ddl_type1.SelectedIndex = 0;

                dr = null;
                cn.Close();
                //ddl_type1.Visible = true;
                ddl_type1.Enabled  = true;
                //ddl_type1.Focus();
            }
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
        }
    }
    protected void ddl_type1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_type1.SelectedIndex > 0)
        {
            #region Machine Final            
            //string Mach_Desc = ddl_comp1.SelectedItem.Text;
            int Mach_Desc = Convert.ToInt32(ddl_comp1.SelectedValue);
            string Mach_Model = ddl_model1.SelectedItem.Text;
            string Mach_Type = ddl_type1.SelectedItem.Text;
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
                txt_mach1.Enabled = true;
                txt_mach1.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp1.SelectedItem.Text + "," + ddl_model1.SelectedItem.Text + "," + ddl_type1.SelectedItem.Text));
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                lbl_mach_id_lt.Value = machid;
                lblSale_price1.Value  = ds.Tables["tbl_machine_master"].Rows[0][1].ToString();
                lblQty1.Text = ds.Tables["tbl_machine_master"].Rows[0][2].ToString();
                int Qty1 = Convert.ToInt32(lblQty1.Text);
                if (Qty1 > 0)
                { }
                else
                {
                    Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
                }
                MachVal();
            }
            txt_srno_lt.Focus();
            #endregion
        }
    }
    protected void rbte_site_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region machine Company
        try
        {
            cn.Open();
            cmd = connection.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "sp_Mach_Desc_ddl";
            DataTable DT_comp = new DataTable();

            dr = cmd.ExecuteReader();
            DT_comp.Load(dr);


            if (rbte_site.SelectedIndex == 0)
            {
                Label4.Enabled  = true;
                Label8.Enabled = true;
                ddl_comp.Enabled = true;
                Label13.Enabled = true;
                txtmach_serno_rt.Enabled = true;
                Label18.Enabled = true;
                Label10.Enabled = false;
                Label17.Enabled = false;
                ddl_comp1.Enabled = false;
                Label16.Enabled = false;
                txt_srno_lt.Enabled = false;
                Label17.Enabled = false;

                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp.SelectedIndex = 0;
            }
            else if (rbte_site.SelectedIndex == 1)
            {
                Label10.Enabled= true;
                Label17.Enabled = true;
                ddl_comp1.Enabled = true;
                Label16.Enabled = true;
                txt_srno_lt.Enabled = true;
                Label18.Enabled = false;
                Label4.Enabled = false;
                Label8.Enabled = false;
                ddl_comp.Enabled = false;
                Label13.Enabled = false;
                txtmach_serno_rt.Enabled = false;
               

                ddl_comp1.DataSource = DT_comp;
                ddl_comp1.DataValueField = "Comp_id";
                ddl_comp1.DataTextField = "Comp_nm";
                ddl_comp1.DataBind();
                ddl_comp1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp1.SelectedIndex = 0;
            }

            else if (rbte_site.SelectedIndex == 2)
            {
                Label10.Enabled  = true;
                Label17.Enabled = true;
                ddl_comp1.Enabled = true;
                Label16.Enabled = true;
                txt_srno_lt.Enabled = true;
                Label18.Enabled = true;
                Label4.Enabled = true;
                Label8.Enabled = true;
                ddl_comp.Enabled = true;
                Label13.Enabled = true;
                txtmach_serno_rt.Enabled = true;

                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));

                Label10.Enabled  = true;
                ddl_comp1.Enabled  = true;

                ddl_comp1.DataSource = DT_comp;
                ddl_comp1.DataValueField = "Comp_id";
                ddl_comp1.DataTextField = "Comp_nm";
                ddl_comp1.DataBind();
                ddl_comp1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp1.SelectedIndex = 0;
            }
            else
            {
                Label4.Enabled  = true;
                Label8.Enabled = true;
                ddl_comp.Enabled = true;
                Label13.Enabled = true;
                txtmach_serno_rt.Enabled = true;
                Label18.Enabled = true;
                Label10.Enabled = false;
                Label17.Enabled = false;
                ddl_comp1.Enabled = false;
                Label16.Enabled = false;
                txt_srno_lt.Enabled = false;                

                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp.SelectedIndex = 0;
            }

            dr = null;
            cn.Close();
        }
        catch
        {
            //Response.Redirect("~/error.aspx");
        }
        #endregion
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        #region Search
        try
        {
            //lblsale_id.Text = "";
           // btnprt_bil.Visible = true;
            string Ptid = lblptnt_id.Value.ToUpper();
            cmd = new SqlCommand("sp_h_m_sale_search", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_h_m_ptid", Ptid);
            cn.Open();
            cn.executeprocedure(cmd);
            cn.Close();
            DataTable DT1 = new DataTable();
            cn.Open();
            dr = cmd.ExecuteReader();
            DT1.Load(dr);
            rbte_site.Visible = true;
            string A = DT1.Rows[0][2].ToString();
            if (A == "Right")
            {
                rbte_site.SelectedIndex = 0;
                txt_mach.Visible = true;
                Label4.Visible = true;
                lbl_mach_id_rt.Visible = true;
                Label8.Visible = true;
                ddl_comp.Visible = true;
                Label13.Visible = true;
                txtmach_serno_rt.Visible = true;
                txtmach_serno_rt.Text = DT1.Rows[0][8].ToString();
                //ddl_mach_model.Visible = true;
                //ddl_mach_type.Visible = true;
                txt_mach.Text = DT1.Rows[0][4].ToString();
                lbl_mach_id_rt.Value  = DT1.Rows[0][3].ToString();
            }
            else if (A == "Left")
            {
                rbte_site.SelectedIndex = 1;
                txt_mach1.Visible = true;
                Label10.Visible = true;
                lbl_mach_id_lt.Visible = true;
                Label17.Visible = true;
                ddl_comp1.Visible = true;
                Label16.Visible = true;
                txt_srno_lt.Visible = true;
                txtmach_serno_rt.Text = DT1.Rows[0][8].ToString();
                txt_srno_lt.Text = DT1.Rows[0][9].ToString();
                //ddl_model1.Visible = true;
                //ddl_type1.Visible = true;
                txt_mach1.Text = DT1.Rows[0][6].ToString();
                lbl_mach_id_lt.Value  = DT1.Rows[0][5].ToString();

            }
            else
            {
                rbte_site.SelectedIndex = 2;
                txt_mach.Visible = true;
                txt_mach1.Visible = true;
                Label4.Visible = true;
                Label8.Visible = true;
                Label10.Visible = true;
                Label17.Visible = true;
                ddl_comp.Visible = true;
                txtmach_serno_rt.Visible = true;
                txt_srno_lt.Visible = true;
                txt_srno_lt.Text = DT1.Rows[0][9].ToString();
                //ddl_mach_model.Visible = true;
                //ddl_mach_type.Visible = true;
                ddl_comp1.Visible = true;
                //ddl_model1.Visible = true;
                //ddl_type1.Visible = true;
                lbl_mach_id_rt.Visible = true;
                lbl_mach_id_lt.Visible = true;
                txt_mach.Text = DT1.Rows[0][3].ToString();
            }
            //lblsale_id.Text = DT1.Rows[0][0].ToString();
            txtmachprice.Text = DT1.Rows[0][10].ToString();
            txtrecamt.Text = DT1.Rows[0][11].ToString();
            txtdueamt.Text = DT1.Rows[0][12].ToString();
            txtcomment.Text = DT1.Rows[0][13].ToString();
            lbl_mach_id_rt.Value = DT1.Rows[0][3].ToString();
            txtmach_serno_rt.Text = DT1.Rows[0][8].ToString();
            txt_mach.Text = DT1.Rows[0][4].ToString();
            lbl_mach_id_lt.Value  = DT1.Rows[0][5].ToString();
            txt_srno_lt.Text = DT1.Rows[0][9].ToString();
            txt_mach1.Text = DT1.Rows[0][6].ToString();
            //lblmas.Text = DT1.Rows[0][11].ToString();
            string M = DT1.Rows[0][7].ToString();
            if (M == "0")
            {
                rbtem.SelectedIndex = 0;
            }
            else if (M == "1")
            {
                rbtem.SelectedIndex = 1;
            }
            else
            {
                rbtem.SelectedIndex = 2;
            }
            txtDisc.Text = DT1.Rows[0][14].ToString();
            txtVat.Text = DT1.Rows[0][15].ToString();
            dr = null;
            cn.Close();
            //btnEdit.Visible = true;
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Patient Not Match')</script>");
        }
        #endregion
       // btnEdit.Visible = true;
    }
    protected void txtrecamt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            WebService Disco = new WebService();
            double paid, price;
            paid = Convert.ToDouble(txtrecamt.Text);
            price = Convert.ToDouble(txtDV.Text);
            txtdueamt.Text = Disco.Due(price, paid).ToString();
            btnsave.Enabled = true;
            txtdueamt.Focus();
        }
        catch { Response.Redirect("~/error.aspx"); }
    }
    protected void rbtDisc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtDisc.SelectedIndex == 0)
        {
            txtVat.Enabled = true;
            lblVat.Enabled = true;
            lblDisc.Enabled = false;
            txtDisc.Enabled = false;
            txtDisc.Text = "0";
            DisVat();
        }
        else if (rbtDisc.SelectedIndex == 1)
        {
            txtVat.Enabled = true;
            lblVat.Enabled = true;
            lblDisc.Enabled = true;
            txtDisc.Enabled = true;
            //DisVat();
        }
        txtDisc.Focus();
    }
    protected void txtDisc_TextChanged(object sender, EventArgs e)
    {        
        DisVat();
    }
    protected void txtVat_TextChanged(object sender, EventArgs e)
    {
        double Vat = System.Convert.ToDouble(txtVat.Text);
        DisVat();
    }
    public void DisVat()
    {
        #region DisVat
        try
        {
            if (rbtDisc.SelectedIndex == 0)
            {
                WebService Disco = new WebService();
                double Disc = System.Convert.ToDouble(txtDisc.Text);
                double Vat = System.Convert.ToDouble(txtVat.Text);
                double Price = Convert.ToDouble(txtmachprice.Text);
                txtDV.Text = Disco.Disc1(Price, Vat).ToString();
            }
            else if (rbtDisc.SelectedIndex == 1)
            {
                WebService Disco = new WebService();
                double Disc = System.Convert.ToDouble(txtDisc.Text);
                double Vat = System.Convert.ToDouble(txtVat.Text);
                double Price = Convert.ToDouble(txtmachprice.Text);
                txtDV.Text = Disco.Disc(Price, Disc, Vat).ToString();
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
    public void MachVal()
    {
        #region MachVal
        try
        {
            if (lblSale_price.Value == "" && lblSale_price1.Value  == "")
            {
                txtmachprice.Text = "0";
                Response.Write("<script>alert('Select Valid Machine')</script>");
            }
            else if (lblSale_price.Value == "" && lblSale_price1.Value  != "")
            {
                txtmachprice.Text = (Convert.ToDouble(lblSale_price1.Value )).ToString();
            }
            else if (lblSale_price.Value != "" && lblSale_price1.Value  == "")
            {
                txtmachprice.Text = (Convert.ToDouble(lblSale_price.Value )).ToString();
            }
            else if (lblSale_price.Value != "" && lblSale_price1.Value  != "")
            {
                txtmachprice.Text = (Convert.ToDouble(lblSale_price.Value) + Convert.ToDouble(lblSale_price1.Value )).ToString();
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Search
        try
        {
            lblsale_id.Value  = "";
            //btnprt_bil.Visible = true;
            //string Ptid = lblptnt_id.Text.ToUpper();
            double id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            cmd = new SqlCommand("sp_h_m_sale_search1", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_h_m_ptid", id);
            cn.Open();
            cn.executeprocedure(cmd);
            cn.Close();
            DataTable DT1 = new DataTable();
            cn.Open();
            dr = cmd.ExecuteReader();
            DT1.Load(dr);
            rbte_site.Visible = true;
            lblsale_id.Value  = DT1.Rows[0][0].ToString();
            string A = DT1.Rows[0][2].ToString();
            if (A == "Right")
            {
                rbte_site.SelectedIndex = 0;
                txt_mach.Visible = true;
                Label4.Visible = true;
                lbl_mach_id_rt.Visible = true;
                Label8.Visible = true;
                ddl_comp.Visible = true;
                Label13.Visible = true;
                txtmach_serno_rt.Visible = true;
                txtmach_serno_rt.Text = DT1.Rows[0][8].ToString();
                //ddl_mach_model.Visible = true;
                //ddl_mach_type.Visible = true;
                txt_mach.Text = DT1.Rows[0][4].ToString();
                lbl_mach_id_rt.Value  = DT1.Rows[0][3].ToString();
            }
            else if (A == "Left")
            {
                rbte_site.SelectedIndex = 1;
                txt_mach1.Visible = true;
                Label10.Visible = true;
                lbl_mach_id_lt.Visible = true;
                Label17.Visible = true;
                ddl_comp1.Visible = true;
                Label16.Visible = true;
                txt_srno_lt.Visible = true;
                txtmach_serno_rt.Text = DT1.Rows[0][8].ToString();
                txt_srno_lt.Text = DT1.Rows[0][9].ToString();
                //ddl_model1.Visible = true;
                //ddl_type1.Visible = true;
                txt_mach1.Text = DT1.Rows[0][6].ToString();
                lbl_mach_id_lt.Value = DT1.Rows[0][5].ToString();

            }
            else
            {
                rbte_site.SelectedIndex = 2;
                txt_mach.Visible = true;
                txt_mach1.Visible = true;
                Label4.Visible = true;
                Label8.Visible = true;
                Label10.Visible = true;
                Label17.Visible = true;
                ddl_comp.Visible = true;
                txtmach_serno_rt.Visible = true;
                txt_srno_lt.Visible = true;
                txt_srno_lt.Text = DT1.Rows[0][9].ToString();
                //ddl_mach_model.Visible = true;
                //ddl_mach_type.Visible = true;
                ddl_comp1.Visible = true;
                //ddl_model1.Visible = true;
                //ddl_type1.Visible = true;
                lbl_mach_id_rt.Visible = true;
                lbl_mach_id_lt.Visible = true;
                txt_mach.Text = DT1.Rows[0][3].ToString();
            }
            //lblsale_id.Text = DT1.Rows[0][0].ToString();
            txtmachprice.Text = DT1.Rows[0][10].ToString();
            txtrecamt.Text = DT1.Rows[0][11].ToString();
            txtdueamt.Text = DT1.Rows[0][12].ToString();
            txtcomment.Text = DT1.Rows[0][13].ToString();
            lbl_mach_id_rt.Value  = DT1.Rows[0][3].ToString();
            txtmach_serno_rt.Text = DT1.Rows[0][8].ToString();
            txt_mach.Text = DT1.Rows[0][4].ToString();
            lbl_mach_id_lt.Value  = DT1.Rows[0][5].ToString();
            txt_srno_lt.Text = DT1.Rows[0][9].ToString();
            txt_mach1.Text = DT1.Rows[0][6].ToString();
            //lblmas.Text = DT1.Rows[0][11].ToString();
            string M = DT1.Rows[0][7].ToString();
            if (M == "0")
            {
                rbtem.SelectedIndex = 0;
            }
            else if (M == "1")
            {
                rbtem.SelectedIndex = 1;
            }
            else
            {
                rbtem.SelectedIndex = 2;
            }
            txtDisc.Text = DT1.Rows[0][14].ToString();
            txtVat.Text = DT1.Rows[0][15].ToString();
            dr = null;
            cn.Close();
           // btnEdit.Visible = true;
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Patient Not Match')</script>");
        }
        #endregion
        //btnEdit.Visible = true;
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        double pid = System.Convert.ToInt32(lblsale_id.Value);
        double Mach_id = System.Convert.ToInt32(lbl_mach_id_rt.Value);
        cmd = new SqlCommand("sp_h_m_sale_delete", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@p_h_m_ptid", pid);
        cmd.Parameters.AddWithValue("@p_h_mach_id", Mach_id);
        cn.Open();
        cn.executeprocedure(cmd);
        cn.Close();
    }
    //protected void txtDV_TextChanged(object sender, EventArgs e)
    //{
    //    //double Dis_Amt = Convert.ToDouble(txtDV.Text);
    //    //double Sale_Price = Convert.ToDouble(txtmachprice.Text);
    //    ////double Disc_val = Convert.ToDouble(Sale_Price - Dis_Amt);
    //    //double Per = ((Sale_Price - Dis_Amt) / Sale_Price) * 100;
    //    //txtDisc.Visible = true;
    //    //txtDisc.Text = Convert.ToString(Per);       
    //}
    protected void txtmachprice_TextChanged(object sender, EventArgs e)
    {
         DisVat();
         txtrecamt.Focus();
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/h_mach_sale_Grid.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        int billno = Convert.ToInt32(lblsale_id.Value);
        Response.Redirect("~/h_m_Chll.aspx?bill_no=" + billno);
    }
}
