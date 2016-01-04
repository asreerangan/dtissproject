<%@ Page Title="" Language="C#" MasterPageFile="~/Bootstrap.Master" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="DtissDemoApplication.AddAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type = "text/javascript">
    function isNumeric(keyCode) {
        if (keyCode == 16)
            isShift = true;

        return ((keyCode >= 48 && keyCode <= 57 || keyCode == 8 ||
            (keyCode >= 96 && keyCode <= 105)) && isShift == false);
    }
    </script>
    <script type = "text/javascript">
        function isAlpha(keyCode) {
            return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8)
        }
    </script> 
    <script type = "text/javascript">
        function isAlphaNumeric(keyCode) {
            return ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || keyCode == 8)
        }
    </script>
    <script type = "text/javascript">
        var isShift = false;
        function keyUP(keyCode) {
            if (keyCode == 16)
                isShift = false;
        }
    </script>
    <script type ="text/javascript">
        function CheckTextLength(text, long) {
            var maxlength = new Number(long); // Change number to your max length.
            if (text.value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                alert(" Only " + long + " characters allowed");
            }
        }
    
    </script>
 <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>User Information form <i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="FirstName" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="FirstName" CssClass="form-control"></asp:TextBox>
                            </div>
                             <asp:Label ID="Label6" runat="server" Text="LastName" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox4" runat="server" placeholder="LastName" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                           <asp:Label ID="Label2" runat="server" Text="AddressLine1" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox2" runat="server" placeholder="AddressLine1" CssClass="form-control"></asp:TextBox>
                            </div>
                             <asp:Label ID="Label7" runat="server" Text="AddressLine2" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox5" runat="server" placeholder="AddressLine2" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                           <asp:Label ID="Label8" runat="server" Text="City" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox6" runat="server" placeholder="City" CssClass="form-control"></asp:TextBox>
                            </div>
                             <asp:Label ID="Label9" runat="server" Text="State" CssClass="col-lg-2 control-label"></asp:Label>                          
                            <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control ddl">
                                    <asp:ListItem>Maharashtra</asp:ListItem>
                                    <asp:ListItem>UttarPradesh</asp:ListItem>
                                    <asp:ListItem>Karnataka</asp:ListItem>
                                    <asp:ListItem>West Bengal</asp:ListItem>
                                    <asp:ListItem>TamilNadu</asp:ListItem>
                                </asp:DropDownList>                              
                            </div>


                        </div>
                      
                        <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="Gender" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <div class="radio">
                                    <label>
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                            <asp:ListItem Selected="True">Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </label>
                                </div>
                            </div>

                             <asp:Label ID="Label15" runat="server" Text="Email" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox12" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>

            <div class ="registrationform">
               <div class="form-horizontal">
               <fieldset>

               <legend><i class="fa fa-dollar pull-right"></i> Bank Information Details </legend>

                <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Debit Card" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox3" runat="server" placeholder="Debit Card" CssClass="form-control" AutoPostBack ="true">1111 1111 1111 1111</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate = "TextBox3"></asp:RequiredFieldValidator>
                                
                                <asp:CustomValidator ID="CustomValidator1"
                                ControlToValidate="TextBox3" runat="server" 
                                ErrorMessage="Debit Card Not Vaild"
                                OnServerValidate="CustomValidator1_ServerValidate">
                                </asp:CustomValidator>
                            </div>
                             <asp:Label ID="Label5" runat="server" Text="CVV"   CssClass="col-lg-2 control-label" ></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="Cvv" runat="server" placeholder="CVV" CssClass="form-control" onChange="CheckTextLength(this,3)" ></asp:TextBox>
                              
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="Cvv"></asp:RequiredFieldValidator>
                               
                            </div>
                        </div>

             <div class="form-group">
              <asp:Label ID="Label10" runat="server" Text="Expiry Date" CssClass="col-lg-2 control-label"></asp:Label>
              <div class="col-lg-10">
              <asp:TextBox ID="TextBox8" runat="server" placeholder="ExpiryDate" CssClass="form-control"></asp:TextBox>
                  <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="TextBox8" CssClass="form-control" ClearTime="True" PopupPosition="TopLeft" />
                  
              </div>
              <asp:Label ID="Label11" runat="server" Text="Card type" CssClass="col-lg-2 control-label"></asp:Label> 
                <div class="col-lg-10">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control ddl">
                                    <asp:ListItem>VOSA</asp:ListItem>
                                    <asp:ListItem>MONSTERCARD</asp:ListItem>
                                    <asp:ListItem>AMUX</asp:ListItem>
                                </asp:DropDownList>                              
                            </div>
          
              </div>
                <div class="form-group">
               <asp:Label ID="Label12" runat="server" Text=" Fav Cartoon Character" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox9" runat="server" placeholder="Cartoon" CssClass="form-control"></asp:TextBox>
                            </div>
                             <asp:Label ID="Label13" runat="server" Text="Fav Book" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox10" runat="server" placeholder="Fav Book" CssClass="form-control" ></asp:TextBox>
                            </div>



              </div>
                <div class="form-group">
                 <asp:Label ID="Label14" runat="server" Text="Secret 10 digit Number" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="TextBox11" runat="server" placeholder="Secret Number" onkeyup = "keyUP(event.keyCode) CheckTextLength(this,10)"   onkeydown = "return isNumeric(event.keyCode);" onChange="CheckTextLength(this,10)"  CssClass="form-control" ></asp:TextBox>
                            </div>
                    <ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="TextBox11" PreferredPasswordLength="10" MinimumNumericCharacters="10" TextStrengthDescriptions="Secret Number should be minimum 10 digits;Excellent"  TextCssClass="form-control" />
                </div>

                <div class="form-group">

                 <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" 
                                    Text="Submit" onclick="btnSubmit_Click" />
                                  <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" 
                                    Text="Cancel" onclick="btnCancel_Click" />
                            </div>

                </div>
               </fieldset>

               </div>
            
            
            </div>
        </div>
</asp:Content>
