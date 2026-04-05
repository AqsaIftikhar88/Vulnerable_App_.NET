<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="WebApplication1.users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <link href="CSS/register.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="username-display text-center">
    <h2>
        <asp:Label ID="LabelUsername" runat="server" CssClass="username-label"></asp:Label>
    </h2>
</div>


        <div class="register-container my-0">
        <%--<center><asp:Label ID="LabelGreeting" runat="server" CssClass="h2"></asp:Label></center>--%>
    <h3 class="register-header">Update Password</h3>
        <div class="form-group">
    <label for="email">Email address</label>
     <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="user@example.com" readonly="true"></asp:TextBox>
    <%--<input type="email" class="form-control" id="email" placeholder="Enter your email" value="user@example.com" readonly>--%>
</div>
                        <div class="form-group">
    <label for="password">Old Password</label>
    <input type="password" class="form-control" id="password" name="password" runat="server" placeholder="Old password" required>
</div>
<div class="form-group">
    <label for="newpassword">New Password</label>
    <input type="password" class="form-control" id="newpassword" name="newpassword" runat="server" placeholder="Create a password" required>
</div>
<div class="form-group">
    <label for="confirmpassword">Confirm Password</label>
    <input type="password" class="form-control" id="confirmpassword" name="confirmpassword" runat="server" placeholder="Confirm your password" required>
</div>
            <asp:Button ID="Button1" runat="server" Text="Update" type="submit" class="btn btn-custom btn-block" OnClick="Button1_Click" />

        <%--<div class="form-group">
            <label for="password">Old Password</label>
            <input type="password" class="form-control" id="password" placeholder="Old password" required>
        </div>
          <div class="form-group">
      <label for="password">New Password</label>
      <input type="password" class="form-control" id="newpassword" placeholder="Create a password" required>
  </div>
        <div class="form-group">
            <label for="confirmPassword">Confirm Password</label>
            <input type="password" class="form-control" id="confirmpassword" placeholder="Confirm your password" required>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Update" type="submit" class="btn btn-custom btn-block" OnClick="Button1_Click" />
       --%>
</div>

    
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
