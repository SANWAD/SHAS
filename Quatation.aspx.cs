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
using System.Web.UI.WebControls.Adapters;

public partial class Quatation : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    double id;
    SqlDataReader dr;
    SqlDataAdapter da;
    DataSet ds;
    int a;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
           cn = new connection();
           WebService Disco = new WebService();
           PtntNm.ContextKey = Session["Cntr_id"].ToString();
            if (!IsPostBack)
            {
                txtptnt_nm.Focus();
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
        if (Request.QueryString["Quot_id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Quot_id"].ToString());
                double QuatId = System.Convert.ToInt32(id1);
                cn.Open();
                cmd = new SqlCommand("tbl_quatation_Sel", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pQuat_id", QuatId);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblquat_id.Value = DT1.Rows[0][0].ToString();
                txtptnt_nm.Text = DT1.Rows[0][1].ToString();
                lblptnt_id.Value = DT1.Rows[0][8].ToString();
                txt_mach.Text = DT1.Rows[0][2].ToString();
                lblmach_id.Value = DT1.Rows[0][9].ToString();
                txtmachprice.Text = DT1.Rows[0][5].ToString();
                string Site=DT1.Rows[0][3].ToString().Trim();
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
                
                //txtaudrat.Text=DT1.Rows[0][4].ToString();
                txtvat.Text = DT1.Rows[0][6].ToString();
                txttot.Text = DT1.Rows[0][7].ToString();
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
    public void Clear()
    {
        lblptnt_id.Value = "";
        lblmach_id.Value = "";
        txtptnt_nm.Text = "";
        rbte_site.SelectedIndex = -1;
        //txtaudrat.Text = "";
        txtmachprice.Text = "";
        txtvat.Text = "";
        txttot.Text = "";
        txt_mach.Text = "";
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
            catch { /*Response.Redirect("~/error.aspx"); */}
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
                ddl_mach_type.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_mach_type.DataBind();
                dr = null;
                cn.Close();
                ddl_mach_type.Enabled  = true;
                ddl_mach_type.Focus();
            }
            catch { /*Response.Redirect("~/error.aspx");*/ }
            #endregion
        }
    }
    protected void ddl_mach_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type.SelectedIndex > 0)
        {
            #region Machine Final            
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
                txt_mach.Enabled = false;
                txt_mach.Text = (System.Convert.ToString(ddl_mach_type.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_comp.SelectedItem.Text));
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                txtmachprice.Text = ds.Tables["tbl_machine_master"].Rows[0][1].ToString();
                lblmach_id.Value  = machid;                
            }
            #endregion
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (btnsave.Text == "Edit")
        {
            #region Edit
            try
            {
                int quat_id = Convert.ToInt32(lblquat_id.Value);
                int ptnt_id =Convert.ToInt32(lblptnt_id.Value);
                int mach_id = Convert.ToInt32(lblmach_id.Value);
                string ear_site = rbte_site.SelectedItem.Text.ToString();
                //string aud_ratio = txtaudrat.Text.ToString();
                double price;
                if (txtmachprice.Text == "")
                {
                    price = 0;
                }
                else
                {
                    price = Convert.ToDouble(txtmachprice.Text);
                }
                double vat;
                if (txtvat.Text == "")
                {
                    vat = 0;
                }
                else
                {
                    vat = Convert.ToDouble(txtvat.Text);
                }
                double tot;
                if (txttot.Text == "")
                {
                    tot = 0;
                }
                else
                {
                    tot = Convert.ToDouble(txttot.Text);
                }
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_quatation_tr_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pquat_id", quat_id);
                cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                cmd.Parameters.AddWithValue("@pmach_id", mach_id);
                cmd.Parameters.AddWithValue("@pquat_ear_site", ear_site);
                //cmd.Parameters.AddWithValue("@pquat_audio_ratio", aud_ratio);
                cmd.Parameters.AddWithValue("@pprice", price);
                cmd.Parameters.AddWithValue("@pvat", vat);
                cmd.Parameters.AddWithValue("@ptotal", tot);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("Quatation_Grid.aspx");
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                btnsave.Enabled = false;               
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
                int quat_id = 0;
                string ptnt_nm1 = txtptnt_nm.Text;
                string[] WordArray = ptnt_nm1.Split('-');
                string Name = WordArray[0].ToString();
                lblptnt_id.Value = WordArray[1];
                int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
                int mach_id = Convert.ToInt32(lblmach_id.Value);
                string ear_site = rbte_site.SelectedItem.Text.ToString();
                //string aud_ratio = txtaudrat.Text.ToString();
                string MachTxt = txt_mach.Text;
                string MachTxt1 = txt_mach1.Text;
                double price, price1;
                if (txtmachprice.Text == "")
                {
                    price = 0;
                }
                else
                {
                    price = Convert.ToDouble(txtmachprice.Text);
                }
                if (txtmachprice1.Text == "")
                {
                    price1 = 0;
                }
                else
                {
                    price1 = Convert.ToDouble(txtmachprice1.Text);
                }
                double vat;
                if (txtvat.Text == "")
                {
                    vat = 0;
                }
                else
                {
                    vat = Convert.ToDouble(txtvat.Text);
                }
                double tot;
                if (txttot.Text == "")
                {
                    tot = 0;
                }
                else
                {
                    tot = Convert.ToDouble(txttot.Text);
                }
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_quatation_tr_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pquat_id", quat_id);
                cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                cmd.Parameters.AddWithValue("@pmach_id", mach_id);
                cmd.Parameters.AddWithValue("@pquat_ear_site", ear_site);
               // cmd.Parameters.AddWithValue("@pquat_audio_ratio", aud_ratio);
                cmd.Parameters.AddWithValue("@pprice", price);
                cmd.Parameters.AddWithValue("@pvat", vat);
                cmd.Parameters.AddWithValue("@ptotal", tot);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cmd.Parameters.AddWithValue("@pMachTxt", MachTxt);
                cmd.Parameters.AddWithValue("@pMachTxt1", MachTxt1);
                cmd.Parameters.AddWithValue("@pprice1", price1);
                a=cn.executeprocedure(cmd);
                lblquat_id.Value  = a.ToString();
                cn.Close(); 
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    print();
                }
                else
                {                    
                    Response.Redirect("~/Quatation_Grid.aspx");
                }
                btnsave.Enabled = false;
                btnPrint.Enabled = true;
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
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
    protected void btn_cal_Click(object sender, EventArgs e)
    {
        #region VAT
        double price = Convert.ToDouble(txtmachprice.Text);
        double vat;
        vat = price * 0.0 / 100;
        txtvat.Text = Convert.ToString(vat);
        txttot.Text = Convert.ToString(vat + price);
        //btnsave.Enabled = true;
        #endregion
    }   
    protected void txtmachprice_TextChanged(object sender, EventArgs e)
    {
        #region VAT1
        double price = Convert.ToDouble(txtmachprice.Text);
        double vat, V;
        V = Convert.ToDouble(txtvat.Text);
        if (V >= 0)
        {
            vat = (price * V) / 100;
            txttot.Text = Convert.ToString(vat + price);
        }
        else
        {
            txttot.Text = txtmachprice.Text;
            //Response.Write("<script language='JavaScript'>alert('Type Vat you Want')</script>");
        }
        #endregion
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Quatation_Grid.aspx");
    }
    protected void txtptnt_nm_TextChanged(object sender, EventArgs e)
    {
        string ABC=txtptnt_nm.Text;
        WebService Disco = new WebService();        
      // int id = Convert.ToInt32(Disco.PatientSearch(ABC, int id));
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        print();
    }
    public void print()
    {
        if (lblquat_id.Value != "")
        {
            int billno = Convert.ToInt32(lblquat_id.Value);
            Response.Redirect("~/quat.aspx?bill_no=" + billno);
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
                Label4.Enabled = true;
                Label8.Enabled = true;
                ddl_comp.Enabled = true;
                Label17.Enabled = false;
                ddl_comp1.Enabled = false;
                Label17.Enabled = false;
                txtmachprice.Enabled = true;
                ddl_comp1.Enabled = false;
                ddl_model1.Enabled = false;
                ddl_type1.Enabled = false;

                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp.SelectedIndex = 0;
            }
            else if (rbte_site.SelectedIndex == 1)
            {
                Label17.Enabled = true;
                ddl_comp1.Enabled = true;
                Label4.Enabled = false;
                Label8.Enabled = false;
                ddl_comp.Enabled = false;
                txtmachprice1.Enabled = true;
                ddl_comp1.Enabled = true;
                ddl_model1.Enabled = true;
                ddl_type1.Enabled = true;


                ddl_comp1.DataSource = DT_comp;
                ddl_comp1.DataValueField = "Comp_id";
                ddl_comp1.DataTextField = "Comp_nm";
                ddl_comp1.DataBind();
                ddl_comp1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp1.SelectedIndex = 0;
            }

            else if (rbte_site.SelectedIndex == 2)
            {
               // Label10.Enabled = true;
                Label17.Enabled = true;
                ddl_comp1.Enabled = true;
                //Label16.Enabled = true;
                //txt_srno_lt.Enabled = true;
                //Label18.Enabled = true;
                Label4.Enabled = true;
                Label8.Enabled = true;
                ddl_comp.Enabled = true;
               // Label13.Enabled = true;
                //txtmach_serno_rt.Enabled = true;
                txtmachprice.Enabled = true;
                txtmachprice1.Enabled = true;
                ddl_comp1.Enabled = true;
                ddl_model1.Enabled = true;
                ddl_type1.Enabled = true;

                ddl_comp.DataSource = DT_comp;
                ddl_comp.DataValueField = "Comp_id";
                ddl_comp.DataTextField = "Comp_nm";
                ddl_comp.DataBind();
                ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));

                //Label10.Enabled = true;
                ddl_comp1.Enabled = true;

                ddl_comp1.DataSource = DT_comp;
                ddl_comp1.DataValueField = "Comp_id";
                ddl_comp1.DataTextField = "Comp_nm";
                ddl_comp1.DataBind();
                ddl_comp1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_comp1.SelectedIndex = 0;
            }
            else
            {
                Label4.Enabled = true;
                Label8.Enabled = true;
                ddl_comp.Enabled = true;
                //Label13.Enabled = true;
                //txtmach_serno_rt.Enabled = true;
                //Label18.Enabled = true;
                //Label10.Enabled = false;
                Label17.Enabled = false;
                ddl_comp1.Enabled = false;
                //Label16.Enabled = false;
                //txt_srno_lt.Enabled = false;

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
                ddl_model1.Enabled = true;
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
                ddl_type1.Enabled = true;
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
                txtmachprice1.Text  = ds.Tables["tbl_machine_master"].Rows[0][1].ToString();
                lblQty1.Text = ds.Tables["tbl_machine_master"].Rows[0][2].ToString();
                int Qty1 = Convert.ToInt32(lblQty1.Text);
                if (Qty1 > 0)
                { }
                else
                {
                    Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
                }
               // MachVal();
            }            
            #endregion
           // txttot.Text = (Convert.ToInt32((txtmachprice.Text)) + Convert.ToInt32((txtmachprice1.Text))).ToString();
        }
    }
    protected void txtvat_TextChanged(object sender, EventArgs e)
    { 
        
    }
}