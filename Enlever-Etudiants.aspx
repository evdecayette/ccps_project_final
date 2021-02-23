<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="Enlever-Etudiants.aspx.cs" Inherits="CCPS_Web_Edu_Update.Enlever_Etudiants" %>
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
    <div class ="col-md-12">
   <div class="panel-primary">
     <div class="panel panel-primary">
       <div class="panel-heading">
          <label class="" id="lblMenu"> ENLEVER UN ETUDIANT DANS UNE CLASSE </label>
        </div>
         <div class="panel-body">
           <div class="container">                                  
             <%--première ligne--%>
               <div class="row">  
                 <div class="col-sm-6">                       
                  <div class="panel panel-primary">
                    <div class="panel-heading">
                       <label class="" id="lblMenu1"> CHOISIR L'ETUDIANT A ENLEVER DANS LA CLASSE  </label>
                      </div>
                      <div class="panel-body">
                       <div class="col-md-6">
                        <div class="form-group">  
                          <asp:dropdownlist runat="server" Width="350px" ID="drowpListOption"  CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drowpListOption_SelectedIndexChanged"  ></asp:dropdownlist> 
                         </div>
                         <br />    
                          <div class="form-group">  
                            <asp:DropDownList ID="DropDownListClasse" Width="350px" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListClasse_SelectedIndexChanged" ></asp:DropDownList>                                                            
                          </div>          
                          <br />  
                          <div class="form-group">  
                            <asp:DropDownList ID="DropDownListHoraire" Width="350px" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="DropDownListHoraire_SelectedIndexChanged" ></asp:DropDownList>                                                            
                           </div>
                         </div>       
                        </div>
                       </div>
                      </div>
                       <div class="col-sm-6">                       
                         <div class="panel panel-primary">
                           <div class="panel-heading">
                             <label class="" id="lblMenu1"> CHOISIR L'ETUDIANT A ENLEVER DANS LA CLASSE  </label>
                            </div>
                             <div class="panel-body">
                              <div class="form-group"> 
                               <asp:listbox runat="server" id="ListeEtudiants" height="150px" width="430px"></asp:listbox>
                              </div>
                              <br/>                   
                             </div>
                            </div>                                                   
                             <div class="row">
                              <div class="col-sm-6">
                               <br />
                                <div class="form-group">                                                                                        
                               </div>
                              </div>
                             <div class="col-sm-4">
                             <br />
                             <div class="form-group">                                
                               <asp:Button ID="btnEnlever" runat="server" Width="200" Text="ENLEVER L'ETUDIANT"  OnClick="btnEnlever_Click" Class="btn btn-primary btn-sm" Height="51px"/> 
                               <asp:label runat="server" text="" id="lblError"></asp:label>
                                   
                                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="GREEN"></asp:Label> </div>
                             
                              </div>
                             </div>
                            </div>    <%--Fin Troisième ligne--%>  
                           </div>
                          </div>
                         </div> 
                       </div>
                      </div>  
                    </div>
                 </div>
</asp:Content>
