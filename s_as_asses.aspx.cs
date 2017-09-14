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

public partial class Clinical_Forms_s_as_asses : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    DataSet ds,ds1;
    SqlDataAdapter da;
    int j, def = 0;
    string[] apt1;
    string apttime, ptntfor;
    string aptid, apt_for;//,ptntid;
    string[] adj ={"08:00 AM","08:30 AM","09:00 AM","09:30 AM","10:00 AM", "10:30 AM","11:00 AM","11:30 AM","12:00 PM","12:30 PM","01:00 PM","01:30 PM","02:00 PM","02:30 PM","03:00 PM",
                   "03:30 PM","04:00 PM","04:30 PM","05:00 PM","05:30 PM","06:00 PM","06:30 PM","07:00 PM","07:30 PM","08:00 PM"};
    double id;
    DateTime aptdt, dt,Birth_Dt;
    //int Bill_No;
    string[] Language = { "English", "Marathi", "Hindi", "Sindhi", "Gujrati", "Kanada", "Tamil", "Telagu", "Urdu", "Bhojpuri", "Rajasthani", "Punjabi", "Bangali","Tullu" };
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
                #region Pageload                
                //InitList1();
                //InitList();
                lbl_msg_supra.Visible = false;
                Image1.Visible = false;

                txt_lang.Visible = false;               
                btn_add_lang.Visible = false;

                txtsel1.Visible = false;
                txtsel2.Visible = false;
                language_add();
                #endregion
                //int Apt_id = Convert.ToInt32(Request.QueryString["id"].ToString());
                //DataFill(Apt_id);
                if (Convert.ToInt32(Session["Ass_id"].ToString()) == 0)
                {
                    int Apt_id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    aptid = Request.QueryString["id"].ToString();
                    DataFill(Apt_id);
                    btn_print.Visible = false;
                }
                else
                {
                    btn_print.Visible = true;
                    Select();
                }
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
                cmd = new SqlCommand("sp_S_Ass_Id_Rpt", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pS_as_id", Ass_id);
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblas_id.Value = DT1.Rows[0][1].ToString();
                lblaptid.Value = DT1.Rows[0][2].ToString();
                DataFill(Convert.ToInt32(lblaptid.Value));
                txtbirthhistry.Text = DT1.Rows[0][4].ToString();
                txtmedhistry.Text = DT1.Rows[0][5].ToString();
                txt_lang.Text = DT1.Rows[0][6].ToString();
                txtcom.Text = DT1.Rows[0][7].ToString();
                txtsel1.Visible = true;
                txtsel2.Visible = true;
                txtsel1.Text = DT1.Rows[0][8].ToString();
                txtsel2.Text = DT1.Rows[0][9].ToString();
                txtseppar.Text = DT1.Rows[0][10].ToString();
                string EyeCon = DT1.Rows[0][11].ToString();
                if (EyeCon == "Present")
                {
                    rbtneyecont.SelectedIndex = 0;
                }
                else if (EyeCon == "Absent")
                {
                    rbtneyecont.SelectedIndex = 1;
                }
                else
                {
                    rbtneyecont.SelectedIndex = 2;
                }
                txtsocsmile.Text = DT1.Rows[0][12].ToString();
                string AttSpm = DT1.Rows[0][13].ToString();
                if (AttSpm == "Poor")
                {
                    rbtnattspan.SelectedIndex = 0;
                }
                else if (AttSpm == "Good")
                {
                    rbtnattspan.SelectedIndex = 1;
                }
                else if (AttSpm == "Inadequate")
                {
                    rbtnattspan.SelectedIndex = 2;
                }
                else
                {
                    rbtnattspan.SelectedIndex = 3;
                }

                string ConCen = DT1.Rows[0][14].ToString();
                if (ConCen== "Poor")
                {
                    rbtnconcetration.SelectedIndex = 0;
                }
                else if (ConCen == "Good")
                {
                    rbtnconcetration.SelectedIndex = 1;
                }
                else if (EyeCon == "Inadequate")
                {
                    rbtnconcetration.SelectedIndex = 2;
                }
                else
                {
                    rbtnconcetration.SelectedIndex = 3;
                }

                string Distra = DT1.Rows[0][15].ToString();
                if (Distra == "Easily")
                {
                    rbtndistrability.SelectedIndex = 0;
                }
                else if (Distra == "Stable")
                {
                    rbtndistrability.SelectedIndex = 1;
                }
                else 
                {
                    rbtndistrability.SelectedIndex = 2;
                }

                string CoOp = DT1.Rows[0][16].ToString();
                if (CoOp == "Co-Operative")
                {
                    rbtncoop.SelectedIndex = 0;
                }
                else if (CoOp == "Non Co-Operative")
                {
                    rbtncoop.SelectedIndex = 1;
                }
                else 
                {
                    rbtncoop.SelectedIndex = 2;
                }

                string INT = DT1.Rows[0][17].ToString();
                if (INT == "Yes")
                {
                    rbtninttoy.SelectedIndex = 0;
                }
                else if (INT == "No")
                {
                    rbtninttoy.SelectedIndex = 1;
                }
                else 
                {
                    rbtninttoy.SelectedIndex = 2;
                }

                string PHYM = DT1.Rows[0][18].ToString();
                if (PHYM == "Normal")
                {
                    rbtnphymov.SelectedIndex = 0;
                }
                else if (PHYM == "Hyper")
                {
                    rbtnphymov.SelectedIndex = 1;
                }
                else if (PHYM == "Low")
                {
                    rbtnphymov.SelectedIndex = 2;
                }
                else if (PHYM == "Clumpsy")
                {
                    rbtnphymov.SelectedIndex = 3;
                }
                else 
                {
                    rbtnphymov.SelectedIndex = 4;
                }

                string FM = DT1.Rows[0][19].ToString();
                if (EyeCon == "Normal")
                {
                    rbtnfacmov.SelectedIndex = 0;
                }
                else if (EyeCon == "Abnormal")
                {
                    rbtnfacmov.SelectedIndex = 1;
                }
                else
                {
                    rbtnfacmov.SelectedIndex = 2;
                }

                string IS = DT1.Rows[0][20].ToString();
                if (IS == "Normal")
                {
                    rbtnimmtskill.SelectedIndex = 0;
                }
                else if (IS == "Abnormal")
                {
                    rbtnimmtskill.SelectedIndex = 1;
                }
                else
                {
                    rbtnimmtskill.SelectedIndex = 2;
                }

                string TC = DT1.Rows[0][21].ToString();
                if (TC == "Achived")
                {
                    rbtntoiletcont.SelectedIndex = 0;
                }
                else if (TC == "Not Achived")
                {
                    rbtntoiletcont.SelectedIndex = 1;
                }
                else
                {
                    rbtntoiletcont.SelectedIndex = 2;
                }
                txt_abn_beh.Text = DT1.Rows[0][22].ToString();
                //SUPRA SEGMENTAL//
                
                ddlintonation.SelectedItem.Text = DT1.Rows[0][23].ToString();
                string Supra = DT1.Rows[0][24].ToString();
                
                     if (Supra == "Applicable")
                {
                    rbtn_supra.SelectedIndex = 0;
                }
                else
                {
                    rbtn_supra.SelectedIndex = 1;
                }
                string Emph = DT1.Rows[0][25].ToString();
                if (Emph == "Appropriate")
                {
                    rbtnemphasis.SelectedIndex = 0;
                }
                else if (Emph == "Inappropriate")
                {
                    rbtnemphasis.SelectedIndex = 1;
                }
                else
                {
                    rbtnemphasis.SelectedIndex = 2;
                }
                string Phra = DT1.Rows[0][26].ToString();
                if (Phra == "Appropriate")
                {
                    rbtnphrasing.SelectedIndex = 0;
                }
                else if (Phra == "Inappropriate")
                {
                    rbtnphrasing.SelectedIndex = 1;
                }
                else
                {
                    rbtnphrasing.SelectedIndex = 2;
                }
                string Rate = DT1.Rows[0][27].ToString();
                if (Rate == "Fast")
                {
                    rbtnrate.SelectedIndex = 0;
                }
                else if (Rate == "Slow")
                {
                    rbtnrate.SelectedIndex = 1;
                }
                else if (Rate == "Normal")
                {
                    rbtnrate.SelectedIndex = 2;
                }
                else
                {
                    rbtnrate.SelectedIndex = 3;
                }
                dr = null;
                cn.Close();
                GridLoad();
                btn_save.Text = "Edit";               
            }
            catch
            { }

            #endregion
        }
    }
    public void GridLoad()
    {
        double pid = System.Convert.ToInt32(lblptnt_id.Value);
        cn.Open();
        cmd = connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from tbl_assess where ptnt_id=" + pid + "";

        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "tbl_assess");

        if (ds.Tables["tbl_assess"].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables["tbl_assess"];
            GridView1.DataBind();
            Label1.Text = (ds.Tables["tbl_assess"].Rows[0][3].ToString());
        }
        else
        {
            Response.Write("<script>alert('Please Select Valid Patient')</script>");
        }
        cn.Close();
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
                        txtptntNm.Text = sdr["ptnt_nm"].ToString();
                        lblptntdob.Text = sdr["ptnt_dob"].ToString();
                        lblgender.Text = sdr["ptnt_gender"].ToString();
                        lblprofession.Text = sdr["ptnt_prof"].ToString();
                        dt = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
                        Birth_Dt = DateTime.ParseExact(lblptntdob.Text, "MM/dd/yyyy", null);
                        string Year = Convert.ToString((dt.Year) - (Birth_Dt.Year));
                        string Month = Convert.ToString((dt.Month) - (Birth_Dt.Month));
                        string Days = Convert.ToString((dt.Day) - (Birth_Dt.Day));
                        lblptntage.Text = (Year + " Year" + ',' + Month + " Month" + ',' + Days + " Days");
                        txtptntNm.Enabled = false;
                        lblptntdob.Enabled = false;
                        lblptntage.Enabled = false;
                        lblgender.Enabled = false;
                        lblprofession.Enabled = false;
                    }
                }
                conn.Close();
            }
        }
    }
    #region init
    //public void InitList1()
    //{
    //    ddl_mother_tongue.Items.Clear();

    //    foreach (string st in Language)
    //    {
    //        ddl_mother_tongue.Items.Add(st);
    //    }
    //    ddl_mother_tongue.Items.Insert(0, "Select");
    //}
    //public void InitList()
    //{
    //    lst_lang_used.Items.Clear();
    //    lst_env_lang.Items.Clear();

    //    foreach (string st in Language)
    //    {
    //        lst_lang_used.Items.Add(st);
    //        lst_env_lang.Items.Add(st);
    //    }
    //}
    #endregion

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
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtptntNm.Text == "")

            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            #region Save
            int apt_id = Convert.ToInt32(lblaptid.Value);
            int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
            int sasid = 0;
            string s_birth_histry = txtbirthhistry.Text;
            string s_med_histry = txtmedhistry.Text;
            string s_mother_tongue = ddl_mother_tongue.SelectedItem.Text;
            string s_communication = txtcom.Text;
            string lang_used = txtsel1.Text;
            string env_lang = txtsel2.Text;
            string s_sep_par = txtseppar.Text;
            string s_eye_cont = rbtneyecont.SelectedItem.Text;
            string s_soc_smile = txtsocsmile.Text;
            string s_atten_span = rbtnattspan.SelectedItem.Text;
            string s_concentration = rbtnconcetration.SelectedItem.Text;
            string s_distractibility = rbtndistrability.SelectedItem.Text;
            string s_co_op = rbtncoop.SelectedItem.Text;
            string s_int_toy = rbtninttoy.SelectedItem.Text;
            string s_phy_mov = rbtnphymov.SelectedItem.Text;
            string s_fac_mov = rbtnfacmov.SelectedItem.Text;
            string s_immitation_skills = rbtnimmtskill.SelectedItem.Text;
            string s_toilet_cont = rbtntoiletcont.SelectedItem.Text;
            string s_abnorm_beh = txt_abn_beh.Text;
            string s_supra_seg = rbtn_supra.SelectedItem.Text;
            string s_intonation = ddlintonation.SelectedItem.Text;
            string s_emphasis = rbtnemphasis.SelectedItem.Text;
            string s_phrasing = rbtnphrasing.SelectedItem.Text;
            string s_rate = rbtnrate.SelectedItem.Text;
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Cur_Age = lblptntage.Text;
            string Flag = "I";
            cn.Open();
            cmd = new SqlCommand("tbl_assess_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ps_asses_id", sasid);
            cmd.Parameters.AddWithValue("@papt_id", apt_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@ps_birth_histry", s_birth_histry);
            cmd.Parameters.AddWithValue("@ps_med_histry", s_med_histry);
            cmd.Parameters.AddWithValue("@ps_mother_tongue", s_mother_tongue);
            cmd.Parameters.AddWithValue("@ps_communication", s_communication);
            cmd.Parameters.AddWithValue("@ps_lang_used", lang_used);
            cmd.Parameters.AddWithValue("@ps_lang_env", env_lang);
            cmd.Parameters.AddWithValue("@ps_sep_par", s_sep_par);
            cmd.Parameters.AddWithValue("@ps_eye_cont", s_eye_cont);
            cmd.Parameters.AddWithValue("@ps_soc_smile", s_soc_smile);
            cmd.Parameters.AddWithValue("@ps_atten_span", s_atten_span);
            cmd.Parameters.AddWithValue("@ps_concentration", s_concentration);
            cmd.Parameters.AddWithValue("@ps_distractibility", s_distractibility);
            cmd.Parameters.AddWithValue("@ps_co_op", s_co_op);
            cmd.Parameters.AddWithValue("@ps_int_toy", s_int_toy);
            cmd.Parameters.AddWithValue("@ps_phy_mov", s_phy_mov);
            cmd.Parameters.AddWithValue("@ps_fac_mov", s_fac_mov);
            cmd.Parameters.AddWithValue("@ps_immitation_skills", s_immitation_skills);
            cmd.Parameters.AddWithValue("@ps_toilet_cont", s_toilet_cont);
            cmd.Parameters.AddWithValue("@ps_abnorm_beh", s_abnorm_beh);
            cmd.Parameters.AddWithValue("@ps_supra_seg", s_supra_seg);
            cmd.Parameters.AddWithValue("@ps_intonation", s_intonation);
            cmd.Parameters.AddWithValue("@ps_emphasis", s_emphasis);
            cmd.Parameters.AddWithValue("@ps_phrasing", s_phrasing);
            cmd.Parameters.AddWithValue("@ps_rate", s_rate);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cmd.Parameters.AddWithValue("@pCur_Age", Cur_Age);
            //cn.executeprocedure(cmd);
            int a = cn.executeprocedure(cmd);            
            cn.Close();
            #endregion
            Session["S_as_id"] = a.ToString();
            Response.Redirect("~/s_as_s_l_dev.aspx");
            btn_save.Enabled = false;
            //Save.Enabled = false;
        }
        catch {/* Response.Redirect("~/error.aspx");*/ }
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

            int ptntid1 = Convert.ToInt32(lblptnt_id.Value);
            //Response.Redirect("~/Clinical Forms/nxt_apts.aspx?ptnt_id=" + ptntid1 + " &Date" + txtdate.Text);
        }
    }
    protected void validate_page_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if ((txtbirthhistry.Text == "") || (txtmedhistry.Text == "") || (txtcom.Text == "") || (ddl_mother_tongue.SelectedIndex == 0) || (rbtneyecont.SelectedIndex == -1)
           || (txtsocsmile.Text == "") || (rbtnattspan.SelectedIndex == -1) || (rbtnconcetration.SelectedIndex == -1) || (rbtndistrability.SelectedIndex == -1) ||
        (rbtncoop.SelectedIndex == -1) || (rbtninttoy.SelectedIndex == -1) || (rbtnphymov.SelectedIndex == -1) || (rbtnfacmov.SelectedIndex == -1) || (rbtnimmtskill.SelectedIndex == -1)
        || (rbtntoiletcont.SelectedIndex == -1) || (ddlintonation.SelectedIndex == 0) || (rbtnemphasis.SelectedIndex == -1) || (rbtnphrasing.SelectedIndex == -1)
        || (rbtnrate.SelectedIndex == -1))
        { args.IsValid = false; }
        else { args.IsValid = true; }
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Ass Not Applicable
        if (RadioButtonList2.SelectedIndex == 0)
        {
            txtseppar.Text = "Not Applicable";
            rbtneyecont.SelectedIndex = 2;
            txtsocsmile.Text = "Not Applicable";
            rbtnattspan.SelectedIndex = 3;
            rbtnconcetration.SelectedIndex = 3;
            rbtndistrability.SelectedIndex = 2;
            rbtncoop.SelectedIndex = 2;
            rbtninttoy.SelectedIndex = 2;
            rbtnphymov.SelectedIndex = 0;
            rbtnfacmov.SelectedIndex = 2;
            rbtnimmtskill.SelectedIndex = 2;
            rbtntoiletcont.SelectedIndex = 2;
            txt_abn_beh.Text = "Not Applicable";

        }
        else
        {
            if ((rbtneyecont.SelectedIndex == -1)
              || (txtsocsmile.Text == "") || (rbtnattspan.SelectedIndex == -1) || (rbtnconcetration.SelectedIndex == -1) || (rbtndistrability.SelectedIndex == -1) ||
           (rbtncoop.SelectedIndex == -1) || (rbtninttoy.SelectedIndex == -1) || (rbtnphymov.SelectedIndex == -1) || (rbtnfacmov.SelectedIndex == -1) || (rbtnimmtskill.SelectedIndex == -1)
           || (rbtntoiletcont.SelectedIndex == -1))
            {
                lbl_msg_supra.Visible = true;
            }
            else
            { lbl_msg_supra.Visible = false; }

        }
        #endregion
    }
    protected void rbtn_supra_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Supra
        if (rbtn_supra.SelectedIndex == 1)
        {
            ddlintonation.SelectedIndex = 4;
            rbtnemphasis.SelectedIndex = 2;
            rbtnphrasing.SelectedIndex = 2;
            rbtnrate.SelectedIndex = 3;


        }
        else
        {
            ddlintonation.SelectedIndex = 0;
            rbtnemphasis.SelectedIndex = -1;
            rbtnphrasing.SelectedIndex = -1;
            rbtnrate.SelectedIndex = -1;

            if ((ddlintonation.SelectedIndex == 0) || (rbtnemphasis.SelectedIndex == -1) || (rbtnphrasing.SelectedIndex == -1) || (rbtnrate.SelectedIndex == -1))
            {
                lbl_msg_supra.Visible = true;
            }
            else
            { lbl_msg_supra.Visible = false; }
        }
#endregion
    }
    protected void valid_page_wiz1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            if ((txtbirthhistry.Text == "") || (txtmedhistry.Text == "") || (txtcom.Text == "") || (ddl_mother_tongue.SelectedIndex == 0))
            { args.IsValid = false; }

            else { args.IsValid = true; }
        }
        catch { Response.Redirect("~/error.aspx"); }
    }
    //public void Image()
    //{
    //    #region Image
    //    try
    //    {
    //        cn.Open();
    //        double id = Convert.ToDouble(lblptnt_id.Text);

    //        string qry = "select * from tbl_ptnt_image" +
    //                                 @" where ptnt_id='" + id + "' ";
    //        ds1 = cn.GetData(qry, "tbl_ptnt_image");

    //        if (ds1.Tables["tbl_ptnt_image"].Rows.Count == 0)
    //        {
    //            Image1.Visible = false;
    //        }
    //        else
    //        {
    //            qry = ds1.Tables["tbl_ptnt_image"].Rows[0][0].ToString();

    //            if (ds1.Tables["tbl_ptnt_image"].Rows.Count > 0)
    //            {
    //                Image1.ImageUrl = "~/ShowImage.ashx?id=" + id;
    //                Image1.Visible = true;
    //            }
    //        }
    //    }
    //    catch
    //    {
    //        Response.Redirect("~/error.aspx");

    //    }
    //    #endregion
    //}
    protected void btn_nxt_Click(object sender, EventArgs e)
    {         
        Session["S_as_id"] = lblas_id.Value;
        Response.Redirect("~/s_as_s_l_dev.aspx");
       // string bill = txtptntNm.Text.ToString();
        //Response.Redirect("~/h_digno.aspx?bill_no=" + bill); 
    }
    //private void nxtmeet(int p, int p_2)
    //{
    //    throw new Exception("The method or operation is not implemented.");
    //}

    #region Language
    protected void lst_lang_used_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtsel1.Visible = true;
            if (txtsel1.Text == "")
            {
                txtsel1.Text = lst_lang_used.SelectedItem.ToString();
            }
            else
            {
                txtsel1.Text = (txtsel1.Text + "," + lst_lang_used.SelectedItem.ToString());

            }
            lst_lang_used.Items.Remove(lst_lang_used.SelectedItem);

        }
        catch
        {
            Response.Redirect("~/Login/login.aspx");
        }
    }
    protected void lst_env_lang_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtsel2.Visible = true;
            if (txtsel2.Text == "")
            {
                txtsel2.Text = lst_env_lang.SelectedItem.ToString();
            }
            else
            {
                txtsel2.Text = (txtsel2.Text + "," + lst_env_lang.SelectedItem.ToString());

            }
            lst_env_lang.Items.Remove(lst_env_lang.SelectedItem);

        }

        catch
        {
            Response.Redirect("~/Login/login.aspx");
        }
    }
    #endregion

    protected void language_add()
    {
        #region Language Function
        cn.Open();
        string lang = ("select * from language_master");
        ds = cn.GetData(lang, "language_master");
        if (ds.Tables["language_master"].Rows.Count == 0)
        {
            string[] language ={ "Langauge", "Other"};
            for (int i = 0; i < language.Length; i++)
            {
                cn.Open();
                cmd = new SqlCommand("sp_lang_insert", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_lang", language[i].ToString());
                cn.executeprocedure(cmd);
            }
            cn.Open();
            cmd = new SqlCommand("select * from language_master", connection.con);
            DataTable dtlang = new DataTable();
            dr = cmd.ExecuteReader();
            dtlang.Load(dr);
            ddl_mother_tongue.DataSource = dtlang;
            ddl_mother_tongue.DataValueField = "lang_id";
            ddl_mother_tongue.DataTextField = "lang";
            ddl_mother_tongue.DataBind();
            lst_lang_used.DataSource = dtlang;
            lst_lang_used.DataValueField = "lang_id";
            lst_lang_used.DataTextField = "lang";
            lst_lang_used.DataBind();
            lst_env_lang.DataSource = dtlang;
            lst_env_lang.DataValueField = "lang_id";
            lst_env_lang.DataTextField = "lang";
            lst_env_lang.DataBind();
            cn.Close();
        }
        else
        {
            cn.Open();
            cmd = new SqlCommand("select * from language_master", connection.con);
            DataTable dtlang = new DataTable();
            dr = cmd.ExecuteReader();
            dtlang.Load(dr);
            ddl_mother_tongue.DataSource = dtlang;
            ddl_mother_tongue.DataValueField = "lang_id";
            ddl_mother_tongue.DataTextField = "lang";
            ddl_mother_tongue.DataBind();
            lst_lang_used.DataSource = dtlang;
            lst_lang_used.DataValueField = "lang_id";
            lst_lang_used.DataTextField = "lang";
            lst_lang_used.DataBind();
            lst_env_lang.DataSource = dtlang;
            lst_env_lang.DataValueField = "lang_id";
            lst_env_lang.DataTextField = "lang";
            lst_env_lang.DataBind();
            cn.Close();

        }
        #endregion
    }

    protected void ddl_mother_tongue_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mother_tongue.SelectedIndex == 1)
        {
            txt_lang.Visible = true;
            btn_add_lang.Visible = true;
        }
        else
        {
            txt_lang.Visible = false;
            btn_add_lang.Visible = false;
        }
    }
    protected void btn_add_lang_Click(object sender, EventArgs e)
    {
        if (txt_lang.Text == "")
        {
            Response.Write("<script>alert('Please Enter Language!!')</script>");
        }
        else
        {
            string add = txt_lang.Text.ToString();

            cn.Open();
            cmd = new SqlCommand("sp_lang_insert", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_lang", add);
            cn.executeprocedure(cmd);
            language_add();
            txt_lang.Visible = false;
            btn_add_lang.Visible = false;
        }
    }
    protected void btn_nxt1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_s_l_dev.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime dt;
        dt = Convert.ToDateTime(GridView1.SelectedRow.Cells[0].Text);
        int id = Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text);
        //Response.Redirect("~/Bill/hm_Sale_print.aspx?bill_no=" + id);
        //cmd = new SqlCommand("sp_ptnt_info_name", connection.con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@p_ptnt_id", id);
        //cn.Open();
        //cn.executeprocedure(cmd);
        //DataTable DT1 = new DataTable();
        //cn.Open();
        //dr = cmd.ExecuteReader();
        //DT1.Load(dr);

        //lblptnt_id.Text = DT1.Rows[0][1].ToString();
        //lblptnttype.Text = DT1.Rows[0][2].ToString();
        //lblptntdob.Text = DT1.Rows[0][4].ToString();
        //lblptntage.Text = DT1.Rows[0][5].ToString();
        //lblgender.Text = DT1.Rows[0][6].ToString();
        //lblprofession.Text = DT1.Rows[0][7].ToString();
        //dr = null;
        //cn.Close();
        lblas_id.Value = "";
        lblptnt_id.Value="";
        cmd = new SqlCommand("sp_asses_search", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@p_ptnt_id", id);
        //cmd.Parameters.AddWithValue("@p_asses_dt", dt);
        cn.Open();
        cn.executeprocedure(cmd);
        DataTable DT2 = new DataTable();
        cn.Open();
        dr = cmd.ExecuteReader();
        DT2.Load(dr);
        lblptnt_id.Value  = DT2.Rows[0][3].ToString();
        //lblaptid.Text = DT2.Rows[0][2].ToString();
        //lblas_id.Text = DT2.Rows[0][1].ToString();
        //lbldate.Text = DT2.Rows[0][0].ToString();
        txtbirthhistry.Text=DT2.Rows[0][4].ToString();
        txtmedhistry.Text=DT2.Rows[0][5].ToString();
        string Lan = DT2.Rows[0][6].ToString();
        if (Lan == "Other")
        { 
            ddl_mother_tongue.SelectedIndex = 1;
        }
        else if (Lan == "MARATHI")
        {
            ddl_mother_tongue.SelectedIndex = 2;
        }
        else if (Lan == "marawadi")
        {
            ddl_mother_tongue.SelectedIndex = 3;
        }
        else if (Lan == "konkani")
        {
            ddl_mother_tongue.SelectedIndex = 4;
        }
        else if (Lan == "kanada")
        {
            ddl_mother_tongue.SelectedIndex = 5;
        }
        else if (Lan == "English")
        {
            ddl_mother_tongue.SelectedIndex = 6;
        }
        else if (Lan == "Hindi")
        {
            ddl_mother_tongue.SelectedIndex = 7;
        }
        else if (Lan == "SINDHI")
        {
            ddl_mother_tongue.SelectedIndex = 8;
        }
        else if (Lan == "telagu")
        {
            ddl_mother_tongue.SelectedIndex = 9;
        }
        else if (Lan == "tulu")
        {
            ddl_mother_tongue.SelectedIndex = 10;
        }
        else if (Lan == "Gujarati")
        {
            ddl_mother_tongue.SelectedIndex = 11;
        }
        else
        {
            ddl_mother_tongue.SelectedIndex = 12;
        }
        txtcom.Text = DT2.Rows[0][7].ToString();
        txtsel1.Text = DT2.Rows[0][8].ToString();
        txtsel2.Text=DT2.Rows[0][9].ToString();
        txtseppar.Text = DT2.Rows[0][10].ToString();
        string Eye_Con = DT2.Rows[0][11].ToString();
        if (Eye_Con == "Present")
        {
            rbtneyecont.SelectedIndex = 0;
        }
        else if (Eye_Con == "Absent")
        {
            rbtneyecont.SelectedIndex = 0;
        }        
        else
        {
            rbtneyecont.SelectedIndex = 3;
        }
        txtsocsmile.Text = DT2.Rows[0][12].ToString();
        string Atten_span = DT2.Rows[0][13].ToString();
        if (Eye_Con == "Poor")
        {
            rbtnattspan.SelectedIndex = 0;
        }
        else if (Eye_Con == "Good")
        {
            rbtnattspan.SelectedIndex = 1;
        }
        else if (Eye_Con == "Inadequate")
        {
            rbtnattspan.SelectedIndex = 2;
        }
        else
        {
            rbtnattspan.SelectedIndex = 3;
        }
        string Contra=DT2.Rows[0][14].ToString();
        if (Contra == "Poor")
        {
            rbtnattspan.SelectedIndex = 0;
        }
        else if (Contra == "Good")
        {
            rbtnattspan.SelectedIndex = 1;
        }
        else if (Contra == "Inadequate")
        {
            rbtnattspan.SelectedIndex = 2;
        }
        else
        {
            rbtnattspan.SelectedIndex = 3;
        }
        string Distri = DT2.Rows[0][15].ToString();
        if (Distri == "Easily")
        {
            rbtndistrability.SelectedIndex = 0;
        }
        else if (Distri == "Stable")
        {
            rbtndistrability.SelectedIndex = 1;
        }       
        else
        {
            rbtndistrability.SelectedIndex = 3;
        }
        string Co_Op = DT2.Rows[0][16].ToString();
        if (Co_Op == "Co-Operative")
        {
            rbtncoop.SelectedIndex = 0;
        }
        else if (Co_Op == "Non Co-Operative")
        {
            rbtncoop.SelectedIndex = 1;
        }
        else
        {
            rbtncoop.SelectedIndex = 3;
        }
        string Inte_in_toy = DT2.Rows[0][17].ToString();
        if (Inte_in_toy == "Yes")
        {
            rbtninttoy.SelectedIndex = 0;
        }
        else if (Inte_in_toy == "No")
        {
            rbtninttoy.SelectedIndex = 1;
        }
        else
        {
            rbtninttoy.SelectedIndex = 3;
        }
        string Physic_mov=DT2.Rows[0][18].ToString();
        if (Physic_mov == "Normal")
        {
            rbtnphymov.SelectedIndex = 0;
        }
        else if (Physic_mov == "Hyper")
        {
            rbtnphymov.SelectedIndex = 1;
        }
        else if (Physic_mov == "Low")
        {
            rbtnphymov.SelectedIndex = 2;
        }
        else if (Physic_mov == "Clumpsy")
        {
            rbtnphymov.SelectedIndex = 3;
        }
        else
        {
           rbtnphymov.SelectedIndex = 4;
        }
        string Facial_Mov = DT2.Rows[0][19].ToString();
        if (Facial_Mov == "Normal")
        {
            rbtnfacmov.SelectedIndex = 0;
        }
        else if (Facial_Mov == "Abnormal")
        {
            rbtnfacmov.SelectedIndex = 1;
        }
        else
        {
            rbtnfacmov.SelectedIndex = 3;
        }
        string Imit_skil = DT2.Rows[0][20].ToString();
        if (Imit_skil == "Good")
        {
            rbtnimmtskill.SelectedIndex = 0;
        }
        else if (Imit_skil == "Poor")
        {
            rbtnimmtskill.SelectedIndex = 1;
        }
        else
        {
            rbtnimmtskill.SelectedIndex = 3;
        }
        string Toil_Con = DT2.Rows[0][21].ToString();
        if (Toil_Con == "Achived")
        {
            rbtntoiletcont.SelectedIndex = 0;
        }
        else if (Toil_Con == "Not Achived")
        {
            rbtntoiletcont.SelectedIndex = 1;
        }
        else
        {
            rbtntoiletcont.SelectedIndex = 3;
        }
        txt_abn_beh.Text=DT2.Rows[0][22].ToString();
        string Itona=DT2.Rows[0][24].ToString();
        if (Itona == "Select")
        {
            ddlintonation.SelectedIndex = 0;
        }
        else if (Itona == "Flat")
        {
            ddlintonation.SelectedIndex = 1;
        }
        else if (Itona == "Normal")
        {
            ddlintonation.SelectedIndex = 2;
        }
        else if (Itona == "Abnormal")
        {
            ddlintonation.SelectedIndex = 3;
        }
        else
        {
           ddlintonation.SelectedIndex = 4;
        }
        string Emphy = DT2.Rows[0][25].ToString();
        if (Emphy == "Appropriate")
        {
            rbtnemphasis.SelectedIndex = 0;
        }
        else if (Emphy == "Inappropriate")
        {
            rbtnemphasis.SelectedIndex = 1;
        }
        else
        {
            rbtnemphasis.SelectedIndex = 3;
        }
        string Phra = DT2.Rows[0][26].ToString();
        if (Phra == "Appropriate")
        {
            rbtnphrasing.SelectedIndex = 0;
        }
        else if (Phra == "Inappropriate")
        {
            rbtnphrasing.SelectedIndex = 1;
        }
        else
        {
            rbtnphrasing.SelectedIndex = 3;
        }
        string Rate = DT2.Rows[0][27].ToString();
        if (Rate == "Fast")
        {
            rbtnrate.SelectedIndex = 0;
        }
        else if (Rate == "Slow")
        {
            rbtnrate.SelectedIndex = 1;
        }
        else if (Rate == "Normal")
        {
            rbtnrate.SelectedIndex = 2;
        }
        else
        {
            rbtnphrasing.SelectedIndex = 3;
        }
        
        dr = null;
        cn.Close();
        //Bill_No = Convert.ToInt32(lblas_id.Text);      
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {       
        int ids = Convert.ToInt32(lblas_id.Value);
        Response.Redirect("~/speech_as_rpt.aspx?asses_id=" + ids);
    }
    protected void btn_New_Click(object sender, EventArgs e)
    {
         if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            cn = new connection();
            //id = cn.getmaxid("Select max(s_asses_id)from tbl_assess", "tbl_s_as_trn");
            //if (id == 0) { lblas_id.Value = System.Convert.ToString(id + 1); }
            //else { lblas_id.Value  = System.Convert.ToString(id + 1); }

            if (!IsPostBack)
            {
                #region Pageload
                
                //InitList1();
                //InitList();
                //lbldate.Text = System.DateTime.Now.Date.ToShortDateString();
                lbl_msg_supra.Visible = false;
                Image1.Visible = false;

                txt_lang.Visible = false;
                btn_add_lang.Visible = false;

                txtsel1.Visible = false;
                txtsel2.Visible = false;
                language_add();
                #endregion
            }
        }
    
    }
    private void nxtmeet(int d, int n_d)
    {
        #region NEXT APPOINTMENT
        try
        {
            // DateTime dt = System.DateTime.Now.Date;
            //DateTime dt = System.Convert.ToDateTime(txtdate.Text);
            int ptntid1 = System.Convert.ToInt32(lblptnt_id.Value);
            string ptntfor1 = "Speech Problem";
            DateTime aptdt = dt;
            for (j = d; j <= n_d; )
            {
                dt = dt.AddDays(+d);
                if (dt.DayOfWeek.ToString() == "Sunday")
                {
                    dt = dt.AddDays(+1);

                    cn.Open();
                    string ptnt_for = "select * from tbl_apointment_trn where apt_date='" + dt.ToShortDateString() + "'";
                    ds = cn.GetData(ptnt_for, "tbl_apointment_trn");
                    if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                    {
                        try
                        { ptntfor = ds.Tables["tbl_apointment_trn"].Rows[0][3].ToString(); }
                        catch {/* Response.Redirect("~/error.aspx");*/ }
                        if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                        {
                            if (ptntfor == "Function")
                            {
                            }
                            else
                            { aptdt = dt; }
                        }
                        else
                        { Response.Redirect("~/error.aspx"); }
                    }
                    else
                    {
                        aptdt = dt;
                    }
                    string cur_time = "select * from tbl_apointment_trn" +
                    @" where apt_date  ='" + System.DateTime.Now.Date + "'";

                    ds = cn.GetData(cur_time, "tbl_apointment_trn");
                    if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                    {
                        cur_time = ds.Tables["tbl_apointment_trn"].Rows[0][7].ToString();
                        string nxt_time = "select * from tbl_apointment_trn" +
                        @" where apt_date  ='" + aptdt + "'and apt_time='" + cur_time + "'";
                        ds = cn.GetData(nxt_time, "tbl_apointment_trn");

                        if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                        {
                            nxt_time = ds.Tables["tbl_apointment_trn"].Rows[0][7].ToString();
                            string time_chk = "select * from tbl_apointment_trn" +
                                 @" where apt_date  >'" + aptdt + "'order by apt_time";
                            ds = cn.GetData(time_chk, "tbl_apointment_trn");

                            if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                            {
                                if (ds.Tables["tbl_apointment_trn"].Rows.Count < 25)
                                {
                                    DataTable DT = new DataTable();
                                    DT = ds.Tables["tbl_apointment_trn"];
                                    ArrayList apt = ConvertDT(DT);
                                    string[] stringArray = new string[apt.Count];
                                    for (int count = 0; count < ds.Tables["tbl_apointment_trn"].Rows.Count; )
                                    {
                                        foreach (Object obj in apt)
                                        {
                                            stringArray[count] = ((DataRow)obj)[5].ToString();
                                            apt.Remove(obj);
                                            break;
                                        }
                                        count++;
                                    }

                                    int dif = Convert.ToInt32((adj.Length) - (stringArray.Length));
                                    int countarray = 0;
                                    string[] apt1 = new string[dif]; ;

                                    Array.Sort(stringArray);

                                    foreach (string str in adj)
                                    {
                                        if (Array.BinarySearch(stringArray, str) < 0)
                                        {
                                            for (countarray = countarray; countarray < dif; )
                                            {
                                                apt1[countarray] = str.ToString();
                                                break;
                                            }
                                            countarray++;
                                        }
                                    }
                                    apttime = ddl_apt_time.SelectedItem.Text;
                                }
                                else { nxtmeet(d + 1, n_d + 1); }
                            }
                            else
                            {
                                apttime = ddl_apt_time.SelectedItem.Text;
                            }
                        }
                        else
                        {
                            apttime = ddl_apt_time.SelectedItem.Text;
                        }
                    }
                    double aptid1 = cn.getmaxid("select max(apt_id) from tbl_apointment_trn", "tbl_apointment_trn");
                    if (aptid1 == 0) { System.Convert.ToString(aptid1 + 1); }
                    else { System.Convert.ToString(aptid1); }
                }
                else
                {
                    dt.ToShortDateString();

                    cn.Open();
                    string ptnt_for = "select * from tbl_apointment_trn where apt_date='" + dt.ToShortDateString() + "'";
                    ds = cn.GetData(ptnt_for, "tbl_apointment_trn");
                    if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                    {
                        try
                        { ptntfor = ds.Tables["tbl_apointment_trn"].Rows[0][3].ToString(); }
                        catch { Response.Redirect("~/error.aspx"); }
                        if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                        {
                            if (ptntfor == "Function")
                            {
                            }
                            else
                            { aptdt = dt; }
                        }
                        else
                        { Response.Redirect("~/error.aspx"); }
                    }
                    else
                    {
                        aptdt = dt;
                    }
                    string cur_time = "select * from tbl_apointment_trn" +
                    @" where apt_date  ='" + System.DateTime.Now.Date + "'";

                    ds = cn.GetData(cur_time, "tbl_apointment_trn");
                    if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                    {
                        cur_time = ds.Tables["tbl_apointment_trn"].Rows[0][7].ToString();
                        string nxt_time = "select * from tbl_apointment_trn" +
                        @" where apt_date  ='" + aptdt + "'and apt_time='" + cur_time + "'";
                        ds = cn.GetData(nxt_time, "tbl_apointment_trn");

                        if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                        {
                            nxt_time = ds.Tables["tbl_apointment_trn"].Rows[0][7].ToString();
                            string time_chk = "select * from tbl_apointment_trn" +
                                 @" where apt_date  >'" + aptdt + "'order by apt_time";
                            ds = cn.GetData(time_chk, "tbl_apointment_trn");

                            if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                            {
                                if (ds.Tables["tbl_apointment_trn"].Rows.Count < 25)
                                {
                                    DataTable DT = new DataTable();
                                    DT = ds.Tables["tbl_apointment_trn"];
                                    ArrayList apt = ConvertDT(DT);
                                    string[] stringArray = new string[apt.Count];
                                    for (int count = 0; count < ds.Tables["tbl_apointment_trn"].Rows.Count; )
                                    {
                                        foreach (Object obj in apt)
                                        {
                                            stringArray[count] = ((DataRow)obj)[5].ToString();
                                            apt.Remove(obj);
                                            break;
                                        }
                                        count++;
                                    }

                                    int dif = Convert.ToInt32((adj.Length) - (stringArray.Length));
                                    int countarray = 0;
                                    string[] apt1 = new string[dif]; ;

                                    Array.Sort(stringArray);

                                    foreach (string str in adj)
                                    {
                                        if (Array.BinarySearch(stringArray, str) < 0)
                                        {
                                            for (countarray = countarray; countarray < dif; )
                                            {
                                                apt1[countarray] = str.ToString();
                                                break;
                                            }
                                            countarray++;
                                        }
                                    }
                                    apttime = ddl_apt_time.SelectedItem.Text;
                                }
                                else
                                {
                                    if (ddlnxtmeet.SelectedIndex == 1)
                                    { nxtmeet(d + 7, n_d + 7); }
                                    else if (ddlnxtmeet.SelectedIndex == 2)
                                    { nxtmeet(d + 3, n_d + 3); }
                                    else if (ddlnxtmeet.SelectedIndex == 3)
                                    { nxtmeet(d + 1, n_d + 1); }
                                    else if (ddlnxtmeet.SelectedIndex == 4)
                                    { nxtmeet(d + 1, n_d + 1); }
                                    else if (ddlnxtmeet.SelectedIndex == 5)
                                    { nxtmeet(d + 30, n_d + 30); }
                                    else if (ddlnxtmeet.SelectedIndex == 6)
                                    { nxtmeet(d + 15, n_d + 15); }
                                    else if (ddlnxtmeet.SelectedIndex == 7)
                                    { nxtmeet(d + 7, n_d + 7); }
                                    else if (ddlnxtmeet.SelectedIndex == 8)
                                    { nxtmeet(d + 180, n_d + 180); }
                                    else if (ddlnxtmeet.SelectedIndex == 9)
                                    { nxtmeet(d + 365, n_d + 365); }
                                }
                            }
                            else
                            {
                                apttime = ddl_apt_time.SelectedItem.Text;
                            }
                        }
                        else
                        {
                            apttime = ddl_apt_time.SelectedItem.Text;
                        }
                        cmd = new SqlCommand("sp_appointment_insert", connection.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_ptnt_id", ptntid1);
                        cmd.Parameters.AddWithValue("@p_ptnt_for", ptntfor1);
                        cmd.Parameters.AddWithValue("@p_apt_date", aptdt);
                        cmd.Parameters.AddWithValue("@p_apt_time", apttime);
                        cmd.Parameters.AddWithValue("@p_For", ptntfor1);
                        cmd.Parameters.AddWithValue("@p_created_by", Session["Name"].ToString());
                        cn.Open();
                        cn.executeprocedure(cmd);
                        cn.Close();
                    }
                    double aptid1 = cn.getmaxid("select max(apt_id) from tbl_apointment_trn", "tbl_apointment_trn");
                    if (aptid1 == 0) { System.Convert.ToString(aptid1 + 1); }
                    else { System.Convert.ToString(aptid1); }
                }
                j = System.Convert.ToInt32(j + d);
            }
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
        #endregion
    }
    protected void Cal_SelectedDate(object sender, EventArgs e)
    {
        #region  APPOINTMENT
        try
        {
            //aptdt = System.Convert.ToDateTime(txtdate.Text);
            //dt = aptdt;

            cn.Open();
            string ptnt_for = "select * from tbl_apointment_trn where apt_date='" + dt.ToShortDateString() + "'";
            ds = cn.GetData(ptnt_for, "tbl_apointment_trn");
            if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
            {
                try
                { ptntfor = ds.Tables["tbl_apointment_trn"].Rows[0][3].ToString(); }
                catch { Response.Redirect("~/error.aspx"); }

                if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                {
                    if (ptntfor == "Function")
                    {
                        string funct = "select * from tbl_func_meet_tr" +
                             " where '" + dt + "' between fun_from_date and fun_to_date";
                        ds = cn.GetData(funct, "tbl_func_meet_tr");
                        if (ds.Tables["tbl_func_meet_tr"].Rows.Count == 0)
                        {
                            aptdt = dt;
                        }
                        else
                        {
                            try
                            { funct = ds.Tables["tbl_func_meet_tr"].Rows[0][5].ToString(); }
                            catch { Response.Redirect("~/error.aspx"); }

                            if (ds.Tables["tbl_func_meet_tr"].Rows.Count > 0)
                            {
                                dt = System.Convert.ToDateTime(ds.Tables["tbl_func_meet_tr"].Rows[0][5]);
                                aptdt = dt;
                                aptdt = aptdt.AddDays(+1);
                            }

                            else
                            { aptdt = dt; }
                        }
                    }

                    else

                    { aptdt = dt; }
                }

                else

                { Response.Redirect("~/error.aspx"); }

            }
            else
            {
                aptdt = dt;
            }
            string allapt = "select * from tbl_apointment_trn" +
            @" where apt_date  ='" + dt + "'";
            ds = cn.GetData(allapt, "tbl_apointment_trn");
            if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
            {
                allapt = ds.Tables["tbl_apointment_trn"].Rows[0][5].ToString();

                if (ds.Tables["tbl_apointment_trn"].Rows.Count < 25)
                {
                    DataTable DT = new DataTable();
                    DT = ds.Tables["tbl_apointment_trn"];
                    ArrayList apt = ConvertDT(DT);
                    string[] stringArray = new string[apt.Count];
                    for (int count = 0; count < ds.Tables["tbl_apointment_trn"].Rows.Count; )
                    {
                        foreach (Object obj in apt)
                        {
                            stringArray[count] = ((DataRow)obj)[5].ToString();
                            apt.Remove(obj);
                            break;
                        }
                        count++;
                    }
                    int dif = Convert.ToInt32((adj.Length) - (stringArray.Length));
                    int countarray = 0;
                    apt1 = new string[dif];

                    Array.Sort(stringArray);

                    foreach (string str in adj)
                    {
                        if (Array.BinarySearch(stringArray, str) < 0)
                        {
                            for (countarray = countarray; countarray < dif; )
                            {
                                apt1[countarray] = str.ToString();
                                break;
                            }
                            countarray++;
                        }
                    }
                    apt1.ToString();
                }
            }
            else
            {
                apt1 = adj;
                ddl_apt_time.DataSource = apt1;
                ddl_apt_time.DataBind();

            }
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
        #endregion
        cn.Open();
        ddl_apt_time.Items.Clear();
        //cmd = new SqlCommand("select apt_time from Time_mast where apt_time Not in (select apt_time from tbl_apointment_trn where apt_date='" + txtdate.Text + "')", connection.con);
        DataTable DT2 = new DataTable();
        dr = cmd.ExecuteReader();
        DT2.Load(dr);
        ddl_apt_time.DataSource = DT2;
        ddl_apt_time.DataTextField = "apt_time";
        ddl_apt_time.Items.Insert(0, new ListItem("Select Time", "apt_time"));
        ddl_apt_time.SelectedIndex = 0;
        ddl_apt_time.DataBind();
        dr = null;
        cn.Close();
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

            int ptntid1 = Convert.ToInt32(lblptnt_id.Value);
            //Response.Redirect("~/Clinical Forms/nxt_apts.aspx?ptnt_id=" + ptntid1 + " &Date" + txtdate.Text);
        }

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Print();
    }
    public void Print()
    {
        #region CHECK DATA
        //id1 = cn.getmaxid("Select max(s_asses_id)from tbl_as_s_l_assess", "tbl_as_s_l_assess");
        //id2 = cn.getmaxid("Select max(s_asses_id)from tbl_s_oral_peri", "tbl_s_oral_peri");
        //id3 = cn.getmaxid("Select max(s_asses_id)from tbl_s_art_vovels", "tbl_s_art_vovels");
        //id4 = cn.getmaxid("Select max(s_asses_id)from tbl_s_conso1", "tbl_s_conso1");
        //id5 = cn.getmaxid("Select max(s_asses_id)from tbl_s_conso2", "tbl_s_conso2");
        //id6 = cn.getmaxid("Select max(s_asses_id)from tbl_s_fluency", "tbl_s_fluency");

        //if (id != id1)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Speech and Language Development')</script>");
        //}
        //else if (id != id2)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Oral Motor Assesment')</script>");
        //}
        //else if (id != id3)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Articulation Vovels')</script>");
        //}
        //else if (id != id4)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Articulation Consonants 1')</script>");
        //}
        //else if (id != id5)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Articulation Consonants 2')</script>");
        //}
        //else if (id != id6)
        //{
        //    Response.Write("<script>alert ('Please Insert Values in Fluency')</script>");
        //}
        //else
        //{
        int ids = Convert.ToInt32(lblas_id.Value);
        Response.Redirect("~/speech_as_rpt.aspx?asses_id=" + ids);
        //}
        #endregion
    }
}
