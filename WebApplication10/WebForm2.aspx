<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication10.WebForm2" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contentbody" runat="server">

     <div>
         <div>
             <asp:Label runat="server" Text="Select A Month"></asp:Label>
             <asp:DropDownList runat="server" ID="Monthselect">
                  <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                  <asp:ListItem Text="January" Value="01"></asp:ListItem>
                  <asp:ListItem Text="February" Value="02"></asp:ListItem>
                  <asp:ListItem Text="March" Value="03"></asp:ListItem>
                  <asp:ListItem Text="April" Value="04"></asp:ListItem>
                  <asp:ListItem Text="May" Value="05"></asp:ListItem>
                  <asp:ListItem Text="June" Value="06"></asp:ListItem>
                  <asp:ListItem Text="July" Value="07"></asp:ListItem>
                  <asp:ListItem Text="August" Value="08"></asp:ListItem>
                  <asp:ListItem Text="September" Value="09"></asp:ListItem>
                  <asp:ListItem Text="October" Value="10"></asp:ListItem>
                  <asp:ListItem Text="November" Value="11"></asp:ListItem>
                  <asp:ListItem Text="December" Value="12"></asp:ListItem>
             </asp:DropDownList>
         </div>
         <asp:Label runat="server" Text="Select Year"></asp:Label>
         <asp:DropDownList runat="server" ID="Yearselect">
              <asp:listitem Value="0" Text="--Select--"></asp:listitem>
              <asp:listitem Value="2019" Text="2019"></asp:listitem>
              <asp:listitem Value="2020" Text="2020"></asp:listitem>
              <asp:listitem Value="2021" Text="2021"></asp:listitem>
              <asp:listitem Value="2022" Text="2022"></asp:listitem>
         </asp:DropDownList>
         <div>
             <asp:Button runat="server" Text="Sort" ID="Sortbtn" OnClick="Sortbtn_Click"/>
         </div>
     </div> 
    <div class="col-md-3">
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Hours table"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:GridView runat="server" ID="grid" AutoGenerateColumns="false" >
                    <Columns>
                         <asp:BoundField DataField="StartTime" HeaderText=" Start Time " />
                         <asp:BoundField DataField="EndTime" HeaderText=" End Time " />
                         <asp:BoundField DataField="WorkDate" HeaderText=" Date " />

                    </Columns>
                </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div class="col-md-3">
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Sick-Day Table"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:GridView CssClass="d-md-grid" runat="server" ID="calandersickday" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Sickday" HeaderText="Date" />
                        <asp:BoundField DataField="UserID" HeaderText=" User ID" />
                    </Columns>
                </asp:GridView>
                </td>
                </tr>
        </table>
    </div>

      <div class="col-md-3">
          <table>
              <tr>
                  <td>
                      <asp:Label runat="server" Text="Day-Off Table"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                    <asp:GridView runat="server" ID="calenderdayoff" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Dayoffcol" HeaderText="Date" />
                            <asp:BoundField DataField="UserID" HeaderText=" User ID" />
                            </Columns>
                    </asp:GridView>
                  </td>
              </tr>
          </table>
    </div>

</asp:Content>
