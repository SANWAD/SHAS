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
using System.Collections.Generic;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

public partial class Main_Grid : System.Web.UI.Page
{
    #region Declaration
    connection cn;
    //SqlCommand cmd;
   // SqlDataReader dr;
    //DataSet ds, ds1;
    //SqlDataAdapter da;
    //double id;
    string stored_pro_Name;
    double sum = 0;
    //DataTable dt, DT;
    int ptnt_id;
    string ptnt_nm;
    DateTime Fdate, Edate;
    public SqlConnection con = new SqlConnection();
    public void Connect()
    {
        con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connetionString"].ConnectionString);
    }
   // DateTime dt = System.DateTime.Now.Date;
    #endregion
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
                //Grid_Load();
            }
            Grid_Load();
        }
    }
    public void Grid_Load()
    { 
        #region Grid Load
        stored_pro_Name = Session["St_Pro_Name"].ToString();
         ptnt_id = 0;
         if (Session["SEARCH"].ToString() == "")
         {
             ptnt_nm = "";
         }
         else
         {
             ptnt_nm = Session["SEARCH"].ToString();
         }
        
         if (Session["FDate"].ToString() == "" || Session["EDate"].ToString() == "")
         {
             Fdate = Convert.ToDateTime(null);
             Edate = Convert.ToDateTime(null);
         }
         else
         {
             Fdate = DateTime.ParseExact(Session["FDate"].ToString(), "dd/MM/yyyy", null);
             Edate = DateTime.ParseExact(Session["EDate"].ToString(), "dd/MM/yyyy", null);
         }
       
        String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = stored_pro_Name;
        if (stored_pro_Name == "tbl_ptn_master_g")
        {
            cmd.Parameters.Add("@pptnt_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDATE", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDATE", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_doc_master_g")
        {
            cmd.Parameters.Add("@pDoc_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDATE", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDATE", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "Stok_ac_mast_g")//tbl_h_ac_master_g
        {
            cmd.Parameters.Add("@ph_ac_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDATE", SqlDbType.Date ).Value = Fdate;
            cmd.Parameters.Add("@pEDATE", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@Cntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if(stored_pro_Name == "tbl_Center_master_g")
        {
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
        }
        else if (stored_pro_Name == "tbl_machine_master_g")
        {
            cmd.Parameters.Add("@pMach_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
        }
        else if (stored_pro_Name == "Stok_H_Aid_g")
        {
            cmd.Parameters.Add("@pMach_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDATE", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@Cntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_h_prog_g")
        {
            cmd.Parameters.Add("@pH_Prog_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "h_m_home_trial_trn_g")
        {
            cmd.Parameters.Add("@p_H_t_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_trial_trn_g")
        {
            cmd.Parameters.Add("@p_Trial_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_hm_rep_trn_g")
        {
            cmd.Parameters.Add("@p_Hr_job_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_hm_sale_trn_g")
        {
            cmd.Parameters.Add("@p_Hm_sale_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_hm_sale_Process_trn_g")
        {
            cmd.Parameters.Add("@p_Hm_sale_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_advertising_trn_g")
        {
            cmd.Parameters.Add("@pAd_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_apointment_trn_g")
        {
            cmd.Parameters.Add("@pApt_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_camp_trn_g")
        {
            cmd.Parameters.Add("@pcamp_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_test_bill_g")
        {
            cmd.Parameters.Add("@ptest_bill_no", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "Comp_Mast_g")
        {
            cmd.Parameters.Add("@pComp_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
        }
        else if (stored_pro_Name == "tbl_Enquiry_g")
        {
            cmd.Parameters.Add("@pEnq_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_ear_mould_tr_g")
        {
            cmd.Parameters.Add("@pMould_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_func_meet_tr_g")
        {
            cmd.Parameters.Add("@pFun_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_acc_sale_g")
        {
            cmd.Parameters.Add("@pAcc_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_h_as_trn_g")
        {
            cmd.Parameters.Add("@pH_as_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_S_as_trn_g")
        {
            cmd.Parameters.Add("@pS_as_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_quatation_tr_g")
        {
            cmd.Parameters.Add("@pQuat_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "Cho_Implant_g")
        {
            cmd.Parameters.Add("@pCho_Impl_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_inward_trn_g")
        {
            cmd.Parameters.Add("@p_inw_no", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_out_trn_g")
        {
            cmd.Parameters.Add("@p_out_no", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "sp_DueAmount_Grid_g")
        {
            cmd.Parameters.Add("@pDue_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "sp_Ptnt_Aid_and_Comp_g")
        {
            cmd.Parameters.Add("@pSale_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "sp_Ptnt_All_Data_g")
        {
            cmd.Parameters.Add("@pPtnt_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "SP_Report_Panding_g")
        {
           // cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_quatation_tr_g")
        {
            cmd.Parameters.Add("@pQuat_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_apointment_Fut_trn_g")
        {
            cmd.Parameters.Add("@pApt_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDATE", SqlDbType.Date).Value = DateTime.Now;
            cmd.Parameters.Add("@pEDATE", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_hm_sale_trn_Warra_g")
        {
            cmd.Parameters.Add("@p_Hm_sale_id", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDATE", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDATE", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "Pitty_Cash_Report")
         {
            cmd.Parameters.Add("@pFDATE", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDATE", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "sp_Acc_HA_PurList")
        {
            cmd.Parameters.Add("@pDoc_Type", SqlDbType.VarChar).Value = Session["Doc_Type"].ToString();
            cmd.Parameters.Add("@pType", SqlDbType.VarChar).Value = Session["Type"].ToString();
            cmd.Parameters.Add("@pFDATE", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDATE", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_ord_nhm_trn_g")
        {
            cmd.Parameters.Add("@pord_no", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else if (stored_pro_Name == "tbl_Mol_Sts_g")
        {
            cmd.Parameters.Add("@pMold_No", SqlDbType.Int).Value = ptnt_id;
            cmd.Parameters.Add("@pSEARCH", SqlDbType.VarChar).Value = ptnt_nm;
            cmd.Parameters.Add("@pFDate", SqlDbType.Date).Value = Fdate;
            cmd.Parameters.Add("@pEDate", SqlDbType.Date).Value = Edate;
            cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
        }
        else
        {
 
        }
        cmd.Connection = con;
        try
        {
            con.Open();           
            string Report_Name = stored_pro_Name; 
            switch (Report_Name)
            {
                case "tbl_ptn_master_g":
                    lblHead.Text = "Patient Register";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_doc_master_g":
                    lblHead.Text = "Doctor Master";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "Stok_ac_mast_g"://tbl_h_ac_master_g
                    lblHead.Text = "Accessories Master";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_Center_master_g":
                    lblHead.Text = "Center Name Master";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_machine_master_g":
                    lblHead.Text = "Hearing Aid Master";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "Stok_H_Aid_g":
                    lblHead.Text = "Hearing Aid Stock";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();                   
                    break;
                case "tbl_h_prog_g":
                    lblHead.Text = "Hearing Aid Programming";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_trial_trn_g":
                    lblHead.Text = "Hearing Aid Trial";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "h_m_home_trial_trn_g":
                    lblHead.Text = "Hearing Aid Home Trial";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_hm_rep_trn_g":
                    lblHead.Text = "Hearing Aid Repair";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_hm_sale_trn_g":
                    lblHead.Text = "Hearing Aid Sale";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_hm_sale_Process_trn_g":
                    lblHead.Text = "Hearing Aid Sale in Process";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_advertising_trn_g":
                    lblHead.Text = "Advertising";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_apointment_trn_g":
                    lblHead.Text = "Appointment's";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_camp_trn_g":
                    lblHead.Text = "Camp's";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_test_bill_g":
                    lblHead.Text = "Petty Cash";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "Comp_Mast_g":
                    lblHead.Text = "Company Master";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_Enquiry_g":
                    lblHead.Text = "Enquiry";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_ear_mould_tr_g":
                    lblHead.Text = "Hearing Aid Mould";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_func_meet_tr_g":
                    lblHead.Text = "Function & Meeting";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_acc_sale_g":
                    lblHead.Text = "Accessories Sale";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_h_as_trn_g":
                    lblHead.Text = "Hearing Assesment";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_S_as_trn_g":
                    lblHead.Text = "Speech Assesment";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_quatation_tr_g":
                    lblHead.Text = "Hearing Aid Quotation";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "Cho_Implant_g":
                    lblHead.Text = "Choclear Implant";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_inward_trn_g":
                    lblHead.Text = "Inward";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_out_trn_g":
                    lblHead.Text = "Outward";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "sp_DueAmount_Grid_g":
                    lblHead.Text = "Due Amount";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "sp_Ptnt_Aid_and_Comp_g":
                    lblHead.Text = "Hearing Aid, Company";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "sp_Ptnt_All_Data_g":
                    lblHead.Text = "Patient All Data";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "SP_Report_Panding_g":
                    lblHead.Text = "Pending Report";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_apointment_Fut_trn_g":
                    lblHead.Text = "Future Appointment";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_hm_sale_trn_Warra_g":
                    lblHead.Text = "Hearing Aid Warranty";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "Pitty_Cash_Report":
                    lblHead.Text = "Petty Cash Report";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "sp_Acc_HA_PurList":
                    lblHead.Text = "Hearing Aid Or Accessories Purchase List";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_ord_nhm_trn_g":
                    lblHead.Text = "Order by Mail";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
                case "tbl_Mol_Sts_g":
                    lblHead.Text = "Mould Status";
                    GridView1.EmptyDataText = "No Records Found";
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    break;
            }               
        }
        catch (Exception ex)
        {
            //throw ex;
        }

        finally
        {
            con.Close();
            con.Dispose();
        }
         #endregion      
    }
    protected void btnAdSearch_Click(object sender, EventArgs e)
    {        
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=Export.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        HtmlForm frm = new HtmlForm();
        GridView1.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(GridView1);
        frm.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       // if(DropDownList1.SelectedIndex==2)
        //{
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //HtmlForm frm = new HtmlForm();
            //GridView1.Parent.Controls.Add(frm);
            //frm.Attributes["runat"] = "server";
            //frm.Controls.Add(GridView1);
            //frm.RenderControl(hw);
            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();
       // }
        //else if (DropDownList1.SelectedIndex == 3)
        //{
        //    Response.AddHeader("content-disposition", "attachment;filename=Export.doc");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = "application/vnd.word";
        //    StringWriter stringWrite = new StringWriter();
        //    HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //    HtmlForm frm = new HtmlForm();
        //    GridView1.Parent.Controls.Add(frm);
        //    frm.Attributes["runat"] = "server";
        //    frm.Controls.Add(GridView1);
        //    frm.RenderControl(htmlWrite);
        //    Response.Write(stringWrite.ToString());
        //    Response.End();
        //}
        //else
        //{
        //    string attachment = "attachment; filename=Export.xls";
        //    Response.ClearContent();
        //    Response.AddHeader("content-disposition", attachment);
        //    Response.ContentType = "application/ms-excel";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    HtmlForm frm = new HtmlForm();
        //    GridView1.Parent.Controls.Add(frm);
        //    frm.Attributes["runat"] = "server";
        //    frm.Controls.Add(GridView1);
        //    frm.RenderControl(htw);
        //    Response.Write(sw.ToString());
        //    Response.End();
        //}

    }
    protected void btnPdf_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        HtmlForm frm = new HtmlForm();
        GridView1.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(GridView1);
        frm.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int indexOfColumn = 0;
        if (e.Row.Cells.Count > indexOfColumn)
        {
            e.Row.Cells[indexOfColumn].Visible = false;
        }
        if (stored_pro_Name == "Pitty_Cash_Report")
        {
            lblPittyCash.Visible = true;
            lblPittyCash.Text = "Petty Cash";
            txtTotal.Visible = true;
            if (e.Row.Cells[7].Text != "TotalAmount")
            {
                //if()
                //{
                var  item = e.Row.Cells[7].Text;
                sum += Convert.ToDouble(item);
                //}
            }
            txtTotal.Text = Convert.ToString(sum);
        }
        if (stored_pro_Name == "tbl_hm_sale_trn_g")
        {
            lblPittyCash.Visible = true;
            lblPittyCash.Text = "H.Aid Discounted Amount";
            txtTotal.Visible = true;
            if (e.Row.Cells[16].Text != "Total Amount")
            {
                var item = e.Row.Cells[16].Text;
                sum += Convert.ToDouble(item);
            }
            txtTotal.Text = Convert.ToString(sum);
        }
        if (stored_pro_Name == "tbl_acc_sale_g")
        {
            lblPittyCash.Visible = true;
            lblPittyCash.Text = "Accessories Amount";
            txtTotal.Visible = true;
            if (e.Row.Cells[10].Text != "Total Amount")
            {
                var item = e.Row.Cells[10].Text;
                sum += Convert.ToDouble(item);
            }
            txtTotal.Text = Convert.ToString(sum);
        }
        if (stored_pro_Name == "sp_DueAmount_Grid_g")
        {
            lblPittyCash.Visible = true;
            lblPittyCash.Text = "Due Charge";
            txtTotal.Visible = true;
            if (e.Row.Cells[5].Text != "Due Charge")
            {
                var item = e.Row.Cells[5].Text;
                sum += Convert.ToDouble(item);
            }
            txtTotal.Text = Convert.ToString(sum);
        }
        if (stored_pro_Name == "sp_Ptnt_All_Data_g")
        {
            lblPittyCash.Visible = true;
            lblPittyCash.Text = "Total Price";
            txtTotal.Visible = true;
            if (e.Row.Cells[6].Text != "Price")
            {
                var item = e.Row.Cells[6].Text;
                sum += Convert.ToDouble(item);
            }
            txtTotal.Text = Convert.ToString(sum);
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (stored_pro_Name == "tbl_h_as_trn_g")
        //{
            print();           
        //}
        //else
        //{}
    }
    public void print()
    {
        if (stored_pro_Name == "tbl_h_as_trn_g")
        {
            Session["H_as_id"] = GridView1.SelectedRow.Cells[1].Text;
            if (Session["H_as_id"].ToString() != "")
            {
                int billno = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                Response.Redirect("~/h_as.aspx?bill_no=" + billno);
            }
        }
        else if (stored_pro_Name == "tbl_hm_sale_trn_g")
        {
            int billno = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                Response.Redirect("~/h_m_Chll.aspx?bill_no=" + billno);            
        }
        else
        {
        }
    }
}
