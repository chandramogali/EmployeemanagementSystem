<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="EmployeemanagementSystem.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Employee Details</title>
    <style>

        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        form {
            max-width: 600px;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        table {
            width: 100%;
            border-collapse: collapse;
            
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 10px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }
      
     

        select {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            box-sizing: border-box;
        }

        button {
            background-color: #4caf50;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        button:hover {
            background-color: blue;
        }

  

GridView1 {
    width: 100%;
    margin-top: 20px;
    width: 80%; /* Adjust the width as needed */
    margin: 20px auto;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
      <table>
    <tr>
        <td>
            <asp:Label runat="server" Text="EmployeeID"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmpID" Type="Integer" runat="server"></asp:TextBox>
            <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
        </td>
    </tr>
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
            <asp:Label ID="Label6" runat="server" Text="Department"></asp:Label>

        </td>
        <td>
            <asp:DropDownList  runat="server" ID="ddlDepartment">
             <asp:ListItem Text="-- Select Department --" Value="" />
             <asp:ListItem Text="HR" Value="HR" />
             <asp:ListItem Text="IT" Value="IT" />
             <asp:ListItem Text="Finance" Value="Finance" />
   
        </asp:DropDownList>
            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Joining Date"></asp:Label>

        </td>
        <td>
            <asp:TextBox ID="txtJoining" runat="server" TextMode="DateTime"></asp:TextBox>

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
         <td>
             
         </td>
             
             <td>
                 <asp:Button ID="Insert" runat="server" Text="Insert" OnClick="Insert_Click"></asp:Button>
                 <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
                 <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" />
                 
            </td>
       
         </tr>
        <tr>
            <td>
                
            </td>
        </tr>
    
    </table>
     
 </div>
       <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
</body>
</html>



