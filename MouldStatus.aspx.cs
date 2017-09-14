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
public partial class outward : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    double id;
    DateTime Sent_Date, Rec_Date, Fit_Date;
    int Pid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            cn = new connection();
            //RangeValidator1.MaximumValue = System.DateTime.Now.AddDays(0).ToShortDateString();
            PtntNm.ContextKey = Session["Cntr_id"].ToString();
            if (!IsPostBack)
            {
                Select();
            }
        }
    }
    public void Select()
    {
        if (Request.QueryString["Mold_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Mold_Id"].ToString());
                double h_t_id = System.Convert.ToInt32(id1);
                cn.Open();
                cmd = new SqlCommand("tbl_Mol_Sts_Id", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pMold_Id", h_t_id);
                cn.executeprocedure(cmd);

                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblMou_no.Value = DT1.Rows[0][0].ToString();
                txtptnt_nm.Text = DT1.Rows[0][1].ToString();
                lblPtnt_id.Value = DT1.Rows[0][7].ToString();
                txtHAidNm.Text = DT1.Rows[0][2].ToString();
                txtSent_Date.Text = DT1.Rows[0][3].ToString();
                txtRec_Date.Text = DT1.Rows[0][4].ToString();
                txtFit_Date.Text = DT1.Rows[0][5].ToString();
                dr = null;
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
        lblMou_no.Value = "";
        txtptnt_nm.Text = "";
        txtHAidNm.Text ="";
        txtSent_Date.Text = "";
        txtRec_Date.Text = "";
        txtFit_Date.Text = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (btnsave.Text == "Edit")
        {
            #region Edit
            try
            {
                string ptnt_nm1 = txtptnt_nm.Text;
                Pid = Convert.ToInt32(lblPtnt_id.Value);
                int Mold_No = Convert.ToInt32(lblMou_no.Value);
                String HAid_Nm = txtHAidNm.Text.ToString();
                Sent_Date = DateTime.ParseExact(txtSent_Date.Text, "dd/MM/yyyy", null);
                if (txtRec_Date.Text == "")
                {
                    Rec_Date = Convert.ToDateTime(null);
                }
                else
                {
                    Rec_Date = DateTime.ParseExact(txtRec_Date.Text, "dd/MM/yyyy", null);
                }
                if (txtRec_Date.Text == "")
                {
                    Fit_Date = Convert.ToDateTime(null);
                }
                else
                {
                    Fit_Date = DateTime.ParseExact(txtFit_Date.Text, "dd/MM/yyyy", null);
                }
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_Mol_Sts_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pMold_no", Mold_No);
                cmd.Parameters.AddWithValue("@pPtnt_id", Pid);
                cmd.Parameters.AddWithValue("@pHAid_Nm", HAid_Nm);
                cmd.Parameters.AddWithValue("@pSent_Date", Sent_Date);
                cmd.Parameters.AddWithValue("@pRec_Date", Rec_Date);
                cmd.Parameters.AddWithValue("@pFit_Date", Fit_Date);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                btnsave.Enabled = false;
                Response.Redirect("MouldStatus_Grid.aspx");
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
            }
            #endregion
        }
        else
        {
            #region Save
            try
            {
                string ptnt_nm1 = txtptnt_nm.Text;
                string[] WordArray = ptnt_nm1.Split('-');
                Pid = Convert.ToInt32(WordArray[1]);
                int Mold_No = 0;
                String HAid_Nm = txtHAidNm.Text.ToString();
                Sent_Date = DateTime.ParseExact(txtSent_Date.Text, "dd/MM/yyyy", null);
                if (txtRec_Date.Text=="")
                {
                    Rec_Date = Convert.ToDateTime(null);
                }
                else
                {
                    Rec_Date = DateTime.ParseExact(txtRec_Date.Text, "dd/MM/yyyy", null);
                }
                if (txtRec_Date.Text=="")
                {
                    Fit_Date = Convert.ToDateTime(null);
                }
                else
                {
                    Fit_Date = DateTime.ParseExact(txtFit_Date.Text, "dd/MM/yyyy", null);
                }
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_Mol_Sts_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pMold_no", Mold_No);
                cmd.Parameters.AddWithValue("@pPtnt_id", Pid);
                cmd.Parameters.AddWithValue("@pHAid_Nm", HAid_Nm);
                cmd.Parameters.AddWithValue("@pSent_Date", Sent_Date);
                cmd.Parameters.AddWithValue("@pRec_Date", Rec_Date);
                cmd.Parameters.AddWithValue("@pFit_Date", Fit_Date);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();
                btnsave.Enabled = false;
                Response.Redirect("MouldStatus_Grid.aspx");
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");                
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
            }
            #endregion
        }       
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MouldStatus_Grid.aspx");
    }
}
