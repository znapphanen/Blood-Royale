<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="BR.Main" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>
<%@ Register Src="UserControls/Nav.ascx" TagName="Nav" TagPrefix="uc1" %>
<%-- Rem--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet.css" rel="stylesheet"  />
    <title></title>
    <script src="jquery-3.2.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Nav ID="Nav1" runat="server" />
        <asp:Panel ID="panelDynasticSequence" runat="server" Height="276px" Visible ="false">
            <asp:Label ID="lblYear" runat="server" Text=""></asp:Label>

            <asp:Button ID="btnDynasticSequence" runat="server" Text="Next phase" OnClick="btnDynasticSequence_Click" />
            <div class="row" >
                <asp:Label ID="lblGame" runat="server" Text=""></asp:Label>
            </div>
            <div class="row" >
                <asp:Label ID="lblPhase" runat="server" Text=""></asp:Label>
            </div>
        </asp:Panel>
        <asp:Panel ID="panelBirth" runat="server" Height="276px" Visible =" false">
          
            <asp:Panel ID="panelEnglandBirth" runat="server" Height="276px" Visible ="false">
                <asp:Image ID="ImageEnglandBirth" runat="server" Height="50" Width="100" ImageUrl="~/images/800px-Flag_of_England.svg.png" />
                <asp:Label ID="Label6" runat="server" Text="England"></asp:Label>
                <asp:GridView ID="gvEnglandBreeders" runat="server" AutoGenerateColumns="False" DataSourceID="odsEnglandBreeders" OnRowCommand ="breeders_RowCommand" OnRowDataBound ="gvBreeders_OnRowDataBound">
                    <Columns>
                        <asp:BoundField DataField="BirthRollesMade" HeaderText="BirthRollesMade" ReadOnly="True" SortExpression="BirthRollesMade"  />
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />                    
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:TemplateField Visible="true" HeaderText="Breed">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbBreed" runat="server" Text="Breed" CommandName="Breed" CommandArgument='<%#Eval("characterId") %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>
                            
                        </asp:TemplateField>   
                                         
                    </Columns>

                </asp:GridView>
                <asp:ObjectDataSource ID="odsEnglandBreeders" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getBreedingCharacters" TypeName="BR.Model.CharacterCollection" >
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="gameId" SessionField="GameId" Type="Int32" />
                        <asp:SessionParameter DefaultValue="" Name="dynastyId" SessionField="EnglandDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Label ID="Label1" runat="server" Text="NewBorns"></asp:Label>
                <asp:GridView ID="gvEnglandNewBorn" runat="server" AutoGenerateColumns="False" DataSourceID="odsEnglandNewBorn" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:BoundField DataField="born" HeaderText="born" ReadOnly="True" SortExpression="born" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsEnglandNewBorn" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getNewlyBorns" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="gameId" SessionField="GameId" Type="Int32" />
                        <asp:SessionParameter Name="dynastyId" SessionField="EnglandDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>

            <asp:Panel ID="panelFranceBirth" runat="server" Height="276px" Visible ="false">
                <asp:Image ID="ImageFranceBirth" runat="server" Height="50" Width="100" ImageUrl="~/images/800px-Flag_of_France_(XIV-XVI).svg.png" />
                <asp:Label ID="Label7" runat="server" Text="France"></asp:Label>
                <asp:GridView ID="gvFranceBreeders" runat="server" AutoGenerateColumns="False" DataSourceID="odsFranceBreeders" OnRowCommand ="breeders_RowCommand" OnRowDataBound ="gvBreeders_OnRowDataBound">
                    <Columns>
                        <asp:BoundField DataField="BirthRollesMade" HeaderText="BirthRollesMade" ReadOnly="True" SortExpression="BirthRollesMade"  />
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />                    
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:TemplateField Visible="true" HeaderText="Breed">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbBreed" runat="server" Text="Breed" CommandName="Breed" CommandArgument='<%#Eval("characterId") %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                    </Columns>
               
                </asp:GridView>
                <asp:ObjectDataSource ID="odsFranceBreeders" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getBreedingCharacters" TypeName="BR.Model.CharacterCollection" >
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="gameId" SessionField="GameId" Type="Int32" />
                        <asp:SessionParameter DefaultValue="" Name="dynastyId" SessionField="FranceDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Label ID="Label2" runat="server" Text="NewBorns"></asp:Label>
                <asp:GridView ID="gvFranceNewBorn" runat="server" AutoGenerateColumns="False" DataSourceID="odsFranceNewBorn" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:BoundField DataField="born" HeaderText="born" ReadOnly="True" SortExpression="born" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsFranceNewBorn" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getNewlyBorns" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="gameId" SessionField="GameId" Type="Int32" />
                        <asp:SessionParameter Name="dynastyId" SessionField="FranceDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>

            <asp:Panel ID="panelGermanyBirth" runat="server" Height="276px" Visible ="false">
                <asp:Image ID="ImageGermanyBirth" runat="server" Height="50" Width="100" ImageUrl="~/images/Banner_of_Charles_V_as_Holy_Roman_Emperor.svg" />
                <asp:Label ID="Label8" runat="server" Text="Germany"></asp:Label>
                <asp:GridView ID="gvGermanyBreeders" runat="server" AutoGenerateColumns="False" DataSourceID="odsGermanyBreeders" OnRowCommand ="breeders_RowCommand" OnRowDataBound ="gvBreeders_OnRowDataBound">
                    <Columns>
                        <asp:BoundField DataField="BirthRollesMade" HeaderText="BirthRollesMade" ReadOnly="True" SortExpression="BirthRollesMade"  />
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />                    
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:TemplateField Visible="true" HeaderText="Breed">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbBreed" runat="server" Text="Breed" CommandName="Breed" CommandArgument='<%#Eval("characterId") %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                    </Columns>
               
                </asp:GridView>
                <asp:ObjectDataSource ID="odsGermanyBreeders" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getBreedingCharacters" TypeName="BR.Model.CharacterCollection" >
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="gameId" SessionField="GameId" Type="Int32" />
                        <asp:SessionParameter DefaultValue="" Name="dynastyId" SessionField="GermanyDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Label ID="Label3" runat="server" Text="NewBorns"></asp:Label>
                <asp:GridView ID="gvGermanyNewBorn" runat="server" AutoGenerateColumns="False" DataSourceID="odsGermanyNewBorn" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:BoundField DataField="born" HeaderText="born" ReadOnly="True" SortExpression="born" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsGermanyNewBorn" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getNewlyBorns" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="gameId" SessionField="GameId" Type="Int32" />
                        <asp:SessionParameter Name="dynastyId" SessionField="GermanyDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>

            <asp:Panel ID="panelItalyBirth" runat="server" Height="276px" Visible ="false">
                 <asp:Image ID="ImageItalyBirth" runat="server" ImageUrl="~/images/it_ven3.gif" Height="50" Width="100" />
                <asp:Label ID="Label9" runat="server" Text="Italy"></asp:Label>
                <asp:GridView ID="gvItalyBreeders" runat="server" AutoGenerateColumns="False" DataSourceID="odsItalyBreeders" OnRowCommand ="breeders_RowCommand" OnRowDataBound ="gvBreeders_OnRowDataBound">
                    <Columns>
                        <asp:BoundField DataField="BirthRollesMade" HeaderText="BirthRollesMade" ReadOnly="True" SortExpression="BirthRollesMade"  />
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />                    
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:TemplateField Visible="true" HeaderText="Breed">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbBreed" runat="server" Text="Breed" CommandName="Breed" CommandArgument='<%#Eval("characterId") %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                    </Columns>
               
                </asp:GridView>
                <asp:ObjectDataSource ID="odsItalyBreeders" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getBreedingCharacters" TypeName="BR.Model.CharacterCollection" >
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="gameId" SessionField="GameId" Type="Int32" />
                        <asp:SessionParameter DefaultValue="" Name="dynastyId" SessionField="ItalyDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Label ID="Label4" runat="server" Text="NewBorns"></asp:Label>
                <asp:GridView ID="gvItalyNewBorn" runat="server" AutoGenerateColumns="False" DataSourceID="odsItalyNewBorn" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:BoundField DataField="born" HeaderText="born" ReadOnly="True" SortExpression="born" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsItalyNewBorn" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getNewlyBorns" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="gameId" SessionField="GameId" Type="Int32" />
                        <asp:SessionParameter Name="dynastyId" SessionField="ItalyDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>

            <asp:Panel ID="panelSpainBirth" runat="server" Height="276px" Visible ="false">
                <asp:Image ID="ImageSpainBirth" runat="server" ImageUrl="~/images/Flag_of_Cross_of_Burgundy.svg.png" Height="50" Width="100" />
                <asp:Label ID="Label10" runat="server" Text="Spain"></asp:Label>
                <asp:GridView ID="gvSpainBreeders" runat="server" AutoGenerateColumns="False" DataSourceID="odsSpainBreeders" OnRowCommand ="breeders_RowCommand" OnRowDataBound ="gvBreeders_OnRowDataBound">
                    <Columns>
                        <asp:BoundField DataField="BirthRollesMade" HeaderText="BirthRollesMade" ReadOnly="True" SortExpression="BirthRollesMade"  />
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />                    
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:TemplateField Visible="true" HeaderText="Breed">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbBreed" runat="server" Text="Breed" CommandName="Breed" CommandArgument='<%#Eval("characterId") %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                    </Columns>
               
                </asp:GridView>
                <asp:ObjectDataSource ID="odsSpainBreeders" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getBreedingCharacters" TypeName="BR.Model.CharacterCollection" >
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="gameId" SessionField="GameId" Type="Int32" />
                        <asp:SessionParameter DefaultValue="" Name="dynastyId" SessionField="SpainDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Label ID="Label5" runat="server" Text="NewBorns"></asp:Label>
                <asp:GridView ID="gvSpainNewBorn" runat="server" AutoGenerateColumns="False" DataSourceID="odsSpainNewBorn" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:BoundField DataField="born" HeaderText="born" ReadOnly="True" SortExpression="born" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsSpainNewBorn" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getNewlyBorns" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="gameId" SessionField="GameId" Type="Int32" />
                        <asp:SessionParameter Name="dynastyId" SessionField="SpainDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="panelSurvival" runat="server" Height="276px" Visible =" false">
            <asp:Panel ID="panelEnglandSurvival" runat="server" Height="276px" Visible =" false">
                <asp:Image ID="ImageEnglandSurvuval" runat="server" Height="50" Width="100" ImageUrl="~/images/800px-Flag_of_England.svg.png" />
                <asp:Label ID="Label11" runat="server" Text="Englands New Deaths"></asp:Label>
                <asp:GridView ID="gvEnglandNewDeath" runat="server"></asp:GridView>
            </asp:Panel>

            <asp:Panel ID="panelFranceSurvival" runat="server" Height="276px" Visible =" false">
                    <asp:Image ID="ImageFranceSurvival" runat="server" Height="50" Width="100" ImageUrl="~/images/800px-Flag_of_France_(XIV-XVI).svg.png" />
                <asp:Label ID="Label12" runat="server" Text="France New Deaths"></asp:Label>
                <asp:GridView ID="gvFranceNewDeath" runat="server"></asp:GridView>
            </asp:Panel>

            <asp:Panel ID="panelGermanySurvival" runat="server" Height="276px" Visible =" false">
                <asp:Image ID="ImageGermanySyrvival" runat="server" Height="50" Width="100" ImageUrl="~/images/Banner_of_Charles_V_as_Holy_Roman_Emperor.svg" />
                <asp:Label ID="Label13" runat="server" Text="Germany New Deaths"></asp:Label>
                <asp:GridView ID="gvGermanyNewDeath" runat="server"></asp:GridView>
            </asp:Panel>
            <asp:Panel ID="panelItalySurvival" runat="server" Height="276px" Visible =" false">
                <asp:Image ID="ImageItalySurvival" runat="server" ImageUrl="~/images/it_ven3.gif" Height="50" Width="100" />
                <asp:Label ID="Label14" runat="server" Text="Italy New Deaths"></asp:Label>
                <asp:GridView ID="gvItalyNewDeath" runat="server"></asp:GridView>
            </asp:Panel>
            <asp:Panel ID="panelSpainSurvival" runat="server" Height="276px" Visible =" false">
                <asp:Image ID="ImageSpainSurvival" runat="server" ImageUrl="~/images/Flag_of_Cross_of_Burgundy.svg.png" Height="50" Width="100" />
                <asp:Label ID="Label15" runat="server" Text="Spain New Deaths"></asp:Label>
                <asp:GridView ID="gvSpainNewDeath" runat="server"></asp:GridView>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="panelMarriage"  runat="server" Height="276px" Visible =" false">

            <asp:Panel ID="panelAllMarriage" runat="server">
                <asp:Label ID="Label22" runat="server" Text="All Available For Marriage"></asp:Label>
                <asp:GridView ID="gvAllAvailable" runat="server" AutoGenerateColumns="False" DataSourceID="odsAllAvailable" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                     </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsAllAvailable" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllAvailable" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="gameId" SessionField="GameId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
             <br />
            
            <asp:Panel ID="panelEnglandMarriage" runat="server" Visible="false" >
                <asp:Image ID="ImageEnglandMarraiage" runat="server" Height="50" Width="100" ImageUrl="~/images/800px-Flag_of_England.svg.png" />
                <asp:Label ID="Label17" runat="server" Text="England Available For Marriage"></asp:Label>
                <asp:GridView ID="gvEnglandAvailable" runat="server" AutoGenerateColumns="False" DataSourceID="odsEnglandAvailable" OnRowCommand ="gvEnglandMarriage_RowCommand" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                       
                    <asp:TemplateField Visible="true" HeaderText="Marriage proposal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbPropose" runat="server" Text="Propose" CommandName="Propose" CommandArgument='<%#Eval("characterId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Proposed Id">
                        <ItemTemplate>
                            <asp:TextBox ID="proposedId" runat="server"></asp:TextBox>   
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Contract">
                        <ItemTemplate>
                            <asp:TextBox ID="contract" runat="server" TextMode ="MultiLine"></asp:TextBox>   
                        </ItemTemplate>
                    </asp:TemplateField>
                   </Columns>
                </asp:GridView>

                <asp:Label ID="lblEngProps" runat="server" Text="Available proposals for England"></asp:Label>
                <asp:GridView ID="gvEnglandProposals" runat="server" AutoGenerateColumns="False" DataSourceID="odsEnglandProposals" OnRowCommand="gvEnglandProposals_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="marriageOfferId" HeaderText="marriageOfferId" ReadOnly="True" SortExpression="marriageOfferId" />
                        <asp:BoundField DataField="offererId" HeaderText="offererId" ReadOnly="True" SortExpression="offererId" />
                        <asp:BoundField DataField="targetId" HeaderText="targetId" ReadOnly="True" SortExpression="targetId" />
                        <asp:BoundField DataField="offererDynasty" HeaderText="offererDynasty" ReadOnly="True" SortExpression="offererDynasty" />
                        <asp:BoundField DataField="targetDynasty" HeaderText="targetDynasty" ReadOnly="True" SortExpression="targetDynasty" />
                        <asp:BoundField DataField="contractText" HeaderText="contractText" ReadOnly="True" SortExpression="contractText" />
                        <asp:TemplateField Visible="true" HeaderText="Accept proposal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbAccept" runat="server" Text="Accept" CommandName="Accept" CommandArgument='<%#Eval("marriageOfferId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsEnglandProposals" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getMarriageOffers" TypeName="BR.Model.MarriageOfferCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="EnglandDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="odsEnglandAvailable" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAvailable" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="EnglandDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
            <br />
            
            <asp:Panel ID="panelFranceMarriage" runat="server" Visible="false">
                <asp:Image ID="ImageFranceMarriage" runat="server" Height="50" Width="100" ImageUrl="~/images/800px-Flag_of_France_(XIV-XVI).svg.png" />
                <asp:Label ID="Label18" runat="server" Text="France Available For Marriage"></asp:Label>
                <asp:GridView ID="gvFranceAvailable" runat="server" DataSourceID="odsFranceAvailable" AutoGenerateColumns="False" OnRowCommand ="gvFranceMarriage_RowCommand" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                       
                    <asp:TemplateField Visible="true" HeaderText="Marriage proposal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbPropose" runat="server" Text="Propose" CommandName="Propose" CommandArgument='<%#Eval("characterId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Proposed Id">
                        <ItemTemplate>
                            <asp:TextBox ID="proposedId" runat="server"></asp:TextBox>   
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Contract">
                        <ItemTemplate>
                            <asp:TextBox ID="contract" runat="server" TextMode ="MultiLine"></asp:TextBox>   
                        </ItemTemplate>
                    </asp:TemplateField>
                   </Columns>
                </asp:GridView>

                <asp:Label ID="lblFranceProps" runat="server" Text="Available proposals for France"></asp:Label>
                <asp:GridView ID="gvFranceProposals" runat="server" AutoGenerateColumns="False" DataSourceID="odsFranceProposals" OnRowCommand="gvFranceProposals_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="marriageOfferId" HeaderText="marriageOfferId" ReadOnly="True" SortExpression="marriageOfferId" />
                        <asp:BoundField DataField="offererId" HeaderText="offererId" ReadOnly="True" SortExpression="offererId" />
                        <asp:BoundField DataField="targetId" HeaderText="targetId" ReadOnly="True" SortExpression="targetId" />
                        <asp:BoundField DataField="offererDynasty" HeaderText="offererDynasty" ReadOnly="True" SortExpression="offererDynasty" />
                        <asp:BoundField DataField="targetDynasty" HeaderText="targetDynasty" ReadOnly="True" SortExpression="targetDynasty" />
                        <asp:BoundField DataField="contractText" HeaderText="contractText" ReadOnly="True" SortExpression="contractText" />
                        <asp:TemplateField Visible="true" HeaderText="Accept proposal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbAccept" runat="server" Text="Accept" CommandName="Accept" CommandArgument='<%#Eval("marriageOfferId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsFranceProposals" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getMarriageOffers" TypeName="BR.Model.MarriageOfferCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="FranceDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="odsFranceAvailable" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAvailable" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="FranceDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
             <br />
           
            <asp:Panel ID="panelGermanyMarriage" runat="server" Visible="false">
                 <asp:Image ID="ImageGermanyMarriage" runat="server" Height="50" Width="100" ImageUrl="~/images/Banner_of_Charles_V_as_Holy_Roman_Emperor.svg" />
                <asp:Label ID="Label19" runat="server" Text="Germany Available For Marriage"></asp:Label>
                <asp:GridView ID="gvGermanyAvailable" runat="server" DataSourceID="odsGermanyAvailable" AutoGenerateColumns="False" OnRowCommand ="gvGermanyMarriage_RowCommand" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                       
                    <asp:TemplateField Visible="true" HeaderText="Marriage proposal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbPropose" runat="server" Text="Propose" CommandName="Propose" CommandArgument='<%#Eval("characterId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Proposed Id">
                        <ItemTemplate>
                            <asp:TextBox ID="proposedId" runat="server"></asp:TextBox>   
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Contract">
                        <ItemTemplate>
                            <asp:TextBox ID="contract" runat="server" TextMode ="MultiLine"></asp:TextBox>   
                        </ItemTemplate>
                    </asp:TemplateField>
                   </Columns>
                </asp:GridView>

                <asp:Label ID="lblGermanyProps" runat="server" Text="Available proposals for Germany"></asp:Label>
                <asp:GridView ID="gvGermanyProposals" runat="server" AutoGenerateColumns="False" DataSourceID="odsGermanyProposals" OnRowCommand="gvGermanyProposals_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="marriageOfferId" HeaderText="marriageOfferId" ReadOnly="True" SortExpression="marriageOfferId" />
                        <asp:BoundField DataField="offererId" HeaderText="offererId" ReadOnly="True" SortExpression="offererId" />
                        <asp:BoundField DataField="targetId" HeaderText="targetId" ReadOnly="True" SortExpression="targetId" />
                        <asp:BoundField DataField="offererDynasty" HeaderText="offererDynasty" ReadOnly="True" SortExpression="offererDynasty" />
                        <asp:BoundField DataField="targetDynasty" HeaderText="targetDynasty" ReadOnly="True" SortExpression="targetDynasty" />
                        <asp:BoundField DataField="contractText" HeaderText="contractText" ReadOnly="True" SortExpression="contractText" />
                        <asp:TemplateField Visible="true" HeaderText="Accept proposal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbAccept" runat="server" Text="Accept" CommandName="Accept" CommandArgument='<%#Eval("marriageOfferId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsGermanyProposals" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getMarriageOffers" TypeName="BR.Model.MarriageOfferCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="GermanyDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="odsGermanyAvailable" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAvailable" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="GermanyDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
             <br />
            
            <asp:Panel ID="panelItalyMarriage" runat="server" Visible="false">
                <asp:Image ID="ImageItalyMarriage" runat="server" ImageUrl="~/images/it_ven3.gif" Height="50" Width="100" />
                <asp:Label ID="Label20" runat="server" Text="Italy Available For Marriage"></asp:Label>
                <asp:GridView ID="gvItalyAvailable" runat="server" DataSourceID="odsItalyAvailable" AutoGenerateColumns="False" OnRowCommand ="gvItalyMarriage_RowCommand" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                       
                    <asp:TemplateField Visible="true" HeaderText="Marriage proposal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbPropose" runat="server" Text="Propose" CommandName="Propose" CommandArgument='<%#Eval("characterId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Proposed Id">
                        <ItemTemplate>
                            <asp:TextBox ID="proposedId" runat="server"></asp:TextBox>   
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Contract">
                        <ItemTemplate>
                            <asp:TextBox ID="contract" runat="server" TextMode ="MultiLine"></asp:TextBox>   
                        </ItemTemplate>
                    </asp:TemplateField>
                   </Columns>
                </asp:GridView>

                <asp:Label ID="lblItalyProps" runat="server" Text="Available proposals for Italy"></asp:Label>
                <asp:GridView ID="gvItalyProposals" runat="server" AutoGenerateColumns="False" DataSourceID="odsItalyProposals" OnRowCommand="gvItalyProposals_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="marriageOfferId" HeaderText="marriageOfferId" ReadOnly="True" SortExpression="marriageOfferId" />
                        <asp:BoundField DataField="offererId" HeaderText="offererId" ReadOnly="True" SortExpression="offererId" />
                        <asp:BoundField DataField="targetId" HeaderText="targetId" ReadOnly="True" SortExpression="targetId" />
                        <asp:BoundField DataField="offererDynasty" HeaderText="offererDynasty" ReadOnly="True" SortExpression="offererDynasty" />
                        <asp:BoundField DataField="targetDynasty" HeaderText="targetDynasty" ReadOnly="True" SortExpression="targetDynasty" />
                        <asp:BoundField DataField="contractText" HeaderText="contractText" ReadOnly="True" SortExpression="contractText" />
                        <asp:TemplateField Visible="true" HeaderText="Accept proposal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbAccept" runat="server" Text="Accept" CommandName="Accept" CommandArgument='<%#Eval("marriageOfferId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsItalyProposals" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getMarriageOffers" TypeName="BR.Model.MarriageOfferCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="ItalyDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="odsItalyAvailable" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAvailable" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="ItalyDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
             <br />
            
            <asp:Panel ID="panelSpainMarriage" runat="server" Visible="false">
                <asp:Image ID="ImageSpainMarriage" runat="server" ImageUrl="~/images/Flag_of_Cross_of_Burgundy.svg.png" Height="50" Width="100" />
                <asp:Label ID="Label21" runat="server" Text="Spain Available For Marriage"></asp:Label>
                <asp:GridView ID="gvSpainAvailable" runat="server" DataSourceID="odsSpainAvailable" AutoGenerateColumns="False" OnRowCommand ="gvSpainMarriage_RowCommand" OnRowDataBound="gv_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="characterId" HeaderText="characterId" ReadOnly="True" SortExpression="characterId" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                        <asp:BoundField DataField="str" HeaderText="str" ReadOnly="True" SortExpression="str" />
                        <asp:BoundField DataField="cha" HeaderText="cha" ReadOnly="True" SortExpression="cha" />
                        <asp:BoundField DataField="con" HeaderText="con" ReadOnly="True" SortExpression="con" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" SortExpression="Gender" />
                        <asp:CheckBoxField DataField="King" HeaderText="King" ReadOnly="True" SortExpression="King" />
                        <asp:BoundField DataField="age" HeaderText="age" ReadOnly="True" SortExpression="age" />
                        <asp:BoundField DataField="dynastyName" HeaderText="dynastyName" ReadOnly="True" SortExpression="dynastyName" />
                       
                    <asp:TemplateField Visible="true" HeaderText="Marriage proposal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbPropose" runat="server" Text="Propose" CommandName="Propose" CommandArgument='<%#Eval("characterId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Proposed Id">
                        <ItemTemplate>
                            <asp:TextBox ID="proposedId" runat="server"></asp:TextBox>   
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" HeaderText="Contract">
                        <ItemTemplate>
                            <asp:TextBox ID="contract" runat="server" TextMode ="MultiLine"></asp:TextBox>   
                        </ItemTemplate>
                    </asp:TemplateField>
                   </Columns>
                </asp:GridView>

                <asp:Label ID="lblSpainProps" runat="server" Text="Available proposals for Spain"></asp:Label>
                <asp:GridView ID="gvSpainProposals" runat="server" AutoGenerateColumns="False" DataSourceID="odsSpainProposals" OnRowCommand="gvSpainProposals_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="marriageOfferId" HeaderText="marriageOfferId" ReadOnly="True" SortExpression="marriageOfferId" />
                        <asp:BoundField DataField="offererId" HeaderText="offererId" ReadOnly="True" SortExpression="offererId" />
                        <asp:BoundField DataField="targetId" HeaderText="targetId" ReadOnly="True" SortExpression="targetId" />
                        <asp:BoundField DataField="offererDynasty" HeaderText="offererDynasty" ReadOnly="True" SortExpression="offererDynasty" />
                        <asp:BoundField DataField="targetDynasty" HeaderText="targetDynasty" ReadOnly="True" SortExpression="targetDynasty" />
                        <asp:BoundField DataField="contractText" HeaderText="contractText" ReadOnly="True" SortExpression="contractText" />
                        <asp:TemplateField Visible="true" HeaderText="Accept proposal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbAccept" runat="server" Text="Accept" CommandName="Accept" CommandArgument='<%#Eval("marriageOfferId")  %>' CssClass="btn btn-success btn-xs"></asp:LinkButton>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsSpainProposals" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getMarriageOffers" TypeName="BR.Model.MarriageOfferCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="SpainDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="odsSpainAvailable" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAvailable" TypeName="BR.Model.CharacterCollection">
                    <SelectParameters>
                        <asp:SessionParameter Name="dynastyId" SessionField="SpainDynastyId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>

        </asp:Panel>


        <asp:Panel ID="panelEventCombat"  runat="server" Height="276px" Visible =" false"> 
            <asp:Label ID="Label16" runat="server" Text="Enter Id: "></asp:Label>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtId" ErrorMessage="Value must be a number" />
            <asp:Button ID="btnKill" runat="server" Text="Kill" OnClick="btnKill_Click" />
            <asp:Button ID="btnPrison" runat="server" Text="Imprison" OnClick="btnPrison_Click" />
            <asp:Button ID="btnRelease" runat="server" Text="Release" OnClick="btnRelease_Click" />
        </asp:Panel>
        
    </div>

        
        <ajaxToolkit:ModalPopupExtender 
            ID="ModalPopupExtenderHeirs" runat="server" 
            PopupControlID="PanelHeirs" 
            BehaviorID="ModalPopupExtenderHeirs" 
            TargetControlID="btnToFoolModalPopUp" 
            BackgroundCssClass="modalBackground"  DropShadow="True">

        </ajaxToolkit:ModalPopupExtender>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
            <asp:Panel ID="PanelHeirs" runat="server" CssClass="modalpopup" BackColor="White">
            Possible Heirs<br />
            <asp:GridView ID="gvPossibleHeirs" runat="server" OnRowCommand="gvPossibleHeirs_RowCommand">
                <Columns>
                <asp:TemplateField Visible="true" HeaderText="Change Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblSelectHeir" runat="server" Text="Make King" CommandName="MakeKing" CommandArgument='<%#Eval("characterId")  %>' Class="btn btn-primary btn-xs"></asp:LinkButton>
                                    </ItemTemplate>                          
                                </asp:TemplateField>
                    </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsPossibleHeirs" runat="server"></asp:ObjectDataSource>
          
        </asp:Panel>

       
        
        <asp:Button ID="btnToFoolModalPopUp" runat="server" Text="Button" style = "display:none" /> 

        <asp:Label ID="lblError" runat="server" ForeColor="Black" Hidden="true"></asp:Label>
    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            $("tr:odd").css("background-color", "lightgrey");
        })
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("img").css("border", "3px solid black");
        })
    </script>

   <script type="text/javascript">
        $(document).ready(function () {
            $("img").css("border", "3px solid black");
        })
    </script>
    

    <script src="JavaScript1.js"></script>
</body>
</html>
