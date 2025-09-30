<%@ Page Title="Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Family_Business.WMGS.Pages.Products" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="col-md-12" style="margin-top: 35px;">

                <div class="row" runat="server" id="messageWrappper">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="alert-list" runat="server" id="wrapperSuccess" visible="False">
                            <div class="alert alert-success alert-dismissible" role="alert">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><i class="notika-icon notika-close"></i></span></button>
                                <asp:Label runat="server" ID="lblMessageSuccess" CssClass=""></asp:Label>
                            </div>
                        </div>
                        <div class="alert-list" runat="server" id="wrapperError" visible="False">
                            <div class="alert bg-danger alert-dismissible" role="alert">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><i class="notika-icon notika-close"></i></span></button>
                                <asp:Label runat="server" ID="lblMessageError" CssClass=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">

                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Product Type
                               
                        </div>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlProductType" OnSelectedIndexChanged="ddlProductType_SelectedIndexChanged" AutoPostBack="true" Class="form-control" Style="width: 279px" runat="server">
                                <asp:ListItem Text="--Select Product--" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1">Oil</asp:ListItem>
                                <asp:ListItem Value="2">Miscellaneous</asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProductType"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Product Type"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Oil Type
                               
                        </div>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlOilType" Class="form-control" Style="width: 279px" runat="server">
                                <asp:ListItem Text="--Select Oil Group--" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1">Burberry</asp:ListItem>
                                <asp:ListItem Value="2">Polo</asp:ListItem>
                                <asp:ListItem Value="3">Gucci</asp:ListItem>
                                <asp:ListItem Value="4">Versace</asp:ListItem>
                                <asp:ListItem Value="5">Jimmy Choo</asp:ListItem>
                                <asp:ListItem Value="6">Mask</asp:ListItem>
                                <asp:ListItem Value="7">Feminine</asp:ListItem>
                                <asp:ListItem Value="8">Masculine</asp:ListItem>
                                <asp:ListItem Value="9">Other</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlOilType"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Oil Type"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Fragrance Type
                               
                        </div>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlFragranceType" Class="form-control" Style="width: 279px" runat="server">
                                <asp:ListItem Text="--Select Fragrance Type--" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1">Male</asp:ListItem>
                                <asp:ListItem Value="2">Female</asp:ListItem>
                                <asp:ListItem Value="3">Unisex</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlFragranceType"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Fragrance Type"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>

                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Name
                               <asp:HiddenField ID="hidProductID" runat="server" />
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtProductName" Class="form-control" Style="width: 282px;" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtProductName"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Product Name"
                                Font-Size="14px" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Code
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtProductCode" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProductCode"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Product Code"
                                Font-Size="14px" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Location
                               
                        </div>
                        <div class="col-md-7">

                            <asp:DropDownList ID="ddlLocation" Class="form-control" Style="width: 200px" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlLocation"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Location"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtIndex" Class="form-control" runat="server" Style="margin-left: -100px"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                        </div>
                        <div class="col-md-9">
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-info" ValidationGroup="Group1" OnClick="btnSave_Click" />
                        </div>
                    </div>




                </div>

                <div class="col-md-6">


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
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <%-- <asp:BoundField DataField="Product_Location" HeaderText="Location" HeaderStyle-BackColor="MistyRose">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>--%>

                            <asp:TemplateField HeaderText="Update" HeaderStyle-BackColor="MistyRose">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/WMGS/img/edit.png" OnClick="imgbtnEdit_Click" />
                                    <asp:ImageButton ID="imgbtnDelet" runat="server" ImageUrl="~/WMGS/img/list_Delete.png" OnClick="imgbtnDelet_Click" />
                                </ItemTemplate>
                                <ItemStyle Width="15%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script>

        function func(result) {
            if (result === 'Data Save Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Update Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>

</asp:Content>




