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

public partial class Camps : System.Web.UI.Page
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
                txtcampnm.Focus();
                Select();
            }
        }
    }
    public void Select()
    {
        if (Request.QueryString["Camp_Id"].ToString() != "0")
        {
            Clear();
            try
            {
                #region Select
                try
                {
                    string id1;
                    id1 = (Request.QueryString["Camp_Id"].ToString());
                    int Camp_id = Convert.ToInt32(id1);
                    cn.Open();
                    cmd = new SqlCommand("tbl_camp_Select", connection.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pcamp_id", Camp_id);
                    cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                    cn.executeprocedure(cmd);
                    DataTable DT1 = new DataTable();
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    DT1.Load(dr);
                    lblcamp_id.Value = DT1.Rows[0][0].ToString();
                    txtdate.Text = DT1.Rows[0][2].ToString();
                    txtcampnm.Text = DT1.Rows[0][1].ToString();
                    txtduration.Text = DT1.Rows[0][3].ToString();
                    txtno_vis.Text = DT1.Rows[0][4].ToString();
                    txtaud_done.Text = DT1.Rows[0][5].ToString();
                    txtfit_book.Text = DT1.Rows[0][6].ToString();
                    txtptntnm.Text = DT1.Rows[0][7].ToString();
                    txtmode_adv.Text = DT1.Rows[0][8].ToString();
                    dr = null;
                    cn.Close();
                    btnsave.Text = "Edit";
                }
                catch
                {
                    Response.Write("<script language='JavaScript'>alert('')</script>");
                }
                #endregion
            }
            catch
            {
            }
        }
    }
    public void Clear()
    {
        lblcamp_id.Value = "";
        txtcampnm.Text = "";
        txtdate.Text = "";
        txtduration.Text = "";
        txtno_vis.Text = "";
        txtaud_done.Text = "";
        txtfit_book.Text = "";
        txtptntnm.Text = "";
        txtmode_adv.Text = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (btnsave.Text == "Edit")
        {            
            #region Edit
            try
            {
                int Camp_id = Convert.ToInt32(lblcamp_id.Value);
                string camp_nm = txtcampnm.Text.ToUpper();
                string dt = txtdate.Text.ToString();
                int dur = System.Convert.ToInt32(txtduration.Text);
                int n_v = System.Convert.ToInt32(txtno_vis.Text);
                int aud_done = System.Convert.ToInt32(txtaud_done.Text);
                int fit_book = System.Convert.ToInt32(txtfit_book.Text);
                string ptnt_nm = txtptntnm.Text.ToString();
                string m_adv = txtmode_adv.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_camp_trn_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pcamp_id", Camp_id);
                cmd.Parameters.AddWithValue("@pcamp_nm", camp_nm);
                cmd.Parameters.AddWithValue("@pcamp_date", dt);
                cmd.Parameters.AddWithValue("@pcamp_duration", dur);
                cmd.Parameters.AddWithValue("@pcamp_no_visitors", n_v);
                cmd.Parameters.AddWithValue("@pcamp_aud_done", aud_done);
                cmd.Parameters.AddWithValue("@pcamp_fit_booked", fit_book);
                cmd.Parameters.AddWithValue("@pcamp_ptnt_nm", ptnt_nm);
                cmd.Parameters.AddWithValue("@pcamp_mode_adv", m_adv);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                Response.Redirect("Cam_Grid.aspx");
                cn.Close();                
            }
            catch
            {
                //Response.Redirect("~/Login.aspx");
            }
            #endregion
        }
        else
        {
            #region Save
            try
            {
                if (txtcampnm.Text == "" || txtdate.Text == "" || txtduration.Text=="")
                {
                    Response.Write("<script language='JavaScript'>alert('Please Type Valid Camp Name,Camp Date,Camp Duration')</script>");
                }
                else
                {
                    int Camp_id = 0;
                    string camp_nm = txtcampnm.Text.ToUpper();
                    string dt = txtdate.Text.ToString();
                    int dur = System.Convert.ToInt32(txtduration.Text);
                    int n_v = System.Convert.ToInt32(txtno_vis.Text);
                    int aud_done = System.Convert.ToInt32(txtaud_done.Text);
                    int fit_book = System.Convert.ToInt32(txtfit_book.Text);
                    string ptnt_nm = txtptntnm.Text.ToString();
                    string m_adv = txtmode_adv.Text.ToString();
                    int cr_by = Convert.ToInt32(Session["Name"].ToString());
                    int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                    string Flag = "I";
                    cn.Open();
                    cmd = new SqlCommand("tbl_camp_trn_c", connection.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pFlag", Flag);
                    cmd.Parameters.AddWithValue("@pcamp_id", Camp_id);
                    cmd.Parameters.AddWithValue("@pcamp_nm", camp_nm);
                    cmd.Parameters.AddWithValue("@pcamp_date", dt);
                    cmd.Parameters.AddWithValue("@pcamp_duration", dur);
                    cmd.Parameters.AddWithValue("@pcamp_no_visitors", n_v);
                    cmd.Parameters.AddWithValue("@pcamp_aud_done", aud_done);
                    cmd.Parameters.AddWithValue("@pcamp_fit_booked", fit_book);
                    cmd.Parameters.AddWithValue("@pcamp_ptnt_nm", ptnt_nm);
                    cmd.Parameters.AddWithValue("@pcamp_mode_adv", m_adv);
                    cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                    cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                    cn.executeprocedure(cmd);
                    cn.Close();
                    Response.Redirect("Cam_Grid.aspx");
                    Clear();
                }
               
            }
            catch
            {
                //Response.Redirect("~/Login.aspx");
            }
            #endregion
        }        
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Cam_Grid.aspx");
    }
}
