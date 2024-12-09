<%@ Page Title="" Language="C#" MasterPageFile="~/RealAdmin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AgentList.aspx.cs" Inherits="RealEstateAshdod.RealAdmin.AgentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="css/dataTables.bootstrap4.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h1>רשימת סוכנים</h1>
     <div class="card shadow">
                    <div class="card-body">
                      <!-- table -->
                      <table class="table datatables" id="MainTbl">
                        <thead>
                          <tr>                          
                            <th>#</th>
                            <th>שם הסוכן</th>
                            <th>טלפון</th>
                            <th>מייל</th>
                            <th>כתובת</th>
                            <th>עיר</th>                          
                            <th>פעולה</th>
                          </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RptAgent" runat="server" >
                                <ItemTemplate>
                                     <tr>                          
                                    <td><%#Eval("AgentId") %></td>
                                    <td><%#Eval("FullName") %></td>
                                    <td><%#Eval("Phone") %></td>
                                    <td><%#Eval("Email") %></td>
                                    <td><%#Eval("Address") %></td>
                                    <td><%#Eval("CityId") %></td>
                                    <td><button class="btn btn-sm dropdown-toggle more-horizontal" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <span class="text-muted sr-only">פרטים נוספים</span>
                                      </button>
                                      <div class="dropdown-menu dropdown-menu-right" >
                                        <a class="dropdown-item" href="AgentAdd.aspx?AgentId=<%#Eval("AgentId") %>">עריכה</a>
                                        <a class="dropdown-item" href="#">מחיקה</a>
                                        <a class="dropdown-item" href="#">כרטיס סוכן</a>
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
