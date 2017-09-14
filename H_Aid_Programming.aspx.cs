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

public partial class H_Aid_Programming : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;   
    double id;
    int a;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login/login.aspx");
        }
        else
        {
            cn = new connection();
            PtntNm.ContextKey = Session["Cntr_id"].ToString();
            if (!IsPostBack)
            {
                #region Loading
                Clear();
                Select();
                #endregion 
             }
       }           
    }
    public void Clear()
    {
        rbtReturn.Focus();
        lbl_H_Prg_id.Value = "";
        txtptnt_nm.Text = "";
        rbtReturn.SelectedIndex = 0;
        ddlTime.SelectedIndex = 0;
        txtCompl.Text = "";
        txtCom_After.Text = "";
    }
    public void Select()
    {
        if (Request.QueryString["Prog_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Prog_Id"].ToString());
                double H_Prog_id = System.Convert.ToInt32(id1);                
                cn.Open();
                cmd = new SqlCommand("tbl_h_prog_Select", connection.con);                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pH_Prog_id", H_Prog_id);
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbl_H_Prg_id.Value = DT1.Rows[0][0].ToString();
                LblPtntid.Value = DT1.Rows[0][1].ToString();
                string Tim = DT1.Rows[0][2].ToString();
                if (Tim == "15 Minutes")
                {
                    ddlTime.SelectedIndex = 0;
                }
                else 
                {
                    ddlTime.SelectedIndex = 1;
                }
                string Ste = DT1.Rows[0][3].ToString();
                if (Ste == "I Step")
                {
                    rbtReturn.SelectedIndex = 0;
                }
                else if (Ste == "II Step")
                {
                    rbtReturn.SelectedIndex = 1;
                }
                else if (Ste == "III Step")
                {
                    rbtReturn.SelectedIndex = 2;
                }
                else
                {
                    rbtReturn.SelectedIndex = 3;
                }
                txtCompl.Text = DT1.Rows[0][4].ToString();
                txtCom_After.Text = DT1.Rows[0][5].ToString();
                txtptnt_nm.Text = DT1.Rows[0][8].ToString();
                dr = null;
                cn.Close();
                btn_save.Text = "Edit";
                btnPrint.Enabled = true;
            }
            catch
            { }
            #endregion
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if (btn_save.Text == "Edit")
        {
            #region Edit
            try
            {
                int Ptnt_id = Convert.ToInt32(LblPtntid.Value);             
                int H_Prog_id = Convert.ToInt32(lbl_H_Prg_id.Value);
                string Time = ddlTime.Text.ToString();
                string Step;
                if (rbtReturn.SelectedIndex == 0)
                {
                    Step = "I Step";
                }
                else if (rbtReturn.SelectedIndex == 1)
                {
                    Step = "II Step";
                }
                else if (rbtReturn.SelectedIndex == 2)
                {
                    Step = "III Step";
                }
                else
                {
                    Step = "Above III Step";
                }
                string Compl = txtCompl.Text.ToString();
                string Comp_aft_Prg = txtCom_After.Text.ToString();
                //DateTime cr_dt = Convert.ToDateTime(lbl_dt.Value);
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                cn.Open();
                cmd = new SqlCommand("tbl_h_prog_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pH_Prog_id", H_Prog_id);
                cmd.Parameters.AddWithValue("@pPtnt_id", Ptnt_id);
                cmd.Parameters.AddWithValue("@pTime", Time);
                cmd.Parameters.AddWithValue("@pSteps", Step);
                cmd.Parameters.AddWithValue("@pCompl", Compl);
                cmd.Parameters.AddWithValue("@pComm_aft_Prog", Comp_aft_Prg);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                cn.executeprocedure(cmd);
                cn.Close();          
                Response.Redirect("H_Aid_Programming_Grid.aspx");
                Clear();
                btn_save.Enabled = false;
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is not save')</script>");
                btn_save.Enabled = true;
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
                string Name = WordArray[0].ToString();
                LblPtntid.Value = WordArray[1];
                int Ptnt_id = Convert.ToInt32(LblPtntid.Value);
                int H_Prog_id = 0;
                string Time = ddlTime.Text.ToString();
                string Step;
                if (rbtReturn.SelectedIndex == 0)
                {
                    Step = "I Step";
                }
                else if (rbtReturn.SelectedIndex == 1)
                {
                    Step = "II Step";
                }
                else if (rbtReturn.SelectedIndex == 2)
                {
                    Step = "III Step";
                }
                else
                {
                    Step = "Above III Step";
                }
                string Compl = txtCompl.Text.ToString();
                string Comp_aft_Prg = txtCom_After.Text.ToString();
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "I";
                cn.Open();
                cmd = new SqlCommand("tbl_h_prog_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pH_Prog_id", H_Prog_id);
                cmd.Parameters.AddWithValue("@pPtnt_id", Ptnt_id);
                cmd.Parameters.AddWithValue("@pTime", Time);
                cmd.Parameters.AddWithValue("@pSteps", Step);
                cmd.Parameters.AddWithValue("@pCompl", Compl);
                cmd.Parameters.AddWithValue("@pComm_aft_Prog", Comp_aft_Prg);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                a=cn.executeprocedure(cmd);
                cn.Close();
                lbl_H_Prg_id.Value = a.ToString();
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    print();
                }
                else
                {
                    Response.Redirect("~/H_Aid_Programming_Grid.aspx");
                }
                btn_save.Enabled = false;
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is not save')</script>");
                btn_save.Enabled = true;
            }
            #endregion
        }        
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/H_Aid_Programming_Grid.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        print();
    }
    public void print()
    {
        if (lbl_H_Prg_id.Value != "")
        {
            int billno = Convert.ToInt32(lbl_H_Prg_id.Value);
            Response.Redirect("~/H_prog.aspx?bill_no=" + billno);
        }
    }
}
