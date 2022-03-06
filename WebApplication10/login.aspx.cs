using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication10
{
    public partial class login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void log_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from users_table where username = '"+Username.Text.Trim()+"' and pass = '"+password.Text.Trim()+"'",con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                         
                            Session["firstname"] = dr.GetValue(1).ToString();
                            Session["lastname"] = dr.GetValue(2).ToString();
                            Session["id"] = dr.GetValue(0).ToString();
                            Session["username"] = dr.GetValue(6).ToString();
                            Session["PhoneNum"] = dr.GetValue(9).ToString();
                            Session["Perhour"] = dr.GetValue(10).ToString();
                            Session["Workplace"] = dr.GetValue(11).ToString();
                            Session["Bday"] = dr.GetValue(8).ToString();
                        }

                        Response.Redirect("profile.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('invalid info');</script>");
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmm = new SqlCommand("select imagedata from tblimages", con);
                    SqlDataReader db = cmm.ExecuteReader();
                    

                    if (db.HasRows)
                    {
                        while (db.Read())
                        {
                            Session["imagedata"] = db.GetValue(3).ToString();
                            Session["userid"] = db.GetValue(4).ToString();
                        }


                    }
                }
            }

            catch (Exception ex)
            {

            }
        }
    }
}