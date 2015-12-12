<%@ Page Title="" Language="C#" MasterPageFile="~/Bootstrap.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="DtissDemoApplication.UserPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h5>  <asp:Label ID="Label1" runat="server"  CssClass ="active"></asp:Label> </h5>

<div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
<div class="registrationform">
                <div class="form-horizontal">

                 <fieldset>
                        <legend>Password Generator <i class="fa fa-rupee pull-right"></i></legend>

                         <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Question 1" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox1" runat="server"  CssClass="form-control"></asp:TextBox>
                            </div>
                             <asp:Label ID="Label6" runat="server" Text="LastName" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox4" runat="server"  CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class ="form-group">
                        <asp:Label ID="Label11" runat="server" Text="Card type" CssClass="col-lg-2 control-label"></asp:Label> 
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control ddl">
                                    <asp:ListItem>VOSA</asp:ListItem>
                                    <asp:ListItem>MONSTERCARD</asp:ListItem>
                                    <asp:ListItem>AMUL</asp:ListItem>
                                </asp:DropDownList>                              
                            </div>
                          <asp:Label ID="Label3" runat="server" Text="Last 4 Digits of Debit Card" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox2" runat="server"  placeholder = "Last 4" CssClass="form-control"></asp:TextBox>
                            </div>
                         
                        
                        </div>

                        <div class ="form-group">
                        
                        <asp:Label ID="Label4" runat="server" Text="CVV" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox3" runat="server"  placeholder = "CVV Number" CssClass="form-control" TextMode ="Password"></asp:TextBox>
                            </div>
                        <asp:Label ID="Label10" runat="server" Text="Expiry Date" CssClass="col-lg-2 control-label"></asp:Label>
              <div class="col-lg-10">
              <asp:TextBox ID="TextBox8" runat="server" placeholder="ExpiryDate" CssClass="form-control"></asp:TextBox>
                  <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"  
                      TargetControlID="TextBox8" CssClass = "arrow" ClearTime="True" 
                      PopupPosition="TopLeft" />
                        </div>
                         
                  
              </div>

              
                        <div class ="form-group">

                        <asp:Label ID="Label7" runat="server" Text = "Amount to be paid"  
                                CssClass="col-lg-2 control-label" ></asp:Label>
                               <asp:Label ID="Label8" runat="server" Text = "$900.00"  CssClass ="col-lg-2 control-label"></asp:Label>
                         <asp:Label ID="Label5" runat="server"  CssClass="col-lg-4 control-label"></asp:Label>
                   
                         <asp:TextBox ID="TextBox5" runat="server" Width="25px"  ></asp:TextBox>
                         <asp:TextBox ID="TextBox6" runat="server" MaxLength="1" Width="25px" ></asp:TextBox>
                         <asp:TextBox ID="TextBox7" runat="server" MaxLength="1" Width="25px" ></asp:TextBox>
                         
                      
                              

                        </div>
                   
                     
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" />
                                                            
                            </div>
                        </div>
                        
                </fieldset>

                </div>
</div>
</div>

</asp:Content>
