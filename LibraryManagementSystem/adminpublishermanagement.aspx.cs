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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            PublisherTable.DataBind();
        }

        protected void AddPublisherBtn_Click(object sender, EventArgs e)
        {
            if (PublisherExists())
            {
                Response.Write("<script>alert('Publisher already exists! Please try new one.')</script>");
            }
            else
            {
                AddPublisher();
            }
        }

        protected void UpdatePublisherBtn_Click(object sender, EventArgs e)
        {
            if (PublisherExists())
            {
                UpdatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher not found to update!')</script>");
            }
        }

        protected void DeletePublsherBtn_Click(object sender, EventArgs e)
        {
            if (PublisherExists())
            {
                DeletePublisher();
            }
            else
            {
                Response.Write("<script>alert('No publisher record found!')</script>");
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

                SqlCommand cmd =
                    new SqlCommand(
                        "SELECT * FROM publisher_tbl WHERE publisher_id='" + PublisherIdTxt.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    PublisherNameTxt.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('No record found!')</script>");
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message+"')</script>");
            }
        }

        bool PublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_tbl WHERE publisher_id='" + PublisherIdTxt.Text.Trim() + "'", con);
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

        void AddPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_tbl (publisher_id, publisher_name) VALUES (@publisher_id, @publisher_name)", con);
                cmd.Parameters.AddWithValue("@publisher_id", PublisherIdTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", PublisherNameTxt.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher added successfully!')</script>");
                ClearText();
                PublisherTable.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')<script>");
            }

        }

        void UpdatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd =
                    new SqlCommand(
                        "UPDATE publisher_tbl SET publisher_name=@publisher_name WHERE publisher_id='" +
                        PublisherIdTxt.Text.Trim() + "';", con);
                cmd.Parameters.AddWithValue("@publisher_name", PublisherNameTxt.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher updated successfully!')</script>");

                ClearText();
                PublisherTable.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        void DeletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd =
                    new SqlCommand(
                        "DELETE FROM publisher_tbl WHERE publisher_id='" + PublisherIdTxt.Text.Trim() + "'",
                        con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher deleted successfully!')</script>");
                ClearText();
                PublisherTable.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"')</script>");
            }
           
                
        }

        void ClearText()
        {
            PublisherIdTxt.Text = "";
            PublisherNameTxt.Text = "";
        }

       
    }
}