<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="LibraryManagementSystem.adminlogin" %>
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
                                <img src="imgs/admin-user.png" width="130px"/>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h3>Admin Login</h3>
                            </div>
                        </div>
                        <hr />
                        
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Admin ID</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Admin ID" ID="AdminIdTxt" runat="server" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox CssClass="form-control" placeholder="Password" ID="PasswordTxt" runat="server" TextMode="Password" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
               
                
            </div>
        </div>
    </div>

</asp:Content>
