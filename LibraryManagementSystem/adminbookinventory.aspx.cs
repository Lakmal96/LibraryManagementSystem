using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string g_filepath;
        static int g_stock, g_current_stock, g_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPublisherAuthorDetails();
            }

            BookInventoryTbl.DataBind();
        }

        protected void BookIdBtn_Click(object sender, EventArgs e)
        {
            GetBookDetails();
        }

        protected void AddBookBtn_Click(object sender, EventArgs e)
        {
            if (CheckBookExists())
            {
                Response.Write("<script>alert('Book already exists!')</script>");
            }
            else
            {
                AddNewBook();
            }
        }

        protected void UpdateBookBtn_Click(object sender, EventArgs e)
        {
            if (CheckBookExists())
            {
                UpdateBookDetails();
            }
            else
            {
                Response.Write("<script>alert('Book does not exists!')</script>");
            }
        }

        protected void DeleteBookBtn_Click(object sender, EventArgs e)
        {
            if (CheckBookExists())
            {
                DeleteBookDetails();
            }
            else
            {
                Response.Write("<script>alert('Book does not exists!')</script>");
            }
        }

        void GetPublisherAuthorDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT publisher_name FROM publisher_tbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                PublisherList.DataSource = dt;
                PublisherList.DataValueField = "publisher_name";
                PublisherList.DataBind();

                cmd = new SqlCommand("SELECT author_name FROM author_tbl", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                AuthorList.DataSource = dt;
                AuthorList.DataValueField = "author_name";
                AuthorList.DataBind();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        bool CheckBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_tbl WHERE book_id='" + BookIdTxt.Text.Trim() + "'", con);
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

        void AddNewBook()
        {
            try
            {
                string genres = "";
                foreach (var genre in GenereSelect.GetSelectedIndices())
                {
                    genres = genres + GenereSelect.Items[genre] + ",";
                }

                genres = genres.Remove(genres.Length - 1);

                string filename = Path.GetFileName(BookUpload.PostedFile.FileName);
                BookUpload.SaveAs(Server.MapPath("book_inventory/" + filename));
                string filepath = "~/book_inventory/" + filename;

                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_tbl (book_id, book_name, genre, author_name, " +
                                                "publisher_name, publish_date, language, edition, cost, pages," +
                                                "book_description, stock, current_stock, book_img) VALUES(@book_id," +
                                                "@book_name, @genre, @author_name, @publisher_name, @publish_date, " +
                                                "@language, @edition, @cost, @pages, @book_description, @stock," +
                                                "@current_stock, @book_img)", con);
                cmd.Parameters.AddWithValue("@book_id", BookIdTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", BookNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", AuthorList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", PublisherList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", PublishDateTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@language", LanguageList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", EditionTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@cost", CostTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@pages", PagesTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", BookDescriptionTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@stock", StockTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", StockTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully')</script>");
                BookInventoryTbl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_tbl WHERE book_id='"+ BookIdTxt.Text.Trim() +"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    BookNameTxt.Text = dt.Rows[0]["book_name"].ToString();
                    LanguageList.SelectedValue = dt.Rows[0]["language"].ToString();
                    AuthorList.SelectedValue = dt.Rows[0]["author_name"].ToString();
                    PublisherList.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
                    PublishDateTxt.Text = dt.Rows[0]["publish_date"].ToString();
                    EditionTxt.Text = dt.Rows[0]["edition"].ToString().Trim();
                    CostTxt.Text = dt.Rows[0]["cost"].ToString().Trim();
                    PagesTxt.Text = dt.Rows[0]["pages"].ToString().Trim();
                    StockTxt.Text = dt.Rows[0]["stock"].ToString().Trim();
                    CurrentStockTxt.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    BookDescriptionTxt.Text = dt.Rows[0]["book_description"].ToString();
                    IssuedBoxTxt.Text =
                        (Convert.ToInt32(dt.Rows[0]["stock"].ToString()) -
                         Convert.ToInt32(dt.Rows[0]["current_stock"].ToString())).ToString();
                    
                    GenereSelect.ClearSelection();
                    string[] genres = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genres.Length; i++)
                    {
                        for (int j = 0; j < GenereSelect.Items.Count; j++)
                        {
                            if (genres[i] == GenereSelect.Items[j].ToString())
                            {
                                GenereSelect.Items[j].Selected = true;
                            }
                        }
                    }

                    g_stock = Convert.ToInt32(dt.Rows[0]["stock"].ToString().Trim());
                    g_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    g_issued_books = g_stock - g_current_stock;
                    g_filepath = dt.Rows[0]["book_img"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid book id!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +")</script>");
            }
        }

        void UpdateBookDetails()
        {
            try
            {
                int stock = Convert.ToInt32(StockTxt.Text.Trim());
                int current_stock = Convert.ToInt32(CurrentStockTxt.Text.Trim());

                if (g_stock == stock)
                {

                }
                else
                {
                    if (g_issued_books > stock)
                    {
                        Response.Write("<script>alert('Stock value cannot be less than issued books!')</script>");
                    }
                    else
                    {
                        current_stock = stock - g_issued_books;
                        CurrentStockTxt.Text = current_stock.ToString();
                    }
                }

                string genres = "";
                foreach (var genre in GenereSelect.GetSelectedIndices())
                {
                    genres = genres + GenereSelect.Items[genre] + ",";
                }

                genres = genres.Remove(genres.Length - 1);

                string filepath = "";
                string filename = Path.GetFileName(BookUpload.PostedFile.FileName);
                if (filename == "" || filename == null)
                {
                    filepath = g_filepath;
                }
                else
                {
                    BookUpload.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }

                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(
                    "UPDATE book_tbl SET book_name=@book_name, genre=@genre, author_name=@author_name," +
                    "publisher_name=@publisher_name, publish_date=@publish_date, language=@language," +
                    "edition=@edition, cost=@cost, pages=@pages, book_description=@book_description," +
                    "stock=@stock, current_stock=@current_stock, book_img=@book_img WHERE book_id='" + BookIdTxt.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@book_name", BookNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", AuthorList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", PublisherList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", PublishDateTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@language", LanguageList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", EditionTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@cost", CostTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@pages", PagesTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", BookDescriptionTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@current_stock", current_stock);
                cmd.Parameters.AddWithValue("@book_img", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                BookInventoryTbl.DataBind();
                Response.Write("<script>alert('Book updated successfully!')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"')</script>");
            }
        }

        void DeleteBookDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_tbl WHERE book_id='"+ BookIdTxt.Text.Trim() +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Book deleted successfully!')</script>");
                BookInventoryTbl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}