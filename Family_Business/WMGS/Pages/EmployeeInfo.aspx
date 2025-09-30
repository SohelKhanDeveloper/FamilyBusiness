<%@ Page Title="Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="Family_Business.WMGS.Pages.EmployeeInfo" %>

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

                <div class="col-md-6">


                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Employee ID
                               <asp:HiddenField ID="hidEMPID" runat="server" />
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtEmployeeID" Class="form-control" Style="width: 282px;" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmployeeID"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Employee ID"
                                Font-Size="14px" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Emp. First Name
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtEmpFirstName" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmpFirstName"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Employee First Name"
                                Font-Size="14px" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Emp. Last Name
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtLastName" Class="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                     <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Emp. Last Name check git
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="TextBox1" Class="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Emp. Phone No
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtPhoneNo" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhoneNo"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Employee Phone Number"
                                Font-Size="14px" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Emp. Email 
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtEmpEmail" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmpEmail"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Employee Email"
                                Font-Size="14px" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Emp. Address
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtEmpAddress" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmpAddress"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Employee Address"
                                Font-Size="14px" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Gender
                               
                        </div>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlGender" Class="form-control" Style="width: 279px" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGender"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Fragrance Type"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>

                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Status
                               
                        </div>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlEmpStatus" Class="form-control" Style="width: 279px" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlEmpStatus"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Employee Status"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                        </div>

                    </div>
                </div>

                <div class="col-md-6">



                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Education
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtEducation" Class="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Emp Nominee
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtEmpNominee" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpNominee"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Employee Nominee"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Nominee Ph No.
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtNomineePhone" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNomineePhone"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Employee Nominee Phone No"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">

                        <div class="col-md-3">
                            Emp Shift.
                              
                        </div>
                        <div class="col-md-9">

                            <asp:TextBox ID="txtEmpShift" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEmpShift"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Employee Shift"
                                Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-3">
                            Date of Birth
                              
                        </div>
                        <div class="col-md-9">

                           
                            <div id="sandbox-container1">
                                <div class="input-group date">
                                   <asp:TextBox ID="txtDateOfDate" Class="form-control" runat="server" placeholder="mm/dd/yyyy" autocomplete="off" TabIndex="3"></asp:TextBox><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-3">
                            Joining Date
                              
                        </div>
                        <div class="col-md-9">

                            <%--<div class="form-group">
                                <div class='input-group date' id='datetimepicker2'>
                                    <asp:TextBox ID="txtJoingingDate" Class="form-control" runat="server" autocomplete="off" TabIndex="3"></asp:TextBox>
                                    <span class="input-group-addon" style="margin-left: 100px">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </div>--%>
                             <div id="sandbox-container2">
                                <div class="input-group date">
                                   <asp:TextBox ID="txtJoingingDate" Class="form-control" runat="server" placeholder="mm/dd/yyyy" autocomplete="off" TabIndex="3"></asp:TextBox><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-3">
                            Pay
                              
                        </div>
                        <div class="col-md-9">

                            <div class="form-group">
                                <asp:TextBox ID="txtEmpPay" Class="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtEmpPay"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Employee Pay"
                                    Font-Size="14px" InitialValue="0" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-3">
                            Confirmd Emp
                              
                        </div>
                        <div class="col-md-9">

                            <div class="form-group">
                                <asp:CheckBox ID="chkEmployeeConfirmed" runat="server" />
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
            <div class="col-md-12" style="margin-top: 35px;">
                <asp:GridView ID="gridEmployee" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="5" AllowPaging="True" PageSize="10" CssClass="table table-bordered table-hover" OnPageIndexChanging="gridEmployee_PageIndexChanging">
                    <Columns>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="MistyRose">
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

                        <asp:BoundField DataField="EID" HeaderText="EID" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FullName" HeaderText="Emp Name" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="12%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="EmpPhone" HeaderText="Phone" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EmpEmail" HeaderText="Email" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EmpAddress" HeaderText="Address" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DateofBirth" HeaderText="DOB" HeaderStyle-BackColor="MistyRose" DataFormatString="{0:dd-MMM-yyyy}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="9%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date" HeaderStyle-BackColor="MistyRose" DataFormatString="{0:dd-MMM-yyyy}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="9%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Gender" HeaderText="Gender" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Gender" HeaderText="Gender" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="EmpShift" HeaderText="Shift" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EmpPay" HeaderText="Pay" HeaderStyle-BackColor="MistyRose" DataFormatString="{0:0.00}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EmpNominee" HeaderText="Nomini" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EmpNomineePhone" HeaderText="N.Phone" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EMP_Status" HeaderText="Status" HeaderStyle-BackColor="MistyRose">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="7%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Update" HeaderStyle-BackColor="MistyRose">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/WMGS/img/edit.png" OnClick="imgbtnEdit_Click" />
                                <asp:ImageButton ID="imgbtnDelet" runat="server" ImageUrl="~/WMGS/img/list_Delete.png" OnClick="imgbtnDelet_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="7%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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




