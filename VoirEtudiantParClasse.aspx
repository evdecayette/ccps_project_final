<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="VoirEtudiantParClasse.aspx.cs" Inherits="CCPS_Web_Edu_Update.VoirEtudiantParClasse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class='col-sm-12'> 
    <div class="container">
     <div class="row">  
      <div class="col-sm-6">
       <div class="panel panel-primary">
         <div class="panel-heading text-center panel-relative">
            <h4>Choix</h4>
          </div>
           <div class="panel-body">             
               <div class="form-group">
                  <asp:DropDownList runat="server"  CssClass="form-control" ID="drowpListOption" OnSelectedIndexChanged="drowpListOption_SelectedIndexChanged" AutoPostBack="true" />
                </div>
                 <br /><br />
                 <div class="form-group">
                   <asp:DropDownList runat="server" CssClass="form-control" ID="DropDownListClasse" OnSelectedIndexChanged="DropDownListClasse_SelectedIndexChanged" AutoPostBack="true" />
                 </div>
                  <br /><br />
                  <div class="form-group">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="DropDownListHoraire"  AutoPostBack="true" OnSelectedIndexChanged="DropDownListHoraire_SelectedIndexChanged"/>         
                  </div>
                   <br /><br /><br />
                  </div> 
               </div>
              </div>
              <div class="col-12 col-sm-6">
                <div class="panel panel-primary">
                  <div class="panel-heading text-center panel-relative">
                      <h4>Voir étudiant par classe</h4>
                  </div>
                    
                 <div class="panel-body">
                  <div class="col-12 col-sm-5">
                    <div class="form-group">
                      <asp:listbox CssClass="lstCenter" runat="server" id="ListeEtudiants" width="350px" height="250px"></asp:listbox>
                       <asp:label Width="300px" runat="server" text="" ID ="lblCount"  Font-Bold="True" Font-Size="Medium" ForeColor="Blue"></asp:label>
                    </div>                     
                    </div>
                   </div>
                  </div>
                 </div>
                <div>
                  <asp:label runat="server" text="" ID ="lblError"></asp:label>
                </div>
               </div>
             </div>
    </div>
</asp:Content>
