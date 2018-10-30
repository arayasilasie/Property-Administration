<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Custodian.aspx.cs" Inherits="PropertyAdmin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 30px; vertical-align: middle; left:100px" ><asp:Label ID="Label3" runat="server" Text="Fixed Assets Under your Custody" 
                                    Font-Bold="False" Font-Italic="True" Font-Overline="False" Font-Size="Medium" 
                                    Font-Strikeout="False"></asp:Label></div>
    <asp:Panel ID="PanelSearch3" runat="server">
                            <fieldset style="border: 1px solid #FDBF12;">
                            
                                
    <div class="titleSub2">
            <asp:Label ID="lbl" runat="server" Text="Transferred Materials under your Custody"></asp:Label></div>
    <div style="clear: both; margin: 1px;">
                                    <asp:Label ID="lblSearchMessage" runat="server" Text=""></asp:Label>
                                    <asp:GridView ID="GrVFARNbyUer" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" CellPadding="4"
                                            ForeColor="#333333" GridLines="None" PageSize="5" DataKeyNames="ID" 
                                        Font-Size="Smaller" >
                                    <Columns>
                                    <asp:TemplateField HeaderText="UnitCost">
                                                    <ItemTemplate>
                                                        <asp:Label ID="UnitCost" Text='<%# Eval("UnitCost") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Item">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Item" Text='<%# Eval("Item") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Quantity" Text='<%# Eval("Quantity") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                      <asp:TemplateField HeaderText="RequestType">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ReturnedBy" Text='<%# Eval("ReturnedBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                      <asp:TemplateField HeaderText="TransferredBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="TransferredBy" Text='<%# Eval("TransferredBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                       <asp:TemplateField HeaderText="TransferredDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="TransferredDate" Text='<%# Eval("TransferredDate") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                               </asp:TemplateField>

                                        <asp:TemplateField HeaderText="TransferedTo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="TransferedTo" Text='<%# Eval("TransferedTo") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                      <asp:TemplateField HeaderText="RecievedDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="RecievedDate" Text='<%# Eval("RecievedDate") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                       <asp:TemplateField HeaderText="ApprovedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ApprovedBy" Text='<%# Eval("ApprovedBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="ApprovedDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ApprovedDate" Text='<%# Eval("ApprovedDate") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Status" Text='<%# Eval("Status") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                     </Columns>
                                     <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#89ac2e" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="#e4efd0" />
                                    </asp:GridView>
                                    <div style="padding-top: 5px;">
                                     
                                               
                                    </div>
                                </div>
                                </fieldset>
                                </asp:Panel>


<asp:Panel ID="Panel1" runat="server">
<fieldset style="border: 1px solid #FDBF12;">
                                <div class="titleSub2">
            <asp:Label ID="Label1" runat="server" Text="Fixed Assets under your Custody"></asp:Label></div>
    <div style="clear: both; margin: 1px;">
                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                    <asp:GridView ID="GrVFARN" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" CellPadding="4"
                                            ForeColor="#333333" GridLines="None" PageSize="5" DataKeyNames="ID" 
                                        Font-Size="Smaller" >
                                    <Columns>
                                    
                                      <asp:TemplateField HeaderText="Item">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Item" Text='<%# Eval("Item") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Model">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Model" Text='<%# Eval("Model") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="RequestQty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="RequestQty" Text='<%# Eval("RequestQty") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="SuppliedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SuppliedBy" Text='<%# Eval("SuppliedBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                      <asp:TemplateField HeaderText="UnitPrice">
                                                    <ItemTemplate>
                                                        <asp:Label ID="UnitPrice" Text='<%# Eval("UnitPrice") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                      <asp:TemplateField HeaderText="ReceivedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ReceivedBy" Text='<%# Eval("ReceivedBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                       <asp:TemplateField HeaderText="DeliveredBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="DeliveredBy" Text='<%# Eval("DeliveredBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                               </asp:TemplateField>

                                        <asp:TemplateField HeaderText="VerifiedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="VerifiedBy" Text='<%# Eval("VerifiedBy") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                      <asp:TemplateField HeaderText="ReceivedDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ReceivedDate" Text='<%# Eval("ReceivedDate") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                       <asp:TemplateField HeaderText="RefNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="RefNo" Text='<%# Eval("RefNo") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="RefDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="RefDate" Text='<%# Eval("RefDate") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Status" Text='<%# Eval("Status") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                     </Columns>
                                     <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#89ac2e" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="#e4efd0" />
                                    </asp:GridView>
                                    <div style="padding-top: 5px;">

                                    </div>
                                    </div></fieldset></asp:Panel>
</asp:Content>
