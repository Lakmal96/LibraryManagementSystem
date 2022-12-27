<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="LibraryManagementSystem.aadmimembermanagement" %>

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
                                <img src="imgs/general-user.png" width="70px" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h5>User Details</h5>
                            </div>
                        </div>

                        <hr />

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>UserName</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" placeholder="UserName" ID="UserNameTxt" runat="server"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-primary" ID="UserNameBtn" runat="server" OnClick="UserNameBtn_Click"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Full Name" ID="FullNameTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <div class="form-group">
                                    <label>Account Status</label>
                                    <div class="input-group">

                                        <asp:TextBox CssClass="form-control mr-1" placeholder="Status" ID="AccountStatusTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-success mr-1" ID="ActiveBtn" runat="server" OnClick="ActiveBtn_Click"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-warning mr-1" ID="PendingBtn" runat="server" OnClick="PendingBtn_Click"><i class="fa-regular fa-circle-pause"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-danger mr-1" ID="DeleteBtn" runat="server" OnClick="DeleteBtn_Click"><i class="fa-regular fa-circle-xmark"></i></asp:LinkButton>
                                    </div>

                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>DOB</label>
                                    <asp:TextBox CssClass="form-control" placeholder="DOB" ID="DOBTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Contact Number</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Contact Number" ID="ContactNumberTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Email" ID="EmailTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>District</label>
                                    <asp:TextBox CssClass="form-control" placeholder="District" ID="DistrictTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>City</label>
                                    <asp:TextBox CssClass="form-control" placeholder="City" ID="CityTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Postal Code</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Postal Code" ID="PostalCodeTxt" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Address</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Address" ID="AddressTxt" TextMode="MultiLine" Rows="3" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <asp:Button CssClass="btn btn-danger btn-block btn-lg" ID="DeleteUserBtn" runat="server" Text="Delete User" OnClick="DeleteUserBtn_Click" />
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
                                <h5>User List</h5>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [user_tbl]"></asp:SqlDataSource>
                                <asp:GridView CssClass="table table-striped table-bordered" ID="UserListTbl" runat="server" AutoGenerateColumns="False" DataKeyNames="user_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="user_id" HeaderText="Username" ReadOnly="True" SortExpression="user_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="contact_number" HeaderText="Contact No." SortExpression="contact_number" />
                                        <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
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
