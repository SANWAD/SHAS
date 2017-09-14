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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using CrystalDecisions.Enterprise;
using CrystalDecisions.ReportAppServer.ClientDoc;
public partial class Transaction_quat : System.Web.UI.Page
{
    int bill;
    ReportDocument Report;
    ParameterField paramField = new ParameterField();
    ParameterFields paramFields = new ParameterFields();
    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (Request.QueryString[0] == null)
        {
            //Response.Redirect("~/error.aspx");
        }
        else
        {
            CrystalReportViewer1.ReportSource = Session["ReportDocument"];
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bill = Convert.ToInt32(Request.QueryString["bill_no"].ToString());
            int bill_no = bill;
            Report = new ReportDocument();
            paramField.Name = "@pQuat_id";
            paramDiscreteValue.Value = bill_no;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            CrystalReportViewer1.ParameterFieldInfo = paramFields;           
            Report.Load(Server.MapPath("~/Reports/quatation.rpt"));
            Session["ReportDocument"] = Report;
        }
        else
        {
            ReportDocument doc = (ReportDocument)Session["ReportDocument"];
            CrystalReportViewer1.ReportSource = doc;
        }
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        //Report.Close();
        //Report.Dispose();
    }
}
