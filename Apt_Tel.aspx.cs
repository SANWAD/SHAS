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

public partial class Apt_Tel : System.Web.UI.Page
{
    SqlCommand cmd, cmd1, cmd2, cmd3;
    SqlDataReader dr, dr1, dr2, dr3, dr4, dr5,dr6;
    connection cn;
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
                #region Page Load Event
                cn.Open();
                ddltype.Items.Clear();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_Ptnt_Apt_ddl";
                DataTable DT1 = new DataTable();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                ddltype.DataSource = DT1;
                ddltype.DataValueField = "AptTYpeId";
                ddltype.DataTextField = "AptTYpe";
                ddltype.DataBind();
                ddltype.Items.Insert(0, new ListItem("Select", "AptTYpe"));
                dr = null;
                ddl_apt_time.Items.Clear();
                cmd1 = connection.con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                //cmd1.CommandText = "sp_Ptnt_Time_ddl";
                cmd1 = new SqlCommand("sp_Ptnt_Time_ddl", connection.con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@pCntr_id", Convert.ToInt32(Session["Cntr_id"].ToString()));
                cmd1.Parameters.AddWithValue("@pADate", System.DateTime.Now);
                cn.executeprocedure(cmd1);
                DataTable DT2 = new DataTable();
                cn.Open();
                dr1 = cmd1.ExecuteReader();
                DT2.Load(dr1);
                ddl_apt_time.DataSource = DT2;
                ddl_apt_time.DataValueField = "time_id";
                ddl_apt_time.DataTextField = "apt_time";
                ddl_apt_time.DataBind();
                ddl_apt_time.Items.Insert(0, new ListItem("Select", "apt_time"));
                dr1 = null;

                cn.Close();
                #endregion
                Select();
            }
        }
    }
    public void Select()
    {
        if (Request.QueryString["apt_Tel_id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["apt_Tel_id"].ToString());
                double h_t_id = System.Convert.ToInt32(id1);
                cn.Open();
                cmd = new SqlCommand("Apt_Tel_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pApt_no", h_t_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);

                DataTable DT1 = new DataTable();
                cn.Open();
                dr2 = cmd.ExecuteReader();
                DT1.Load(dr2);
                lblApt_Tel_No.Value = DT1.Rows[0][0].ToString();
                txtPtnt_Nm.Text = DT1.Rows[0][1].ToString();
                txtmobno.Text = DT1.Rows[0][1].ToString();
                ddltype.SelectedIndex = Convert.ToInt32(DT1.Rows[0][2].ToString());
                ddl_apt_time.SelectedIndex = Convert.ToInt32(DT1.Rows[0][3].ToString());
                dr2 = null;
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
        lblApt_Tel_No.Value = "";
        txtPtnt_Nm.Text = "";
        txtmobno.Text = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        #region Save
        if(btnsave.Text=="Edit")
        {
            try
            {
                int Apt_no = Convert.ToInt32(lblApt_Tel_No.Value);
                string Ptnt_Nm = txtPtnt_Nm.Text.ToUpper();
                int Ptntype = Convert.ToInt32(ddltype.SelectedValue);
                DateTime aptdt = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);
                if (aptdt.DayOfWeek.ToString() == "Sunday")
                { aptdt.AddDays(1).ToShortDateString(); }
                else { aptdt.ToShortDateString(); }
                int ptnt_mob = Convert.ToInt32(txtmobno.Text);
                int apttime = Convert.ToInt32(ddl_apt_time.SelectedValue);
                string Apt_Desc = txtApt_Desc.Text;
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_Apt_Tel_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pApt_no", Apt_no);
                cmd.Parameters.AddWithValue("@pPtnt_Nm", Ptnt_Nm);
                cmd.Parameters.AddWithValue("@pptnt_mob", ptnt_mob);
                cmd.Parameters.AddWithValue("@pPtntype", Ptntype);
                cmd.Parameters.AddWithValue("@paptdt", aptdt);
                cmd.Parameters.AddWithValue("@papttime", apttime);
                cmd.Parameters.AddWithValue("@pApt_Desc", Apt_Desc);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                Response.Redirect("Apt_Tel_Grid.aspx");
                btnsave.Enabled = false;
                Clear();
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
            }
        }
        else
        {
        try
        {
            int Apt_no = 0;
            string Ptnt_Nm = txtPtnt_Nm.Text.ToUpper();
            int Ptntype = Convert.ToInt32(ddltype.SelectedValue);
            DateTime aptdt = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);
            if (aptdt.DayOfWeek.ToString() == "Sunday")
            { aptdt.AddDays(1).ToShortDateString(); }
            else { aptdt.ToShortDateString(); }
            int ptnt_mob = Convert.ToInt32(txtmobno.Text);
            int apttime = Convert.ToInt32(ddl_apt_time.SelectedValue);
            string Apt_Desc = txtApt_Desc.Text;
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_Apt_Tel_trn_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@pApt_no", Apt_no);
            cmd.Parameters.AddWithValue("@pPtnt_Nm", Ptnt_Nm);
            cmd.Parameters.AddWithValue("@pptnt_mob", ptnt_mob);
            cmd.Parameters.AddWithValue("@pPtntype", Ptntype);
            cmd.Parameters.AddWithValue("@paptdt", aptdt);
            cmd.Parameters.AddWithValue("@papttime", apttime);
            cmd.Parameters.AddWithValue("@pApt_Desc", Apt_Desc);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            cn.executeprocedure(cmd);
            cn.Close();
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
            Response.Redirect("Apt_Tel_Grid.aspx");
            btnsave.Enabled = false;
            Clear();
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
        }
        #endregion
        }
    }
    protected void btnCanel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Apt_tel_Grid.aspx");
    }
}
