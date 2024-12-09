<%@ Page Title="" Language="C#" MasterPageFile="~/RealAdmin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AgentAdd.aspx.cs" Inherits="RealEstateAshdod.RealAdmin.AgentAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
     <div class="col-md-6">
                  <div class="card shadow mb-4">
                    <div class="card-header">
                      <strong class="card-title">הוספה / עריכת סוכנים</strong>
                    </div>
                    <div class="card-body">
                      
                        <div class="form-row">
                          <div class="col-md-6 mb-3">
                              <asp:HiddenField ID="HidAgentId" runat="server" Value="-1" />
                            <label for="TxtId">מספר רישיון תיווך</label>
                              <asp:TextBox ID="TxtId" runat="server"  class="form-control" placeholder="נא הזן מספר מתווך"/>
                           </div>
                            <div class="col-md-6 mb-3">
                            <label for="TxtFullName">שם מלא</label>
                              <asp:TextBox ID="TxtFullName" runat="server"  class="form-control" placeholder="נא הזן שם מלא"/>
                           </div>
                           <div class="col-md-4 mb-3">
                            <label for="TxtPhone">טלפון</label>
                              <asp:TextBox ID="TxtPhone" runat="server" TextMode="Phone"  class="form-control" placeholder="נא הזן טלפון"/>
                           </div>

                              <div class="col-md-4 mb-3">
                            <label for="TxtEmail">מייל</label>
                              <asp:TextBox ID="TxtEmail" runat="server" TextMode="Email"  class="form-control" placeholder="נא הזן דואר אלקטרוני" />
                           </div>
                              <div class="col-md-4 mb-3">
                            <label for="TxtPass">סיסמה</label>
                              <asp:TextBox ID="TxtPass" runat="server" TextMode="Password"  class="form-control" placeholder="נא הזן סיסמה" />
                           </div>
                              <div class="col-md-4 mb-3">
                            <label for="TxtStartDate">תאריך תחילת עבודה</label>
                              <asp:TextBox ID="TxtStartDate" runat="server" TextMode="Date"  class="form-control" placeholder="נא הזן תאריך תיחלת העסקה בחברה" />
                           </div>
                              <div class="col-md-4 mb-3">
                            <label for="TxtAddress">כתובת</label>
                              <asp:TextBox ID="TxtAddress" runat="server"  class="form-control"  placeholder="נא הזן כתובת"/>
                           </div>
                            <div class="col-md-4 mb-3">
                            <label for="DDLCity">עיר</label>
                                  <asp:DropDownList ID="DDLCity" runat="server" class="form-control" />
                             
                           </div>
                            <asp:Button ID="BtnSave" runat="server" Text="שמירה" class="btn btn-success" OnClick="BtnSave_Click"/>


                        
                    
                    </div> <!-- /.card-body -->
                  </div> <!-- /.card -->
                </div> <!-- /.col -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
</asp:Content>
