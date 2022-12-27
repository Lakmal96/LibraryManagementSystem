<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="LibraryManagementSystem.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <section>
        <img src="imgs/home.jpg" class="img-fluid" />
    </section>

    <section>
        <div class="container">
            <div class="row text-center">
                <div class="col-12">
                    <h1>Features</h1>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 text-center">
                    <img src="imgs/books.png" width="150px" />
                    <h4>Digital Inventory</h4>
                    <p class="text-justify">
                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                        when an unknown printer took a galley of type and scrambled it to make a type specimen book.
                    </p>
                </div>
                <div class="col-md-4 text-center">
                    <img src="imgs/books.png" width="150px" />
                    <h4>Search Books</h4>
                    <p class="text-justify">
                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                        when an unknown printer took a galley of type and scrambled it to make a type specimen book.
                    </p>
                </div>
                <div class="col-md-4 text-center">
                    <img src="imgs/books.png" width="150px" />
                    <h4>Variety of Books</h4>
                    <p class="text-justify">
                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                        when an unknown printer took a galley of type and scrambled it to make a type specimen book.
                    </p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
