<%@ WebHandler Language="C#" Class="ShowImage" %>

using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public class ShowImage : IHttpHandler 
{
    public void ProcessRequest(HttpContext context)
    {
        string empno;
        string Ext;
        if (context.Request.QueryString["id"] != null)
        {
            empno = context.Request.QueryString["id"];
            Ext = Convert.ToString(context.Request.QueryString["Ext"]);
        }
        else
            throw new ArgumentException("No parameter specified");
        if (Ext == ".pdf")
        {
            context.Response.ContentType = "application/pdf";
        }
        else
        {
            if (Ext == ".xls")
            {
                context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }
            else
            {
                if (Ext == ".jpeg")
                {
                    context.Response.ContentType = "image/JPEG";
                }
                else
                {
                    if (Ext == ".gif")
                    {
                        context.Response.ContentType = "image/GIF";
                    }
                    else
                    {
                        if (Ext == ".docx" || Ext == ".doc")
                        {
                            context.Response.ContentType = "application/msword";
                        }
                    }
                }
            }
        }
        Stream strm = ShowEmpImage(empno);
        byte[] buffer = new byte[4096];

        try
        {
            int byteSeq = strm.Read(buffer, 0, 4096);
            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
            context.Response.BinaryWrite(buffer);
        }
        catch
        {
            context.Response.BinaryWrite(buffer);
        }
    }
    public System.IO.Stream ShowEmpImage(string empno)
    {
        string conn = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);
        string sql = "SELECT p_Hist_image FROM tbl_ptnt_Hist_image WHERE ptnt_id = @ID ";
        SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ID", empno);
        connection.Open();
        object img = cmd.ExecuteScalar();
        try
        {
            return new MemoryStream((byte[])img);
        }
        catch
        {
            return null;
        }
        finally
        {
            connection.Close();
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}