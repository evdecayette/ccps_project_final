using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCPS_Web_Edu_Update
{
    public partial class EtudiantGraduee : System.Web.UI.Page
    {

        BaseDeDonnees donnees = new BaseDeDonnees();
        protected void Page_Load(object sender, EventArgs e)
        {
            String sqlDa = "SELECT Nom, Prenom, DateCreee FROM Personnes";
            gridviewId.DataSource = donnees.GetDataSet(sqlDa);
            gridviewId.DataBind();
        }

        public void ChercherEtudiant()
        {
            //String sqlDa = "SELECT Nom +' , '+ Prenom as NomComplet FROM Personnes WHERE Etudiant = 1 order by Prenom";

            //String sqlDa = "SELECT DISTINCT Nom, Prenom, DateCreee FROM Personnes WHERE Nom LIKE '%' + '" + Recherche.Text + "' + '%' OR Prenom LIKE '%' + '" + Recherche.Text + "'";
            //String sqlDa = "SELECT DISTINCT Nom, Prenom, DateCreee FROM Personnes WHERE Nom LIKE '%' + '" + Recherche.Text + "' + '%' OR Prenom LIKE '%' + '" + Recherche.Text + "'";
            String sqlDa = "select DISTINCT Nom +', ' + Prenom as NomComplet, Nom, Prenom, DateCreee FROM Personnes where Nom LIKE '%' +'" + Recherche.Text + "'+ '%' OR Prenom LIKE '%'+'" + Recherche.Text + "' + '%' OR Nom+' '+ Prenom LIKE '%'+'" + Recherche.Text + "'+ '%'";
            gridviewId.DataSource = donnees.GetDataSet(sqlDa);

            gridviewId.DataBind();
        }

        protected void RechercheEdu()
        {
            String sqlDa = "SELECT DISTINCT Nom, Prenom, DateCreee FROM Personnes WHERE Nom LIKE '%' + '" + Recherche.Text + "' + '%' OR Prenom LIKE '%' + '" + Recherche.Text + "' ";
            //String sqlDa = "SELECT DISTINCT Nom + Prenom As NomComplet, Nom, Prenom, DateCreee FROM Personnes WHERE Nom LIKE '%' + '" + Recherche.Text + "' + '%' OR Prenom LIKE '%' + '" + Recherche.Text + "' ";
            
            gridviewId.DataSource = donnees.GetDataSet(sqlDa);

            gridviewId.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ChercherEtudiant();
        }

        protected void Recherche_TextChanged1(object sender, EventArgs e)
        {
            ChercherEtudiant();
        }

        protected void DisplayData()
        {
            String sqlDa = "SELECT Nom, Prenom, DateCreee FROM Personnes";
            //DataTable dtbl = new DataTable();
            //sqlDa.Fill(dtbl);
            //DataSet ds = new DataSet();
            gridviewId.DataSource = donnees.GetDataSet(sqlDa);
            // gridviewId.DataSource ="Nom" ;
            //gridviewId.DataSource = "Prenom";
            //.DataSource = "DateCreee";
            gridviewId.DataBind();
        }

        protected void gridviewId_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewId.PageIndex = e.NewPageIndex;
            DisplayData();
            RechercheEdu();
        }

        protected void gridviewId_PageIndexChanging(object sender, EventArgs e)
        {

        }
    }
}