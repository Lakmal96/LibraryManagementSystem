<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="LibraryManagementSystem.adminbookinventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 my-3">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <img src="imgs/books.png" width="70px" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h5>Book Details</h5>
                            </div>
                        </div>

                        <hr />

                        <div class="row">
                            <div class="col">
                                <asp:FileUpload CssClass="form-control" ID="BookUpload" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Book ID</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" placeholder="Book ID" ID="BookIdTxt" runat="server"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-primary" ID="BookIdBtn" runat="server" OnClick="BookIdBtn_Click"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Book Name</label>
                                    <asp:TextBox CssClass="form-control" placeholder="BookName" ID="BookNameTxt" runat="server"></asp:TextBox>
                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="LanguageList" runat="server">
                                        <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                        <asp:ListItem Text="Sinhala" Value="Sinhala"></asp:ListItem>
                                        <asp:ListItem Text="Tamil" Value="Tamil"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>


                                <label>Publisher</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="PublisherList" runat="server">
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1"></asp:ListItem>
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Author</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="AuthorList" runat="server">
                                        <asp:ListItem Text="Author 1" Value="Author 1"></asp:ListItem>
                                        <asp:ListItem Text="Author 2" Value="Author 2"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Publish Date</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Publish Date" ID="PublishDateTxt" TextMode="Date" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox CssClass="form-control" ID="GenereSelect" runat="server" SelectionMode="Multiple" Rows="4">
                                        <asp:ListItem Text="Romance" Value="Romance"></asp:ListItem>
                                        <asp:ListItem Text="Action" Value="Action"></asp:ListItem>
                                        <asp:ListItem Text="Personal Development" Value="Personal Development"></asp:ListItem>
                                    </asp:ListBox>
                                </div>


                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Edition</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Edition" ID="EditionTxt" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Cost</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Cost" ID="CostTxt" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Pages</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Pages" ID="PagesTxt" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Stock</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Stock" ID="StockTxt" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Current Stock</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Current Stock" ID="CurrentStockTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Issued Books</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Issued Books" ID="IssuedBoxTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Description</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Description" ID="BookDescriptionTxt" runat="server" Rows="3" ReadOnly="False" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="AddBookBtn" runat="server" Text="Add" OnClick="AddBookBtn_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="UpdateBookBtn" runat="server" Text="Update" OnClick="UpdateBookBtn_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-danger btn-block btn-lg" ID="DeleteBookBtn" runat="server" Text="Delete" OnClick="DeleteBookBtn_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <a style="text-decoration: none" href="./homepage.aspx"><< Back to Home Page</a>

            </div>



            <div class="col-md-7 my-3">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h5>Book Inventory List</h5>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="BookInventoryTbl" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >

                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-md-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Author-<asp:Label ID="Label2" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                                    &nbsp;| Genre -
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("genre") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                                    &nbsp;| Language -
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("language") %>' Font-Bold="True" Font-Italic="True"></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Publisher -
                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("publisher_name") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                                    &nbsp;| Publish Date -
                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("publish_date") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                                    &nbsp;</div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Pages -
                                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("pages") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("edition") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                                    &nbsp;Cost -
                                                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("cost") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Current Stock -
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("stock") %>'></asp:Label>
                                                                    &nbsp;| Available Stock -
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Description -
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Small" Text='<%# Eval("book_description") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:Image CssClass="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>


                    </div>


                </div>
            </div>
        </div>
    </div>

</asp:Content>
