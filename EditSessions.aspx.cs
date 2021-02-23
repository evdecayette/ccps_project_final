using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCPS_Web_Edu_Update
{
    public partial class EditSessions : System.Web.UI.Page
    {
        BaseDeDonnees donnees = new BaseDeDonnees();
        protected void Page_Load(object sender, EventArgs e)
        {

#if !DEBUG
        if (!DB_Access.IsCurrentUserInGroup("Administrators"))
        {
            Response.Redirect("../NoAccess.htm");
        }
#endif


            if (!IsPostBack)
            {
                Label lblControl = (Label)Master.FindControl("lblPageName");
                if (lblControl != null)
                {
                    lblControl.Text = "Modifier Classes Existantes!!!";
                }

                RemplirClasses();
                RemplirProfesseur();
                RemplirJourRencontre();
                RemplirHeures();
                // RemplirSessions() Doit être exécuté en dernier
                RemplirSessions();
            }
        }

        void RemplirSessions()
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
                string sSql = "SELECT -1 as SessionID, '' as Heures, '' as JourRencontre, '' as DateCommence,  '' as DateFin, 0 as MaxEtudiants, 0 as MontantParticipation, 'Cliquez pour Choisir' as Description UNION " +
                    " SELECT SessionID, Heures, JourRencontre, DateCommence, DateFin, MaxEtudiants, MontantParticipation, JourRencontre + '-' + Heures  + '(' + CAST(DateFin as nvarchar(10)) + '-' + CAST(DateFin as nvarchar(10)) + ')' as Description from Sessions " +
                    "WHERE Actif = 1";
                clSession clUneSession = null;
                List<clSession> listSession = new List<clSession>();
                ArrayList arSessions = new ArrayList();

                //SqlDataAdapter da = new SqlDataAdapter(sSql, myConnection);
                //DataTable dTable = new DataTable();
                //da.Fill(dTable);

                //cbo_A_Modifier.DataSource = dTable;
                //cbo_A_Modifier.DataValueField = "SessionID";
                //cbo_A_Modifier.DataTextField = "Description";
                SqlDataReader dr = donnees.GetDataReader(sSql);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        clUneSession = new clSession();
                        clUneSession.SessionID = Int16.Parse(dr["SessionID"].ToString());
                        clUneSession.Heures = dr["Heures"].ToString();
                        clUneSession.JourRencontre = dr["JourRencontre"].ToString();
                        clUneSession.DateCommence = dr["DateCommence"].ToString();
                        clUneSession.DateFin = dr["DateFin"].ToString();
                        clUneSession.MaxEtudiants = Int16.Parse(dr["MaxEtudiants"].ToString());
                        clUneSession.Montant = Double.Parse(dr["MontantParticipation"].ToString());
                        clUneSession.Description = dr["Description"].ToString();
                        listSession.Add(clUneSession);
                        // arSessions.Add(clUneSession);
                    }

                    cbo_A_Modifier.DataSource = listSession;        //listSession;
                    cbo_A_Modifier.DataValueField = "SessionID";
                    cbo_A_Modifier.DataTextField = "Description";
                    cbo_A_Modifier.DataBind();
                }
            }
            catch (Exception ex)
            {
                string sError = ex.Message.ToString();
                Debug.WriteLine(sError);
                sError = "";
            }
        }

        void RemplirClasses()
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
                string sSql = "SELECT -1 as ClasseID, 'Cliquez pour Choisir' as NomClasse UNION SELECT ClasseID, NomClasse from Classes";

                SqlDataAdapter da = new SqlDataAdapter(sSql, myConnection);
                DataTable dTable = new DataTable();
                da.Fill(dTable);

                cboClasses.DataSource = dTable;
                cboClasses.DataValueField = "ClasseID";
                cboClasses.DataTextField = "NomClasse";

                cboClasses.DataBind(); ;
            }
            catch (Exception ex)
            {
                string sError = ex.Message.ToString();
                Debug.WriteLine(sError);
                sError = "";
            }
        }

        void RemplirProfesseur()
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
                string sSql = "SELECT -1 as PersonneID, 'Cliquez pour Choisir' as Nom UNION SELECT PersonneID, Nom + ', ' + Prenom AS Nom from Personnes WHERE Professeur = 1";

                SqlDataAdapter da = new SqlDataAdapter(sSql, myConnection);
                DataTable dTable = new DataTable();
                da.Fill(dTable);

                cboProfesseurs.DataSource = dTable;
                cboProfesseurs.DataValueField = "PersonneID";
                cboProfesseurs.DataTextField = "Nom";

                cboProfesseurs.DataBind();
            }
            catch (Exception ex)
            {
                string sError = ex.Message.ToString();
                Debug.WriteLine(sError);
                sError = "";
            }
        }

        void RemplirJourRencontre()
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
                string sSql = "SELECT -1 as JourID, 'Cliquez pour Choisir' as JourDescription UNION SELECT JourID, JourDescription from JoursDeClasses";

                SqlDataAdapter da = new SqlDataAdapter(sSql, myConnection);
                DataTable dTable = new DataTable();
                da.Fill(dTable);

                cboJourDeClasses.DataSource = dTable;
                cboJourDeClasses.DataValueField = "JourID";
                cboJourDeClasses.DataTextField = "JourDescription";

                cboJourDeClasses.DataBind();
            }
            catch (Exception ex)
            {
                string sError = ex.Message.ToString();
                Debug.WriteLine(sError);
                sError = "";
            }
        }

        void RemplirHeures()
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
                string sSql = "SELECT -1 as HeureID, 'Cliquez pour Choisir' as HeureDescription UNION SELECT HeureID, HeureDescription from HeuresDeClasses";

                SqlDataAdapter da = new SqlDataAdapter(sSql, myConnection);
                DataTable dTable = new DataTable();
                da.Fill(dTable);

                cboHeuresDeClasses.DataSource = dTable;
                cboHeuresDeClasses.DataValueField = "HeureID";
                cboHeuresDeClasses.DataTextField = "HeureDescription";

                cboHeuresDeClasses.DataBind();
            }
            catch (Exception ex)
            {
                string sError = ex.Message.ToString();
                Debug.WriteLine(sError);
                sError = "";
            }
        }

        bool ToutBagayPaAnfom()
        {
            bool bValeur = true;

            if (cboClasses.SelectedIndex == -1)
                bValeur = false;
            if (cboProfesseurs.SelectedIndex == -1)
                bValeur = false;
            if (cboJourDeClasses.SelectedIndex == -1)
                bValeur = false;
            if (cboHeuresDeClasses.SelectedIndex == -1)
                bValeur = false;

            if (txtDateDebut.Text == string.Empty)
                bValeur = false;
            //if (calDebut.getGregorianDateText == string.Empty)
            //    bValeur = false;
            if (txtDateFin.Text == string.Empty)
                bValeur = false;

            if (txtMaxEtudiants.Text == string.Empty)
                bValeur = false;
            if (txtMontant.Text == string.Empty)
                bValeur = false;
            return bValeur;
        }

        protected void cbo_A_Modifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.InnerText = "";
            try
            {
                //Ajuster les autres listes           
                string sSql = "SELECT * FROM Sessions WHERE SessionID = " + cbo_A_Modifier.SelectedValue.ToString();
                SqlDataReader dr = donnees.GetDataReader(sSql);
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        string sClasseID = dr["ClasseID"].ToString();
                        string sHeures = dr["Heures"].ToString();
                        string sJourRencontre = dr["JourRencontre"].ToString();
                        string sMaxEtudiants = dr["MaxEtudiants"].ToString();
                        string sMontantParticipation = dr["MontantParticipation"].ToString();
                        string sProfesseurID = dr["ProfesseurID"].ToString();
                        string sDateCommence = dr["DateCommence"].ToString();
                        string sDateFin = dr["DateFin"].ToString();
                        // string sDescription = dr["Description"].ToString();

                        // Mise à Jour de textboxes
                        string sOldSelection = "";
                        txtMaxEtudiants.Text = sMaxEtudiants;
                        txtMontant.Text = sMontantParticipation;
                        // Mise à Jour de dropdownboxes
                        if (cboClasses.Items.FindByValue(sClasseID) != null && sClasseID != string.Empty)
                        {
                            sOldSelection = cboClasses.SelectedValue.ToString();
                            cboClasses.Items.FindByValue(sClasseID).Selected = true;
                            if (sOldSelection != sClasseID) // Pour ne pas désélectionner le nouveau choix
                                cboClasses.Items.FindByValue(sOldSelection).Selected = false;
                        }
                        sOldSelection = "";
                        if (cboProfesseurs.Items.FindByValue(sProfesseurID) != null && sProfesseurID != string.Empty)
                        {
                            sOldSelection = cboProfesseurs.SelectedValue.ToString();
                            cboProfesseurs.Items.FindByValue(sProfesseurID).Selected = true;
                            if (sOldSelection != sProfesseurID) // Pour ne pas désélectionner le nouveau choix
                                cboProfesseurs.Items.FindByValue(sOldSelection).Selected = false;
                        }
                        sOldSelection = "";
                        if (cboHeuresDeClasses.Items.FindByText(sHeures) != null && sHeures != string.Empty)
                        {
                            sOldSelection = cboHeuresDeClasses.SelectedItem.Text;
                            cboHeuresDeClasses.Items.FindByText(sHeures).Selected = true;
                            if (sOldSelection != sHeures) // Pour ne pas désélectionner le nouveau choix
                                cboHeuresDeClasses.Items.FindByText(sOldSelection).Selected = false;
                        }
                        sOldSelection = "";
                        if (cboJourDeClasses.Items.FindByText(sJourRencontre) != null && sJourRencontre != string.Empty)
                        {
                            sOldSelection = cboJourDeClasses.SelectedItem.Text;
                            cboJourDeClasses.Items.FindByText(sJourRencontre).Selected = true;
                            if (sOldSelection != sJourRencontre) // Pour ne pas désélectionner le nouveau choix
                                cboJourDeClasses.Items.FindByText(sOldSelection).Selected = false;
                        }
                        // Mise à Jour des calendriers
                        DateTime dt = DateTime.Parse(sDateCommence.Substring(0, 10));
                        txtDateDebut.Text = dt.ToShortDateString();
                        txtDateDebut.Visible = true;
                        dt = DateTime.Parse(sDateFin.Substring(0, 10));
                        txtDateFin.Text = dt.ToShortDateString();
                        txtDateFin.Visible = true;
                    }
                    else
                    {
                        lblError.InnerText = "ERROR: Données PAS Sauvegardées -- Voir Un Technicien!!!";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.InnerText = ex.Message.ToString();
            }
        }
    }

    public class clSession
    {
        private Int16 sessionid;
        public Int16 SessionID
        {
            get { return sessionid; }
            set { sessionid = value; }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string jourrencontre;
        public string JourRencontre
        {
            get { return jourrencontre; }
            set { jourrencontre = value; }
        }
        private string heures;
        public string Heures
        {
            get { return heures; }
            set { heures = value; }
        }
        private string professeur;
        public string Professeur
        {
            get { return professeur; }
            set { professeur = value; }
        }
        private string dateCommence;
        public string DateCommence
        {
            get { return dateCommence; }
            set { dateCommence = value; }
        }
        private string dateFin;
        public string DateFin
        {
            get { return dateFin; }
            set { dateFin = value; }
        }
        private int maxEtudiants;
        public int MaxEtudiants
        {
            get { return maxEtudiants; }
            set { maxEtudiants = value; }
        }
        private double montant;
        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }
    }
}