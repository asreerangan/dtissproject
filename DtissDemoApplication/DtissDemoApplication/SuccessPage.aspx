<%@ Page Title="" Language="C#" MasterPageFile="~/Bootstrap.Master" AutoEventWireup="true" CodeBehind="SuccessPage.aspx.cs" Inherits="DtissDemoApplication.SuccessPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">

<h4>
    <asp:Label ID="Label1" runat="server" CssClass="col-lg-6 control-label"></asp:Label> </h4>

    <div class="form-group">
        <div class="form-horizontal">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" 
                                    Text="Back" onclick="btnSubmit_Click"  />
                                                            
                            </div>
                        </div>
                        </div>
                   
                        </div>
</asp:Content>
