<%@ Page Title="OffDaySetup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OffDaySetup.aspx.cs" Inherits="Family_Business.WMGS.Pages.OffDaySetup" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.15.1/moment.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.43/css/bootstrap-datetimepicker.min.css">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.43/js/bootstrap-datetimepicker.min.js"></script>


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
                            Employee
                               <asp:HiddenField ID="hidOffDayID" runat="server" />
                        </div>
                        <div class="col-md-9">

                            <asp:DropDownList ID="ddlEmployee" Class="form-control" Style="width: 279px" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlEmployee"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Employee"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Day
                              
                        </div>
                        <div class="col-md-9">

                            <asp:DropDownList ID="ddlDay" Class="form-control" Style="width: 279px" runat="server">
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDay"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Day"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Status
                              
                        </div>
                        <div class="col-md-9">

                            <asp:DropDownList ID="ddlStatus" Class="form-control" Style="width: 279px" runat="server">
                                <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                                <asp:ListItem Value="true">Yes</asp:ListItem>
                                <asp:ListItem Value="false">No</asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStatus"
                                Display="Dynamic" ForeColor="Red" SetocusOnError="True" ErrorMessage="Select Status"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
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


                    <asp:GridView ID="gridOffDay" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="5" AllowPaging="True" PageSize="10" CssClass="table table-bordered table-hover" OnPageIndexChanging="gridOffDay_PageIndexChanging">
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
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="EIDnFullName" HeaderText="Employee" HeaderStyle-BackColor="MistyRose">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="50%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OffDay" HeaderText="OffDay" HeaderStyle-BackColor="MistyRose">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OffDayStatus" HeaderText="Status" HeaderStyle-BackColor="MistyRose">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>


                            <asp:TemplateField HeaderText="Update" HeaderStyle-BackColor="MistyRose">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/WMGS/img/edit.png" OnClick="imgbtnEdit_Click" />
                                    <asp:ImageButton ID="imgbtnDelet" runat="server" ImageUrl="~/WMGS/img/list_Delete.png" OnClick="imgbtnDelet_Click" />
                                </ItemTemplate>
                                <ItemStyle Width="20%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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

    </asp:UpdatePanel>

    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker();
        });
    </script>
</asp:Content>




