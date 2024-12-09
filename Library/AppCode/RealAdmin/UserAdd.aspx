<%@ Page Title="" Language="C#" MasterPageFile="~/AppCode/RealAdmin/NewAdminMaster.Master" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="Library.AppCode.RealAdmin.UserAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
     <div class="col-md-6">
                  <div class="card shadow mb-4">
                    <div class="card-header">
                      <strong class="card-title"> הוספת/עריכת משתמש</strong>
                    </div>
                    <div class="card-body">
                     
                        <div class="form-row">
                          <div class="col-md-6 mb-3">
                              <asp:HiddenField ID="HidUserId" runat="server" Value="-1" />
                            <label for="TxtUserId">מספר משתמש</label>
                              <asp:TextBox ID="TxtUserId" runat="server" class="form-control" placeholder="נא הזן מספר משתמש" />
                           </div>
                             <div class="col-md-6 mb-3">
                            <label for="TxtUserName">שם משתמש</label>
                              <asp:TextBox ID="TxtUserName" runat="server" class="form-control" placeholder="נא הזן שם משתמש" />
                           </div>
                               <div class="col-md-4 mb-3">
                            <label for="TxtName">שם מלא</label>
                              <asp:TextBox ID="TxtName" runat="server" class="form-control" placeholder="נא הזן שם מלא" />
                           </div>
                                  <div class="col-md-4 mb-3">
                            <label for="TxtUserPass">סיסמא</label>
                              <asp:TextBox ID="TxtUserPass" runat="server" TextMode="Password" class="form-control" placeholder="נא הזן סיסמא" />
                           </div>
                                 <div class="col-md-4 mb-3">
                            <label for="TxtPhone">טלפון</label>
                              <asp:TextBox ID="TxtPhone" runat="server" TextMode="Phone" class="form-control" placeholder="נא הזן מספר טלפון" />
                           </div>
                                 <div class="col-md-4 mb-3">
                            <label for="TxtEmail">אמייל</label>
                              <asp:TextBox ID="TxtEmail" runat="server" TextMode="Email" class="form-control" placeholder="נא הזן אמייל" />
                           </div>
                                 <div class="col-md-4 mb-3">
                            <label for="TxtAddress">כתובת</label>
                              <asp:TextBox ID="TxtAddress" runat="server" class="form-control" placeholder="נא הזן כתובת " />
                           </div>
                                 <div class="col-md-4 mb-3">
                            <label for="TxtJoinDate">תאריך הצטרפות</label>
                              <asp:TextBox ID="TxtJoinDate" runat="server" TextMode="Date" class="form-control" placeholder="נא הזן תאריך הצטרפות" />
                           </div>
                        
                            <asp:Button ID="BtnSave" runat="server" Text="שמירה" class="btn btn-success" OnClick="BtnSave_Click" /> 

                    </div> 
                  </div> 
                </div> 
         </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
</asp:Content>
