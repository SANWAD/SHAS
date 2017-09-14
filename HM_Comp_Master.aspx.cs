using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

public partial class HM_Comp_Master : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    SqlDataAdapter da;
    DataSet ds;
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
                txtComp_Code.Enabled = false;
                txtComp_nm.Focus();
                Select();                
            }
        }        
    }
    public void Select()
    {         
        if (Request.QueryString["Comp_Id"].ToString() != "0")
        {
           #region Select
                try
                {
                    string id1;
                    id1 = (Request.QueryString["Comp_Id"].ToString());
                    double Comp_id = System.Convert.ToInt32(id1);                    
                        cn.Open();
                        // cmd = new SqlCommand("HM_Comp_Mast_Select", connection.con);
                        cmd = new SqlCommand("HM_Comp_Mast_g", connection.con);
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        cmd.Parameters.AddWithValue("@pComp_id", Comp_id);                        
                        cn.executeprocedure(cmd);
                        DataTable DT1 = new DataTable();
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        DT1.Load(dr);
                        lblComp_id.Value  = DT1.Rows[0][0].ToString();
                        txtComp_Code.Text = DT1.Rows[0][2].ToString();
                        txtComp_nm.Text = DT1.Rows[0][3].ToString();
                        txtComp_Add.Text = DT1.Rows[0][4].ToString();
                        txtReg_No.Text = DT1.Rows[0][5].ToString();
                        txtPh_No.Text = DT1.Rows[0][6].ToString();
                        dr = null;
                        cn.Close();
                        txtComp_Code.Enabled = false;
                        btn_save.Text = "Edit";
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
            cn.Open();         
            double Comp_id = System.Convert.ToInt32(lblComp_id.Value);
            string Comp_Code = txtComp_Code.Text.ToUpper();
            Double Ph_No;
            string Comp_nm = txtComp_nm.Text.ToUpper();
            string Add = txtComp_Add.Text.ToString();
            string Flag = "E";
            string Reg_No;
            if (txtReg_No.Text == "")
            {
                Reg_No = " ";
            }
            else
            {
                Reg_No = txtReg_No.Text.ToString();
            }  
            if (txtPh_No.Text == "")
            {
                Ph_No = 0;
            }
            else
            {
                Ph_No = Convert.ToDouble(txtPh_No.Text);
            }
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                cmd = new SqlCommand("HM_Comp_Mast_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pComp_id", Comp_id);
                cmd.Parameters.AddWithValue("@pComp_nm", Comp_nm);
                cmd.Parameters.AddWithValue("@pComp_add", Add);
                cmd.Parameters.AddWithValue("@pReg_No", Reg_No);
                cmd.Parameters.AddWithValue("@pComp_ph", Ph_No);
                cmd.Parameters.AddWithValue("@pCreated_by", cr_by);
                cn.executeprocedure(cmd);                
                Response.Write("<script language='JavaScript'>alert('Record is Update')</script>");
                cn.Close();
                Response.Redirect("HM_Comp_Add_Grid.aspx");
                Clear();
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Error Occured while Updatting Record!')</script>");
        }
        #endregion
        }
        else if (btn_save.Text == "Delete")
        {
            cn.Open();
            #region Delete
            //try
            //{
            //    int Comp_id = 0;
            //    string Comp_Code = "SANWAD";
            //    Double Ph_No;
            //    string Comp_nm = txtComp_nm.Text.ToUpper();
            //    string Add = txtComp_Add.Text.ToString();
            //    string Flag = "D";
            //    string Reg_No;
            //    if (txtReg_No.Text == "")
            //    {
            //        Reg_No = " ";
            //    }
            //    else
            //    {
            //        Reg_No = txtReg_No.Text.ToString();
            //    }
            //    if (txtPh_No.Text == "")
            //    {
            //        Ph_No = 0;
            //    }
            //    else
            //    {
            //        Ph_No = Convert.ToDouble(txtPh_No.Text);
            //    }
            //    if (txtComp_nm.Text == "" || txtComp_Add.Text == "" || txtReg_No.Text == "" || txtPh_No.Text == "")
            //    {
            //        Response.Write("<script language='JavaScript'>alert('Please Type Valid Company Name,Address,Reg No & Ph No')</script>");
            //    }
            //    else
            //    {
            //        int cr_by = Convert.ToInt32(Session["Name"].ToString());
            //        cn.Open();
            //        cmd = new SqlCommand("HM_Comp_Mast_c", connection.con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@pFlag", Flag);
            //        cmd.Parameters.AddWithValue("@pComp_id", Comp_id);
            //        cmd.Parameters.AddWithValue("@pComp_Code", Comp_Code);
            //        cmd.Parameters.AddWithValue("@pComp_nm", Comp_nm);
            //        cmd.Parameters.AddWithValue("@pComp_add", Add);
            //        cmd.Parameters.AddWithValue("@pReg_No", Reg_No);
            //        cmd.Parameters.AddWithValue("@pComp_ph", Ph_No);
            //        cmd.Parameters.AddWithValue("@pCreated_by", cr_by);
            //        cn.executeprocedure(cmd);
            //        cn.Close();
            //        Response.Write("<script language='JavaScript'>alert('Record is Deleted')</script>");
            //        Clear();
            //        Response.Redirect("Comp_Add_Grid.aspx");
            //    }
            //}
            //catch
            //{
            //    Response.Write("<script language='JavaScript'>alert('Error Occured while saving Record!')</script>");
            //}
            #endregion           
        }
        else
        {
            #region Save
            try
            {
                cn.Open();
                int Comp_id = 0;
                //string Comp_Code = txtComp_Code.Text.ToUpper();
                Double Ph_No;
                string Comp_nm = txtComp_nm.Text.ToUpper();
                string Add = txtComp_Add.Text.ToString();
                string Flag = "I";
                string Reg_No;
                if (txtReg_No.Text == "")
                {
                    Reg_No = " ";
                }
                else
                {
                    Reg_No = txtReg_No.Text.ToString();
                }
                if (txtPh_No.Text == "")
                {
                    Ph_No = 0;
                }
                else
                {
                    Ph_No = Convert.ToDouble(txtPh_No.Text);
                }
                if (txtComp_nm.Text == "" || txtComp_Add.Text == "" || txtReg_No.Text == "" || txtPh_No.Text == "")
                {
                    Response.Write("<script language='JavaScript'>alert('Please Type Valid Company Name,Address,Reg No & Ph No')</script>");
                    //lblError.Visible = true;
                    //lblError.Text = "Please Type Valid Company Name,Address,Reg No & Ph No";
                }
                else
                {
                    int cr_by = Convert.ToInt32(Session["Name"].ToString());
                    cn.Open();
                    cmd = new SqlCommand("HM_Comp_Mast_c", connection.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pFlag", Flag);
                    cmd.Parameters.AddWithValue("@pComp_id", Comp_id);
                    //cmd.Parameters.AddWithValue("@pComp_Code", Comp_Code);
                    cmd.Parameters.AddWithValue("@pComp_nm", Comp_nm);
                    cmd.Parameters.AddWithValue("@pComp_add", Add);
                    cmd.Parameters.AddWithValue("@pReg_No", Reg_No);
                    cmd.Parameters.AddWithValue("@pComp_ph", Ph_No);
                    cmd.Parameters.AddWithValue("@pCreated_by", cr_by);
                    cn.executeprocedure(cmd);
                    cn.Close();
                    Response.Redirect("HM_Comp_Add_Grid.aspx");
                    Response.Write("<script language='JavaScript'>alert('Record is Save')</script>");
                    Clear();
                }
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Error Occured while saving Record!')</script>");
            }
            #endregion
        }        
    }   
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("HM_Comp_Add.aspx");
    }
    public void Clear()
    {
        lblComp_id.Value= "";
        txtComp_nm.Text = "";
        txtComp_Add.Text = "";
        txtPh_No.Text = "";
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/HM_Comp_Add_Grid.aspx");
    }
    protected void txtComp_nm_TextChanged(object sender, EventArgs e)
    {
        #region Company Exists
        string Comp_nm = txtComp_nm.Text.Trim();

        cmd = new SqlCommand("sp_Comp_Id_Search", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@pComp_nm", Comp_nm);

        cn.executeprocedure(cmd);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "HM_Comp_Mast");
        if (ds.Tables["HM_Comp_Mast"].Rows.Count > 0)
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
