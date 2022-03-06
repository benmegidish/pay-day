using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Timers;

namespace WebApplication10
{
    public partial class profile : System.Web.UI.Page

    {
        public string hours;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null )
            {
                Response.Redirect("login.aspx");
            }

            x.Visible = false;
            xx.Visible = false;
            xxx.Visible = false;
            xxxx.Visible = false;

            if (Session["Bday"]!=null)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CAST(GETDATE() AS date) as currents", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (Session["Bday"] == dr["currents"])
                        {
                            xxxx.Visible = true;
                        }
                    }
                }
                con.Close();
            }

            if (Session["Buttonstate"] == null)
            {
                startbutton.Enabled = true;
                stop.Enabled = false;
            }
            else if (Session["Buttonstate"] + "" == "1")//סוג של קאסט (המרה)
            {
                startbutton.Enabled = false;
                stop.Enabled = true;
            }
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("select imagedata from tblimages where id='" + Session["id"] + "'", con);

                SqlParameter paramid = new SqlParameter()
                {
                    ParameterName = "id",
                    Value = Session["id"]
                };
                cmd.Parameters.Add(paramid);
                con.Open();
                byte[] bytes = (byte[])cmd.ExecuteScalar();
                string strbase64 = Convert.ToBase64String(bytes);
                image1.ImageUrl = "data:Image/png;base64," + strbase64;
                if (image1.ImageUrl == null)
                {
                    image1.ImageUrl = "pics/defaultpic.png";
                }
                try
                {
                    if (Session["firstname"] != null)
                    {
                        firstname.Text = Session["firstname"].ToString();
                        persname.Text = "First Name: " + Session["firstname"].ToString();

                    }
                    if (Session["lastname"] != null)
                    {
                        lastname.Text = Session["lastname"].ToString();
                        Label1.Text = "Last Name: " + Session["lastname"].ToString();
                    }
                    if (Session["Perhour"] != null)
                    {
                        Label4.Text = Session["Perhour"].ToString();
                    }
                    if (Session["Workplace"] != null)
                    {
                        Label2.Text = "Work Place: " + Session["Workplace"].ToString();
                    }


                }
                catch (Exception ex)
                {
                  Response.Write("Something went wrong Please try again Later!");
                }

                SqlCommand vmd = new SqlCommand("SELECT DATEPART(month, GETDATE()) AS Month, DATEPART(YEAR, GETDATE()) AS years", con);
                SqlDataReader dd = vmd.ExecuteReader();
                dd.Read();
                string mm = dd["Month"].ToString();
                if (int.Parse(mm) < 10)
                {
                    mm = "0" + mm;
                }
                string yy = dd["years"].ToString();
                SqlCommand cmm = new SqlCommand("select  (SUM( DATEDIFF(MINUTE ,start_time, End_time)))/60 AS TotalHours from work_datetime where user_id = '" + Session["id"] + "' and Work_Date between '" + mm + "-01-" + yy + "' and '" + mm + "-30-" + yy + "'", con);
                dd.Close();
                SqlDataReader rd = cmm.ExecuteReader();
                //rd.Read();
                //Label3.Text = rd["TotalHours"].ToString();
                calcpaycheck();

            }

        }

        protected void Unnamed_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {

            HttpPostedFile postedfile = fileupload1.PostedFile;
            string filename = Path.GetFileName(postedfile.FileName);
            string fileextantion = Path.GetExtension(filename);
            int filesize = postedfile.ContentLength;

            if (fileextantion.ToLower() == ".jpg" || fileextantion.ToLower() == ".png" ||
              fileextantion.ToLower() == ".gif" || fileextantion.ToLower() == ".bmp")
            {
                Stream stream = postedfile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("updateimage", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramname = new SqlParameter()
                {
                    ParameterName = "@Name",
                    Value = filename

                };
                cmd.Parameters.Add(paramname);
                SqlParameter paramsize = new SqlParameter()
                {
                    ParameterName = "@size",
                    Value = filesize
                };
                cmd.Parameters.Add(paramsize);
                SqlParameter paramimagedata = new SqlParameter()
                {
                    ParameterName = "@imagedata",
                    Value = bytes
                };
                cmd.Parameters.Add(paramimagedata);
                SqlParameter paramid = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = Session["id"]
                };
                cmd.Parameters.Add(paramid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                Response.Write("<script>alert('Only (jpg,png,gif,bmp) are aproved!');</script>");
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("update users_table set Perhour='" + per.Text + "',WorkPlace='" + company.Text + "' where id='" + Session["id"] + "'", con);
            cmd.ExecuteNonQuery();
            Response.Write("Data has been set!");
            con.Close();
        }
        

        protected void Stop_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE work_datetime SET End_time = GETDATE() WHERE Log_id ='" + Session["logid"] + "'", con);
            cmd.ExecuteNonQuery();
            startbutton.Enabled = true;
            Session["Buttonstate"] = null;
            SqlCommand cmm = new SqlCommand("select  SUM(DATEDIFF(MINUTE, start_time, End_time))/60 AS Total from work_datetime where Log_id='" + Session["logid"] + "'", con);
            SqlDataReader dr = cmm.ExecuteReader();
            dr.Read();
            hours = dr["Total"].ToString();
            functions.Send(Session["PhoneNum"].ToString(), Session["firstname"].ToString(), hours);
            con.Close();
            stop.Enabled = false;
            Session["lablestate2"] = "";

            if (Session["lablestate2"] == null)
            {
                xxx.Visible = true;
                xx.Visible = false;
            }
            else
            {
                xxx.Visible = true;
                Session["lablestate2"] = null;
            }
        }

        protected void Start_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into work_datetime(user_id,start_time,Work_Date) values('" + Session["id"] + "',GETDATE(),GETDATE())", con);
            cmd.ExecuteNonQuery();
            SqlCommand cmm = new SqlCommand("select top 1 Log_id from work_datetime where user_id='" + Session["id"] + "' order by Log_id desc", con);
            SqlDataReader dr = cmm.ExecuteReader();
            if (dr.Read())
            {

                Session["logid"] = dr.GetValue(0).ToString();

            }
            else
            {
                Response.Write("<script>alert('Sorry something went wrong');</script>");

            }
            con.Close();
            startbutton.Enabled = false;
            Session["Buttonstate"] = "1";
            stop.Enabled = true;
            Session["lablestate"] = "";

            if (Session["lablestate"] == null)
            {
                x.Visible = true;

            }
            else
            {
                x.Visible = false;
                xx.Visible = true;
                Session["lablestate"] = null;
            }
        }

        protected void calcpaycheck()//אלגוריתם חישוב מס
        {
            int c, a;
            string sql;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand vmd = new SqlCommand("SELECT DATEPART(month, GETDATE()) AS Month, DATEPART(YEAR, GETDATE()) AS years", con);
            SqlDataReader dd = vmd.ExecuteReader();
            dd.Read();
            string mm = dd["Month"].ToString();
            if (int.Parse(mm)<10)
            {
                mm = "0" + mm;
            }
            string yy = dd["years"].ToString();
            dd.Close();
            int count = functions.Count(Session["id"].ToString());
            //SqlCommand xx = new SqlCommand($"select * from Sickday where UserID={Session["id"]} and Sickday between '" + mm + "-01-" + yy + "' and '" + mm + "-30-" + yy + "'", con);
            //SqlDataReader Za = xx.ExecuteReader();
            //Za.Read();
            //if (functions.Calcsickday(Za.GetValue(1) , , Session["id"]))
            //{

            //}
            SqlCommand cmd = new SqlCommand();
            sql = "select  ((SUM( DATEDIFF(MINUTE ,start_time, End_time)))/60)*'" + int.Parse(Label4.Text) + "' AS PreTax from work_datetime where user_id = '" + Session["id"] + "' and Work_Date between '" + mm + "-01-" + yy + "' and '" + mm + "-30-" + yy + "' ";
            dd.Close();
            cmd.CommandText = sql;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
           
            if (dr.Read())
            {
                string tst = dr["PreTax"] + "";
                if (tst == "")
                {
                    return;
                }

                Label5.Text = "Pretax: " + dr["PreTax"].ToString();
                c = int.Parse(dr["PreTax"].ToString());
                Label6.Text = "Health-Insurance: " + (float.Parse(c.ToString()) * 3.1) / 100;
                Label7.Text = "Social-Security : " + (float.Parse(c.ToString()) * 0.4) / 100;

                if (c > 1 && c <= 6330)
                {
                    a = (int.Parse(Label3.Text) * int.Parse(Label4.Text) * 10) / 100;
                    a = (int.Parse(Label3.Text) * int.Parse(Label4.Text)) - a ;
                    Label8.Text = a.ToString();
                }
                else if (c > 6330 && c <= 9080)
                {
                    a = ((int.Parse(Label3.Text) * int.Parse(Label4.Text) - 6330) * 14) / 100;
                    a = a + 633;
                    a = (int.Parse(Label3.Text) * int.Parse(Label4.Text)) - a + count;
                    Label8.Text = a.ToString();
                }
                else if (c > 9080 && c <= 14580)
                {
                    a = ((int.Parse(Label3.Text) * int.Parse(Label4.Text) - 9080) * 20) / 100;
                    a = a + 385 + 633;
                    a = (int.Parse(Label3.Text) * int.Parse(Label4.Text)) - a + count;
                    Label8.Text = a.ToString();
                }
                else if (c > 14580 && c <= 20260)
                {
                    a = ((int.Parse(Label3.Text) * int.Parse(Label4.Text) - 14580) * 31) / 100;
                    a = a + 633 + 385 + 1100;
                    a = (int.Parse(Label3.Text) * int.Parse(Label4.Text)) - a + count;
                    Label8.Text = a.ToString();
                }
                else if (c > 20260 && c <= 42160)
                {
                    a = ((int.Parse(Label3.Text) * int.Parse(Label4.Text) - 20260) * 35) / 100;
                    a = a + 633 + 385 + 1100 + 1761;
                    a = (int.Parse(Label3.Text) * int.Parse(Label4.Text)) - a + count;
                    Label8.Text = a.ToString();
                }
                else if (c > 42160)
                {
                    a = ((int.Parse(Label3.Text) * int.Parse(Label4.Text) - 42160) * 47) / 100;
                    a = a + 633 + 385 + 1100 + 1761 + 7665;
                    a = (int.Parse(Label3.Text) * int.Parse(Label4.Text)) - a + count;
                    Label8.Text = a.ToString();
                }
                else
                {
                    Response.Write("Something went wrong!");
                }

                dr.Close();
                SqlCommand bm = new SqlCommand($"SELECT DATEDIFF( MONTH,MAX (End_time) , GETDATE()) AS Endtimer from work_datetime where user_id={Session["id"]}", con);
                SqlDataReader rr = bm.ExecuteReader();
                rr.Read();
                if (int.Parse(rr["Endtimer"].ToString())>0)
                {
                    SqlCommand cmc = new SqlCommand($"insert into Salaries(Userid,Amount,Month,Year) values({Session["id"]},{Label8.Text},{mm},{yy})", con);
                }
            }
        }
        protected void paycheck_Click(object sender, EventArgs e)//אלגוריתם חישוב מס
        {

            calcpaycheck();

        }

        protected void calender_SelectionChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Dayoff(Dayoff,UserID) values('" + calender.SelectedDate.ToString("MM/dd/yyyy") + "','" + Session["id"] + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sickday(Sickday,UserID) values('" + Calendar1.SelectedDate.ToString("MM/dd/yyyy") + "','" + Session["id"] + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}