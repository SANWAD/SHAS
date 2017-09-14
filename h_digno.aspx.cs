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

public partial class Clinical_Forms_h_digno : System.Web.UI.Page
{
    #region Declaration
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    DataSet ds,ds1;
    SqlDataAdapter da;
    int j,def=0;
    double id;
    string apttime, ptntfor;
    DateTime dt;
    string[] apt1;
    string ptntid, aptid, asid;
    string[] adj ={"08:00 AM","08:30 AM","09:00 AM","09:30 AM","10:00 AM", "10:30 AM","11:00 AM","11:30 AM","12:00 PM","12:30 PM","01:00 PM","01:30 PM","02:00 PM","02:30 PM","03:00 PM",
                   "03:30 PM","04:00 PM","04:30 PM","05:00 PM","05:30 PM","06:00 PM","06:30 PM","07:00 PM","07:30 PM","08:00 PM"};
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new connection();
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
          if (!IsPostBack)
            {
                txt_ac_250_r.Focus();
                lbl_msg.Visible = true;
                lblPtnt_nm.Text = (Request.QueryString["bill_no"].ToString());
                lbldate.Text = DateTime.Now.Date.ToShortDateString();
                CompFill();

              int  H_ass_id = Convert.ToInt32(Session["H_as_id"].ToString());               
              DataFill(H_ass_id);
              if (Convert.ToInt32(Session["Ass_id"])>0)
              {
                  Select();
              }
                //int Apt_id = Convert.ToInt32(Session["Apt_Id"]);
                //int Ptnt_id = Convert.ToInt32(Session["Ptnt_Id"]);
                //DataFill(Apt_id, Ptnt_id);
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
                cmd = new SqlCommand("sp_H_Ass_Id_Rpt", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ph_as_id", Ass_id);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbl_asid.Value = DT1.Rows[0][0].ToString();
                lbl_ptntid.Value = DT1.Rows[0][1].ToString();
                DataFill(Convert.ToInt32(lbl_aptid.Value));
                txttymp_left.Text = DT1.Rows[0][20].ToString();
                txttymp_right.Text = DT1.Rows[0][21].ToString();
                txt_bera_lt.Text = DT1.Rows[0][22].ToString();
                txt_bera_rt.Text = DT1.Rows[0][23].ToString();

                txt_sds_right.Text = DT1.Rows[0][24].ToString();
                txt_srt_right.Text = DT1.Rows[0][25].ToString();
                txt_sds_left.Text = DT1.Rows[0][26].ToString();
                txt_srt_left.Text = DT1.Rows[0][27].ToString();
                ddl_spl_tonedecay_left.SelectedItem.Text = DT1.Rows[0][28].ToString();
                ddl_spl_sisi_left.SelectedItem.Text = DT1.Rows[0][29].ToString();
                ddl_spl_tonedecay_right.SelectedItem.Text = DT1.Rows[0][30].ToString();
                ddl_spl_sisi_right.SelectedItem.Text = DT1.Rows[0][31].ToString();
                txt_pta_left.Text = DT1.Rows[0][32].ToString();
                txt_pta_right.Text = DT1.Rows[0][33].ToString();
                txtPass1.Text = DT1.Rows[0][34].ToString();
                txtPass.Text = DT1.Rows[0][35].ToString();
                txt_mach1.Text = DT1.Rows[0][36].ToString();
                txt_mach2.Text = DT1.Rows[0][37].ToString();
                txt_mach3.Text = DT1.Rows[0][38].ToString();
                txt_mach3.Text = DT1.Rows[0][39].ToString();
                txt_ac_250_r.Text = DT1.Rows[0][40].ToString();
                txt_ac_250_l.Text = DT1.Rows[0][41].ToString();
                txt_ac_500_r.Text = DT1.Rows[0][42].ToString();
                txt_ac_500_l.Text = DT1.Rows[0][43].ToString();
                txt_ac_1k_r.Text = DT1.Rows[0][44].ToString();
                txt_ac_1k_l.Text = DT1.Rows[0][45].ToString();
                txt_ac_1_5k_r.Text = DT1.Rows[0][46].ToString();
                txt_ac_1_5k_l.Text = DT1.Rows[0][47].ToString();
                txt_ac_2k_r.Text = DT1.Rows[0][48].ToString();
                txt_ac_2k_l.Text = DT1.Rows[0][49].ToString();
                txt_ac_3k_r.Text = DT1.Rows[0][50].ToString();
                txt_ac_3k_l.Text = DT1.Rows[0][51].ToString();
                txt_ac_4k_r.Text = DT1.Rows[0][52].ToString();
                txt_ac_4k_l.Text = DT1.Rows[0][53].ToString();
                txt_ac_6k_r.Text = DT1.Rows[0][54].ToString();
                txt_ac_6k_l.Text = DT1.Rows[0][55].ToString();
                txt_ac_8k_r.Text = DT1.Rows[0][56].ToString();
                txt_ac_8k_r.Text = DT1.Rows[0][57].ToString(); 

                txt_bc_250_r.Text = DT1.Rows[0][58].ToString();
                txt_bc_250_l.Text = DT1.Rows[0][59].ToString();
                txt_bc_500_r.Text = DT1.Rows[0][60].ToString();
                txt_bc_500_l.Text = DT1.Rows[0][61].ToString();
                txt_bc_1k_r.Text = DT1.Rows[0][62].ToString();
                txt_bc_1k_l.Text = DT1.Rows[0][63].ToString();
                txt_bc_1_5k_r.Text = DT1.Rows[0][64].ToString();
                txt_bc_1_5k_l.Text = DT1.Rows[0][65].ToString();
                txt_bc_2k_r.Text = DT1.Rows[0][66].ToString();
                txt_bc_2k_l.Text = DT1.Rows[0][67].ToString();
                txt_bc_3k_r.Text = DT1.Rows[0][68].ToString();
                txt_bc_3k_l.Text = DT1.Rows[0][69].ToString();
                txt_bc_4k_r.Text = DT1.Rows[0][70].ToString();
                txt_bc_4k_l.Text = DT1.Rows[0][71].ToString();

                txt_mask_250_r.Text = DT1.Rows[0][72].ToString();
                txt_mask_250_l.Text = DT1.Rows[0][73].ToString();
                txt_mask_500_r.Text = DT1.Rows[0][74].ToString();
                txt_mask_500_l.Text = DT1.Rows[0][75].ToString();
                txt_mask_1k_r.Text = DT1.Rows[0][76].ToString();
                txt_mask_1k_l.Text = DT1.Rows[0][77].ToString();
                txt_mask_1_5k_r.Text = DT1.Rows[0][78].ToString();
                txt_mask_1_5k_l.Text = DT1.Rows[0][79].ToString();
                txt_mask_2k_r.Text = DT1.Rows[0][80].ToString();
                txt_mask_2k_l.Text = DT1.Rows[0][81].ToString();
                txt_mask_3k_r.Text = DT1.Rows[0][82].ToString();
                txt_mask_3k_l.Text = DT1.Rows[0][83].ToString();
                txt_mask_4k_r.Text = DT1.Rows[0][84].ToString();
                txt_mask_4k_l.Text = DT1.Rows[0][85].ToString();
                txt_mask_6k_r.Text = DT1.Rows[0][86].ToString();
                txt_mask_6k_l.Text = DT1.Rows[0][87].ToString();
                txt_mask_8k_r.Text = DT1.Rows[0][88].ToString();
                txt_mask_8k_l.Text = DT1.Rows[0][89].ToString();

                txt_mask_250_r_bc.Text = DT1.Rows[0][90].ToString();
                txt_mask_250_l_bc.Text = DT1.Rows[0][91].ToString();
                txt_mask_500_r_bc.Text = DT1.Rows[0][92].ToString();
                txt_mask_500_l_bc.Text = DT1.Rows[0][93].ToString();
                txt_mask_1k_r_bc.Text = DT1.Rows[0][94].ToString();
                txt_mask_1k_l_bc.Text = DT1.Rows[0][95].ToString();
                txt_mask_1_5_k_r_bc.Text = DT1.Rows[0][96].ToString();
                txt_mask_1_5_k_l_bc.Text = DT1.Rows[0][97].ToString();
                txt_mask_2k_r_bc.Text = DT1.Rows[0][98].ToString();
                txt_mask_2k_l_bc.Text = DT1.Rows[0][99].ToString();
                txt_mask_3k_r_bc.Text = DT1.Rows[0][100].ToString();
                txt_mask_3k_l_bc.Text = DT1.Rows[0][101].ToString();
                txt_mask_4k_r_bc.Text = DT1.Rows[0][102].ToString();
                txt_mask_4k_l_bc.Text = DT1.Rows[0][103].ToString();

                txt_pta_rt.Text = DT1.Rows[0][104].ToString();
                txt_pta_lt.Text = DT1.Rows[0][105].ToString();
                txth_digno_det.Text = DT1.Rows[0][106].ToString();
                txtsuggest.Text = DT1.Rows[0][107].ToString();
                txtadd_test.Text = DT1.Rows[0][108].ToString();

                txt_ucl_250_r.Text = DT1.Rows[0][110].ToString();
                txt_ucl_250_l.Text = DT1.Rows[0][111].ToString();
                txt_ucl_500_r.Text = DT1.Rows[0][112].ToString();
                txt_ucl_500_l.Text = DT1.Rows[0][113].ToString();
                txt_ucl_1k_r.Text = DT1.Rows[0][114].ToString();
                txt_ucl_1k_l.Text = DT1.Rows[0][115].ToString();
                txt_ucl_1_5k_r.Text = DT1.Rows[0][116].ToString();
                txt_ucl_1_5k_l.Text = DT1.Rows[0][117].ToString();
                txt_ucl_2k_r.Text = DT1.Rows[0][118].ToString();
                txt_ucl_2k_l.Text = DT1.Rows[0][119].ToString();
                txt_ucl_3k_r.Text = DT1.Rows[0][120].ToString();
                txt_ucl_3k_l.Text = DT1.Rows[0][121].ToString();
                txt_ucl_4k_r.Text = DT1.Rows[0][122].ToString();
                txt_ucl_4k_l.Text = DT1.Rows[0][123].ToString();
                txt_ucl_6k_r.Text = DT1.Rows[0][124].ToString();
                txt_ucl_6k_l.Text = DT1.Rows[0][125].ToString();
                txt_ucl_8k_r.Text = DT1.Rows[0][126].ToString();
                txt_ucl_8k_l.Text = DT1.Rows[0][127].ToString();


                txt_mcl_250_r.Text = DT1.Rows[0][129].ToString();
                txt_mcl_250_l.Text = DT1.Rows[0][130].ToString();
                txt_mcl_500_r.Text = DT1.Rows[0][131].ToString();
                txt_mcl_500_l.Text = DT1.Rows[0][132].ToString();
                txt_mcl_1k_r.Text = DT1.Rows[0][133].ToString();
                txt_mcl_1k_l.Text = DT1.Rows[0][134].ToString();
                txt_mcl_1_5k_r.Text = DT1.Rows[0][135].ToString();
                txt_mcl_1_5k_l.Text = DT1.Rows[0][136].ToString();
                txt_mcl_2k_r.Text = DT1.Rows[0][137].ToString();
                txt_mcl_2k_l.Text = DT1.Rows[0][138].ToString();
                txt_mcl_3k_r.Text = DT1.Rows[0][139].ToString();
                txt_mcl_3k_l.Text = DT1.Rows[0][140].ToString();
                txt_mcl_4k_r.Text = DT1.Rows[0][141].ToString();
                txt_mcl_4k_l.Text = DT1.Rows[0][142].ToString();
                txt_mcl_6k_r.Text = DT1.Rows[0][143].ToString();
                txt_mcl_6k_l.Text = DT1.Rows[0][144].ToString();
                txt_mcl_8k_r.Text = DT1.Rows[0][145].ToString();
                txt_mcl_8k_l.Text = DT1.Rows[0][146].ToString();

                txt_ucl_rt.Text = DT1.Rows[0][147].ToString();
                txt_ucl_lt.Text = DT1.Rows[0][148].ToString();

                txt_mcl_rt.Text = DT1.Rows[0][149].ToString();
                txt_mcl_lt.Text = DT1.Rows[0][150].ToString();
                dr = null;
                cn.Close();               
                btnsave.Text = "Edit";
            }
            catch
            { }

            #endregion
        }
    }
    public void CompFill()
    {
        #region machine Company
        cn.Open();
        cmd = connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "sp_Mach_Desc_ddl";
        DataTable DT_comp = new DataTable();

        dr = cmd.ExecuteReader();
        DT_comp.Load(dr);
        ddl_comp1.DataSource = DT_comp;
        ddl_comp1.DataValueField = "Comp_id";
        ddl_comp1.DataTextField = "Comp_nm";
        ddl_comp1.DataBind();
        ddl_comp1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
        ddl_comp1.SelectedIndex = 0;

        ddl_comp2.DataSource = DT_comp;
        ddl_comp2.DataValueField = "Comp_id";
        ddl_comp2.DataTextField = "Comp_nm";
        ddl_comp2.DataBind();
        ddl_comp2.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
        ddl_comp2.SelectedIndex = 0;
        //Label14.Text = "Add Quantity";
        dr = null;
        cn.Close();

        #endregion
        ddl_mach_model1.Visible = false;
        ddl_mach_model2.Visible = false;
        ddl_mach_model3.Visible = false;
        ddl_mach_model4.Visible = false;

        ddl_mach_type1.Visible = false;
        ddl_mach_type2.Visible = false;
        ddl_mach_type3.Visible = false;
        ddl_mach_type4.Visible = false;

        txt_mach1.Visible = false;
        txt_mach2.Visible = false;
        txt_mach3.Visible = false;
        txt_mach4.Visible = false;
        ddl_comp1.Visible = false;
        ddl_comp2.Visible = false;
        ddl_comp3.Visible = false;
        ddl_comp4.Visible = false;
        txt_bera_rt.Visible = false;
        txt_bera_lt.Visible = false;       
    }
    public void DataFill(int H_ass_id)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["Sanwad"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_h_ass_apt_id";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@p_apt_id", Apt_id);
                //cmd.Parameters.AddWithValue("@p_ptnt_id", Ptnt_id);
                cmd.Parameters.AddWithValue("@p_H_ass_id", H_ass_id);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        lbl_asid.Value  = sdr["h_as_id"].ToString();
                        lbl_aptid.Value  = sdr["apt_id"].ToString();
                        lbl_ptntid.Value  = sdr["ptnt_id"].ToString();                  
                    }
                }
                conn.Close();
            }
        }
    }
    protected void ddl_rec_subtype_left_SelectedIndexChanged(object sender, EventArgs e)
    {
    }   
    protected void ddlnxtmeet_SelectedIndexChanged(object sender, EventArgs e)
    {       
    } 
    #region Tympanometry
    protected void ddl_reflexes_left_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_reflexes_left.SelectedIndex == 1)
        {
            txttymp_left.Text = "Not Applicable";
        }
        else
        {
            txttymp_left.Text = (System.Convert.ToString(ddl_tymp_graph_left.SelectedItem.Text + " Type Graph " + "," + ddl_complaince_left.SelectedItem.Text + "," +
            "" + " " + ddlLPre.SelectedItem.Text + " " + ddl_reflexes_left.SelectedItem.Text));          
        }
    }
    protected void ddl_comp_right_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void ddl_puretone_type_loss_left_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddl_puretone_type_loss_left.SelectedIndex == 1)
        {
            txt_pta_left.Text = "Not Applicable";
        }
        else if (ddl_puretone_type_loss_left.SelectedIndex == 2)
        {
            txt_pta_left.Text = System.Convert.ToString(ddl_puretone_type_loss_left.SelectedItem.Text);
        }
        else
        {
            txt_pta_left.Text = System.Convert.ToString(ddl_puretone_degree_left.SelectedItem.Text + "," + ddl_puretone_type_loss_left.SelectedItem.Text + " " + "HEARING LOSS");
        }
    }
    protected void ddl_puretone_type_loss_right_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddl_puretone_type_loss_right.SelectedIndex == 1)
        {
            txt_pta_right.Text = "Not Applicable";
        }
        else if (ddl_puretone_type_loss_right.SelectedIndex == 2)
        {
            txt_pta_right.Text = System.Convert.ToString(ddl_puretone_type_loss_right.SelectedItem.Text);
        }
        else
        {
            txt_pta_right.Text = System.Convert.ToString(ddl_puretone_degree_right.SelectedItem.Text + "," + ddl_puretone_type_loss_right.SelectedItem.Text + " " + "HEARING LOSS");
        }
    }
    #endregion      
    protected void ddl_2k_right_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {        
        #region Save
        try
        {
            int asid1 = System.Convert.ToInt32(lbl_asid.Value);
            //int asid1 = 0;
            int aptid1 = System.Convert.ToInt32(lbl_aptid.Value);
            int ptntid1 = System.Convert.ToInt32(lbl_ptntid.Value);
            string tymp_lt = txttymp_left.Text.ToString();
            if (txttymp_left.Text == "")
            {
                tymp_lt = "NA";
            }
            else
            {
                tymp_lt = txttymp_left.Text.ToString();
            }
            string tymp_rt; 
            if (txttymp_right.Text=="")
            {
                tymp_rt = "NA";
            }
            else
            {
                tymp_rt = txttymp_right.Text.ToString();
            }
            string bera_lt;
            if (txt_bera_lt.Text == "")
            {
                bera_lt = "NA";
            }
            else
            {
                bera_lt = txt_bera_lt.Text.ToString();
            }
            string bera_rt;
            if (txt_bera_rt.Text == "")
            {
                bera_rt = "NA";
            }
            else
            {
                bera_rt = txt_bera_rt.Text.ToString();
            }

            //string ASSRL;
            //if (txtASSRL.Text == "")
            //{
            //    ASSRL = "NA";
            //}
            //else
            //{
            //    ASSRL = txtASSRL.Text.ToString();
            //}
            //string ASSRR;
            //if (txtASSRR.Text == "")
            //{
            //    ASSRR = "NA";
            //}
            //else
            //{
            //    ASSRR = txtASSRR.Text.ToString();
            //}
            string sa_sds_lt = txt_sds_left.Text.ToString();
            string sa_sds_rt = txt_sds_right.Text.ToString();
            string srt_lt = txt_srt_left.Text.ToString();
            string srt_rt = txt_srt_right.Text.ToString();
            string td_lt = ddl_spl_tonedecay_left.SelectedItem.Text.ToString();
            string td_rt = ddl_spl_tonedecay_right.SelectedItem.Text.ToString();
            string sisi_lt = ddl_spl_sisi_left.SelectedItem.Text.ToString();
            string sisi_rt = ddl_spl_sisi_right.SelectedItem.Text.ToString();            
            string pta_lt;
            if (txt_pta_left.Text == "")
            {
                pta_lt = "NA";
            }
            else
            {
                pta_lt = txt_pta_left.Text.ToString();
            }
            string pta_rt;
            if (txt_pta_right.Text == "")
            {
                pta_rt = "NA";
            }
            else
            {
                pta_rt = txt_pta_right.Text.ToString();
            }
            
            string oae_lt = rbtn_oae_left.SelectedItem.Text.ToString();
            string oae_rt = rbtn_oae_right.SelectedItem.Text.ToString();
            string recom_mach_lt = txt_mach1.Text.ToString();
            string recom_mach_rt = txt_mach2.Text.ToString();
            string sel_mach_lt = txt_mach3.Text.ToString();
            string sel_mach_rt = txt_mach4.Text.ToString();            
            string ac_h_250_right=txt_ac_250_r.Text.ToString();
            string ac_h_250_left=txt_ac_250_l.Text.ToString();
            string ac_h_500_right=txt_ac_500_r.Text.ToString();
            string ac_h_500_left=txt_ac_500_l.Text.ToString();
            string ac_h_1k_right=txt_ac_1k_r.Text.ToString();
            string ac_h_1k_left	 =txt_ac_1k_l.Text.ToString();
            string ac_h_1_5k_right=txt_ac_1_5k_r.Text.ToString();
            string ac_h_1_5k_left=txt_ac_1_5k_l.Text.ToString();
            string ac_h_2k_right = txt_ac_2k_r.Text.ToString();
            string ac_h_2k_left	 =txt_ac_2k_l.Text.ToString();
            string ac_h_3k_right=txt_ac_3k_r.Text.ToString();
            string ac_h_3k_left	 =txt_ac_3k_l.Text.ToString();
            string ac_h_4k_right=txt_ac_4k_r.Text.ToString();
            string ac_h_4k_left	 =txt_ac_4k_l.Text.ToString();
            string ac_h_6k_right=txt_ac_6k_r.Text.ToString();
            string ac_h_6k_left	 =txt_ac_6k_l.Text.ToString();
            string ac_h_8k_right=txt_ac_8k_r.Text.ToString();
            string ac_h_8k_left	 =txt_ac_8k_l.Text.ToString();
            string bc_h_250_right=txt_bc_250_r.Text.ToString();
            string bc_h_250_left=txt_bc_250_l.Text.ToString();
            string bc_h_500_right=txt_bc_500_r.Text.ToString();
            string bc_h_500_left=txt_bc_500_l.Text.ToString();
            string bc_h_1k_right=txt_bc_1k_r.Text.ToString();
            string bc_h_1k_left	 =txt_bc_1k_l.Text.ToString();
            string bc_h_1_5k_right=txt_bc_1_5k_r.Text.ToString();
            string bc_h_1_5k_left=txt_bc_1_5k_l.Text.ToString();
            string bc_h_2k_right=txt_bc_2k_r.Text.ToString();
            string bc_h_2k_left	 =txt_bc_2k_l.Text.ToString();
            string bc_h_3k_right=txt_bc_3k_r.Text.ToString();
            string bc_h_3k_left	 =txt_bc_3k_l.Text.ToString();
            string bc_h_4k_right=txt_bc_4k_r.Text.ToString();
            string bc_h_4k_left	 =txt_bc_4k_l.Text.ToString();

            string mask_h_250_right=txt_mask_250_r.Text.ToString();
            string mask_h_250_left	=txt_mask_250_l.Text.ToString();
            string mask_h_500_right=txt_mask_500_r.Text.ToString();
            string mask_h_500_left=txt_mask_500_l.Text.ToString();
            string mask_h_1k_right=txt_mask_1k_r.Text.ToString();
            string mask_h_1k_left=txt_mask_1k_l.Text.ToString();
            string mask_h_1_5k_right=txt_mask_1_5k_r.Text.ToString();
            string mask_h_1_5k_left=txt_mask_1_5k_l.Text.ToString();
            string mask_h_2k_right=txt_mask_2k_r.Text.ToString();
            string mask_h_2k_left=txt_mask_2k_l.Text.ToString();
            string mask_h_3k_right=txt_mask_3k_r.Text.ToString();
            string mask_h_3k_left=txt_mask_3k_l.Text.ToString();
            string mask_h_4k_right=txt_mask_4k_r.Text.ToString();
            string mask_h_4k_left=txt_mask_4k_l.Text.ToString();
            string mask_h_6k_right=txt_mask_6k_r.Text.ToString();
            string mask_h_6k_left=txt_mask_6k_l.Text.ToString();
            string mask_h_8k_right=txt_mask_8k_r.Text.ToString();
            string mask_h_8k_left=txt_mask_8k_l.Text.ToString();
            
            string mask_h_250_right_bc=txt_mask_250_r_bc.Text.ToString();
            string mask_h_250_left_bc=txt_mask_250_l_bc.Text.ToString();
            string mask_h_500_right_bc=txt_mask_500_r_bc.Text.ToString();
            string mask_h_500_left_bc=txt_mask_500_r_bc.Text.ToString();
            string mask_h_1k_right_bc=txt_mask_1k_r_bc.Text.ToString();
            string mask_h_1k_left_bc=txt_mask_1k_l_bc.Text.ToString();
            string mask_h_1_5k_right_bc=txt_mask_1_5_k_r_bc.Text.ToString();
            string mask_h_1_5k_left_bc=txt_mask_1_5_k_l_bc.Text.ToString();
            string mask_h_2k_right_bc=txt_mask_2k_r_bc.Text.ToString();
            string mask_h_2k_left_bc=txt_mask_2k_l_bc.Text.ToString();
            string mask_h_3k_right_bc=txt_mask_3k_r_bc.Text.ToString();
            string mask_h_3k_left_bc=txt_mask_3k_l_bc.Text.ToString();
            string mask_h_4k_right_bc=txt_mask_4k_r_bc.Text.ToString();
            string mask_h_4k_left_bc=txt_mask_4k_l_bc.Text.ToString();

            string ucl_h_250_right = txt_ucl_250_r.Text.ToString();
            string ucl_h_250_left = txt_ucl_250_l.Text.ToString();
            string ucl_h_500_right = txt_ucl_500_r.Text.ToString();
            string ucl_h_500_left = txt_ucl_500_l.Text.ToString();
            string ucl_h_1k_right = txt_ucl_1k_r.Text.ToString();
            string ucl_h_1k_left = txt_ucl_1k_l.Text.ToString();
            string ucl_h_1_5k_right = txt_ucl_1_5k_r.Text.ToString();
            string ucl_h_1_5k_left = txt_ucl_1_5k_l.Text.ToString();
            string ucl_h_2k_right = txt_ucl_2k_r.Text.ToString();
            string ucl_h_2k_left = txt_ucl_2k_l.Text.ToString();
            string ucl_h_3k_right = txt_ucl_3k_r.Text.ToString();
            string ucl_h_3k_left = txt_ucl_3k_l.Text.ToString();
            string ucl_h_4k_right = txt_ucl_4k_r.Text.ToString();
            string ucl_h_4k_left = txt_ucl_4k_l.Text.ToString();
            string ucl_h_6k_right = txt_ucl_6k_r.Text.ToString();
            string ucl_h_6k_left = txt_ucl_6k_l.Text.ToString();
            string ucl_h_8k_right = txt_ucl_8k_r.Text.ToString();
            string ucl_h_8k_left = txt_ucl_8k_l.Text.ToString();

            string mcl_h_250_right = txt_mask_250_r_bc.Text.ToString();
            string mcl_h_250_left = txt_mask_250_l.Text.ToString();
            string mcl_h_500_right = txt_mask_500_r.Text.ToString();
            string mcl_h_500_left = txt_mask_500_l.Text.ToString();
            string mcl_h_1k_right = txt_mask_1k_r.Text.ToString();
            string mcl_h_1k_left = txt_mask_1k_l.Text.ToString();
            string mcl_h_1_5k_right = txt_mask_1_5k_r.Text.ToString();
            string mcl_h_1_5k_left = txt_mask_1_5k_l.Text.ToString();
            string mcl_h_2k_right = txt_mask_2k_r.Text.ToString();
            string mcl_h_2k_left = txt_mask_2k_l.Text.ToString();
            string mcl_h_3k_right = txt_mask_3k_r.Text.ToString();
            string mcl_h_3k_left = txt_mask_3k_l.Text.ToString();
            string mcl_h_4k_right = txt_mask_4k_r.Text.ToString();
            string mcl_h_4k_left = txt_mask_4k_l.Text.ToString();
            string mcl_h_6k_right = txt_mask_6k_r.Text.ToString();
            string mcl_h_6k_left = txt_mask_6k_l.Text.ToString();
            string mcl_h_8k_right = txt_mask_8k_r.Text.ToString();
            string mcl_h_8k_left = txt_mask_8k_l.Text.ToString();

            string avg_pta_lt = txt_pta_lt.Text;
            string avg_pta_rt = txt_pta_rt.Text;
            string avg_ucl_lt;
            if (txt_ucl_lt.Text == "")
            {
                avg_ucl_lt = "NA";
            }
            else
            {
                avg_ucl_lt = txt_ucl_lt.Text;
            }
            string avg_ucl_rt;
            if (txt_ucl_rt.Text == "")
            {
                avg_ucl_rt = "NA";
            }
            else
            {
                avg_ucl_rt = txt_ucl_rt.Text;
            }
            string avg_mcl_lt;
            if (txt_mcl_rt.Text == "")
            {
                avg_mcl_lt = "NA";
            }
            else
            {
                avg_mcl_lt = txt_mcl_lt.Text;
            }
            string avg_mcl_rt;
            if (txt_mcl_lt.Text == "")
            {
                avg_mcl_rt = "NA";
            }
            else
            {
                avg_mcl_rt = txt_mcl_rt.Text;
            }
            //string avg_ucl_lt = txt_ucl_lt.Text;
            //string avg_ucl_rt = txt_ucl_rt.Text;
            //string avg_mcl_lt = txt_mcl_lt.Text;
            //string avg_mcl_rt = txt_mcl_rt.Text;
            string digno_det = txth_digno_det.Text.ToString();
            string digno_sug = txtsuggest.Text.ToString();
            string ad_test = txtadd_test.Text.ToString();
            DateTime cr_dt = Convert.ToDateTime(lbldate.Text);
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_h_digno_trn_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ph_as_id", asid1);
            cmd.Parameters.AddWithValue("@pptnt_id", ptntid1);
            cmd.Parameters.AddWithValue("@papt_id", aptid1);
            cmd.Parameters.AddWithValue("@ph_digno_tympano_left", tymp_lt);
            cmd.Parameters.AddWithValue("@ph_digno_tympano_right", tymp_rt);
            cmd.Parameters.AddWithValue("@ph_digno_bera_test_left", bera_lt);
            cmd.Parameters.AddWithValue("@ph_digno_bera_test_right", bera_rt);
            //cmd.Parameters.AddWithValue("@ph_ASSRL_test", ASSRL);
            //cmd.Parameters.AddWithValue("@ph_ASSRR_test", ASSRR);
            cmd.Parameters.AddWithValue("@ph_digno_speech_audio_sds_left", sa_sds_lt);
            cmd.Parameters.AddWithValue("@ph_digno_speech_audio_sds_right", sa_sds_rt);
            cmd.Parameters.AddWithValue("@ph_digno_speech_audio_srt_left", srt_lt);
            cmd.Parameters.AddWithValue("@ph_digno_speech_audio_srt_right", srt_rt);
            cmd.Parameters.AddWithValue("@ph_digno_spl_test_tone_decay_left", td_lt);
            cmd.Parameters.AddWithValue("@ph_digno_spl_test_tone_decay_right", td_rt);
            cmd.Parameters.AddWithValue("@ph_digno_spl_test_sisi_left", sisi_lt);
            cmd.Parameters.AddWithValue("@ph_digno_spl_test_sisi_right", sisi_rt);
            cmd.Parameters.AddWithValue("@ph_digno_puretone_audiometry_left", pta_lt);
            cmd.Parameters.AddWithValue("@ph_digno_puretone_audiometry_right", pta_rt);
            cmd.Parameters.AddWithValue("@ph_digno_oae_test_left", oae_lt);
            cmd.Parameters.AddWithValue("@ph_digno_oae_test_right", oae_rt);
            cmd.Parameters.AddWithValue("@ph_digno_recom_mach_left", recom_mach_lt);
            cmd.Parameters.AddWithValue("@ph_digno_recom_mach_right", recom_mach_rt);
            cmd.Parameters.AddWithValue("@ph_digno_sel_mach_left", sel_mach_lt);
            cmd.Parameters.AddWithValue("@ph_digno_sel_mach_right", sel_mach_rt);
            cmd.Parameters.AddWithValue("@pac_h_250_right",ac_h_250_right);
            cmd.Parameters.AddWithValue("@pac_h_250_left",ac_h_250_left);
            cmd.Parameters.AddWithValue("@pac_h_500_right",ac_h_500_right);
            cmd.Parameters.AddWithValue("@pac_h_500_left", ac_h_500_left);        
            cmd.Parameters.AddWithValue("@pac_h_1k_right",ac_h_1k_right);
            cmd.Parameters.AddWithValue("@pac_h_1k_left",ac_h_1k_left);
            cmd.Parameters.AddWithValue("@pac_h_1_5k_right",ac_h_1_5k_right);
            cmd.Parameters.AddWithValue("@pac_h_1_5k_left",ac_h_1_5k_left);
            cmd.Parameters.AddWithValue("@pac_h_2k_right",ac_h_2k_right);
            cmd.Parameters.AddWithValue("@pac_h_2k_left",ac_h_2k_left);
            cmd.Parameters.AddWithValue("@pac_h_3k_right",ac_h_3k_right);
            cmd.Parameters.AddWithValue("@pac_h_3k_left",ac_h_3k_left);
            cmd.Parameters.AddWithValue("@pac_h_4k_right",ac_h_4k_right);
            cmd.Parameters.AddWithValue("@pac_h_4k_left",ac_h_4k_left);
            cmd.Parameters.AddWithValue("@pac_h_6k_right", ac_h_6k_right); 
            cmd.Parameters.AddWithValue("@pac_h_6k_left",ac_h_6k_left);
            cmd.Parameters.AddWithValue("@pac_h_8k_right",ac_h_8k_right);
            cmd.Parameters.AddWithValue("@pac_h_8k_left",ac_h_8k_left);
            cmd.Parameters.AddWithValue("@pbc_h_250_right",bc_h_250_right);
            cmd.Parameters.AddWithValue("@pbc_h_250_left",bc_h_250_left);
            cmd.Parameters.AddWithValue("@pbc_h_500_right",bc_h_500_right);
            cmd.Parameters.AddWithValue("@pbc_h_500_left",bc_h_500_left);
            cmd.Parameters.AddWithValue("@pbc_h_1k_right",bc_h_1k_right);
            cmd.Parameters.AddWithValue("@pbc_h_1k_left",bc_h_1k_left);
            cmd.Parameters.AddWithValue("@pbc_h_1_5k_right",bc_h_1_5k_right);
            cmd.Parameters.AddWithValue("@pbc_h_1_5k_left", bc_h_1_5k_left);
            cmd.Parameters.AddWithValue("@pbc_h_2k_right",bc_h_2k_right);
            cmd.Parameters.AddWithValue("@pbc_h_2k_left",bc_h_2k_left);
            cmd.Parameters.AddWithValue("@pbc_h_3k_right",bc_h_3k_right);
            cmd.Parameters.AddWithValue("@pbc_h_3k_left",bc_h_3k_left);
            cmd.Parameters.AddWithValue("@pbc_h_4k_right",bc_h_4k_right);
            cmd.Parameters.AddWithValue("@pbc_h_4k_left",bc_h_4k_left);
            cmd.Parameters.AddWithValue("@pmask_h_250_right",mask_h_250_right);
            cmd.Parameters.AddWithValue("@pmask_h_250_left",mask_h_250_left);
            cmd.Parameters.AddWithValue("@pmask_h_500_right", mask_h_500_right); 
            cmd.Parameters.AddWithValue("@pmask_h_500_left",mask_h_500_left);
            cmd.Parameters.AddWithValue("@pmask_h_1k_right",mask_h_1k_right);
            cmd.Parameters.AddWithValue("@pmask_h_1k_left",mask_h_1k_left);
            cmd.Parameters.AddWithValue("@pmask_h_1_5k_right",mask_h_1_5k_right);
            cmd.Parameters.AddWithValue("@pmask_h_1_5k_left",mask_h_1_5k_left);
            cmd.Parameters.AddWithValue("@pmask_h_2k_right",mask_h_2k_right);
            cmd.Parameters.AddWithValue("@pmask_h_2k_left",mask_h_2k_left);
            cmd.Parameters.AddWithValue("@pmask_h_3k_right",mask_h_3k_right);
            cmd.Parameters.AddWithValue("@pmask_h_3k_left",mask_h_3k_left);
            cmd.Parameters.AddWithValue("@pmask_h_4k_right",mask_h_4k_right);
            cmd.Parameters.AddWithValue("@pmask_h_4k_left",mask_h_4k_left);
            cmd.Parameters.AddWithValue("@pmask_h_6k_right", mask_h_6k_right);
            cmd.Parameters.AddWithValue("@pmask_h_6k_left",mask_h_6k_left);
            cmd.Parameters.AddWithValue("@pmask_h_8k_right",mask_h_8k_right);
            cmd.Parameters.AddWithValue("@pmask_h_8k_left", mask_h_8k_left);
            cmd.Parameters.AddWithValue("@pmask_h_250_right_bc",mask_h_250_right_bc);
            cmd.Parameters.AddWithValue("@pmask_h_250_left_bc",mask_h_250_right_bc);
            cmd.Parameters.AddWithValue("@pmask_h_500_right_bc",mask_h_500_right_bc);
            cmd.Parameters.AddWithValue("@pmask_h_500_left_bc",mask_h_500_left_bc);
            cmd.Parameters.AddWithValue("@pmask_h_1k_right_bc",mask_h_1k_right_bc);
            cmd.Parameters.AddWithValue("@pmask_h_1k_left_bc",mask_h_1k_left_bc);
            cmd.Parameters.AddWithValue("@pmask_h_1_5k_right_bc",mask_h_1_5k_right_bc);
            cmd.Parameters.AddWithValue("@pmask_h_1_5k_left_bc", mask_h_1_5k_left_bc);
            cmd.Parameters.AddWithValue("@pmask_h_2k_right_bc",mask_h_2k_right_bc);
            cmd.Parameters.AddWithValue("@pmask_h_2k_left_bc",mask_h_2k_left_bc);
            cmd.Parameters.AddWithValue("@pmask_h_3k_right_bc",mask_h_3k_right_bc);
            cmd.Parameters.AddWithValue("@pmask_h_3k_left_bc",mask_h_3k_left_bc);
            cmd.Parameters.AddWithValue("@pmask_h_4k_right_bc",mask_h_4k_right_bc);
            cmd.Parameters.AddWithValue("@pmask_h_4k_left_bc", mask_h_4k_left_bc);

            cmd.Parameters.AddWithValue("@pucl_h_250_right", ucl_h_250_right);
            cmd.Parameters.AddWithValue("@pucl_h_250_left", ucl_h_250_left);
            cmd.Parameters.AddWithValue("@pucl_h_500_right", ucl_h_500_right);
            cmd.Parameters.AddWithValue("@pucl_h_500_left", ucl_h_500_left);
            cmd.Parameters.AddWithValue("@pucl_h_1k_right", ucl_h_1k_right);
            cmd.Parameters.AddWithValue("@pucl_h_1k_left", ucl_h_1k_left);
            cmd.Parameters.AddWithValue("@pucl_h_1_5k_right", ucl_h_1_5k_right);
            cmd.Parameters.AddWithValue("@pucl_h_1_5k_left", ucl_h_1_5k_left);
            cmd.Parameters.AddWithValue("@pucl_h_2k_right", ucl_h_2k_right);
            cmd.Parameters.AddWithValue("@pucl_h_2k_left", ucl_h_2k_left);
            cmd.Parameters.AddWithValue("@pucl_h_3k_right", ucl_h_3k_right);
            cmd.Parameters.AddWithValue("@pucl_h_3k_left", ucl_h_3k_left);
            cmd.Parameters.AddWithValue("@pucl_h_4k_right", ucl_h_4k_right);
            cmd.Parameters.AddWithValue("@pucl_h_4k_left", ucl_h_4k_left);
            cmd.Parameters.AddWithValue("@pucl_h_6k_right", ucl_h_6k_right);
            cmd.Parameters.AddWithValue("@pucl_h_6k_left", ucl_h_6k_left);
            cmd.Parameters.AddWithValue("@pucl_h_8k_right", ucl_h_8k_right);
            cmd.Parameters.AddWithValue("@pucl_h_8k_left", ucl_h_8k_left);

            cmd.Parameters.AddWithValue("@pmcl_h_250_right", mcl_h_250_right);
            cmd.Parameters.AddWithValue("@pmcl_h_250_left", mcl_h_250_left);
            cmd.Parameters.AddWithValue("@pmcl_h_500_right", mcl_h_500_right);
            cmd.Parameters.AddWithValue("@pmcl_h_500_left", mcl_h_500_left);
            cmd.Parameters.AddWithValue("@pmcl_h_1k_right", mcl_h_1k_right);
            cmd.Parameters.AddWithValue("@pmcl_h_1k_left", mcl_h_1k_left);
            cmd.Parameters.AddWithValue("@pmcl_h_1_5k_right", mcl_h_1_5k_right);
            cmd.Parameters.AddWithValue("@pmcl_h_1_5k_left", mcl_h_1_5k_left);
            cmd.Parameters.AddWithValue("@pmcl_h_2k_right", mcl_h_2k_right);
            cmd.Parameters.AddWithValue("@pmcl_h_2k_left", mcl_h_2k_left);
            cmd.Parameters.AddWithValue("@pmcl_h_3k_right", mcl_h_3k_right);
            cmd.Parameters.AddWithValue("@pmcl_h_3k_left", mcl_h_3k_left);
            cmd.Parameters.AddWithValue("@pmcl_h_4k_right", mcl_h_4k_right);
            cmd.Parameters.AddWithValue("@pmcl_h_4k_left", mcl_h_4k_left);
            cmd.Parameters.AddWithValue("@pmcl_h_6k_right", mcl_h_6k_right);
            cmd.Parameters.AddWithValue("@pmcl_h_6k_left", mcl_h_6k_left);
            cmd.Parameters.AddWithValue("@pmcl_h_8k_right", mcl_h_8k_right);
            cmd.Parameters.AddWithValue("@pmcl_h_8k_left", mcl_h_8k_left);

            cmd.Parameters.AddWithValue("@ph_avg_pta_right", avg_pta_rt);
            cmd.Parameters.AddWithValue("@ph_avg_pta_left", avg_pta_lt);

            cmd.Parameters.AddWithValue("@ph_avg_ucl_right", avg_ucl_rt);
            cmd.Parameters.AddWithValue("@ph_avg_ucl_left", avg_ucl_lt);

            cmd.Parameters.AddWithValue("@ph_avg_mcl_right", avg_mcl_rt);
            cmd.Parameters.AddWithValue("@ph_avg_mcl_left", avg_mcl_lt);

            cmd.Parameters.AddWithValue("@ph_digno_detail", digno_det);
            cmd.Parameters.AddWithValue("@ph_digno_suggest", digno_sug);
            cmd.Parameters.AddWithValue("@ph_digno_add_test", ad_test);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            int a=cn.executeprocedure(cmd);
            lbl_asid.Value = a.ToString();
            cn.Close();            
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                print();
            }
            else
            {
                Response.Redirect("~/h_assessment_Grid.aspx");
            }
            btnsave.Enabled = false;
            btn_print.Enabled = true;            
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
           // Response.Redirect("~/error.aspx");
        }
        #endregion

        if (ddlnxtmeet.SelectedIndex == 0)
        {
            Response.Write("<script>alert('Next Appointment Not Allocated....')</script>");
        }
        else
        {
            if (ddlnxtmeet.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Next Appointment Not Allocated....')</script>");
            }
            else
            {
                //#region Nxtmeet
                //switch (ddlnxtmeet.SelectedIndex)
                //{
                //    case 1:
                //        nxtmeet(7, 7);
                //        break;

                //    case 2:
                //        nxtmeet(3, 6);
                //        break;

                //    case 3:
                //        nxtmeet(1, 7);
                //        break;
                //    case 4:
                //        nxtmeet(1, 30);
                //        break;
                //    case 5:
                //        nxtmeet(30, 30);
                //        break;
                //    case 6:
                //        nxtmeet(15, 15);
                //        break;
                //    case 7:
                //        nxtmeet(7, 15);
                //        break;
                //    case 8:
                //        nxtmeet(180, 180);
                //        break;
                //    case 9:
                //        nxtmeet(365, 365);
                //        break;
                //}
                //#endregion
                //int ptntid1 = Convert.ToInt32(lblptnt_id.Text);
                //Response.Redirect("~/Clinical Forms/nxt_apts.aspx?ptnt_id=" + ptntid1 + " &Date" + txtdate.Text);
            }
        }
    }
    public string RemoveAllWhitespace(string str)
    {
        #region Remove White Space
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
        #endregion
    }
    protected void ddl_ref_rt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_ref_rt.SelectedIndex == 1)
        {
            txttymp_right.Text = "Not Applicable";
        }
        else
        {
            txttymp_right.Text = (System.Convert.ToString(ddl_tymp_graph_right.SelectedItem.Text + " Type Graph" + "," + ddl_comp_right.SelectedItem.Text + "," +
            "" + " " + ddlRPre.SelectedItem.Text + " " + ddl_ref_rt.SelectedItem.Text));           
        }
    }
    private void nxtmeet(int d, int n_d)
    {
        //#region NEXT APPOINTMENT
        //try
        //{
        //    // DateTime dt = System.DateTime.Now.Date;
        //    DateTime dt = System.Convert.ToDateTime(txtdate.Text);
        //    int ptntid1 = System.Convert.ToInt32(lblptnt_id.Text);
        //    string ptntfor1 = "Hearing Problem";
        //    DateTime aptdt = dt;
        //    for (j = d; j <= n_d; )
        //    {
        //        dt = dt.AddDays(+d);
        //        if (dt.DayOfWeek.ToString() == "Sunday")
        //        {
        //            dt = dt.AddDays(+1);

        //            cn.Open();
        //            string ptnt_for = "select * from tbl_apointment_trn where apt_date='" + dt.ToShortDateString() + "'";
        //            ds = cn.GetData(ptnt_for, "tbl_apointment_trn");
        //            if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //            {
        //                try
        //                { ptntfor = ds.Tables["tbl_apointment_trn"].Rows[0][3].ToString(); }
        //                catch { Response.Redirect("~/error.aspx"); }
        //                if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //                {
        //                    if (ptntfor == "Function")
        //                    {
        //                    }
        //                    else
        //                    { aptdt = dt; }
        //                }
        //                else
        //                { Response.Redirect("~/error.aspx"); }
        //            }
        //            else
        //            {
        //                aptdt = dt;
        //            }
        //            string cur_time = "select * from tbl_apointment_trn" +
        //            @" where apt_date  ='" + System.DateTime.Now.Date + "'";

        //            ds = cn.GetData(cur_time, "tbl_apointment_trn");
        //            if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //            {
        //                cur_time = ds.Tables["tbl_apointment_trn"].Rows[0][7].ToString();
        //                string nxt_time = "select * from tbl_apointment_trn" +
        //                @" where apt_date  ='" + aptdt + "'and apt_time='" + cur_time + "'";
        //                ds = cn.GetData(nxt_time, "tbl_apointment_trn");

        //                if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //                {
        //                    nxt_time = ds.Tables["tbl_apointment_trn"].Rows[0][7].ToString();
        //                    string time_chk = "select * from tbl_apointment_trn" +
        //                         @" where apt_date  >'" + aptdt + "'order by apt_time";
        //                    ds = cn.GetData(time_chk, "tbl_apointment_trn");

        //                    if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //                    {
        //                        if (ds.Tables["tbl_apointment_trn"].Rows.Count < 25)
        //                        {
        //                            DataTable DT = new DataTable();
        //                            DT = ds.Tables["tbl_apointment_trn"];
        //                            ArrayList apt = ConvertDT(DT);
        //                            string[] stringArray = new string[apt.Count];
        //                            for (int count = 0; count < ds.Tables["tbl_apointment_trn"].Rows.Count; )
        //                            {
        //                                foreach (Object obj in apt)
        //                                {
        //                                    stringArray[count] = ((DataRow)obj)[5].ToString();
        //                                    apt.Remove(obj);
        //                                    break;
        //                                }
        //                                count++;
        //                            }

        //                            int dif = Convert.ToInt32((adj.Length) - (stringArray.Length));
        //                            int countarray = 0;
        //                            string[] apt1 = new string[dif]; ;

        //                            Array.Sort(stringArray);

        //                            foreach (string str in adj)
        //                            {
        //                                if (Array.BinarySearch(stringArray, str) < 0)
        //                                {
        //                                    for (countarray = countarray; countarray < dif; )
        //                                    {
        //                                        apt1[countarray] = str.ToString();
        //                                        break;
        //                                    }
        //                                    countarray++;
        //                                }
        //                            }
        //                            apttime = ddl_apt_time.SelectedItem.Text;
        //                        }
        //                        else { nxtmeet(d + 1, n_d + 1); }
        //                    }
        //                    else
        //                    {
        //                        apttime = ddl_apt_time.SelectedItem.Text;
        //                    }
        //                }
        //                else
        //                {
        //                    apttime = ddl_apt_time.SelectedItem.Text;
        //                }
        //            }
        //            double aptid1 = cn.getmaxid("select max(apt_id) from tbl_apointment_trn", "tbl_apointment_trn");
        //            if (aptid1 == 0) { System.Convert.ToString(aptid1 + 1); }
        //            else { System.Convert.ToString(aptid1); }
        //        }
        //        else
        //        {
        //            dt.ToShortDateString();

        //            cn.Open();
        //            string ptnt_for = "select * from tbl_apointment_trn where apt_date='" + dt.ToShortDateString() + "'";
        //            ds = cn.GetData(ptnt_for, "tbl_apointment_trn");
        //            if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //            {
        //                try
        //                { ptntfor = ds.Tables["tbl_apointment_trn"].Rows[0][3].ToString(); }
        //                catch { Response.Redirect("~/error.aspx"); }
        //                if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //                {
        //                    if (ptntfor == "Function")
        //                    {
        //                    }
        //                    else
        //                    { aptdt = dt; }
        //                }
        //                else
        //                { Response.Redirect("~/error.aspx"); }
        //            }
        //            else
        //            {
        //                aptdt = dt;
        //            }
        //            string cur_time = "select * from tbl_apointment_trn" +
        //            @" where apt_date  ='" + System.DateTime.Now.Date + "'";

        //            ds = cn.GetData(cur_time, "tbl_apointment_trn");
        //            if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //            {
        //                cur_time = ds.Tables["tbl_apointment_trn"].Rows[0][7].ToString();
        //                string nxt_time = "select * from tbl_apointment_trn" +
        //                @" where apt_date  ='" + aptdt + "'and apt_time='" + cur_time + "'";
        //                ds = cn.GetData(nxt_time, "tbl_apointment_trn");

        //                if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //                {
        //                    nxt_time = ds.Tables["tbl_apointment_trn"].Rows[0][7].ToString();
        //                    string time_chk = "select * from tbl_apointment_trn" +
        //                         @" where apt_date  >'" + aptdt + "'order by apt_time";
        //                    ds = cn.GetData(time_chk, "tbl_apointment_trn");

        //                    if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //                    {
        //                        if (ds.Tables["tbl_apointment_trn"].Rows.Count < 25)
        //                        {
        //                            DataTable DT = new DataTable();
        //                            DT = ds.Tables["tbl_apointment_trn"];
        //                            ArrayList apt = ConvertDT(DT);
        //                            string[] stringArray = new string[apt.Count];
        //                            for (int count = 0; count < ds.Tables["tbl_apointment_trn"].Rows.Count; )
        //                            {
        //                                foreach (Object obj in apt)
        //                                {
        //                                    stringArray[count] = ((DataRow)obj)[5].ToString();
        //                                    apt.Remove(obj);
        //                                    break;
        //                                }
        //                                count++;
        //                            }

        //                            int dif = Convert.ToInt32((adj.Length) - (stringArray.Length));
        //                            int countarray = 0;
        //                            string[] apt1 = new string[dif]; ;

        //                            Array.Sort(stringArray);

        //                            foreach (string str in adj)
        //                            {
        //                                if (Array.BinarySearch(stringArray, str) < 0)
        //                                {
        //                                    for (countarray = countarray; countarray < dif; )
        //                                    {
        //                                        apt1[countarray] = str.ToString();
        //                                        break;
        //                                    }
        //                                    countarray++;
        //                                }
        //                            }
        //                            apttime = ddl_apt_time.SelectedItem.Text;
        //                        }
        //                        else
        //                        {
        //                            if (ddlnxtmeet.SelectedIndex == 1)
        //                            { nxtmeet(d + 7, n_d + 7); }
        //                            else if (ddlnxtmeet.SelectedIndex == 2)
        //                            { nxtmeet(d + 3, n_d + 3); }
        //                            else if (ddlnxtmeet.SelectedIndex == 3)
        //                            { nxtmeet(d + 1, n_d + 1); }
        //                            else if (ddlnxtmeet.SelectedIndex == 4)
        //                            { nxtmeet(d + 1, n_d + 1); }
        //                            else if (ddlnxtmeet.SelectedIndex == 5)
        //                            { nxtmeet(d + 30, n_d + 30); }
        //                            else if (ddlnxtmeet.SelectedIndex == 6)
        //                            { nxtmeet(d + 15, n_d + 15); }
        //                            else if (ddlnxtmeet.SelectedIndex == 7)
        //                            { nxtmeet(d + 7, n_d + 7); }
        //                            else if (ddlnxtmeet.SelectedIndex == 8)
        //                            { nxtmeet(d + 180, n_d + 180); }
        //                            else if (ddlnxtmeet.SelectedIndex == 9)
        //                            { nxtmeet(d + 365, n_d + 365); }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        apttime = ddl_apt_time.SelectedItem.Text;
        //                    }
        //                }
        //                else
        //                {
        //                    apttime = ddl_apt_time.SelectedItem.Text;
        //                }
        //                cmd = new SqlCommand("sp_appointment_insert", connection.con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@p_ptnt_id", ptntid1);
        //                cmd.Parameters.AddWithValue("@p_ptnt_for", ptntfor1);
        //                cmd.Parameters.AddWithValue("@p_apt_date", aptdt);
        //                cmd.Parameters.AddWithValue("@p_apt_time", apttime);
        //                cmd.Parameters.AddWithValue("@p_For", ptntfor1);
        //                cmd.Parameters.AddWithValue("@p_created_by", Session["Name"].ToString());
        //                cn.Open();
        //                cn.executeprocedure(cmd);
        //                cn.Close();
        //            }
        //            double aptid1 = cn.getmaxid("select max(apt_id) from tbl_apointment_trn", "tbl_apointment_trn");
        //            if (aptid1 == 0) { System.Convert.ToString(aptid1 + 1); }
        //            else { System.Convert.ToString(aptid1); }
        //        }
        //        j = System.Convert.ToInt32(j + d);
        //    }
        //}
        //catch
        //{
        //    Response.Redirect("~/error.aspx");
        //}
        //#endregion        
    }        
    public ArrayList ConvertDT(DataTable data)
    {
        #region Arraylist
        ArrayList converted = new ArrayList(data.Rows.Count);
	    foreach (DataRow row in data.Rows)
	    {
	        converted.Add(row).ToString();
            converted.ToArray().ToString();
	    }
	    return converted;
        #endregion
    }  
    public void loadgrid()
    {
        //#region Loadgrid
        //cmd = connection.con.CreateCommand();
        //cmd.CommandType = CommandType.Text;
        //cmd.CommandText = "select * from tbl_h_digno_trn where ptnt_id=" + ptntid+"";

        //da = new SqlDataAdapter(cmd);
        //ds = new DataSet();
        //da.Fill(ds, "tbl_h_digno_trn");
      
        //    if (ds.Tables["tbl_h_digno_trn"].Rows.Count > 0)
        //    {
        //        gridh_lastdigno.DataSource = ds.Tables["tbl_h_digno_trn"];
        //        gridh_lastdigno.DataBind();
        //    }
        //    else
        //    {
        //        lbl_msg.Visible = true;
        //        lbl_msg.Text = "No Previous Diagnosis!!!! ";
        //    }
        //#endregion
    }
    protected void ddl_comp1_SelectedIndexChanged(object sender, EventArgs e)
    {       
        if (ddl_comp1.SelectedIndex > 0)
        {
            #region Machine Model
            try
            {
                ddl_mach_model1.Visible = true;
                cn.Open();
                ddl_mach_model1.Items.Clear();
                // string Mach_Desc = ddl_comp.SelectedItem.Text;
                int Mach_Desc = Convert.ToInt32(ddl_comp1.SelectedValue);
                cmd = new SqlCommand("sp_Mach_Model_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cn.executeprocedure(cmd);
                DataTable DT_model = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_model.Load(dr);

                ddl_mach_model1.DataSource = DT_model;
                ddl_mach_model1.DataValueField = "mach_id";
                ddl_mach_model1.DataTextField = "mach_model";
                ddl_mach_model1.DataBind();
                ddl_mach_model1.Items.Insert(0, new ListItem("Select", "mach_model"));
                ddl_mach_model1.SelectedIndex = 0;

                dr = null;
                cn.Close();                
                ddl_mach_model1.Enabled = true;
                //ddl_mach_model.Focus();
            }
            catch {/* Response.Redirect("~/error.aspx");*/ }
            #endregion
        }
    }
    protected void ddl_comp2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_comp2.SelectedIndex > 0)
        {
            #region Machine Model
            try
            {
                ddl_mach_model2.Visible = true;
                cn.Open();
                ddl_mach_model2.Items.Clear();
                // string Mach_Desc = ddl_comp.SelectedItem.Text;
                int Mach_Desc = Convert.ToInt32(ddl_comp2.SelectedValue);
                cmd = new SqlCommand("sp_Mach_Model_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cn.executeprocedure(cmd);
                DataTable DT_model = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_model.Load(dr);

                ddl_mach_model2.DataSource = DT_model;
                ddl_mach_model2.DataValueField = "mach_id";
                ddl_mach_model2.DataTextField = "mach_model";
                ddl_mach_model2.DataBind();
                ddl_mach_model2.Items.Insert(0, new ListItem("Select", "mach_model"));
                ddl_mach_model2.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_model1.Enabled = true;
                //ddl_mach_model.Focus();
            }
            catch {/* Response.Redirect("~/error.aspx");*/ }
            #endregion
        }
    }
    protected void ddl_comp3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_comp3.SelectedIndex > 0)
        {
            #region Machine Model
            try
            {
                cn.Open();
                cmd = new SqlCommand("select * from tbl_machine_master where mach_cmp='" + ddl_comp3.SelectedItem.Text + "'", connection.con);
                DataTable DT_model = new DataTable();

                dr = cmd.ExecuteReader();
                DT_model.Load(dr);

                ddl_mach_model3.DataSource = DT_model;
                ddl_mach_model3.DataValueField = "mach_id";
                ddl_mach_model3.DataTextField = "mach_model";
                ddl_mach_model3.DataBind();
                ddl_mach_model3.Items.Insert(0, new ListItem("Select", "mach_model"));
                ddl_mach_model3.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_model3.Visible = true;
            }
            catch { Response.Write("<script>alert('Select Valid Model....')</script>"); }
            #endregion
        }
    }
    protected void ddl_comp4_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Machine Model
        try
        {           
            cn.Open();
            cmd = new SqlCommand("select * from tbl_machine_master where mach_cmp='" + ddl_comp4.SelectedItem.Text + "'", connection.con);
            DataTable DT_model = new DataTable();

            dr = cmd.ExecuteReader();
            DT_model.Load(dr);

            ddl_mach_model4.DataSource = DT_model;
            ddl_mach_model4.DataValueField = "mach_id";
            ddl_mach_model4.DataTextField = "mach_model";
            ddl_mach_model4.DataBind();
            ddl_mach_model4.Items.Insert(0, new ListItem("Select", "mach_model"));
            ddl_mach_model4.SelectedIndex = 0;

            dr = null;
            cn.Close();
            ddl_mach_model4.Visible = true;
        }
        catch { Response.Write("<script>alert('Select Valid Model....')</script>"); }
        #endregion
    }
    protected void ddl_mach_model1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_model1.SelectedIndex > 0)
        {
            #region Machine Type
            try
            {
                ddl_mach_type1.Visible = true;
                cn.Open();
                ddl_mach_type1.Items.Clear();
                //string Mach_Desc = ddl_comp.SelectedItem.Text;
                int Mach_Desc = Convert.ToInt32(ddl_comp1.SelectedValue);
                string Mach_Model = ddl_mach_model1.SelectedItem.Text;
                cmd = new SqlCommand("sp_Mach_Type_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
                cn.executeprocedure(cmd);
                DataTable DT_type = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_type.Load(dr);

                ddl_mach_type1.DataSource = DT_type;
                ddl_mach_type1.DataValueField = "mach_id";
                ddl_mach_type1.DataTextField = "mach_type";
                ddl_mach_type1.DataBind();
                ddl_mach_type1.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_mach_type1.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_type1.Enabled = true;          
            }
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
        }
    }
    protected void ddl_mach_model2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_model2.SelectedIndex > 0)
        {
            #region Machine Type
            try
            {
                ddl_mach_type2.Visible = true;
                cn.Open();
                ddl_mach_type2.Items.Clear();
                //string Mach_Desc = ddl_comp.SelectedItem.Text;
                int Mach_Desc = Convert.ToInt32(ddl_comp2.SelectedValue);
                string Mach_Model = ddl_mach_model2.SelectedItem.Text;
                cmd = new SqlCommand("sp_Mach_Type_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
                cn.executeprocedure(cmd);
                DataTable DT_type = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_type.Load(dr);

                ddl_mach_type2.DataSource = DT_type;
                ddl_mach_type2.DataValueField = "mach_id";
                ddl_mach_type2.DataTextField = "mach_type";
                ddl_mach_type2.DataBind();
                ddl_mach_type2.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_mach_type2.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_type1.Enabled = true;
            }
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
        }
    }
    protected void ddl_mach_model3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_model3.SelectedIndex > 0)
        {
            #region Machine Type 3
            try
            {

                cn.Open();
                cmd = new SqlCommand("select * from tbl_machine_master where mach_cmp='" + ddl_comp3.SelectedItem.Text + "' and mach_model='" + ddl_mach_model3.SelectedItem.Text + "'", connection.con);
                DataTable DT_type = new DataTable();

                dr = cmd.ExecuteReader();
                DT_type.Load(dr);

                ddl_mach_type3.DataSource = DT_type;
                ddl_mach_type3.DataValueField = "mach_id";
                ddl_mach_type3.DataTextField = "mach_type";
                ddl_mach_type3.DataBind();
                ddl_mach_type3.Items.Insert(0, new ListItem("Type", "ptnt_nm"));
                ddl_mach_type3.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_type3.Visible = true;
            }
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
        }
    }
    protected void ddl_mach_model4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_model4.SelectedIndex > 0)
        {
            #region Machine Type 4
            try
            {

                cn.Open();
                cmd = new SqlCommand("select * from tbl_machine_master where mach_cmp='" + ddl_comp4.SelectedItem.Text + "' and mach_model='" + ddl_mach_model4.SelectedItem.Text + "'", connection.con);
                DataTable DT_type = new DataTable();

                dr = cmd.ExecuteReader();
                DT_type.Load(dr);

                ddl_mach_type4.DataSource = DT_type;
                ddl_mach_type4.DataValueField = "mach_id";
                ddl_mach_type4.DataTextField = "mach_type";
                ddl_mach_type4.DataBind();
                ddl_mach_type4.Items.Insert(0, new ListItem("Type", "ptnt_nm"));
                ddl_mach_type4.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_type4.Visible = true;
            }
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
        }
    }
    protected void ddl_mach_type1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type1.SelectedIndex > 0)
        {
            #region Machine Final1
            txt_mach1.Visible = true;
            txt_mach1.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp1.SelectedItem.Text + "," + ddl_mach_model1.SelectedItem.Text + "," + ddl_mach_type1.SelectedItem.Text));

            #endregion
        }
    }
    protected void ddl_mach_type2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type2.SelectedIndex > 0)
        {
            #region Machine Final2
            txt_mach2.Visible = true;
            txt_mach2.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp2.SelectedItem.Text + "," + ddl_mach_model2.SelectedItem.Text + "," + ddl_mach_type2.SelectedItem.Text));

            #endregion
        }
    }
    protected void ddl_mach3_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type3.SelectedIndex > 0)
        {
            #region Machine Final3
            txt_mach3.Visible = true;
            txt_mach3.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp3.SelectedItem.Text + "," + ddl_mach_model3.SelectedItem.Text + "," + ddl_mach_type3.SelectedItem.Text));

            #endregion
        }
    }
    protected void ddl_mach_type4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type4.SelectedIndex > 0)
        {
            #region Machine Final4
            txt_mach4.Visible = true;
            txt_mach4.Text = RemoveAllWhitespace(System.Convert.ToString(ddl_comp4.SelectedItem.Text + "," + ddl_mach_model4.SelectedItem.Text + "," + ddl_mach_type4.SelectedItem.Text));

            #endregion
        }
    }   
    protected void rbtn_speech_aud_left_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtn_speech_aud_left.SelectedIndex == 1)
        {
            txt_sds_left.Text = def.ToString();
            txt_srt_left.Text = def.ToString();
        }        
    }
    protected void rbtn_speech_aud_right_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtn_speech_aud_right.SelectedIndex == 1)
        {
            txt_sds_right.Text = def.ToString();
            txt_srt_right.Text = def.ToString();
        }
      }  
    protected void gridh_lastdigno_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gridh_lastdigno.PageIndex = e.NewPageIndex;
        loadgrid();
    }   
    protected void ddl_bera_left_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_bera_lt.Visible = true;
        txt_bera_lt.Text = ddl_bera_left.SelectedItem.Text;
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedIndex == 0)
        {
            Label34.Visible = true;
            Label12.Visible = true;
            ddl_comp1.Visible = true;
            ddl_comp2.Visible = true;
            ddl_comp3.Visible = true;
            ddl_comp4.Visible = true;
            txt_mach1.Visible = true;
            txt_mach2.Visible = true;
            Label34.Visible = true;
            Label12.Visible = true;
        }
        else 
        {
            Label34.Visible = false;
            Label12.Visible = false;
            ddl_comp1.Visible = false;
            ddl_comp2.Visible = false;
            ddl_comp3.Visible = false;
            ddl_comp4.Visible = false;
            Label34.Visible = false;
            Label12.Visible = false;
            txt_mach1.Visible = false;
            txt_mach2.Visible = false;
            txt_mach1.Text = "Not Applicable";
            txt_mach2.Text = "Not Applicable";
            txt_mach3.Text = "Not Applicable";
            txt_mach4.Text = "Not Applicable";
        }
    }
         #region PTA
    protected void btn_unmasked_pta_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txt_ac_250_r.Text == "NR") || (txt_ac_500_r.Text == "NR") || (txt_ac_1k_r.Text == "NR") || (txt_ac_2k_r.Text == "NR"))
            {
                txt_pta_rt.Text = ">120";
            }
            else
            {
                double ac_pta_rt = Convert.ToInt32(txt_ac_500_r.Text) + Convert.ToInt32(txt_ac_1k_r.Text) + Convert.ToInt32(txt_ac_2k_r.Text);
                double ac_pta_rt1 = (ac_pta_rt / 3);
                txt_pta_rt.Text = Convert.ToString(double.Parse((ac_pta_rt1).ToString("##0.00")));
                //(ac_pta_rt / 3).ToString();          
            }
            txt_ac_250_l.Focus();
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
    }
    protected void btn_masked_pta_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txt_mask_250_r.Text == "NR") || (txt_mask_500_r.Text == "NR") || (txt_mask_1k_r.Text == "NR") || (txt_mask_2k_r.Text == "NR"))
            {
                txt_pta_rt.Text = ">120";
            }
            else
            {
                double mask_rt = Convert.ToInt32(txt_mask_250_r.Text) + Convert.ToInt32(txt_mask_1k_r.Text) + Convert.ToInt32(txt_mask_2k_r.Text);
                double mask_rt1 = (mask_rt / 3);
                txt_pta_rt.Text = Convert.ToString(double.Parse((mask_rt1).ToString("##0.00")));
            }

        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
    }    
    protected void btn_unmasked_pta_l_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txt_ac_250_l.Text == "NR") || (txt_ac_500_l.Text == "NR") || (txt_ac_1k_l.Text == "NR") || (txt_ac_2k_l.Text == "NR"))
            {
                txt_pta_lt.Text = ">120";
            }
            else
            {
                double ac_pta_lt = Convert.ToInt32(txt_ac_500_l.Text) + Convert.ToInt32(txt_ac_1k_l.Text) + Convert.ToInt32(txt_ac_2k_l.Text);
                double ac_pta_lt1 = ac_pta_lt / 3;
                txt_pta_lt.Text = Convert.ToString(double.Parse((ac_pta_lt1).ToString("##0.00")));
            }
        }
        catch { Response.Redirect("~/error.aspx"); }
    }
    protected void btn_masked_pta_l_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txt_mask_250_l.Text == "NR") || (txt_mask_500_l.Text == "NR") || (txt_ac_1k_l.Text == "NR") || (txt_mask_1_5k_l.Text == "NR") || (txt_ac_2k_l.Text == "NR"))
            {
                txt_pta_lt.Text = ">120";
            }
            else
            {
                double mask_lt = Convert.ToInt32(txt_mask_500_l.Text) + Convert.ToInt32(txt_mask_1k_l.Text) + Convert.ToInt32(txt_mask_2k_l.Text);
                double mask_lt1 = mask_lt / 3;
                txt_pta_lt.Text = Convert.ToString(double.Parse((mask_lt1).ToString("##0.00")));
            }
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
    }
         #endregion
    protected void ddl_bera_right_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_bera_rt.Visible = true;
        txt_bera_rt.Text = ddl_bera_right.SelectedItem.Text;
    }
    protected void ddlRPre_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRPre.SelectedIndex == 0)
        {
            txttymp_right.Text = "Not Applicable";
        }
        else
        {
            txttymp_right.Text = (System.Convert.ToString(ddl_tymp_graph_right.SelectedItem.Text + " Type Graph" + "," + ddl_comp_right.SelectedItem.Text + "," +
            "" + " " + ddlRPre.SelectedItem.Text + " " + ddl_ref_rt.SelectedItem.Text));
            //+ "Reflexes " 
        }
    }
    protected void ddlLPre_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLPre.SelectedIndex == 0)
        {
            txttymp_left.Text = "Not Applicable";
        }
        else
        {
            txttymp_left.Text = (System.Convert.ToString(ddl_tymp_graph_left.SelectedItem.Text + " Type Graph " + "," + ddl_complaince_left.SelectedItem.Text + "," +
            "" + " " + ddlLPre.SelectedItem.Text + " " + ddl_reflexes_left.SelectedItem.Text));
           // + "Reflexes " 
        }
    }
    protected void rbtn_oae_right_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtn_oae_right.SelectedIndex == 0)
        {
            txtPass.Text = "Indicates normal functioning of outer haircell in Cochlea in absence of any significant pathology of outer or middle ear";
        }
        else if (rbtn_oae_right.SelectedIndex == 1)
        {
            txtPass.Text = "Indicates abnormal functioning of outer haircell in Cochlea in absence of any significant pathology of outer or middle ear";
        }
        else
        {
            txtPass.Text = "NA";
        }
    }
    protected void rbtn_oae_left_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtn_oae_left.SelectedIndex == 0)
        {
            txtPass1.Text = "Indicates normal functioning of outer haircell in Cochlea in absence of any significant pathology of outer or middle ear";
        }
        else if (rbtn_oae_left.SelectedIndex == 1)
        {
            txtPass1.Text = "Indicates abnormal functioning of outer haircell in Cochlea in absence of any significant pathology of outer or middle ear";
        }
        else
        {
            txtPass1.Text = "NA";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void lblNxt_Apt_Click(object sender, EventArgs e)
    {
        if (ddlnxtmeet.SelectedIndex == 0)
        {
            Response.Write("<script>alert('Next Appointment Not Allocated....')</script>");
        }
        else
        {
            #region Nxtmeet
            switch (ddlnxtmeet.SelectedIndex)
            {
                case 1:
                    nxtmeet(7, 7);
                    break;

                case 2:
                    nxtmeet(3, 6);
                    break;

                case 3:
                    nxtmeet(1, 7);
                    break;
                case 4:
                    nxtmeet(1, 30);
                    break;
                case 5:
                    nxtmeet(30, 30);
                    break;
                case 6:
                    nxtmeet(15, 15);
                    break;
                case 7:
                    nxtmeet(7, 15);
                    break;
                case 8:
                    nxtmeet(180, 180);
                    break;
                case 9:
                    nxtmeet(365, 365);
                    break;
            }
            #endregion
            //int ptntid1 = Convert.ToInt32(lblptnt_id.Text);
            //Response.Redirect("~/Clinical Forms/nxt_apts.aspx?ptnt_id=" + ptntid1 + " &Date" + txtdate.Text);
        }

    }
    protected void ddl_Additional_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtadd_test.Text = ddl_Additional.SelectedItem.Text;
    }
    public void print()
    {
        if (Session["H_as_id"].ToString() != "")
        {
            //int billno = Convert.ToInt32(asid);
            //int billno = Convert.ToInt32(lbl_asid.Value);
            int billno = Convert.ToInt32(Session["H_as_id"].ToString());
           Response.Redirect("~/h_as.aspx?bill_no=" + billno);            
        }
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {
        print();
    }
    protected void ddl_tymp_graph_right_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddl_tymp_graph_right.SelectedItem.Text=="'A'")
        {
            ddl_comp_right.SelectedIndex=0;
            ddlRPre.SelectedIndex = 1;
        }
        else if(ddl_tymp_graph_right.SelectedItem.Text=="'As'")
        {
            ddl_comp_right.SelectedIndex=5;
            ddlRPre.SelectedIndex = 1;
        }
        else if (ddl_tymp_graph_right.SelectedItem.Text == "'Ad'")
        {
            ddl_comp_right.SelectedIndex = 3;
            ddlRPre.SelectedIndex = 1;
        }
    }
    protected void ddl_tymp_graph_left_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_tymp_graph_left.SelectedItem.Text == "'A'")
        {
            ddl_complaince_left.SelectedIndex = 0;
            ddlLPre.SelectedIndex = 1;
        }
        else if (ddl_tymp_graph_left.SelectedItem.Text == "'As'")
        {
            ddl_complaince_left.SelectedIndex = 5;
            ddlLPre.SelectedIndex = 1;
        }
        else if (ddl_tymp_graph_left.SelectedItem.Text == "'Ad'")
        {
            ddl_complaince_left.SelectedIndex = 3;
            ddlLPre.SelectedIndex = 1;
        }
    }
    protected void btnMCL1_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txt_mcl_250_r.Text == "NR") || (txt_mcl_500_r.Text == "NR") || (txt_mcl_1k_r.Text == "NR") || (txt_mcl_2k_r.Text == "NR"))
            {
                txt_mcl_rt.Text = ">120";
            }
            else
            {
                double ac_mcl_rt = Convert.ToInt32(txt_mcl_500_r.Text) + Convert.ToInt32(txt_mcl_1k_r.Text) + Convert.ToInt32(txt_mcl_2k_r.Text);
                double ac_mcl_rt1 = (ac_mcl_rt / 3);
                txt_mcl_rt.Text = Convert.ToString(double.Parse((ac_mcl_rt1).ToString("##0.00")));                          
            }
            txt_ac_250_l.Focus();
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
    }
    protected void btnMCL2_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txt_mcl_250_l.Text == "NR") || (txt_mcl_500_l.Text == "NR") || (txt_mcl_1k_l.Text == "NR") || (txt_mcl_2k_l.Text == "NR"))
            {
                txt_mcl_lt.Text = ">120";
            }
            else
            {
                double ac_mcl_lt = Convert.ToInt32(txt_ucl_500_l.Text) + Convert.ToInt32(txt_ucl_1k_l.Text) + Convert.ToInt32(txt_ucl_2k_l.Text);
                double ac_mcl_lt1 = (ac_mcl_lt / 3);
                txt_mcl_lt.Text = Convert.ToString(double.Parse((ac_mcl_lt1).ToString("##0.00")));                          
            }            
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
    }
    protected void btnUCL1_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txt_ucl_250_r.Text == "NA") || (txt_ucl_500_r.Text == "NA") || (txt_ucl_1k_r.Text == "NA") || (txt_ucl_2k_r.Text == "NA"))
            {
                txt_ucl_rt.Text = ">120";
            }
            else
            {
                double ac_ucl_rt = Convert.ToInt32(txt_ucl_500_r.Text) + Convert.ToInt32(txt_ucl_1k_r.Text) + Convert.ToInt32(txt_ucl_2k_r.Text);
                double ac_ucl_rt1 = (ac_ucl_rt / 3);
                txt_ucl_rt.Text = Convert.ToString(double.Parse((ac_ucl_rt1).ToString("##0.00")));                          
            }
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
    }
    protected void btnUCL2_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txt_ucl_250_l.Text == "NA") || (txt_ucl_500_l.Text == "NA") || (txt_ucl_1k_l.Text == "NA") || (txt_ucl_2k_l.Text == "NA"))
            {
                txt_ucl_lt.Text = ">120";
            }
            else
            {
                double ac_ucl_lt = Convert.ToInt32(txt_ucl_500_l.Text) + Convert.ToInt32(txt_ucl_1k_l.Text) + Convert.ToInt32(txt_ucl_2k_l.Text);
                double ac_ucl_lt1 = ac_ucl_lt / 3;
                txt_ucl_lt.Text = Convert.ToString(double.Parse((ac_ucl_lt1).ToString("##0.00")));
            }
        }
        catch { Response.Redirect("~/error.aspx"); }
    }
}
