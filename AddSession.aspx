<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddSession.aspx.cs" Inherits="CCPS_Web_Edu_Update.AddSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class='col-sm-12'>
         <div class='panel panel-primary'>
            <div class='panel-heading text-center panel-relative'>
               <label class="block-cente">Parametre Session Courante</label>
             </div>
              <div class='panel-body'>
                <div class="container">
                 <div class="row">
                   <div class="col-sm-1">
                      </div>
                       <div class="col-sm-6">      
                        <div class="panel panel-primary">
                            <div class="panel-heading text-center panel-relative">
                               <p>Creer Une Nouvelle Session</p>
                            </div>
                             <div class="panel-body">
                             <div class="form-group">
                                
                                   <label>Date Debut </label><label id ="debuSessionCourante" runat ="server">*</label>
                                
                                 <asp:TextBox ID="DateDebut" runat="server" class="form-control" placeholder="Entrer la Date de Naissance" TextMode="Date" ToolTip="mm/jj/aaaa"></asp:TextBox>
                               </div> 
                               <div class="form-group">     
                              
                                  <label>Date Fin  </label>   <label id="FinSessionCourante" runat="server"> *</label>              
                                 <asp:TextBox ID="DateFin" runat="server" class="form-control" TextMode="Date" ToolTip="mm/jj/aaaa"></asp:TextBox>
                               </div>
                               <div class="form-group">    
                               <asp:TextBox ID="SessionRemarque" runat="server" rows="2" placeholder="Remarque" class="form-control" ></asp:TextBox>
                             </div>

                               <div class="form-group">                                
                                 <asp:Button ID="btnAddSession" runat="server" Width="200" Text="SAUVEGARDEZ" CssClass="Blue" OnClick="btnAddSession_Click"/>
                                 <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" Text="Editer" OnCheckedChanged="CheckBox1_CheckedChanged" />
                              </div>
                             </div> 
                            </div>
                      <div class="col-sm-5">

                      </div>
                     
                     
   <%-- THe My --%>

    <%--Deuxieme ligne avec trois colums--%>
                        <div class="row">
                         <div class="col-sm-4"> 
                             <label runat="server" id="lblError"></label>
                         </div>            
                          <div class="col-sm-4">
                          
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
