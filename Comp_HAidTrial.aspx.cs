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
public partial class Comp_HAidTrial : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
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
                Select();
            }
        }
    }
    public void Select()
    {
        if (Request.QueryString["Trial_id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Trial_id"].ToString());
                double Trial_No = System.Convert.ToInt32(id1);
                cn.Open();
                cmd = new SqlCommand("tbl_Comp_Trial_trn_Id", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pTrial_No", Trial_No);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);

                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblTriaMach_No.Value = DT1.Rows[0][0].ToString();
                txtComp_Name.Text = DT1.Rows[0][1].ToString();
                txtModel_Name.Text = DT1.Rows[0][2].ToString();
                txtHAid_Type.Text = DT1.Rows[0][3].ToString();
                txtRec_Qty.Text = DT1.Rows[0][4].ToString();
                txtRet_Qty.Text = DT1.Rows[0][5].ToString();
                txtHAid_Stock.Text = DT1.Rows[0][6].ToString();
                txtRea_HAid.Text = DT1.Rows[0][7].ToString();
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
        lblTriaMach_No.Value = "";
        txtComp_Name.Text = "";
        txtModel_Name.Text = "";
        txtHAid_Type.Text = "";
        txtRec_Qty.Text = "";
        txtRet_Qty.Text = "";
        txtHAid_Stock.Text = "";
        txtComp_Name.Focus();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (btnsave.Text == "Edit")
        {
            #region Edit
            try
            {
                int Trial_No = Convert.ToInt32(lblTriaMach_No.Value);
                string Comp_Name = txtComp_Name.Text.ToString();
                string Model_Name = txtModel_Name.Text.ToString();
                string HAid_Type = txtHAid_Type.Text.ToString();
                int Rec_Qty = Convert.ToInt32(txtRec_Qty.Text.ToString());
                int Ret_Qty = Convert.ToInt32(txtRet_Qty.Text.ToString());
                int Haid_Stock = Convert.ToInt32(txtHAid_Stock.Text);
                string Rea_HAid = txtRea_HAid.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_Comp_Trial_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pTrial_No", Trial_No);
                cmd.Parameters.AddWithValue("@pComp_Name", Comp_Name);
                cmd.Parameters.AddWithValue("@pModel_Name", Model_Name);
                cmd.Parameters.AddWithValue("@pHAid_Type", HAid_Type);
                cmd.Parameters.AddWithValue("@pRec_Qty", Rec_Qty);
                cmd.Parameters.AddWithValue("@pRet_Qty", Ret_Qty);
                cmd.Parameters.AddWithValue("@pHaid_Stock", Haid_Stock);
                cmd.Parameters.AddWithValue("@pRea_HAid", Rea_HAid);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("Comp_HAidTrial_Grid.aspx");
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                //btnsave.Enabled = false;
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
                int Trial_No = 0;
                string Comp_Name = txtComp_Name.Text.ToString();
                string Model_Name = txtModel_Name.Text.ToString();
                string HAid_Type = txtHAid_Type.Text.ToString();
                int Rec_Qty = Convert.ToInt32(txtRec_Qty.Text);
                int Ret_Qty = Convert.ToInt32(txtRet_Qty.Text);
                int Haid_Stock = Convert.ToInt32(txtHAid_Stock.Text);
                string Rea_HAid = txtRea_HAid.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_Comp_Trial_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pTrial_No", Trial_No);
                cmd.Parameters.AddWithValue("@pComp_Name", Comp_Name);
                cmd.Parameters.AddWithValue("@pModel_Name", Model_Name);
                cmd.Parameters.AddWithValue("@pHAid_Type", HAid_Type);
                cmd.Parameters.AddWithValue("@pRec_Qty", Rec_Qty);
                cmd.Parameters.AddWithValue("@pRet_Qty", Ret_Qty);
                cmd.Parameters.AddWithValue("@pHaid_Stock", Haid_Stock);
                cmd.Parameters.AddWithValue("@pRea_HAid", Rea_HAid);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("Comp_HAidTrial_Grid.aspx");
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                //btnsave.Enabled = false;
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
            }
            #endregion
        }       
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Comp_HAidTrial_Grid.aspx");
    }   
}
