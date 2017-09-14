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


public partial class h_m_order : System.Web.UI.Page
{
    SqlCommand cmd;
    connection cn;
    SqlDataReader dr;
    SqlDataAdapter da;
    double itemno, id = 1;
    DataSet ds;
    int rowIndex;
    DataTable myDataTable;
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
        //        id = cn.getmaxid("select max(ord_no)from tbl_ord_nhm_trn", "tbl_ord_nhm_trn");
        //        if (id == 0) { lblord_no.Text = System.Convert.ToString(id + 1); }
        //        else { lblord_no.Text = System.Convert.ToString(id + 1); }
           #region ACCESSORIES
           cn.Open();
           cmd = new SqlCommand("select * from tbl_h_ac_master ", connection.con);
           DataTable DT_ac = new DataTable();

           dr = cmd.ExecuteReader();
           DT_ac.Load(dr);

           ddlacc_desc.DataSource = DT_ac;
           ddlacc_desc.DataValueField = "h_ac_id";
           ddlacc_desc.DataTextField = "h_ac_name";
           ddlacc_desc.DataBind();
           ddlacc_desc.Items.Insert(0, new ListItem("SELECT", "h_ac_name"));
           ddlacc_desc.SelectedIndex = 0;
           dr = null;
           cn.Close();
           #endregion
           #region machine Company
           cn.Open();
           cmd = connection.con.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "sp_Mach_Desc_ddl";
           DataTable DT_comp = new DataTable();

           dr = cmd.ExecuteReader();
           DT_comp.Load(dr);

           ddl_comp.DataSource = DT_comp;
           ddl_comp.DataValueField = "mach_desc";
           ddl_comp.DataTextField = "mach_desc";
           ddl_comp.DataBind();
           ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
           ddl_comp.SelectedIndex = 0;
           dr = null;
           cn.Close();
           #endregion
           ddlordertype.Focus();
            ddlacc_desc.Enabled = false;
            ddl_mach_type.Enabled = false;
            ddl_mach_model.Enabled = false;
            ddl_comp.Enabled = false;
            txt_mach.Enabled = false;
            itemno = 1;
            lblitem_no.Value = System.Convert.ToString(itemno);
            rowIndex = 0;
            }
       }
    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {


    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        //int def = 0;

        //if (ddlordertype.SelectedIndex == 1)
        //{ lblmach_id.Text = System.Convert.ToInt32(def).ToString(); }

        //myDataTable = new DataTable();

        //DataColumn myDataColumn;
        //myDataTable.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        //myDataColumn = new DataColumn();
        //myDataColumn.DataType = Type.GetType("System.Int32");
        //myDataColumn.ColumnName = "ord_no";
        //myDataTable.Columns.Add(myDataColumn);

        //myDataColumn = new DataColumn();
        //myDataColumn.DataType = Type.GetType("System.Int32");
        //myDataColumn.ColumnName = "ord_itm_no";
        //myDataTable.Columns.Add(myDataColumn);

        //myDataColumn = new DataColumn();
        //myDataColumn.DataType = Type.GetType("System.String");
        //myDataColumn.ColumnName = "ord_type";
        //myDataTable.Columns.Add(myDataColumn);

        //myDataColumn = new DataColumn();
        //myDataColumn.DataType = Type.GetType("System.Int32");
        //myDataColumn.ColumnName = "mach_id";
        //myDataTable.Columns.Add(myDataColumn);

        //myDataColumn = new DataColumn();
        //myDataColumn.DataType = Type.GetType("System.Int32");
        //myDataColumn.ColumnName = "qty";
        //myDataTable.Columns.Add(myDataColumn);

        //myDataColumn = new DataColumn();
        //myDataColumn.DataType = Type.GetType("System.String");
        //myDataColumn.ColumnName = "order_by";
        //myDataTable.Columns.Add(myDataColumn);

        //DataRow row;

        //row = myDataTable.NewRow();
        //row["RowNumber"] = GridView1.Rows.Count;
        //row["ord_no"] = System.Convert.ToInt32(lblord_no.Text);
        //row["ord_itm_no"] = System.Convert.ToInt32(lblitem_no.Text);
        //row["ord_type"] = ddlordertype.SelectedItem.Text;
        //row["mach_id"] = System.Convert.ToInt32(lblmach_id.Text);
        //row["qty"] = System.Convert.ToInt32(txtqty.Text);
        //row["order_by"] = txtorder_by.Text;

        //myDataTable.Rows.Add(row);

        //ViewState["Currenttable"] = myDataTable;

        //GridView1.DataSource = myDataTable.DefaultView;
        //GridView1.DataBind();
        //itemno = Convert.ToDouble(lblitem_no.Text);

        //AddNewRowToGrid();

        //itemno++;
        //lblitem_no.Text = itemno.ToString();
        //ddlordertype.SelectedIndex = 0;
        //lblmach_id.Text = "";
        //ddl_mach_model.Items.Clear();
        //ddl_mach_type.Items.Clear();
        //ddlacc_desc.SelectedIndex = 0;
        //ddlacc_desc.Visible = false;
        //ddl_mach_type.Visible = false;
        //ddl_mach_model.Visible = false;
        //ddl_comp.Visible = false;
        //txt_mach.Visible = false;
        //txtqty.Text = "";
        //txtorder_by.Text = "";

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddl_comp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_comp.SelectedIndex > 0)
        {
            #region Machine Model
            try
            {
                cn.Open();
                ddl_mach_model.Items.Clear();
                string Mach_Desc = ddl_comp.SelectedItem.Text;
                cmd = new SqlCommand("sp_Mach_Model_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cn.executeprocedure(cmd);
                DataTable DT_model = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_model.Load(dr);

                ddl_mach_model.DataSource = DT_model;
                ddl_mach_model.DataValueField = "mach_id";
                ddl_mach_model.DataTextField = "mach_model";
                ddl_mach_model.DataBind();
                ddl_mach_model.Items.Insert(0, new ListItem("Select", "mach_model"));
                ddl_mach_model.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_model.Enabled = true;
                ddl_mach_model.Focus();
            }
            catch { Response.Redirect("~/error.aspx"); }
            #endregion
        }
    }
    protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlordertype.SelectedIndex == 1)
        {
            ddlacc_desc.Enabled  = true;
            ddl_mach_type.Enabled = false;
            ddl_mach_model.Enabled = false;
            ddl_comp.Enabled = false;
            txt_mach.Enabled = false;
        }
        else
        {
            ddlacc_desc.Enabled = false;
            ddl_comp.Enabled = true;
            ddl_comp.Enabled = true;
            //#region machine Company
            //cn.Open();
            //cmd = connection.con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "sp_Mach_Desc_ddl";
            //DataTable DT_comp = new DataTable();

            //dr = cmd.ExecuteReader();
            //DT_comp.Load(dr);

            //ddl_comp.DataSource = DT_comp;
            //ddl_comp.DataValueField = "mach_desc";
            //ddl_comp.DataTextField = "mach_desc";
            //ddl_comp.DataBind();
            //ddl_comp.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
            //ddl_comp.SelectedIndex = 0;
            //dr = null;
            //cn.Close();
            //#endregion
        }
    }
    protected void ddl_mach_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_type.SelectedIndex > 0)
        {
            #region Machine Final
            string Mach_Desc = ddl_comp.SelectedItem.Text;
            string Mach_Model = ddl_mach_model.SelectedItem.Text;
            string Mach_Type = ddl_mach_type.SelectedItem.Text;
            cmd = new SqlCommand("sp_Mach_Id_Search", connection.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
            cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
            cmd.Parameters.AddWithValue("@mach_Type", Mach_Type);
            cn.executeprocedure(cmd);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "tbl_machine_master");
            if (ds.Tables["tbl_machine_master"].Rows.Count > 0)
            {
                txt_mach.Enabled = false;
                txt_mach.Text = (System.Convert.ToString(ddl_comp.SelectedItem.Text + "," + ddl_mach_model.SelectedItem.Text + "," + ddl_mach_type.SelectedItem.Text));
                string machid = System.Convert.ToInt32(ds.Tables["tbl_machine_master"].Rows[0][0]).ToString();
                lblmach_id.Value = machid;
                txtqty.Focus();
            }
            #endregion
        }
    }
    protected void ddl_mach_model_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mach_model.SelectedIndex > 0)
        {
            #region Machine Type
            try
            {
                cn.Open();
                ddl_mach_type.Items.Clear();
                string Mach_Desc = ddl_comp.SelectedItem.Text;
                string Mach_Model = ddl_mach_model.SelectedItem.Text;
                cmd = new SqlCommand("sp_Mach_Type_ddl", connection.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mach_desc", Mach_Desc);
                cmd.Parameters.AddWithValue("@mach_model", Mach_Model);
                cn.executeprocedure(cmd);
                DataTable DT_type = new DataTable();
                cn.Open();
                dr = cmd.ExecuteReader();
                DT_type.Load(dr);

                ddl_mach_type.DataSource = DT_type;
                ddl_mach_type.DataValueField = "mach_id";
                ddl_mach_type.DataTextField = "mach_type";
                ddl_mach_type.DataBind();
                ddl_mach_type.Items.Insert(0, new ListItem("Select", "ptnt_nm"));
                ddl_mach_type.SelectedIndex = 0;

                dr = null;
                cn.Close();
                ddl_mach_type.Enabled = true;
                ddl_mach_type.Focus();
            }
            catch {/*Response.Redirect("~/error.aspx");*/ }
            #endregion
        }
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

    private void AddNewRowToGrid()
    {
        //if (GridView1.Rows.Count > 1)
        //{
        //    SetPreviousData();
        //}
        //else
        //{

        //    StringCollection sc = new StringCollection();

        //    if (ViewState["Currenttable"] != null)
        //    {

        //        DataTable dtCurrenttable1 = (DataTable)ViewState["Currenttable"];

        //        DataRow drCurrentrow = null;

        //        if (dtCurrenttable1.Rows.Count > 0)
        //        {

        //            for (int i = 1; i <= dtCurrenttable1.Rows.Count; i++)
        //            {


        //                string box1 = GridView1.Rows[rowIndex].Cells[0].Text;
        //                string box2 = GridView1.Rows[rowIndex].Cells[1].Text;
        //                string box3 = GridView1.Rows[rowIndex].Cells[2].Text;
        //                string box4 = GridView1.Rows[rowIndex].Cells[3].Text;
        //                string box5 = GridView1.Rows[rowIndex].Cells[4].Text;
        //                string box6 = GridView1.Rows[rowIndex].Cells[5].Text;

        //                drCurrentrow = dtCurrenttable1.NewRow();

        //                drCurrentrow["RowNumber"] = i + 1;

        //                dtCurrenttable1.Rows[i - 1]["ord_no"] = box1.ToString();
        //                dtCurrenttable1.Rows[i - 1]["ord_itm_no"] = box2.ToString();
        //                dtCurrenttable1.Rows[i - 1]["ord_type"] = box3.ToString();
        //                dtCurrenttable1.Rows[i - 1]["mach_id"] = box4.ToString();
        //                dtCurrenttable1.Rows[i - 1]["qty"] = box5.ToString();
        //                dtCurrenttable1.Rows[i - 1]["order_by"] = box6.ToString();

        //                rowIndex++;

        //            }

        //            dtCurrenttable1.Rows.Add(drCurrentrow);

        //            ViewState["Currenttable"] = dtCurrenttable1;
        //            GridView1.DataSource = dtCurrenttable1;
        //            GridView1.DataBind();

        //        }

        //    }

        //    else
        //    {

        //        Response.Write("ViewState is null");

        //    }
        //}

    }

    private void SetPreviousData()
    {

        int rowIndex = 0;

        if (ViewState["Currenttable"] != null)
        {

            DataTable dt = (DataTable)ViewState["Currenttable"];

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string box1 = GridView1.Rows[rowIndex].Cells[0].Text;
                    string box2 = GridView1.Rows[rowIndex].Cells[1].Text;
                    string box3 = GridView1.Rows[rowIndex].Cells[2].Text;
                    string box4 = GridView1.Rows[rowIndex].Cells[3].Text;
                    string box5 = GridView1.Rows[rowIndex].Cells[4].Text;
                    string box6 = GridView1.Rows[rowIndex].Cells[5].Text;

                    box1 = dt.Rows[i]["ord_no"].ToString();
                    box2 = dt.Rows[i]["ord_itm_no"].ToString();
                    box3 = dt.Rows[i]["ord_type"].ToString();
                    box4 = dt.Rows[i]["mach_id"].ToString();
                    box5 = dt.Rows[i]["qty"].ToString();
                    box6 = dt.Rows[i]["order_by"].ToString();

                    rowIndex++;

                }
            }
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

    }
}
