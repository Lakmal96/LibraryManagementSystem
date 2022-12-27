<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="LibraryManagementSystem.adminpublishermanagement" %>

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
                                <h5>Publisher Details</h5>
                            </div>
                        </div>

                        <hr />

                        <div class="row">
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label>ID</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" placeholder="Publisher ID" ID="PublisherIdTxt" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-dark" ID="GoBtn" runat="server" Text="Go" OnClick="GoBtn_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-7">
                                <div class="form-group">
                                    <label>Publisher Name</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Publisher Name" ID="PublisherNameTxt" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="AddPublisherBtn" runat="server" Text="Add" OnClick="AddPublisherBtn_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="UpdatePublisherBtn" runat="server" Text="Update" OnClick="UpdatePublisherBtn_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-danger btn-block btn-lg" ID="DeletePublsherBtn" runat="server" Text="Delete" OnClick="DeletePublsherBtn_Click" />
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
                                <h5>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_tbl]"></asp:SqlDataSource>
                                    Publisher List</h5>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="PublisherTable" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
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
