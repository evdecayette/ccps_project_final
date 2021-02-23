<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SalleDeClasse.aspx.cs" Inherits="CCPS_Web_Edu_Update.SalleDeClasse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class='col-sm-12'>
        <div class='panel-primary'>
          <div class='panel panel-primary'>
            <div class='panel-heading text-center panel-relative'>
               <label class="block-cente"> PARAMETRES</label>
             </div>
                 <div class='panel-body'>
                  <div class="container">
                   <div class="row">
                            <div class="col-sm-1"></div>
                        <div class="col-sm-6">
                           <div class="panel panel-primary">
                            <div class="panel-heading text-center panel-relative">
                              <p class="panel-title">Salle De Classe</p>
                            </div>
                             <div class="panel-body">
                              <div class="form-group">
                              <div class="form-group">
                                  <br />
                               <asp:TextBox ID="txtSallDeClasse" runat="server" Height="40" rows="2" placeholder="Entrez le nom d'une salle *" class="form-control" ></asp:TextBox>
                             </div>
                                  <br />
                              <div class="form-group">
                                  <br />
                               <asp:TextBox ID="txtDescriptionSalle" runat="server" Height="40" rows="2" placeholder="Description" class="form-control" ></asp:TextBox>
                             </div>
                              </div>
                              <br />
                               <div class="form-group">                                
                                 <asp:Button ID="btnSalleName" Height="40" runat="server" Width="200" Text="SAUVEGARDEZ" class="btn btn-outline btn-primary" OnClick="btnSalleName_Click"/>
                                
                              </div>
                             </div> 
                           </div>
                          </div>
                            <div class="col-sm-5"></div>
                       </div></div></div></div></div></div>
</asp:Content>
