<%@ Page Title="" Language="C#" MasterPageFile="~/AppCode/RealAdmin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="Library.AppCode.RealAdmin.UsersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="css/dataTables.bootstrap4.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
      <h1>רשימת משתמשים</h1>
                  <div class="card shadow">
                    <div class="card-body">
                      <!-- table -->
                      <table class="table datatables" id="MainTbl">
                        <thead>
                          <tr>
                            <th>#</th>
                            <th>שם מלא </th>
                            <th> שם משתמש</th>
                            <th>סיסמה </th>
                            <th>אימייל</th>
                            <th>טלפון</th>
                            <th>תאריך הצטרפות</th>
                            <th>כתובת </th>
                            <th>פעולה</th>
                            
                          </tr>
                        </thead>
                  <tbody>
                      <asp:Repeater ID="RpUsers" runat="server">
                          <ItemTemplate>
                                <tr>
                            <td><%#Eval("UserId") %></td>
                            <td><%#Eval("Name") %></td>
                            <td><%#Eval("UserName") %></td>
                            <td><%#Eval("UserPass") %></td>
                            <td><%#Eval("Email") %></td>
                            <td><%#Eval("Phone") %></td>
                            <td><%#Eval("JoinDate") %></td>
                            <td><%#Eval("Address") %></td>
                            <td>
                              <button class="btn btn-sm dropdown-toggle more-horizontal" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="text-muted sr-only">פעולה</span>
                              </button>
                              <div class="dropdown-menu dropdown-menu-right">
                                <a class="dropdown-item" href='<%#Eval("UserId","UserAdd.aspx?UserId={0}") %>' onclick="return confirm('Are you sure you want to edit this User?');">עריכה</a>
                                <a class="dropdown-item" href='<%#Eval("UserId","UserDelete.aspx?UserId={0}") %>' onclick="return confirm('Are you sure you want to delete this User?');">הסרה</a>
                              </div>
                            </td>

                          </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                        
                      </tbody>
                      </table>
                    </div>
                  </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
    <script src='js/jquery.dataTables.min.js'></script>
    <script src='js/dataTables.bootstrap4.min.js'></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
    <script>
        $('#MainTbl').DataTable(
      {
        autoWidth: true,
        "lengthMenu": [
          [16, 32, 64, -1],
          [16, 32, 64, "All"]
              ],
          language: {
              url: '//cdn.datatables.net/plug-ins/2.0.8/i18n/he.json'
          }
      });


    </script>
</asp:Content>
