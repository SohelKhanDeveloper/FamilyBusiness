<%@ Page Title="Salary Process" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalaryProcess.aspx.cs" Inherits="Family_Business.WMGS.Pages.SalaryProcess" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <div class="row" style="padding-top: 8px;">
    <div class="col-md-12">
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

                        <asp:GridView ID="grdSalary" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="5" AllowPaging="True" PageSize="10" CssClass="table table-bordered table-hover" OnPageIndexChanging="grdSalary_PageIndexChanging">
                            <Columns>
                                 <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="headerLevelCheckBox" onclick="checkAll(this);" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="rowLevelCheckBox" runat="server" onclick="Check_Click(this)" />
                                        <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                        <itemstyle horizontalalign="Left" width="2%" cssclass="Grid_Border" />
                                        <footerstyle cssclass="Grid_Footer" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField>
                                    <HeaderTemplate>
                                        Sl.
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSRNO" runat="server"
                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"  width="5%"/>
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

                                 <asp:BoundField DataField="TotalWorkingHour" HeaderText="Total Hour" DataFormatString="{0:0.00}">
                                    <ItemStyle HorizontalAlign="Left" Width="10%"/>
                                </asp:BoundField>

                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalWorkingHour" runat="server" Text='<%# Eval("TotalWorkingHour")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:BoundField DataField="EmpPay" HeaderText="EmpPay" DataFormatString="{0:0.00}">
                                    <ItemStyle HorizontalAlign="Left" Width="10%"/>
                                </asp:BoundField>

                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbEmpPay" runat="server" Text='<%# Eval("EmpPay")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:BoundField DataField="totalPayAmt" HeaderText="Total PayAmt" DataFormatString="{0:0.00}">
                                    <ItemStyle HorizontalAlign="Left" Width="10%"/>
                                </asp:BoundField>

                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbtotalPayAmt" runat="server" Text='<%# Eval("totalPayAmt")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                               <asp:BoundField DataField="Status" HeaderText="Status" >
                                    <ItemStyle HorizontalAlign="Left" Width="10%"/>
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Benefits">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbx" runat="server" Width="100%" ToolTip="Enter Hour" Text='<%# Bind("Benefits") %>' Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                </asp:TemplateField>  

                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbxRemarks" runat="server" Width="100%" ToolTip="Enter Hour" Text='<%# Bind("Remarks") %>' ></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="35%" CssClass="Grid_Border" />
                                </asp:TemplateField>  
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

         <div class="row" style="padding-top: 8px;">
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-9">
                            <asp:Button ID="btnbtnConfirm" runat="server" Text="Confirm" class="btn btn-info" ValidationGroup="Group1" OnClick="btnbtnConfirm_Click" />
                        </div>
                    </div>
        </div>
      <script type="text/javascript">
               function Check_Click(objRef) {

                   //Get the Row based on checkbox
                   var row = objRef.parentNode.parentNode;
                   if (objRef.checked) {
                       //If checked change color to Aqua
                       row.style.backgroundColor = "MistyRose";
                   }
                   else {

                       row.style.backgroundColor = "white";
                   }


                   //Get the reference of GridView
                   var GridView = row.parentNode;

                   //Get all input elements in Gridview
                   var inputList = GridView.getElementsByTagName("input");

                   for (var i = 0; i < inputList.length; i++) {
                       //The First element is the Header Checkbox
                       var headerCheckBox = inputList[0];

                       //Based on all or none checkboxes
                       //are checked check/uncheck Header Checkbox
                       var checked = true;
                       if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                           if (!inputList[i].checked) {
                               checked = false;
                               break;
                           }
                       }
                   }
                   headerCheckBox.checked = checked;

               }
           </script>
            <script type="text/javascript">
                function checkAll(objRef) {
                    var GridView = objRef.parentNode.parentNode.parentNode;
                    var inputList = GridView.getElementsByTagName("input");
                    for (var i = 0; i < inputList.length; i++) {
                        //Get the Cell To find out ColumnIndex
                        var row = inputList[i].parentNode.parentNode;
                        if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                            if (objRef.checked) {
                                //If the header checkbox is checked
                                //check all checkboxes
                                //and highlight all rows
                                row.style.backgroundColor = "MistyRose";
                                inputList[i].checked = true;
                            }
                            else {

                                row.style.backgroundColor = "white";
                                inputList[i].checked = false;
                            }
                        }
                    }
                }
            </script>
</asp:Content>




