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

public partial class s_digno : System.Web.UI.Page
{
    #region Declaration
    string[] Language = { "English", "Marathi", "Hindi", "Sindhi", "Gujrati", "Kanada", "Tamil", "Telagu", "Urdu", "Bhojpuri", "Rajasthani", "Punjabi", "Bangali" };
    string[] adj ={"08:00 AM","08:30 AM","09:00 AM","09:30 AM","10:00 AM", "10:30 AM","11:00 AM","11:30 AM","12:00 PM","12:30 PM","01:00 PM","01:30 PM","02:00 PM","02:30 PM","03:00 PM",
                   "03:30 PM","04:00 PM","04:30 PM","05:00 PM","05:30 PM","06:00 PM","06:30 PM","07:00 PM","07:30 PM","08:00 PM"};
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    DataSet ds, ds1;
    SqlDataAdapter da;
    int j;
    string apttime, ptntfor;
    double id;
    string[] apt1;
    DateTime dt;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        { Response.Redirect("~/Login.aspx"); }
        else
        {
            cn = new connection();
            if (!IsPostBack)
            {
                txtptnt_nm.Focus();
                InitList();
                InitList1();
                lbldate.Text = System.DateTime.Now.Date.ToShortDateString();
        //        Image1.Visible = false;
        //        btn_print.Enabled = false;
        //        id = cn.getmaxid("select max(s_d_id) from tbl_s_dignostic_trn", "tbl_s_dignostic_trn");
        //        if (id == 0) { lbldigno_id.Text = Convert.ToString(id + 1); }
        //        else
        //        {
        //            lbldigno_id.Text = Convert.ToString(id + 1);
        //        }
            }
        }
   }

    #region Language
    public void InitList()
    {
        lst_lang_used.Items.Clear();
        lst_env_lang.Items.Clear();

        foreach (string st in Language)
        {
            lst_lang_used.Items.Add(st);
            lst_env_lang.Items.Add(st);
            ddl_mother_tongue.Items.Add(st);
            ddl_mother_tongue.Items.Insert(0, "Select");
        }
    }
    public void InitList1()
    {
        ddl_mother_tongue.Items.Clear();
        ddl_recom_lang.Items.Clear();

        foreach (string st in Language)
        {
            ddl_mother_tongue.Items.Add(st);
            ddl_recom_lang.Items.Add(st);

        }
        ddl_mother_tongue.Items.Insert(0, "Select");
        ddl_recom_lang.Items.Insert(0, "Select");
    }
    protected void lst_lang_used_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
            {
            if (txtsel1.Text == "")
            {
                txtsel1.Text = lst_lang_used.SelectedItem.ToString();
            }
            else
            {
                txtsel1.Text = (txtsel1.Text + "," + lst_lang_used.SelectedItem.ToString());

            }
            lst_lang_used.Items.Remove(lst_lang_used.SelectedItem);
            lst_env_lang.Focus();
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
            if (txtsel2.Text == "")
            {
                txtsel2.Text = lst_env_lang.SelectedItem.ToString();
            }
            else
            {
                txtsel2.Text = (txtsel2.Text + "," + lst_env_lang.SelectedItem.ToString());

            }
            lst_env_lang.Items.Remove(lst_env_lang.SelectedItem);
            ddl_oral_fun.Focus();
        }

        catch
        {
            Response.Redirect("~/Login/login.aspx");
        }
    }
    #endregion
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtptnt_nm.Text == "")

            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void ddlnxtmeet_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void btn_nm_Click(object sender, EventArgs e)
    {
        #region Search
        //try
        //{
        //    string nm = txtptnt_nm.Text.ToUpper();
        //    ddl_ptnt_nm.Items.Clear();

        //    cmd = new SqlCommand("sp_ptnt_speech_search", connection.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@p_ptnt_nm", nm);
        //    cn.Open();
        //    cn.executeprocedure(cmd);

        //    DataTable DT1 = new DataTable();
        //    cn.Open();
        //    dr = cmd.ExecuteReader();
        //    DT1.Load(dr);
        //    DT1.Columns.Add("ptntnm", typeof(string), "ptnt_id+','+ptnt_nm");
        //    ddl_ptnt_nm.DataSource = DT1;
        //    ddl_ptnt_nm.DataValueField = "ptnt_id";
        //    ddl_ptnt_nm.DataTextField = "ptntnm";
        //    ddl_ptnt_nm.DataBind();
        //    ddl_ptnt_nm.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
        //    ddl_ptnt_nm.SelectedIndex = 0;
        //    dr = null;
        //    cn.Close();

        //}

        //catch
        //{
        //    Response.Redirect("~/error.aspx");
        //}
        #endregion
    }
    protected void ddl_ptnt_nm_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddl_ptnt_nm.SelectedIndex > 0)
        //{
        //    #region patient information
        //    try
        //    {
        //        lblptnt_id.Text = "";
        //        lblptnttype.Text = "";
        //        lblptntdob.Text = "";
        //        lblptntage.Text = "";
        //        lblgender.Text = "";
        //        lblprofession.Text = "";


        //        string[] arrrSelVal = ddl_ptnt_nm.SelectedValue.Split(',');
        //        double pid = System.Convert.ToInt32(arrrSelVal[0]);

        //        cmd = new SqlCommand("sp_ptnt_info_name", connection.con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@p_ptnt_id", pid);
        //        cn.Open();
        //        cn.executeprocedure(cmd);
        //        DataTable DT1 = new DataTable();
        //        cn.Open();
        //        dr = cmd.ExecuteReader();
        //        DT1.Load(dr);

        //        lblptnt_id.Text = DT1.Rows[0][1].ToString();
        //        lblptnttype.Text = DT1.Rows[0][2].ToString();
        //        lblptntdob.Text = DT1.Rows[0][4].ToString();
        //        lblptntage.Text = DT1.Rows[0][5].ToString();
        //        lblgender.Text = DT1.Rows[0][6].ToString();
        //        lblprofession.Text = DT1.Rows[0][7].ToString();
        //        dr = null;
        //        cn.Close();

        //        string apt_id = "select * from tbl_apointment_trn" +
        //          " where ptnt_id ='" + lblptnt_id.Text + "' and  apt_date='" + System.DateTime.Now.Date + "'";
        //        ds = cn.GetData(apt_id, "tbl_apointment_trn");
        //        try
        //        {
        //            apt_id = ds.Tables["tbl_apointment_trn"].Rows[0][1].ToString();
        //            lblat_time.Text = ds.Tables["tbl_apointment_trn"].Rows[0][5].ToString();
        //        }
        //        catch { Response.Write("<script>alert('Please Select Valid Appointment Patient')</script>"); }
        //        if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
        //        { lblaptid.Text = apt_id; }
        //        else { Response.Write("<script>alert('Please Select Valid Appointment Patient')</script>"); }

        //        double ass_id = cn.getmaxid("select max(s_asses_id) from tbl_assess" +
        //         " where ptnt_id ='" + lblptnt_id.Text + "'", "tbl_s_as_trn");
        //        if (ass_id == 0) { Response.Write("<script>alert('Please Select Assessed Patient')</script>"); }
        //        else { lblas_id.Text = System.Convert.ToString(ass_id); }
        //    }
        //    catch { Response.Write("<script>alert('Please Select Appointed or Assessed Patient')</script>"); }
        //    Image();
        //    loadgrid();
        //    #endregion
        //}
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        #region Save
        try
        {
            //int assesid = System.Convert.ToInt32(lblas_id.Text);
            int assesid = 0;
            //int ap_id = System.Convert.ToInt32(lblaptid.Text);
            int ap_id = System.Convert.ToInt32(lblaptid.Text);
            //int ptnt_id = System.Convert.ToInt32(lblptnt_id.Text);
            int ptnt_id = System.Convert.ToInt32(lblptnt_id.Text);
            string m_toungue = ddl_mother_tongue.SelectedItem.Text.ToString();
            string mode = ddl_mode_exp.SelectedItem.Text.ToString();
            string exp = ddl_expressive_lang.SelectedItem.Text.ToString();
            string rec = ddl_rec_lang.SelectedItem.Text.ToString();
            string langused = txtsel1.Text.ToString();
            string langenv = txtsel2.Text.ToString();
            string oralmotor = ddl_oral_fun.SelectedItem.Text.ToString();
            string fluency = ddl_fluency.SelectedItem.Text.ToString();
            string behobs = ddl_beh_obs.SelectedItem.Text.ToString();
            string dignodet = txts_digno_det.Text.ToString();
            string recomlang = ddl_recom_lang.SelectedItem.Text.ToString();
            string nasal_rate = ddl_nasal_rate.SelectedItem.Text.ToString();
            string recom = txt_recom.Text.ToString();
            //string cr_by = Session["Name"].ToString();
            
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";

            cn.Open();
            cmd = new SqlCommand("tbl_s_dignostic_trn_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);     
            cmd.Parameters.AddWithValue("@ps_asses_id", assesid);
            cmd.Parameters.AddWithValue("@papt_id", ap_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@ps_d_moth_tong", m_toungue);
            cmd.Parameters.AddWithValue("@ps_d_mode_exp", mode);
            cmd.Parameters.AddWithValue("@ps_d_exp_lang", exp);
            cmd.Parameters.AddWithValue("@ps_d_rec_lang", rec);
            cmd.Parameters.AddWithValue("@ps_d_lang_used", langused);
            cmd.Parameters.AddWithValue("@ps_d_env_lang", langenv);
            cmd.Parameters.AddWithValue("@ps_d_ora_motor", oralmotor);
            cmd.Parameters.AddWithValue("@ps_d_fluency", fluency);
            cmd.Parameters.AddWithValue("@ps_d_beh_obs", behobs);
            cmd.Parameters.AddWithValue("@ps_d_digno_det", dignodet);
            cmd.Parameters.AddWithValue("@ps_d_recom_lang", recomlang);
            cmd.Parameters.AddWithValue("@ps_nasal_rate", nasal_rate);
            cmd.Parameters.AddWithValue("@ps_recom", recom);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            cn.executeprocedure(cmd);
            cn.Close();
            btnsave.Enabled = false;
            //btn_print.Enabled = true;
        }

        catch
        {
            Response.Redirect("~/error.aspx");
        }
        #endregion
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
            int ptntid = Convert.ToInt32(lblptnt_id.Text);
            Response.Redirect("~/Clinical Forms/nxt_apts.aspx?ptnt_id=" + ptntid);
        }
    }
    private void nxtmeet(int d, int n_d)
    {
        #region NEXT APPOINTMENT
        try
        {
            DateTime dt = System.DateTime.Now.Date;
            int ptntid = System.Convert.ToInt32(lblptnt_id.Text);
            string ptntfor1 = lblptnttype.Text;
            DateTime aptdt = dt;


            for (j = d; j <= n_d; )
            {
                dt = dt.AddDays(+d);
                if (dt.DayOfWeek.ToString() == "Sunday")
                { dt = dt.AddDays(+1); }
                else { dt.ToShortDateString(); }

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
                string cur_time = "select * from tbl_apointment_trn" +
                @" where apt_date  ='" + System.DateTime.Now.Date + "'";
                ds = cn.GetData(cur_time, "tbl_apointment_trn");
                if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                {
                    cur_time = ds.Tables["tbl_apointment_trn"].Rows[0][5].ToString();

                    string nxt_time = "select * from tbl_apointment_trn" +
                    @" where apt_date  ='" + aptdt + "'and apt_time='" + cur_time + "'";
                    ds = cn.GetData(nxt_time, "tbl_apointment_trn");

                    if (ds.Tables["tbl_apointment_trn"].Rows.Count > 0)
                    {
                        nxt_time = ds.Tables["tbl_apointment_trn"].Rows[0][5].ToString();
                        string time_chk = "select * from tbl_apointment_trn" +
                             @" where apt_date  ='" + aptdt + "'order by apt_time";
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
                                apttime = apt1[0].ToString();

                            }

                            else { nxtmeet(d + 1, n_d + 1); }
                        }

                        else
                        {
                            string time1 = "select * from tbl_apointment_trn" +
                            @" where apt_date ='" + System.DateTime.Now.Date + "'";
                            ds = cn.GetData(time1, "tbl_apointment_trn");
                            try
                            {
                                apttime = ds.Tables["tbl_apointment_trn"].Rows[0][5].ToString();
                            }
                            catch { Response.Redirect("~/error.aspx"); }
                        }
                    }
                    else
                    {
                        string time1 = "select * from tbl_apointment_trn" +
                        @" where apt_date ='" + System.DateTime.Now.Date + "'";
                        ds = cn.GetData(time1, "tbl_apointment_trn");
                        try
                        {
                            apttime = ds.Tables["tbl_apointment_trn"].Rows[0][5].ToString();
                        }
                        catch { Response.Redirect("~/error.aspx"); }

                    }
                    cmd = new SqlCommand("sp_appointment_insert", connection.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_ptnt_id", ptntid);
                    cmd.Parameters.AddWithValue("@p_ptnt_for", ptntfor1);
                    cmd.Parameters.AddWithValue("@p_apt_date", aptdt);
                    cmd.Parameters.AddWithValue("@p_apt_time", apttime);
                    cmd.Parameters.AddWithValue("@p_created_by", Session["Name"].ToString());
                    cn.Open();
                    cn.executeprocedure(cmd);
                    cn.Close();

                    double aptid1 = cn.getmaxid("select max(apt_id) from tbl_apointment_trn", "tbl_apointment_trn");
                    if (aptid1 == 0) { System.Convert.ToString(aptid1 + 1); }
                    else { System.Convert.ToString(aptid1); }
                    j = System.Convert.ToInt32(j + d);

                }

            }
        }
        catch
        {
            Response.Redirect("~/error.aspx");
        }
        #endregion
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
    public void loadgrid()
    {
        #region Loadgrid
        //cmd = connection.con.CreateCommand();
        //cmd.CommandType = CommandType.Text;
        //cmd.CommandText = "select * from tbl_s_dignostic_trn where ptnt_id=" + lblptnt_id.Text + "";

        //da = new SqlDataAdapter(cmd);
        //ds = new DataSet();
        //da.Fill(ds, "tbl_s_dignostic_trn");

        //if (ds.Tables["tbl_s_dignostic_trn"].Rows.Count > 0)
        //{
        //    grids_lastdigno.DataSource = ds.Tables["tbl_s_dignostic_trn"];
        //    grids_lastdigno.DataBind();
        //}
        //else
        //{
        //    lbl_msg.Visible = true;
        //    lbl_msg.Text = "No Previous Diagnosis!!!! ";
        //}
        #endregion
    }
    public void Image()
    {
        #region Image
        try
        {
            cn.Open();
            double id = Convert.ToDouble(lblptnt_id.Text);

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
            Response.Redirect("~/error.aspx");

        }
        #endregion
    }
    protected void grids_lastdigno_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //grids_lastdigno.PageIndex = e.NewPageIndex;
        //loadgrid();
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {
        #region print

        //lblptnt_id.Text = "";
        //lblptnttype.Text = "";
        //lblptntdob.Text = "";
        //lblptntage.Text = "";
        //lblgender.Text = "";
        //lblprofession.Text = "";
        //ddl_mother_tongue.SelectedIndex = 0;
        //ddl_mode_exp.SelectedIndex = 0;
        //ddl_expressive_lang.SelectedIndex = 0;
        //ddl_rec_lang.SelectedIndex = 0;
        //txtsel1.Text = "";
        //txtsel2.Text = "";
        //ddl_oral_fun.SelectedIndex = 0;
        //ddl_fluency.SelectedIndex = 0;
        //ddl_beh_obs.SelectedIndex = 0;
        //txts_digno_det.Text = "";
        //ddl_recom_lang.SelectedIndex = 0;
        //ddl_nasal_rate.SelectedIndex = 0;
        //txt_recom.Text = "";
        #endregion
       // int billno = Convert.ToInt32(lbldigno_id.Text);
        //Response.Redirect("~/Clinical Forms/s_diagno_rpt.aspx?bill_no=" + billno);
    }
}
