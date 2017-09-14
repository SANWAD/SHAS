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

public partial class MenuMapping : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    double id;
    SqlDataAdapter da;
    SqlDataReader dr1;
    DataSet ds;
    int IsAct,UserId;
    string Flag, MenuSelect, MenuSubSelect,Check = "";
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
            CLEAR();
            cn.Open();
            #region Loading
            if (!IsPostBack)
            {
                cn.Open();
                ddlUser.Items.Clear();
                cmd = connection.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "sp_User_DDL";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "tbl_user_master");

                DataTable DT2 = new DataTable();
                dr1 = cmd.ExecuteReader();
                DT2.Load(dr1);
                ddlUser.DataSource = DT2;
                ddlUser.DataValueField = "USER_ID";
                ddlUser.DataTextField = "user_nm";
                ddlUser.DataBind();
                ddlUser.Items.Insert(0, new ListItem("Select", "user_nm"));
                //ddlUser.SelectedIndex = 0;
                dr1 = null;
                PopulateMasterMenu();
                cn.Close();                
                Select();
            }
            #endregion
        }
      }
    }

    public void Select()
    {
        if (Request.QueryString["Map_Id"].ToString() != "0")
        {
            #region Select
            try
            {
                string id1;
                id1 = (Request.QueryString["Map_Id"].ToString());
                int MapID = System.Convert.ToInt32(id1);
                lblChild_MapId.Text = id1;
                cn.Open();
                cmd = new SqlCommand("USERMENUMAP_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pMap_id", MapID);
                cmd.Parameters.AddWithValue("@pMnuType", 'M');
                cn.executeprocedure(cmd);
                DataTable DT1 = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT1.Load(dr);
                lbl_MAPID.Value = DT1.Rows[0][0].ToString();                
                lblChk.Text = DT1.Rows[0][1].ToString();
                ddlUser.SelectedValue = DT1.Rows[0][2].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand("USERMENUMAP_Select", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pMap_id", MapID);
                cmd.Parameters.AddWithValue("@pMnuType", 'C');
                cn.executeprocedure(cmd);
                DataTable DTCHLD = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DTCHLD.Load(dr);
                lbl_MAPID.Value = DTCHLD.Rows[0][0].ToString();                
                lblChk.Text = DT1.Rows[0][1].ToString();
                PopulateMasterMenu2();
                PopulateMasterMenu3(DTCHLD.Rows[0][1].ToString(), DT1.Rows[0][1].ToString());
                
                ddlUser.SelectedValue = DTCHLD.Rows[0][2].ToString();
                string IsActive = DTCHLD.Rows[0][3].ToString();
                if (IsActive == "True")
                {
                    ChkIsAct.Checked = true;
                }
                else
                {
                    ChkIsAct.Checked = false;
                }                
                dr = null;
                cn.Close();
                btn_save.Text = "Edit";
            }
            catch
            { }

            #endregion
        }
    }


    public void CLEAR()
    {
               
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if(btn_save.Text=="Edit")
        {
            #region Edit
            try
            {
                MenuString();
                // int MAPID = Convert.ToInt32(lbl_MAPID.Value);
                int MAPID = Convert.ToInt32(lblChild_MapId.Text);
                UserId = Convert.ToInt32(ddlUser.SelectedValue);
                if (ChkIsAct.Checked == true)
                {
                    IsAct = 1;
                }
                else
                {
                    IsAct = 0;
                }
                Flag = "E";
                cn.Open();
                cmd = new SqlCommand("USERMENUMAP_c", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pFlag", Flag);
                cmd.Parameters.AddWithValue("@pMAPID", MAPID);
                cmd.Parameters.AddWithValue("@pMENUID", lblChk.Text);
                cmd.Parameters.AddWithValue("@pUserID", UserId);
                cmd.Parameters.AddWithValue("@pISACTIVE", IsAct);
                cn.executeprocedure(cmd);
                cn.Close();
                btn_save.Text = "Save";
                btn_save.Enabled = false;
                btnCan.Text = "Exit";
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('Record is not Update')</script>");
            }
            #endregion
        }
        else
        {
        #region Save
        try
        {
            int MAPID = 0;
            UserId = Convert.ToInt32(ddlUser.SelectedValue);
            if (ChkIsAct.Checked == true)
            {
                IsAct = 1;
            }
            else
            {
                IsAct = 0;
            }     
            Flag = "I";
            cn.Open();
            cmd = new SqlCommand("USERMENUMAP_c", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pFlag", Flag);
            cmd.Parameters.AddWithValue("@pMAPID", MAPID);
            cmd.Parameters.AddWithValue("@pMENUID", lblChk.Text);
            cmd.Parameters.AddWithValue("@pUserID", UserId);
            cmd.Parameters.AddWithValue("@pISACTIVE", IsAct);
            cn.executeprocedure(cmd);
            cn.Close(); 
            btn_save.Enabled = false;
            btnCan.Text = "Exit";
            //Response.Redirect("MenuMapping_Grid.aspx");
        }
        catch
        {
            Response.Write("<script language='JavaScript'>alert('Record is not save')</script>");
        }
        #endregion
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MenuMapping_Grid.aspx");
    }
    protected void chkMastMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        MasterMenu();
        PopulateMasterMenu1(MenuSelect);
        MenuIdMast.Value = MenuSelect;
        Session["MastMenu"] = MenuIdMast.Value;
        //if (btn_save.Text == "SAVE")
        //{
        //    MasterMenu();
        //    PopulateMasterMenu1(MenuSelect);
        //    MenuIdMast.Value = MenuSelect;
        //    Session["MastMenu"] = MenuIdMast.Value;
        //}
        //else if (btn_save.Text == "Edit")
        //{
        //    MasterMenu();
        //}       
    }

    private void PopulateMasterMenu()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["Sanwad"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GETMENULIST_g";                
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    chkMastMenu.Items.Clear();
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["MENUNAME"].ToString();
                        item.Value = sdr["MENUID"].ToString();
                        chkMastMenu.Items.Add(item);
                    }
                }
                conn.Close();
            }
        }
    }

    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateMasterMenu();
    }
     private void PopulateMasterMenu1(string MenuId)
    { 
        using (SqlConnection conn = new SqlConnection())
        {
            chkSubMenu.Items.Clear();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Sanwad"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GETMENULIST_g";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pMenuID", MenuId);               
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {                    
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["MENUNAME"].ToString();
                        item.Value = sdr["MENUID"].ToString();
                        chkSubMenu.Items.Add(item);
                    }
                }
                conn.Close();
            }
        }
    }
     protected void chkSubMenu_SelectedIndexChanged(object sender, EventArgs e)
     {
         SubMenuFill();
         //MenuSubSelect = "";
         //for (int chkcount = 0; chkcount < chkSubMenu.Items.Count; chkcount++)
         //{
         //    if (chkSubMenu.Items[chkcount].Selected)
         //    {
         //        MenuSubSelect +=  chkSubMenu.Items[chkcount].Value + ",";
         //    }
         //}
         //lblChk.Text = MenuIdMast.Value + "," + MenuSubSelect.Remove(MenuSubSelect.Length - 1, 1);
}
     public void MasterMenu()
     {
         MenuSelect = "";
         for (int chkcount = 0; chkcount < chkMastMenu.Items.Count; chkcount++)
         {
             if (chkMastMenu.Items[chkcount].Selected)
             {
                 MenuSelect += chkMastMenu.Items[chkcount].Value + ",";
             }
         }
         MenuSelect = MenuSelect.Remove(MenuSelect.Length - 1, 1);
     }
     public void SubMenuFill()
     {
         MenuSubSelect = "";
         for (int chkcount = 0; chkcount < chkSubMenu.Items.Count; chkcount++)
         {
             if (chkSubMenu.Items[chkcount].Selected)
             {
                 MenuSubSelect += chkSubMenu.Items[chkcount].Value + ",";
             }
         }
         lblChk.Text = MenuIdMast.Value + "," + MenuSubSelect.Remove(MenuSubSelect.Length - 1, 1);
     }
     public void MenuString()
     {
         MasterMenu();
         MenuSubSelect = "";
         for (int chkcount = 0; chkcount < chkSubMenu.Items.Count; chkcount++)
         {
             if (chkSubMenu.Items[chkcount].Selected)
             {
                 MenuSubSelect += chkSubMenu.Items[chkcount].Value + ",";
             }
         }
         lblChk.Text = MenuIdMast.Value + "," + MenuSubSelect.Remove(MenuSubSelect.Length - 1, 1);
     }
private void PopulateMasterMenu2()
{
 chkMastMenu.Items.Clear();
 using (SqlConnection conn = new SqlConnection())
 {
     conn.ConnectionString = ConfigurationManager
             .ConnectionStrings["Sanwad"].ConnectionString;
     using (SqlCommand cmd = new SqlCommand())
     {
         cmd.CommandText = "GETMENULIST_g";
         cmd.Connection = conn;
         conn.Open();
         using (SqlDataReader sdr = cmd.ExecuteReader())
         {
             while (sdr.Read())
             {
                 ListItem item = new ListItem();
                 item.Text = sdr["MENUNAME"].ToString();
                 item.Value = sdr["MENUID"].ToString();
                 chkMastMenu.Items.Add(item);
                 string[] ss = null;
                 string strnew = "";
                 if (lblChk.Text == "")
                 {
                     strnew = "0";
                 }
                 else
                 {
                     PopulateMasterMenu1(lblChk.Text);
                     ss = lblChk.Text.Split(',');
                     for (int i = 0; i < ss.Length; i++)
                     {
                         string a = ss[i].ToString();
                         if (item.Value == a)
                         {
                             foreach (ListItem listItem in chkMastMenu.Items)
                             {
                                 if (a == listItem.Value)
                                 {
                                     listItem.Selected = true;
                                 }
                             } 
                         }
                     }
                 }
             }
         }
         conn.Close();
     }
 }
}
private void PopulateMasterMenu3(string MenuId,string MASTMNU)
{
     BlankMenuString();
     string[] ss = null;
     string[] ss1 = null;         
        ss=MenuId.Split(',');
        ss1 = Check.Split(',');
        for (int i = 0; i < ss1.Length; i++)
        {
            string a = ss1[i].ToString();
            for (int j = 0; j < ss.Length; j++)
            {
                if (a == ss[j])
                {
                    foreach (ListItem listItem in chkSubMenu.Items)
                    {
                        if (a == listItem.Value)
                        {
                        listItem.Selected = true;
                        }
                    }                       
                }

              }
        }
     cn.Close();
}         
private void BlankMenuString()
 { 
    using (SqlConnection conn = new SqlConnection())
    {
        conn.ConnectionString = ConfigurationManager
                .ConnectionStrings["Sanwad"].ConnectionString;
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "GETALLMENU_g";
            cmd.CommandType = CommandType.StoredProcedure;               
            cmd.Connection = conn;
            conn.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {                    
                while (sdr.Read())
                {
                    Check = sdr["MENU"].ToString(); 
                }
            }
            conn.Close();
        }
    }
}
}
 
