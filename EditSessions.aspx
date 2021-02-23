 <%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditSessions.aspx.cs" Inherits="CCPS_Web_Edu_Update.EditSessions" %>
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
                  <div class="col-sm-8">
                    <div class="form-group">
                       <asp:DropDownList runat="server" CausesValidation="True" AutoPostBack="true" CssClass="form-control" ID="cbo_A_Modifier" OnSelectedIndexChanged="cbo_A_Modifier_SelectedIndexChanged"/>
                     </div>
                    </div>
                  </div>
                 <div class="row">
                    <%-- <div class="col-sm-1"></div>--%>
                  <div class="col-sm-4">      
               <div class="panel panel-primary">
                            <div class="panel-heading text-center panel-relative">
                              <p class="panel-title">Creer Une Nouvelle Session</p>
                            </div>
                           <div class="panel-body">
                            <div class="form-group">
                             <asp:DropDownList runat="server" CausesValidation="True" AutoPostBack="true" CssClass="form-control" ID="cboClasses"/>
                            </div>
                               
                               <div class="form-group">
                             <asp:DropDownList runat="server" CssClass="form-control" ID="cboJourDeClasses" />
                            </div>
                               
                               <div class="form-group">    
                               <asp:TextBox ID="txtMaxEtudiants" runat="server" rows="2" placeholder="Max Etudiant" class="form-control" ></asp:TextBox>
                             </div>
                             
                               <div class="form-group">                                
                                <label>Date Debut de la session </label><label id ="debuSessionCourante" runat ="server">*</label>                         
                                 <asp:TextBox ID="txtDateDebut" runat="server"  class="form-control" TextMode="Date" ToolTip="mm/jj/aaaa"></asp:TextBox>
                               </div>
                              
                               </div>
                             </div> 
                            </div>
                         <div class="col-sm-4">      
                           <div class="panel panel-primary">
                            <div class="panel-heading text-center panel-relative">
                              <p class="panel-title">Creer Une Nouvelle Session</p>
                            </div>
                           <div class="panel-body">
                            <div class="form-group">
                             <asp:DropDownList runat="server" CssClass="form-control" ID="cboProfesseurs" />
                            </div>
                              
                               <div class="form-group">
                             <asp:DropDownList runat="server"  CssClass="form-control" ID="cboHeuresDeClasses" />
                            </div>

                            <div class="form-group">    
                               <asp:TextBox ID="txtMontant" runat="server" rows="2" placeholder="Montant En Gourde (HTG)" class="form-control" ></asp:TextBox>
                             </div>
                               
                               <div class="form-group">                                
                                <label>Date Fin de la session </label><label id ="lblDateFin" runat ="server">*</label>                         
                                 <asp:TextBox ID="txtDateFin" runat="server"  class="form-control" TextMode="Date" ToolTip="mm/jj/aaaa"></asp:TextBox>
                               </div>
                             </div> 
                            </div>
                     </div>
                      
                     
   <%-- THe My --%>

    <%--Deuxieme ligne avec trois colums--%>
                     <div class='col-sm-12'> 
                        <div class="row">
                         <div class="col-sm-4"> <label id="lblError" runat="server"></label>
                         </div>            
                          <div class="col-sm-4">
                           <asp:Button ID="BtnAddClasse" runat="server" Width="200" Text="SAUVEGARDEZ" class="btn btn-outline btn-primary"/>
                          </div>
                          <div class="col-sm-4">
                           </div>
                          </div>
                         </div>
                        </div>
                       </div>
                      </div>
                    </div>
                   </div>
</asp:Content>
