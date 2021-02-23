<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ChoixProf.aspx.cs" Inherits="CCPS_Web_Edu_Update.ChoixProf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class='col-sm-12'>
        <div class='panel-primary'>
          <div class='panel panel-primary'>
            <div class='panel-heading text-center panel-relative'>
               <label> PARAMETRES</label>
             </div>
                 <div class='panel-body'>
                  <div class="container">
                   <div class="row">
                      <div class="col-sm-1"></div>
                         <div class="col-sm-6">
                           <div class="panel panel-primary">
                            <div class="panel-heading text-center panel-relative">
                              <%-- class="panel-title">--%>Choix des Professeurs pour la session courante
                                <asp:Label ID="lblmsg" class="textcls" runat="server"></asp:Label> 
                                  <div class="row">
                                    <div class="col-sm-12">
                                      <div class="form-group">    
                                        <Textarea ID="Textarea1" name="txtAnnonce" width="400px" runat="server" placeholder="List des Professeurs choisir" rows="1" class="form-control" ></Textarea>
                                      </div> 
                                    </div>    
                                  </div>
                                </div>
                             <div class="panel-body">
                             
                               <div class="form-group" style="width:400px; height:150px; overflow-y:auto">
                                 <asp:CheckBoxList ID="ChProfActifID" runat="server" AutoPostBack="true" SelectionMode="Multiple" OnSelectedIndexChanged="ChProfActifID_SelectedIndexChanged"></asp:CheckBoxList>
                               </div>
                                <div class="col-md-4">
                                 <div class="form-group">
                                     <asp:Button ID="SaveProfChoisir" runat="server" Text="SAUVEGARDEZ" class="btn btn-outline btn-primary" OnClick="SaveProfChoisir_Click"/>                            
                                 </div>
                               </div>
                             </div> 
                            </div>
                           </div>
                           <div class="col-sm-5"></div>
                          </div>
                        </div>
                       </div>
                      </div>
                     </div>
                   </div>
</asp:Content>
