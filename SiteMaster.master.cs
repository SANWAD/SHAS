using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    int Temp = 0;
    connection con;
    double id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            BindData();
        }
    }
    private void BindData()
    {
        con = new connection();
        SqlCommand myCommand = new SqlCommand("DynamicMenu", connection.con);
        myCommand.Parameters.Add("@pUserId",Convert.ToInt32( Session["Name"].ToString()));
        myCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter ad = new SqlDataAdapter(myCommand);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        // Attach the relationship to the dataSet
        ds.Relations.Add(new DataRelation("CategoriesRelation", ds.Tables[0].Columns["MENUID"],
        ds.Tables[1].Columns["ParentId"]));
        outerRep.DataSource = ds.Tables[0];
        outerRep.DataBind();
    }   
    protected void outerRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
        e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = e.Item.DataItem as DataRowView;
            Repeater innerRep = e.Item.FindControl("innerRep") as Repeater;
            innerRep.DataSource = drv.CreateChildView("CategoriesRelation");
            innerRep.DataBind();
        }
    }
    
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    //if (!IsPostBack)
    //    //{
    //    con = new connection();

    //        SqlDataAdapter da = new SqlDataAdapter("SELECT MENUID , RTRIM(LTRIM(MENUNAME)) as MENUNAME,ParentId,ISNULL(ParentUrl,'#')as ParentUrl FROM dbo.MENUMAST WHERE ISACTIVE=1 and ParentId Is Null",connection.con);
    //        DataTable dttc = new DataTable();
    //        da.Fill(dttc);
    //        HtmlGenericControl main = UList("Menuid");
    //       // HtmlGenericControl main = UList("1,8,16,2,3,4,5,6,7");
    //        foreach (DataRow row in dttc.Rows)
    //        {
    //            da = new SqlDataAdapter("SELECT MENUID , RTRIM(LTRIM(MENUNAME)) as MENUNAME,ParentId,ISNULL(ParentUrl,'#')as ParentUrl FROM dbo.MENUMAST WHERE ISACTIVE=1 and ParentId Is Not Null and ParentId=" + row["MENUID"].ToString(),connection.con);
    //            //da = new SqlDataAdapter("SELECT  M.MENUID, RTRIM(LTRIM(MENUNAME)) AS MENUNAME, ParentId, ISNULL(ParentUrl, '#') AS ParentUrl,'.' + RTRIM(LTRIM(MENUNAME)) + '-Menu' AS MENUTarget FROM    dbo.MENUMAST AS M INNER JOIN dbo.USERMENUMAP AS U ON  M.MENUID IN(SELECT MENUID FROM USERMENUMAP WHERE (ISACTIVE = 1)) INNER JOIN dbo.tbl_user_master AS TUM ON TUM.USER_ID = U.UserID INNER JOIN dbo.Usertype AS U2 ON U2.UserTypeId = TUM.UserTypeId WHERE U.ISACTIVE=1 and ParentId Is Not Null and ParentId=" + row["MENUID"].ToString(), connection.con);
    //            DataTable dtDist = new DataTable();
    //            da.Fill(dtDist);
    //            if (dtDist.Rows.Count > 0)
    //            {
    //                HtmlGenericControl sub_menu = LIList(row["MENUNAME"].ToString(), row["MENUID"].ToString(), row["ParentUrl"].ToString());

    //                if (string.IsNullOrEmpty(row["ParentUrl"].ToString()))
    //                {
    //                    sub_menu.Attributes.Add("class", "nav-header collapsed");
    //                    sub_menu.Attributes.Add("data-target", "."+row["MENUNAME"].ToString()+"-menu");
    //                    sub_menu.Attributes.Add("data-toggle", "collapse");
    //                    main.Attributes.Add("href", "#");
    //                }

    //                HtmlGenericControl ul = new HtmlGenericControl("ul");

    //                foreach (DataRow r in dtDist.Rows)
    //                {
    //                    ul.Controls.Add(LIList(r["MENUNAME"].ToString(), r["MENUID"].ToString(), r["ParentUrl"].ToString()));
                        
    //                    if (Temp == 0)
    //                    {
    //                        ul.Attributes.Add("class", row["MENUNAME"].ToString() + "-menu nav nav-list collapse in");
    //                    }
    //                    else
    //                    {
    //                        ul.Attributes.Add("class", row["MENUNAME"].ToString() + "-menu nav " + row["MENUNAME"].ToString() + " nav nav-list collapse in");
    //                    }
    //                    Temp++;
    //                }
    //                Temp = 0;
    //                sub_menu.Controls.Add(ul);

    //                main.Controls.Add(sub_menu);
    //            }
    //            else
    //            {
    //                main.Controls.Add(LIList(row["MENUNAME"].ToString(), row["MENUID"].ToString(), row["ParentUrl"].ToString()));
    //            }
    //        }
    //        DIvNav.Controls.Add(main);
    //    //}
    //}
    private HtmlGenericControl UList(string id)
    {
        HtmlGenericControl ul = new HtmlGenericControl("ul");
        ul.ID = id;
        return ul;
    }
    private HtmlGenericControl LIList(string innerHtml, string rel, string url)
    {
        HtmlGenericControl li = new HtmlGenericControl("li");
        li.Attributes.Add("rel", rel);
        li.InnerHtml = "<a href=" + (url) + "> <span class='fa fa-caret-right'></span> " + innerHtml + "</a>";
        return li;
    }   
}
