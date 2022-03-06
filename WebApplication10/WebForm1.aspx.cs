using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace WebApplication10
{
    public partial class WebForm1 : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"insert into users_table (id,Fname,Lname,Gnder,Email,pass,Addres,username,Birthday,Phone,Perhour,WorkPlace)
                                    values('" + id.Text + "', '" + firstname.Text.Trim() + "', '" + lastname.Text.Trim() + "','"+gender.SelectedValue.ToString()+"', " +
                                    "'" + email.Text.Trim() + "', '" + password.Text.Trim() + "', '" + address.Text.Trim() + "', '" + username.Text.Trim() + "'," +
                                    "'"+Bday.Text+"','"+userphone.Text.Trim()+"','"+PerHour.Text+"','"+workplace.Text+"')", con);
            
            cmd.ExecuteNonQuery();
            HttpPostedFile postedFile = fileupload2.PostedFile;
            string Filename = Path.GetFileName(postedFile.FileName);
            string fileextantion = Path.GetExtension(Filename);
            int filesize = postedFile.ContentLength;

            if (fileextantion.ToLower() == ".jpg" || fileextantion.ToLower() == ".png" ||
              fileextantion.ToLower() == ".gif" || fileextantion.ToLower() == ".bmp")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                SqlCommand cmm = new SqlCommand("spuploadimageee", con);
                cmm.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = Filename

                };
                cmm.Parameters.Add(paramName);
                SqlParameter paramsize = new SqlParameter()
                {
                    ParameterName = "@size",
                    Value = filesize
                };
                cmm.Parameters.Add(paramsize);
                SqlParameter paramimagedata = new SqlParameter()
                {
                    ParameterName = "@imagedata",
                    Value = bytes
                };
                cmm.Parameters.Add(paramimagedata);
                SqlParameter paramid = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id.Text.Trim()
                };
                cmm.Parameters.Add(paramid);
               
                cmm.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                Response.Write("<script>alert('Only (jpg,png,gif,bmp) are aproved!');</script>");
            }
            Response.AddHeader("REFRESH", "1;login.aspx");
        }

    }
    
}