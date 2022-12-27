<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="LibraryManagementSystem.adminbookissuing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
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
                                <h5>Book Issuing</h5>
                            </div>
                        </div>

                        <hr />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>UserName</label>
                                    <asp:TextBox CssClass="form-control" placeholder="UserName" ID="UserNameTxt" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Book ID</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" placeholder="Book ID" ID="BookIdTxt" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-dark" ID="GoBtn" runat="server" Text="Go" OnClick="GoBtn_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Name</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Name" ID="NameTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Book Name</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Book Name" ID="BookNameTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Start Date</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Start Date" ID="StartDateTxt" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>End Date</label>
                                    <asp:TextBox CssClass="form-control" placeholder="End Date" ID="EndDateTxt" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="IssueBtn" runat="server" Text="Issue" OnClick="IssueBtn_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="ReturnBtn" runat="server" Text="Return" OnClick="ReturnBtn_Click" />
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
                                <h5>Issued Book List</h5>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="IssuedBookListTbl" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="IssuedBookListTbl_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="user_id" HeaderText="Username" SortExpression="user_id" />
                                        <asp:BoundField DataField="user_name" HeaderText="Name" SortExpression="user_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issu Date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
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
