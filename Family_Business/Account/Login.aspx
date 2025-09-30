<%@  Language="C#" MasterPageFile="~/Account/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Family_Business.Account.Login" Async="true" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div class="panel-heading panel-heading-01"><i class="fa fa-sign-out fa-fw icon-padding"></i>Enter your Username and Password</div>--%>
    <div class="col-md-12" style="margin-top: 180px;">
        <div class="col-md-3">
        </div>
        <div class="col-md-6">
            <div class="row" style="padding-top: 8px;">
                <div class="col-md-3">
                    <%--User Name--%>
                </div>
                <div class="col-md-9">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="true" CssClass="lbltext" ></asp:Label>
                     

                </div>
            </div>
            <div class="row" style="padding-top: 8px;">
                <div class="col-md-3">
                    <%--User Name--%>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtLoginName" runat="server" placeholder="Username" Class="form-control"></asp:TextBox>
                    <asp:Label ID="lblStatus" runat="server" Font-Bold="true" CssClass="lbltext"></asp:Label>
                     

                </div>
            </div>
            <div class="row" style="padding-top: 8px;">
                <div class="col-md-3">
                    <%--Password--%>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" placeholder="Password" onkeypress="return EnterEvent(event)" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblPassword" runat="server" Font-Bold="true" CssClass="lbltext"></asp:Label>

                </div>
            </div>
            <asp:Panel ID="LodingPanel" runat="server">

                <div class="resultText" style="padding-bottom: 10px">
                   

                </div>
            </asp:Panel>
            <div class="row" style="padding-top: 8px;">

                <div class="col-md-3">
                </div>
                <div class="col-md-9">
                    <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-info" Style="width: 280px;" />
                    <asp:Image ID="imgstatusloading" runat="server" CssClass="lblstatusloading_icon" style="margin-left:100px"
                        Visible="false" />
                    <asp:Image ID="imgstatus" runat="server" CssClass="lblstatus_icon" Visible="false" />
                    <asp:Label ID="lblMesg" runat="server" Font-Bold="true" CssClass="lbltext"></asp:Label>
                    
                </div>
            </div>

        </div>
        <div class="col-md-3">
            
        </div>




    </div>
</asp:Content>
