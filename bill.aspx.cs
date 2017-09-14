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

public partial class bill : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    double id,ptnt_id;
    protected void Page_Load(object sender, EventArgs e)
    {     
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            cn = new connection();
            AutoPtntNm.ContextKey = Session["Cntr_id"].ToString();
        if (!IsPostBack)
        {     
            ptnt_id=Convert.ToInt32(Session["ptnt_id"]);
            if (ptnt_id > 0 && Session["Bill_Id"] == "0")
            {
                try
                {
                    cn.Open();
                    cmd = new SqlCommand("tbl_ptn_mast_Select", connection.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                    cn.Open();
                    cn.executeprocedure(cmd);
                    DataTable DT5 = new DataTable();
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    DT5.Load(dr);
                    lblptnt_id.Value = DT5.Rows[0][0].ToString();
                    txtptnt_nm.Text = DT5.Rows[0][3].ToString() + "-" + ptnt_id;

                    dr = null;
                    cn.Close();
                }
                catch
                {
                    Response.Write("<script language='JavaScript'>alert('')</script>");
                }
            }
            txtptnt_nm.Focus();
            Select();
        }
        }
    }
    public void Select()
    {
        if (Request.QueryString["Bill_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                CLEAR();
                string id1;
                id1 = (Request.QueryString["Bill_Id"].ToString());
                double Bill_Id = System.Convert.ToInt32(id1);

                cn.Open();
                cmd = new SqlCommand("tbl_test_bill_Id", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ptest_bill_no", Bill_Id);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbl_bill_no.Value = DT1.Rows[0][0].ToString();
                txtptnt_nm.Text =DT1.Rows[0][2].ToString();
                lblptnt_id.Value=DT1.Rows[0][17].ToString();
                txtPTA.Text=DT1.Rows[0][5].ToString();
                txtBera.Text = DT1.Rows[0][6].ToString();
                txtImp.Text = DT1.Rows[0][7].ToString();
                txtTDT.Text = DT1.Rows[0][8].ToString();
                txtSisiT.Text = DT1.Rows[0][9].ToString();
                txtFFAud.Text = DT1.Rows[0][10].ToString();
                txtSE.Text = DT1.Rows[0][11].ToString();
                txtStD.Text = DT1.Rows[0][12].ToString();
                txtStM.Text = DT1.Rows[0][13].ToString();
                txtHAP.Text = DT1.Rows[0][14].ToString();
                txtCoun.Text = DT1.Rows[0][15].ToString();
                //txtOther.Text = DT1.Rows[0][16].ToString();
                txt_bill_amt.Text = DT1.Rows[0][16].ToString();
                dr = null;
                cn.Close();
                btnsave.Text = "Edit";
                btnPrint.Enabled = true;
            }
            catch
            { }

            #endregion
        }
    }
    public void CLEAR()
    {
        txtptnt_nm.Text = "";
        txtPTA.Text = "";
        txtBera.Text = "";
        txtImp.Text = "";
        txtTDT.Text = "";
        txtSisiT.Text = "";
        txtFFAud.Text = "";
        txtSE.Text = "";
        txtStD.Text = "";
        txtStM.Text = "";
        txtCoun.Text = "";
        txtHAP.Text = "";
        txt_bill_amt.Text = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //string id1;
       // id1 = (Request.QueryString["id"].ToString());        
       // string name = (Request.QueryString["nm"].ToString());
        #region Save
        try
        {
            string ptnt_nm1 = txtptnt_nm.Text;
            string[] WordArray = ptnt_nm1.Split('-');
            string Name = WordArray[0].ToString();
            lblptnt_id.Value = WordArray[1];
            int bill_no = 0;
            string InvcNo = "DEF";
            int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
            string part = txtptnt_nm.Text.ToString();
            string Perti = txtOther.Text;
            int PTA, Bera, Imp, TDT, SisiT, FFA, SE, StD, StM, HAP, Coun;
            if (txtPTA.Text == "")
            {
                PTA = 0;
            }
            else
            {
                PTA = System.Convert.ToInt32(txtPTA.Text);
            }
            if (txtBera.Text == "")
            {
                Bera = 0;
            }
            else
            {
                Bera = System.Convert.ToInt32(txtBera.Text);
            }
            if (txtImp.Text == "")
            {
                Imp = 0;
            }
            else
            {
                Imp = System.Convert.ToInt32(txtImp.Text);
            }
            if (txtTDT.Text == "")
            {
                TDT = 0;
            }
            else
            {
                TDT = System.Convert.ToInt32(txtTDT.Text);
            }
            if (txtSisiT.Text == "")
            {
                SisiT = 0;
            }
            else
            {
                SisiT = System.Convert.ToInt32(txtSisiT.Text);
            }
            if (txtFFAud.Text == "")
            {
                FFA = 0;
            }
            else
            {
                FFA = System.Convert.ToInt32(txtFFAud.Text);
            }
            if (txtSE.Text == "")
            {
                SE = 0;
            }
            else
            {
                SE = System.Convert.ToInt32(txtSE.Text);
            }
            if (txtStD.Text == "")
            {
                StD = 0;
            }
            else
            {
                StD = System.Convert.ToInt32(txtStD.Text);
            }
            if (txtStM.Text == "")
            {
                StM = 0;
            }
            else
            {
                StM = System.Convert.ToInt32(txtStM.Text);
            }
            if (txtHAP.Text == "")
            {
                HAP = 0;
            }
            else
            {
                HAP = System.Convert.ToInt32(txtHAP.Text);
            }
            if (txtCoun.Text == "")
            {
                Coun = 0;
            }
            else
            {
                Coun = System.Convert.ToInt32(txtCoun.Text);
            }
            //if (txt_bill_amt.Text == "")
            //{
            //    txt_bill_amt.Text = "0";
            //}
            //else
            //{
            int amt = System.Convert.ToInt32(txt_bill_amt.Text);
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
            string Flag = "I";

            cn.Open();
            cmd = new SqlCommand("tbl_test_bill_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ptest_bill_no", bill_no);
            cmd.Parameters.AddWithValue("@pInvcNo", InvcNo); 
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@pptnt_nm", part);
            cmd.Parameters.AddWithValue("@pparticulars", Perti);
            cmd.Parameters.AddWithValue("@pPTA", PTA);
            cmd.Parameters.AddWithValue("@pBera", Bera);
            cmd.Parameters.AddWithValue("@pImp", Imp);
            cmd.Parameters.AddWithValue("@pTDT", TDT);
            cmd.Parameters.AddWithValue("@pSisiT", SisiT);
            cmd.Parameters.AddWithValue("@pFFA", FFA);
            cmd.Parameters.AddWithValue("@pSE", SE);
            cmd.Parameters.AddWithValue("@pSTD", StD);
            cmd.Parameters.AddWithValue("@pStM", StM);
            cmd.Parameters.AddWithValue("@pHAP", HAP);
            cmd.Parameters.AddWithValue("@pCoun", Coun);
            cmd.Parameters.AddWithValue("@pamt", amt);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
            int a=cn.executeprocedure(cmd);
            lbl_bill_no.Value = a.ToString();
            cn.Close();
            btnsave.Enabled = false;
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                print();
            }
            else
            {
                Response.Redirect("~/bill_Display.aspx");
            }
            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
            btnPrint.Enabled = true;
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
        }
        #endregion
    }
   
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtptnt_nm.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    //protected void txtCoun_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int I = Convert.ToInt32(txtImp.Text);
    //    int T = Convert.ToInt32(txtTDT.Text);
    //    int Si = Convert.ToInt32(txtSisiT.Text);
    //    int FA = Convert.ToInt32(txtFFAud.Text);
    //    int SE = Convert.ToInt32(txtSE.Text);
    //    int SD = Convert.ToInt32(txtStD.Text);
    //    int SM = Convert.ToInt32(txtStM.Text);
    //    int H = Convert.ToInt32(txtHAP.Text);
    //    int C = Convert.ToInt32(txtCoun.Text);
    //    int Amt = ((P) + (B) + (I) + (T) + (Si) + (SD) + (SM) + (SE) + (H) + (FA) + (C));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //}
    //protected void txtPTA_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int Amt = ((P));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //    txtBera.Focus();       
    //}
    //protected void txtBera_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int Amt = ((P) + (B));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //    txtImp.Focus();
    //}
    //protected void txtImp_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int I = Convert.ToInt32(txtImp.Text);
    //    int Amt = ((P) + (B) + (I));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //    txtTDT.Focus();
    //}
    //protected void txtTDT_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int I = Convert.ToInt32(txtImp.Text);
    //    int T = Convert.ToInt32(txtTDT.Text);
    //    int Amt = ((P) + (B) + (I) + (T));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //    txtSisiT.Focus();
    //}
    //protected void txtSisiT_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int I = Convert.ToInt32(txtImp.Text);
    //    int T = Convert.ToInt32(txtTDT.Text);
    //    int Si = Convert.ToInt32(txtSisiT.Text);
    //    int Amt = ((P) + (B) + (I) + (T) + (Si));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //    txtFFAud.Focus();
    //}
    //protected void txtFFAud_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int I = Convert.ToInt32(txtImp.Text);
    //    int T = Convert.ToInt32(txtTDT.Text);
    //    int Si = Convert.ToInt32(txtSisiT.Text);
    //    int FA = Convert.ToInt32(txtFFAud.Text);
    //    int Amt = ((P) + (B) + (I) + (T) + (Si) + (FA));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //    txtSE.Focus();
    //}
    //protected void txtSE_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int I = Convert.ToInt32(txtImp.Text);
    //    int T = Convert.ToInt32(txtTDT.Text);
    //    int Si = Convert.ToInt32(txtSisiT.Text);
    //    int FA = Convert.ToInt32(txtFFAud.Text);
    //    int SE = Convert.ToInt32(txtSE.Text);
    //    int Amt = ((P) + (B) + (I) + (T) + (Si) + (FA) + (SE));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //    txtStD.Focus();
    //}
    //protected void txtStD_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int I = Convert.ToInt32(txtImp.Text);
    //    int T = Convert.ToInt32(txtTDT.Text);
    //    int Si = Convert.ToInt32(txtSisiT.Text);
    //    int FA = Convert.ToInt32(txtFFAud.Text);
    //    int SE = Convert.ToInt32(txtSE.Text);
    //    int SD = Convert.ToInt32(txtStD.Text);
    //    int Amt = ((P) + (B) + (I) + (T) + (Si) + (FA) + (SE) + (SD));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //    txtStM.Focus();
    //}
    //protected void txtStM_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int I = Convert.ToInt32(txtImp.Text);
    //    int T = Convert.ToInt32(txtTDT.Text);
    //    int Si = Convert.ToInt32(txtSisiT.Text);
    //    int FA = Convert.ToInt32(txtFFAud.Text);
    //    int SE = Convert.ToInt32(txtSE.Text);
    //    int SD = Convert.ToInt32(txtStD.Text);
    //    int SM = Convert.ToInt32(txtStM.Text);
    //    int Amt = ((P) + (B) + (I) + (T) + (Si) + (FA) + (SE) + (SD) + (SM));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //    txtHAP.Focus();
    //}
    //protected void txtHAP_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int I = Convert.ToInt32(txtImp.Text);
    //    int T = Convert.ToInt32(txtTDT.Text);
    //    int Si = Convert.ToInt32(txtSisiT.Text);
    //    int FA = Convert.ToInt32(txtFFAud.Text);
    //    int SE = Convert.ToInt32(txtSE.Text);
    //    int SD = Convert.ToInt32(txtStD.Text);
    //    int SM = Convert.ToInt32(txtStM.Text);
    //    int H = Convert.ToInt32(txtHAP.Text);
    //    int Amt = ((P) + (B) + (I) + (T) + (Si) + (FA) + (SE) + (SD) + (SM) + (H));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //    txtOther.Focus();
    //}
    //protected void txtOther_TextChanged(object sender, EventArgs e)
    //{
    //    int P = Convert.ToInt32(txtPTA.Text);
    //    int B = Convert.ToInt32(txtBera.Text);
    //    int I = Convert.ToInt32(txtImp.Text);
    //    int T = Convert.ToInt32(txtTDT.Text);
    //    int Si = Convert.ToInt32(txtSisiT.Text);
    //    int FA = Convert.ToInt32(txtFFAud.Text);
    //    int SE = Convert.ToInt32(txtSE.Text);
    //    int SD = Convert.ToInt32(txtStD.Text);
    //    int SM = Convert.ToInt32(txtStM.Text);
    //    int H = Convert.ToInt32(txtHAP.Text);
    //    int O = Convert.ToInt32(txtOther.Text);
    //    int C = Convert.ToInt32(txtCoun.Text);
    //    int Amt = ((P) + (B) + (I) + (T) + (Si) + (FA) + (SE) + (SD) + (SM) + (H) + (C) + (O));
    //    txt_bill_amt.Text = System.Convert.ToString(Amt);
    //}
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/bill_Display.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        print();
    }
    public void print()
    {
        if (lbl_bill_no.Value != "")
        {
            int billno = Convert.ToInt32(lbl_bill_no.Value);
            Response.Redirect("~/testbill.aspx?bill_no=" + billno);
        }
    }
}
