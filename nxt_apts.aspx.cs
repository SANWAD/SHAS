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


public partial class Clinical_Forms_nxt_apts : System.Web.UI.Page
{
    int id;
    DateTime dt1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("~/Login/login.aspx");
        }
        else
        {
            if (Request.QueryString[0] == null)
            {
                Response.Redirect("~/error.aspx");
            }
            else
            {
                id = Convert.ToInt32(Request.QueryString["ptnt_id"].ToString());
                dt1 = Convert.ToDateTime(Request.QueryString["Date"].ToString());
                try
                {
                    //ReportDocument Report = new ReportDocument();
                    //Report.Load(Server.MapPath("~/Reports/nxt_apt_recept.rpt"));
                    //ParameterFieldDefinitions crParameterFieldDefinitions;
                    //ParameterFieldDefinition crParameterFieldDefinition;
                    //ParameterValues crParameterValues = new ParameterValues();
                    //ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                    //crParameterDiscreteValue.Value = id;
                    //crParameterFieldDefinitions = Report.DataDefinition.ParameterFields;
                    //crParameterFieldDefinition = crParameterFieldDefinitions["@p_ptnt_id"];
                    //crParameterValues = crParameterFieldDefinition.CurrentValues;

                    //crParameterValues.Clear();
                    //crParameterValues.Add(crParameterDiscreteValue);
                    //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                    //crParameterDiscreteValue.Value = dt1.ToShortDateString();
                    //crParameterFieldDefinitions = Report.DataDefinition.ParameterFields;
                    //crParameterFieldDefinition = crParameterFieldDefinitions["@p_apt_Curent_Dt"];
                    //crParameterValues = crParameterFieldDefinition.CurrentValues;

                    //crParameterValues.Add(crParameterDiscreteValue);
                    //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                    //CrystalReportViewer1.ReportSource = Report;
                    //CrystalReportViewer1.RefreshReport();
                }
                catch { Response.Redirect("~/error.aspx"); }
            }
        }
    }
}
