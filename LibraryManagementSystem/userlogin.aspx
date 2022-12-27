<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="LibraryManagementSystem.userlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto my-3">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <img src="imgs/general-user.png" width="130px" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h3>User Login</h3>
                            </div>
                        </div>
                        <hr />

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>User Name</label>
                                    <asp:TextBox CssClass="form-control" placeholder="User Name" ID="UserNameTxt" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Password" ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
                                </div>
                                <div class="form-group">
                                    <a href="usersignup.aspx">
                                        <input id="SignUpBtn" class="btn btn-info btn-block btn-lg" type="button" value="Sign Up" /></a>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <a style="text-decoration: none" href="./homepage.aspx"><< Back to Home Page</a>

            </div>
        </div>
    </div>

</asp:Content>
