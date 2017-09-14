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

public partial class MenuDetail : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    double id;
    SqlDataAdapter da;
    SqlDataReader dr1;
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
            cn.Open();
            //sp_User_DDL 
            #region Loading
            if (!IsPostBack)
            {
                cn.Open();
                ddlUser.Items.Clear();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_User_DDL";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "tbl_user_master");

                DataTable DT2 = new DataTable();
                dr1 = cmd.ExecuteReader();
                DT2.Load(dr1);
                ddlUser.DataSource = DT2;
                ddlUser.DataValueField = "USER_ID";
                ddlUser.DataTextField = "user_nm";
                ddlUser.DataBind();
                ddlUser.Items.Insert(0, new ListItem("Select", "user_nm"));
                ddlUser.SelectedIndex = 0;
                dr1 = null;               
                cn.Close();
            }
            #endregion
        }
      }
    }   
    public void CLEAR()
    {
        //txt_ac_desc.Focus();
        //txt_ac_desc.Text = "";
        //lbl_ac_id1.Focus();        
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if(btn_save.Text=="Edit")
        {
            #region Edit
            try
            {
                //string Center = txt_ac_desc.Text.ToUpper();
                //string CtrCode = lbl_ac_id1.Text;
                //string CtrID = lbl_ac_id.Value;
                ////int cr_by = Convert.ToInt32(Session["Name"].ToString());
                //string Flag = "E";
                //cn.Open();
                //cmd = new SqlCommand("tbl_Center_master_c", connection.con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@pFlag", Flag);
                //cmd.Parameters.AddWithValue("@pCntr_id", CtrID);
                //cmd.Parameters.AddWithValue("@pCntrCode", CtrCode);
                //cmd.Parameters.AddWithValue("@pCntr_Nm", Center);
                //// cmd.Parameters.AddWithValue("@p_created_by", cr_by);
                //cn.executeprocedure(cmd);
                //cn.Close();
                //Response.Write("<script>alert('Record is Update')</script>");
                //Response.Redirect("centerMast_Grid.aspx");
                //btn_save.Text = "Save";                
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
           // if (txt_ac_desc.Text=="")
           // {
           //     Response.Write("<script language='JavaScript'>alert('Please Type Valid Center Code,Center Name')</script>");
           // }
           // else
           // {
           // string Center = txt_ac_desc.Text.ToUpper();
           //// string CtrCode = lbl_ac_id1.Text.ToUpper();
           // int CtrID = 0;
           // //int cr_by = Convert.ToInt32(Session["Name"].ToString());
           // string Flag = "I";
           // cn.Open();
           // cmd = new SqlCommand("tbl_Center_master_c", connection.con);
           // cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@pFlag", Flag);
           // cmd.Parameters.AddWithValue("@pCntr_id", CtrID);
           // //cmd.Parameters.AddWithValue("@pCntrCode", CtrCode);
           // cmd.Parameters.AddWithValue("@pCntr_Nm", Center);
           //// cmd.Parameters.AddWithValue("@p_created_by", cr_by);
           // cn.executeprocedure(cmd);
           // cn.Close();            
           // Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
           // btn_save.Enabled = false;
           // CLEAR();
           // Response.Redirect("centerMast_Grid.aspx");
           // }
           
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is not save')</script>");
        }
        #endregion
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuDetail.aspx");
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //if (txt_ac_desc.Text == "")
        //    args.IsValid = false;
        //else
        //    args.IsValid = true;
    }
    protected void txt_ac_desc_TextChanged(object sender, EventArgs e)
    {
        //#region Acc Exists
        //string Cntr_nm = txt_ac_desc.Text.Trim();

        //cmd = new SqlCommand("sp_Cntr_Id_Search", connection.con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@pCntr_nm", Cntr_nm);

        //cn.executeprocedure(cmd);
        //da = new SqlDataAdapter(cmd);
        //ds = new DataSet();
        //da.Fill(ds, "tbl_Center_master");
        //if (ds.Tables["tbl_Center_master"].Rows.Count > 0)
        //{
        //    lblMsg.Visible = true;
        //    btn_save.Enabled = false;
        //}
        //else
        //{
        //    lblMsg.Visible = false;
        //    btn_save.Enabled = true;
        //}
        //#endregion
    }
}
