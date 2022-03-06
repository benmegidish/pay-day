using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication10
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string citizancheck="";
        string newcomercheck="";
        string underagecheck="";
        string kidscheck="";
        int    kidsnumcheck=0;
        string devorsecheck="";
        string studentcheck="";
        string militarycheck="";
        string freesildiercheck="";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmm = new SqlCommand("select * from Pinfo_table where userid='" + Session["id"] + "'", con);
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        Session["state"] = dr.GetValue(10).ToString();
                    }
                }
            }
            if (Session["state"].ToString()=="Done")
            {
                subclick.Visible = false;
                Updnote.Visible = true;
                Firstnote.Visible = false;
            }
            else
            {
                Updnote.Visible = false;
                Firstnote.Visible = true;
            }
        
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            int i;
            for (i=0;i<check1.Items.Count;i++)
            {
                if (check1.Items[i].Selected)
                {
                    if (citizancheck=="")
                    {
                        citizancheck = check1.Items[i].Text;
                        
                    }
                }
            }
            for (i = 0; i < check2.Items.Count; i++)
            {
                if (check2.Items[i].Selected)
                {
                    if (newcomercheck == "")
                    {
                        newcomercheck = check2.Items[i].Text;
                       
                    }
                }
            }
            for (i = 0; i < check3.Items.Count; i++)
            {
                if (check3.Items[i].Selected)
                {
                    if (underagecheck == "")
                    {
                        underagecheck = check3.Items[i].Text;
                    }
                }
            }
            for (i = 0; i < check4.Items.Count; i++)
            {
                if (check4.Items[i].Selected)
                {
                    if (kidscheck == "")
                    {
                        kidscheck = check4.Items[i].Text;
                        kidsnumcheck =int.Parse( under18.SelectedValue);
                    }
                }
            }
            for (i = 0; i < check5.Items.Count; i++)
            {
                if (check5.Items[i].Selected)
                {
                    if (devorsecheck=="")
                    {
                        devorsecheck = check5.Items[i].Text;
                    }
                }
            }
            for (i = 0; i < college.Items.Count; i++)
            {
                if (college.Items[i].Selected)
                {
                    if (studentcheck == "")
                    {
                        studentcheck = college.Items[i].Text;
                    }
                }
            }
            for (i = 0; i < check6.Items.Count; i++)
            {
                if (check6.Items[i].Selected)
                {
                    if (militarycheck == "")
                    {
                        militarycheck = check6.Items[i].Text;
                    }
                }
            }
            for (i = 0; i < check7.Items.Count; i++)
            {
                if (check7.Items[i].Selected)
                {
                    if (freesildiercheck == "")
                    {
                        freesildiercheck = check7.Items[i].Text;
                    }
                }
            }
         
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Pinfo_table(userid,Citizan,Newcomer,Underage,Kidsunderfive,Kidsnum,Devorse,Student,Militaryinj,Freesoldier,State) values('" + Session["id"] + "','" + citizancheck + "','" + newcomercheck + "','"+underagecheck+"','" + kidscheck + "','" + int.Parse(kidsnumcheck.ToString()) + "','" + devorsecheck + "','" + studentcheck + "','" + militarycheck + "','" + freesildiercheck + "','Done')", con);
            cmd.ExecuteNonQuery();
            Response.Write("Data has been set Properly!");
            con.Close();
            Response.AddHeader("REFRESH", "2;profile.aspx");
            
        }

        protected void sub_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < check1.Items.Count; i++)
            {
                if (check1.Items[i].Selected)
                {
                    if (citizancheck == "")
                    {
                        citizancheck = check1.Items[i].Text;
                       
                    }
                }
            }
            for (i = 0; i < check2.Items.Count; i++)
            {
                if (check2.Items[i].Selected)
                {
                    if (newcomercheck == "")
                    {
                        newcomercheck = check2.Items[i].Text;
                       
                    }
                }
            }
            for (i = 0; i < check3.Items.Count; i++)
            {
                if (check3.Items[i].Selected)
                {
                    if (underagecheck == "")
                    {
                        underagecheck = check3.Items[i].Text;
                    }
                }
            }
            for (i = 0; i < check4.Items.Count; i++)
            {
                if (check4.Items[i].Selected)
                {
                    if (kidscheck == "")
                    {
                        kidscheck = check4.Items[i].Text;
                        kidsnumcheck = int.Parse(under18.SelectedValue);
                    }
                }
            }
            for (i = 0; i < check5.Items.Count; i++)
            {
                if (check5.Items[i].Selected)
                {
                    if (devorsecheck == "")
                    {
                        devorsecheck = check5.Items[i].Text;
                    }
                }
            }
            for (i = 0; i < college.Items.Count; i++)
            {
                if (college.Items[i].Selected)
                {
                    if (studentcheck == "")
                    {
                        studentcheck = college.Items[i].Text;
                    }
                }
            }
            for (i = 0; i < check6.Items.Count; i++)
            {
                if (check6.Items[i].Selected)
                {
                    if (militarycheck == "")
                    {
                        militarycheck = check6.Items[i].Text;
                    }
                }
            }
            for (i = 0; i < check7.Items.Count; i++)
            {
                if (check7.Items[i].Selected)
                {
                    if (freesildiercheck == "")
                    {
                        freesildiercheck = check7.Items[i].Text;
                    }
                }
            }
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OJJ6EJ5;Initial Catalog=pay-day;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Pinfo_table set Citizan='" + citizancheck + "',Newcomer='" + newcomercheck + "',Underage='" + underagecheck + "',Kidsunderfive='" + kidscheck + "',Kidsnum='"+kidsnumcheck+"',Devorse='" + devorsecheck + "',Student='" + studentcheck + "',Militaryinj='" + militarycheck + "',Freesoldier='" + freesildiercheck + "' where userid='"+Session["id"]+"'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("Data has been set Properly!");
            Response.AddHeader("REFRESH", "2;profile.aspx");
        }
    }
}