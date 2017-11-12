<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BR.Login" %>

<!DOCTYPE html>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet.css" rel="stylesheet"  />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <h2>Login</h2>
    <div class ="row">
        <div class="col-md-6">
            <asp:Label ID="Label1" runat="server" Text="UserName: " CssClass="myLabel"></asp:Label>
           
            <asp:TextBox ID="txtUserName" runat="server" CssClass="myTxtBox" Width="130px"></asp:TextBox>
             
        </div>
        </br>
    </div>
    <div class="row">
        <div class="col-md-6">
            <asp:Label ID="Label2" runat="server" Text="Password: " CssClass="myLabel"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="myTxtBox" Width="130px"></asp:TextBox>
        </div>
        </br>
    </div>
        
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" style="height: 26px" Text="Login" />
            <asp:HyperLink ID="hypRegister" runat="server" NavigateUrl="~/Register.aspx">Create User</asp:HyperLink>
        
        <asp:Label ID="lblError" runat="server" ForeColor="Black" hidden ="true"></asp:Label>
    </div>




       
       
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
<script src="JavaScript1.js"></script>

       
    </form>
        
</body>
</html>
