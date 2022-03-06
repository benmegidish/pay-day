<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication10.WebForm3" MasterPageFile="~/Site1.Master" %>
<asp:Content ID="Contentbody" ContentPlaceHolderID="Contentbody" runat="server">
    
    <asp:Label runat="server" ID="Firstnote">
        Hello this is a one time form that you need to complete in order to use the functionality of this application <br />
        Do not worry at all, all of your DATA is for your eyes only!<br />
        Please make sure that every section is beeing selected!<br />
        Do not worry you can always update it!
    </asp:Label>
    <asp:Label runat="server" ID="Updnote">
        Hey there, Something changed?<br />
        Go ahead and Update it!<br />
        Do not forget to mark all fields!
    </asp:Label>
    
    <div>
        <div>
            <asp:Label Text="A citizan of Israel" runat="server"></asp:Label>
             <asp:CheckBoxList runat="server" ID="check1">
                <asp:ListItem Text="Yes"></asp:ListItem>
                <asp:ListItem Text="No"></asp:ListItem>
            </asp:CheckBoxList>

        </div>
        <div>
            <asp:Label runat="server" Text="A newcomer to Israel"></asp:Label>
            <asp:CheckBoxList runat="server" ID="check2">
                <asp:ListItem Text="Yes"></asp:ListItem>
                <asp:ListItem Text="No"></asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <div>
            <asp:Label runat="server" Text="Are you under 18?" ID="underage"></asp:Label>
            <asp:CheckBoxList runat="server" ID="check3">
                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="0"></asp:ListItem>
            </asp:CheckBoxList>
         
            </div>
        <div>
            <asp:Label runat="server" Text="Do you have kids under 5?"></asp:Label>
            <asp:CheckBoxList runat="server" ID="check4">
                <asp:ListItem Text="Yes"></asp:ListItem>
                <asp:ListItem Text="No"></asp:ListItem>
            </asp:CheckBoxList>
            <asp:DropDownList runat="server" ID="under18">
                <asp:ListItem Text="SELECT AMOUNT OF KIDS" Value="-1"></asp:ListItem>
                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                <asp:ListItem Text="7" Value="7"></asp:ListItem>
             </asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ID="un18" ControlToValidate="under18" ErrorMessage="REQUIRED!" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label runat="server" Text="Are you devorse?"></asp:Label>
            <asp:CheckBoxList runat="server" ID="check5">
                <asp:ListItem Text="Yes"></asp:ListItem>
                <asp:ListItem Text="No"></asp:ListItem>
            </asp:CheckBoxList>
            
        </div>
        <div>
            <asp:Label runat="server" Text="Are you a college student?"></asp:Label>
            <asp:CheckBoxList runat="server" ID="college">
                <asp:ListItem Text="Yes"></asp:ListItem>
                <asp:ListItem Text="No"></asp:ListItem>
            </asp:CheckBoxList>
            
        </div>
        <div>
            <asp:Label runat="server" Text="Are you Military cripled"></asp:Label>
            <asp:CheckBoxList runat="server" ID="check6">
                <asp:ListItem Text="Yes"></asp:ListItem>
                <asp:ListItem Text="No"></asp:ListItem>
            </asp:CheckBoxList>
            
        </div>
        <div>
            <asp:Label runat="server" Text="Did you got release from the military in the last 3 years?"></asp:Label>
            <asp:CheckBoxList runat="server" ID="check7">
                <asp:ListItem Text="Yes"></asp:ListItem>
                <asp:ListItem Text="No"></asp:ListItem>
            </asp:CheckBoxList>
            
        </div>

      </div>
        <asp:Button runat="server" ID="subclick" Text="Submit" OnClick="Unnamed_Click" />
        <asp:Button runat="server" ID="sub" Text="Update" OnClick="sub_Click"/>

   </asp:Content>