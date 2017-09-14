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

public partial class Ear_Mould : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    double id;
    SqlDataReader dr;

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
                Clear();
                Select();                
            }
        }
    }
    public void Clear()
    {
        lbleMould_id.Value = "";
        lblptnt_id.Value = "";       
        txtdt.Text = "";
        rbte_site.SelectedIndex = -1;
        txtprice.Text = "";
        txtrecamt.Text = "";
        txtremamt.Text = "";
        txtcomment.Text = "";
    }
    public void Select()
    {
        if (Request.QueryString["Mould_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Mould_Id"].ToString());
                double mould_id = System.Convert.ToInt32(id1); 
                cn.Open();
                cmd = new SqlCommand("tbl_ear_mould_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pmould_id", mould_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbleMould_id.Value= DT1.Rows[0][0].ToString();
                lblptnt_id.Value = DT1.Rows[0][1].ToString();
                string Site= DT1.Rows[0][3].ToString();
                if (Site == "Right")
                {
                    rbte_site.SelectedIndex = 0;
                }
                else if (Site == "Left")
                {
                    rbte_site.SelectedIndex = 1;
                }
                else
                {
                    rbte_site.SelectedIndex = 2;
                }
                txtprice.Text = DT1.Rows[0][4].ToString();
                txtdt.Text = DT1.Rows[0][9].ToString();
                txtrecamt.Text = DT1.Rows[0][5].ToString();
                txtremamt.Text = DT1.Rows[0][6].ToString();
                txtcomment.Text = DT1.Rows[0][7].ToString();
                txtPtnt_nm.Text = DT1.Rows[0][10].ToString();
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
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (char.IsNumber(txtprice.Text, 0))
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (char.IsNumber(txtrecamt.Text, 0))
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (char.IsNumber(txtremamt.Text, 0))
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if(btnsave.Text=="Edit")
        {
            #region Edit
            try
            {
                int mould_id = Convert.ToInt32(lbleMould_id.Value );
                int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
                DateTime emr = System.Convert.ToDateTime(txtdt.Text);
                string esite = rbte_site.SelectedItem.Text.ToString();
                double price = System.Convert.ToDouble(txtprice.Text);
                double recamt = System.Convert.ToDouble(txtrecamt.Text);
                double rem = System.Convert.ToDouble(txtremamt.Text);
                string comm = txtcomment.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_ear_mould_tr_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pmould_id", mould_id);
                cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                cmd.Parameters.AddWithValue("@pem_return_dt", emr);
                cmd.Parameters.AddWithValue("@pem_ear_site", esite);
                cmd.Parameters.AddWithValue("@pem_price", price);
                cmd.Parameters.AddWithValue("@pem_rec_amt", recamt);
                cmd.Parameters.AddWithValue("@pem_due_amt", rem);
                cmd.Parameters.AddWithValue("@pcomment", comm);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Clear();
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                Response.Redirect("earmould_Grid.aspx");                
            }
            catch
            {
                // Response.Redirect("~/error.aspx");
            }
            #endregion
        }
        else
        {
        #region Save
        try
        {
            int mould_id = 0;
            string ptnt_nm1 = txtPtnt_nm.Text;
            string[] WordArray = ptnt_nm1.Split('-');
            string Name = WordArray[0].ToString();
            lblptnt_id.Value = WordArray[1];
            int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
            DateTime emr = DateTime.ParseExact(txtdt.Text, "dd/MM/yyyy", null);
            string esite = rbte_site.SelectedItem.Text.ToString();
            double price = System.Convert.ToDouble(txtprice.Text);
            double recamt = System.Convert.ToDouble(txtrecamt.Text);
            double rem=System.Convert.ToDouble(txtremamt.Text);
            string comm = txtcomment.Text.ToString();
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_ear_mould_tr_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@pmould_id", mould_id); 
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@pem_return_dt", emr);
            cmd.Parameters.AddWithValue("@pem_ear_site", esite);
            cmd.Parameters.AddWithValue("@pem_price", price);
            cmd.Parameters.AddWithValue("@pem_rec_amt", recamt);
            cmd.Parameters.AddWithValue("@pem_due_amt", rem);
            cmd.Parameters.AddWithValue("@pcomment", comm);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            int a=cn.executeprocedure(cmd);
            lbleMould_id.Value = a.ToString();
            cn.Close();
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                print();
            }
            else
            {
                Response.Redirect("~/earmould_Grid.aspx");
            }
            Clear();
            btnPrint.Enabled = true;
            btnsave.Enabled = false;
        }
        catch
        {
           // Response.Redirect("~/error.aspx");
        }
        #endregion

        }
    }
    protected void btn_cal_Click(object sender, EventArgs e)
    {
        double price = System.Convert.ToDouble(txtprice.Text);
        double paid = System.Convert.ToDouble(txtrecamt.Text);
        double rem;
        rem = price - paid;
        txtremamt.Text = System.Convert.ToString(rem);
        //btnsave.Enabled = true;
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/earmould_Grid.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        print();
    }
    public void print()
    {
        if (lbleMould_id.Value != "")
        {
            int billno = Convert.ToInt32(lbleMould_id.Value);
            Response.Redirect("~/ear_mould_rpt.aspx?bill_no=" + billno);
        }
    }
}
