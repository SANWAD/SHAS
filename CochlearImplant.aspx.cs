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
using System.Text.RegularExpressions;

public partial class CochlearImplant : System.Web.UI.Page
{
    connection cn;
    connection con;
    SqlCommand cmd;
    SqlDataReader dr;
    DataSet ds,ds1;
    string aptid, apt_for;
    double id;
    DateTime dt, Birth_Dt;
    SqlDataAdapter da;    
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new connection();

        if (Session["Name"] ==null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
         if (!IsPostBack)
            {
                #region Load Event 
                rbtearsite.Enabled  = true;               
                Label8.Enabled = false;
                Label9.Enabled = false;
                lblSPML.Enabled = false;
                lblSNL.Enabled = false;
                lblDFFL.Enabled = false;
                txtSPMR.Enabled = false;
                txtDFFL.Enabled = false;
                txtSNL.Enabled = false;
                txtDFFL.Enabled = false;
                Label17.Enabled = false;
                Label18.Enabled = false;
                Label19.Enabled = false;
                lblSPMR.Enabled = false;
                lblSNR.Enabled = false;
                lblDFFR.Enabled = false;
                txtSPML.Enabled = false;
                txtDFFR.Enabled = false;
                txtSNR.Enabled = false;
                txtDFFR.Enabled = false;

                cn.Open();
                ddl_Surgeon.Items.Clear(); 
                cmd = new SqlCommand("sp_Doc_SelDoc_nm", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                
                DataTable DT1 = new DataTable();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                ddl_Surgeon.DataSource = DT1;
                ddl_Surgeon.DataValueField = "doc_id";
                ddl_Surgeon.DataTextField = "doc_nm";
                ddl_Surgeon.Items.Insert(0, new ListItem("Self Refered", "doc_nm"));
                ddl_Surgeon.SelectedIndex = 0;
                ddl_Surgeon.DataBind();
                dr = null;
                cn.Close();

                #region machine Company

                Image1.Visible = false;
                cn.Open();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_Mach_Desc_ddl";
                DataTable DT_comp = new DataTable();

                dr = cmd.ExecuteReader();
                DT_comp.Load(dr);
                dr = null;
                cn.Close();
                #endregion
            #endregion               

                if (Convert.ToInt32(Session["CoCh_Id"].ToString()) == 0)
                {
                    int CoCh_Id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    aptid = Request.QueryString["id"].ToString();
                    DataFill(CoCh_Id);
                }
                else
                {
                   Select();
                }
                //int Apt_id = Convert.ToInt32(Request.QueryString["id"].ToString());
                //DataFill(Apt_id);
            }
        }
        
   }
    public void Select()
    {
        if (Convert.ToInt32(Session["Ass_id"].ToString()) != 0)
        {
            #region Select
            try
            {
                string id1;
                id1 = (Session["Ass_id"].ToString());
                int Ass_id = System.Convert.ToInt32(id1);

                cn.Open();
                cmd = new SqlCommand("sp_Cho_Impl_Id_Rpt", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pCho_Impl_id", Ass_id);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblas_id.Value = DT1.Rows[0][0].ToString();
                lblaptid.Value = DT1.Rows[0][1].ToString();
                DataFill(Convert.ToInt32(lblaptid.Value));               
                ddl_Surgeon.SelectedItem.Text = DT1.Rows[0][3].ToString();
                txtSurDate.Text = DT1.Rows[0][4].ToString();
                txtbirthhistry.Text = DT1.Rows[0][5].ToString();
                txtmedhistry.Text = DT1.Rows[0][6].ToString();
                txtImpMod.Text = DT1.Rows[0][8].ToString();
                txtSrno.Text = DT1.Rows[0][9].ToString();
                txtSPMR.Text = DT1.Rows[0][10].ToString();
                txtSNR.Text = DT1.Rows[0][11].ToString();
                txtDFFR.Text = DT1.Rows[0][12].ToString();
                txtSPML.Text = DT1.Rows[0][13].ToString();
                txtSNL.Text = DT1.Rows[0][14].ToString();
                txtDFFL.Text = DT1.Rows[0][15].ToString();
                string Site = DT1.Rows[0][7].ToString();
                if (Site == "Left")
                {
                    rbtearsite.SelectedIndex = 0;
                }
                else if (Site == "Right")
                {
                    rbtearsite.SelectedIndex = 1;
                }
                else
                {
                    rbtearsite.SelectedIndex = 2;
                }
                int ptn_Id = Convert.ToInt32(DT1.Rows[0][2].ToString());
                dr = null;
                cn.Close();
                FilldeptInGrid(ptn_Id);
                btn_save.Text = "Edit";
            }
            catch
            { }

            #endregion
        }
    }
    public void DataFill(int Apt_id)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["Sanwad"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_ptnt_info_Apt_id";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_apt_id", Apt_id);
                lblaptid.Value = Apt_id.ToString();
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        lblptnt_id.Value = sdr["ptnt_id"].ToString();
                        lblptnttype.Text = sdr["Ptntype"].ToString();
                        txtptnt_nm.Text = sdr["ptnt_nm"].ToString();
                        lblptntdob.Text = sdr["ptnt_dob"].ToString();
                        DateTime CHDT = Convert.ToDateTime(lblptntdob.Text);
                        lblgender.Text = sdr["ptnt_gender"].ToString();
                        lblprofession.Text = sdr["ptnt_prof"].ToString();
                        dt = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
                       //Birth_Dt = DateTime.ParseExact(lblptntdob.Text, "dd/MM/yyyy", null);
                        Birth_Dt = CHDT;
                        string Year = Convert.ToString((dt.Year) - (Birth_Dt.Year));
                        string Month = Convert.ToString((dt.Month) - (Birth_Dt.Month));
                        string Days = Convert.ToString((dt.Day) - (Birth_Dt.Day));
                        lblptntage.Text = (Year + " Year" + ',' + Month + " Month" + ',' + Days + " Days");
                        txtptnt_nm.Enabled = false;
                        lblptntdob.Enabled = false;
                        lblgender.Enabled = false;
                        lblprofession.Enabled = false;
                        lblptntage.Enabled = false;                        
                    }
                }
                conn.Close();
            }
        }
    }
    private void FilldeptInGrid( int Ass_id)
    {
        #region Grid Load
        double pid = System.Convert.ToInt32(lblptnt_id.Value);
        cn.Open();
        cmd = connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT Cho_Impl_id,apt_id,ptnt_id,Nm_Surg,Surg_Dt,birth_histry,med_histry, Ear_Implant,Implant_Model,Sr_No,RSp_Pr_Mod,RSr_No,RDt_Fst_Ftd,LSp_Pr_Mod,LSr_No,LDt_Fst_Ftd,created_by,revised_by,created_dt,revised_dt FROM  Cho_Implant WHERE(ptnt_id =" + Ass_id + ")";
        

        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "Cho_Implant");

        if (ds.Tables["Cho_Implant"].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables["Cho_Implant"];
            GridView1.DataBind();
            Label1.Text = (ds.Tables["Cho_Implant"].Rows[0][2].ToString());
        }
        else
        {
            Response.Write("<script>alert('Please Select Valid Patient')</script>");
        }
        #endregion
        cn.Close();
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
    protected void btn_save_Click(object sender, EventArgs e)
    {       
        #region Save
        int Imp_id = 0;
        int aptid = System.Convert.ToInt32(lblaptid.Value);
        int ptntid = System.Convert.ToInt32(lblptnt_id.Value);
        string Ear_Imp = "";
        string birth_h = txtbirthhistry.Text.ToString();
        string med_h = txtmedhistry.Text.ToString();
        string Nm_Surg = ddl_Surgeon.SelectedItem.Text.ToString();
        DateTime Sur_Dt = Convert.ToDateTime(txtSurDate.Text);
        int SiteEar = rbtearsite.SelectedIndex;
        string SPMR = "";
        DateTime DFFR = Convert.ToDateTime(txtDFFL.Text);
        string SNR = "";
        string SPML = "";
        DateTime DFFL = Convert.ToDateTime(txtDFFL.Text);
        string SNL = txtSNL.Text;   
        if (SiteEar== 0)
        {
            Ear_Imp = "R";
            txtSPML.Text = "";
            txtDFFL.Text = "1/1/2001";
            txtSNL.Text = "";           
             SPMR = txtSPMR.Text;
             //DFFR = "1/1/2001";
            SNR=txtSNR.Text;            
            DFFL = Convert.ToDateTime(txtDFFL.Text);
            SNL = txtSNL.Text;            
        }
        else if (SiteEar == 1)
        {
           Ear_Imp = "L";
            txtSPMR.Text = "";
            txtDFFR.Text = "1/1/2001";
            txtSNR.Text = "";            
           SPML = txtSPMR.Text;            
            SNL = txtSNR.Text;           
             DFFL = Convert.ToDateTime(txtDFFL.Text);
            SNL = txtSNL.Text; 
        }
        else
        {
           Ear_Imp = "B";
            //txtSPMR.Text = "";
            //txtDFFR.Text = "";
            //txtSNR.Text = "";
            //txtDFFR.Text = "";
            //txtSPML.Text = "";
            //txtDFFL.Text = "";
            //txtSNL.Text = "";
            //txtDFFL.Text = "";
             SPMR = txtSPMR.Text;
             DFFR = Convert.ToDateTime(txtDFFR.Text);
            SNR = txtSNR.Text;
             SPML = txtSPML.Text;
             DFFL = Convert.ToDateTime(txtDFFL.Text);
            SNL = txtSNL.Text;   
        }
        //string Ear_Imp = rbtearsite.SelectedValue;
        string Impl_Model = txtImpMod.Text.ToString();
        string Sr_No = txtSrno.Text;
        //string RSp_Pro_Model = txtSPMR.Text.ToString();
        //string RSrNo = txtSNR.Text.ToString();
        //DateTime  RDFF = Convert.ToDateTime(txtDFFR.Text);

        string LSp_Pro_Model = txtSPMR.Text.ToString();
        string LSrNo = txtSNR.Text.ToString();
        DateTime  LDFF = Convert.ToDateTime(txtDFFR.Text);
        int  cr_by =Convert.ToInt32(Session["Name"].ToString());
        //string p_h_u = (rbtp_h_a_user.SelectedItem.Text).ToString();
        //string ear_sit;
             string Flag = "I";
     
            try
            {
                cn.Open();
                cmd = new SqlCommand("Cho_Implant_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pCho_Impl_id", Imp_id);
                cmd.Parameters.AddWithValue("@papt_id", aptid);
                cmd.Parameters.AddWithValue("@pptnt_id", ptntid);
                cmd.Parameters.AddWithValue("@pbirth_histry", birth_h);
                cmd.Parameters.AddWithValue("@pmed_histry", med_h);
                cmd.Parameters.AddWithValue("@pNm_Surg", Nm_Surg);
                cmd.Parameters.AddWithValue("@pSurg_Dt", Sur_Dt);
                cmd.Parameters.AddWithValue("@pEar_Implant", Ear_Imp);
                cmd.Parameters.AddWithValue("@pImplant_Model", Impl_Model);
                cmd.Parameters.AddWithValue("@pSr_No", Sr_No);

                cmd.Parameters.AddWithValue("@pRSp_Pr_Mod", SPMR);
                cmd.Parameters.AddWithValue("@pRSr_No", SNR);
                cmd.Parameters.AddWithValue("@pRDt_Fst_Ftd", DFFR);

                cmd.Parameters.AddWithValue("@pLSp_Pr_Mod", SPML);
                cmd.Parameters.AddWithValue("@pLSr_No", SNL);
                cmd.Parameters.AddWithValue("@pLDt_Fst_Ftd", DFFL);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                int a=cn.executeprocedure(cmd);
                lblas_id.Value = a.ToString();
               
                cn.Close();
                Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    print();
                }
                else
                {
                    Response.Redirect("~/CoImp_Grid.aspx");
                }
                btn_save.Enabled = false;
                //btnnxt.Enabled = true;                
                FilldeptInGrid(ptntid);
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
                
            }
            #endregion
    }
    protected void ddlnoise_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    public string RemoveAllWhitespace(string str)
    {
        try
        {
            Regex reg = new Regex(@"\s*");
            str = reg.Replace(str, "");
            return str;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        //string bill = txtptnt_nm.Text.ToString();
        //Response.Redirect("~/Clinical Forms/h_digno.aspx?bill_no=" + bill);       
    }
    public void Image()
    {
        #region Image
        try
        {
            cn.Open();
            double id = Convert.ToDouble(lblptnt_id.Value);

            string qry = "select * from tbl_ptnt_image" +
                                     @" where ptnt_id='" + id + "' ";
            ds1 = cn.GetData(qry, "tbl_ptnt_image");

            if (ds1.Tables["tbl_ptnt_image"].Rows.Count == 0)
            {
                Image1.Visible = false;
            }
                else
            {
            qry = ds1.Tables["tbl_ptnt_image"].Rows[0][0].ToString();
           
                if (ds1.Tables["tbl_ptnt_image"].Rows.Count > 0)
                {
                    Image1.ImageUrl = "~/ShowImage.ashx?id=" + id;
                    Image1.Visible = true;
                }
            }
        }
        catch
        {
            //Response.Redirect("~/error.aspx");
        }
      #endregion
    }
    protected void ddl_complaints_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Surgeon.SelectedIndex > 0)
        {
           
        }
    }
    protected void rbtearsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtearsite.SelectedIndex == 0)
        {
            Label8.Enabled  = true;
            Label9.Enabled = true;
            lblSPMR.Enabled = true;
            lblSNR.Enabled = true;
            lblDFFR.Enabled = true;
            txtSPMR.Enabled = true;
            txtDFFR.Enabled = true;
            txtSNR.Enabled = true;
            txtDFFR.Enabled = true;
            Label17.Enabled = true;
            Label19.Enabled = true;
            
            lblSPML.Enabled = false;
            lblSNL.Enabled = false;
            lblDFFL.Enabled = false;
            txtSPML.Enabled = false;
            txtDFFL.Enabled = false;
            txtSNL.Enabled = false;
            txtDFFL.Enabled = false;
            Label18.Enabled = false;
        }
        else if (rbtearsite.SelectedIndex == 1)
        {
            Label8.Enabled  = true;
            Label9.Enabled = false;
            lblSPMR.Enabled = false;
            lblSNR.Enabled = false;
            lblDFFR.Enabled = false;
            txtDFFR.Enabled = false;
            txtSPMR.Enabled = false;
            txtSNR.Enabled = false;
            txtDFFR.Enabled = false;
            Label17.Enabled = false;

            Label18.Enabled = true;
            Label19.Enabled = true;           
            lblSPML.Enabled = true;
            lblSNL.Enabled = true;
            lblDFFL.Enabled = true;
            txtSPML.Enabled = true;
            txtDFFL.Enabled = true;
            txtSNL.Enabled = true;
            txtDFFL.Enabled = true;
        }
        else
        {
            Label8.Enabled = true;
            Label9.Enabled = true;
            lblSPMR.Enabled = true;
            lblSNR.Enabled = true;
            lblDFFR.Enabled = true;
            txtSPMR.Enabled = true;
            txtDFFR.Enabled = true;
            txtSNR.Enabled = true;
            txtDFFR.Enabled = true;
            Label17.Enabled = true;
            Label18.Enabled = true;
            Label19.Enabled = true;
           
            lblSPML.Enabled = true;
            lblSNL.Enabled = true;
            lblDFFL.Enabled = true;
            txtSPML.Enabled = true;
            txtDFFL.Enabled = true;
            txtSNL.Enabled = true;
            txtDFFL.Enabled = true;
        }
    }
    public void print()
    {
        if (lblas_id.Value!="")
        {
            //int billno = Convert.ToInt32(lblas_id.Value);
            //Response.Redirect("~/.aspx?bill_no=" + billno);
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
