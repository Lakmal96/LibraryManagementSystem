using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    UserLogin.Visible = true;
                    SignUp.Visible = true;
                    Logout.Visible = false;
                    Greeting.Visible = false;

                    AdminLogin.Visible = true;
                    AuthorManagement.Visible = false;
                    PublisherManagement.Visible = false;
                    BookInventory.Visible = false;
                    BookIssuing.Visible = false;
                    MemberManagement.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    UserLogin.Visible = false;
                    SignUp.Visible = false;
                    Logout.Visible = true;
                    Greeting.Text = "Hello " + Session["username"].ToString();
                    Greeting.Visible = true;

                    AdminLogin.Visible = true;
                    AuthorManagement.Visible = false;
                    PublisherManagement.Visible = false;
                    BookInventory.Visible = false;
                    BookIssuing.Visible = false;
                    MemberManagement.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {
                    UserLogin.Visible = false;
                    SignUp.Visible = false;
                    Logout.Visible = true;
                    Greeting.Text = "Hello Admin";
                    Greeting.Visible = true;

                    AdminLogin.Visible = false;
                    AuthorManagement.Visible = true;
                    PublisherManagement.Visible = true;
                    BookInventory.Visible = true;
                    BookIssuing.Visible = true;
                    MemberManagement.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void AdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void AuthorManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void PublisherManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void BookInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void BookIssuing_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void MemberManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void ViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void UserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["full_name"] = "";
            Session["username"] = "";
            Session["role"] = "";
            Session["status"] = "";

            UserLogin.Visible = true;
            SignUp.Visible = true;
            Logout.Visible = false;
            Greeting.Visible = false;

            AdminLogin.Visible = true;
            AuthorManagement.Visible = false;
            PublisherManagement.Visible = false;
            BookInventory.Visible = false;
            BookIssuing.Visible = false;
            MemberManagement.Visible = false;

            Response.Redirect("homepage.aspx");
        }

        protected void Greeting_Click(object sender, EventArgs e)
        {
            Response.Redirect("updateuserprofile.aspx");
        }
    }
}