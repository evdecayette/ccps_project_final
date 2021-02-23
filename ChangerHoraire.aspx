<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="ChangerHoraire.aspx.cs" Inherits="CCPS_Web_Edu_Update.ChangerHoraire" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/bootstrap.css" rel="stylesheet">   
     <link href="assets/css/tuto.css" rel="stylesheet"> 
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='col-sm-12'>
        <div class='panel-primary'>
          <div class='panel panel-primary'>
            <div class='panel-heading'>
               <label class="block-cente"> PARAMETRES</label>
                <asp:TextBox ID="Recherche" runat="server" style="width:360px;" class="form-control" placeholder="Recherche" name="search" AutoPostBack="True" OnTextChanged="Recherche_TextChanged1"  ></asp:TextBox>
                </div>
                 <div class='panel-body'>
                  <div class="container">
                   <div class="row">
                     <div class="col-sm-4">
                           <div class="panel panel-primary">
                            <div class="panel-heading">
                              <label class="panel-title">Choississez un Etudiant</label>
                            </div>
                             <div class="panel-body">

                             <div class="form-group" style="width:360px;">  
                                   <asp:ListBox ID="lstTousEtudiant" Height="300"  CausesValidation="true"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="lstToutEtudiant_SelectedIndexChanged"></asp:ListBox>                                          
                                </div>
                              </div>
                             </div> 
                            </div>                                   
                          <div class="col-sm-4">
                           <div class="panel panel-primary">
                            <div class="panel-heading">
                             <label class="panel-title">Classe a Enlever</label>
                            </div>
                              <div class="panel-body">
                               <div class="form-group" style="width:300px;">
                                   <asp:ListBox ID="lstClasseEnlver" height="300" runat="server"></asp:ListBox>
                                </div>
                              </div>
                            </div> 
                           </div>          
                          <div class="col-sm-4">
                           <div class="panel panel-primary">
                            <div class="panel-heading">
                              <label class="panel-title">Classe a Ajouter</label>
                            </div>
                             <div class="panel-body">
                              <div class="form-group"  style="width:300px;">
                                   <asp:ListBox ID="lstClasseAjouter" height="300" runat="server"></asp:ListBox>                                          
                                </div>
                             </div> 
                           </div>
                          </div>   
                      </div>
                     <div class="row">
                         <div class="col-sm-4">
                             <div class="form-group">
                             </div>
                         </div>
                         <div class="col-sm-4">
                          <div class="form-group">

                          </div>
                          </div> 
                            <div class="col-sm-4">
                               <div class="form-group">                                
                                 <asp:Button ID="btnChangez" runat="server" Width="200" Text="CHANGEZ" class="btn btn-outline btn-primary" OnClick="btnChangez_Click"/>               
                              </div>
                            </div>
                       </div>

                  </div>
             </div>              
         </div>
     </div>   
   </div>
</asp:Content>

