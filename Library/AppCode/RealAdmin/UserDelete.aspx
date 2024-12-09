<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteUser.aspx.cs" Inherits="YourNamespace.DeleteUser" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete User</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header">
                            <h3>אישור מחיקת משתמש</h3>
                        </div>
                        <div class="card-body">
                            <p>האם אתה בטוח שברצונך למחוק את המשתמש?</p>
                            <asp:Label ID="lblUserName" runat="server" Text="" CssClass="font-weight-bold"></asp:Label>
                            <div class="mt-3">
                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="מחק" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="בטל" OnClick="btnCancel_Click" />
                            </div>
                            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-3"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
