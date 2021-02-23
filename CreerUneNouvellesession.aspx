<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CreerUneNouvellesession.aspx.cs" Inherits="CCPS_Web_Edu_Update.CreerUneNouvellesession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class='col-sm-14'>  
          <div class='panel panel-primary'>
            <div 
                class='panel-heading text-center panel-relative'>
               <label class="block-cente">Parametre Session Courante</label>
             </div>
               <div class='panel-body'>
                <div class="container">
                 <div class="row">
                  <div class="col-sm-4">      
               <div class="panel panel-primary">
                            <div class="panel-heading text-center panel-relative">
                              <p class="panel-title">Ajouter Une Classe Dans La Session</p>
                            </div>
                           <div class="panel-body">
                            <div class="form-group">
                             <asp:DropDownList runat="server" CausesValidation="True" AutoPostBack="true" CssClass="form-control" ID="NomClasse" OnSelectedIndexChanged="NomClasse_SelectedIndexChanged1" />
                            </div>
                              
                               <div class="form-group">
                             <asp:DropDownList runat="server" CssClass="form-control" ID="dJourDeClasse" />
                            </div>
                              
                               <div class="form-group">    
                               <asp:TextBox ID="txtMaxEtudiant" runat="server" rows="2" placeholder="Max Etudiant" class="form-control" ></asp:TextBox>
                             </div>
                             
                               <div class="form-group">                                
                                 <Label ID="lblDateDebut" runat="server">Debut de La Session: </Label>
                               </div>
                              
                               </div>
                             </div> 
                            </div>
                         <div class="col-sm-4">      
                           <div class="panel panel-primary">
                            <div class="panel-heading text-center panel-relative">
                              <p class="panel-title">Ajouter Une Classe Dans La Session</p>
                            </div>
                           <div class="panel-body">
                            <div class="form-group">
                             <asp:DropDownList runat="server" CssClass="form-control" ID="DrpProfesseurName" />
                            </div>
                              
                               <div class="form-group">
                             <asp:DropDownList runat="server"  CssClass="form-control" ID="DropHeureDeClasse"/>
                            </div>
                               
                            <div class="form-group">    
                               <asp:TextBox ID="txtMontant" runat="server" rows="2" placeholder="Montant En Gourde (HTG)" class="form-control" ></asp:TextBox>
                             </div>
                               
                               <div class="form-group">                                
                                 <Label ID="lblDateFin" runat="server">Fin de La Session: </Label>                            
                               </div>
                               
                             </div> 
                            </div>
                     </div>
                     
   <%-- THe My --%>

    <%--Deuxieme ligne avec trois colums--%>
                     <div class="row">
                       <div class='col-sm-12'>
                        <div class="col-sm-1"></div>
                         <div class="col-sm-3">
                           <div class="form-group">
                             <asp:Button ID="btnCancel" runat="server" Width="200" Text="CANCEL" class="btn btn-outline btn-primary" OnClick="btncancel_Click"/>
                           </div>
                          </div>
                           <div class="col-sm-1">
                           
                          </div>
                          <div class="col-sm-2">
                              <div class="form-group">
                                 <asp:Button ID="BtnAddClasse" runat="server" Width="200" Text="SAUVEGARDEZ" class="btn btn-outline btn-primary" OnClick="BtnAddClasse_Click"/>
                           </div>
                          </div>
                          <div class="col-sm-1">
                           
                          </div>
                          <div class="col-sm-4">
                           <label id="lblError" runat="server" Text="" text-color="green" Font-Bold="True" Font-Size="Medium" ForeColor="red"></label>
                           <asp:Label ID="lblSucces" runat="server" Text="" text-color="green" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                           </div>
                          </div>
                         </div>
                        </div>
                       </div>
                     </div>
                    </div>
       </div>
</asp:Content>
