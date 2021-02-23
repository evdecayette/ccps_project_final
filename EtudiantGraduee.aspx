<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="EtudiantGraduee.aspx.cs" Inherits="CCPS_Web_Edu_Update.EtudiantGraduee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="css/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class='col-sm-12'> 
        <div class='panel-primary'> 
          <div class='panel panel-primary'> 
            <div class='panel-heading text-center panel-relative'> 
                <asp:Label ID="Label1" runat="server" style="color:mediumseagreen,ActiveBorder,Background;text-decoration-color:lightseagreen; font:bold; font-size:20px;font-family:'Global User Interface'" Text="Listes Des Etudiants Gradués de la CCPS" Font-Bold="True" Font-Size="15pt" class="block-center" ></asp:Label>

               <%--<label class="block-centrer" id="title" > Liste de tous les etudants gradues de la CCPS </label>--%>
             </div>
              <div class="panel-body">

<%--              </div>
              </div>
            </div>--%>
<%--        </div>--%>

    
    <div class="panel-body">
    <div class="container">
        <div class="row">
           <div class="input-group">
               
               <asp:TextBox ID="Recherche" runat="server" class="form-control" placeholder="Recherche" name="search" AutoPostBack="True" OnTextChanged="Recherche_TextChanged1"></asp:TextBox>
              <%-- <input type="text" ID="recherche" class="form-control" placeholder="Search" name="search" />--%>
               <div class="input-group-btn">
                   <asp:Button ID="Button1" runat="server" class="btn btn-default" OnClick="Button1_Click" Text="Recherche" type="submit"  />
                   <%--<button class="btn btn-default" type="submit" >--%>
                      <%-- <i class="glyphicon glyphicon-search"></i>--%>
                  <%-- </button>--%>
               </div>
           </div>
   </div>           
        </div>
    </div>
    
    <div class="row">
        <div class="col-sm-12">
            <div class="form-group">
                <div class="panel-body">
            <asp:gridview runat="server" ID="gridviewId" AutoGenerateColumns = "False" CssClass="table table-responsive" 
                AllowPaging="True" AllowSorting="True" HeaderStyle-BackColor="#0099cc" HeaderStyle-ForeColor="White" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridviewId_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>

                    <asp:BoundField DataField="Nom" HeaderText="Nom" ReadOnly="True" />
                    <asp:BoundField DataField="Prenom" HeaderText="Prenom" />
                    <asp:BoundField DataField="DateCreee" HeaderText="DateCreee" />
                </Columns>
                
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />

<HeaderStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True"></HeaderStyle>
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
                
            </asp:gridview >
        </div>
    </div>
    </div>
    </div>

    
</div></div></div></div>
    
</asp:Content>
