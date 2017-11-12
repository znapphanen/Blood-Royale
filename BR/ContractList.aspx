<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ContractList.aspx.cs" Inherits="BR.ContractList" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="UserControls/Nav.ascx" TagName="Nav" TagPrefix="uc1" %>
        
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <uc1:Nav ID="Nav1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="panelContractList" runat="server">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Panel ID="panelEngland" runat="server" Visible=" false">
                            <asp:Image ID="ImageEngland" runat="server" Height="50" Width="100" ImageUrl="~/images/800px-Flag_of_England.svg.png" />
                        
                            <asp:Label ID="Label1" runat="server" Text="England"></asp:Label>
                            <div class="table-responsive">
                                <asp:GridView ID="gvEnglandContractList" runat="server" AutoGenerateColumns="False" DataSourceID="odsEnglandContractList">
                                    <Columns>
                                        <asp:BoundField DataField="contractText" HeaderText="contractText" ReadOnly="True" SortExpression="contractText" />
                                        <asp:BoundField DataField="nameOne" HeaderText="nameOne" ReadOnly="True" SortExpression="nameOne" />
                                        <asp:BoundField DataField="idOne" HeaderText="idOne" ReadOnly="True" SortExpression="idOne" />
                                        <asp:BoundField DataField="dynastynameOne" HeaderText="dynastynameOne" ReadOnly="True" SortExpression="dynastynameOne" />
                                        <asp:BoundField DataField="dynastyIdOne" HeaderText="dynastyIdOne" ReadOnly="True" SortExpression="dynastyIdOne" />
                                        <asp:BoundField DataField="nameTwo" HeaderText="nameTwo" ReadOnly="True" SortExpression="nameTwo" />
                                        <asp:BoundField DataField="idTwo" HeaderText="idTwo" ReadOnly="True" SortExpression="idTwo" />
                                        <asp:BoundField DataField="dynastynameTwo" HeaderText="dynastynameTwo" ReadOnly="True" SortExpression="dynastynameTwo" />
                                        <asp:BoundField DataField="dynastyIdTwo" HeaderText="dynastyIdTwo" ReadOnly="True" SortExpression="dynastyIdTwo" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <asp:ObjectDataSource ID="odsEnglandContractList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllContractsForDynasty" TypeName="BR.Model.ContractCollection">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="dynastyId" SessionField="EnglandDynastyId" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel> 
                        <asp:Panel ID="panelFrance" runat="server" Visible=" false">
                            <asp:Image ID="ImageFrance" runat="server" Height="50" Width="100" ImageUrl="~/images/800px-Flag_of_France_(XIV-XVI).svg.png" />
             
                            <asp:Label ID="Label2" runat="server" Text="France"></asp:Label>
                            <div class="table-responsive">
                                <asp:GridView ID="gvFranceContractList" runat="server" AutoGenerateColumns="False" DataSourceID="odsFranceContractList">
                                    <Columns>
                                        <asp:BoundField DataField="contractText" HeaderText="contractText" ReadOnly="True" SortExpression="contractText" />
                                        <asp:BoundField DataField="nameOne" HeaderText="nameOne" ReadOnly="True" SortExpression="nameOne" />
                                        <asp:BoundField DataField="idOne" HeaderText="idOne" ReadOnly="True" SortExpression="idOne" />
                                        <asp:BoundField DataField="dynastynameOne" HeaderText="dynastynameOne" ReadOnly="True" SortExpression="dynastynameOne" />
                                        <asp:BoundField DataField="dynastyIdOne" HeaderText="dynastyIdOne" ReadOnly="True" SortExpression="dynastyIdOne" />
                                        <asp:BoundField DataField="nameTwo" HeaderText="nameTwo" ReadOnly="True" SortExpression="nameTwo" />
                                        <asp:BoundField DataField="idTwo" HeaderText="idTwo" ReadOnly="True" SortExpression="idTwo" />
                                        <asp:BoundField DataField="dynastynameTwo" HeaderText="dynastynameTwo" ReadOnly="True" SortExpression="dynastynameTwo" />
                                        <asp:BoundField DataField="dynastyIdTwo" HeaderText="dynastyIdTwo" ReadOnly="True" SortExpression="dynastyIdTwo" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <asp:ObjectDataSource ID="odsFranceContractList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllContractsForDynasty" TypeName="BR.Model.ContractCollection">
                                <SelectParameters>
                                    <asp:SessionParameter Name="dynastyId" SessionField="FranceDynastyId" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                         <asp:Panel ID="panelGermany" runat="server" Visible=" false">
                            <asp:Image ID="ImageGermany" runat="server" Height="50" Width="100" ImageUrl="~/images/Banner_of_Charles_V_as_Holy_Roman_Emperor.svg" />
         
                            <asp:Label ID="Label3" runat="server" Text="Germany"></asp:Label>
                            <div class="table-responsive">
                                <asp:GridView ID="gvGermanyContractList" runat="server" AutoGenerateColumns="False" DataSourceID="odsGermanyContractList">
                                    <Columns>
                                        <asp:BoundField DataField="contractText" HeaderText="contractText" ReadOnly="True" SortExpression="contractText" />
                                        <asp:BoundField DataField="nameOne" HeaderText="nameOne" ReadOnly="True" SortExpression="nameOne" />
                                        <asp:BoundField DataField="idOne" HeaderText="idOne" ReadOnly="True" SortExpression="idOne" />
                                        <asp:BoundField DataField="dynastynameOne" HeaderText="dynastynameOne" ReadOnly="True" SortExpression="dynastynameOne" />
                                        <asp:BoundField DataField="dynastyIdOne" HeaderText="dynastyIdOne" ReadOnly="True" SortExpression="dynastyIdOne" />
                                        <asp:BoundField DataField="nameTwo" HeaderText="nameTwo" ReadOnly="True" SortExpression="nameTwo" />
                                        <asp:BoundField DataField="idTwo" HeaderText="idTwo" ReadOnly="True" SortExpression="idTwo" />
                                        <asp:BoundField DataField="dynastynameTwo" HeaderText="dynastynameTwo" ReadOnly="True" SortExpression="dynastynameTwo" />
                                        <asp:BoundField DataField="dynastyIdTwo" HeaderText="dynastyIdTwo" ReadOnly="True" SortExpression="dynastyIdTwo" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <asp:ObjectDataSource ID="odsGermanyContractList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllContractsForDynasty" TypeName="BR.Model.ContractCollection">
                                <SelectParameters>
                                    <asp:SessionParameter Name="dynastyId" SessionField="GermanyDynastyId" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>

                         <asp:Panel ID="panelItaly" runat="server" Visible=" false">
                            <asp:Image ID="ImageItaly" runat="server" Height="50" Width="100" ImageUrl="~/images/it_ven3.gif" />
          
                            <asp:Label ID="Label4" runat="server" Text="Italy"></asp:Label>
                            <div class="table-responsive">
                                <asp:GridView ID="gvItalyContractList" runat="server" AutoGenerateColumns="False" DataSourceID="odsItalyContractList">
                                    <Columns>
                                        <asp:BoundField DataField="contractText" HeaderText="contractText" ReadOnly="True" SortExpression="contractText" />
                                        <asp:BoundField DataField="nameOne" HeaderText="nameOne" ReadOnly="True" SortExpression="nameOne" />
                                        <asp:BoundField DataField="idOne" HeaderText="idOne" ReadOnly="True" SortExpression="idOne" />
                                        <asp:BoundField DataField="dynastynameOne" HeaderText="dynastynameOne" ReadOnly="True" SortExpression="dynastynameOne" />
                                        <asp:BoundField DataField="dynastyIdOne" HeaderText="dynastyIdOne" ReadOnly="True" SortExpression="dynastyIdOne" />
                                        <asp:BoundField DataField="nameTwo" HeaderText="nameTwo" ReadOnly="True" SortExpression="nameTwo" />
                                        <asp:BoundField DataField="idTwo" HeaderText="idTwo" ReadOnly="True" SortExpression="idTwo" />
                                        <asp:BoundField DataField="dynastynameTwo" HeaderText="dynastynameTwo" ReadOnly="True" SortExpression="dynastynameTwo" />
                                        <asp:BoundField DataField="dynastyIdTwo" HeaderText="dynastyIdTwo" ReadOnly="True" SortExpression="dynastyIdTwo" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <asp:ObjectDataSource ID="odsItalyContractList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllContractsForDynasty" TypeName="BR.Model.ContractCollection">
                                <SelectParameters>
                                    <asp:SessionParameter Name="dynastyId" SessionField="ItalyDynastyId" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>

                         <asp:Panel ID="panelSpain" runat="server" Visible=" false">
                            <asp:Image ID="ImageSpain" runat="server" Height="50" Width="100" ImageUrl="~/images/Flag_of_Cross_of_Burgundy.svg.png" />
             
                            <asp:Label ID="Label5" runat="server" Text="Spain"></asp:Label>
                            <div class="table-responsive">
                                <asp:GridView ID="gvSpainContractList" runat="server" AutoGenerateColumns="False" DataSourceID="odsSpainContractList">
                                    <Columns>
                                        <asp:BoundField DataField="contractText" HeaderText="contractText" ReadOnly="True" SortExpression="contractText" />
                                        <asp:BoundField DataField="nameOne" HeaderText="nameOne" ReadOnly="True" SortExpression="nameOne" />
                                        <asp:BoundField DataField="idOne" HeaderText="idOne" ReadOnly="True" SortExpression="idOne" />
                                        <asp:BoundField DataField="dynastynameOne" HeaderText="dynastynameOne" ReadOnly="True" SortExpression="dynastynameOne" />
                                        <asp:BoundField DataField="dynastyIdOne" HeaderText="dynastyIdOne" ReadOnly="True" SortExpression="dynastyIdOne" />
                                        <asp:BoundField DataField="nameTwo" HeaderText="nameTwo" ReadOnly="True" SortExpression="nameTwo" />
                                        <asp:BoundField DataField="idTwo" HeaderText="idTwo" ReadOnly="True" SortExpression="idTwo" />
                                        <asp:BoundField DataField="dynastynameTwo" HeaderText="dynastynameTwo" ReadOnly="True" SortExpression="dynastynameTwo" />
                                        <asp:BoundField DataField="dynastyIdTwo" HeaderText="dynastyIdTwo" ReadOnly="True" SortExpression="dynastyIdTwo" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <asp:ObjectDataSource ID="odsSpainContractList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllContractsForDynasty" TypeName="BR.Model.ContractCollection">
                                <SelectParameters>
                                    <asp:SessionParameter Name="dynastyId" SessionField="SpainDynastyId" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                   </div>
                </div>

            </div>
     </asp:Panel>
    
</asp:Content>
