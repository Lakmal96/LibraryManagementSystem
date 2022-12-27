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
    public partial class updateuserprofile : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('Session expired!')</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                GetBookDetails();
                if (!IsPostBack)
                {
                    GetUserDetails();
                }
               
            }
            
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('Session expired!')</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                UpdateUserDetails();
            }
        }

        void GetBookDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE user_id='"+ Session["username"].ToString() +"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                IssuedBookTbl.DataSource = dt;
                IssuedBookTbl.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void GetUserDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd  = new SqlCommand("SELECT * FROM user_tbl WHERE user_id='"+ Session["username"].ToString() +"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    FullNameTxt.Text = dt.Rows[0]["full_name"].ToString();
                    DateofBirthTxt.Text = dt.Rows[0]["dob"].ToString();
                    ContactNumberTxt.Text = dt.Rows[0]["contact_number"].ToString();
                    EmailTxt.Text = dt.Rows[0]["email"].ToString();
                    DistrictDrp.SelectedValue = dt.Rows[0]["district"].ToString();
                    CityTxt.Text = dt.Rows[0]["city"].ToString();
                    PostalCodeTxt.Text = dt.Rows[0]["postal_code"].ToString();
                    AddressTxt.Text = dt.Rows[0]["full_address"].ToString();
                    UserNameTxt.Text = dt.Rows[0]["user_id"].ToString();
                    PasswordTxt.Text = dt.Rows[0]["password"].ToString();

                    Status.Text = dt.Rows[0]["account_status"].ToString();

                    if (Status.Text == "active")
                    {
                        Status.Attributes.Add("class"," badge badge-pill badge-success");
                    }
                    else if(Status.Text == "pending")
                    {
                        Status.Attributes.Add("class", " badge badge-pill badge-warning");
                    }
                    else if (Status.Text == "deactivated")
                    {
                        Status.Attributes.Add("class", " badge badge-pill badge-danger");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Something went wrong!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"')</script>");
            }
        }

        void UpdateUserDetails()
        {
            try
            {
                string password = "";
                password = NewPasswordTxt.Text.Trim() == "" ? PasswordTxt.Text.Trim() : NewPasswordTxt.Text.Trim();

                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(
                    "UPDATE user_tbl SET full_name=@full_name, dob=@dob, contact_number=@contact_number, email=@email, " +
                    "district=@district, city=@city, postal_code=@postal_code, full_address=@full_address, password=@password, " +
                    "account_status=@account_status WHERE user_id='" + Session["username"].ToString() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", FullNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", DateofBirthTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_number", ContactNumberTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@email", EmailTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@district", DistrictDrp.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", CityTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@postal_code", PostalCodeTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", AddressTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                GetUserDetails();

                Response.Write("<script>alert('User updated successfully!')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"')</script>");
            }
        }

        protected void IssuedBookTbl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}