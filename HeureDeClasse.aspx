<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="HeureDeClasse.aspx.cs" Inherits="CCPS_Web_Edu_Update.HeureDeClasse" %>
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
                             <p class="panel-title">Heure de Classe</p>
                            </div>
                              <div class="panel-body">
                            <div class="form-group">
                                <label>*Separez les heures avec un tirait (-)</label>                
                            </div>
                             <div class="form-group">
                                 <label>Entrez l'heure</label>
                               <asp:TextBox ID="txtHeure" runat="server" Height="40"  class="form-control" placeholder="2hPM-4hPM" MaxLength="40"></asp:TextBox>
                             </div>
                              <div class="form-group">
                               <asp:DropDownList runat="server" CssClass="form-control" ID="DroClasseCat" />
                             </div>
                             <div class="form-group">                                
                               <asp:Button ID="AddHeure" runat="server" Width="200" Text="SAUVEGARDEZ" class="btn btn-outline btn-primary" OnClick="AddHeure_Click"/>                            
                             </div>
                            </div> 
                           </div>
                          </div>
                        <div class="col-sm-5"></div>
                       </div></div></div></div></div></div>
</asp:Content>
