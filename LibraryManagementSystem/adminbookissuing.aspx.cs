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
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GoBtn_Click(object sender, EventArgs e)
        {
            if (BookExists() && UserExists())
            {
                GetUsernameBookName();
            }
            else
            {
                Response.Write("<script>alert('Book or Member id does not exists!')</script>");
            }
        }

        protected void IssueBtn_Click(object sender, EventArgs e)
        {
            if (IssueExists())
            {
                Response.Write("<script>alert('Already rented the book to the user!')</script>");
            }
            else
            {
                IssueBook();
            }

        }

        protected void ReturnBtn_Click(object sender, EventArgs e)
        {
            if (BookExists() && UserExists())
            {
                if (IssueExists())
                {
                    ReturnBook();
                }
                else
                {
                    Response.Write("<script>alert('No record found!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Book or Member id does not exists!')</script>");
            }

        }

        bool BookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_tbl WHERE book_id='" + BookIdTxt.Text.Trim() + "' AND current_stock > 0", con);
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

        bool UserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM user_tbl WHERE user_id='" + UserNameTxt.Text.Trim() + "'", con);
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

        void GetUsernameBookName()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT full_name FROM user_tbl WHERE user_id='" + UserNameTxt.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    NameTxt.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('User does not exists!')</script>");
                }

                cmd = new SqlCommand("SELECT book_name FROM book_tbl WHERE book_id='" + BookIdTxt.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    BookNameTxt.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Book does not exists!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }



        }

        void IssueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl (book_id, book_name, user_id, user_name, issue_date, due_date)" +
                                                "VALUES (@book_id, @book_name, @user_id, @user_name, @issue_date, @due_date)", con);
                cmd.Parameters.AddWithValue("@book_id", BookIdTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", BookNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@user_id", UserNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@user_name", NameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", StartDateTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", EndDateTxt.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_tbl SET current_stock=current_stock-1 WHERE book_id='" + BookIdTxt.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Record added successfully!')</script>");
                IssuedBookListTbl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool IssueExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE book_id='" + BookIdTxt.Text.Trim() + "' AND " +
                                                "user_id='" + UserNameTxt.Text.Trim() + "'", con);
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

        void ReturnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id='" + BookIdTxt.Text.Trim() + "' AND " +
                                                "user_id='" + UserNameTxt.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    cmd = new SqlCommand("UPDATE book_tbl SET current_stock=current_stock+1 WHERE book_id='" + BookIdTxt.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                }
                con.Close();

                Response.Write("<script>alert('Updated successfully!')</script>");
                IssuedBookListTbl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void IssuedBookListTbl_RowDataBound(object sender, GridViewRowEventArgs e)
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