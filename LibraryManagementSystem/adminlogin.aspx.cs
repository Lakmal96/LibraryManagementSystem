using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class adminlogin : System.Web.UI.Page
    {
        private string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_tbl WHERE username='"+ AdminIdTxt.Text.Trim() +"' AND password='"+ PasswordTxt.Text.Trim() +"';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //Response.Write("<script>alert('"+ dr.GetValue(0).ToString() +"')</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["role"] = "admin";
                        Session["full_name"] = dr.GetValue(2).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials!')</script>");
                }
            }
            catch (Exception ex)
            {
               Response.Write("<script>alert('"+ ex.Message +"')</script>");
            }



        }
    }
}