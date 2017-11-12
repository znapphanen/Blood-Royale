<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BR.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="row" >
        <asp:Label ID="UserName" runat="server" Text="UserName"></asp:Label>
        <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="tbUserName" CssClass="ValidationError" ErrorMessage="&laquo; (Required)" ToolTip="User Name is a REQUIRED field"></asp:RequiredFieldValidator>
    </div>
    <div class="row">
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword" CssClass="ValidationError" ErrorMessage="&laquo; (Required)" ToolTip="Password is a REQUIRED field"></asp:RequiredFieldValidator>
    </div>
    <div class="row">
        <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="tbConfirmPassword" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbConfirmPassword" CssClass="ValidationError" ControlToCompare="tbPassword" ErrorMessage="No Match"  ToolTip="Password must be the same" />
        <asp:RequiredFieldValidator ID="rfvComapare" runat="server" ControlToValidate="tbConfirmPassword" CssClass="ValidationError" ErrorMessage="&laquo; (Required)" ToolTip="Confirm Password is a REQUIRED field"></asp:RequiredFieldValidator>

         </div>
        <div class="row">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbEmail" runat="server" ValidationExpression =".+@.+"  class="icon-danger"  ErrorMessage="Must be a email."></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" CssClass="ValidationError" ErrorMessage="&laquo; (Required)" ToolTip="Email is a REQUIRED field"></asp:RequiredFieldValidator>
        </div>
        <div class="row">
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"></asp:Button>
        </div>

    </form>
</body>
</html>
