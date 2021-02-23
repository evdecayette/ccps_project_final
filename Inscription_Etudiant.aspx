<%@Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="Inscription_Etudiant.aspx.cs" Inherits="CCPS_Web_Edu_Update.Inscription_Etudiant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='col-sm-12'>
          <div class='panel panel-primary'>
            <div class='panel-heading text-center panel-relative'>
               <label class="block-cente">Inscription Etudiant </label>
             </div>
               <div class='panel-body'>
    <%--            <div class="container">--%>
                 <div class="row">
                     <div class="col-sm-8">
                          <div class="panel panel-primary">
            <div class='panel-heading text-center panel-relative'>
                <asp:checkbox runat="server" ID="checkEtudiant" ></asp:checkbox>
               <label class="block-cente">   Renseignement Personnel</label>
             </div>
               <div class='panel-body'>
                <%--   collun1--%>
                         <div class="col-sm-6">
                             
                            <div class="form-group">
                                  <asp:TextBox runat="server" class="form-control" ID="txtNom" AutoPostBack="true" placeholder="Nom" OnTextChanged="txtNom_TextChanged1"></asp:TextBox>
                             </div>
                             
                              <div class="form-group">
                                   <asp:TextBox runat="server" class="form-control" id="txtPrenom" AutoPostBack="true" placeholder="Prenom" OnTextChanged="txtPrenom_TextChanged1"></asp:TextBox>
                             </div>
                             <div class="form-group">
                             <asp:DropDownList ID="DrpSexe" class="form-control" runat="server">
                                 <asp:ListItem Enabled="true" Text="Choisir Sexe" Value="-1"></asp:ListItem>
                                       <asp:ListItem Text="M" Value="1"></asp:ListItem>
                                       <asp:ListItem Text="F" Value="2"></asp:ListItem>
                             </asp:DropDownList>
                            </div>
                              <div class="form-group">
                                   <asp:TextBox runat="server" class="form-control" id="txtetude"  placeholder="Niveau D'etude"></asp:TextBox> 
                             </div>
                             
                              <div class="form-group">
                                   <asp:TextBox ID="txtdate" runat="server" class="form-control" TextMode="date" placeholder="Date de Naissance" Tooltip="Date de Naissance" ></asp:TextBox>
                             </div>
                              

                              <div class="form-group">
                                   <asp:TextBox runat="server" class="form-control" id="txttelephone"  placeholder="Télephone"></asp:TextBox> 
                             </div>

                             <div class="form-group">
                                 <asp:DropDownList ID="DropDownDepartement" class="form-control" runat="server">


                                     <asp:ListItem Enabled="true" Text="Choisir Departement" Value="-1"></asp:ListItem>
                                       <asp:ListItem Text="Artibonite" Value="1"></asp:ListItem>
                                 

                                     <asp:ListItem Text="Centre" Value="2"></asp:ListItem>
                                       <asp:ListItem Text="Grande-Anse" Value="3"></asp:ListItem>
                                         <asp:ListItem Text="Nippes" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="Nord" Value="5"></asp:ListItem>
                                         <asp:ListItem Text="Nord-Est" Value="6"></asp:ListItem>
                                     <asp:ListItem Text="Nord-Ouest" Value="7"></asp:ListItem>
                                         <asp:ListItem Text="Ouest" Value="8"></asp:ListItem>
                                     <asp:ListItem Text="Sud" Value="9"></asp:ListItem>
                                         <asp:ListItem Text="Sud-Est" Value="10">
                                     
                                     </asp:ListItem>   
                                   

                                 </asp:DropDownList>

                            

                                  </div>

                             <asp:Label ID="lblMessage" runat="server" Text="" text-color="green" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
                             <asp:Label ID="lblSucces" runat="server" Text="" text-color="green" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
                              <asp:Label ID="LblCount" runat="server" Text="" text-color="green" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                              <br /> <br /> <br />
                         </div>
                   <%--fin col 1--%>
                         <div class="col-sm-6">                        
                              <div class="form-group">
                                  <asp:TextBox runat="server" class="form-control" id="txtemail"  placeholder="Email"></asp:TextBox> 
                             </div>
                             
                              <div class="form-group">
                                    <asp:TextBox runat="server" class="form-control" id="txtnumeromaison"  placeholder="Numero Maison"></asp:TextBox> 
                             </div>
                              
                              <div class="form-group">
                                    <asp:TextBox runat="server" class="form-control" id="txtrue"  placeholder="Rue"></asp:TextBox>
                             </div>
                             
                              <div class="form-group">
                                  <asp:TextBox runat="server" class="form-control" id="txtville"  placeholder="Ville"></asp:TextBox>
                             </div>
                              
                              <div class="form-group">
                                  <asp:TextBox runat="server" class="form-control" id="Txturgence"  placeholder="Numero d'urgence"></asp:TextBox>
                             </div>

                             

                              <div class="form-group">

                                 <Textarea runat="server" class="form-control"  id="txtRemarque" cols="55" rows="2" placeholder="Remarque" ></Textarea>
                                  
                             </div>
                             
                       <div class="row">
                           <div class="col-sm-6">
                              <div class="form-group">
                                  <asp:button  runat="server" class="btn btn-primary" Text="Sauvegarder" id="btnsauvegarder" OnClick="btnsauvegarder_Click1" />
                             </div>
                               </div><div class="col-sm-6">
                                <div class="form-group">
                                  <asp:button  runat="server" class="btn btn-primary" Text="Annuler" id="btnCancel" OnClick="btnCancel_Click" />
                             </div></div>
                                </div>
                         </div>
                    <br /> <br /> <br />

                     </div>
                         
                     </div></div>
                     <div class="col-sm-4 " >
                          <div class='panel panel-primary'>
            <div class='panel-heading text-center panel-relative'>
               <label class="block-cente">Ajouter Etudiant Dans Classe</label>
             </div>
               <div class='panel-body'>
                   <div class="form-group">
                        <asp:DropDownList ID="DrchoisirSujet" class="form-control" AutoPostback="true" runat="server" OnSelectedIndexChanged="DrchoisirSujet_SelectedIndexChanged1" ></asp:DropDownList>
                   </div>
                   <div class="form-group">
                        <asp:DropDownList ID="DropDownListNiveau" class="form-control" runat="server" AutoPostback="true" OnSelectedIndexChanged="DropDownListNiveau_SelectedIndexChanged1" ></asp:DropDownList>
                   </div>
                   <div class="form-group">
                         <asp:DropDownList ID="DropDownListOptionhoraire1" class="form-control" runat="server" OnSelectedIndexChanged="DropDownListOptionhoraire1_SelectedIndexChanged1"></asp:DropDownList>
                   </div>
               <%--    list--%>

                   <div class="form-group">
                                       <asp:TextBox ID="Seach" TextMode="Search" placeholder="Chercher un étudiant" runat="server" AutoPostBack="True" Height="27px"  Width="180px" Font-Bold="True" ToolTip="Recherchez par nom ou prenom" OnTextChanged="Seach_TextChanged"></asp:TextBox>
                                <asp:button runat="server" ID="Clear" text="Refresh" Height="30px" Width="60px" BackColor="#337AB7"  ForeColor="White" OnClick="Clear_Click" />
                                   </div>


                    <div class="form-group ">
                        <asp:ListBox id="lstEtudiant" width="280" height="132" AutoPostback="true"  runat="server" OnSelectedIndexChanged="lstEtudiant_SelectedIndexChanged"></asp:ListBox>
                        <asp:ListBox ID ="lstTousEtudiants"  runat ="server" OnSelectedIndexChanged="lstTousEtudiants_SelectedIndexChanged"></asp:ListBox>
                         <asp:TextBox ID="txtPersonneID" runat="server" Visible="False"></asp:TextBox>
                   </div>

                   <div class="form-group col-sm-offset-4">
                       
                      <asp:Button  runat="server" class="btn btn-primary" id="btnajouterdansclasse" Text="Ajouter dans Classe"  OnClick="btnajouterdansclasse_Click" /> 

                   </div>
                   <%--<div class="form-group col-sm-offset-4">
                       
                      <asp:Button  runat="server" class="btn btn-primary" id="btnAutreOption" Text="Autre option"  OnClick="btnAutreOption_Click" /> 

                   </div>--%>
                   <!--
                   <div class="form-group">
                        <asp:DropDownList ID="DropDownListOption2" class="form-control" runat="server"></asp:DropDownList> %>
                   </div>
                    <div class="form-group">
                        <asp:DropDownList ID="DropDownListOptionhoraire2" class="form-control" runat="server"></asp:DropDownList>
                   </div> -->

                   </div></div>
                     </div>
                 </div></div>
              
          </div>
      

  </div>
</asp:Content>
