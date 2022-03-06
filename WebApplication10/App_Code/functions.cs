using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication10
{
    public class functions
    {
        public static string Send(string recipienter,string name,string hours)
        {
            string URI = "https://www.sms4free.co.il/ApiSMS/SendSMS";
            WebClient wc = new WebClient();
            string key = "TvziH3Nog";
            string user = "0535266587";
            string pass = "19097252";
            string sender = "PAY-DAY";
            string recipient = recipienter;
            string msg = "Hi Dear '"+name+"' you just worked for '"+hours+"'";
            string myParameters = $"key={key}&user={user}&pass={pass}&sender={sender}&recipient={recipient}&msg={msg}";
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string HtmlResult = wc.UploadString(URI, myParameters);
            return HtmlResult;

        }
        public static string Sent(string recipient,string msg)
        {
            string URI = "https://www.sms4free.co.il/ApiSMS/SendSMS";
            WebClient wc = new WebClient();
            string key = "TvziH3Nog";
            string user = "0535266587";
            string pass = "19097252";
            string sender = "ביטוח לאומי";
            //string recipient = "0526767900";
            //string msg = "Hi lior keep up the good work see you Next time";
            string myParameters = $"key={key}&user={user}&pass={pass}&sender={sender}&recipient={recipient}&msg={msg}";
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string HtmlResult = wc.UploadString(URI, myParameters);
            return HtmlResult;
        }

        public static int Count(string ID)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Pinfo_table where userid='"+ID+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            int counter=0;
            while (dr.Read())
            {
                if (dr.HasRows)
                {
                    for (int i=0;i<dr.FieldCount;i++)
                    {
                        if (dr.GetValue(i).ToString()=="Yes")
                        {
                            counter++;
                        }
                    }
                }
            }
            return counter*216;
        }
        void Loadchart(string ID,DateTime start,DateTime end)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            
        }

        public static int Calcsickday(DateTime start,DateTime End,string userid)
        {
            int count = 0;
            string sql = $"select * from Sickday where UserID={userid} and Sickday between {start.ToString("dd/MM/yyyy")} and {End.ToString("dd/MM/yyyy")}";
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count<=1)
            {
                return 0;
            }
            for(int i = 1; i < dt.Rows.Count; i++)
            {
                DateTime Current = (DateTime)dt.Rows[i]["Sickday"];
                DateTime Before = (DateTime)dt.Rows[i - 1]["Sickday"];
                if (Current.AddDays(-1)==Before)
                {
                    count++;
                }
            }
            return count;
        }

    }
    
}