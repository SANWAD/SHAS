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

public partial class SelectPatient_HearingRpt : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    DataSet ds, ds1;
    string aptid, apt_for;
    double id;
    DateTime dt, dt1;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new connection();

        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login/login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                //#region Load Event


                #region machine Company


                cn.Open();
                //cmd = new SqlCommand("select distinct(hm_nm_rt),hm_nm_lt from tbl_hm_sale_trn", connection.con);
                cmd = new SqlCommand("select distinct(hm_nm_rt) from tbl_hm_sale_trn where hm_nm_rt=hm_nm_lt or hm_nm_rt<>hm_nm_lt ", connection.con);
                //select count(hm_nm_rt+hm_nm_lt) from tbl_hm_sale_trn where hm_sale_dt between  @p_F_dt and @p_To_dt and hm_nm_rt=@p_Mach_nm or hm_nm_lt=@p_Mach_nm 
                DataTable DT_comp = new DataTable();

                dr = cmd.ExecuteReader();
                DT_comp.Load(dr);

                //ddlSale_Mach_Search.DataSource = DT_comp;
                //ddlSale_Mach_Search.DataValueField = "hm_nm_rt";
                //ddlSale_Mach_Search.DataTextField = "hm_nm_rt";
                //ddlSale_Mach_Search.DataBind();
                //ddlSale_Mach_Search.Items.Insert(0, new ListItem("COMPANY", "ptnt_nm"));
                //ddlSale_Mach_Search.SelectedIndex = 0;
                dr = null;
                cn.Close();

                #endregion


                //ddl_mach_type.Visible = false;
                //ddl_mach_model.Visible = false;
                //ddl_comp.Visible = false;
                //txt_mach.Visible = false;               
                //#endregion
            }
        }
    }
    protected void rbtSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtSelect.SelectedIndex == 0)
        {
            Response.Redirect("~/Ptnt_Hearing_Comp_Grid.aspx");
            //txtptnt_nm.Visible = true;
            //lblComp.Visible = false;
            //txtCom.Visible = false;
            //txtModel.Visible = false;
            //lblMod.Visible = false;
            //txtdate.Visible = true;
            //lblto_date.Visible = true;           
            ////btn_nm.Visible = true;
            ////ddl_ptnt_nm.Visible = true;
            ////lblptnt_id.Visible = true;
            ////Label29.Visible = true;

            ////txtmodel_no.Visible = false;
            ////Button1.Visible = false;
            ////Label8.Visible = false;
            ////btnShow1.Visible = false;
            ////ddl_h_ac_des.Visible = false;

            
            ////Button2.Visible = false;
            ////Label1.Visible = false;
            ////btnShow2.Visible = false;


            ////calFrm_dt.Visible = false;
            ////calTo_dt.Visible = false;
            ////lblFrm_dt.Visible = false;
            ////txtFrm_dt.Visible = false;
            ////lblTo_Dt.Visible = false;
            ////txtTo_dt.Visible = false;
            ////lblSale_Mach.Visible = false;
            ////ddlSale_Mach_Search.Visible = false;
            ////btnCount.Visible = false;
            ////lblFrm_dt.Visible = false;
            ////lblTo_Dt.Visible = false;
            ////txtFrm_dt.Visible = false;
            ////txtTo_dt.Visible = false;
            ////calFrm_dt.Visible = false;
            ////calTo_dt.Visible = false;
        }
        else if (rbtSelect.SelectedIndex == 5)
        {
            Response.Redirect("~/Ptnt_Hearing_Comp_Grid.aspx");
            //lblComp.Visible = false;
            //txtCom.Visible = false;
            //txtModel.Visible = true;
            //lblMod.Visible = true;
            //txtdate.Visible = true;
            //lblto_date.Visible = true; 
            ////txtmodel_no.Visible = true;
            ////Button1.Visible = true;
            ////Label8.Visible = true;
            ////btnShow1.Visible = true;

            ////Label29.Visible = false;
            ////btnShow.Visible = false;
            ////txtptnt_nm.Visible = false;
            ////btn_nm.Visible = false;
            ////ddl_ptnt_nm.Visible = false;
            ////lblptnt_id.Visible = false;

            ////Button2.Visible = false;
            ////Label1.Visible = false;
            ////btnShow2.Visible = false;
            ////lblSale_Mach.Visible = false;
            ////ddlSale_Mach_Search.Visible = false;
            ////lblSal_mach.Visible = false;
            ////lblFrm_dt.Visible = false;
            ////lblTo_Dt.Visible = false;
            ////txtFrm_dt.Visible = false;
            ////txtTo_dt.Visible = false;
            ////calFrm_dt.Visible = false;
            ////calTo_dt.Visible = false;
        }
        else if (rbtSelect.SelectedIndex == 6)
        {
            Response.Redirect("~/Ptnt_Hearing_Comp_Grid.aspx");
            //txtCom.Visible = true;
            //lblComp.Visible = true;            
            //txtModel.Visible = false;
            //lblMod.Visible = false;
            //txtdate.Visible = true;
            //lblto_date.Visible = true; 
            ////Button2.Visible = true;
            ////Label1.Visible = true;
            ////btnShow2.Visible = true;


            ////Label29.Visible = false;
            ////btnShow.Visible = false;
            ////txtptnt_nm.Visible = false;
            ////btn_nm.Visible = false;
            ////ddl_ptnt_nm.Visible = false;
            ////lblptnt_id.Visible = false;

            ////txtmodel_no.Visible = false;
            ////Button1.Visible = false;
            ////Label8.Visible = false;
            ////btnShow1.Visible = false;
            ////ddl_h_ac_des.Visible = false;
            ////lblFrm_dt.Visible = false;
            ////lblTo_Dt.Visible = false;
            ////txtFrm_dt.Visible = false;
            ////txtTo_dt.Visible = false;
            ////calFrm_dt.Visible = false;
            ////calTo_dt.Visible = false;
        }
        else if (rbtSelect.SelectedIndex == 1)
        {
            Response.Redirect("~/DueAmount_Grid.aspx");
        }
        else if (rbtSelect.SelectedIndex == 2)
        {
            //Response.Redirect("~/Noof_Ptnt_RefBy_Doc_Grid.aspx");
            Response.Redirect("~/Noof_Ptnt_RefBy_Doc.aspx");
        }
        else if (rbtSelect.SelectedIndex == 3)
        {
            Response.Redirect("~/Reports_Admin.aspx");
            //calFrm_dt.Visible = true;
            //calTo_dt.Visible = true;
            //txtFrm_dt.Visible = true;
            //lblFrm_dt.Visible = true;
            //lblTo_Dt.Visible = true;
            //txtTo_dt.Visible = true;
            //lblSale_Mach.Visible = true;
            //ddlSale_Mach_Search.Visible = true;
            //btnCount.Visible = true;
            //lblSal_mach.Visible = true;

            //txtptnt_nm.Visible = false;
            //btn_nm.Visible = false;
            //ddl_ptnt_nm.Visible = false;
            //lblptnt_id.Visible = false;
            //Label29.Visible = false;
            //btnShow.Visible = false;

            //txtmodel_no.Visible = false;
            //Button1.Visible = false;
            //Label8.Visible = false;
            //btnShow1.Visible = false;
            //ddl_h_ac_des.Visible = false;

            txtCom.Visible = false;
            //Button2.Visible = false;
            //Label1.Visible = false;
            //btnShow2.Visible = false;
        }
        else if (rbtSelect.SelectedIndex == 4)
        {
            Response.Redirect("~/Ptnt_HAid_Acc_Rep_Grid.aspx");
        }
        else
        {

        }
    }
}
