<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="LibraryManagementSystem.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto my-3">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <img src="imgs/general-user.png" width="80px" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h5>User Registration</h5>
                            </div>
                        </div>
                        <hr />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Full Name" ID="FullNameTxt" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Date of Birth</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Date of Birth" ID="DateOfBirthTxt" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Contact Number</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Contact Number" ID="ContactNumberTxt" runat="server" TextMode="Phone"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Email" ID="EmailTxt" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>District</label>
                                    <asp:DropDownList CssClass="form-control" ID="DistrictDrp" runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Colombo" Value="Colombo" />
                                        <asp:ListItem Text="Gampaha" Value="Gampaha" />
                                        <asp:ListItem Text="Kaluthara" Value="Kaluthara" />
                                        <asp:ListItem Text="Galle" Value="Galle" />
                                        <asp:ListItem Text="Mathara" Value="Mathara" />
                                        <asp:ListItem Text="Hambanthota" Value="Hambanthota" />
                                        <asp:ListItem Text="Kandy" Value="Kandy" />
                                        <asp:ListItem Text="Kurunegala" Value="Kurunegala" />

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>City</label>
                                    <asp:TextBox CssClass="form-control" placeholder="City" ID="CityTxt" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Postal Code" ID="PostalCodeTxt" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Address</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Address" ID="AddressTxt" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col text-center">
                                <h4><span class="badge badge-pill badge-info">User Credentials</span></h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>User Name</label>
                                    <asp:TextBox CssClass="form-control" placeholder="User Name" ID="UserNameTxt" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Password" ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="SignUpBtn" runat="server" Text="Sign Up" OnClick="SignUpBtn_Click" />
                        </div>
                    </div>


                </div>
                <a style="text-decoration: none" href="./homepage.aspx"><< Back to Home Page</a>
            </div>


        </div>
    </div>


</asp:Content>
