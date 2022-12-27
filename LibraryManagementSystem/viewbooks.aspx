<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="LibraryManagementSystem.viewbooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-12 my-3">

                <div class="row">
                    <div class="col text-center">
                        <h5>Book Inventory List</h5>
                    </div>
                </div>
                <div class="row">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_tbl]"></asp:SqlDataSource>
                                <div class="col">
                                    <asp:GridView CssClass="table table-striped table-bordered" ID="BookInventoryTbl" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id">

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
                                                                        &nbsp;
                                                                    </div>
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
        <a style="text-decoration: none" href="./homepage.aspx"><< Back to Home Page</a>
    </div>

</asp:Content>
