<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AttendanceProcess.aspx.cs" Inherits="Family_Business.WMGS.Pages.AttendanceProcess" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <style type="text/css">
        .LoaderBackground_ {
            /*background-color:;*/
            filter: alpha(opacity=90);
            opacity: 0.9;
            z-index: 999999999;
            overflow: hidden;
            width: 20%;
            height: 20%;
            position: absolute;
            margin: 170px 300px 0;
        }

        .LoaderBackground_Image {
            display: block;
            position: absolute;
            left: 48%;
            top: 40%;
            width: 50px;
            height: 50px;
        }
    </style>

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
                            <div class="col-md-3">
                               From Date
                              
                            </div>
                            <div class="col-md-9">                               

                                <div id="sandbox-container1">
                                <div class="input-group date">
                                   <asp:TextBox ID="txtFromDate" Class="form-control" runat="server" placeholder="mm/dd/yyyy" AutoPostBack="true" OnTextChanged="txtFromDate_TextChanged" autocomplete="off" TabIndex="3"></asp:TextBox><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>

                            </div>
                        </div>

                        <div class="row" style="padding-top: 8px;">

                            <div class="col-md-3">
                                Employee
                            <asp:HiddenField ID="hidSaleID" runat="server" />

                            </div>
                            <div class="col-md-9">

                                <asp:DropDownList ID="ddlEmployee" Class="form-control" Style="width: 279px" AutoPostBack="true"  runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlEmployee"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Location"
                                    Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                            </div>

                        </div>

                        
                         <div class="row" style="padding-top: 8px;">
                            <div class="col-md-3">
                               To Date
                              
                            </div>
                            <div class="col-md-9">

                                <div class="form-group">                                  
                                     <asp:TextBox ID="txtToDate" Class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                         <div class="row" style="padding-top: 8px;">
                            <div class="col-md-3">
                               Total Day
                              
                            </div>
                            <div class="col-md-9">

                                <div class="form-group">
                                    <asp:TextBox ID="txtTotalDay" Class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                         <div class="row" style="padding-top: 8px;">
                            <div class="col-md-3">
                               Remarks
                              
                            </div>
                            <div class="col-md-9">

                                <div class="form-group">
                                    <asp:TextBox ID="txtRemarks" Class="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>

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


                        <asp:GridView ID="gridAttendance" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="5" AllowPaging="True" PageSize="20" CssClass="table table-bordered table-hover" OnPageIndexChanging="gridAttendance_PageIndexChanging">
                            <Columns>

                                
                                 <asp:TemplateField>
                                    <HeaderTemplate>
                                        Sl.
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSRNO" runat="server"
                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"  width="7%"/>
                                </asp:TemplateField>

                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("id")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                                <asp:BoundField DataField="EID" HeaderText="EID">
                                    <ItemStyle HorizontalAlign="Left" Width="10%"/>
                                </asp:BoundField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbEID" runat="server" Text='<%# Eval("EID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="FullName" HeaderText="Name">
                                    <ItemStyle HorizontalAlign="Left" Width="15%"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="AttendanceDate" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}">
                                    <ItemStyle HorizontalAlign="Left" Width="10%"/>
                                </asp:BoundField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="AttendanceDate" runat="server" Text='<%# Eval("AttendanceDate")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="Attendance_Day" HeaderText="Day">
                                    <ItemStyle HorizontalAlign="Left" Width="10%"/>
                                </asp:BoundField>  
                                 <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Attendance_Day" runat="server" Text='<%# Eval("Attendance_Day")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Hour">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbx" runat="server" Width="100%" ToolTip="Enter Hour" Text='<%# Bind("Total_Hour") %>' Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Status" HeaderText="Status" >
                                    <ItemStyle HorizontalAlign="Left" Width="10%"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="AttendanceProcessStatus" HeaderText="Process Status">
                                    <ItemStyle HorizontalAlign="Left" Width="10%"/>
                                </asp:BoundField>
                                
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbxRemarks" runat="server" Width="100%" ToolTip="Enter Hour" Text='<%# Bind("Remarks") %>' ></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                </asp:TemplateField>
                                
                                
                               
                                

                                <%-- <asp:BoundField DataField="Product_Location" HeaderText="Location" HeaderStyle-BackColor="MistyRose">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>--%>

                               <%-- <asp:TemplateField HeaderText="Update" HeaderStyle-BackColor="MistyRose">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/WMGS/img/edit.png" OnClick="imgbtnEdit_Click" />
                                        <asp:ImageButton ID="imgbtnDelet" runat="server" ImageUrl="~/WMGS/img/list_Delete.png" OnClick="imgbtnDelet_Click" />
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                </asp:TemplateField>--%>
                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                Font-Bold="True" ForeColor="White" />
                            <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="Silver" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>


                    </div>
                     
                </div>
                <div class="row" style="padding-top: 8px;">
                    <asp:Button ID="btnProcess" runat="server" Text="Process" class="btn btn-info" OnClick="btnProcess_Click" style="margin-left: 1062px;" />
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

            $('#sandbox-container1 .input-group.date').datepicker
                ({
                    autoclose: true,
                    todayHighlight: true
                });
            $('#sandbox-container2 .input-group.date').datepicker
               ({
                   autoclose: true,
                   todayHighlight: true
               });

        });
    </script>

</asp:Content>




