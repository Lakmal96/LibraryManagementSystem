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
    public partial class aadmimembermanagement : System.Web.UI.Page
    {
        private string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserListTbl.DataBind();
        }

        protected void UserNameBtn_Click(object sender, EventArgs e)
        {
            if (CheckUserExists())
            {
                GetUserDetails();
            }
            else
            {
                ClearForm();
                Response.Write("<script>alert('User does not exists!')</script>");
            }
        }

        protected void ActiveBtn_Click(object sender, EventArgs e)
        {
            if (CheckUserExists())
            {
                ChangeUserStatus("active");
                GetUserDetails();
            }
            else
            {
                Response.Write("<script>alert('User does not exists!')</script>");
            }
        }

        protected void PendingBtn_Click(object sender, EventArgs e)
        {
            if (CheckUserExists())
            {
                ChangeUserStatus("pending");
                GetUserDetails();
            }
            else
            {
                Response.Write("<script>alert('User does not exists!')</script>");
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (CheckUserExists())
            {
                ChangeUserStatus("deactivated");
                GetUserDetails();
            }
            else
            {
                Response.Write("<script>alert('User does not exists!')</script>");
            }
        }

        protected void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            if (CheckUserExists())
            {
                DeleteUser();
            }
            else
            {
                Response.Write("<script>alert('User does not exists!')</script>");
            }
        }

        bool CheckUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd =
                    new SqlCommand("SELECT * FROM user_tbl WHERE user_id='" + UserNameTxt.Text.Trim() + "'", con);
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

        void GetUserDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM user_tbl WHERE user_id='" + UserNameTxt.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        FullNameTxt.Text = dr.GetValue(0).ToString();
                        AccountStatusTxt.Text = dr.GetValue(10).ToString();
                        DOBTxt.Text = dr.GetValue(1).ToString();
                        ContactNumberTxt.Text = dr.GetValue(2).ToString();
                        EmailTxt.Text = dr.GetValue(3).ToString();
                        DistrictTxt.Text = dr.GetValue(4).ToString();
                        CityTxt.Text = dr.GetValue(5).ToString();
                        PostalCodeTxt.Text = dr.GetValue(6).ToString();
                        AddressTxt.Text = dr.GetValue(7).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        void ChangeUserStatus(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE user_tbl SET account_status='" + status + "' WHERE user_id='" + UserNameTxt.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('User status updated successfully!')</script>");
                UserListTbl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        void DeleteUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd =
                    new SqlCommand("DELETE FROM user_tbl WHERE user_id='" + UserNameTxt.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('User deleted successfully!')</script>");

                ClearForm();
                UserListTbl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void ClearForm()
        {
            FullNameTxt.Text = "";
            AccountStatusTxt.Text = "";
            DOBTxt.Text = "";
            ContactNumberTxt.Text = "";
            EmailTxt.Text = "";
            DistrictTxt.Text = "";
            CityTxt.Text = "";
            PostalCodeTxt.Text = "";
            AddressTxt.Text = "";
        }


    }
}