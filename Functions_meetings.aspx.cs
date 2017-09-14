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

public partial class Functions_meetings : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    double id, aptid;
    int i, j;
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
                txtn_days.Focus();
                Select();
            }            
        }
    }    
    public void Select()
    {
        if (Request.QueryString["Fun_Id"].ToString() != "0")
        {
            #region Select
            try
            {
            string id1;
            id1 = (Request.QueryString["Fun_Id"].ToString());
            double fun_id = System.Convert.ToInt32(id1); 
            cmd = new SqlCommand("tbl_func_meet_Select", connection.con);
            //cmd = new SqlCommand("tbl_func_meet_tr_g", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pfun_id", fun_id);
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
            cn.Open();
            cn.executeprocedure(cmd);           
            DataTable DT1 = new DataTable();
            cn.Open();
            dr = cmd.ExecuteReader();
            DT1.Load(dr);
            lblfunct_id.Value  = DT1.Rows[0][0].ToString();
            lbl_apt_id.Value  = DT1.Rows[0][1].ToString();
            txtn_days.Text = DT1.Rows[0][2].ToString();
            txtdate.Text = DT1.Rows[0][3].ToString();
            lblto_date.Text = DT1.Rows[0][4].ToString();           
            dr = null;
            cn.Close();
            //Response.Write("<script language='JavaScript'>alert('')</script>");
            btnsave.Text = "Edit";
            }
            catch
            { }
            #endregion
        }
    }
    public void Clear()
    {
        lblfunct_id.Value = "";
        lbl_apt_id.Value  = "";
        txtn_days.Text = "";
        txtdate.Text = "";
        lbl_apt_id.Value  = "";
        lblto_date.Text = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if(btnsave.Text=="Edit")
        {
            #region Edit
            try
            {
                int fun_id = Convert.ToInt32(lblfunct_id.Value);
                DateTime fromdt = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);
                DateTime todt = DateTime.ParseExact(lblto_date.Text, "dd/MM/yyyy", null);
                string  n_d = txtn_days.Text;
                int createdby = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id=Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                //if (n_d > 1)
                //{

                //    for (i = 1; i <= n_d; i++)
                //    {
                //        for (j = i; j <= i; j++)
                //        {
                //            DateTime dt = fromdt.AddDays(+j);
                //            cmd = new SqlCommand("sp_appointment_insert", connection.con);
                //            cmd.CommandType = CommandType.StoredProcedure;
                //            cmd.Parameters.AddWithValue("@pFlag", Flag);                     
                //            cmd.Parameters.AddWithValue("@p_ptnt_id", 0);
                //            cmd.Parameters.AddWithValue("@p_ptnt_for", "Function");
                //            cmd.Parameters.AddWithValue("@p_apt_date", dt);
                //            cmd.Parameters.AddWithValue("@p_apt_time", "All");
                //            cmd.Parameters.AddWithValue("@p_created_by", createdby);

                //            cn.Open();
                //            cn.executeprocedure(cmd);
                //            aptid = cn.getmaxid("select max(apt_id) from tbl_apointment_trn", "tbl_apointment_trn");
                //            if (aptid == 0) { lbl_apt_id.Text = Convert.ToString(aptid + 1); }
                //            else { lbl_apt_id.Text = Convert.ToString(aptid); }
                //        }
                //    }
                //}
                //else
                //{
                //    cmd = new SqlCommand("sp_appointment_insert", connection.con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@pFlag", Flag);
                //    cmd.Parameters.AddWithValue("@p_ptnt_id", 0);
                //    cmd.Parameters.AddWithValue("@p_ptnt_for", "Function");
                //    cmd.Parameters.AddWithValue("@p_apt_date", fromdt);
                //    cmd.Parameters.AddWithValue("@p_apt_time", "All");
                //    cmd.Parameters.AddWithValue("@p_created_by", createdby);
                //    cn.Open();
                //    cn.executeprocedure(cmd);
                //}
                cmd = new SqlCommand("tbl_func_meet_tr_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pfun_id", fun_id);
                cmd.Parameters.AddWithValue("@pfun_no_days", n_d);
                cmd.Parameters.AddWithValue("@pfun_from_date", fromdt.Date);
                cmd.Parameters.AddWithValue("@pfun_to_date", todt.Date);
                cmd.Parameters.AddWithValue("@pcreated_by", createdby);
                cmd.Parameters.AddWithValue("@pCntr_id",Cntr_id);
                cn.Open();
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("Function_Meeting_Grid.aspx");
            }
            catch
            {
                /*Response.Redirect("~/error.aspx");*/
            }
            #endregion
            }
            else
            {
            #region Save
            try
            {
                int fun_id = 0;
                DateTime fromdt = System.Convert.ToDateTime(txtdate.Text);
                DateTime todt = System.Convert.ToDateTime(lblto_date.Text);
                string n_d = txtn_days.Text;
                int createdby = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "I";
                //if (n_d > 1)
                //{

                //    for (i = 1; i <= n_d; i++)
                //    {
                //        for (j = i; j <= i; j++)
                //        {
                //            DateTime dt = fromdt.AddDays(+j);
                //            cmd = new SqlCommand("sp_appointment_insert", connection.con);
                //            cmd.CommandType = CommandType.StoredProcedure;
                //            cmd.Parameters.AddWithValue("@pFlag", Flag);                     
                //            cmd.Parameters.AddWithValue("@p_ptnt_id", 0);
                //            cmd.Parameters.AddWithValue("@p_ptnt_for", "Function");
                //            cmd.Parameters.AddWithValue("@p_apt_date", dt);
                //            cmd.Parameters.AddWithValue("@p_apt_time", "All");
                //            cmd.Parameters.AddWithValue("@p_created_by", createdby);

                //            cn.Open();
                //            cn.executeprocedure(cmd);
                //            aptid = cn.getmaxid("select max(apt_id) from tbl_apointment_trn", "tbl_apointment_trn");
                //            if (aptid == 0) { lbl_apt_id.Text = Convert.ToString(aptid + 1); }
                //            else { lbl_apt_id.Text = Convert.ToString(aptid); }
                //        }
                //    }
                //}
                //else
                //{
                //    cmd = new SqlCommand("sp_appointment_insert", connection.con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@pFlag", Flag);
                //    cmd.Parameters.AddWithValue("@p_ptnt_id", 0);
                //    cmd.Parameters.AddWithValue("@p_ptnt_for", "Function");
                //    cmd.Parameters.AddWithValue("@p_apt_date", fromdt);
                //    cmd.Parameters.AddWithValue("@p_apt_time", "All");
                //    cmd.Parameters.AddWithValue("@p_created_by", createdby);
                //    cn.Open();
                //    cn.executeprocedure(cmd);
                //}
                cmd = new SqlCommand("tbl_func_meet_tr_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pfun_id", fun_id);
                cmd.Parameters.AddWithValue("@pfun_no_days", n_d);
                cmd.Parameters.AddWithValue("@pfun_from_date", fromdt.Date);
                cmd.Parameters.AddWithValue("@pfun_to_date", todt.Date);
                cmd.Parameters.AddWithValue("@pcreated_by", createdby);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.Open();
                cn.executeprocedure(cmd);
                cn.Close();
                Response.Redirect("Function_Meeting_Grid.aspx");            
            }

            catch
            {
                /*Response.Redirect("~/error.aspx");*/
            }
            #endregion
        }
     }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Function_Meeting_Grid.aspx");
    }
}
