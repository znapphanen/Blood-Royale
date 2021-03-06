﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BR._default" %>


<!DOCTYPE html>
<%@  Register Src="UserControls/Nav.ascx" TagName="Nav" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet.css" rel="stylesheet"  />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
        <uc1:Nav ID="Nav1" runat="server" />
        
        <asp:GridView ID="gvGameList" runat="server" DataSourceID="odsGameList" AutoGenerateColumns="False" OnRowCommand="gvGameList_RowCommand" OnRowDataBound="gvGameList_RowDataBound">
            <Columns>
                <asp:BoundField DataField="gameId" HeaderText="Id" ReadOnly="True"  SortExpression="gameId" />

                <asp:TemplateField HeaderText="Name">                
                    <ItemTemplate>
                        <asp:LinkButton ID="lbViewGame" runat="server"  Text='<%#Eval("Gamename") %>' CommandName="ViewGame" CommandArgument='<%#Eval("GameId") %>'></asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>

                
                <asp:BoundField DataField="turn" HeaderText="Turn" ReadOnly="True" SortExpression="turn" />
                 <asp:TemplateField>                
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDeleteGame" runat="server" Text='Delete' CommandName="DeleteGame" CommandArgument='<%#Eval("GameId") %>'  Visible="false"></asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsGameList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetGames" TypeName="BR.Model.GameCollection">
            <SelectParameters>
                <asp:SessionParameter Name="userId" SessionField="LoggedInUserId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource> 
        </br>

        <asp:Panel ID="PanelCreateGame" runat="server" BorderColor="Black" BorderWidth="3">
            <asp:Label ID="lblCreateGame" runat="server" Text="Create game" Font-Size="Larger"></asp:Label>
            <div class="row">
                <asp:Label ID="Label1" runat="server" Text="Game Name"></asp:Label>
                <asp:TextBox ID="txtGameName" runat="server"  ></asp:TextBox>
            </div>    
            <div class="row">  
                
                <asp:CheckBox ID="cbEngland" runat="server" Text="England" OnCheckedChanged="cbEngland_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBox ID="cbFrance" runat="server" Text="France" OnCheckedChanged="cbFrance_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBox ID="cbGermany" runat="server" Text="Germany" OnCheckedChanged="cbGermany_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBox ID="cbItaly" runat="server" Text="Italy" OnCheckedChanged="cbItaly_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBox ID="cbSpain" runat="server" Text="Spain" OnCheckedChanged="cbSpain_CheckedChanged" AutoPostBack="true" />
            </div>
            <div class="row">
                <asp:Label ID="lblDynasty" runat="server" Text="Dynasty"></asp:Label> 
                <div class="col-md-12">
                    <asp:DropDownList ID="ddlEngland" runat="server" Visible="false" > </asp:DropDownList>
                    
                </div> 
                <section class="col">
                     <asp:DropDownList ID="ddlFrance" runat="server" Visible="false"></asp:DropDownList>
                </section> 
                <section class="col">
                     <asp:DropDownList ID="ddlGermany" runat="server" Visible="false"></asp:DropDownList>
                </section> 
                <section class="col">
                    <asp:DropDownList ID="ddlItaly" runat="server" Visible="false"></asp:DropDownList>
                </section> 
                <section class="col">
                    <asp:DropDownList ID="ddlSpain" runat="server" Visible="false"></asp:DropDownList>
                </section> 
                
               
               
                
                
            </div> <!-- row  -->

            <div class="row">
                <asp:Label ID="lblPlayer" runat="server" Text="Player"></asp:Label>
                <asp:DropDownList ID="ddlEnglandPlayer" runat="server" Visible="false"   > </asp:DropDownList>
                <asp:DropDownList ID="ddlFrancePlayer" runat="server" Visible="false"></asp:DropDownList>
                <asp:DropDownList ID="ddlGermanyPlayer" runat="server" Visible="false"></asp:DropDownList>
                <asp:DropDownList ID="ddlItalyPlayer" runat="server" Visible="false"></asp:DropDownList>
                <asp:DropDownList ID="ddlSpainPlayer" runat="server" Visible="false"></asp:DropDownList>
            </div>

            <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
            <div class="row">
                <asp:Label ID="lblError" runat="server" Text="" Hidden=" true"></asp:Label>
            </div>

        </asp:Panel>
        The creator of the game can run everything and sees everything.<br/>
        Players can be added to the countries and they have a limited view.



        <asp:ScriptManager ID="ScriptManagerDeleteGame" runat="server"></asp:ScriptManager>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDeleteGame" runat="server" BackgroundCssClass="modalBackground" CancelControlID="btnCancel" TargetControlID="btnToFoolModalPopUp" PopupControlID="PanelDeleteGame"></ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="PanelDeleteGame" runat="server" BackColor="White" CssClass="modalPopup" Width="250" Height="70">
            Do you want to delete the game <br/>
            <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" style="margin-left: 5px" Width="60px" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" />
        </asp:Panel>

           <asp:Button ID="btnToFoolModalPopUp" runat="server" Text="Button" style = "display:none" /> 
    </form>

         <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <script src="JavaScript1.js"></script>
</body>
</html>
