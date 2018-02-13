<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CharacterList2.aspx.cs" Inherits="BR.CharacterList2" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="UserControls/Nav.ascx" TagName="Nav" TagPrefix="uc1" %>



    


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    
    <uc1:Nav ID="Nav1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    
     <asp:Panel ID="panelCharacterList" runat="server">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Panel ID="panelEnglandCharacterList" runat="server" Visible=" false">
                            <asp:Image ID="ImageEngland" runat="server" Height="50" Width="100" ImageUrl="~/images/800px-Flag_of_England.svg.png" />
                        
                            <asp:Label ID="Label1" runat="server" Text="England" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                            <div class="table-responsive">
                            <asp:GridView ID="gvEnglandCharacterList" runat="server" AutoGenerateColumns="False" DataSourceID="odsEnglandCharacterList" OnRowCommand ="characterList_RowCommand" OnRowDataBound="characterList_RowDataBound" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="characterId" HeaderText="Id" ReadOnly="True" SortExpression="characterId" />
                                <asp:BoundField DataField="firstName" HeaderText="Name" ReadOnly="True" SortExpression="firstName" />
                                <asp:BoundField DataField="str" HeaderText="Str" ReadOnly="True" SortExpression="str" />
                                <asp:BoundField DataField="cha" HeaderText="Cha" ReadOnly="True" SortExpression="cha" />
                                <asp:BoundField DataField="con" HeaderText="Con" ReadOnly="True" SortExpression="con" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                                <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />                               
                                <asp:BoundField DataField="age" HeaderText="Age" ReadOnly="True" SortExpression="age" />
                                <asp:BoundField DataField="dynastyName" HeaderText="Dynasty" ReadOnly="True" SortExpression="dynastyName" />
                                <asp:TemplateField Visible="true" HeaderText="Spouse Id">
                            <ItemTemplate>
                                <asp:LinkButton ID="spouseidbtn" runat="server" Text='<%#Eval("spouseId")  %>' CommandName="showSpouse" CommandArgument='<%#Eval("spouseId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                              
                                <asp:CheckBoxField DataField="Prisoner" HeaderText="Prisoner" ReadOnly="True" SortExpression="Prisoner" />
                                <asp:TemplateField Visible="true" HeaderText="Change Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbChangeName" runat="server" Text="Change Name" CommandName="ChangeName" CommandArgument='<%#Eval("characterId")  %>' Class="btn btn-primary btn-xs"></asp:LinkButton>
                                    </ItemTemplate>                          
                                </asp:TemplateField>
                                <asp:TemplateField Visible="true" HeaderText="New Name">
                                    <ItemTemplate>
                                        <asp:TextBox ID="newName" runat="server"></asp:TextBox>   
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                    
                            </asp:GridView>
                    </div>
                <asp:ObjectDataSource ID="odsEnglandCharacterList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllCharacters" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="EnglandDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
                    </div>
                </div>
            </div>
            <asp:Panel ID="panelFranceCharacterList" runat="server" Visible=" false">
                 <asp:Image ID="ImageFrance" runat="server" Height="50" Width="100" ImageUrl="~/images/800px-Flag_of_France_(XIV-XVI).svg.png" />
             
                <asp:Label ID="Label3" runat="server" Text="France" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                <asp:GridView ID="gvFranceCharacterList" runat="server" AutoGenerateColumns="False" DataSourceID="odsFranceCharacterList" OnRowCommand ="characterList_RowCommand" OnRowDataBound="characterList_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="Id" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="Name" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="Str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="Cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="Con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />                               
                        <asp:BoundField DataField="age" HeaderText="Age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="Dynasty" ReadOnly="True" SortExpression="dynastyName" />
                        <asp:TemplateField Visible="true" HeaderText="Spouse Id">
                            <ItemTemplate>
                                <asp:LinkButton ID="spouseidbtn" runat="server" Text='<%#Eval("spouseId")  %>' CommandName="showSpouse" CommandArgument='<%#Eval("spouseId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                     
                        <asp:CheckBoxField DataField="Prisoner" HeaderText="Prisoner" ReadOnly="True" SortExpression="Prisoner" />
                        <asp:TemplateField Visible="true" HeaderText="Change Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbChangeName" runat="server" Text="Change Name" CommandName="ChangeName" CommandArgument='<%#Eval("characterId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                        <asp:TemplateField Visible="true" HeaderText="New Name">
                            <ItemTemplate>
                                <asp:TextBox ID="newName" runat="server"></asp:TextBox>   
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsFranceCharacterList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllCharacters" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="FranceDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>

            <asp:Panel ID="panelGermanyCharacterList" runat="server" Visible=" false">
                <asp:Image ID="ImageGermany" runat="server" Height="50" Width="100" ImageUrl="~/images/Banner_of_Charles_V_as_Holy_Roman_Emperor.svg" />
         
                <asp:Label ID="Label2" runat="server" Text="Germany" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                <asp:GridView ID="gvGermanyCharacterList" runat="server" AutoGenerateColumns="False" DataSourceID="odsGermanyCharacterList" OnRowCommand ="characterList_RowCommand" OnRowDataBound="characterList_RowDataBound">
                    <Columns>
                                <asp:BoundField DataField="characterId" HeaderText="Id" ReadOnly="True" SortExpression="characterId" />
                                <asp:BoundField DataField="firstName" HeaderText="Name" ReadOnly="True" SortExpression="firstName" />
                                <asp:BoundField DataField="str" HeaderText="Str" ReadOnly="True" SortExpression="str" />
                                <asp:BoundField DataField="cha" HeaderText="Cha" ReadOnly="True" SortExpression="cha" />
                                <asp:BoundField DataField="con" HeaderText="Con" ReadOnly="True" SortExpression="con" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                                <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />                               
                                <asp:BoundField DataField="age" HeaderText="Age" ReadOnly="True" SortExpression="age" />
                                <asp:BoundField DataField="dynastyName" HeaderText="Dynasty" ReadOnly="True" SortExpression="dynastyName" />
                                <asp:TemplateField Visible="true" HeaderText="Spouse Id">
                            <ItemTemplate>
                                <asp:LinkButton ID="spouseidbtn" runat="server" Text='<%#Eval("spouseId")  %>' CommandName="showSpouse" CommandArgument='<%#Eval("spouseId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
               
                        <asp:CheckBoxField DataField="Prisoner" HeaderText="Prisoner" ReadOnly="True" SortExpression="Prisoner" />
                        <asp:TemplateField Visible="true" HeaderText="Change Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbChangeName" runat="server" Text="Change Name" CommandName="ChangeName" CommandArgument='<%#Eval("characterId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                        <asp:TemplateField Visible="true" HeaderText="New Name">
                            <ItemTemplate>
                                <asp:TextBox ID="newName" runat="server"></asp:TextBox>   
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsGermanyCharacterList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllCharacters" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="GermanyDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>            

            <asp:Panel ID="panelItalyCharacterList" runat="server" Visible=" false">
                <asp:Image ID="ImageItaly" runat="server" Height="50" Width="100" ImageUrl="~/images/it_ven3.gif" />
          
                <asp:Label ID="Label4" runat="server" Text="Italy" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                <asp:GridView ID="gvItalyCharacterList" runat="server" AutoGenerateColumns="False" DataSourceID="odsItalyCharacterList" OnRowCommand ="characterList_RowCommand" OnRowDataBound="characterList_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="Id" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="Name" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="Str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="Cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="Con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />                               
                        <asp:BoundField DataField="age" HeaderText="Age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="Dynasty" ReadOnly="True" SortExpression="dynastyName" />
                        <asp:TemplateField Visible="true" HeaderText="Spouse Id">
                            <ItemTemplate>
                                <asp:LinkButton ID="spouseidbtn" runat="server" Text='<%#Eval("spouseId")  %>' CommandName="showSpouse" CommandArgument='<%#Eval("spouseId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
             
                        <asp:CheckBoxField DataField="Prisoner" HeaderText="Prisoner" ReadOnly="True" SortExpression="Prisoner" />
                        <asp:TemplateField Visible="true" HeaderText="Change Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbChangeName" runat="server" Text="Change Name" CommandName="ChangeName" CommandArgument='<%#Eval("characterId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                        <asp:TemplateField Visible="true" HeaderText="New Name">
                            <ItemTemplate>
                                <asp:TextBox ID="newName" runat="server"></asp:TextBox>   
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsItalyCharacterList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllCharacters" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="ItalyDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>

            <asp:Panel ID="panelSpainCharacterList" runat="server" Visible=" false">
                <asp:Image ID="ImageSpain" runat="server" Height="50" Width="100" ImageUrl="~/images/Flag_of_Cross_of_Burgundy.svg.png" />
             
                <asp:Label ID="Label5" runat="server" Text="Spain" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                <asp:GridView ID="gvSpainCharacterList" runat="server" AutoGenerateColumns="False" DataSourceID="odsSpainCharacterList" OnRowCommand ="characterList_RowCommand"  OnRowDataBound="characterList_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="Id" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="Name" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="Str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="Cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="Con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />                               
                        <asp:BoundField DataField="age" HeaderText="Age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="Dynasty" ReadOnly="True" SortExpression="dynastyName" />
                        
              
                        <asp:TemplateField Visible="true" HeaderText="Spouse Id">
                            <ItemTemplate>
                                <asp:LinkButton ID="spouseidbtn" runat="server" Text='<%#Eval("spouseId")  %>' CommandName="showSpouse" CommandArgument='<%#Eval("spouseId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>

                        <asp:CheckBoxField DataField="Prisoner" HeaderText="Prisoner" ReadOnly="True" SortExpression="Prisoner" />
                        <asp:TemplateField Visible="true" HeaderText="Change Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbChangeName" runat="server" Text="Change Name" CommandName="ChangeName" CommandArgument='<%#Eval("characterId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                        <asp:TemplateField Visible="true" HeaderText="New Name">
                            <ItemTemplate>
                                <asp:TextBox ID="newName" runat="server"></asp:TextBox>   
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsSpainCharacterList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllCharacters" TypeName="BR.Model.CharacterCollection"  >
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="SpainDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
         <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
             
        </asp:Panel>
    <ajaxToolkit:ModalPopupExtender 
            ID="ModalPopupExtenderSpouse" runat="server" 
            PopupControlID="panelSpouse" 
            BehaviorID="ModalPopupExtenderSpouse" 
            TargetControlID="btnToFoolModalPopUp" 
            BackgroundCssClass="modalBackground"  
            CancelControlID="btn_Cancel"        
            DropShadow="True">

        </ajaxToolkit:ModalPopupExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Button ID="btnToFoolModalPopUp" runat="server" Text="Button" style = "display:none" /> 
    <asp:Panel ID="panelSpouse" runat="server" CssClass="modalpopup" BackColor="White">
        <asp:Image ID="imgSpouseFlag"  Height="10" Width="20" runat="server" /><asp:Label ID="lblSpouseInfo" runat="server" Text=""></asp:Label>
        <asp:Button ID="btn_Cancel" runat="server" Text="Ok" />
    </asp:Panel>

   
</asp:Content>
