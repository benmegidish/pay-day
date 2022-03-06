<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WebApplication10.profile" MasterPageFile="~/Site1.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Contentbody" ContentPlaceHolderID="Contentbody" runat="server">
   
    <table>
        <tr>
            <td>
                <table>
                <tr>
                   <td>
                        <div id="pic" style="width:300px; height:300px; float:left; margin:20px;">
                            <asp:Image runat="server" ID="image1" style="width:300px; height:300px; border:solid black 2px"/> 
                        </div>
                       <div style="margin:30px">
                             <asp:Label  runat="server" ID="firstname">Fist Name: </asp:Label> <br />
                             <asp:Label runat="server" ID="lastname">Last Name: </asp:Label> <br />
                       </div> 
                    </td>
                    
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button runat="server" Text="Start" BackColor="White" ID="startbutton" OnClick="Start_Click"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                     <asp:Button runat="server" Text="Stop" BackColor="White" ID="stop" OnClick="Stop_Click"/>
                                </td>
                            </tr>
                        </table>
                    </td>

                 </tr>
               </table>
            </td>
        </tr>
    </table>
    
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

                                       <div class="btn-group-vertical">
                                            <ul> 
                                                <li><asp:Button CssClass="btn btn-primary" ID="paycheck" runat="server" text="Pay-Check" OnClick="paycheck_Click"/></li>
                                                <li><asp:Button CssClass="btn btn-primary" ID="dayoff" runat="server" text="Day-Off"/></li>
                                                </ul>
                                        </div>
                                        <div class="btn-group-vertical">
                                            <ul>
                                                <li><asp:Button CssClass="btn btn-primary" ID="hour" runat="server" text="Account settings" /></li>
                                                <li><asp:Button CssClass="btn btn-primary" ID="sickday" runat="server" text="Sick-Day"/></li>
                                                
                                            </ul>
                                         </div>
   
                             <div >
                                <asp:Panel ID="panel1" runat="server" CssClass="popup rounded container">
                                    <a href="">X</a>
                                    
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="persname" runat="server" Text="First Name:" Font-Size="Larger"></asp:Label>
                                           
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Last Name:" Font-Size="Larger"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="Work-Place:" Font-Size="Larger"></asp:Label>
                                               
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Total-Hours:<asp:Label ID="Label3" runat="server" Font-Size="Larger"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                               Per-Hour: <asp:Label ID="Label4" runat="server"  Font-Size="Larger"></asp:Label>
                                                
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="Pre-Tax:" Font-Size="Larger"></asp:Label>
                                                
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                           <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="Health-Insurance:" Font-Size="Larger"></asp:Label>
                                                
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                           <tr>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="Social-Security:" Font-Size="Larger"></asp:Label>
                                                
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                           <tr>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="Post-Tax:" Font-Size="Larger" ></asp:Label>
                                                
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                              </asp:Panel>
                            <<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="paycheck" PopupControlID="panel1" BackgroundCssClass="background" 
                               runat="server"></ajaxToolkit:ModalPopupExtender>
                        </div>
    
  
    <div class="modal-dialog-centered">
    <asp:Panel runat="server" ID="setperhourr" CssClass="background:white">
        <a href="">X</a>
        <asp:Label runat="server" ID="perhourset" Text="Please Enter New Per Hour:"></asp:Label>
        <asp:TextBox runat="server" ID="per" ></asp:TextBox>
            <br />
        <asp:Label runat="server" ID="jobplace" Text="Please Enter work-place:"></asp:Label>
        <asp:TextBox runat="server" ID="company" ></asp:TextBox>
            <br />
         <asp:FileUpload runat="server" ID="fileupload1" />
         <asp:Button runat="server" Text="Change Profile Pic" OnClick="Unnamed2_Click" />
        <br />
            <asp:Button runat="server" ID="submit" Text="submit" OnClick="submit_Click" />
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" TargetControlID="hour" PopupControlID="setperhourr" BackgroundCssClass="background" runat="server"></ajaxToolkit:ModalPopupExtender>
    </div>
    <div>
        <asp:Panel ID="offday" runat="server">
            <asp:Calendar runat="server" ID="calender" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" OnSelectionChanged="calender_SelectionChanged">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                <DayStyle Width="14%" />
                <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                <TodayDayStyle BackColor="#CCCC99" />
            </asp:Calendar>
            <asp:Button runat="server" Text="Cancel"/>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender4" TargetControlID="dayoff" PopupControlID="offday"  runat="server"></ajaxToolkit:ModalPopupExtender>
    </div>

    <div>
        <asp:Panel ID="daysick" runat="server">
            <asp:Calendar runat="server" ID="Calendar1" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" OnSelectionChanged="Calendar1_SelectionChanged">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                <DayStyle Width="14%" />
                <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                <TodayDayStyle BackColor="#CCCC99" />
            </asp:Calendar>
            <asp:Button runat="server" Text="Cancel"/>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender5" TargetControlID="sickday" PopupControlID="daysick"  runat="server"></ajaxToolkit:ModalPopupExtender>
      </div>

    

    <div class="container">
        <div class="col-6">
            <asp:Label runat="server" ID="x" Text="You are a killer go get the MONEY!"></asp:Label><br />
            <asp:Label runat="server" ID="xx" Text="Have an aesome time!"></asp:Label><br />
            <asp:Label runat="server" ID="xxx" Text="Thank you for your hard work!"></asp:Label><br />
            <asp:Label runat="server" ID="xxxx" Text="Happy Birth-Day!!!"></asp:Label><br />
        </div>
    </div>
    
</asp:Content>


