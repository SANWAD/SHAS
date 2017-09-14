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

public partial class centerMaster : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    double id;
    SqlDataAdapter da;
    DataSet ds;
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
            CLEAR();
            Select();
        }
        }
    }
    public void Select()
    {
        if (Request.QueryString["Cent_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Cent_Id"].ToString());
                double CtrID = System.Convert.ToInt32(id1);

                cn.Open();
                cmd = new SqlCommand("tbl_Center_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pCntr_id", CtrID);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbl_ac_id.Value = DT1.Rows[0][0].ToString();
                lbl_ac_id1.Text = DT1.Rows[0][1].ToString();
                txt_ac_desc.Text = DT1.Rows[0][2].ToString();
                dr = null;
                cn.Close();
                lbl_ac_id1.Enabled = false;
                btn_save.Text = "Edit";
            }
            catch
            { }

            #endregion
        }
    }
    public void CLEAR()
    {
        txt_ac_desc.Focus();
        txt_ac_desc.Text = "";
        lbl_ac_id1.Focus();        
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if(btn_save.Text=="Edit")
        {
            #region Edit
            try
            {
                string Center = txt_ac_desc.Text.ToUpper();
                string CtrCode = lbl_ac_id1.Text;
                string CtrID = lbl_ac_id.Value;
                //int cr_by = Convert.ToInt32(Session["Name"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_Center_master_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pCntr_id", CtrID);
                //cmd.Parameters.AddWithValue("@pCntrCode", CtrCode);
                cmd.Parameters.AddWithValue("@pCntr_Nm", Center);
                // cmd.Parameters.AddWithValue("@p_created_by", cr_by);
                cn.executeprocedure(cmd);
                cn.Close();               
                btn_save.Text = "Save";
                btn_save.Enabled = false;
                Response.Write("<script>alert('Record is Update')</script>");
                Response.Redirect("centerMast_Grid.aspx");                               
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is not Update')</script>");
            }
            #endregion
        }
        else
        {
        #region Save
        try
        {
            if (txt_ac_desc.Text=="")
            {
                Response.Write("<script language='JavaScript'>alert('Please Type Valid Center Code,Center Name')</script>");
            }
            else
            {
            string Center = txt_ac_desc.Text.ToUpper();
           // string CtrCode = lbl_ac_id1.Text.ToUpper();
            int CtrID = 0;
            //int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_Center_master_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@pCntr_id", CtrID);
            //cmd.Parameters.AddWithValue("@pCntrCode", CtrCode);
            cmd.Parameters.AddWithValue("@pCntr_Nm", Center);
           // cmd.Parameters.AddWithValue("@p_created_by", cr_by);
             //int a=cn.executeprocedure(cmd);
            cn.executeprocedure(cmd);
            cn.Close();
            btn_save.Enabled = false;
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");            
            CLEAR();
            Response.Redirect("centerMast_Grid.aspx");
            }           
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
        Response.Redirect("CenterMaster.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("CenterMaster.aspx");
    }
    protected void BtnStock_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/Transaction/AccStock.aspx");
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/centerMast_Grid.aspx");
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txt_ac_desc.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void txt_ac_desc_TextChanged(object sender, EventArgs e)
    {
        #region Acc Exists
        string Cntr_Nm = txt_ac_desc.Text.Trim();
        int Center_Id = Convert.ToInt32(Session["Cntr_id"].ToString());
        cmd = new SqlCommand("sp_Cntr_Id_Search", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@pCntr_Nm", Cntr_Nm);
        //cmd.Parameters.AddWithValue("@pCntr_id", Center_Id);
        cn.executeprocedure(cmd);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "tbl_Center_master");
        if (ds.Tables["tbl_Center_master"].Rows.Count > 0)
        {
            lblMsg.Visible = true;
            btn_save.Enabled = false;
            txt_ac_desc.Focus();
        }
        else
        {
            lblMsg.Visible = false;
            btn_save.Enabled = true;
            btn_save.Focus();
        }
        #endregion
    }
}
