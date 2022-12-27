<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="LibraryManagementSystem.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function() {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5 my-3">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <img src="imgs/general-user.png" width="70px" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h5>Author Details</h5>
                            </div>
                        </div>

                        <hr />

                        <div class="row">
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label>ID</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" placeholder="Author ID" ID="AuthorIdTxt" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-dark" ID="GoBtn" runat="server" Text="Go" OnClick="GoBtn_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-7">
                                <div class="form-group">
                                    <label>Author Name</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Author Name" ID="AuthorNameTxt" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="AddAuthorBtn" runat="server" Text="Add" OnClick="AddAuthorBtn_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="UpdateAuthorBtn" runat="server" Text="Update" OnClick="UpdateAuthorBtn_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-danger btn-block btn-lg" ID="DeleteAuthorBtn" runat="server" Text="Delete" OnClick="DeleteAuthorBtn_Click" />
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
                                <h5>Author List</h5>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [author_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="AuthorTable" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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
