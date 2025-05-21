<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileHandler.aspx.cs" Inherits="ASP_Uploaded_Files.FileHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Download Files</title>
    <style>
        .backimg{
            background-image:url(imgs/Ui_First.png);
            height:10%;
            width:10%;
        }
    </style>
</head>

<body style="width: 1200px; height: 675px">
    
    <form id="form1" runat="server">
        <p>
            ------------------------------------------------------------------------------------<asp:Label ID="Header_Text" runat="server" Font-Size="XX-Large" Text="Download Files"></asp:Label>
            ----------------------------------------------------------------------------------</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="333px" Width="1196px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="fileName" HeaderText="File Name" />
                    <asp:CommandField HeaderText="Action" SelectText="Download" ShowSelectButton="True">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </p>
    </form>
</body>
</html>
