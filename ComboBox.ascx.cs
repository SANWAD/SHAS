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
using System.Linq;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.UI.WebControls.Adapters;


public partial class ComboBox : System.Web.UI.UserControl
{
    connection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    DataSet ds, ds1;
    SqlDataAdapter da;
    double id;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
