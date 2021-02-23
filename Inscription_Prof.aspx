<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="Inscription_Prof.aspx.cs" Inherits="CCPS_Web_Edu_Update.Inscription_Prof" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!--  <link href="Styles/main.css" rel="stylesheet" /> -->
    <link rel="stylesheet" type="text/css" href="style.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="col-sm-12">
    <div class='panel panel-primary'>
       <div class='panel-heading text-center panel-relative'>
         <label class="block-cente">Inscription Professeur </label>
       </div>
        <div class='panel-body'>
            <div class='panel panel-primary'>
                <div class='panel-heading text-center panel-relative'>
                    <label class="block-cente">Renseignement Personnel</label>
                </div>
                <div class='panel-body'>
                 <%--   collun1--%>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <asp:TextBox runat="server" class="form-control" id="txtNom" placeholder="Nom"></asp:TextBox>
                         </div>
                        <br />
                        <div class="form-group">
                            <asp:TextBox runat="server" class="form-control" id="txtPrenom" placeholder="Prenom"></asp:TextBox>
                        </div>
                        <br />
                       <div class="form-group">
                            <asp:TextBox runat="server" class="form-control" id="txtetude" placeholder="Niveau D'etude"></asp:TextBox>
                        </div>
                        <br />
                       <div class="form-group">
                           <asp:TextBox id="txtdate" runat="server" class="form-control" TextMode="date" placeholder="Date de Naissance" Tooltip="Date de Naissance"></asp:TextBox>
                       </div>
                    <br />
                 <div class="form-group">
                    <asp:TextBox runat="server" class="form-control" id="txtTelephone" placeholder="Télephone"></asp:TextBox>
                 </div>
                <br />
                    <div class="form-group">
                        <asp:TextBox runat="server" class="form-control" id="TextnifOuCin" placeholder="Nif/Cin"></asp:TextBox>
                </div>
                <br />
            </div>
            <%--fin col 1--%>
            <div class="col-sm-6">
                <div class="form-group">
                    <asp:TextBox runat="server" class="form-control" id="txtemail" placeholder="Email"></asp:TextBox>
                </div>
              <br />
                <div class="form-group">
                    <asp:TextBox runat="server" class="form-control" id="txtnumeromaison" placeholder="Numero Maison"></asp:TextBox>
                </div>
                <br />
                <div class="form-group">
                    <asp:TextBox runat="server" class="form-control" id="txtrue" placeholder="Rue"></asp:TextBox>
                </div>
                <br />
                <div class="form-group">
                    <asp:TextBox runat="server" class="form-control" id="txtville" placeholder="Ville"></asp:TextBox>
                </div>
                <br />

                <div class="form-group">
                    <textarea runat="server" class="form-control" id="txtRemarque" cols="90" rows="2" placeholder="Remarque"></textarea>
                    <asp:Label ID="lblerror" runat="server" Text="" text-color="red" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
                    <br />
                    <br />
                    <br />
                </div>

                <%--fin col 2--%>
            </div>
            <div class="row-sm-12">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="row">
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:button runat="server" class="btn btn-primary" Text="Sauvegarder" id="btnsauvegarder" OnClick="btnsauvegarder_Click" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:button runat="server" class="btn btn-primary" Text="Annuler" id="btnCancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                    </div>
                    <div class="col-sm-4">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
