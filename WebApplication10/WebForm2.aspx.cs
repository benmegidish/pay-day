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
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Sortbtn_Click(object sender, EventArgs e)
        {

            string Month = Monthselect.SelectedValue.ToString();
            string Year = Yearselect.SelectedValue.ToString();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select CONVERT(nvarchar, start_time, 108) as StartTime ,CONVERT(nvarchar,End_time,108) as EndTime ,CONVERT(nvarchar,Work_Date,104) as WorkDate from work_datetime where user_id = '" + Session["id"] + "' and Work_Date between '" + Month + "-01-" + Year + "' and '" + Month + "-30-" + Year + "'", con);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            grid.DataSource = dtbl;
            grid.DataBind();
            SqlDataAdapter dbt = new SqlDataAdapter($"select Dayoffcol,UserID from Dayoff where UserID='" + Session["id"] + "' and Dayoffcol between '" + Month + "-01-" + Year + "' and '" + Month + "-30-" + Year + "' ", con);
            DataTable dda = new DataTable();
            dbt.Fill(dda);
            calenderdayoff.DataSource = dda;
            calenderdayoff.DataBind();
            SqlDataAdapter dad = new SqlDataAdapter("select Sickday,UserID from Sickday where UserID='" + Session["id"] + "' and Sickday between '" + Month + "-01-" + Year + "' and '" + Month + "-30-" + Year + "'", con);
            DataTable dr = new DataTable();
            dad.Fill(dr);
            calandersickday.DataSource = dr;
            calandersickday.DataBind();
            con.Close();
        }
    }
}