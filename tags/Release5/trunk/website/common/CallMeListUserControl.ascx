<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CallMeListUserControl.ascx.cs" Inherits="common_CallMeListUserControl" %>
    <div>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="call_me_id" 
            GridLines="Vertical">
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="call_me_id" HeaderText="Id" 
                    InsertVisible="False" ReadOnly="True" SortExpression="call_me_id" />
                <asp:BoundField DataField="name_forename" HeaderText="First Name" 
                    SortExpression="name_forename" />
                <asp:BoundField DataField="name_surname" HeaderText="Sur Name" 
                    SortExpression="name_surname" />
                <asp:BoundField DataField="telephone" HeaderText="Telephone" 
                    SortExpression="telephone" />
                <asp:BoundField DataField="cell_number" HeaderText="Mobile" 
                    SortExpression="cell_number" />
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                <asp:BoundField DataField="company_name" HeaderText="company_name" 
                    SortExpression="company_name" />
                <asp:BoundField DataField="company_website" HeaderText="Website" 
                    SortExpression="company_website" />
                <asp:BoundField DataField="postal_adress" HeaderText="Postal Address" 
                    SortExpression="postal_adress" />
                <asp:BoundField DataField="postal_code" HeaderText="Postal Code" 
                    SortExpression="postal_code" />
                <asp:BoundField DataField="comments" HeaderText="Comments" 
                    SortExpression="comments" />
                <asp:CheckBoxField DataField="flg_receive_emails" 
                    HeaderText="Receive Emails?" SortExpression="flg_receive_emails" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:GridView>    
    </div>
