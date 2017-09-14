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

public partial class Advertising : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            Clear();
            txtmedia.Focus();
            if (Request.QueryString["Adv_Id"].ToString() != "0")
            {
                try
                {
                    #region Select
                    try
                    {
                        string id1;
                        id1 = (Request.QueryString["Adv_Id"].ToString());
                        int ad_id = Convert.ToInt32(id1);                        

                        cn.Open();
                        cmd = new SqlCommand("tbl_adv_Select", connection.con);
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        cmd.Parameters.AddWithValue("@pad_id", ad_id);
                        cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                        cn.executeprocedure(cmd);
                        DataTable DT1 = new DataTable();
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        DT1.Load(dr);
                        lblad_id.Value = DT1.Rows[0][0].ToString();
                        txtmedia.Text = DT1.Rows[0][1].ToString();
                        txt_nm_media.Text = DT1.Rows[0][5].ToString();
                        txtdate.Text = DT1.Rows[0][2].ToString();
                        txtdtfrom.Text = DT1.Rows[0][3].ToString();
                        string freq = DT1.Rows[0][4].ToString();
                        if (freq == "For Three Day")
                        {
                            ddl_ad_freq.SelectedIndex = 2;
                        }
                        else if (freq == "Once in Week")
                        {
                            ddl_ad_freq.SelectedIndex = 3;
                        }
                        else if (freq == "Weekly")
                        {
                            ddl_ad_freq.SelectedIndex = 4;
                        }
                        else if (freq == "Fortnight")
                        {
                            ddl_ad_freq.SelectedIndex = 5;
                        }
                        else 
                        {
                            ddl_ad_freq.SelectedIndex = 1;
                        }

                        ddl_ad_freq.SelectedValue = DT1.Rows[0][4].ToString();
                        txt_cost.Text = DT1.Rows[0][6].ToString();
                        txt_result.Text = DT1.Rows[0][7].ToString();                       
                        dr = null;
                        cn.Close();
                        btnsave.Text = "Edit";                         
                    }
                    catch
                    {
                        Response.Write("<script language='JavaScript'>alert('')</script>");
                        //Response.Redirect("~/error.aspx");
                    }
                    #endregion
                }
                catch
                {
                }
            }
        }
      }
    }
    public void Clear()
    {
        txtmedia.Text = "";
        lblad_id.Value  = "";
        txtdate.Text = "";
        txtdtfrom.Text = "";
        ddl_ad_freq.SelectedIndex = 0;
        txt_nm_media.Text = "";
        txt_cost.Text = "";
        txt_result.Text = "";
        txt_result.Text = "";
    }
    #region Cal
    protected void Cal_SelectedDate(object sender, EventArgs e)
    {
            //txtdate.Text = calDate.SelectedDate.ToShortDateString();
            //calDate.Visible = false;
    }
    protected void btn_showCal(object sender, EventArgs e)
    {
        //calDate.Visible = true;
    }
    protected void btndtfrom_Click(object sender, EventArgs e)
    {
        //calfrom.Visible = true;
    }
    protected void calfrom_SelectionChanged(object sender, EventArgs e)
    {
        //txtdtfrom.Text = calfrom.SelectedDate.ToShortDateString();
        //calfrom.Visible = false;
    }
    #endregion
    
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if(btnsave.Text=="Edit")
        {
             #region Edit
        try
        {            
            string media="";
            if (txtmedia.Text != "")
            {
                media = txtmedia.Text.ToUpper();
            }
            DateTime post_dt = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);
            DateTime from_dt = DateTime.ParseExact(txtdtfrom.Text, "dd/MM/yyyy", null);
            //DateTime post_dt = System.Convert.ToDateTime(txtdate.Text);
            //DateTime from_dt = System.Convert.ToDateTime(txtdtfrom.Text);
            string freq="";
            //int fre = ddl_ad_freq.SelectedIndex;
            //if (fre ==0)
            //{
                freq = ddl_ad_freq.SelectedItem.Text.ToString();
            //}
            string nm_med="";
            if (txt_nm_media.Text != "")
            {
                nm_med = txt_nm_media.Text.ToUpper();
            }
            double price;
            if (txt_cost.Text == "")
            {
                price = 0;
            }
            else
            {
                price = System.Convert.ToDouble(txt_cost.Text);
            }            
            string result = txt_result.Text.ToString();
            int cr_by =Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            int ad_id = Convert.ToInt32(lblad_id.Value);
            string Flag = "E";

            cn.Open();
            cmd = new SqlCommand("tbl_advertising_trn_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@pad_id", ad_id);
            cmd.Parameters.AddWithValue("@pad_media", media);
            cmd.Parameters.AddWithValue("@pad_posted_date", post_dt);
            cmd.Parameters.AddWithValue("@pad_from", from_dt);
            cmd.Parameters.AddWithValue("@pad_freq", freq);
            cmd.Parameters.AddWithValue("@pad_nm_media", nm_med);
            cmd.Parameters.AddWithValue("@pad_cost", price);
            cmd.Parameters.AddWithValue("@pad_result", result);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            cn.executeprocedure(cmd);
            Response.Redirect("advertising_Grid.aspx");
            cn.Close();
            btnsave.Enabled = false;
            btnCancel.Text = "Exit";
        }
        catch
        {
            //Response.Redirect("~/error.aspx");
        }
        #endregion
        }
        else
        {
 #region Save
        try
        {            
            string media="";
            if (txtmedia.Text != "")
            {
                media = txtmedia.Text.ToUpper();
            }
            DateTime post_dt = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);
            DateTime from_dt = DateTime.ParseExact(txtdtfrom.Text, "dd/MM/yyyy", null);
            string freq="";
            //int fre = ddl_ad_freq.SelectedIndex;
            //if (fre ==0)
            //{
                freq = ddl_ad_freq.SelectedItem.Text.ToString();
            //}
            string nm_med="";
            if (txt_nm_media.Text != "")
            {
                nm_med = txt_nm_media.Text.ToUpper();
            }
            double price;
            if (txt_cost.Text == "")
            {
                price = 0;
            }
            else
            {
                price = System.Convert.ToDouble(txt_cost.Text);
            }            
            string result = txt_result.Text.ToString();
            int cr_by =Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            int ad_id = 0;
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_advertising_trn_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@pad_id", ad_id);
            cmd.Parameters.AddWithValue("@pad_media", media);
            cmd.Parameters.AddWithValue("@pad_posted_date", post_dt);
            cmd.Parameters.AddWithValue("@pad_from", from_dt);
            cmd.Parameters.AddWithValue("@pad_freq", freq);
            cmd.Parameters.AddWithValue("@pad_nm_media", nm_med);
            cmd.Parameters.AddWithValue("@pad_cost", price);
            cmd.Parameters.AddWithValue("@pad_result", result);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            cn.executeprocedure(cmd);
            Response.Redirect("advertising_Grid.aspx");
            cn.Close();
            btnsave.Enabled = false;
            btnCancel.Text = "Exit";
        }
        catch
        {
            //Response.Redirect("~/error.aspx");
        }
        #endregion
        }       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/advertising_Grid.aspx");
    }
}
