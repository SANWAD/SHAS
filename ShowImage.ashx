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

        Double ptnt_id;
        if (context.Request.QueryString["id"] != null)
            ptnt_id = Convert.ToDouble(context.Request.QueryString["id"]);
        else
            throw new ArgumentException("No parameter specified");

        context.Response.ContentType = "image/jpeg";
        Stream strm = ShowptntImage(ptnt_id);
        if (strm !=null)
        {
            byte[] buffer = new byte[4096];
            int byteSeq = 0;

            byteSeq = strm.Read(buffer, 0, 4096);
            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
        }
    }
    public Stream ShowptntImage(double ptnt)
    {
        string conn = ConfigurationManager.ConnectionStrings["sanwad"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);
        string sql = "SELECT p_ptnt_image FROM tbl_ptnt_image WHERE ptnt_id =" + ptnt;
        SqlCommand cmd = new SqlCommand(sql,connection);
        cmd.CommandType = CommandType.Text;
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