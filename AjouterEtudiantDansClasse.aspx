<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="AjouterEtudiantDansClasse.aspx.cs" Inherits="CCPS_Web_Edu_Update.AjouterEtudiantDansClasse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
     <title> Etudiant Dans Classe</title>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="StyleSheet1.css" />
    <link href="assets/css/bootstrap.css" rel="stylesheet">   
     <link href="assets/css/tuto.css" rel="stylesheet"> 
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='col-sm-12'>
        <div class='panel-primary'>
          <div class='panel panel-primary'>
              <div class='panel-body'>
                  <div class="container">
                   <div class="row">
                     <div class="col-sm-6">
                           <div class="panel panel-primary">
                            <div class="panel-heading">
                              <label class="panel-title">
                                <div class="text-center">
                                    </div>
                                </label>
                               </div>
                             <div class="panel-body">
                             <div class="auto-style1">
                                 <!--C'est la liste qui affiche la liste des cours offerts par l'ecole-->

                                 <asp:DropDownList ID="ListeCours" runat="server" AutoPostBack="True" placeholder="Liste des Cours" Height="37px" Width="265px" OnSelectedIndexChanged="ListeCours_SelectedIndexChanged" BackColor="#D2D2D2" Font-Bold="True" Font-Size="Medium" ForeColor="Black" ToolTip="Cliquez pour choisir une option">
                                 </asp:DropDownList>                                  
                                </div>
                                 
                                   <div class="panel-heading">
                              <label class="panel-title">
                                <div class="text-center1" id="titre">
                                </div>
                                </label>&nbsp;</div>
                                  <div class="auto-style1">  
                                <!--C'est la liste qui affiche la liste qui affiche les niveaux-->

                                 <asp:DropDownList ID="ListeNiveau" runat="server" AutoPostBack="True" placeholder="Choisir Niveau" Height="37px" Width="265px" OnSelectedIndexChanged="ListeNiveau_SelectedIndexChanged" BackColor="#D2D2D2" Font-Bold="True" Font-Size="Medium" ForeColor="Black" ToolTip="Cliquez pour choisir  une classe">
                                      </asp:DropDownList>                                  
                                </div>
                                
                                   <div class="panel-heading">
                              <label class="panel-title">
                                <div class="text-center1">
                                    </div>
                                </label>&nbsp;</div>
                                  <div class="auto-style1">  
                                   <!--C'est la liste qui affiche la liste les horaires-->

                                 <asp:DropDownList ID="ListeHoraire" runat="server" AutoPostBack="True" placeholder="Choisir Horaire" Height="37px" Width="265px" OnSelectedIndexChanged="ListeHoraire_SelectedIndexChanged" BackColor="#D2D2D2" Font-Bold="True" Font-Size="Medium" ForeColor="Black" ToolTip="Cliquer pour choisir l'horaire">
                                      </asp:DropDownList> 
                                     
                                </div>                               
                                 <br />
                                 <br />
                                 
                              </div>
                             </div> 
                            </div>                                   
                          <div class="col-sm-6">
                           <div class="panel panel-primary">
                            <div class="panel-heading">
                             <label class="panel-title">
                                <div class="text-center">Choisir Un Étudiant
                                    </div>
                                </label>
                            &nbsp;</div>
                              <div class="panel-body">
                                   <div class="form-group" id="form1">
                                                <!--C'est la barre de recherche-->


                                       <asp:TextBox ID="Seach" TextMode="Search" placeholder="Chercher un étudiant" runat="server" AutoPostBack="True" Height="27px" OnTextChanged="Seach_TextChanged" Width="197px" BackColor="#D2D2D2" Font-Bold="True" ToolTip="Recherchez par nom ou prenom"></asp:TextBox>
                                <asp:button runat="server" ID="Clear" text="X" Height="27px" Width="49px" BackColor="#337AB7" Font-Bold="True" Font-Size="Medium" ForeColor="Red" OnClick="Clear_Click"/>
                                   </div>
                               <div class="form-group">
                                               <!--C'est la liste qui affiche tous les étudiants de l'actuelle session-->

                                   <asp:ListBox ID="lstClasse" height="152px" runat="server" AutoPostBack="True" BackColor="#D2D2D2" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:ListBox><br /><br />
                                  </div>

                              </div>
                            </div> 
                           </div>          
                        
                                             
                         </div>
                     <%-- Coll--%>
                       <div class="row">
                           <div class="col-sm-4"></div>
                          <div class="col-sm-4">
      
                            </div> 
                            <div class="col-sm-4">
                               <div class="form-group">                                
                                 <asp:Button ID="btnTerminer" runat="server" Width="200" Text="TERMINEZ" class="btn btn-outline btn-primary" OnClick="btnTerminer_Click"/>                                  
                                <div>
                                   <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="GREEN"></asp:Label> </div>
                              </div>
                            </div>
                    </div>
                </div>
              </div>          
            </div>
          </div> 
        </div>
</asp:Content>
