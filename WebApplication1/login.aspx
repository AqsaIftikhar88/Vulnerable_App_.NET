<%@ Page Title="" Language="C#"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <link href="CSS/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="login-container">
    <h2 class="login-header">Login</h2>
        <div class="form-group">
            <label for="username">Username</label>
             <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Enter your username"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Username is required." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="password">Password</label>
             <asp:TextBox ID="TextBox2" runat="server" class="form-control" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
              <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ControlToValidate="TextBox2" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <%--<asp:Button ID="Button1" class="btn btn-custom btn-block" runat="server" Text="Login" OnClick="Button1_Click" />--%>
        <asp:Button ID="Button1" runat="server" Text="Login" type="submit" class="btn btn-custom btn-block" OnClick="Button1_Click" />
       <%-- <button type="submit" class="btn btn-custom btn-block">Login</button>--%>
    <div class="text-center mt-3">
        <a href="Register.aspx">Don't have an account? Register here</a>
    </div>
</div>

<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

</asp:Content>
