<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Family_Business.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
<div class="col-md-12">



            <div class="col-md-6">

                <div class="row" style="padding-top: 8px;">

                    <div class="col-md-3">
                        Name
                               <asp:HiddenField ID="hidProductID" runat="server" />
                    </div>
                    <div class="col-md-9">
                        <div class="nk-int-st">
                            <asp:TextBox ID="txtProductName" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="row" style="padding-top: 8px;">

                    <div class="col-md-3">
                        Code
                              
                    </div>
                    <div class="col-md-9">
                        <div class="nk-int-st">
                            <asp:TextBox ID="txtProductCode" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="row" style="padding-top: 8px;">

                    <div class="col-md-3">
                        Location
                               
                    </div>
                    <div class="col-md-9">
                        <div class="nk-int-st">
                            <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="row" style="padding-top: 8px;">

                    <div class="col-md-3">
                       
                               
                    </div>
                    <div class="col-md-9">
                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-info  pull-right" OnClick="btnSave_Click" />
                    </div>
                </div>



                
            </div>

            <div class="col-md-6">


                <asp:GridView ID="gridProduct" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="5" AllowPaging="True" PageSize="10" CssClass="table table-bordered table-hover" OnPageIndexChanging="gridProduct_PageIndexChanging">
                    <Columns>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="MistyRose">
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
                        <asp:BoundField DataField="Item_Name" HeaderText="Product Name" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>




                        <asp:BoundField DataField="Item_Code" HeaderText="Code" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Item_Location" HeaderText="Location" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Update" HeaderStyle-BackColor="MistyRose">
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