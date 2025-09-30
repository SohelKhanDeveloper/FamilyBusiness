<%@ Page Title="Sales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="Family_Business.WMGS.Pages.Sale" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/juliet/resources/juliet.css">
    <link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
    <script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/js/bootstrap-datepicker.min.js"></script>

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
                <div class="row" style="padding-top: 8px;">
                    <div class="col-md-6">
                        <div class="row" style="padding-top: 8px;">
                            <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel2" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                     <div class="col-md-3">
                                Date
                              
                            </div>
                            <div class="col-md-9">


                                <div id="sandbox-container">
                                    <div class="input-group date">
                                        <asp:TextBox ID="txtSaleDate" Class="form-control" runat="server" placeholder="mm/dd/yyyy" autocomplete="off" TabIndex="3"></asp:TextBox><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                    </div>
                                </div>

                            </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                           
                        </div>
                        <div class="row" style="padding-top: 8px;">

                            <div class="col-md-3">
                                Location
                            <asp:HiddenField ID="hidSaleID" runat="server" />

                            </div>
                            <div class="col-md-9">

                                <asp:DropDownList ID="ddlShop" Class="form-control" Style="width: 279px" AutoPostBack="true" OnSelectedIndexChanged="ddlShop_SelectedIndexChanged" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlShop"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Location"
                                    Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                            </div>

                        </div>






                        <div class="row" style="padding-top: 8px;">

                            <div class="col-md-3">
                                Cash
                               
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtCash" Class="form-control" Style="width: 282px;" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCash"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Cash Amount"
                                    Font-Size="14px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row" style="padding-top: 8px;">

                            <div class="col-md-3">
                                Card
                               
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtCard" Class="form-control" Style="width: 282px;" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCard"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Cash Amount"
                                    Font-Size="14px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
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

                </div>
                <div class="row" style="padding-top: 8px;">
                    <div class="col-md-12">


                        <asp:GridView ID="gridSales" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="5" AllowPaging="True" PageSize="10" CssClass="table table-bordered table-hover" OnPageIndexChanging="gridSales_PageIndexChanging">
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
                                <%-- <asp:BoundField DataField="ProdactTypeName" HeaderText="Product Type" HeaderStyle-BackColor="MistyRose">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>--%>
                                <asp:BoundField DataField="ShopName" HeaderText="Shop Name" HeaderStyle-BackColor="MistyRose">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="14%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SaleDate" HeaderText="Date" HeaderStyle-BackColor="MistyRose" DataFormatString="{0:dd-MMM-yyyy}">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ShopLocation" HeaderText="Shop Location" HeaderStyle-BackColor="MistyRose">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CashAmt" HeaderText="Cash Amt" HeaderStyle-BackColor="MistyRose" DataFormatString="{0:0.00}">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="7%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CashAmtTax" HeaderText="Cash Amt Tax" HeaderStyle-BackColor="MistyRose" DataFormatString="{0:0.00}">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalCashAmt" HeaderText="Total Cash" HeaderStyle-BackColor="MistyRose" DataFormatString="{0:0.00}">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CardAmt" HeaderText="CardAmt" HeaderStyle-BackColor="MistyRose" DataFormatString="{0:0.00}">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CardAmtTax" HeaderText="Card Amt Tax" HeaderStyle-BackColor="MistyRose" DataFormatString="{0:0.00}">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalCardAmt" HeaderText="Total Card Amt" HeaderStyle-BackColor="MistyRose" DataFormatString="{0:0.00}">
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
                <div class="row" style="padding-top: 8px;">
                    <asp:Button ID="btnRpt" runat="server" Text="Report" class="btn btn-info" OnClick="btnRpt_Click" Style="margin-left: 1062px;" />
                </div>


                <div class="col-md-12">


                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"
                        Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px"
                        PageCountMode="Actual" AsyncRendering="False" ShowFindControls="false"
                        InteractivityPostBackMode="AlwaysSynchronous">
                    </rsweb:ReportViewer>


                </div>




            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script>
        $(document).ready(function () {

            $('#sandbox-container .input-group.date').datepicker
                ({
                    autoclose: true,
                    todayHighlight: true
                });          

        });
    </script>

</asp:Content>




