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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUpBtn_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Working')</script>;");
            if (UserExists())
            {
                Response.Write("<script>alert('UserName Already taken! Please try another one.')</script>");
            }
            else
            {
                NewUserSignUp();
            }

        }

        bool UserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from user_tbl where user_id='" + UserNameTxt.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }

        }

        void NewUserSignUp()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO user_tbl (full_name,dob,contact_number,email,district,city,postal_code,full_address,user_id,password,account_status) VALUES (@full_name, @dob, @contact_number, @email, @district, @city, @postal_code, @full_address,@user_id, @password, @account_status)", con);
                cmd.Parameters.AddWithValue("@full_name", FullNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", DateOfBirthTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_number", ContactNumberTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@email", EmailTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@district", DistrictDrp.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", CityTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@postal_code", PostalCodeTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", AddressTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@user_id", UserNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@password", PasswordTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('User Created Successfully!')</script>;");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }
    }
}