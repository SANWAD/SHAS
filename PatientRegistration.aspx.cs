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
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.SqlTypes;

public partial class PatientRegistratioon : System.Web.UI.Page
{
    #region Declaration
    string[] months = { "Month", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    string[] adj ={"---SELECT---","08:00 AM","08:30 AM","09:00 AM","09:30 AM","10:00 AM", "10:30 AM", "11:00 AM","11:30 AM","12:00 PM","12:30 PM","01:00 PM","01:30 PM","02:00 PM","02:30 PM","03:00 PM",
                   "03:30 PM","04:00 PM","04:30 PM","05:00 PM","05:30 PM","06:00 PM","06:30 PM","07:00 PM","07:30 PM","08:00 PM"};
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr,dr1;
    DataSet ds;
    string[] apt1;
    string apttime;
    double id;
    DateTime dt,Birth_Dt;
    int ptnt_type;
    DataSet ds1,ds2;
    SqlDataAdapter da;
    //string pt_id = "0";
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
            #region Loading
            if (!IsPostBack)
            {                         
                cn.Open();
                ddl_ref_by.Items.Clear();
                cmd = new SqlCommand("sp_Doc_SelDoc_nm", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pCntr_id", SqlDbType.Int).Value = Convert.ToInt32(Session["Cntr_id"].ToString());
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "tbl_h_ac_master");

                DataTable DT2 = new DataTable();
                dr1 = cmd.ExecuteReader();
                DT2.Load(dr1);
                ddl_ref_by.DataSource = DT2;
                ddl_ref_by.DataValueField = "doc_id";
                ddl_ref_by.DataTextField = "doc_nm";
                ddl_ref_by.DataBind();
                ddl_ref_by.Items.Insert(0, new ListItem("Select", "doc_nm"));
                ddl_ref_by.SelectedIndex = 0;
                dr1 = null;

                ddlptnt_Type.Items.Clear();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_Ptnt_Type_ddl";
                DataTable DT1 = new DataTable();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                ddlptnt_Type.DataSource = DT1;
                ddlptnt_Type.DataValueField = "PtntypeId";
                ddlptnt_Type.DataTextField = "Ptntype";
                ddlptnt_Type.DataBind();
                ddlptnt_Type.Items.Insert(0, new ListItem("Select", "Ptntype"));
                dr = null;
                cn.Close();
                ddlptnt_Type.Focus();
                Select();
            }
            #endregion
        }
        //Button3.Enabled = false;
        }

    #region Validation
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtmobno.Text.Length >= 9 && char.IsNumber(txtmobno.Text, 0))

            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtphno.Text.Length >= 9 && char.IsNumber(txtphno.Text, 0))
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void chkenq_CheckedChanged(object sender, EventArgs e)
    {
        //if (chkenq.Checked == true)
        //{
        //    Label15.Visible = true;
        //    Label16.Visible = true;
        //    txtenq_nm.Visible = true;
        //    txtenq_rel.Visible = true;
        //}
        //else
        //{
        //    Label15.Visible = false;
        //    Label16.Visible = false;
        //    txtenq_nm.Visible = false;
        //    txtenq_rel.Visible = false;
        //}
    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtdate.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void CustomValidator3_ServerValidate1(object source, ServerValidateEventArgs args)
    {
        if (txtptnt_nm.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtdate.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtptntadd.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void CustomValidator6_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtprof.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    #endregion

    #region Date
    //public DateTime Date
    //{
    //    get { return new DateTime(Convert.ToInt32(ViewState["Year"]), Convert.ToInt32(ViewState["Month"]), Convert.ToInt32(ViewState["Day"])); }
    //    set
    //    {
    //        ViewState["Day"] = value.Day;
    //        ViewState["Month"] = value.Month;
    //        ViewState["Year"] = value.Year;
    //    }
    //}

    //public void InitList()
    //{
    //    ddlYear.Items.Clear();
    //    ddlMonth.Items.Clear();
    //    ddlDay.Items.Clear();

    //    foreach (string st in months)
    //    {
    //        ddlMonth.Items.Add(st);
    //    }
    //    for (int i = 1920; i <= 2020; i++)
    //        ddlYear.Items.Add(i.ToString());
    //    ddlYear.Items.Insert(0, "Year");

    //    for (int i = 1; i <= 31; i++)
    //        ddlDay.Items.Add(i.ToString());
    //    ddlDay.Items.Insert(0, "Day");

    //}
    #endregion

    #region Age Calculation
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
    //    //Button3.Enabled = true;  
    //    if (ddlYear.SelectedIndex > 0)
    //    {
    //        ViewState["Year"] = Convert.ToInt32(ddlYear.SelectedItem.Text);
    //    }
    //    txtdate.Text = System.Convert.ToString(ddlDay.SelectedItem.Text + "," + ddlMonth.SelectedItem.Text + "," + ddlYear.SelectedItem.Text);
    //    try
    //    {

    //        int yrd, mthd, dayd;
    //        int day1, day2, mth1, mth2, yr1, yr2;

    //        DateTime d1 = System.DateTime.Now;
    //        day1 = d1.Day;
    //        mth1 = d1.Month;
    //        yr1 = d1.Year;

    //        DateTime d2 = Convert.ToDateTime(txtdate.Text);
    //        day2 = d2.Day;
    //        mth2 = d2.Month;
    //        yr2 = d2.Year;

    //        yrd = yr2 - yr1;
    //        mthd = mth2 - mth1;
    //        dayd = day2 - day1;

    //        if (yrd < 0)
    //            yrd = 0 - yrd;
    //        if (mthd < 0)
    //            mthd = 0 - mthd;
    //        if (dayd < 0)
    //            dayd = 0 - dayd;

    //        if (yr2 <= yr1)
    //        {

    //            if (mth1 < mth2)
    //            {

    //                yrd -= 1;
    //                mthd = 12 - mthd;
    //            }
    //            if (day1 < day2)
    //            {
    //                mthd -= 1;
    //                dayd = 30 - dayd;
    //            }
    //        }

    //        lbl_age.Text = (yrd + "year" + "," + mthd + " month" + "," + dayd + " day");
    //    }
    //    catch

    //    { Response.Redirect("~/error.aspx"); }

    }
   // protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    //{
        //if (ddlMonth.SelectedIndex > 0)
        //{
        //    ViewState["Month"] = ddlMonth.SelectedIndex;
        //}
    //}
    //protected void ddlDay_SelectedIndexChanged(object sender, EventArgs e)
    //{
        //if (ddlDay.SelectedIndex > 0)
        //{
        //    ViewState["Day"] = ddlDay.SelectedIndex;
        //}
    //}
    #endregion
   
    public void Select()
    {
        #region Select
        if (Request.QueryString["ptnt_id"].ToString() != "0")
        {            
            try
            {
                string id1;
                id1 = (Request.QueryString["ptnt_id"].ToString());
                double ptnt_id = System.Convert.ToInt32(id1);
                cn.Open();
                cmd = new SqlCommand("tbl_ptn_mast_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                cn.Open();
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lblptnt_id.Value = DT1.Rows[0][0].ToString();
                ddlptnt_Type.SelectedValue = (DT1.Rows[0][2].ToString());
                txtptnt_nm.Text = DT1.Rows[0][3].ToString();
                txtdate.Text = DT1.Rows[0][4].ToString();
                Label5.Visible = true;
                lbl_age.Visible = true;
                lbl_age.Text = DT1.Rows[0][5].ToString();
                //txt_age.Text = DT1.Rows[0][5].ToString();
                txtprof.Text = DT1.Rows[0][7].ToString();
                txtptntadd.Text = DT1.Rows[0][8].ToString();
                txtmobno.Text = DT1.Rows[0][9].ToString();
                txtphno.Text = DT1.Rows[0][10].ToString();
                txtBrief.Text = DT1.Rows[0][14].ToString();
                ddl_ref_by.SelectedValue = DT1.Rows[0][11].ToString();
                string Gender = RemoveAllWhitespace(DT1.Rows[0][6].ToString());
                if (Gender == "Male")
                {
                    rdbtngender.SelectedIndex = 0;
                }
                else
                {
                    rdbtngender.SelectedIndex = 1;
                }
                string VIP = RemoveAllWhitespace(DT1.Rows[0][20].ToString());
                if (VIP == "VIP")
                {
                    rbtVIP.SelectedIndex = 1;
                }
                else if (Gender == "V VIP")
                {
                    rbtVIP.SelectedIndex = 2;
                }
                else
                {
                    rbtVIP.SelectedIndex = 0;
                }
                ShowImage(); 
                // txtRef.Text = DT1.Rows[0][11].ToString();
                dr = null;
                cn.Close();
                btnsave.Text = "Edit";
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
            }
        }
        #endregion
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if(btnsave.Text=="Edit")
        {
            #region Edit
            try
            {
                string nm = txtptnt_nm.Text.ToUpper();
                string time;
                // int ptnt_type;
                DateTime dat;
                double mob;
                double tel;
                double def = 0;
                if ((txtmobno.Text == "") || (txtphno.Text == ""))
                {
                    mob = (def);
                    tel = (def);
                }
                else
                {
                    mob = System.Convert.ToDouble(txtmobno.Text);
                    tel = System.Convert.ToDouble(txtphno.Text);
                }               
                int ptnt_id = Convert.ToInt32(lblptnt_id.Value);
                ptnt_type = Convert.ToInt32(ddlptnt_Type.SelectedValue);
                string dob = txtdate.Text.ToString();
                Label15.Visible = true;
                lbl_age.Visible = true;
                //string age = lbl_age.Text.ToString();
                string age = txt_age.Text.ToString();
                string gen = rdbtngender.SelectedItem.Text.ToString();
                string prof = txtprof.Text.ToString();
                string add = txtptntadd.Text.ToString();
                string ref_by = ddl_ref_by.SelectedValue;
                string VIP = rbtVIP.SelectedItem.Text.ToString();
                //string enq_nm = txtenq_nm.Text;
                //string enq_rel = txtenq_rel.Text;                
                string BriefHist = txtBrief.Text;               
                int cr_by = Convert.ToInt32(Session["Name"].ToString());
                int Center_Id = Convert.ToInt32(Session["Cntr_id"].ToString());
                string Flag = "E";
                
                cn.Open();
                cmd = new SqlCommand("tbl_ptn_master_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                //cmd.Parameters.AddWithValue("@pptnt_Code", ptnt_Code);
                cmd.Parameters.AddWithValue("@pPtntypeId", ptnt_type);
                cmd.Parameters.AddWithValue("@pptnt_nm", nm);
                cmd.Parameters.AddWithValue("@pptnt_dob", dob);
                cmd.Parameters.AddWithValue("@pptnt_age", age);
                cmd.Parameters.AddWithValue("@pptnt_gender", gen);
                cmd.Parameters.AddWithValue("@pptnt_prof", prof);
                cmd.Parameters.AddWithValue("@pptnt_add", add);
                cmd.Parameters.AddWithValue("@pptnt_mob", mob);
                cmd.Parameters.AddWithValue("@pVIP", VIP);
                cmd.Parameters.AddWithValue("@pptnt_cont_no", tel);
                cmd.Parameters.AddWithValue("@prefered_by", ref_by);
                //cmd.Parameters.AddWithValue("@pptnt_enq_nm", enq_nm);
                //cmd.Parameters.AddWithValue("@pptnt_enq_rel", enq_rel);
                cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                cmd.Parameters.AddWithValue("@pptnt_Brief", BriefHist);
                cmd.Parameters.AddWithValue("@pCntr_id", Center_Id);
                cn.executeprocedure(cmd);
                cn.Close();
                if (uploadphoto.HasFile)
                {
                    string id1 = lblptnt_id.Value;
                    string qry = "select * from tbl_ptnt_image" + @" where ptnt_id='" + id1 + "' ";
                    ds1 = cn.GetData(qry, "tbl_ptnt_image");

                    if (ds1.Tables["tbl_ptnt_image"].Rows.Count == 0)
                    {
                        ImageU();
                        ShowImage();
                        UpdateScanCopy2(Convert.ToInt32(lblptnt_id.Value));
                        Image1.Visible = false;
                        Image2.Visible = false;
                    }
                    else
                    {
                        ImageUpdate();
                        UpdateScanCopy2(Convert.ToInt32(lblptnt_id.Value));
                        ShowImage();
                        Image1.Visible = true;
                        Image2.Visible = true;
                    }
                    Response.Write("<script language='JavaScript'>alert('Record is Update Succesfuly')</script>");
                }
                else
                {
                    Response.Write("<script>alert(' Patient Registered Without Photo')</script>)");
                }
                if (uploadBackHist.HasFile)
                {
                    string id1 = lblptnt_id.Value;
                    string qry1 = "select * from tbl_ptnt_Hist_image" + @" where ptnt_id='" + id1 + "' ";
                    ds2 = cn.GetData(qry1, "tbl_ptnt_Hist_image");

                    if (ds2.Tables["tbl_ptnt_Hist_image"].Rows.Count == 0 )
                    {
                        UpdateScanCopy2(Convert.ToInt32(lblptnt_id.Value));
                        Image2.Visible = false;
                    }
                    else
                    {
                        UpdateScanCopy2(Convert.ToInt32(lblptnt_id.Value));
                        ShowImage();
                        Image2.Visible = true;
                    }
                    Response.Write("<script language='JavaScript'>alert('Record is Update Succesfuly')</script>");
                }
                else
                {
                    Response.Write("<script>alert(' Patient Registered Without Photo')</script>)");
                }
                Response.Redirect("PtntList_Grid.aspx");
                // btnsave.Enabled = false;
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
            }
            #endregion
        }
        else
        {
            DateTime dt = System.DateTime.Now.Date;
            if (ddlptnt_Type.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Please Check Patient Type!!')</script>");
            }
            else
            {
                string nm = txtptnt_nm.Text.ToUpper();
                string time;
                // int ptnt_type;
                DateTime dat;
                double mob;
                double tel;
                double def = 0;
                if ((txtmobno.Text == "") || (txtphno.Text == ""))
                {
                    mob = (def);
                    tel = (def);
                }
                else
                {
                    mob = System.Convert.ToDouble(txtmobno.Text);
                    tel = System.Convert.ToDouble(txtphno.Text);
                }
            //string ptnt_nm =txtptnt_nm.Text;
            //string ptnt_Dob = txtdate.Text;
            //cmd = new SqlCommand("sp_Patient_Check", connection.con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@ptnt_nm", ptnt_nm);
            //cmd.Parameters.AddWithValue("@dob_dt", ptnt_Dob);
            //cn.executeprocedure(cmd);
            //da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds, "tbl_machine_master");
                string check = ("select * from tbl_ptn_master " + @" where ptnt_nm='" + nm + "' and ptnt_dob='" + txtdate.Text + "' ");
                ds = cn.GetData(check, "tbl_ptn_master");
                if (ds.Tables["tbl_ptn_master"].Rows.Count > 0)
                {
                    Response.Write("<script>alert('Patient Already Registered') </script>");
                    lblMsg.Visible = true;
                }
                else
                {
                    #region Save
                    try
                    {                        
                        int ptnt_id = 0;
                        //string ptnt_Code = "K0001";
                        ptnt_type = Convert.ToInt32(ddlptnt_Type.SelectedValue);
                        string dob = txtdate.Text.ToString();
                        string age = lbl_age.Text.ToString();
                        //string age = txt_age.Text.ToString();
                        string gen = rdbtngender.SelectedItem.Text.ToString();
                        string prof = txtprof.Text.ToString();
                        string add = txtptntadd.Text.ToString();
                        string ref_by = ddl_ref_by.SelectedValue;
                        string VIP = rbtVIP.SelectedItem.Text.ToString();
                        //string enq_nm = txtenq_nm.Text;
                        //string enq_rel = txtenq_rel.Text;
                        string BriefHist = txtBrief.Text;
                        int Center_Id = Convert.ToInt32(Session["Cntr_id"].ToString());
                        int cr_by = Convert.ToInt32(Session["Name"].ToString());
                        string Flag = "I";
                        cn.Open();
                        cmd = new SqlCommand("tbl_ptn_master_c", connection.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pFlag", Flag);
                        cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
                        //cmd.Parameters.AddWithValue("@pptnt_Code", ptnt_Code);
                        cmd.Parameters.AddWithValue("@pPtntypeId", ptnt_type);
                        cmd.Parameters.AddWithValue("@pptnt_nm", nm);
                        cmd.Parameters.AddWithValue("@pptnt_dob", dob);
                        cmd.Parameters.AddWithValue("@pptnt_age", age);
                        cmd.Parameters.AddWithValue("@pptnt_gender", gen);
                        cmd.Parameters.AddWithValue("@pptnt_prof", prof);
                        cmd.Parameters.AddWithValue("@pptnt_add", add);
                        cmd.Parameters.AddWithValue("@pptnt_mob", mob);
                        cmd.Parameters.AddWithValue("@pVIP", VIP);
                        cmd.Parameters.AddWithValue("@pptnt_cont_no", tel);
                        cmd.Parameters.AddWithValue("@prefered_by", ref_by);
                       // cmd.Parameters.AddWithValue("@pptnt_enq_nm", enq_nm);
                        //cmd.Parameters.AddWithValue("@pptnt_enq_rel", enq_rel);
                        cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
                        cmd.Parameters.AddWithValue("@pptnt_Brief", BriefHist);
                        cmd.Parameters.AddWithValue("@pCntr_id", Center_Id);
                        //cn.executeprocedure(cmd);
                        int a = cn.executeprocedure(cmd);
                        lblptnt_id.Value = (a.ToString());
                        cn.Close();
                        if (uploadphoto.HasFile)
                        {
                            Image();
                            UpdateScanCopy2(Convert.ToInt32(lblptnt_id.Value));
                            Response.Write("<script>alert(' Patient Registered With Photo')</script>)");
                            ShowImage();
                        }
                        else
                        {
                            Response.Write("<script>alert(' Patient Registered Without Photo')</script>)");
                            Response.Write("<script language='JavaScript'>alert('Record is Save Succesfuly')</script>");                            
                        }
                       // Response.Redirect("PtntList_Grid.aspx");
                        btnsave.Enabled = false;
                    }
                    catch
                    {
                        Response.Write("<script language='JavaScript'>alert('Record is Not Save')</script>");
                        //Response.Redirect("~/error.aspx");
                    }
                    #endregion
                }
      
        //        #region Telephonic Appointment Auto Allocation
        //        string tel_apt = ("select * from tbl_telephonic_apt_master " +
        //                             @" where t_apt_ptnt_nm='" + nm + "'");

        //        ds = cn.GetData(tel_apt, "tbl_telephonic_apt_master");
        //        if (ds.Tables["tbl_telephonic_apt_master"].Rows.Count > 0)
        //        {

        //            DateTime curdate = System.DateTime.Now.Date;
        //            cmd = new SqlCommand("sp_tel_apt_select", connection.con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@p_t_apt_ptnt_nm", nm);
        //            cmd.Parameters.AddWithValue("@p_apt_date", curdate);
        //            cn.Open();
        //            cn.executeprocedure(cmd);
        //            DataTable DTtime = new DataTable();
        //            cn.Open();
        //            dr = cmd.ExecuteReader();
        //            DTtime.Load(dr);
        //            int apttel;
        //            apttel = Convert.ToInt32(DTtime.Rows[0][1].ToString());
        //            ptnt_type = DTtime.Rows[0][2].ToString();
        //            dat = System.DateTime.Now.Date;
        //            time = DTtime.Rows[0][5].ToString();
        //            dr = null;
        //            cn.Close();
        //            int ptn_id = Convert.ToInt32(lblptnt_id.Text);
        //            apt_sp(ptn_id, ptnt_type, dat, time);



        //            cmd = new SqlCommand("sp_del_tel_apt", connection.con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@p_t_apt_id", apttel);
        //            cmd.Parameters.AddWithValue("@p_apt_date", dat);
        //            cmd.Parameters.AddWithValue("@p_apt_time", time);
        //            cmd.Parameters.AddWithValue("@p_revised_by", Session["Name"].ToString());
        //            cn.Open();
        //            cn.executeprocedure(cmd);
        //            cn.Close();

        //        }
        //        #endregion
        //        if (chk_apt.Checked == true)
        //        {
        //            #region Appointment

        //            string allapt = "select * from tbl_apointment_trn" +
        //          @" where apt_date  ='" + dt + "'";
        //            ds = cn.GetData(allapt, "tbl_apointment_trn");
        //            if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //            {
        //                allapt = ds.Tables["tbl_apointment_trn"].Rows[0][5].ToString();

        //                if (ds.Tables["tbl_apointment_trn"].Rows.Count < 25)
        //                {
        //                    DataTable DT = new DataTable();
        //                    DT = ds.Tables["tbl_apointment_trn"];
        //                    ArrayList apt = ConvertDT(DT);
        //                    string[] stringArray = new string[apt.Count];
        //                    for (int count = 0; count < ds.Tables["tbl_apointment_trn"].Rows.Count; )
        //                    {
        //                        foreach (Object obj in apt)
        //                        {
        //                            stringArray[count] = ((DataRow)obj)[5].ToString();
        //                            apt.Remove(obj);
        //                            break;
        //                        }
        //                        count++;
        //                    }
        //                    int dif = Convert.ToInt32((adj.Length) - (stringArray.Length));
        //                    int countarray = 0;
        //                    apt1 = new string[dif];

        //                    Array.Sort(stringArray);

        //                    foreach (string str in adj)
        //                    {
        //                        if (Array.BinarySearch(stringArray, str) < 0)
        //                        {
        //                            for (countarray = countarray; countarray < dif; )
        //                            {
        //                                apt1[countarray] = str.ToString();
        //                                break;
        //                            }
        //                            countarray++;
        //                        }
        //                    }
        //                    apt1.ToString();
        //                }
        //            }
        //            else
        //            {
        //                apt1 = adj;
        //            }


        //            string alltelapt = "select * from tbl_telephonic_apt_master" +
        //                @" where apt_date  ='" + dt + "'";
        //            ds = cn.GetData(alltelapt, "tbl_telephonic_apt_master");
        //            if (ds.Tables["tbl_telephonic_apt_master"].Rows.Count > 0)
        //            {
        //                alltelapt = ds.Tables["tbl_telephonic_apt_master"].Rows[0][5].ToString();

        //                if (ds.Tables["tbl_telephonic_apt_master"].Rows.Count < 25)
        //                {
        //                    DataTable DT1 = new DataTable();
        //                    DT1 = ds.Tables["tbl_telephonic_apt_master"];
        //                    ArrayList apt2 = ConvertDT(DT1);
        //                    string[] stringArray1 = new string[apt2.Count];
        //                    for (int count1 = 0; count1 < ds.Tables["tbl_telephonic_apt_master"].Rows.Count; )
        //                    {
        //                        foreach (Object obj in apt2)
        //                        {
        //                            stringArray1[count1] = ((DataRow)obj)[5].ToString();
        //                            apt2.Remove(obj);
        //                            break;
        //                        }
        //                        count1++;
        //                    }
        //                    int dif = Convert.ToInt32((apt1.Length) - (stringArray1.Length));
        //                    int countarray1 = 0;
        //                    string[] apt3 = new string[dif]; ;

        //                    Array.Sort(stringArray1);

        //                    foreach (string str1 in apt1)
        //                    {
        //                        if (Array.BinarySearch(stringArray1, str1) < 0)
        //                        {
        //                            for (countarray1 = countarray1; countarray1 < dif; )
        //                            {
        //                                apt3[countarray1] = str1.ToString();
        //                                break;
        //                            }
        //                            countarray1++;
        //                        }
        //                    }

        //                    apttime = apt3[1];
        //                }
        //            }
        //            else
        //            {
        //                apttime = apt1[1];
        //            }

        //            int ptntid = Convert.ToInt32(lblptnt_id.Text);
        //            string ptntfor = ddlptnt_type.SelectedItem.Text;
        //            DateTime aptdt = dt;
        //            string apttime1 = apttime.ToString();
        //            string createdby = Session["Name"].ToString();

        //            cmd = new SqlCommand("sp_appointment_insert", connection.con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@p_ptnt_id", ptntid);
        //            cmd.Parameters.AddWithValue("@p_ptnt_for", ptntfor);
        //            cmd.Parameters.AddWithValue("@p_apt_date", aptdt);
        //            cmd.Parameters.AddWithValue("@p_apt_time", apttime1);
        //            cmd.Parameters.AddWithValue("@p_created_by", Session["Name"].ToString());
        //            cn.Open();
        //            cn.executeprocedure(cmd);
        //            Response.Write("<script language='JavaScript'>alert('Appointment Date & Time Is " + aptdt + " , " + apttime + " ')</script>");
        //            cn.Close();

        //            ddlptnt_type.SelectedIndex = 0;
        //            //txtptnt_nm.Text = "";
        //            txtdate.Text = "";
        //            lbl_age.Text = "";
        //            rdbtngender.SelectedIndex = -1;
        //            txtprof.Text = "";
        //            txtptntadd.Text = "";
        //            ddl_ref_by.SelectedIndex = 0;
        //            txtenq_nm.Text = "";
        //            txtenq_rel.Text = "";
        //            txtmobno.Text = "";
        //            txtphno.Text = "";
        //            #endregion
        //        }
          }
        }
    }
    public ArrayList ConvertDT(DataTable data)
    {
        ArrayList converted = new ArrayList(data.Rows.Count);
        foreach (DataRow row in data.Rows)
        {
            converted.Add(row).ToString();
            converted.ToArray().ToString();
        }
        return converted;
    }

    public void Image()
    {
        #region Image
        try
        {
            FileUpload img = (FileUpload)uploadphoto;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                HttpPostedFile File = uploadphoto.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            cn.Open();
            string qry = "insert into tbl_ptnt_image values(@p_ptnt_id,@p_p_ptnt_image)";
            cmd = connection.con.CreateCommand();
            cmd.CommandText = qry;
            cmd.Parameters.AddWithValue("@p_ptnt_id", lblptnt_id.Value);
            cmd.Parameters.AddWithValue("@p_p_ptnt_image", imgByte);
            cmd.ExecuteNonQuery();
            double id = Convert.ToDouble(lblptnt_id.Value);

            Image1.ImageUrl = "~/ShowImage.ashx?id=" + id;
        }
        catch
        {
            //Response.Redirect("~/error.aspx");

        }
        finally
        {
            cn.Close();
        }
        #endregion

        #region Image1
        try
        {
            FileUpload img = (FileUpload)uploadBackHist;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                HttpPostedFile File = uploadBackHist.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            cn.Open();
            string qry = "insert into tbl_ptnt_Hist_image values(@p_ptnt_id,@p_p_ptnt_image)";
            cmd = connection.con.CreateCommand();
            cmd.CommandText = qry;
            cmd.Parameters.AddWithValue("@p_ptnt_id", lblptnt_id.Value);
            cmd.Parameters.AddWithValue("@p_p_ptnt_image", imgByte);
            cmd.ExecuteNonQuery();
            double id = Convert.ToDouble(lblptnt_id.Value);

            Image2.ImageUrl = "~/ShowImage.ashx?id=" + id;
        }
        catch
        {
            //Response.Redirect("~/error.aspx");

        }
        finally
        {
            cn.Close();
        }
        #endregion
    }
    public void apt_sp(int id, string ptntfor, DateTime aptdt, string apttime)
    {
        #region Function Save
        cmd = new SqlCommand("sp_appointment_insert", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@p_ptnt_id", id);
        cmd.Parameters.AddWithValue("@p_ptnt_for", ptntfor);
        cmd.Parameters.AddWithValue("@p_apt_date", aptdt);
        cmd.Parameters.AddWithValue("@p_apt_time", apttime);
        cmd.Parameters.AddWithValue("@p_created_by", Session["Name"].ToString());
        cn.Open();
        cn.executeprocedure(cmd);
        Response.Write("<script language='JavaScript'>alert('Appointment Date & Time Is " + aptdt + " , " + apttime + " ')</script>");
        cn.Close();
        #endregion
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Master/Doctor master.aspx");
    }   
    public void ShowImage()
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

            string qry1 = "select * from tbl_ptnt_Hist_image" +
                                     @" where ptnt_id='" + id + "' ";
            ds2 = cn.GetData(qry1, "tbl_ptnt_Hist_image");

            if (ds2.Tables["tbl_ptnt_Hist_image"].Rows.Count == 0)
            {
                Image2.Visible = false;
            }
            else
            {
                qry1 = ds2.Tables["tbl_ptnt_Hist_image"].Rows[0][0].ToString();
                if (ds2.Tables["tbl_ptnt_Hist_image"].Rows.Count > 0)
                {
                    string Ext = ds2.Tables["tbl_ptnt_Hist_image"].Rows[0][3].ToString();
                    Image2.ImageUrl = "~/ShowImageHistory.ashx?id=" + id + "&Ext=" + Ext; 
                    HyperLink3.NavigateUrl = "~/ShowImageHistory.ashx?id=" + lblptnt_id.Value + "&Ext=" + Ext;
                    Image2.Visible = true;
                }
            }
        }
        catch
        {
            //Response.Redirect("~/error.aspx");

        }
        #endregion
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        #region Update
        //try
        //{
        //    double mob;
        //    double tel;
        //    double def = 0;
        //    if ((txtmobno.Text == "") || (txtphno.Text == ""))
        //    {
        //        mob = (def);
        //        tel = (def);
        //    }
        //    else
        //    {
        //        mob = System.Convert.ToDouble(txtmobno.Text);
        //        tel = System.Convert.ToDouble(txtphno.Text);
        //    }
        //    int ptnt_id = System.Convert.ToInt32(lblPtnid.Text);
        //    string type = ddlptnt_type.SelectedItem.Text.ToString();
        //    string nm = txtptnt_nm.Text.ToString();
        //    string dob = txtdate.Text.ToString();
        //    string age = lbl_age.Text.ToString();
        //    string gen = rdbtngender.SelectedItem.Text.ToString();
        //    string prof = txtprof.Text.ToString();
        //    string add = txtptntadd.Text.ToString();
        //    string ref_by = ddl_ref_by.SelectedItem.Text;
        //    string enq_nm = txtenq_nm.Text;
        //    string enq_rel = txtenq_rel.Text;
        //    string cr_by = Session["Name"].ToString();
        //    string BriefHist = txtBrief.Text;
        //    //string Image = Image1.ImageUrl;
        //    cn.Open();
        //    cmd = new SqlCommand("sp_new_ptnt_regiUpdate", connection.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@p_ptnt_id", ptnt_id);
        //    cmd.Parameters.AddWithValue("@p_ptnt_typ", type);
        //    cmd.Parameters.AddWithValue("@p_ptnt_nm", nm);
        //    cmd.Parameters.AddWithValue("@p_ptnt_dob", dob);
        //    cmd.Parameters.AddWithValue("@p_ptnt_age", age);
        //    cmd.Parameters.AddWithValue("@p_ptnt_gender", gen);
        //    cmd.Parameters.AddWithValue("@p_ptnt_prof", prof);
        //    cmd.Parameters.AddWithValue("@p_ptnt_add", add);
        //    cmd.Parameters.AddWithValue("@p_ptnt_mob", mob);
        //    cmd.Parameters.AddWithValue("@p_ptnt_cont_no", tel);
        //    cmd.Parameters.AddWithValue("@p_refered_by", ref_by);
        //    cmd.Parameters.AddWithValue("@p_ptnt_enq_nm", enq_nm);
        //    cmd.Parameters.AddWithValue("@p_ptnt_enq_rel", enq_rel);
        //    cmd.Parameters.AddWithValue("@p_ptnt_Brief", BriefHist);
        //    cmd.Parameters.AddWithValue("@p_created_by", cr_by);
        //    cn.executeprocedure(cmd);
        //    cn.Close();
        //    if (uploadphoto.HasFile)
        //    {
        //        string id1 = lblPtnid.Text;
        //        string qry = "select * from tbl_ptnt_image" +
        //                             @" where ptnt_id='" + id1 + "' ";
        //        ds1 = cn.GetData(qry, "tbl_ptnt_image");

        //        if (ds1.Tables["tbl_ptnt_image"].Rows.Count == 0)
        //        {
        //            ImageU();
        //            ShowImage1();
        //            Image1.Visible = false;
        //        }
        //        else
        //        {
        //            ImageUpdate();
        //            ShowImage1();
        //            Image1.Visible = true;
        //        }
        //        Button4.Visible = true;
        //        //Response.Write("<script>alert(' Patient Registered With Photo')</script>)");
        //        Response.Write("<script language='JavaScript'>alert('Record is Update Succesfuly')</script>");
        //    }
        //    else
        //    {
        //        //Response.Write("<script>alert(' Patient Registered Without Photo')</script>)");
        //        Response.Write("<script language='JavaScript'>alert('Record is Update Succesfuly')</script>");
        //    }
        //}
        //catch
        //{
        //    Response.Write("<script language='JavaScript'>alert('Record is Not Update')</script>");
        //    //Response.Redirect("~/error.aspx");
        //}
        #endregion
    }
    public void ImageUpdate()
    {
        #region Image
        try
        {
            FileUpload img = (FileUpload)uploadphoto;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                HttpPostedFile File = uploadphoto.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            cn.Open();
            string qry = "update tbl_ptnt_image set p_ptnt_image=@p_p_ptnt_image where ptnt_id=@p_ptnt_id";
            cmd = connection.con.CreateCommand();
            cmd.CommandText = qry;
            cmd.Parameters.AddWithValue("@p_ptnt_id", lblptnt_id.Value);
            cmd.Parameters.AddWithValue("@p_p_ptnt_image", imgByte);
            cmd.ExecuteNonQuery();
            double id = Convert.ToDouble(lblptnt_id.Value);
            Image1.ImageUrl = "~/ShowImage.ashx?id=" + id;
            cn.Close();

        }
        catch
        {
            Response.Redirect("~/error.aspx");

        }
        finally
        {
            cn.Close();
        }
        #endregion
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
    protected void btnBill_Click(object sender, EventArgs e)
    {
        string qry = "select Ptnt_id from tbl_ptn_master where ptnt_nm='" + txtptnt_nm.Text + "' ";
        ds1 = cn.GetData(qry, "tbl_ptn_master");
        string user_type = ds1.Tables["tbl_ptn_master"].Rows[0][0].ToString();
        double Pid = Convert.ToInt32(user_type);
        // Response.Redirect("~/Reception Forms/Appointments.aspx?id=" + Pid + " &nm=" + txtptnt_nm.Text);
        //Response.Redirect("~/bill/bill.aspx?id=" + lblPtnid.Text + " &nm=" + txtptnt_nm.Text + " &add" + txtptntadd.Text);
        Response.Redirect("~/bill.aspx?id=" + Pid + " &nm=" + txtptnt_nm.Text + " &add" + txtptntadd.Text);
    }
    protected void btnApt_Click(object sender, EventArgs e)
    {
       // string qry = "select Ptnt_id from tbl_ptn_master where ptnt_nm='" + txtptnt_nm.Text + "' ";
        //ds1 = cn.GetData(qry, "tbl_ptn_master");
        //string user_type = ds1.Tables["tbl_ptn_master"].Rows[0][0].ToString();

        //double Pid = Convert.ToInt32(lblptnt_id.Value);
        //Response.Redirect("~/Appointments.aspx?id=" + Pid + " &nm=" + txtptnt_nm.Text);
        Session["Appo_Id"] = 0;
        Session["ptnt_id"] = lblptnt_id.Value;
        Response.Redirect("~/Appointments.aspx");
    }
    protected void btnHst_Click(object sender, EventArgs e)
    {
       // int bill = Convert.ToInt32(lblPtnid.Text);
       // Response.Redirect("~/Transaction/Ptnt_Dtl_rpt.aspx?bill_no=" + bill);
    }
    protected void btnMHst_Click(object sender, EventArgs e)
    {
       // int bill = Convert.ToInt32(lblPtnid.Text);
       // Response.Redirect("~/Transaction/Ptnt_MDtl_rpt.aspx?bill_no=" + bill);
    }
    protected void btnApt1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Reception Forms/Appointments.aspx?id=" + lblptnt_id.Value + " &nm=" + txtptnt_nm.Text);
    }

    public void ImageU()
    {
        #region Image
        try
        {
            FileUpload img = (FileUpload)uploadphoto;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                HttpPostedFile File = uploadphoto.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            cn.Open();
            string qry = "insert into tbl_ptnt_image values(@p_ptnt_id,@p_p_ptnt_image)";
            cmd = connection.con.CreateCommand();
            cmd.CommandText = qry;
            cmd.Parameters.AddWithValue("@p_ptnt_id", lblptnt_id.Value);
            cmd.Parameters.AddWithValue("@p_p_ptnt_image", imgByte);
            cmd.ExecuteNonQuery();
            double id = Convert.ToDouble(lblptnt_id.Value);
            Image1.ImageUrl = "~/ShowImage.ashx?id=" + id;
        }
        catch
        {
            Response.Redirect("~/error.aspx");

        }
        finally
        {
            cn.Close();
        }
        #endregion
    }
   
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PtntList_Grid.aspx");
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        //if (txtdate.Text == "")
        //{
        //    dt = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
        //    Birth_Dt = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);
        //    string Year = Convert.ToString((dt.Year) - (Birth_Dt.Year));
        //    string Month = Convert.ToString((dt.Month) - (Birth_Dt.Month));
        //    string Days = Convert.ToString((dt.Day) - (Birth_Dt.Day));
        //    string Cal_Age = (Year + " Year" + ',' + Month + " Month" + ',' + Days + " Days");
        //    //string Cal_Age= Convert.ToString((dt.Year) - (Birth_Dt.Year));
        //    lbl_age.Visible = true;
        //    lbl_age.Text = Cal_Age;
        //    Label5.Visible = true;
        //}
    }
    protected void txtptnt_nm_TextChanged(object sender, EventArgs e)
    {
        #region Patient Name Exists
        string Ptnt_nm = txtptnt_nm.Text.Trim();
        int Center_Id = Convert.ToInt32(Session["Cntr_id"].ToString());

        cmd = new SqlCommand("sp_Ptnt_Id_Search", connection.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ph_Ptn_name", Ptnt_nm);
        cmd.Parameters.AddWithValue("@pCntr_id", Center_Id);

        cn.executeprocedure(cmd);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "tbl_ptn_master");
        if (ds.Tables["tbl_ptn_master"].Rows.Count > 0)
        {
            lblMsg.Visible = true;
            btnsave.Enabled = false;
        }
        else
        {
            lblMsg.Visible = false;
            btnsave.Enabled = true;
        }
        #endregion
    }
    private void UpdateScanCopy2(int ptnt_id)
    {
        int Doc_No = Convert.ToInt32(lblptnt_id.Value);
        if (uploadBackHist.FileName != "")
        {
            FileUpload img = (FileUpload)uploadBackHist;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = uploadBackHist.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            string Ext = "";
            if (uploadBackHist.FileName.EndsWith(".pdf") || uploadBackHist.FileName.EndsWith(".PDF"))
            {
                Ext = ".pdf";
            }
            else
            {
                if (uploadBackHist.FileName.EndsWith(".png") || uploadBackHist.FileName.EndsWith(".jpeg") || uploadBackHist.FileName.EndsWith(".jpg") || uploadBackHist.FileName.EndsWith(".PNG") || uploadBackHist.FileName.EndsWith(".JPEG") || uploadBackHist.FileName.EndsWith(".JPG"))
                {
                    Ext = ".jpeg";
                }
                else
                {
                    if (uploadBackHist.FileName.EndsWith(".gif") || uploadBackHist.FileName.EndsWith(".GIF"))
                    {
                        Ext = ".gif";
                    }
                    else
                    {
                        if (uploadBackHist.FileName.EndsWith(".xls") || uploadBackHist.FileName.EndsWith(".XLS"))
                        {
                            Ext = ".xls";
                        }
                        else
                        {
                            if (uploadBackHist.FileName.EndsWith(".doc") || uploadBackHist.FileName.EndsWith(".docx") || uploadBackHist.FileName.EndsWith(".DOC") || uploadBackHist.FileName.EndsWith(".DOCX"))
                            {
                                Ext = ".docx";
                            }
                            else
                            {
                                goto l;
                            }
                        }
                    }
                }
            }
            if (imgByte != null)
            {
                if (btnsave.Text == "Save")
                {
                    string sql11 = "insert into tbl_ptnt_Hist_image(ptnt_id,p_Hist_image,EXT) values(@pptnt_id,@Eimg,@Ext)";
                    String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
                    SqlConnection con = new SqlConnection(strConnString);
                    con.Open();
                    SqlCommand cmd11 = new SqlCommand(sql11, con);
                    cmd11.Parameters.AddWithValue("@pptnt_id", Doc_No);
                    cmd11.Parameters.AddWithValue("@Eimg", imgByte);
                    cmd11.Parameters.AddWithValue("@Ext", Ext);
                    cmd11.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    string id1 = lblptnt_id.Value;
                    string qry1 = "select * from tbl_ptnt_Hist_image" + @" where ptnt_id='" + id1 + "' ";
                    ds2 = cn.GetData(qry1, "tbl_ptnt_Hist_image");
                    if (ds2.Tables["tbl_ptnt_Hist_image"].Rows.Count == 0)
                    {
                        string sql11 = "insert into tbl_ptnt_Hist_image(ptnt_id,p_Hist_image,EXT) values(@pptnt_id,@Eimg,@Ext)";
                        String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
                        SqlConnection con = new SqlConnection(strConnString);
                        con.Open();
                        SqlCommand cmd11 = new SqlCommand(sql11, con);
                        cmd11.Parameters.AddWithValue("@pptnt_id", Doc_No);
                        cmd11.Parameters.AddWithValue("@Eimg", imgByte);
                        cmd11.Parameters.AddWithValue("@Ext", Ext);
                        cmd11.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        string sql11 = "UPDATE tbl_ptnt_Hist_image SET p_Hist_image = @Eimg, EXT='" + Ext + "' WHERE ptnt_id=" + Doc_No;
                        String strConnString = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
                        SqlConnection con = new SqlConnection(strConnString);
                        con.Open();
                        SqlCommand cmd11 = new SqlCommand(sql11, con);
                        cmd11.Parameters.AddWithValue("@Eimg", imgByte);
                        cmd11.ExecuteNonQuery();
                        con.Close();
                    }
                    
                }

            }
        }
    l: { }
    }
    protected void txtdate_TextChanged1(object sender, EventArgs e)
    {
        //txt_age.Text = lbl_age.Text;
    }
}
