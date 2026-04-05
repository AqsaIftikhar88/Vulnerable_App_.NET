<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebApplication1.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <link href="CSS/register.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center><h2 class="m-0 p-0">Hello Admin</h2></center>
    <div class="container ">
        <div class="row">
            <!-- Form Column -->
            <div class="col-md-6">
                <div class="register-container my-0 py-0">
                    <h2 class="register-header">Register</h2>
                    <div class="form-group">
                        <label for="username">Search Username</label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="username"></asp:TextBox>
                    </div>

<%--                    <div class="form-group">
                        <label for="email">Email address</label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="email@123.com" ReadOnly="true"></asp:TextBox>

                    </div>--%>

                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-custom btn-block my-3 mb-7" Text="Delete User" OnClick="Button1_Click" />
                </div>
            </div>

            <!-- GridView Column -->
            <div class="col-md-6">
                <h2>Users List</h2>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:webprojectConnectionString %>" SelectCommand="SELECT [user_name], [email_address] FROM [user_table]"></asp:SqlDataSource>
                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="user_name" HeaderText="user_name" SortExpression="user_name" />
                        <asp:BoundField DataField="email_address" HeaderText="email_address" SortExpression="email_address" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
