<%@ Page Title="Product List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Family_Business.WMGS.Pages.ProductList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <div class="col-md-12">
        <div class="row" style="padding-top: 8px;">
            <div class="col-md-8">
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlOilType" AutoPostBack="true" OnSelectedIndexChanged="ddlOilType_SelectedIndexChanged" Class="form-control" Style="width: 200px" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlProductName" AutoPostBack="true" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged" Class="form-control" Style="width: 200px" runat="server">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-md-4">
            </div>


        </div>
        <div class="row" style="padding-top: 8px;">
            <asp:GridView ID="gridProduct" runat="server" AutoGenerateColumns="False" Width="100%"
                CellPadding="5" AllowPaging="True" PageSize="10" CssClass="table table-bordered table-hover" OnPageIndexChanging="gridProduct_PageIndexChanging">
                <Columns>

                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="MistyRose">
                        <HeaderTemplate>
                            sl
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSRNO" runat="server"
                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="ProdactTypeName" HeaderText="Product Type" HeaderStyle-BackColor="MistyRose">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>--%>
                    <asp:BoundField DataField="oilType" HeaderText="oil Type" HeaderStyle-BackColor="MistyRose">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" HeaderStyle-BackColor="MistyRose">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProductLocation" HeaderText="Location" HeaderStyle-BackColor="MistyRose">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProductIndex" HeaderText="Index" HeaderStyle-BackColor="MistyRose">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>




                    <asp:BoundField DataField="ProductCode" HeaderText="Code" HeaderStyle-BackColor="MistyRose">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <%-- <asp:BoundField DataField="Product_Location" HeaderText="Location" HeaderStyle-BackColor="MistyRose">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>--%>

                    <asp:TemplateField HeaderText="Details" HeaderStyle-BackColor="MistyRose">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/WMGS/img/edit.png" OnClick="imgbtnEdit_Click" />
                        </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle ForeColor="Red" />
                <RowStyle CssClass="Grid_RowStyle" />
                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                <FooterStyle CssClass="Grid_Footer" />
            </asp:GridView>
        </div>


    </div>

</asp:Content>




