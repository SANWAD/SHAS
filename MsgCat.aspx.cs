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

public partial class MsgCat : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    double id;
    SqlDataAdapter da;
    DataSet ds;
    int IsAct, cr_by;
    string Flag, MassCat;
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
        if (Request.QueryString["Msg_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Msg_Id"].ToString());
                double CatID = System.Convert.ToInt32(id1);

                cn.Open();
                cmd = new SqlCommand("tbl_MsgCat_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pCat_id", CatID);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbl_Msg_id.Value = DT1.Rows[0][0].ToString();
                txt_MsgDesc.Text = DT1.Rows[0][1].ToString();
                string Chkd=DT1.Rows[0][2].ToString();
                if (Chkd=="True")
                {
                    ChkIsAct.Checked = true;
                }
                else
                {
                    ChkIsAct.Checked = false;
                }                
                dr = null;
                cn.Close();
                btn_save.Text = "Edit";
            }
            catch
            { }

            #endregion
        }
    }
    public void CLEAR()
    {
        txt_MsgDesc.Focus();
        txt_MsgDesc.Text = "";   
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if(btn_save.Text=="Edit")
        {
            #region Edit
            try
            {
                MassCat = txt_MsgDesc.Text.ToUpper();
                string MsgID = lbl_Msg_id.Value;
                cr_by = Convert.ToInt32(Session["Name"].ToString());
                if (ChkIsAct.Checked == true)
                {
                    IsAct = 1;
                }
                else
                {
                    IsAct = 0;
                }         
                Flag = "E";
                cn.Open();
                cmd = new SqlCommand("MessageCat_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pCATID", MsgID);
                cmd.Parameters.AddWithValue("@pDescription", MassCat);
                cmd.Parameters.AddWithValue("@pIsActive", IsAct);
                cmd.Parameters.AddWithValue("@pUSERID", cr_by);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Write("<script>alert('Record is Update')</script>");
                Response.Redirect("MsgCat_Grig.aspx");
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
                if (txt_MsgDesc.Text == "")
                {
                    Response.Write("<script language='JavaScript'>alert('Please Type Valid Massage Description')</script>");
                }
                else
                {
                    MassCat = txt_MsgDesc.Text.ToUpper();
                    cr_by = Convert.ToInt32(Session["Name"].ToString());
                    if(ChkIsAct.Checked==true )
                    {
                         IsAct=1;
                    }
                    else
                    {
                         IsAct=0;
                    }                   
                    int MsgID = 0;
                    Flag = "I";
                    cn.Open();
                    cmd = new SqlCommand("MessageCat_c", connection.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pFlag", Flag);
                    cmd.Parameters.AddWithValue("@pCATID", MsgID);
                    cmd.Parameters.AddWithValue("@pDescription", MassCat);
                    cmd.Parameters.AddWithValue("@pIsActive", IsAct);
                    cmd.Parameters.AddWithValue("@pUSERID", cr_by);
                    cn.executeprocedure(cmd);
                    cn.Close();

                    Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                    btn_save.Enabled = false;
                    CLEAR();
                    Response.Redirect("MsgCat_Grig.aspx");
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
        Response.Redirect("~/MsgCat_Grig.aspx");
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txt_MsgDesc.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }    
    protected void txt_MsgDesc_TextChanged(object sender, EventArgs e)
    {
        #region Massage Description Exists
        MassCat = txt_MsgDesc.Text.Trim();
        cmd = new SqlCommand("sp_MsgCat_Id_Search", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@p_MsgDesc", MassCat);
        cn.executeprocedure(cmd);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "MessageCat");
        if (ds.Tables["MessageCat"].Rows.Count > 0)
        {
            lblMsg.Visible = true;
            btn_save.Enabled = false;
        }
        else
        {
            lblMsg.Visible = false;
            btn_save.Enabled = true;
        }
        #endregion
    }
}
