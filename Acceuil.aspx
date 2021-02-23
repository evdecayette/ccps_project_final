<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="Acceuil.aspx.cs" Inherits="CCPS_Web_Edu_Update.Acceuil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
	<H1>ACCEUIL</H1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>            
              <!-- Banner -->
			<section id="banner">
				<div class="inner">
					<header>
                      <!--     <h1 style="margin-top: 0px; padding-top: 10px;">CALVARY CHRISTIAN PROFESSIONAL SCHOOL</h1>  -->
                        <h3 style="color: #FFFFFF">AVIS IMPORTANTS</h3>
                        <h4>

                            <!-- Le literal affiche les annonces sur l'ecran-->
                        <asp:literal id="Literal1" runat="server"></asp:literal>
                       <a href="Annonce.aspx" class="button">Modifier Annonces</a>

                         
					    </h4>
					</header>
					
				</div>
			</section>

              <!-- Main -->
			<div id="main">

				<!-- Section -->
					<section class="wrapper style1">
						<div class="inner">
							<!-- 2 Columns -->
								<div class="flex flex-2">
									<div class="col col1">
										<div class="image round fit">
											<a href="generic.html" class="link"><img src="images/computer.jpg" alt="" /></a>
										</div>
									</div>
									<div class="col col2">
                                        <h3>CALVARY CHRISTIAN PROFESSIONAL SCHOOL</h3>
                                        <p style="font-size: 25px" font-weight:"bold">une école chrétienne, de qualité au service de la population haitienne. Une école qui proclame l'évangile de Christ au moyen de l'éducation</p>
									</div>
								</div>
						</div>
					</section>

                     </div>

              
		<!-- Footer -->
			<footer id="footer">
				 
			</footer>


              
         </div>
</asp:Content>
