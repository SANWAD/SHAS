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
using System.Web.UI.WebControls.Adapters;

public partial class acc_sale_Reg : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd, cmd1;
    SqlDataReader dr,dr1;
    DataSet ds, ds1;
    SqlDataAdapter da;
    double id;
    string Doc_Type;
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
            Doc_Type = Session["Doc_Type"].ToString();
            if (!IsPostBack)
            {
                //DateTime dt = DateTime.Now;
                //txtDoc_Date.Text = dt.ToShortDateString();

                #region ACCESSORIES
                cn.Open();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_Acc_Nm_ddl";
                DataTable DT_ac = new DataTable();

                dr = cmd.ExecuteReader();
                DT_ac.Load(dr);

                ddlacc_desc.DataSource = DT_ac;
                ddlacc_desc.DataValueField = "h_ac_id";

                ddlacc_desc.DataTextField = "h_ac_name";
                ddlacc_desc.DataBind();
                ddlacc_desc.Items.Insert(0, new ListItem("Select", "h_ac_name"));
                ddlacc_desc.SelectedIndex = 0;
                dr = null;
                cn.Close();
                #endregion
                Select();
                btnsave.Enabled = false;
                optRchk.Focus();
                btnPrint.Enabled = true;
                if (Doc_Type == "PA")
                {
                    lblHeading.Text = "Accessories Purchase";
                    txtptnt_nm.Text = "PURCHASE";
                    Label3.Text = "Purchase";
                    lblDoc_Date.Text = "Purchase Date";
                    Label12.Text = "Purchase Price";
                    Label14.Text = "Add Quantity";
                }
                else
                {
                    lblHeading.Text = "Accessories Sale";
                    Label3.Text = "Patient Name";
                    lblDoc_Date.Text = "Sale Date";
                    Label12.Text = "Sale Price";
                    Label14.Text = "Sale Quantity";
                }
            }
        }
    }
    public void Select()
    {
        if (Request.QueryString["Acc_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Acc_Id"].ToString());
                double CtrID = System.Convert.ToInt32(id1);

                cn.Open();

                cmd = new SqlCommand("tbl_acc_sale_Id", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pAcc_id", CtrID);
                //cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblsale_id.Value = DT1.Rows[0][0].ToString();
                lblptnt_id.Value = DT1.Rows[0][10].ToString();
                txtptnt_nm.Text = DT1.Rows[0][1].ToString();
                ddlacc_desc.SelectedItem.Text  = DT1.Rows[0][3].ToString();
                txtPrice.Text = DT1.Rows[0][4].ToString();
                txtqty.Text = DT1.Rows[0][5].ToString();
                txtrecamt.Text = DT1.Rows[0][9].ToString();
                txtDoc_Date.Text = DT1.Rows[0][11].ToString();
                dr = null;
                cn.Close();
                btnPrint.Enabled = true;
                btnsave.Text = "Edit";
            }
            catch
            { }

            #endregion
        }
    }

    #region validation
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (char.IsNumber(txtPrice.Text, 0))
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (char.IsNumber(txtqty.Text,0))
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (char.IsNumber(txtrecamt.Text,0))
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    #endregion
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (btnsave.Text == "Edit")
        {

        }
        else
        {
        #region Save
        try
        {
            string Doc_Type = Session["Doc_Type"].ToString();
            DateTime dt = Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString());
            //DateTime Doc_Date = System.Convert.ToDateTime(txtDoc_Date.Text);
            DateTime Doc_Date = DateTime.ParseExact(txtDoc_Date.Text, "dd/MM/yyyy", null);
            int PTA = 0, Bera = 0, Imp = 0, TDT = 0, SisiT = 0, FFA = 0, SE = 0, StD = 0, StM = 0, HAP = 0, Coun = 0;
            int Pid;
            string RegChk;
            string ptnt_nm;
            string Name;
            //int acc_sale_id = Convert.ToInt32(lblsale_id.Value);
            int acc_sale_id = 0;
            if (optRchk.SelectedIndex == 0)
            {
                string ptnt_nm1 = txtptnt_nm.Text;
                string[] WordArray = ptnt_nm1.Split('-');
                Name = WordArray[0].ToString();
                //lblptnt_id.Value = WordArray[1];
                if (Doc_Type == "PA")
                {
                    lblptnt_id.Value = null;
                    Pid = Convert.ToInt32(0);
                    ptnt_nm = "Purchase";
                }
                else
                {
                    lblptnt_id.Value = WordArray[1];
                    Pid = Convert.ToInt32(lblptnt_id.Value);
                   // ptnt_nm = txtptnt_nm.Text.ToString();
                    ptnt_nm = Name;
                }                                
                RegChk = "R";
            }
            else
            {
                Pid = 0;
                ptnt_nm = txtptnt_nm.Text.ToString();
                RegChk = "UR";
            }
            if (ddlacc_desc.SelectedItem.Text == "Select")
            {
                //Response.Write("<script language='JavaScript'>alert('Please Select Accessories')</script>");
            }
            else
            {               
                string acc = ddlacc_desc.SelectedItem.Text.ToString();
                double price = System.Convert.ToDouble(txtPrice.Text);
                int qty = System.Convert.ToInt32(txtqty.Text);
                int amt = System.Convert.ToInt32(txtrecamt.Text);
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());
                int Q = Convert.ToInt32(lblQty.Text);
                string Flag = "I";
                if (Doc_Type == "PA" || Doc_Type == "SA")
                {
                    if (Q >= qty && Doc_Type == "SA")
                    {
                        cn.Open();
                        cmd = new SqlCommand("tbl_acc_sale_c", connection.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pFlag", Flag);
                        cmd.Parameters.AddWithValue("@pacc_sale_id", acc_sale_id);
                        cmd.Parameters.AddWithValue("@pDoc_Type", Doc_Type);
                        cmd.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                        cmd.Parameters.AddWithValue("@pptnt_id", Pid);
                        cmd.Parameters.AddWithValue("@pptnt_nm", ptnt_nm);
                        cmd.Parameters.AddWithValue("@pacc_desc", acc);
                        cmd.Parameters.AddWithValue("@pacc_price", price);
                        cmd.Parameters.AddWithValue("@pacc_qty", qty);
                        cmd.Parameters.AddWithValue("@pacc_amt_rec", amt);
                        cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                        cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                        int a = cn.executeprocedure(cmd);
                        lblsale_id.Value = a.ToString();
                        cn.Close();
                        btnsave.Enabled = false;
                        btnCancel.Text = "Exit";
                        string confirmValue = Request.Form["confirm_value"];
                        if (confirmValue == "Yes")
                        {
                            print();
                        }
                        else
                        {
                            //Response.Redirect("~/acc_sale_Reg_Grid.aspx");
                        }                        
                    }
                    else
                    {
                        cn.Open();
                        cmd = new SqlCommand("tbl_acc_sale_c", connection.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pFlag", Flag);
                        cmd.Parameters.AddWithValue("@pacc_sale_id", acc_sale_id);
                        cmd.Parameters.AddWithValue("@pDoc_Type", Doc_Type);
                        cmd.Parameters.AddWithValue("@pDoc_Date", Doc_Date);
                        cmd.Parameters.AddWithValue("@pptnt_id", Pid);
                        cmd.Parameters.AddWithValue("@pptnt_nm", ptnt_nm);
                        cmd.Parameters.AddWithValue("@pacc_desc", acc);
                        cmd.Parameters.AddWithValue("@pacc_price", price);
                        cmd.Parameters.AddWithValue("@pacc_qty", qty);
                        cmd.Parameters.AddWithValue("@pacc_amt_rec", amt);
                        cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                        cmd.Parameters.AddWithValue("@pCntr_id", Cntr_id);
                        int a = cn.executeprocedure(cmd);
                        lblsale_id.Value = a.ToString();
                        cn.Close();
                        btnsave.Enabled = false;
                        btnCancel.Text = "Exit";
                        string confirmValue = Request.Form["confirm_value"];
                        if (confirmValue == "Yes")
                        {
                            print();
                        }
                        else
                        {
                            //Response.Redirect("~/acc_sale_Reg_Grid.aspx");
                        } 
                        //Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
                }
            }            
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
        }
        #endregion
        }       
    }    
    protected void ddlacc_desc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlacc_desc.SelectedIndex > 0)
        {
            #region Acc Price
            try
            {
                string[] arrrSelVal = ddlacc_desc.SelectedValue.Split(',');
                double pid = System.Convert.ToInt32(arrrSelVal[0]);
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());

                cmd = new SqlCommand("sp_Acc_Sale_H", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_Dd_id", pid);
                cmd.Parameters.AddWithValue("@Cntr_id", Cntr_id);
                cn.Open();
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                if (Doc_Type == "PA")
                {
                    lblsale_id.Value = DT1.Rows[0][0].ToString();
                    txtPrice.Text = DT1.Rows[0][2].ToString();
                    txtPrice.Enabled = false;
                    string Qty = DT1.Rows[0][3].ToString();
                    int Qty1 = Convert.ToInt32(Qty);
                    lblQty.Text = DT1.Rows[0][3].ToString();
                    //if (Qty1 > 0)
                    //{
                    //    btnsave.Enabled = true;
                    //}
                    //else
                    //{
                    //    //Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
                    //    btnsave.Enabled = false;
                    //}
                    btnsave.Enabled = true;
                }
                else
                {
                    lblsale_id.Value = DT1.Rows[0][0].ToString();
                    txtPrice.Text = DT1.Rows[0][4].ToString();
                    txtPrice.Enabled = false;
                    string Qty = DT1.Rows[0][3].ToString();
                    int Qty1 = Convert.ToInt32(Qty);

                    lblQty.Text = DT1.Rows[0][3].ToString();
                    if (Qty1 > 0)
                    {
                        btnsave.Enabled = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('Not Sufficient Stock Please Add Stock')</Script>");
                        btnsave.Enabled = false;
                    }
                    btnsave.Enabled = true;
                }

                dr = null;
                cn.Close();
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Please Add Purchase Entry')</script>");
            }
            #endregion
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("acc_sale_Reg_Grid.aspx");
    }
    //protected void txtqty_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtPrice.Text != "" && txtqty.Text != "")
    //    {
    //        int P = System.Convert.ToInt32(txtPrice.Text);
    //        int qty = System.Convert.ToInt32(txtqty.Text);
    //        int amt;
    //        amt = P * (qty);
    //        txtrecamt.Text = System.Convert.ToString(amt);
    //        btnsave.Enabled = true;            
    //    }
    //    else
    //    {
    //        Response.Write("<script language='JavaScript'>alert('Please Select Accessories First')</script>");
    //    }
    //}
    protected void optRchk_SelectedIndexChanged(object sender, EventArgs e)
    {        
        if(optRchk.SelectedIndex==1)
        {
           // btn_nm.Visible = false;
            //ddl_ptnt_nm.Visible = false;
        }
        else
        {            
            //btn_nm.Visible = true;
            //ddl_ptnt_nm.Visible = true;
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        print();
    }
    public void print()
    {
        if (lblsale_id.Value != "")
        {
            int billno = Convert.ToInt32(lblsale_id.Value);
            Response.Redirect("~/acc_bill.aspx?bill_no=" + billno);
        }
    }
    protected void txtqty_TextChanged(object sender, EventArgs e)
    {
        if (Session["Doc_Type"].ToString() == "SA")
        {
            #region Acc Price
            try
            {
                string[] arrrSelVal = ddlacc_desc.SelectedValue.Split(',');
                double pid = System.Convert.ToInt32(arrrSelVal[0]);
                int Cntr_id = Convert.ToInt32(Session["Cntr_id"].ToString());

                cmd1 = new SqlCommand("sp_Acc_Sale_H1", connection.con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@p_Dd_id", pid);
                cmd1.Parameters.AddWithValue("@Cntr_id", Cntr_id);
                cn.Open();
                cn.executeprocedure(cmd1);
                DataTable DT2 = new DataTable();
                cn.Open();
                dr1 = cmd1.ExecuteReader();
                DT2.Load(dr1);
                lblsale_id.Value = DT2.Rows[0][0].ToString();
                int Q = Convert.ToInt32(DT2.Rows[0][3].ToString());
                cn.Close();
                cmd = new SqlCommand("sp_Acc_Sale_H", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_Dd_id", pid);
                cmd.Parameters.AddWithValue("@Cntr_id", Cntr_id);
                cn.Open();
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblsale_id.Value = DT1.Rows[0][0].ToString();
               //txtPrice.Text = DT1.Rows[0][2].ToString();
                txtPrice.Text = DT1.Rows[0][4].ToString();
                txtPrice.Enabled = false;
                string Qty = DT1.Rows[0][3].ToString();
                //int Qty1 = (Convert.ToInt32(Qty) - (Q + Convert.ToInt32(txtqty.Text)));
                int Qty1 = (Convert.ToInt32(Qty) - (Convert.ToInt32(txtqty.Text)));
                lblQty.Text = DT1.Rows[0][3].ToString();
                if (Qty1 >= 0)
                {
                    btnsave.Enabled = true;
                }
                else
                {
                    Response.Write("<script>alert('Not Sufficient Stock Please Add Purchase Entry')</Script>");
                    btnsave.Enabled = false;
                }
                //btnsave.Enabled = true;
                dr = null;
                cn.Close();
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Please Add Purchase Entry')</script>");
            }
            #endregion
        }
        else
        {
 
        }
    }
}
