using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorTable.DataBind();
        }

        protected void AddAuthorBtn_Click(object sender, EventArgs e)
        {
            if (CheckAuthorExits())
            {
                Response.Write("<script>alert('Author already exists! Please enter another author.')</script>");
            }
            else
            {
                AddNewAuthor();
            }

        }

        protected void UpdateAuthorBtn_Click(object sender, EventArgs e)
        {
            if (CheckAuthorExits())
            {
                UpdateAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exists!')</script>");
            }
        }

        protected void DeleteAuthorBtn_Click(object sender, EventArgs e)
        {
            if (CheckAuthorExits())
            {
                DeleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exits!')</script>");
            }
        }

        protected void GoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_tbl WHERE author_id='" + AuthorIdTxt.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    AuthorNameTxt.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid author id!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool CheckAuthorExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_tbl WHERE author_id='" + AuthorIdTxt.Text.Trim() + "';", con);
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

        void AddNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO author_tbl (author_id, author_name) VALUES (@author_id, @author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", AuthorIdTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", AuthorNameTxt.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author added successfully!')</script>");

                ClearTexts();
                AuthorTable.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void UpdateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE author_tbl SET author_name=@author_name WHERE author_id='"+ AuthorIdTxt.Text.Trim() +"'", con);
                cmd.Parameters.AddWithValue("@author_name", AuthorNameTxt.Text.Trim());
                
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author record updated successfully!')</script>");
                ClearTexts();
                AuthorTable.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        void DeleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM author_tbl WHERE author_id='"+ AuthorIdTxt.Text.Trim() +"';", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author deleted Successfully!')</script>");
                ClearTexts();
                AuthorTable.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"')</script>");
            }
        }

        void ClearTexts()
        {
            AuthorIdTxt.Text = "";
            AuthorNameTxt.Text = "";
        }


    }
}