<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Classe.aspx.cs" Inherits="CCPS_Web_Edu_Update.Classe" %>
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
                   <div class="col-sm-1"></div>
                    <div class="col-sm-6">
                           <div class="panel panel-primary">
                            <div class="panel-heading text-center panel-relative">
                             <p class="panel-title">CLASSE</p>
                            </div>
                              <div class="panel-body">
                            <div class="form-group">                        
                                <asp:TextBox ID ="txtNomClasse" runat="server" class="form-control" placeholder="Entrer le nom de la classe(Nom + I ou II ou +...)" MaxLength="40"></asp:TextBox>
                            </div>
                             <div class="form-group">
                               <asp:TextBox ID ="txtDescClasse" runat="server" class="form-control" placeholder="Entrer le niveau (Niveau)" MaxLength="40"></asp:TextBox>
                             </div>
                             <div class="form-group">
                              <asp:TextBox ID ="txtNiveau" runat="server" class="form-control" placeholder="Entrez le Niveau (1 , 2 ,...)" MaxLength="40"></asp:TextBox>
                             </div>
                             <div class="form-group">
                              <asp:TextBox ID ="txtCategorie" runat="server" class="form-control" placeholder="Classe Categorie (Anglais Ou Info ou autres..)" MaxLength="40"></asp:TextBox>
                             </div>
                             <div class="form-group">                                
                               <asp:Button ID="btnClasse" runat="server" Width="200" Text="SAUVEGARDEZ" class="btn btn-outline btn-primary" OnClick="btnClasse_Click"/>                          
                             </div>
                             <div class="form-group">
                                 <label id="lblError" runat="server"></label>
                             </div>
                            </div> 
                           </div>
                          </div>
                        <div class="col-sm-5"></div>
                      </div></div></div></div></div>
</asp:Content>
