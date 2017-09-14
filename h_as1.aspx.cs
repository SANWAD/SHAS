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
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;


public partial class h_as1 : System.Web.UI.Page
{
    int bill;
    ReportDocument Report;
    ParameterField paramField = new ParameterField();

    ParameterFields paramFields = new ParameterFields();

    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
    protected void Page_Load(object sender, EventArgs e)
    {
        CrystalReportViewer1.ReportSource = Session["ReportDocument"];        
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bill = Convert.ToInt32(Session["H_as_id"].ToString());
            int bill_no = bill;
            // do all your reporting stuff here, then add it to session like so
            Report = new ReportDocument();
            paramField.Name = "@ph_as_id";
            paramDiscreteValue.Value = bill_no;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            CrystalReportViewer1.ParameterFieldInfo = paramFields;
            Report.Load(Server.MapPath("~/Reports/hearing Ass.rpt"));
            //_reportViewer is the crystalviewer which you have on ur aspx form
            
            Session["ReportDocument"] = Report;
        }
        else
        {
            ReportDocument doc = (ReportDocument)Session["ReportDocument"];
            CrystalReportViewer1.ReportSource = doc;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
                      
        }
        catch (Exception Ex)
        {
        }
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
      //  Report.Close();
       // Report.Dispose();
    }

}
