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

public partial class TempCat : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    double id;
    SqlDataAdapter da;
    DataSet ds;
    int IsAct, cr_by, MsgID;
    string Flag, TmpCat,MsgBody;
    DateTime fromdt, todt;
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
            cn = new connection();
            #region Loading
            if (!IsPostBack)
            {
                cn.Open();
                ddlMsgCat.Items.Clear();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_MsgCat_ddl";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "MessageCat");

                DataTable DT1 = new DataTable();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                ddlMsgCat.DataSource = DT1;
                ddlMsgCat.DataValueField = "CATID";
                ddlMsgCat.DataTextField = "Description";
                ddlMsgCat.DataBind();
                ddlMsgCat.Items.Insert(0, new ListItem("Select", "Description"));
                ddlMsgCat.SelectedIndex = 0;
                dr = null;

                CLEAR();
                Select();
            }
            #endregion            
        }
        }
    }
    public void Select()
    {
        if (Request.QueryString["TempCat_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["TempCat_Id"].ToString());
                double CatID = System.Convert.ToInt32(id1);

                cn.Open();
                cmd = new SqlCommand("tbl_MsgTempCat_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pTempCat_Id", CatID);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbl_Temp_id.Value = DT1.Rows[0][0].ToString();
                txtMsgBody.Text = DT1.Rows[0][1].ToString();
                ddlMsgCat.SelectedValue = DT1.Rows[0][3].ToString();
                string Checkd = DT1.Rows[0][2].ToString();
                if (Checkd=="True")
                {
                    ChkIsAct.Checked = true;
                }
                else
                {
                    ChkIsAct.Checked = false;
                }
                txtdate.Text = DT1.Rows[0][4].ToString();
                lblto_date.Text = DT1.Rows[0][5].ToString();
                dr = null;
                cn.Close();
               // btn_save.Text = "Edit";
                btn_save.Enabled = false;
            }
            catch
            { }

            #endregion
        }
    }
    public void CLEAR()
    {
       // txt_TempDesc.Focus();
        //txt_TempDesc.Text = "";   
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if(btn_save.Text=="Edit")
        {
            #region Edit
            try
            {                
                string MsgTempID = lbl_Temp_id.Value;
                MsgID = Convert.ToInt32(ddlMsgCat.SelectedValue);
                cr_by = Convert.ToInt32(Session["Name"].ToString());
                fromdt = System.Convert.ToDateTime(txtdate.Text);
                todt = System.Convert.ToDateTime(lblto_date.Text);
                if (ChkIsAct.Checked == true)
                {
                    IsAct = 1;
                }
                else
                {
                    IsAct = 0;
                }
                MsgBody = txtMsgBody.Text;
                Flag = "E";
                cn.Open();
                cmd = new SqlCommand("MSGTemplate_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pMSGTEMPID", MsgTempID);
                cmd.Parameters.AddWithValue("@pCATID", MsgID);
                cmd.Parameters.AddWithValue("@pFromdate", fromdt.Date);
                cmd.Parameters.AddWithValue("@pTODATE", todt.Date);
                cmd.Parameters.AddWithValue("@pMSGBody", MsgBody);
                cmd.Parameters.AddWithValue("@pIsActive", IsAct);
                cmd.Parameters.AddWithValue("@pUSERID", cr_by);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Write("<script>alert('Record is Update')</script>");
                Response.Redirect("TempCat_Grig.aspx");
                btn_save.Text = "Save";
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
                if (ddlMsgCat.SelectedItem.Text  == "")
                {
                    Response.Write("<script language='JavaScript'>alert('Please Type Valid Template Description')</script>");
                }
                else
                {
                    MsgID = Convert.ToInt32(ddlMsgCat.SelectedValue);
                    cr_by = Convert.ToInt32(Session["Name"].ToString());
                    fromdt = System.Convert.ToDateTime(txtdate.Text);
                    todt = System.Convert.ToDateTime(lblto_date.Text);
                    if(ChkIsAct.Checked==true )
                    {
                         IsAct=1;
                    }
                    else
                    {
                         IsAct=0;
                    }
                    MsgBody = txtMsgBody.Text;
                    int MsgTempID = 0;
                    Flag = "I";
                    cn.Open();
                    cmd = new SqlCommand("MSGTemplate_c", connection.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pFlag", Flag);
                    cmd.Parameters.AddWithValue("@pMSGTEMPID", MsgTempID);
                    cmd.Parameters.AddWithValue("@pCATID", MsgID);
                    cmd.Parameters.AddWithValue("@pFromdate", fromdt.Date);
                    cmd.Parameters.AddWithValue("@pTODATE", todt.Date);
                    cmd.Parameters.AddWithValue("@pMSGBody", MsgBody);
                    cmd.Parameters.AddWithValue("@pIsActive", IsAct);                    
                    cmd.Parameters.AddWithValue("@pUSERID", cr_by);
                    cn.executeprocedure(cmd);
                    cn.Close();

                    Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                    btn_save.Enabled = false;
                    CLEAR();
                    Response.Redirect("TempCat_Grig.aspx");
                }

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
        Response.Redirect("~/TempCat_Grig.aspx");
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtMsgBody.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }  
    
    protected void txt_TempDesc_TextChanged(object sender, EventArgs e)
    {
        #region Massage Description Exists
        MsgBody = txtMsgBody.Text.Trim();
        cmd = new SqlCommand("sp_MsgCat_Id_Search", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@p_MsgDesc", MsgBody);
        cn.executeprocedure(cmd);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "MSGTemplate");
        if (ds.Tables["MSGTemplate"].Rows.Count > 0)
        {
           // lblMsg.Visible = true;
            btn_save.Enabled = false;
        }
        else
        {
            //lblMsg.Visible = false;
            btn_save.Enabled = true;
        }
        #endregion
    }
}
