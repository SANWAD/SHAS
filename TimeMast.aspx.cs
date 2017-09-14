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

public partial class TimeMast : System.Web.UI.Page
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
            CLEAR();
            cn.Open();
           // if (Request.QueryString["Time_Id"].ToString() != "0")
           // {
                //#region Select
                //try
                //{
                //    string id1;
                //    id1 = (Request.QueryString["Time_Id"].ToString());
                //    double CtrID = System.Convert.ToInt32(id1);
                   
                //    cn.Open();
                //    cmd = new SqlCommand("tbl_Center_Select", connection.con);
                //    cmd.CommandType = CommandType.StoredProcedure;                    
                //    cmd.Parameters.AddWithValue("@pTime_id", CtrID);                   
                //    cn.executeprocedure(cmd);
                //    DataTable DT1 = new DataTable();
                //    cn.Open();
                //    dr = cmd.ExecuteReader();
                //    DT1.Load(dr); 
                //    lbl_ac_id.Value= DT1.Rows[0][0].ToString();
                //    lbl_ac_id1.Text = DT1.Rows[0][1].ToString();
                //    dr = null;
                //    cn.Close();
                //    lbl_ac_id1.Enabled = false;
                //    btn_save.Text = "Edit";                    
                //}
                //catch
                //{ }
                //#endregion
           // }
        }
        }
    }   
    public void CLEAR()
    {
        txtApt_time.Text = "";
        txtApt_time.Focus();    
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if(btn_save.Text=="Edit")
        {
            #region Edit
            try
            {
                int time_id = Convert.ToInt32(lblTime_id.Value);
                string Apt_Time = txtApt_time.Text.ToUpper();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("Time_mast_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@ptime_id", time_id);
                cmd.Parameters.AddWithValue("@pApt_Time", Apt_Time);
                //cmd.Parameters.AddWithValue("@p_created_by", cr_by);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Write("<script>alert('Record is Update')</script>");
                //Response.Redirect("TimeMast_Grid.aspx");
                btn_save.Text = "SAVE";                
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
            int time_id = 0;
            string Apt_Time = txtApt_time.Text.ToUpper();
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("Time_mast_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ptime_id", time_id);
            cmd.Parameters.AddWithValue("@pApt_Time", Apt_Time);
            //cmd.Parameters.AddWithValue("@p_created_by", cr_by);
            cn.executeprocedure(cmd);
            cn.Close();
            Response.Write("<script>alert('Record is Update')</script>");
            //Response.Redirect("TimeMast_Grid.aspx");
            btn_save.Text = "SAVE";                
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
        Response.Redirect("centerMast_Grid.aspx");
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtApt_time.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }
}
