<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="ListeDeTousLesEtudiant.aspx.cs" Inherits="CCPS_Web_Edu_Update.ListeDeTousLesEtudiant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class='col-lg-12'>
        <div class='panel-primary'>
          <div class='panel panel-primary'>
            <div class='panel-heading text-center panel-relative'>
                <h6>LISTE DE TOUS LES ETUDIANTS DE LA CCPS</h6>
             </div>
              <div class='panel-body'>
               <div class="container">
                   <div class="row">
                    <div class="col-lg-2"></div>
                       <div class="col-lg-8">
                           <div class="col-lg-6">
                            <asp:DropDownList  ID="DropDownList1" runat="server" width="300px" Height="27" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                             <asp:ListItem>Selectionnez Etudiants Par</asp:ListItem>
                                <asp:ListItem>Etudiants dans la session courante</asp:ListItem>
                             <asp:ListItem>Tous les Etudiants</asp:ListItem> 
                               
                            </asp:DropDownList>
                           </div>
                           <div class="col-lg-6"> 
                             <asp:TextBox runat="server" width="300px" ID="txtSearch" PlaceHolder="SEARCH" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                         </div>
                        </div>
                       <br /><br />
                      <div class="col-lg-2"></div>
                   </div>
                   <div class="row" >
                    <div class="col-lg-2"></div>
                     <div class="col-lg-8">
                      <div class='panel-primary'>
                       <div class='panel panel-primary'>
                        <div class='panel-heading text-center panel-relative'>
                          <h6>LISTE DE TOUS LES ETUDIANTS DE LA CCPS</h6>
                        </div>
                         <div class='panel-body'>
                           <asp:ListBox ID ="lstTousEtudiants"  runat ="server" Height ="300px" Width =" 450px"></asp:ListBox>
                         </div>
                        </div>
                       </div>
                      </div>
                     <div class="col-lg-2"></div>
                    <br /> <br />
                  </div>
                   <div class="row">
                    <div class="col-lg-4">
                      <label runat="server" id="lblError"></label>
                        <asp:Label ID="lblError1" runat="server" Text="" text-color="green" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
                    </div>                 
                     <div class="col-lg-4">
                       <div class="col-lg-12">
                          <br />
                           <div class="col-lg-6">
                             <asp:button runat="server" width="150px" CssClass="btn btn-primary" ID="btnEditez" text="EDITEZ" OnClick="btnEditez_Click"/>
                           </div>
                          <div class="col-lg-6">
                            <asp:button runat="server" width="150px" CssClass="btn btn-primary" ID="btnClear" text="Nettoyer" OnClick="btnClear_Click"/>
                          </div>
                         </div>
                       </div>
                     <div class="col-lg-4"></div>
                  </div>
               </div>
             </div>
          </div>
        </div>
      </div>
</asp:Content>
