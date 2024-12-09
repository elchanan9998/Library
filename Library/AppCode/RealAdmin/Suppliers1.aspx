<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suppliers1.aspx.cs" Inherits="Library.AppCode.RealAdmin.Suppliers1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ספקי ספרים</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
        }
        h1 {
            color: #343a40;
            text-align: center;
            margin-bottom: 30px;
        }
        .table {
            margin-top: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            background-color: #fff;
            border-radius: 10px;
        }
        .table th, .table td {
            text-align: center;
            vertical-align: middle;
        }
        .table img {
            width: 100px;
            height: auto;
            border-radius: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1>ספקי ספרים</h1>
            <asp:Repeater ID="rptSuppliers" runat="server">
                <HeaderTemplate>
                    <table class="table table-hover">
                        <thead class="thead-dark">
                            <tr>
                                <th>תמונה</th>
                                <th>שם ספק</th>
                                <th>טלפון</th>
                                <th>דוא"ל</th>
                                <th>כתובת</th>
                                <th>אתר אינטרנט</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><img src='<%# Eval("ImageUrl") %>' alt="תמונת ספק" /></td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Phone") %></td>
                        <td><a href='mailto:<%# Eval("Email") %>'><%# Eval("Email") %></a></td>
                        <td><%# Eval("Address") %></td>
                        <td><a href='<%# Eval("Website") %>' target="_blank"><%# Eval("Website") %></a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
