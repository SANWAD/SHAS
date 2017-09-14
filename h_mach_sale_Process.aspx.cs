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

public partial class h_mach_sale_Process : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlDataReader dr;
    connection cn;
    DataSet ds;
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
            cn = new connection();
            PtntNm.ContextKey = Session["Cntr_id"].ToString();
            if (!IsPostBack)
            {
                rbte_site.Enabled = false;
                Label4.Enabled = false;
                Label8.Enabled = false;
                ddl_comp.Enabled = false;
                ddl_mach_model.Enabled = false;
                ddl_mach_type.Enabled = false;
                txt_mach.Enabled = false;
                lblmas.Enabled = false;
                Label5.Enabled = false;
                Label18.Enabled = false;
                Label19.Enabled = false;
                Label10.Enabled = false;
                ddl_comp1.Enabled = false;
                ddl_model1.Enabled = false;
                ddl_type1.Enabled = false;
                txt_mach1.Enabled = false;
                btnsave.Enabled = true;
                Select();
            }
        }
    }
    public void Select()
    {
        if (Request.QueryString["sale_Pro_id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["sale_Pro_id"].ToString());
                double SaleId = System.Convert.ToInt32(id1);

                cn.Open();
                cmd = new SqlCommand("tbl_HM_Sale_pro_Id", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_Hm_sale_id", SaleId);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblsale_id.Value = DT1.Rows[0][0].ToString();
                Ptnt_Nm.Text = DT1.Rows[0][2].ToString();
                lblptnt_id.Value = DT1.Rows[0][16].ToString();
                ddl_complete.Text = DT1.Rows[0][3].ToString();
                int M = Convert.ToInt32(DT1.Rows[0][9].ToString());
                if(M==0)
                {
                    rbtem.SelectedIndex = 0;
                }
                else if (M == 1)
                {
                    rbtem.SelectedIndex = 1;
                }
                else if (M == 2)
                {
                    rbtem.SelectedIndex = 2;
                }
                else if (M == 3)
                {
                    rbtem.SelectedIndex = 3;
                }
                else
                {
                    rbtem.SelectedIndex = 4;
                }
                rbtem.SelectedValue = DT1.Rows[0][9].ToString();
                lbl_mach_id_rt.Value = DT1.Rows[0][5].ToString();
                txt_mach.Text = DT1.Rows[0][6].ToString();
                lbl_mach_id_lt.Value = DT1.Rows[0][7].ToString();
                txt_mach1.Text = DT1.Rows[0][8].ToString();
                txtrecamt.Text = DT1.Rows[0][11].ToString();
                txtdueamt.Text = DT1.Rows[0][12].ToString();
                txtcomment.Text = DT1.Rows[0][13].ToString();               
                lblmas.Text = DT1.Rows[0][14].ToString();
                txtDate.Text = DT1.Rows[0][15].ToString();
                txtmachprice.Text = DT1.Rows[0][10].ToString();
                string Site = DT1.Rows[0][4].ToString().Trim();
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
                //txtDisc.Text = DT1.Rows[0][13].ToString();
                //txtVat.Text = DT1.Rows[0][14].ToString();
                dr = null;
                cn.Close();
                btnsave.Text = "Edit";
               // btnPrint.Enabled = true;
            }
            catch
            { }

            #endregion
        }

    }
    public void Clear()
    {
 
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
            catch { Response.Redirect("~/error.aspx"); }
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
    protected void ddl_mach_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type.SelectedIndex > 0)
        {
            #region Machine Final
            txt_mach.Visible = true;
            txt_mach.Text = RemoveAllWhitespace
                (System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_mach_type.SelectedItem.Text));
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
                lblPrice.Value = ds.Tables["tbl_machine_master"].Rows[0][1].ToString();
                string Price = ds.Tables["tbl_machine_master"].Rows[0][1].ToString();
                txtmachprice.Text = Price.ToString();
                lbl_mach_id_rt.Value  = machid;                
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
    protected void btnsave_Click(object sender, EventArgs e)
    {
        #region Save
        try
        {
            if(btnsave.Text=="Edit" )
            {
            int def = 0;
            int hm_mach_id_rt;
            string Trial = ddl_complete.Text.ToString();
            int hm_mach_id_lt;
            if (lbl_mach_id_rt.Value  == "")
            { hm_mach_id_rt = def; }
            else
            { hm_mach_id_rt = Convert.ToInt32(lbl_mach_id_rt.Value); }
            if (lbl_mach_id_lt.Value  == "")
            { hm_mach_id_lt = def; }
            else { hm_mach_id_lt = Convert.ToInt32(lbl_mach_id_lt.Value ); }
            int hmsale_id = Convert.ToInt32(lblsale_id.Value);
            double paid_chg = Convert.ToDouble(txtrecamt.Text);
            int dueamt = Convert.ToInt32(txtdueamt.Text);
            string comm = txtcomment.Text.ToString();
            //string ptnt_nm1 = Ptnt_Nm.Text;
            //string[] WordArray = ptnt_nm1.Split('-');
            string Name = Ptnt_Nm.Text;
            //lblptnt_id.Value = WordArray[1];
            int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
            string hm_sale_ear_site = rbte_site.SelectedItem.Text.ToString();
            string hm_nm_rt = txt_mach.Text.ToString();
            string hm_nm_lt = txt_mach1.Text.ToString();
            int hm_sale_ear_mould_to = rbtem.SelectedIndex;
            double hm_sale_mach_price_rt = Convert.ToDouble(txtmachprice.Text);
            string Msg = lblmas.Text.ToString();
            DateTime visit_Dt = Convert.ToDateTime(txtDate.Text);
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "E";
            cn.Open();
            cmd = new SqlCommand("tbl_hm_sale_trn_Process_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@phm_sale_id", hmsale_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@phm_Trial", Trial);
            cmd.Parameters.AddWithValue("@phm_sale_ear_site", hm_sale_ear_site);
            cmd.Parameters.AddWithValue("@phm_mach_id_rt", hm_mach_id_rt);
            cmd.Parameters.AddWithValue("@phm_nm_rt", hm_nm_rt);
            cmd.Parameters.AddWithValue("@phm_mach_id_lt", hm_mach_id_lt);
            cmd.Parameters.AddWithValue("@phm_nm_lt", hm_nm_lt);
            cmd.Parameters.AddWithValue("@phm_sale_ear_mould_to", hm_sale_ear_mould_to);
            cmd.Parameters.AddWithValue("@phm_sale_mach_price_rt", hm_sale_mach_price_rt);
            cmd.Parameters.AddWithValue("@ph_m_sale_paid_charg", paid_chg);
            cmd.Parameters.AddWithValue("@ph_m_sale_due_charg", dueamt);
            cmd.Parameters.AddWithValue("@ph_m_sale_comment", comm);
            cmd.Parameters.AddWithValue("@pMsg", Msg);
            cmd.Parameters.AddWithValue("@pvisit_Dt", visit_Dt);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cn.executeprocedure(cmd);
            cn.Close();
            Response.Redirect("~/h_mach_sale_Process_Grid.aspx");
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
           // btnprt_bil.Enabled = true;
        }
        else
        {
            int def = 0;
            int hm_mach_id_rt;
            string Trial = ddl_complete.Text.ToString();
            int hm_mach_id_lt;
            if (lbl_mach_id_rt.Value  == "")
            { hm_mach_id_rt = def; }
            else
            { hm_mach_id_rt = Convert.ToInt32(lbl_mach_id_rt.Value); }
            if (lbl_mach_id_lt.Value  == "")
            { hm_mach_id_lt = def; }
            else { hm_mach_id_lt = Convert.ToInt32(lbl_mach_id_lt.Value ); }
            int hmsale_id = 0;
            double paid_chg = Convert.ToDouble(txtrecamt.Text);
            //int dueamt = Convert.ToInt32(txtdueamt.Text);
            int dueamt = Convert.ToInt32(txtdueamt.Text);
            string comm = txtcomment.Text.ToString();
            string ptnt_nm1 = Ptnt_Nm.Text;
            string[] WordArray = ptnt_nm1.Split('-');
            string Name = WordArray[0].ToString();
            lblptnt_id.Value = WordArray[1];
            int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
            string hm_sale_ear_site = rbte_site.SelectedItem.Text.ToString();
            string hm_nm_rt = txt_mach.Text.ToString();
            string hm_nm_lt = txt_mach1.Text.ToString();
            int hm_sale_ear_mould_to = rbtem.SelectedIndex;
            double hm_sale_mach_price_rt = Convert.ToDouble(txtmachprice.Text);
            string Msg = lblmas.Text.ToString();
            DateTime visit_Dt = Convert.ToDateTime(txtDate.Text);
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_hm_sale_trn_Process_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@phm_sale_id", hmsale_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@phm_Trial", Trial);
            cmd.Parameters.AddWithValue("@phm_sale_ear_site", hm_sale_ear_site);
            cmd.Parameters.AddWithValue("@phm_mach_id_rt", hm_mach_id_rt);
            cmd.Parameters.AddWithValue("@phm_nm_rt", hm_nm_rt);
            cmd.Parameters.AddWithValue("@phm_mach_id_lt", hm_mach_id_lt);
            cmd.Parameters.AddWithValue("@phm_nm_lt", hm_nm_lt);
            cmd.Parameters.AddWithValue("@phm_sale_ear_mould_to", hm_sale_ear_mould_to);
            cmd.Parameters.AddWithValue("@phm_sale_mach_price_rt", hm_sale_mach_price_rt);
            cmd.Parameters.AddWithValue("@ph_m_sale_paid_charg", paid_chg);
            cmd.Parameters.AddWithValue("@ph_m_sale_due_charg", dueamt);
            cmd.Parameters.AddWithValue("@ph_m_sale_comment", comm);
            cmd.Parameters.AddWithValue("@pMsg", Msg);
            cmd.Parameters.AddWithValue("@pvisit_Dt", visit_Dt);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cn.executeprocedure(cmd);
            cn.Close();
            Response.Redirect("~/h_mach_sale_Process_Grid.aspx");
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
           // btnprt_bil.Enabled = true;
         }
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
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
        }
        catch { Response.Redirect("~/error.aspx"); }
    }
    protected void btnprt_bil_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Transaction/h_m_bill_Process.aspx");
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
                //string Mach_Desc = ddl_comp1.SelectedItem.Text;
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
                ddl_model1.Items.Insert(0, new ListItem("Select", "mach_model"));
                ddl_model1.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_model1.Enabled  = true;
                ddl_model1.Focus();
            }
            catch { Response.Redirect("~/error.aspx"); }
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
                ddl_type1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_type1.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_type1.Enabled  = true;
                ddl_type1.Focus();
            }
            catch {/* Response.Redirect("~/error.aspx");*/ }
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
                txt_mach1.Enabled = false;
                txt_mach1.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp1.SelectedItem.Text + "," + ddl_model1.SelectedItem.Text + "," + ddl_type1.SelectedItem.Text));
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                lblPrice1.Value = ds.Tables["tbl_machine_master"].Rows[0][1].ToString();
                //string Price1 = ds.Tables["tbl_machine_master"].Rows[0][1].ToString();
                double p1 = Convert.ToDouble(lblPrice1.Value);
                double p = Convert.ToDouble(lblPrice.Value);
                double SumPrice = (p1 + p);
                txtmachprice.Text = SumPrice.ToString();
                lbl_mach_id_lt.Value  = machid;
            }            
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
                Label19.Enabled = false;
                ddl_comp.Enabled = true;
                lblmas.Enabled = true;
                Label10.Enabled = false;
                ddl_comp1.Enabled = false;
                
                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp.SelectedIndex = 0;
            }
            else if (rbte_site.SelectedIndex == 1)
            {
                Label10.Enabled = true;
                ddl_comp1.Enabled = true;
                Label4.Enabled = false;
                Label18.Enabled = false;
                ddl_comp.Enabled = false;
                lblmas.Enabled = false;

                ddl_comp1.DataSource = DT_comp;
                ddl_comp1.DataValueField = "Comp_id";
                ddl_comp1.DataTextField = "Comp_nm";
                ddl_comp1.DataBind();
                ddl_comp1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp1.SelectedIndex = 0;
            }

            else
            {
                Label10.Enabled  = true;
                ddl_comp1.Enabled = true;
                Label4.Enabled = true;
                Label8.Enabled = true;
                ddl_comp.Enabled = true;
                lblmas.Enabled = true; 
                Label10.Enabled = true;
                ddl_comp1.Enabled = true;

                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));

                ddl_comp1.DataSource = DT_comp;
                ddl_comp1.DataValueField = "Comp_id";
                ddl_comp1.DataTextField = "Comp_nm";
                ddl_comp1.DataBind();
                ddl_comp1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp1.SelectedIndex = 0;
            }
            dr = null;
            cn.Close();
            ddl_comp.Focus();
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
        #endregion
    }

    protected void ddl_complete_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_complete.SelectedIndex > 0)
        {
            rbte_site.Enabled = true;
            rbte_site.Focus();
            Label5.Enabled = true;           
        }
    }
    protected void rbtdoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtem.SelectedIndex == 0 && rbtdoc.SelectedIndex == 0)
        {
            lblmas.Visible = true;
            lblmas.Text = "If all Part is Complete Go for Hearing Aid Sale Bill Printing Option";
        }
        else
        {
            lblmas.Visible = false;
            lblmas.Text = "";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        #region Search
        try
        {
            string Ptid = lblptnt_id.Value.ToUpper();
            cmd = new SqlCommand("sp_h_m_sale_process_search", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_h_m_ptid", Ptid);
            cn.Open();
            cn.executeprocedure(cmd);
            cn.Close();
            DataTable DT1 = new DataTable();
            cn.Open();
            dr = cmd.ExecuteReader();
            DT1.Load(dr);
            string C = DT1.Rows[0][0].ToString();

            if (C == "Complete")
            {
                ddl_complete.SelectedIndex = 1;
            }
            else
            {
                ddl_complete.SelectedIndex = 0;
            }
            rbte_site.Visible = true;
            string A = DT1.Rows[0][1].ToString();
            if (A == "Right")
            {
                rbte_site.SelectedIndex = 0;
                txt_mach.Visible = true;
                Label4.Visible = true;
                lbl_mach_id_rt.Visible = true;
                Label8.Visible = true;
                ddl_comp.Visible = true;
                txt_mach.Text = DT1.Rows[0][3].ToString();
                lbl_mach_id_rt.Value  = DT1.Rows[0][2].ToString();
            }
            else if (A == "Left")
            {
                rbte_site.SelectedIndex = 1;
                txt_mach1.Visible = true;
                Label10.Visible = true;
                ddl_comp1.Visible = true;
                txt_mach1.Text = DT1.Rows[0][5].ToString();
                lbl_mach_id_lt.Value  = DT1.Rows[0][4].ToString();
            }
            else
            {
                rbte_site.SelectedIndex = 2;
                txt_mach.Visible = true;
                txt_mach1.Visible = true;
                Label4.Visible = true;
                Label8.Visible = true;
                Label10.Visible = true;
                ddl_comp.Visible = true;
                ddl_comp1.Visible = true;
                lbl_mach_id_rt.Visible = true;
                lbl_mach_id_lt.Visible = true;
                txt_mach.Text = DT1.Rows[0][3].ToString();
            }
            txtmachprice.Text = DT1.Rows[0][7].ToString();
            txtrecamt.Text = DT1.Rows[0][8].ToString();
            txtdueamt.Text = DT1.Rows[0][9].ToString();
            txtcomment.Text = DT1.Rows[0][10].ToString();
            lblmas.Text = DT1.Rows[0][11].ToString();
            string M = DT1.Rows[0][6].ToString();
            if (M == "0")
            {
                rbtem.SelectedIndex = 0;
                rbtdoc.SelectedIndex = 0;
                lblmas.Visible = true;
            }
            else
            {
                rbtem.SelectedIndex = 1;
                rbtdoc.SelectedIndex = 1;
            }
            dr = null;
            cn.Close();
            //btnUpdate.Visible = true;
        }

        catch
        {
            Response.Write("<script language='JavaScript'>alert('Accesories Not Match')</script>");
        }

        #endregion

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        #region Update
        //try
        //{
        //    int def = 0;
        //    int hm_mach_id_rt;
        //    string Trial = ddl_complete.Text.ToString();
        //    int hm_mach_id_lt;
        //    if (lbl_mach_id_rt.Value  == "")
        //    { hm_mach_id_rt = def; }
        //    else
        //    { hm_mach_id_rt = Convert.ToInt32(lbl_mach_id_rt.Value ); }
        //    if (lbl_mach_id_lt.Value  == "")
        //    { hm_mach_id_lt = def; }
        //    else { hm_mach_id_lt = Convert.ToInt32(lbl_mach_id_lt.Value ); }
        //    int ptnt_id = Convert.ToInt32(lblptnt_id.Value );
        //    double paid_chg = Convert.ToDouble(txtrecamt.Text);
        //    int dueamt = Convert.ToInt32(txtdueamt.Text);
        //    string comm = txtcomment.Text.ToString();
        //    string hm_sale_ear_site = rbte_site.SelectedItem.Text.ToString();
        //    string hm_nm_rt = txt_mach.Text.ToString();
        //    string hm_nm_lt = txt_mach1.Text.ToString();
        //    int hm_sale_ear_mould_to = rbtem.SelectedIndex;
        //    double hm_sale_mach_price_rt = Convert.ToDouble(txtmachprice.Text);
        //    string Msg = lblmas.Text.ToString();
        //    DateTime visit_Dt = Convert.ToDateTime(txtDate.Text);
        //    string cr_by = Session["Name"].ToString(); ;
        //    cn.Open();
        //    cmd = new SqlCommand("sp_h_m_sale_process_Update", connection.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@p_hm_trial", Trial);
        //    cmd.Parameters.AddWithValue("@p_ptnt_id", ptnt_id);
        //    cmd.Parameters.AddWithValue("@p_hm_sale_ear_site", hm_sale_ear_site);
        //    cmd.Parameters.AddWithValue("@p_hm_mach_id_rt", hm_mach_id_rt);
        //    cmd.Parameters.AddWithValue("@p_hm_nm_rt", hm_nm_rt);
        //    cmd.Parameters.AddWithValue("@p_hm_mach_id_lt", hm_mach_id_lt);
        //    cmd.Parameters.AddWithValue("@p_hm_nm_lt", hm_nm_lt);
        //    cmd.Parameters.AddWithValue("@p_hm_sale_ear_mould_to", hm_sale_ear_mould_to);
        //    cmd.Parameters.AddWithValue("@p_hm_sale_mach_price_rt", hm_sale_mach_price_rt);
        //    cmd.Parameters.AddWithValue("@p_h_m_sale_paid_charg", paid_chg);
        //    cmd.Parameters.AddWithValue("@p_h_m_sale_due_charg", dueamt);
        //    cmd.Parameters.AddWithValue("@p_h_m_sale_comment", comm);
        //    cmd.Parameters.AddWithValue("@p_h_m_Msg", Msg);
        //    cmd.Parameters.AddWithValue("@p_hm_visit", visit_Dt);
        //    cmd.Parameters.AddWithValue("@p_created_by", cr_by);
        //    cn.executeprocedure(cmd);
        //    cn.Close();
        //    Response.Write("<script language='JavaScript'>alert('Record is Update Succesfuly')</script>");
        //}
        //catch
        //{
        //    Response.Write("<script language='JavaScript'>alert('Record is Not Update')</script>");
        //    //Response.Redirect("~/error.aspx");
        //}
        #endregion
    }

    protected void txtrecamt_TextChanged(object sender, EventArgs e)
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
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/h_mach_sale_Process_Grid.aspx");
    }
}
