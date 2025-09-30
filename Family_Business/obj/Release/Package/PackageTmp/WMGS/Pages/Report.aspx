<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Family_Business.WMGS.Pages.Report" %>

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
                           <div class="col-md-3">
                                Report
                            </div>
                            <div class="col-md-7">

                                <asp:DropDownList ID="ddlReport" Class="form-control" Style="width: 279px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged">

                                    <asp:ListItem Enabled="true" Text="--Select Report--" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Employee Report" Value="rptEmployee"></asp:ListItem>                                    
                                    <asp:ListItem Text="Attendance" Value="rptAttendance"></asp:ListItem>
                                    <asp:ListItem Text="Job Card" Value="rptJobCard"></asp:ListItem>
                                    <asp:ListItem Text="Employee Salary" Value="rptSalary"></asp:ListItem>
                                    <asp:ListItem Text="Pay Slip" Value="rptPaySlip"></asp:ListItem>                                    
                                    <asp:ListItem Text="Product" Value="rptProduct"></asp:ListItem>                                    
                                </asp:DropDownList>


                            </div>
                             <div class="col-md-2">
                                   <asp:Button ID="btnRpt" runat="server" Text="Report" class="btn btn-info" OnClick="btnRpt_Click"  />

                            </div>

                        </div>

                        <div class="row" style="padding-top: 8px;" runat="server" id="employee" visible="false">
                            <div class="col-md-3">
                                Eid
                                <asp:HiddenField ID="hidEID" runat="server" />
                            </div>
                            <div class="col-md-7">
                                <div class="col-md-8">
                                     <asp:DropDownList ID="ddlEmployee" Class="form-control" Style="margin-left: -14px" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged"  runat="server">
                                </asp:DropDownList>
                                </div>
                                 <div class="col-md-4">
                                     <asp:TextBox ID="txteid" Class="form-control" Style="margin-left: -20px" runat="server"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-2">
                                
                            </div>
                        </div>

                        <div class="row" style="padding-top: 8px;" runat="server" id="fromDate" visible="false">
                            <div class="col-md-3">
                                From Date
                            </div>
                            <div class="col-md-7">
                                   <div id="sandbox-container1">
                                <div class="input-group date">
                                   <asp:TextBox ID="txtFromDate" Class="form-control" runat="server" placeholder="mm/dd/yyyy" autocomplete="off" TabIndex="3"></asp:TextBox><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>
                            </div>
                            <div class="col-md-2">
                                
                            </div>
                        </div>

                         <div class="row" style="padding-top: 8px;" runat="server" id="toDate" visible="false">
                            <div class="col-md-3">
                                Todate Date
                            </div>
                            <div class="col-md-7">
                                   <div id="sandbox-container2">
                                <div class="input-group date">
                                   <asp:TextBox ID="txtToDate" Class="form-control" runat="server" placeholder="mm/dd/yyyy" autocomplete="off" TabIndex="3"></asp:TextBox><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>
                            </div>
                            <div class="col-md-2">
                                
                            </div>
                        </div>


                    </div>


                </div>

               


                <div class="col-md-12" style="padding-top: 10px;">


                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"
                        Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px"
                        PageCountMode="Actual" AsyncRendering="False" ShowFindControls="false"
                        InteractivityPostBackMode="AlwaysSynchronous">
                    </rsweb:ReportViewer>


                </div>




            </div>
        </ContentTemplate>

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




