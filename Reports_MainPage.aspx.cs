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

public partial class Reports : System.Web.UI.Page
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
               
            }
        }
    }
    public void Clear()
    {
        
    }     
    protected void btnCan_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Cam_Grid.aspx");
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {

    }   
    protected void lbtnptntList_Click(object sender, EventArgs e)
    {       
        Session["St_Pro_Name"] = "tbl_ptn_master_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void lbtnDoc_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_doc_master_g";
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnAcc_Click(object sender, EventArgs e)
    {
        //Session["St_Pro_Name"] = "tbl_h_ac_master_g";
        Session["St_Pro_Name"] = "Stok_ac_mast_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");        
    }
    protected void btnCenter_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_Center_master_g";
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnHAid_Click(object sender, EventArgs e)
    {
        //Session["St_Pro_Name"] = "tbl_machine_master_g";
        Session["St_Pro_Name"] = "Stok_H_Aid_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnProg_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_h_prog_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnHAid_Trial_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_trial_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnHAid_Repair_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_hm_rep_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnH_Hom_Trial_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "h_m_home_trial_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnHAid_Sale_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_hm_sale_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");        
    }
    protected void btnAdvert_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_advertising_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnApp_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_apointment_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnCamp_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_camp_trn_g";
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnPitty_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_test_bill_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnCompany_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "Comp_Mast_g";
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnEnq_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_Enquiry_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnEarM_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_ear_mould_tr_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnFun_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_func_meet_tr_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnAccSale_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_acc_sale_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnHAss_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_h_as_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnSAss_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_S_as_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnQuat_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_quatation_tr_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnCoch_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "Cho_Implant_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void lblInwd_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_inward_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void lblOutwd_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_out_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void lblDueAmt_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "sp_DueAmount_Grid_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void lblPtnt_CompModel_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "sp_Ptnt_Aid_and_Comp_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void lblPtntAll_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "sp_Ptnt_All_Data_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnHAid_Sale_Proc_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_hm_sale_Process_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnRptPend_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "SP_Report_Panding_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnQuot_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_quatation_tr_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnFut_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_apointment_Fut_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnWarr_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_hm_sale_trn_Warra_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnPCRpt_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "Pitty_Cash_Report";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");
    }
    protected void btnOrderForm_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_ord_nhm_trn_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");        
    }
    protected void btnMoldSt_Click(object sender, EventArgs e)
    {
        Session["St_Pro_Name"] = "tbl_Mol_Sts_g";
        Session["FDate"] = txtFr_Dt.Text;
        Session["EDate"] = txtTo_Dt.Text;
        Session["SEARCH"] = txtDesc.Text;
        Response.Redirect("Main Grid_Page_Grid.aspx");  
    }
}
