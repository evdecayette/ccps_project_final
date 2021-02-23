using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CCPS_Web_Edu_Update
{
    public partial class ChangerHoraire : System.Web.UI.Page
    {
        BaseDeDonnees donnees;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RemplirLesList();
                RemplirListeClassesSessions();
                // RemplirClassePourEtudiantChoissi();
            }
        }
        public void RemplirLesList()

        {
            // string sSql = "SELECT DISTINCT Nom, Prenom, P.PersonneID, Nom + ', ' + Prenom as NomComplet FROM Personnes P, EtudiantsCourants E WHERE P.PersonneID = E.PersonneID AND Etudiant = 1 ORDER BY Nom, Prenom, NomComplet, P.PersonneID";

            String sSql = "SELECT CONCAT(Nom,' ',Prenom ) AS NomComplet FROM Personnes WHERE Etudiant = 1";
            // string sSql = "SELECT DISTINCT Nom, Prenom, P.PersonneID, Nom + ' ' + Prenom as NomComplet FROM Personnes P, EtudiantsCourants E WHERE P.PersonneID = E.PersonneID AND Etudiant = 1 ORDER BY Nom, Prenom, NomComplet, P.PersonneID";
            donnees = new BaseDeDonnees();
            DataSet ds = new DataSet();
            //DataTable ds = new DataTable();
            ds = donnees.GetDataSet(sSql);
            // BaseDeDonnees [] Table ;
            // lstToutEtudiant.Rows.(ds);

            this.lstTousEtudiant.DataSource = ds;
            //lstTousEtudiant.DataValueField = "PersonneID";
            lstTousEtudiant.DataTextField = "NomComplet";
            lstTousEtudiant.DataBind();
        }

        private void RemplirListeClassesSessions()
        {

            string sSql = "SELECT SessionID, JourRencontre + ': ' + Heures '++' As SessionName FROM Sessions WHERE Actif = 1";
            donnees = new BaseDeDonnees();
            DataSet ds = new DataSet();
            //DataTable ds = new DataTable();
            ds = donnees.GetDataSet(sSql);
            // lstToutEtudiant.Rows.(ds);
            //SqlDataAdapter da = new SqlDataAdapter(sSql, sqlConn);
            //DataTable dTable = new DataTable();
            // da.Fill(dTable);
            this.lstClasseAjouter.DataSource = ds;
            lstClasseAjouter.DataValueField = "SessionID";
            lstClasseAjouter.DataTextField = "SessionName";
            lstClasseAjouter.DataBind();
        }

        private void RemplirClassePourEtudiantChoissi()
        {


            string sSql = "SELECT E.EtudiantsCourantsID, S.SessionID, S.JourRencontre + ': ' + S.Heures As SessionName  FROM Sessions S,Classes C, EtudiantsCourants E WHERE S.ClasseID = C.ClasseID AND S.SessionID = E.SessionID AND S.Actif = 1 AND PersonneID = " + lstTousEtudiant.SelectedValue;
            donnees = new BaseDeDonnees();
            DataSet ds = new DataSet();
            ds = donnees.GetDataSet(sSql);
            // lstToutEtudiant.Rows.(ds);
            //SqlDataAdapter da = new SqlDataAdapter(sSql, sqlConn);
            DataTable dTable = new DataTable();
            // da.Fill(dTable);
            this.lstClasseEnlver.DataSource = ds;
            lstClasseEnlver.DataValueField = "EtudiantsCourantsID";
            lstClasseEnlver.DataTextField = "SessionName";
            lstClasseEnlver.DataBind();

        }
        protected void btnChangez_Click(object sender, EventArgs e)
        {
            if (lstClasseAjouter.SelectedIndex < 0 || lstClasseEnlver.SelectedIndex < 0)
            {
                Response.Write("Choisissez classes à enlever et ajouter!");
                return;
            }

            Response.Write("");

            string sSql = string.Format("UPDATE EtudiantsCourants SET SessionID = {0} WHERE EtudiantsCourantsID = {1}", lstClasseAjouter.SelectedValue.ToString(), lstClasseEnlver.SelectedValue.ToString());
            try
            {
                if (donnees.IssueCommand(sSql))
                {
                    Response.Write("Changement à Succès");
                    RemplirClassePourEtudiantChoissi();
                }
                else
                {
                    Response.Write("ERREUR: Pas de Changement!");
                }
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("ERREUR: Voir un Technicien ({0})", ex.Message));
            }
        }

        protected void lstToutEtudiant_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemplirClassePourEtudiantChoissi();
        }

        protected void Recherche_TextChanged1(object sender, EventArgs e)
        {
            String sqlDa = "select DISTINCT Nom +', ' + Prenom as NomComplet, Nom, Prenom, DateCreee FROM Personnes where Nom LIKE '%' +'" + Recherche.Text + "'+ '%' OR Prenom LIKE '%'+'" + Recherche.Text + "' + '%' OR Nom+' '+ Prenom LIKE '%'+'" + Recherche.Text + "'+ '%'";
            BaseDeDonnees donne = new BaseDeDonnees();
            lstTousEtudiant.DataSource = donne.GetDataSet(sqlDa);

            lstTousEtudiant.DataBind();
        }
    }
}