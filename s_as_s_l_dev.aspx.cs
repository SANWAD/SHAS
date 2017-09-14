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

public partial class s_as_s_l_dev : System.Web.UI.Page
{
    connection cn;
    SqlCommand cmd;
    double id;
    SqlDataReader dr;
    string ptntid, aptid, asid;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Session["Name"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            cn = new connection();            
            lblDate.Text = DateTime.Now.Date.ToShortDateString();      
            if (!IsPostBack)
            { 
                InitList();                
                rbtn_sp_lang_chk.Focus();
                int S_ass_id = Convert.ToInt32(Session["S_as_id"].ToString());
                DataFill(S_ass_id);
                if (Convert.ToInt32(Session["S_as_id"].ToString()) > 0)
                {
                    Select();
                }
                //if (Convert.ToInt32(Session["S_as_id"].ToString()) == 0)
                //{
                //    S_ass_id = Convert.ToInt32(Session["S_as_id"].ToString());
                //    DataFill(S_ass_id);
                //}
                //else
                //{
                //    Select();
                //}
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

                
                lbl_asid.Value = DT1.Rows[0][1].ToString();
                lbl_aptid.Value = DT1.Rows[0][2].ToString();
                DataFill(Convert.ToInt32(lbl_aptid.Value));

                ddlsentstruct.SelectedItem.Text = DT1.Rows[0][32].ToString();
                 string CSC = DT1.Rows[0][33].ToString();
                 if (CSC == "Can Follow")
                {
                    rbtnsimpcmd.SelectedIndex = 0;
                }
                 else if (CSC == "Can not Follow")
                {
                    rbtnsimpcmd.SelectedIndex = 1;
                }
                 else if (CSC == "Age Appropriate")
                {
                    rbtnsimpcmd.SelectedIndex = 3;
                }
                else
                {
                    rbtnsimpcmd.SelectedIndex = 2;
                }
                 string ESC = DT1.Rows[0][34].ToString();
                 if (ESC == "Can Follow")
                 {
                     rbtn_simpcmd.SelectedIndex = 0;
                 }
                 else if (ESC == "Can not Follow")
                 {
                     rbtn_simpcmd.SelectedIndex = 1;
                 }
                 else if (ESC == "Age Appropriate")
                 {
                     rbtn_simpcmd.SelectedIndex = 3;
                 }
                 else
                 {
                     rbtn_simpcmd.SelectedIndex = 2;
                 }
                 ddlbodypartno.SelectedItem.Text = DT1.Rows[0][35].ToString();
                 ddlbodyparttype.SelectedItem.Text = DT1.Rows[0][36].ToString();
                 string EBP = DT1.Rows[0][37].ToString();
                 if (EBP == "Can Follow")
                 {
                     rbt_body_part.SelectedIndex = 0;
                 }
                 else if (EBP == "Can not Follow")
                 {
                     rbt_body_part.SelectedIndex = 1;
                 }
                 else if (EBP == "Age Appropriate")
                 {
                     rbt_body_part.SelectedIndex = 3;
                 }
                 else
                 {
                     rbt_body_part.SelectedIndex = 2;
                 }
                 ddlcomobjcomp.SelectedItem.Text = DT1.Rows[0][38].ToString();
                 ddlcomobjexp.SelectedItem.Text = DT1.Rows[0][39].ToString();

                string CC = DT1.Rows[0][40].ToString();
                if (CC == "Basic")
                 {
                     rbtncolorcomp.SelectedIndex = 0;
                 }
                else if (CC == "Shades")
                 {
                     rbtncolorcomp.SelectedIndex = 1;
                 }
                else if (CC == "Not Achived")
                 {
                     rbtncolorcomp.SelectedIndex = 3;
                 }
                else if (CC == "Age Appropriate")
                 {
                     rbtncolorcomp.SelectedIndex = 4;
                 }
                 else
                 {
                     rbtncolorcomp.SelectedIndex = 2;
                 }
                string EC = DT1.Rows[0][41].ToString();
                if (EC == "Basic")
                {
                    rbtncolorexp.SelectedIndex = 0;
                }
                else if (EC == "Shades")
                {
                    rbtncolorexp.SelectedIndex = 1;
                }
                else if (EC == "Not Achived")
                {
                    rbtncolorexp.SelectedIndex = 3;
                }
                else if (EC == "Age Appropriate")
                {
                    rbtncolorexp.SelectedIndex = 4;
                }
                else
                {
                    rbtncolorexp.SelectedIndex = 2;
                }

                string CN = DT1.Rows[0][42].ToString();
                if (CN == "Can Understand Value")
                {
                    rbtnnumeralcomp.SelectedIndex = 0;
                }
                else if (CN == "Can Not Understand Value")
                {
                    rbtnnumeralcomp.SelectedIndex = 1;
                }
                else if (CN == "Not Achived")
                {
                    rbtnnumeralcomp.SelectedIndex = 3;
                }
                else if (CN == "Age Appropriate")
                {
                    rbtnnumeralcomp.SelectedIndex = 4;
                }
                else
                {
                    rbtnnumeralcomp.SelectedIndex = 2;
                }

                string EN = DT1.Rows[0][43].ToString();
                if (EN == "Can Resite")
                {
                    rbtnnumeralexp.SelectedIndex = 0;
                }
                else if (EN == "Can not Resite")
                {
                    rbtnnumeralexp.SelectedIndex = 1;
                }
                else if (EN == "Can Count Object")
                {
                    rbtnnumeralexp.SelectedIndex = 2;
                }
                else if (EN == "Can Not Count Object")
                {
                    rbtnnumeralexp.SelectedIndex = 3;
                }
                else if (EN == "Not Achived")
                {
                    rbtnnumeralexp.SelectedIndex = 5;
                }
                else if (EN == "Age Appropriate")
                {
                    rbtnnumeralexp.SelectedIndex = 6;
                }
               
                else
                {
                    rbtnnumeralexp.SelectedIndex = 4;
                }

                string CF = DT1.Rows[0][44].ToString();
                if (CF == "Common")
                {
                    rbtnfruitcomp.SelectedIndex = 0;
                }
                else if (CF == "Detail")
                {
                    rbtnfruitcomp.SelectedIndex = 1;
                }
                else if (CF == "Not Achived")
                {
                    rbtnfruitcomp.SelectedIndex = 3;
                }
                else if (CF == "Age Appropriate")
                {
                    rbtnfruitcomp.SelectedIndex = 4;
                }
                else
                {
                    rbtnfruitcomp.SelectedIndex = 2;
                }
                string EF = DT1.Rows[0][45].ToString();
                if (EF == "Common")
                {
                    rbtnfruitexp.SelectedIndex = 0;
                }
                else if (EF == "Detail")
                {
                    rbtnfruitexp.SelectedIndex = 1;
                }
                else if (EF == "Not Achived")
                {
                    rbtnfruitexp.SelectedIndex = 3;
                }
                else if (EF == "Age Appropriate")
                {
                    rbtnfruitexp.SelectedIndex = 4;
                }
                else
                {
                    rbtnfruitexp.SelectedIndex = 2;
                }

                string CA = DT1.Rows[0][46].ToString();
                if (CA == "Common")
                {
                    rbtnanimalcomp.SelectedIndex = 0;
                }
                else if (CA == "Detail")
                {
                    rbtnanimalcomp.SelectedIndex = 1;
                }
                else if (CA == "Not Achived")
                {
                    rbtnanimalcomp.SelectedIndex = 3;
                }
                else if (CA == "Age Appropriate")
                {
                    rbtnanimalcomp.SelectedIndex = 4;
                }
                else
                {
                    rbtnanimalcomp.SelectedIndex = 2;
                }
                string EA = DT1.Rows[0][47].ToString();
                if (EA == "Common")
                {
                    rbtnanimaexp.SelectedIndex = 0;
                }
                else if (EA == "Detail")
                {
                    rbtnanimaexp.SelectedIndex = 1;
                }
                else if (EA == "Not Achived")
                {
                    rbtnanimaexp.SelectedIndex = 3;
                }
                else if (EA == "Age Appropriate")
                {
                    rbtnanimaexp.SelectedIndex = 4;
                }
                else
                {
                    rbtnanimaexp.SelectedIndex = 2;
                }

                string CV = DT1.Rows[0][48].ToString();
                if (CV == "Common")
                {
                    rbtnvegcomp.SelectedIndex = 0;
                }
                else if (CV == "Detail")
                {
                    rbtnvegcomp.SelectedIndex = 1;
                }
                else if (CV == "Not Achived")
                {
                    rbtnvegcomp.SelectedIndex = 3;
                }
                else if (CV == "Age Appropriate")
                {
                    rbtnvegcomp.SelectedIndex = 4;
                }
                else
                {
                    rbtnvegcomp.SelectedIndex = 2;
                }
                string EV = DT1.Rows[0][49].ToString();
                if (EV == "Common")
                {
                    rbtnvegexp.SelectedIndex = 0;
                }
                else if (EV == "Detail")
                {
                    rbtnvegexp.SelectedIndex = 1;
                }
                else if (EV == "Not Achived")
                {
                    rbtnvegexp.SelectedIndex = 3;
                }
                else if (EV == "Age Appropriate")
                {
                    rbtnvegexp.SelectedIndex = 4;
                }
                else
                {
                    rbtnvegexp.SelectedIndex = 2;
                }

                string CCLO = DT1.Rows[0][50].ToString();
                if (CCLO == "Common")
                {
                    rbtnclothescomp.SelectedIndex = 0;
                }
                else if (CCLO == "Detail")
                {
                    rbtnclothescomp.SelectedIndex = 1;
                }
                else if (CCLO == "Not Achived")
                {
                    rbtnclothescomp.SelectedIndex = 3;
                }
                else if (CCLO == "Age Appropriate")
                {
                    rbtnclothescomp.SelectedIndex = 4;
                }
                else
                {
                    rbtnclothescomp.SelectedIndex = 2;
                }
                string ECLO = DT1.Rows[0][51].ToString();
                if (ECLO == "Common")
                {
                    rbtnclothesexp.SelectedIndex = 0;
                }
                else if (ECLO == "Detail")
                {
                    rbtnclothesexp.SelectedIndex = 1;
                }
                else if (ECLO == "Not Achived")
                {
                    rbtnclothesexp.SelectedIndex = 3;
                }
                else if (ECLO == "Age Appropriate")
                {
                    rbtnclothesexp.SelectedIndex = 4;
                }
                else
                {
                    rbtnclothesexp.SelectedIndex = 2;
                }

                string CPLA = DT1.Rows[0][52].ToString();
                if (CPLA == "Common")
                {
                    rbtnplacecomp.SelectedIndex = 0;
                }
                else if (CPLA == "Detail")
                {
                    rbtnplacecomp.SelectedIndex = 1;
                }
                else if (CPLA == "Not Achived")
                {
                    rbtnplacecomp.SelectedIndex = 3;
                }
                else if (CPLA == "Age Appropriate")
                {
                    rbtnplacecomp.SelectedIndex = 4;
                }
                else
                {
                    rbtnplacecomp.SelectedIndex = 2;
                }
                string EPLA = DT1.Rows[0][53].ToString();
                if (EPLA == "Common")
                {
                    rbtnplacesexp.SelectedIndex = 0;
                }
                else if (EPLA == "Detail")
                {
                    rbtnplacesexp.SelectedIndex = 1;
                }
                else if (EPLA == "Not Achived")
                {
                    rbtnplacesexp.SelectedIndex = 3;
                }
                else if (EPLA == "Age Appropriate")
                {
                    rbtnplacesexp.SelectedIndex = 4;
                }
                else
                {
                    rbtnplacesexp.SelectedIndex = 2;
                }

                string CM = DT1.Rows[0][54].ToString();
                if (CM == "Can Identify")
                {
                    rbtnmoneycomp.SelectedIndex = 0;
                }
                else if (CM == "Can Identify Denominations")
                {
                    rbtnmoneycomp.SelectedIndex = 1;
                }
                else if (CM == "Can Do Transaction")
                {
                    rbtnmoneycomp.SelectedIndex = 2;
                }
                else if (CM == "Not Achived")
                {
                    rbtnmoneycomp.SelectedIndex = 4;
                }
                else if (CM == "Age Appropriate")
                {
                    rbtnmoneycomp.SelectedIndex = 5;
                }
                else
                {
                    rbtnmoneycomp.SelectedIndex = 3;
                }


                string EM = DT1.Rows[0][55].ToString();
                if (EM == "Can Identify")
                {
                    rbtnmoneyexp.SelectedIndex = 0;
                }
                else if (EM == "Can Identify Denominations")
                {
                    rbtnmoneyexp.SelectedIndex = 1;
                }
                else if (CM == "Can Do Transaction")
                {
                    rbtnmoneycomp.SelectedIndex = 2;
                }
                else if (EM == "Not Achived")
                {
                    rbtnmoneyexp.SelectedIndex = 4;
                }
                else if (EM == "Age Appropriate")
                {
                    rbtnmoneyexp.SelectedIndex = 5;
                }
                else
                {
                    rbtnmoneyexp.SelectedIndex = 3;
                }




                string CTIM = DT1.Rows[0][56].ToString();
                if (CTIM == "Can Understand Day Night Concept")
                {
                    rbtntimecomp.SelectedIndex = 0;
                }
                else if (CTIM == "Can Identify Time")
                {
                    rbtntimecomp.SelectedIndex = 1;
                }
                else if (CTIM == "Can Read Clock")
                {
                    rbtntimecomp.SelectedIndex = 2;
                }
                else if (CTIM == "Can Follow Time")
                {
                    rbtntimecomp.SelectedIndex = 3;
                }
                else if (EM == "Not Achived")
                {
                    rbtntimecomp.SelectedIndex = 5;
                }
                else if (CTIM == "Age Appropriate")
                {
                    rbtntimecomp.SelectedIndex = 6;
                }
                else
                {
                    rbtntimecomp.SelectedIndex = 4;
                }


                string ETIM = DT1.Rows[0][57].ToString();
                if (ETIM == "Express Day Night Concept")
                {
                    rbtntmieexp.SelectedIndex = 0;
                }
                else if (ETIM == "Can Identify Time")
                {
                    rbtntmieexp.SelectedIndex = 1;
                }
                else if (ETIM == "Can Read Clock")
                {
                    rbtntmieexp.SelectedIndex = 2;
                }
                else if (ETIM == "Can follow Time")
                {
                    rbtntmieexp.SelectedIndex = 3;
                }
                else if (EM == "Not Achived")
                {
                    rbtntmieexp.SelectedIndex = 5;
                }
                else if (ETIM == "Age Appropriate")
                {
                    rbtntmieexp.SelectedIndex = 6;
                }
                else
                {
                    rbtntmieexp.SelectedIndex = 4;
                }

                string CTEN = DT1.Rows[0][58].ToString();
                if (CTEN == "Can Understand Future")
                {
                    rbtn_comp_tense.SelectedIndex = 0;
                }
                else if (CTEN == "Present a Not")
                {
                    rbtn_comp_tense.SelectedIndex = 1;
                }
                else if (CTEN == "Past a Not")
                {
                    rbtn_comp_tense.SelectedIndex = 2;
                }
                else if (CTEN == "Future")
                {
                    rbtn_comp_tense.SelectedIndex = 3;
                }
                else if (CTEN == "Not Present")
                {
                    rbtn_comp_tense.SelectedIndex = 4;
                }
                
                string ETEN = DT1.Rows[0][59].ToString();
                if (ETEN == "Can Express Future")
                {
                    rbtntenseexp.SelectedIndex = 0;
                }
                else if (ETEN == "Can Express Past")
                {
                    rbtntenseexp.SelectedIndex = 1;
                }
                else if (ETEN == "Can Express Present")
                {
                    rbtntenseexp.SelectedIndex = 2;
                }
                else if (ETEN == "Can Express all Tenses")
                {
                    rbtntenseexp.SelectedIndex = 3;
                }
                else if (ETEN == "Can Express Present but cant Express Future")
                {
                    rbtntenseexp.SelectedIndex = 4;
                }
                else if (ETEN == "Can Express Present but cant Express past")
                {
                    rbtntenseexp.SelectedIndex = 5;
                }
                else if (ETEN == "Can Express Past but cant Express Future")
                {
                    rbtntenseexp.SelectedIndex = 6;
                }
                else if (EM == "Not Achived")
                {
                    rbtntmieexp.SelectedIndex = 8;
                }
                else if (ETIM == "Age Appropriate")
                {
                    rbtntenseexp.SelectedIndex = 9;
                }
                else
                {
                    rbtntenseexp.SelectedIndex = 7;
                }



                string CPRE = DT1.Rows[0][60].ToString();
                if (CPRE == "Basic")
                {
                    rbtprepocomp.SelectedIndex = 0;
                }
                else if (CPRE == "Detail")
                {
                    rbtprepocomp.SelectedIndex = 1;
                }
                else if (CPRE == "Not Achived")
                {
                    rbtprepocomp.SelectedIndex = 3;
                }
                else if (CPRE == "Age Appropriate")
                {
                    rbtprepocomp.SelectedIndex = 4;
                }
                else
                {
                    rbtprepocomp.SelectedIndex = 2;
                }
                string EPRE = DT1.Rows[0][61].ToString();
                if (EPRE == "Basic")
                {
                    rbtnprepoexp.SelectedIndex = 0;
                }
                else if (EPRE == "Detail")
                {
                    rbtnprepoexp.SelectedIndex = 1;
                }
                else if (EPRE == "Not Achived")
                {
                    rbtnprepoexp.SelectedIndex = 3;
                }
                else if (EPRE == "Age Appropriate")
                {
                    rbtnprepoexp.SelectedIndex = 4;
                }
                else
                {
                    rbtnprepoexp.SelectedIndex = 2;
                }



                string CADJ = DT1.Rows[0][62].ToString();
                if (CADJ == "Basic")
                {
                    rbtnadjcomp.SelectedIndex = 0;
                }
                else if (CADJ == "Detail")
                {
                    rbtnadjcomp.SelectedIndex = 1;
                }
                else if (CADJ == "Not Achived")
                {
                    rbtnadjcomp.SelectedIndex = 3;
                }
                else if (CADJ == "Age Appropriate")
                {
                    rbtnadjcomp.SelectedIndex = 4;
                }
                else
                {
                    rbtnadjcomp.SelectedIndex = 2;
                }
                string EADJ = DT1.Rows[0][63].ToString();
                if (EADJ == "Basic")
                {
                    rbtnadjexp.SelectedIndex = 0;
                }
                else if (EADJ == "Detail")
                {
                    rbtnadjexp.SelectedIndex = 1;
                }
                else if (EADJ == "Not Achived")
                {
                    rbtnadjexp.SelectedIndex = 3;
                }
                else if (EADJ == "Age Appropriate")
                {
                    rbtnadjexp.SelectedIndex = 4;
                }
                else
                {
                    rbtnadjexp.SelectedIndex = 2;
                }
                ddlactionverbscomp.SelectedItem.Text = DT1.Rows[0][64].ToString();
                ddl_action_verbs_exp.SelectedItem.Text = DT1.Rows[0][65].ToString();


                string CEMO = DT1.Rows[0][66].ToString();
                if (CEMO == "Can Understand")
                {
                    rbtnemotionscomp.SelectedIndex = 0;
                }
                else if (CEMO == "Can Not Understand")
                {
                    rbtnemotionscomp.SelectedIndex = 1;
                }
                else if (CEMO == "Not Achived")
                {
                    rbtnemotionscomp.SelectedIndex = 3;
                }
                else if (CEMO == "Age Appropriate")
                {
                    rbtnemotionscomp.SelectedIndex = 4;
                }
                else
                {
                    rbtnemotionscomp.SelectedIndex = 2;
                }
                string EEMO = DT1.Rows[0][67].ToString();
                if (EEMO == "Can Express")
                {
                    rbtnemotationsexp.SelectedIndex = 0;
                }
                else if (EEMO == "can not Express")
                {
                    rbtnemotationsexp.SelectedIndex = 1;
                }
                else if (EEMO == "Not Achived")
                {
                    rbtnemotationsexp.SelectedIndex = 3;
                }
                else if (EEMO == "Age Appropriate")
                {
                    rbtnemotationsexp.SelectedIndex = 4;
                }
                else
                {
                    rbtnemotationsexp.SelectedIndex = 2;
                }

                dr = null;
                cn.Close();
                //GridLoad();
                btn_save.Text = "Edit";
            }
            catch
            { }

            #endregion
        }
    }
    public void DataFill(int S_ass_id)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["Sanwad"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_S_ass_apt_id";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_S_ass_id", S_ass_id);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        lbl_asid.Value = sdr["s_asses_id"].ToString();
                        lbl_aptid.Value = sdr["apt_id"].ToString();
                        lbl_ptntid.Value = sdr["ptnt_id"].ToString();
                    }
                }
                conn.Close();
            }
        }
    }
    #region INIT
    public void InitList()
    {
        if (!IsPostBack)
        {
            ddlcomobjcomp.Items.Clear();
            ddlcomobjexp.Items.Clear();

            for (int j = 1; j <= 200; j++)
                ddlcomobjcomp.Items.Add(j.ToString());
            ddlcomobjcomp.Items.Insert(0, "Select");

            for (int k = 1; k <= 200; k++)
                ddlcomobjexp.Items.Add(k.ToString());
            ddlcomobjexp.Items.Insert(0, "Select");
        }
    }
    #endregion

    protected void rbtn_sp_lang_chk_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region Speech And Language
        if (rbtn_sp_lang_chk.SelectedIndex == 0)
        {
            ddlsentstruct.SelectedIndex = 11;
            rbtnsimpcmd.SelectedIndex = 2;
            rbtn_simpcmd.SelectedIndex = 2;
            ddlbodypartno.SelectedIndex = 1;
            ddlbodyparttype.SelectedIndex = 4;
            rbt_body_part.SelectedIndex = 2;
            ddlcomobjcomp.SelectedIndex = 1;
            ddlcomobjexp.SelectedIndex = 1;
            rbtncolorcomp.SelectedIndex = 2;
            rbtncolorexp.SelectedIndex = 2;
            rbtnnumeralcomp.SelectedIndex = 2;
            rbtnnumeralexp.SelectedIndex = 4;
            rbtnfruitcomp.SelectedIndex = 2;
            rbtnfruitexp.SelectedIndex = 2;
            rbtnanimalcomp.SelectedIndex = 2;
            rbtnanimaexp.SelectedIndex = 2;
            rbtnvegcomp.SelectedIndex = 2;
            rbtnvegexp.SelectedIndex = 2;
            rbtnclothescomp.SelectedIndex = 2;
            rbtnclothesexp.SelectedIndex = 2;
            rbtnplacecomp.SelectedIndex = 2;
            rbtnplacesexp.SelectedIndex = 2;
            rbtnmoneycomp.SelectedIndex = 3;
            rbtnmoneyexp.SelectedIndex = 3;
            rbtntimecomp.SelectedIndex = 4;
            rbtntmieexp.SelectedIndex = 4;
            rbtn_comp_tense.SelectedIndex = 5;
            rbtntenseexp.SelectedIndex = 7;
            rbtprepocomp.SelectedIndex = 2;
            rbtnprepoexp.SelectedIndex = 2;
            rbtnadjcomp.SelectedIndex = 2;
            rbtnadjexp.SelectedIndex = 2;
            ddlactionverbscomp.SelectedIndex = 7;
            ddl_action_verbs_exp.SelectedIndex = 7;
            rbtnemotionscomp.SelectedIndex = 2;
            rbtnemotationsexp.SelectedIndex = 2;
        }
        else if (rbtn_sp_lang_chk.SelectedIndex == 2)
        {
            ddlsentstruct.SelectedIndex = 12;
            rbtnsimpcmd.SelectedIndex = 3;
            rbtn_simpcmd.SelectedIndex = 3;
            ddlbodypartno.SelectedIndex = 1;
            ddlbodyparttype.SelectedIndex = 5;
            rbt_body_part.SelectedIndex = 3;
            ddlcomobjcomp.SelectedIndex = 2;
            ddlcomobjexp.SelectedIndex = 2;
            rbtncolorcomp.SelectedIndex = 4;
            rbtncolorexp.SelectedIndex = 4;
            rbtnnumeralcomp.SelectedIndex = 4;
            rbtnnumeralexp.SelectedIndex = 6;
            rbtnfruitcomp.SelectedIndex = 4;
            rbtnfruitexp.SelectedIndex = 4;
            rbtnanimalcomp.SelectedIndex = 4;
            rbtnanimaexp.SelectedIndex = 4;
            rbtnvegcomp.SelectedIndex = 4;
            rbtnvegexp.SelectedIndex = 4;
            rbtnclothescomp.SelectedIndex = 4;
            rbtnclothesexp.SelectedIndex = 4;
            rbtnplacecomp.SelectedIndex = 4;
            rbtnplacesexp.SelectedIndex = 4;
            rbtnmoneycomp.SelectedIndex = 5;
            rbtnmoneyexp.SelectedIndex = 5;
            rbtntimecomp.SelectedIndex = 6;
            rbtntmieexp.SelectedIndex = 6;
            rbtn_comp_tense.SelectedIndex = 4;
            rbtntenseexp.SelectedIndex = 9;
            rbtprepocomp.SelectedIndex = 4;
            rbtnprepoexp.SelectedIndex = 4;
            rbtnadjcomp.SelectedIndex = 4;
            rbtnadjexp.SelectedIndex = 4;
            ddlactionverbscomp.SelectedIndex = 8;
            ddl_action_verbs_exp.SelectedIndex = 8;
            rbtnemotionscomp.SelectedIndex = 4;
            rbtnemotationsexp.SelectedIndex = 4;
            ddlbodyparttype.SelectedIndex = 5;
            ddlcomobjcomp.SelectedItem.Text = "Age Appropriate";
            ddlcomobjexp.SelectedItem.Text = "Age Appropriate";
            //ddlactionverbscomp.SelectedIndex = 8;
            //ddl_action_verbs_exp.SelectedIndex = 8;
            //ddlsentstruct.SelectedIndex = 12;
        }
        else
        {
            rbtncolorcomp.SelectedIndex = 3;
            rbtncolorexp.SelectedIndex = 3;
            rbtnnumeralcomp.SelectedIndex = 3;
            rbtnnumeralexp.SelectedIndex = 5;
            rbtnfruitcomp.SelectedIndex = 3;
            rbtnfruitexp.SelectedIndex = 3;
            rbtnanimalcomp.SelectedIndex = 3;
            rbtnanimaexp.SelectedIndex = 3;
            rbtnvegcomp.SelectedIndex = 3;
            rbtnvegexp.SelectedIndex = 3;
            rbtnclothescomp.SelectedIndex = 3;
            rbtnclothesexp.SelectedIndex = 3;
            rbtnplacecomp.SelectedIndex = 3;
            rbtnplacesexp.SelectedIndex = 3;
            rbtnmoneycomp.SelectedIndex = 4;
            rbtnmoneyexp.SelectedIndex = 4;
            rbtntimecomp.SelectedIndex = 5;
            rbtntmieexp.SelectedIndex = 5;
            rbtn_comp_tense.SelectedIndex = 4;
            rbtntenseexp.SelectedIndex = 8;
            rbtprepocomp.SelectedIndex = 3;
            rbtnprepoexp.SelectedIndex = 3;
            rbtnadjcomp.SelectedIndex = 3;
            rbtnadjexp.SelectedIndex = 3;
            rbtnemotionscomp.SelectedIndex = 3;
            rbtnemotationsexp.SelectedIndex = 3;
            ddlsentstruct.SelectedIndex = 13;
            ddlbodyparttype.SelectedIndex = 6;
            ddlcomobjcomp.SelectedItem.Text = "Not Achived";
            ddlcomobjexp.SelectedItem.Text = "Not Achived";
            ddlactionverbscomp.SelectedIndex = 9;
            ddl_action_verbs_exp.SelectedIndex = 9;
        }
        #endregion
        ddlsentstruct.Focus();
    }
    protected void validate_page_wiz2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (rbtn_sp_lang_chk.SelectedIndex == 1)
        {
            try
            {
                if ((ddlsentstruct.SelectedIndex == 0) || (rbtnsimpcmd.SelectedIndex == -1) || (rbtn_simpcmd.SelectedIndex == -1) || (ddlbodypartno.SelectedIndex == 0)
                || (ddlbodyparttype.SelectedIndex == 0) || (rbt_body_part.SelectedIndex == -1) || (ddlcomobjcomp.SelectedIndex == 0) || (ddlcomobjexp.SelectedIndex == 0)
                || (rbtncolorcomp.SelectedIndex == -1) || (rbtncolorexp.SelectedIndex == -1) || (rbtnnumeralcomp.SelectedIndex == -1) || (rbtnnumeralexp.SelectedIndex == -1)
                || (rbtnfruitcomp.SelectedIndex == -1) || (rbtnfruitexp.SelectedIndex == -1) || (rbtnanimalcomp.SelectedIndex == -1) || (rbtnanimaexp.SelectedIndex == -1) ||
                (rbtnvegcomp.SelectedIndex == -1) || (rbtnvegexp.SelectedIndex == -1) || (rbtnclothescomp.SelectedIndex == -1) || (rbtnclothesexp.SelectedIndex == -1) ||
                (rbtnplacecomp.SelectedIndex == -1) || (rbtnplacesexp.SelectedIndex == -1) || (rbtnmoneycomp.SelectedIndex == -1) || (rbtnmoneyexp.SelectedIndex == -1) ||
                (rbtntimecomp.SelectedIndex == -1) || (rbtntmieexp.SelectedIndex == -1) || (rbtn_comp_tense.SelectedIndex == -1) || (rbtntenseexp.SelectedIndex == -1) ||
                (rbtprepocomp.SelectedIndex == -1) || (rbtnprepoexp.SelectedIndex == -1) || (rbtnadjcomp.SelectedIndex == -1) || (rbtnadjexp.SelectedIndex == -1) ||
                (ddlactionverbscomp.SelectedIndex == 0) || (ddl_action_verbs_exp.SelectedIndex == 0) || (rbtnemotionscomp.SelectedIndex == -1)
                || (rbtnemotationsexp.SelectedIndex == -1))
                { args.IsValid = false; }
                else { args.IsValid = true; }
            }
            catch {/* Response.Redirect("~/error.aspx");*/ }
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            #region SAVE
            int apt_id = Convert.ToInt32(lbl_aptid.Value);
            int ptnt_id = Convert.ToInt32(lbl_ptntid.Value);
            int as_id = Convert.ToInt32(lbl_asid.Value);
            string s_sent_struct = ddlsentstruct.SelectedItem.Text;
            string s_comp_simp_cmd = rbtnsimpcmd.SelectedItem.Text;
            string s_exp_simp_cmd = rbtn_simpcmd.SelectedItem.Text;
            string s_comp_body_part_no = ddlbodypartno.SelectedItem.Text;
            string s_comp_body_part_type = ddlbodyparttype.SelectedItem.Text;
            string s_exp_body_part = rbt_body_part.SelectedItem.Text;
            string s_comp_com_obj = ddlcomobjcomp.SelectedItem.Text;
            string s_exp_com_obj = ddlcomobjexp.SelectedItem.Text;
            string s_comp_colors = rbtncolorcomp.SelectedItem.Text;
            string s_exp_colors = rbtncolorexp.SelectedItem.Text;
            string s_comp_numerals = rbtnnumeralcomp.SelectedItem.Text;
            string s_exp_numerals = rbtnnumeralexp.SelectedItem.Text;
            string s_comp_fruit = rbtnfruitcomp.SelectedItem.Text;
            string s_exp_fruit = rbtnfruitexp.SelectedItem.Text;
            string s_comp_animals = rbtnanimalcomp.SelectedItem.Text;
            string s_exp_animals = rbtnanimaexp.SelectedItem.Text;
            string s_comp_vegetables = rbtnvegcomp.SelectedItem.Text;
            string s_exp_vegetables = rbtnvegexp.SelectedItem.Text;
            string s_comp_clothes = rbtnclothescomp.SelectedItem.Text;
            string s_exp_clothes = rbtnclothesexp.SelectedItem.Text;
            string s_comp_place = rbtnplacecomp.SelectedItem.Text;
            string s_exp_place = rbtnplacesexp.SelectedItem.Text;
            string s_comp_money = rbtnmoneycomp.SelectedItem.Text;
            string s_exp_money = rbtnmoneyexp.SelectedItem.Text;
            string s_comp_time = rbtntimecomp.SelectedItem.Text;
            string s_exp_time = rbtntmieexp.SelectedItem.Text;
            string s_comp_tense = rbtn_comp_tense.SelectedItem.Text;
            string s_exp_tense = rbtntenseexp.SelectedItem.Text;
            string s_comp_prepositions = rbtprepocomp.SelectedItem.Text;
            string s_exp_prepositions = rbtnprepoexp.SelectedItem.Text;
            string s_comp_adjectives = rbtnadjcomp.SelectedItem.Text;
            string s_exp_adjectves = rbtnadjexp.SelectedItem.Text;
            string s_comp_actionverbs = ddlactionverbscomp.SelectedItem.Text;
            string s_exp_actionverbs = ddl_action_verbs_exp.SelectedItem.Text;
            string s_comp_emotions = rbtnemotionscomp.SelectedItem.Text;
            string s_exp_emotions = rbtnemotationsexp.SelectedItem.Text;
            //DateTime cr_dt = Convert.ToDateTime(lblDate.Text);
            int cr_by = Convert.ToInt32(Session["Name"].ToString());
            string Flag = "I";

            cn.Open();
            cmd = new SqlCommand("tbl_as_s_l_assess_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@ps_asses_id", as_id);
            cmd.Parameters.AddWithValue("@papt_id", apt_id);
            cmd.Parameters.AddWithValue("@pptnt_id", ptnt_id);
            cmd.Parameters.AddWithValue("@ps_sent_struct", s_sent_struct);
            cmd.Parameters.AddWithValue("@ps_comp_simp_cmd", s_comp_simp_cmd);
            cmd.Parameters.AddWithValue("@ps_exp_simp_cmd", s_exp_simp_cmd);
            cmd.Parameters.AddWithValue("@ps_comp_body_part_no", s_comp_body_part_no);
            cmd.Parameters.AddWithValue("@ps_comp_body_part_type", s_comp_body_part_type);
            cmd.Parameters.AddWithValue("@ps_exp_body_part", s_exp_body_part);
            cmd.Parameters.AddWithValue("@ps_comp_com_obj", s_comp_com_obj);      
            cmd.Parameters.AddWithValue("@ps_exp_com_obj", s_exp_com_obj);
            cmd.Parameters.AddWithValue("@ps_comp_colors", s_comp_colors);
            cmd.Parameters.AddWithValue("@ps_exp_colors", s_exp_colors);
            cmd.Parameters.AddWithValue("@ps_comp_numerals", s_comp_numerals);
            cmd.Parameters.AddWithValue("@ps_exp_numerals", s_exp_numerals);
            cmd.Parameters.AddWithValue("@ps_comp_fruit", s_comp_fruit);
            cmd.Parameters.AddWithValue("@ps_exp_fruit", s_exp_fruit);
            cmd.Parameters.AddWithValue("@ps_comp_animals", s_comp_animals);
            cmd.Parameters.AddWithValue("@ps_exp_animals", s_exp_animals);
            cmd.Parameters.AddWithValue("@ps_comp_vegetables", s_comp_vegetables);
            cmd.Parameters.AddWithValue("@ps_exp_vegetables", s_exp_vegetables);
            cmd.Parameters.AddWithValue("@ps_comp_clothes", s_comp_clothes);
            cmd.Parameters.AddWithValue("@ps_exp_clothes", s_exp_clothes);
            cmd.Parameters.AddWithValue("@ps_comp_place", s_comp_place);
            cmd.Parameters.AddWithValue("@ps_exp_place", s_exp_place);
            cmd.Parameters.AddWithValue("@ps_comp_money", s_comp_money);
            cmd.Parameters.AddWithValue("@ps_exp_money", s_exp_money);
            cmd.Parameters.AddWithValue("@ps_comp_time", s_comp_time);
            cmd.Parameters.AddWithValue("@ps_exp_time", s_exp_time);
            cmd.Parameters.AddWithValue("@ps_comp_tense", s_comp_tense);
            cmd.Parameters.AddWithValue("@ps_exp_tense", s_exp_tense);
            cmd.Parameters.AddWithValue("@ps_comp_prepositions", s_comp_prepositions);
            cmd.Parameters.AddWithValue("@ps_exp_prepositions", s_exp_prepositions);
            cmd.Parameters.AddWithValue("@ps_comp_adjectives", s_comp_adjectives);
            cmd.Parameters.AddWithValue("@ps_exp_adjectves", s_exp_adjectves);
            cmd.Parameters.AddWithValue("@ps_comp_actionverbs", s_comp_actionverbs);
            cmd.Parameters.AddWithValue("@ps_exp_actionverbs", s_exp_actionverbs);
            cmd.Parameters.AddWithValue("@ps_comp_emotions", s_comp_emotions);
            cmd.Parameters.AddWithValue("@ps_exp_emotions", s_exp_emotions);
            cmd.Parameters.AddWithValue("@pcreated_by", cr_by);
            //cmd.Parameters.AddWithValue("@pcreated_dt", cr_dt);
           // cn.executeprocedure(cmd);
            int a=cn.executeprocedure(cmd);
            cn.Close();
            #endregion
            Session["S_as_id"] = lbl_asid.Value;
            Response.Redirect("~/s_as_oral_peri.aspx");
            btn_save.Enabled = false;
            Save.Enabled = false;
        }
        catch
        {/* Response.Write("~/error.aspx"); */}
    }
    protected void btn_prev_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_asses.aspx");
    }
    protected void btn_nxt_Click(object sender, EventArgs e)
    {
        //Session["S_as_id"] = lblas_id.Value;
        Response.Redirect("~/s_as_oral_peri.aspx");
    }
    protected void rbt_body_part_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void btn_pre1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/s_as_asses.aspx");
    }
    protected void btn_nxt1_Click(object sender, EventArgs e)
    {
        //Session["S_as_id"] = lblas_id.Value;
        Response.Redirect("~/s_as_oral_peri.aspx");
    }

}
