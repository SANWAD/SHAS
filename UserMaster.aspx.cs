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

public partial class UserMaster : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    DataSet ds;
    SqlDataAdapter da, da1;
    SqlDataReader dr,dr1,dr2;
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
                LoadPage();
                Select();               
            }
        }
    }
    public void LoadPage()
    {
        #region Loading
        cn.Open();
        ddlCent_Nm.Items.Clear();
        cmd = connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "sp_Center_nm";
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "tbl_Center_master");

        DataTable DT2 = new DataTable();
        dr1 = cmd.ExecuteReader();
        DT2.Load(dr1);
        ddlCent_Nm.DataSource = DT2;
        ddlCent_Nm.DataValueField = "Cntr_id";
        ddlCent_Nm.DataTextField = "Cntr_Nm";
        ddlCent_Nm.DataBind();
        ddlCent_Nm.Items.Insert(0, new ListItem("Select", "Cntr_Nm"));
        dr1 = null;

        ddlUser_type.Items.Clear();
        cmd = connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "sp_User_DDL1";
        DataTable DT3 = new DataTable();
        dr2 = cmd.ExecuteReader();
        DT3.Load(dr2);
        ddlUser_type.DataSource = DT3;
        ddlUser_type.DataValueField = "UserTypeId";
        ddlUser_type.DataTextField = "USerType";
        ddlUser_type.DataBind();
        ddlUser_type.Items.Insert(0, new ListItem("Select", "USerType"));
        dr2 = null;
        cn.Close();
        #endregion                
    }
    public void Select()
    {
        #region Select
        if (Request.QueryString["User_Id"].ToString() != "0")
        {
            CLEAR();            
            try
            {
                string id1;
                id1 = (Request.QueryString["User_Id"].ToString());
                double UserID = System.Convert.ToInt32(id1);

                cn.Open();
                cmd = new SqlCommand("tbl_User_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pUser_id", UserID);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbl_user_id.Value = DT1.Rows[0][0].ToString();
                // lbl_User_id1.Text = DT1.Rows[0][1].ToString();
                txt_User_desc.Text = DT1.Rows[0][2].ToString();
                txtUserPwd.Text = DT1.Rows[0][2].ToString();
                ddlCent_Nm.SelectedValue = DT1.Rows[0][2].ToString();
                ddlUser_type.SelectedValue = DT1.Rows[0][2].ToString();
                dr = null;
                cn.Close();
                btn_save.Text = "Edit";
            }
            catch
            { }
        }
        #endregion
    }
    public void CLEAR()
    {       
        txt_User_desc.Text = "";
        txt_User_desc.Focus();
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if(btn_save.Text=="Edit")
        {
            #region Edit
            try
            {
                if (txtUserPwd.Text == txtConPwd.Text)
                {
                    string User_Nm = txt_User_desc.Text.ToUpper();
                    string User_Pwd = txtUserPwd.Text.ToUpper();
                    int CenterCode = Convert.ToInt32(ddlCent_Nm.SelectedValue);
                    //string UserCode = lbl_User_id1.Text;
                    string UserID = lbl_user_id.Value;
                    string UserCon_Pwd = txtConPwd.Text;
                    string Tele = txtTelphone.Text;
                    string Email = txtEmail.Text;
                    int Sha_Mitra;
                    if (rbtn_svn_mitr.SelectedItem.Text == "Yes")
                    {
                        Sha_Mitra = 1;
                    }
                    else
                    {
                        Sha_Mitra = 0;
                    }            
                    int User_Type = Convert.ToInt32(ddlUser_type.SelectedValue);
                    int cr_by = Convert.ToInt32(Session["Name"].ToString());
                    int IsActive;
                    if (ChkIsActive.Checked == true)
                    {
                        IsActive = 1;
                    }
                    else
                    {
                        IsActive = 0;
                    } 
                    string Flag = "E";
                    cn.Open();
                    cmd = new SqlCommand("tbl_user_master_c", connection.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@@pFlag", Flag);
                    cmd.Parameters.AddWithValue("@pUSER_ID", UserID);
                    //cmd.Parameters.AddWithValue("@pCntrCode", UserCode);
                    cmd.Parameters.AddWithValue("@puser_nm", User_Nm);
                    cmd.Parameters.AddWithValue("@puser_pwd", User_Pwd);
                    cmd.Parameters.AddWithValue("@puser_tel", Tele);
                    cmd.Parameters.AddWithValue("@puser_email", Email);
                    cmd.Parameters.AddWithValue("@pis_svn_mitr", Sha_Mitra);
                    cmd.Parameters.AddWithValue("@pUserTypeId", User_Type);
                    cmd.Parameters.AddWithValue("@pCent_Code", CenterCode);
                    cmd.Parameters.AddWithValue("@pIsactive", IsActive);
                    cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                    cn.executeprocedure(cmd);
                    cn.Close();
                    Response.Write("<script>alert('Record is Update')</script>");
                    Response.Redirect("UserMast_Grid.aspx");
                    CLEAR();                    
                    btn_save.Text = "SAVE";
                }
                else
                {
                    Response.Write("<script language='JavaScript'>alert('Type Correct Password Or Password is Not Match')</script>");
                }
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
            if(txtUserPwd.Text==txtConPwd.Text)
            {
            string User_Nm = txt_User_desc.Text.ToUpper();
            string User_Pwd = txtUserPwd.Text;
            string UserCon_Pwd = txtConPwd.Text;
            string Tele = txtTelphone.Text;
            string Email = txtEmail.Text;
            int CenterCode = Convert.ToInt32(ddlCent_Nm.SelectedValue);
            //string UserCode = lbl_User_id1.Text.ToUpper();
            int UserID = 0;
            int Sha_Mitra;
            if (rbtn_svn_mitr.SelectedItem.Text == "Yes")
            {
                Sha_Mitra = 1;
            }
            else 
            {
                Sha_Mitra = 0;
            }            
            int User_Type=Convert.ToInt32(ddlUser_type.SelectedValue);
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int IsActive;
            if (ChkIsActive.Checked==true)
            {
                IsActive = 1;
            }
            else
            {
                IsActive = 0;
            } 
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_user_master_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@pUSER_ID", UserID);
            //cmd.Parameters.AddWithValue("@pUserCode", UserCode);
            cmd.Parameters.AddWithValue("@puser_nm", User_Nm);
            cmd.Parameters.AddWithValue("@puser_pwd", User_Pwd);
            cmd.Parameters.AddWithValue("@puser_tel", Tele);
            cmd.Parameters.AddWithValue("@puser_email", Email);
            cmd.Parameters.AddWithValue("@pis_svn_mitr", Sha_Mitra);
            cmd.Parameters.AddWithValue("@pUserTypeId", User_Type);
            cmd.Parameters.AddWithValue("@pCent_Code", CenterCode);
            cmd.Parameters.AddWithValue("@pIsactive", IsActive);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cn.executeprocedure(cmd);
            cn.Close();            
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
            btn_save.Enabled = false;
            CLEAR();
            Response.Redirect("UserMast_Grid.aspx");
            }
            else 
            {
                Response.Write("<script language='JavaScript'>alert('Type Correct Password Or Password is Not Match')</script>");
            }
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('')</script>");
        }
        #endregion
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserMast_Grid.aspx");
    }
}
