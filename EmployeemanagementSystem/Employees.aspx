<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeemanagementSystem.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>

      table{
          border: none;
      }
     .center-table {
         display:flex;
         justify-content:center;
         align-items:center;
         margin-left: auto;
         margin-right: auto;
            }

/* Optional: Add some styling to the table */
.center-table table {
    border-collapse: collapse;
    max-width: 550%; /* Adjust the width as needed */
}
#Insert {
    text-align: center;
    background-color: #4caf50;
    color: white;
    padding: 10px 15px;
    margin: 10px auto;
    margin-left:100%;
    border: none;
    display:flex;
    justify-content:center;
    align-items:center;
    border-radius: 3px;
    cursor: pointer;
}

.center-table th, .center-table td {
    
    padding: 8px;
    text-align: left;
}

.center-table th {
    background-color: #f2f2f2;
}

.form {
    max-width: 400px;
    margin: 20px auto;
    background-color: #fff;
    padding: 20px;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  
}



 .grid{
     display:flex;
     justify-content:center;
     align-items:center;
     max-width:400%;
     margin-left:40px;
     margin-right:40px;
    
 }
 
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
   <div class="form">
       <div class="center-table">
     <table>
   
   <tr>
       <td>
           <asp:Label runat="server" Text="FirstName"></asp:Label>
       </td>
       <td>
           <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
       </td>
   </tr>
   <tr>
       <td>
           <asp:Label ID="Label1" runat="server" Text="LastName"></asp:Label>

       </td>
       <td>
           <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>

       </td>
   </tr>
   <tr>
       <td>
           <asp:Label ID="Label2" runat="server" Text="Age"></asp:Label>

       </td>
       <td>
           
           <asp:TextBox ID="txtAge" Type="Integer" runat="server"></asp:TextBox>

       </td>
   </tr>
   <tr>
       <td>
           <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>

       </td>
       <td>
           <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

       </td>
   </tr>
   <tr>
       <td>
           <asp:Label ID="Label4" runat="server" Text="PhoneNumber"></asp:Label>

       </td>
       <td>
           <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>

       </td>
   </tr>
   <tr>
       <td>
           <asp:Label ID="Label5" runat="server"  Text="Salary"></asp:Label>

       </td>
       <td>
           <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>

       </td>
   </tr>
   <tr>
       <td>
           <asp:Label ID="Label6" runat="server" Text="Department" ></asp:Label>

       </td>
       <td>
           <asp:DropDownList  runat="server" ID="ddlDepartment" Width="175px" Height="25px" >
            <asp:ListItem Text="-- Select Department --" Value="" />
            <asp:ListItem Text="HR" Value="HR" />
            <asp:ListItem Text="IT" Value="IT" />
            <asp:ListItem Text="Finance" Value="Finance" />
  
       </asp:DropDownList>
           
       </td>
   </tr>
   <tr>
       <td>
           <asp:Label ID="Label7" runat="server" Text="Joining Date" ></asp:Label>

       </td>
       <td>
           <asp:TextBox ID="txtJoining" runat="server" TextMode="Date" Width="172px" Height="24px"></asp:TextBox>


       </td>
   </tr>
   <tr>
       <td>
           <asp:Label ID="Label8" runat="server" Text="City"></asp:Label>

       </td>
       <td>
           <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>

       </td>
   </tr>
         <tr>
             <td></td>
             <td>
            
                 
                 <asp:Button ID="Insert" runat="server" BackColor="BlueViolet" Width="100px" Height="40px" Font-Bold="true" ForeColor="White"  Text="Sumbit" OnClick="Insert_Click">

                 </asp:Button>
                 <asp:Button ID="Reset" runat="server" BackColor="Red" Width="100px" Height="40px" Font-Bold="true" ForeColor="White"  Text="Reset" OnClick="Reset_Click"></asp:Button>
                
                 </td>
          </tr>          

   </table>
     </div>
           

</div>

    <asp:GridView ID="GridView1" Class="grid" runat="server" AutoGenerateColumns="False"  Font-Overline="False" DataKeyNames="EmployeeId" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" BorderColor="Red" BackColor="#66FFFF" BorderStyle="None" EditRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Middle">
        <Columns>

            <asp:BoundField DataField="EmployeeId" HeaderText="Employee ID" ReadOnly="True" />
        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
        <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
        <asp:BoundField DataField="Salary" HeaderText="Salary" SortExpression="Salary" />
        <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
        <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date" SortExpression="JoiningDate" />
        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />

            <asp:CommandField ButtonType="Button" ShowEditButton="True" />
    
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />

        <%--<asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewFirstName" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    
       </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewLastName" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Age" SortExpression="Age">
                      <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Age") %>'></asp:Label>
                        </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="txtEditAge" runat="server" Text='<%# Bind("Age") %>'></asp:TextBox>
                    </EditItemTemplate>
                     <FooterTemplate>
                     <asp:TextBox ID="txtNewAge" runat="server"></asp:TextBox>
                    </FooterTemplate>
                     </asp:TemplateField>
                        
                             <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                 <ItemTemplate>
                                   <asp:Label runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                          </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtEditEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtNewEmail" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        </asp:TemplateField>

                 <asp:TemplateField HeaderText="PhoneNumber" SortExpression="PhoneNumber">
                        <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtEditPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                         <asp:TextBox ID="txtNewPhoneNumber" runat="server"></asp:TextBox>
                          </FooterTemplate>
                  </asp:TemplateField>

            <asp:TemplateField HeaderText="Salary" SortExpression="Salary">
              <ItemTemplate>
              <asp:Label runat="server" Text='<%# Eval("Salary") %>'></asp:Label>
             </ItemTemplate>
             <EditItemTemplate>
                 <asp:TextBox ID="txtEditSalary" runat="server" Text='<%# Bind("Salary") %>'></asp:TextBox>
                </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="txtNewSalary" runat="server"></asp:TextBox>
                    </FooterTemplate>
               </asp:TemplateField>

             <asp:TemplateField HeaderText="Department" SortExpression="Department">
                        <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                       </ItemTemplate>
                    <EditItemTemplate>
                     <asp:TextBox ID="txtEditDepartment" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                        </EditItemTemplate>
                      <FooterTemplate>
                      <asp:TextBox ID="txtNew" runat="server"></asp:TextBox>
                      </FooterTemplate>
               </asp:TemplateField>

    <asp:TemplateField HeaderText="JoiningDate" SortExpression="JoingDate">
        <ItemTemplate>
        <asp:Label runat="server" Text='<%# Eval("JoiningDate") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
        <asp:TextBox ID="txtEditJoiningDate" runat="server" Text='<%# Bind("JoiningDate") %>'></asp:TextBox>
        </EditItemTemplate>
        <FooterTemplate>
         <asp:TextBox ID="txtNewJoiningDate" runat="server"></asp:TextBox>
          </FooterTemplate>
  </asp:TemplateField>

   <asp:TemplateField HeaderText="City" SortExpression="City">
      <ItemTemplate>
      <asp:Label runat="server" Text='<%# Eval("City") %>'></asp:Label>
      </ItemTemplate>
      <EditItemTemplate>
      <asp:TextBox ID="txtEditCity" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
      </EditItemTemplate>
      <FooterTemplate>
       <asp:TextBox ID="txtNewCity" runat="server"></asp:TextBox>
        </FooterTemplate>
</asp:TemplateField>--%>

     
     </Columns>
</asp:GridView> 
  
</asp:Content>
