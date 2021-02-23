<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="JourDeClasse.aspx.cs" Inherits="CCPS_Web_Edu_Update.JourDeClasse" %>
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
                              <p class="panel-title">Jours de Classe</p>
                            </div>
                             <div class="panel-body">
                              <div class="form-group">
                                <label>*separez les jours avec un tirait (-)</label>
                              </div>
                               <div class="form-group">
                                  <label>Entrez le jour</label>
                                 <asp:TextBox ID="txtJour" runat="server"  class="form-control" placeholder="Jour Ou Jour1-Jour2" MaxLength="40"></asp:TextBox>
                               </div>
                                      <br /><br /><br />
                               <div class="form-group">                                
                                 <asp:Button ID="AddJour" runat="server" Width="200" Text="SAUVEGARDEZ" class="btn btn-outline btn-primary" OnClick="AddJour_Click"/>               
                              </div>
                             </div> 
                            </div>
                           </div> 
         <div class="col-sm-5"></div>
         </div>
                      </div></div></div></div>
         </div>
</asp:Content>
