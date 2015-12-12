<%@ Page Title="" Language="C#" MasterPageFile="~/login.Master" AutoEventWireup="true" CodeBehind="AccountLogin.aspx.cs" Inherits="DtissDemoApplication.AccountLogin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
           
         
            <div class="login">
           
                   
                    <p>
                    	
                        <asp:TextBox ID="UserName" runat="server" CssClass="UserName" placeholder ="username"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                             <br>
                       
                         </p>
                         <p>
                             <asp:TextBox ID="Password" runat="server" CssClass="Password" 
                                 TextMode="Password" placeholder ="password"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                 ControlToValidate="Password" CssClass="failureNotification" 
                                 ErrorMessage="Password is required." ToolTip="Password is required." 
                                 ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                         </p>
                       
                      <p>
                    <asp:Button ID="LoginButton" runat="server" CommandName="button" Text="Log In" 
                              ValidationGroup="LoginUserValidationGroup" CssClass="button" 
                              ViewStateMode="Enabled" onclick="LoginButton_Click1"/>
                </p>
          
               
            </div>
        </LayoutTemplate>
    </asp:Login>
     
</asp:Content>
