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

public partial class DoctorMaster : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
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
                Clear();
                txtDoc_Code.Enabled = false;
                Select();
            }
        }
    }
    public void Clear()
    {
        txtdocnm.Focus();
        lbldoc_id.Value = "";
        txtdocnm.Text = "";
        txtdocadd.Text = "";
        txttelno.Text = "";
        txtmobno.Text = "";
        txtalttelno.Text = "";
        txtemailid.Text = "";
    }
    public void Select()
    {
        if (Request.QueryString["Doc_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Doc_Id"].ToString());
                double doc_id = System.Convert.ToInt32(id1);              
                cn.Open();
                cmd = new SqlCommand("tbl_doc_mast_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@pdoc_id", doc_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbldoc_id.Value  = DT1.Rows[0][0].ToString();
                txtdocnm.Text = DT1.Rows[0][1].ToString();
                txtDoc_Code.Text  = DT1.Rows[0][9].ToString();
                txtdocadd.Text = DT1.Rows[0][2].ToString();
                txttelno.Text = DT1.Rows[0][3].ToString();
                txtmobno.Text = DT1.Rows[0][4].ToString();
                txtalttelno.Text = DT1.Rows[0][5].ToString();
                txtemailid.Text = DT1.Rows[0][6].ToString();
                txtDoc_Code.Enabled = false;
                dr = null;
                cn.Close();
                btnsave.Text = "Edit";
            }
            catch
            { }
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
                int doc_id = Convert.ToInt32(lbldoc_id.Value);
                //string doc_Code = txtDoc_Code.Text.ToUpper();
                string doc_nm = txtdocnm.Text.ToString().ToUpper();
                string add = txtdocadd.Text.ToString();
                double mob = System.Convert.ToDouble(txtmobno.Text);
                double tel = System.Convert.ToDouble(txttelno.Text);
                string alt_no = txtalttelno.Text.ToString();
                string email = txtemailid.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                string Flag = "E";
                int cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.Open();
                cmd = new SqlCommand("tbl_doc_master_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pdoc_id", doc_id);
                //cmd.Parameters.AddWithValue("@pdoc_Code", doc_Code);
                cmd.Parameters.AddWithValue("@pdoc_nm", doc_nm);
                cmd.Parameters.AddWithValue("@pcntr_id", cntr_id);
                cmd.Parameters.AddWithValue("@pdoc_add", add);
                cmd.Parameters.AddWithValue("@pdoc_tel", tel);
                cmd.Parameters.AddWithValue("@pdoc_mob", mob);
                cmd.Parameters.AddWithValue("@pdoc_alt_tel", alt_no);
                cmd.Parameters.AddWithValue("@pdoc_email", email);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                Response.Redirect("Doctor_Directory_Grid.aspx");
                btnsave.Enabled = false;
                Clear();
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
                int doc_id = 0;
                //string doc_Code = txtDoc_Code.Text.ToUpper();
                string doc_nm = txtdocnm.Text.ToString().ToUpper();
                string add = txtdocadd.Text.ToString();
                double mob = System.Convert.ToDouble(txtmobno.Text);
                double tel = System.Convert.ToDouble(txttelno.Text);
                string alt_no = txtalttelno.Text.ToString();
                string email = txtemailid.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                string Flag = "I";
                int cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.Open();
                cmd = new SqlCommand("tbl_doc_master_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pdoc_id", doc_id);
                //cmd.Parameters.AddWithValue("@pdoc_Code", doc_Code);
                cmd.Parameters.AddWithValue("@pdoc_nm", doc_nm);
                cmd.Parameters.AddWithValue("@pcntr_id", cntr_id);
                cmd.Parameters.AddWithValue("@pdoc_add", add);
                cmd.Parameters.AddWithValue("@pdoc_tel", tel);
                cmd.Parameters.AddWithValue("@pdoc_mob", mob);
                cmd.Parameters.AddWithValue("@pdoc_alt_tel", alt_no);
                cmd.Parameters.AddWithValue("@pdoc_email", email);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cn.executeprocedure(cmd);
                cn.Close();                
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                Response.Redirect("Doctor_Directory_Grid.aspx");
                btnsave.Enabled = false;
                Clear();
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is not save')</script>");
            }
            #endregion
        }        
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtmobno.Text.Length >= 9 && char.IsNumber(txtmobno.Text, 0))

            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txttelno.Text.Length >= 9 && char.IsNumber(txttelno.Text, 0))
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("DoctorMaster.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Doctor_Directory_Grid.aspx");
    }
    protected void txtdocnm_TextChanged(object sender, EventArgs e)
    {
        #region Doctor Name Exists
        string Ptnt_nm = txtdocnm.Text.Trim();
        int Center_Id = Convert.ToInt32(Session["Cntr_id"].ToString());

        cmd = new SqlCommand("sp_Doc_Id_Search", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@pDoc_name", Ptnt_nm);
        cmd.Parameters.AddWithValue("@pCntr_id", Center_Id);

        cn.executeprocedure(cmd);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "tbl_doc_master");
        if (ds.Tables["tbl_doc_master"].Rows.Count > 0)
        {
            lblMsg.Visible = true;
            btnsave.Enabled = false;
            txtdocnm.Focus();
        }
        else
        {
            lblMsg.Visible = false;
            btnsave.Enabled = true;
            txtdocadd.Focus();
        }
        #endregion
    }
}
