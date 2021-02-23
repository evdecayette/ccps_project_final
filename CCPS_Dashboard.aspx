<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="CCPS_Dashboard.aspx.cs" Inherits="CCPS_Web_Edu_Update.CCPS_Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class ="col-sm-12">        
        <div class="panel panel-primary">
            <div class="panel-heading form-control">
                <label class="" id="lblMenu"> MENU PRINCIPAL CCPS</label>
            </div>

                <div class="panel-body">
                    <div class="container ">
                        <%--Premiere ligne--%>
                    <div class="row">
                        <div class=" col-sm-4 ">
                            <br />
                            <div class="form-group ">  
                                <asp:Button ID="btnInscrireNouveauxEtudiants"  runat="server" Text="INSCRIRE ETUDIANTS" Class="btn btn-primary btn-lg form-control" Height="51px" Width="300px" OnClick="btnInscrireNouveauxEtudiants_Click" Font-Bold="True" Font-Size="11pt"/>                                                                 
                            </div>
                        </div>

                           <div class="col-sm-4 ">
                           <br />
                           <div class="form-group">  
                                <asp:Button ID="btnListeDesEtudiants" runat="server"  Text="LISTE DES ETUDIANTS" Class="btn btn-primary btn-lg form-control" Height="51px" Width="300px" OnClick="btnListeDesEtudiants_Click" Font-Bold="True" Font-Size="11pt"/>                                                                
                           </div>
                           </div>


                            <div class="col-sm-4 ">
                            <br />
                            <div class="form-group">  
                                <asp:Button ID="btnEtudiantsParClasse" runat="server" Text="ETUDIANTS PAR CLASSE(EXCEL)" Class="btn btn-primary btn-lg form-control" Height="51px" Width="300px" OnClick="btnEtudiantsParClasse_Click" Font-Bold="True" Font-Size="11pt"/>                                                                
                            </div>

                            </div>
                           
                      </div>  <%--Fin Premiere ligne--%>  


                        <%--Deuxième ligne--%>

                       
                        <div class="row">
                            <div class="col-sm-4">
                                 <br />
                                <div class="form-group">  
                                    <asp:Button ID="btnModiferHoraire" runat="server" Text="MODIFIER HORAIRE" Class="btn btn-primary btn-lg" Width="300px" OnClick="btnModiferHoraire_Click" Font-Bold="True" Font-Size="11pt" Height="51px"/>                                                                
                                </div>
                            </div>

                                <div class="col-sm-4">
                                     <br />
                                    <div class="form-group">  
                                        <asp:Button ID="btnCreerSession" runat="server" Text="AJOUTER CLASSE" Class="btn btn-primary btn-lg" Width="300px" OnClick="btnCreerSession_Click" Font-Bold="True" Font-Size="11pt" Height="51px"/>                                                                
                                    </div>
                                </div>
                            
                            <div class="col-sm-4 ">
                                 <br />
                                 <div class="form-group">  
                                        <asp:Button ID="btnAjouterEtudiantsDansClasse" runat="server" Text="AJOUTER ETUDIANTS DANS CLASSE" Class="btn btn-primary btn-lg" Width="300px" OnClick="btnAjouterEtudiantsDansClasse_Click" Font-Bold="True" Font-Size="11pt" Height="51px"/>                                                                
                                 </div>
                            </div>
                           
                        </div>    <%--Fin Deuxième ligne--%>
                       
                        <%--Troisième ligne--%>                
                 
                        <div class="row ">
                            <div class="col-sm-4">
                                <br />
                                <div class="form-group">  
                                    <asp:Button ID="btnVoirEtudiantsParClasse" runat="server" Text="VOIR ETUDIANTS PAR CLASSE" Class="btn btn-primary btn-lg" Width="300px" OnClick="btnVoirEtudiantsParClasse_Click" Font-Bold="True" Font-Size="11pt" Height="51px"/>                                                                
                                </div>
                            </div>

                                <div class="col-sm-4">
                                    <br />
                                    <div class="form-group">  
                                        <asp:Button ID="btnEnleverEtudiantsDansClasse" runat="server" Text="ENLEVER ETUDIANTS DANS CLASSE" Class="btn btn-primary btn-lg" Width="300px" OnClick="btnEnleverEtudiantsDansClasse_Click" Font-Bold="True" Font-Size="11pt" Height="51px"/>                                                                
                                    </div>
                                </div>

                            <div class="col-sm-4">
                                <br />
                                 <div class="form-group">  
                                        <asp:Button ID="btnEtudiantsDejaGradues" runat="server" Text="ETUDIANTS DEJA GRADUES" Class="btn btn-primary btn-lg" Width="300px" OnClick="btnEtudiantsDejaGradues_Click" Font-Bold="True" Font-Size="11pt" Height="51px"/>                                                                
                                 </div>

                            </div>
                           
                        </div>  
                      

                         
                        <div class="row">
                            <div class="col-sm-4">
                                <br />
                                <div class="form-group">  
                                                                                               
                                </div>
                            </div>
                                <div class="col-sm-4 ">
                                    <br />
                                    <div class="form-group">  
                                        <asp:Button ID="btnSetupPourAdmin" runat="server" Text="SETUP POUR ADMINISTRATEUR" Class="btn btn-primary btn-lg" Width="300px" OnClick="btnSetupPourAdmin_Click" Font-Bold="True" Font-Size="11pt" Height="51px"/>                                                                
                                    </div>
                                </div>


                            <div class="col-sm-4">
                                <br />
                               
                            </div>
                           
                        </div>              

                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>


                  </div>
                 </div>

             </div>
           </div>
</asp:Content>
