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
public partial class Transaction_acc_bill : System.Web.UI.Page
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
            bill = Convert.ToInt32(Request.QueryString["bill_no"].ToString());
            int bill_no = bill;
            Report = new ReportDocument();
            paramField.Name = "@pAcc_id";
            paramDiscreteValue.Value = bill_no;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            CrystalReportViewer1.ParameterFieldInfo = paramFields;
            
            //CrystalDecisions.Shared.ParameterValues billNo = new ParameterValues();
            //CrystalDecisions.Shared.ParameterValues CntId = new ParameterValues();

            //ParameterDiscreteValue pdisval1 = new ParameterDiscreteValue();
            //pdisval1.Value = bill_no;
            //billNo.Add(pdisval1);

            //ParameterDiscreteValue pdisval2 = new ParameterDiscreteValue();
            //pdisval2.Value = Session["Cntr_id"].ToString();
            //CntId.Add(pdisval2);

            //Report.DataDefinition.ParameterFields["@pAcc_id"].ApplyCurrentValues(billNo);
            //Report.DataDefinition.ParameterFields["@pCntr_id"].ApplyCurrentValues(CntId);
 
            //Report.DataDefinition.FormulaFields["Comp_Nm"].Text = "'" + Session["Company Name"] + "'";
            //Report.DataDefinition.FormulaFields["comp"].Text = "'" + Session["Company Address"] + "'";
            Report.Load(Server.MapPath("~/Reports/acc_bill.rpt"));
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
