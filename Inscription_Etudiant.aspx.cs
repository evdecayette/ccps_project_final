using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CCPS_Web_Edu_Update
{
    public partial class Inscription_Etudiant : System.Web.UI.Page
    {
        private String ChaineDeConnexion = ConfigurationManager.ConnectionStrings["connection"].ToString();

        BaseDeDonnees donnees = new BaseDeDonnees();
        string sPersonneID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lstTousEtudiants.Visible = false;
            autocheck();
            selectcount();

            if (!IsPostBack)
            {
                Dernier_Etudiant_Inscrit();

                choisirSujet();
                //  RemplirList();
                // Dernier_Etudiant_Inscrit();

                Label lblControl = (Label)Master.FindControl("lblPageName");
                if (lblControl != null)
                {
                    lblControl.Text = "Entrer/Modifier Les Données Démographiques de l'Etudiant";
                }

                if (Request["Leader"] != null)
                {
                    // btnSave_Register.Visible = false;
                }

                if (Request["pid"] != null)
                {
                    sPersonneID = Request["pid"].ToString().Trim();
                    txtPersonneID.Text = sPersonneID;
                }

                if (sPersonneID == string.Empty)
                {
                    lblMessage.Text = "";
                }
                else
                {
                    try
                    {
                        SqlParameter paramPersonneID = new SqlParameter("@PersonneID", SqlDbType.BigInt);
                        paramPersonneID.Value = int.Parse(sPersonneID);

                        string sSql = "SELECT * FROM Personnes WHERE PersonneID = @PersonneID";
                        RemplirInfoEtudiant(sSql, paramPersonneID);
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }
                }
                txtPrenom.Focus();
            }
        }

        protected void btnsauvegarder_Click1(object sender, EventArgs e)
        {
            //ToutbagayOk();


            if (txtNom.Text == String.Empty)
            {

                lblMessage.Text = "Le champ nom est obligatoire !";
            }
            else if (DrpSexe.SelectedItem.Text == "Choisir Sexe")
            {
                lblMessage.Text = "Choisissez le sexe de la personne !";
            }
            else if (txtPrenom.Text == string.Empty)
            {
                lblMessage.Text = "Le champ Prenom est obligatoire !";
            }
            else if (txtdate.Text == string.Empty)
            {
                lblMessage.Text = "Le champ Date de naissance est obligatoire !";
            }
            else if (txtetude.Text == string.Empty)
            {
                lblMessage.Text = "Le champ Niveau d'étude est obligatoire !";
            }
            else if (txttelephone.Text == string.Empty)
            {
                lblMessage.Text = "Le champ Telephone est obligatoire !";
            }

            else if (DropDownDepartement.SelectedItem.Text == "Choisir Departement")
            {
                lblMessage.Text = "Choisissez le departement !";
            }
            else
            {
                Save();
                LoadJScript();

            }

            choisirSujet();
            //RemplirList();
            Dernier_Etudiant_Inscrit();
        }

        /// <summary>
        /// Methode sauvegarder
        /// </summary>
        void methodesauvegarder()
        {
            string sSql = "";
            string sStudentID = "";

            lblMessage.Text = string.Empty;

            sPersonneID = txtPersonneID.Text;
            try
            {
                ToutbagayOk();
                SqlParameter paramPersonneID = new SqlParameter("@PersonneID", SqlDbType.Int);
                if (Request["pid"] != null) // Existing student
                {
                    sStudentID = Request["pid"].ToString();
                    paramPersonneID.Value = int.Parse(sStudentID);
                }
                else if (sPersonneID != String.Empty)
                {
                    sStudentID = sPersonneID; // Was selected in list box of existing students/personnes
                    paramPersonneID.Value = int.Parse(sStudentID);
                }

                int etu = 1;
                int prof = 0;
                int addstaf = 0;
                string mydate;
                mydate = DateTime.Now.ToString("MM.dd.yyyy");
                SqlParameter nomparam = new SqlParameter("@Nom", DbType.String.ToString());
                nomparam.Value = txtNom.Text;
                SqlParameter prenomparam = new SqlParameter("@Prenom", DbType.String.ToString());
                prenomparam.Value = txtPrenom.Text;
                SqlParameter ddnparam = new SqlParameter("@DDN", DbType.String.ToString());
                ddnparam.Value = txtdate.Text;
                SqlParameter niveauetudeparam = new SqlParameter("@NiveauEtude", DbType.String.ToString());
                niveauetudeparam.Value = txtetude.Text;
                SqlParameter telephoneparam = new SqlParameter("@Telephone1", DbType.String.ToString());
                telephoneparam.Value = txttelephone.Text;
                SqlParameter emailparam = new SqlParameter("@Email", DbType.String.ToString());
                emailparam.Value = txtemail.Text;
                SqlParameter numeromaisonparam = new SqlParameter("@AdresseExtra", DbType.String.ToString());
                numeromaisonparam.Value = txtnumeromaison.Text;
                SqlParameter Adresserueparam = new SqlParameter("@AdresseRue", DbType.String.ToString());
                Adresserueparam.Value = txtrue.Text;
                SqlParameter Villeparam = new SqlParameter("@Ville", DbType.String.ToString());
                Villeparam.Value = txtville.Text;
                SqlParameter Remarqueparam = new SqlParameter("@Remarque", DbType.String.ToString());
                Remarqueparam.Value = txtRemarque.InnerText;
                SqlParameter UserIdparam = new SqlParameter("@CreeParUsername", DbType.String.ToString());
                UserIdparam.Value = BaseDeDonnees.GetWindowsUser();
                SqlParameter datecreparam = new SqlParameter("@DateCreee", DbType.Date);
                datecreparam.Value = mydate;
                SqlParameter profparam = new SqlParameter("@Professeur", DbType.Int32.ToString());
                profparam.Value = prof;
                SqlParameter etudiantparam = new SqlParameter("@Etudiant", DbType.Int32.ToString());
                etudiantparam.Value = etu;
                SqlParameter AdminStafparam = new SqlParameter("@AdminStaff", DbType.Int32.ToString());
                AdminStafparam.Value = addstaf;

                // Current User
                SqlParameter paramCreeParUsername = new SqlParameter("@CreeParUsername", SqlDbType.VarChar);
                paramCreeParUsername.Value = BaseDeDonnees.GetWindowsUser();

                SqlParameter Sexeparam = new SqlParameter("@Sexe", DbType.String.ToString());
                Sexeparam.Value = DrpSexe.SelectedItem.Text;

                SqlParameter departementparam = new SqlParameter("@GroupeSanguin", DbType.String.ToString());
                departementparam.Value = DropDownDepartement.SelectedItem.Text;


                SqlParameter telephone2param = new SqlParameter("@Telephone2", DbType.String.ToString());
                telephone2param.Value = Txturgence.Text;



                if (sStudentID == String.Empty)
                {
                    // methodesauvegarder();
                    sSql = "INSERT INTO Personnes (Prenom, Nom, Telephone1,Telephone2, DDN, AdresseRue, AdresseExtra, Ville, NiveauEtude, Remarque, Etudiant, Professeur, AdminStaff, CreeParUsername,Email,Sexe,GroupeSanguin) VALUES (" +
                       "@Prenom, @Nom, @Telephone1, @Telephone2,@DDN, @AdresseRue, @AdresseExtra, @Ville, @NiveauEtude, @Remarque, @Etudiant, @Professeur, @AdminStaff, @CreeParUsername,@Email,@Sexe,@GroupeSanguin)";

                    bool bResult = donnees.IssueCommandWithParams(sSql, nomparam, prenomparam, ddnparam,
                   niveauetudeparam, telephoneparam, telephone2param, emailparam, numeromaisonparam, Villeparam, datecreparam, Adresserueparam, UserIdparam, etudiantparam, profparam, AdminStafparam, departementparam
                   , Remarqueparam, Sexeparam);

                    //int iIdentity = DB_Access.GetScalarWithParams(sSql, nomparam, prenomparam, ddnparam,
                    //niveauetudeparam, telephoneparam, emailparam, numeromaisonparam, Villeparam, datecreparam, Adresserueparam, UserIdparam, etudiantparam, profparam, AdminStafparam, Remarqueparam);
                    if (bResult == true)
                    {
                        sPersonneID = bResult.ToString();
                        lblSucces.Text = string.Format("'{0} {1}' est ajouté dans le système !", txtPrenom.Text, txtNom.Text);
                        // ClearForm();
                        Nettoyer();
                        btnsauvegarder.Enabled = false;
                    }
                    else
                    {
                        lblMessage.Text = string.Format("ERROR Adding User '{0} {1}'!", txtPrenom.Text, txtNom.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERROR: " + ex.Message + string.Format("--Specific Error: ('{0} {1}') Dossier Non Modifié!", txtPrenom.Text, txtNom.Text); ;
            }

        }
        /// <summary>
        /// Methode pou netoyer textbox yo.
        /// </summary>
        void nettoyertextbox()
        {

            txtNom.Text = Regex.Replace(txtNom.Text, " ", "");
            txtPrenom.Text = Regex.Replace(txtPrenom.Text, " ", "");
            txtdate.Text = Regex.Replace(txtdate.Text, " ", "");
            txtetude.Text = Regex.Replace(txtetude.Text, " ", "");
            txttelephone.Text = Regex.Replace(txttelephone.Text, " ", "");
            txtemail.Text = Regex.Replace(txtemail.Text, " ", "");
            txtnumeromaison.Text = Regex.Replace(txtnumeromaison.Text, " ", "");
            txtrue.Text = Regex.Replace(txtrue.Text, " ", "");
            txtville.Text = Regex.Replace(txtville.Text, " ", "");


        }

        /// <summhoary>
        /// Methode pou change enfomasyon ki antre yo an lower to upper case
        /// </summary>
        void lowertoupper()
        {
            try
            {
                try
                {
                    char[] a = txtNom.Text.ToCharArray();
                    string a1 = a[0].ToString().ToUpper();
                    for (int b = 1; b < a.Length; b++)
                        a1 += a[b].ToString().ToLower();
                    txtNom.Text = a1;
                }
                catch (EvaluateException e2)
                {

                }
                try
                {
                    char[] c = txtPrenom.Text.ToCharArray();
                    string c1 = c[0].ToString().ToUpper();
                    for (int b = 1; b < c.Length; b++)
                        c1 += c[b].ToString().ToLower();
                    txtPrenom.Text = c1;
                }
                catch (EvaluateException e3)
                {

                }
                try
                {
                    char[] d = txtetude.Text.ToCharArray();
                    string d1 = d[0].ToString().ToUpper();
                    for (int b = 1; b < d.Length; b++)
                        d1 += d[b].ToString().ToLower();
                    txtetude.Text = d1;
                }
                catch (EvaluateException e4)
                {

                }

                try
                {
                    char[] f = txtrue.Text.ToCharArray();
                    string f1 = f[0].ToString().ToUpper();
                    for (int b = 1; b < f.Length; b++)
                        f1 += f[b].ToString().ToLower();
                    txtrue.Text = f1;
                }
                catch (EvaluateException e5) { }
                try
                {
                    char[] g = txtville.Text.ToCharArray();
                    string g1 = g[0].ToString().ToUpper();
                    for (int b = 1; b < g.Length; b++)
                        g1 += g[b].ToString().ToLower();
                    txtville.Text = g1;
                }
                catch (EvaluateException ex)
                {

                }

            }
            catch (EvaluateException e)
            {

            }

        }

        /// <summary>
        /// methode pou nettoyer ecran soit le moun nan fin anregistre oubyn le moun nan ap anile
        /// </summary>
        public void Nettoyer()
        {

            txtNom.Text = "";
            txtdate.Text = "";
            txtetude.Text = "";
            txtPrenom.Text = "";
            txttelephone.Text = "";
            txtemail.Text = "";
            txtnumeromaison.Text = "";
            txtrue.Text = "";
            txtville.Text = "";
            txtRemarque.InnerText = "";
            Txturgence.Text = "";
            lblMessage.Text = "";
            DropDownDepartement.SelectedIndex = -1;
            DrpSexe.SelectedIndex = -1;

            RemplirDroppdownhoraire();

            DrchoisirSujet.SelectedIndex = -1;
            DropDownListOptionhoraire1.SelectedIndex = -1;
            DropDownListOption2.SelectedIndex = -1;
            DropDownListOptionhoraire2.SelectedIndex = -1;

        }


        /// <summary>
        /// Methode pou ou konnen si session an remplie
        /// </summary>
        /// <returns></returns>
        bool SessionRemplie()
        {
            bool bRetval = true;
            try
            {
                int iSessionID = int.Parse(DropDownListOptionhoraire1.SelectedValue.ToString());
                int iMax = donnees.GetScalar("Select MaxEtudiants FROM Sessions WHERE SessionID = " + iSessionID);
                int iNombreInscrits = donnees.GetScalar("Select COUNT(SessionID) FROM EtudiantsCourants WHERE SessionID = " + iSessionID);
                return iNombreInscrits >= iMax;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERREUR: Contactez un technicien: " + ex;

                bRetval = true;
            }
            return bRetval;
        }
        /// <summary>
        /// Methode pou le etudiant finn enskri pou ou ajouter etudiant sa nan classe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnajouterdansclasse_Click(object sender, EventArgs e)
        {
            exceptionclick();
            ajouteretudiant();

            if (lstEtudiant.Text == String.Empty)
            {
                btnsauvegarder.Enabled = true;
                btnajouterdansclasse.Enabled = false;

            }
        }

        /// <summary>
        /// pou le yo clike bouton ajoute nan class la san moun pa pran anyen pou li pa di contacte yn moun
        /// /// </summary>
        void exceptionclick()
        {
            if (DropDownListOptionhoraire1.SelectedValue != "" || DropDownListNiveau.SelectedValue != "" || DropDownListOptionhoraire1.SelectedValue != "")
            {
                lblMessage.Text = "Remplissez tout les champs Svp !!!";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('Remplissez tout les champs Svp !!! ');", true);

            }

        }

        /// <summary>
        /// methode pou ajouter etudiant nan class
        /// </summary>
        void ajouteretudiant()
        {
            exceptionclick();
            // Save info in ClassSession table


            string sSql = "";

            Response.Write(string.Empty);
            if (SessionRemplie())
                lblMessage.Text = "Classe Remplie, Plus de places !!!";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert(' Classe Remplie, Plus de places !!! ');", true);

            else
            {

                try
                {
                    SqlParameter paramSessionID = new SqlParameter("@SessionID", SqlDbType.Int);
                    paramSessionID.Value = int.Parse(DropDownListOptionhoraire1.SelectedValue);
                    SqlParameter paramStudentID = new SqlParameter("@PersonneID", SqlDbType.Int);
                    paramStudentID.Value = int.Parse(lstEtudiant.SelectedValue);
                    SqlParameter paramUserId = new SqlParameter("@CreeParUsername", SqlDbType.VarChar);
                    paramUserId.Value = BaseDeDonnees.GetWindowsUser();

                    sSql = "INSERT INTO EtudiantsCourants (SessionID, PersonneID, CreeParUsername) VALUES (@SessionID, @PersonneID, @CreeParUsername)";

                    if (donnees.IssueCommandWithParams(sSql, paramSessionID, paramStudentID, paramUserId))
                    {
                        lblMessage.Text = "Succès: Etudiant Inscrit!";
                        //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert(' Succès: Etudiant Inscrit! ');", true);
                        choisirSujet();
                        DropDownListNiveau.Items.Clear();
                        DropDownListOptionhoraire1.Items.Clear();
                        btneffacer();
                        lstEtudiant.Items.Clear();
                        btnsauvegarder.Enabled = true;

                    }
                    else
                    {
                        lblMessage.Text = "ERREUR: Etudiant n'est pas inscrit!";
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert(' ERREUR: Etudiant n'est pas inscrit! ');", true);

                    }

                    //Redirect to another page

                }
                catch (Exception ex)
                {
                    Response.Write("ERROR: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Methode pou ou chwazi sujet pou mete nan textbox 
        /// </summary>
        void choisirSujet()
        {

            string remplirdrop = "SELECT '1-Choisissez un Sujet' as Categorie UNION SELECT DISTINCT Categorie from Classes group by Categorie Order By Categorie";
            DataSet ds = new DataSet();
            ds = donnees.GetDataSet(remplirdrop);
            this.DrchoisirSujet.DataSource = ds;

            DrchoisirSujet.DataValueField = "Categorie";
            DrchoisirSujet.DataBind();


            DropDownListOption2.Enabled = false;

            DropDownListOptionhoraire2.Enabled = false;

        }

        void RemplirDroppdown1()
        {

            if (DrchoisirSujet.SelectedValue == "Informatique")
            {


                String remplirdrop1 = "Select NomOption From Options where OptionID = 2";
                DataSet db = new DataSet();
                db = donnees.GetDataSet(remplirdrop1);
                this.DropDownListOption2.DataSource = db;
                DropDownListOption2.DataValueField = "NomOption";
                DropDownListOption2.DataBind();
                DropDownListOption2.Items.Insert(0, new ListItem("Choisir Autre Option"));
            }
        }

        void RemplirDroppdown2()
        {
            if (DrchoisirSujet.SelectedValue == "Anglais")
            {

                String remplirdrop1 = "Select NomOption From Options where OptionID = 1";
                DataSet db = new DataSet();
                db = donnees.GetDataSet(remplirdrop1);
                this.DropDownListOption2.DataSource = db;
                DropDownListOption2.DataValueField = "NomOption";
                DropDownListOption2.DataBind();
                DropDownListOption2.Items.Insert(0, new ListItem("Choisir Autre Option"));
            }

        }


        void RemplirDroppdownhoraire()
        {

            string remplirdropop = "Select 0 As SessionID, '3-Choisissez Un Horaire' As SessionName from Sessions UNION Select SessionID, JourRencontre + ': ' + Heures As SessionName FROM Sessions WHERE Actif = 1 AND ClasseID = " + DropDownListNiveau.SelectedValue;
            BaseDeDonnees dropdownoptionheur = new BaseDeDonnees();
            DataSet da = new DataSet();
            da = dropdownoptionheur.GetDataSet(remplirdropop);
            this.DropDownListOptionhoraire1.DataSource = da;
            DropDownListOptionhoraire1.DataValueField = "SessionID";
            DropDownListOptionhoraire1.DataTextField = "SessionName";
            DropDownListOptionhoraire1.DataBind();


        }

        void RemplirDroppdownhoraire1()
        {
            String remplirdropop = "Select SessionID, JourRencontre + ': ' + Heures As SessionName From Sessions Where Actif = 1";
            BaseDeDonnees dropdownoptionheur1 = new BaseDeDonnees();
            DataSet dc = new DataSet();
            dc = dropdownoptionheur1.GetDataSet(remplirdropop);
            this.DropDownListOptionhoraire2.DataSource = dc;
            DropDownListOptionhoraire2.DataValueField = "SessionName";
            DropDownListOptionhoraire2.DataBind();
            DropDownListOptionhoraire2.Items.Insert(0, new ListItem("Choisir Autre Horaire"));

        }

        void remplireniveau()
        {
            //String remplirdropop = "Select SessionID, JourRencontre + ': ' + Heures As SessionName From Sessions Where Actif = 1";
            string remplirdropop = string.Format("SELECT -1 as ClasseID, '2-Choisissez Une Classe' as NomClasse UNION SELECT ClasseID, NomClasse from Classes WHERE Categorie ='{0}'", DrchoisirSujet.SelectedValue);
            BaseDeDonnees dropdownoptionheur1 = new BaseDeDonnees();
            DataSet dc = new DataSet();
            dc = dropdownoptionheur1.GetDataSet(remplirdropop);
            this.DropDownListNiveau.DataSource = dc;
            DropDownListNiveau.DataValueField = "ClasseID";
            DropDownListNiveau.DataTextField = "NomClasse";
            DropDownListNiveau.DataBind();

        }
        //Method seach

        public void SearchBox()
        {
            String search = Seach.Text.Trim().ToLower().ToString();
            if (!string.IsNullOrEmpty(search) && search.Contains(lstEtudiant.Text))
            {
                String sSql = "select DISTINCT PersonneID, Nom +', ' + Prenom as NomComplet, Nom, Prenom FROM Personnes where Nom LIKE '%' +'" + search + "'+ '%' OR Prenom LIKE '%'+'" + search + "' + '%' OR Nom+' '+ Prenom LIKE '%'+'" + search + "'+ '%'";
                DataSet ds = new DataSet();
                ds = donnees.GetDataSet(sSql);
                this.lstEtudiant.DataSource = ds.Tables[0];
                lstEtudiant.DataValueField = "PersonneID";
                lstEtudiant.DataTextField = "NomComplet";
                lstEtudiant.DataBind();

            }
            else
            {
                lblMessage.Text = "Le nom que vous chercher n'existe pas la classe";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Le nom que vous chercher n'existe pas la classe');", true);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Nettoyer();
        }

        void btneffacer()
        {

            Seach.Text = "";


            if (string.IsNullOrEmpty(Seach.Text))
            {
                lstEtudiant.Items.Clear();
                // String sSql = "select PersonneID, Nom + ', ' + Prenom as NomComplet  FROM Personnes ORDER BY NomComplet ASC";
                //RemplirEtudiants(sSql);
                //RemplirList();
                Dernier_Etudiant_Inscrit();
            }
            else
            {
                lblMessage.Text = "Le nom que vous chercher n'existe pas la classe";
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", "alert('Le nom que vous chercher n'existe pas la classe');", true);

            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            btneffacer();
        }
        void autocheck()
        {
            checkEtudiant.Checked = true;
            checkEtudiant.Visible = false;
        }

        protected void Seach_TextChanged(object sender, EventArgs e)
        {
            SearchBox();
        }

        protected void txtNom_TextChanged1(object sender, EventArgs e)
        {

            if (txtPrenom.Text != String.Empty && txtNom.Text != String.Empty)
            {
                String sFirstName = txtPrenom.Text.Trim();
                String sLastName = txtNom.Text.Trim();
                //look if student is already in the system
                // Show liste of student with same name, show DDN and Telephon1 with it.

                // RemplirListeEtudiants(sFirstName, sLastName);
            }
        }

        protected void txtPrenom_TextChanged1(object sender, EventArgs e)
        {
            if (txtPrenom.Text != String.Empty && txtNom.Text != String.Empty)
            {
                String sFirstName = txtPrenom.Text.Trim();
                String sLastName = txtNom.Text.Trim();
                //look if student is already in the system
                // Show liste of student with same name, show DDN and Telephon1 with it.

                // RemplirListeEtudiants(sFirstName, sLastName);
                // sPersonneID = lstEtudiantsExistants.SelectedValue.ToString();
            }
        }

        void RemplirInfoEtudiant(String sSql, SqlParameter paramPersonneID)
        {
            //string sql = "Select * From Personnes Where PersonneID =;
            // string Sql = String.Format("SELECT PersonneID, Nom + ', ' + Prenom  + '-' + replace(convert(nvarchar,Isnull(DDN,'')), '1900-01-01', 'N/A')  + '-' + Isnull(Telephone1,'N/A')  as NomComplet FROM Personnes WHERE Nom LIKE '{0}%' AND Prenom LIKE '{1}%'", sLastName, sFirstName);
            SqlDataReader dt = donnees.GetDataReaderWithParams(sSql, paramPersonneID);
            if (dt != null)
            {
                if (dt.Read())
                {
                    txtetude.Text = dt["NiveauEtude"].ToString();
                    txtNom.Text = dt["Nom"].ToString();
                    txtPrenom.Text = dt["Prenom"].ToString();
                    txttelephone.Text = dt["Telephone1"].ToString();
                    txtrue.Text = dt["AdresseRue"].ToString();
                    txtemail.Text = dt["Email"].ToString();
                    txtnumeromaison.Text = dt["Email"].ToString();
                    // txtdate.Text = dt["DDN"].ToString();
                    txtville.Text = dt["Ville"].ToString();
                    txtRemarque.InnerText = dt["Remarque"].ToString();

                    // Date est speciale, format est: 00-00-0000 for mois-jour-annee
                    string sDate = dt["DDN"].ToString();
                    if (sDate != string.Empty)
                    {
                        DateTime dtTemp = Convert.ToDateTime(sDate);
                        txtdate.Text = dtTemp.Month.ToString();
                        if (dtTemp.Month < 10)
                            txtdate.Text = "0" + txtdate.Text;
                        if (dtTemp.Day < 10)
                            txtdate.Text = txtdate.Text + "-0" + dtTemp.Day.ToString() + "-" + dtTemp.Year.ToString();
                        else
                            txtdate.Text = txtdate.Text + "-" + dtTemp.Day.ToString() + "-" + dtTemp.Year.ToString();
                    }
                    // Photo

                }
            }
        }
        bool ToutbagayOk()
        {
            bool bValeur = true;
            if (DrpSexe.SelectedIndex == -1)
                bValeur = false;
            if (DropDownDepartement.SelectedIndex == -1)
                bValeur = false;

            return bValeur;
        }
        protected void Save()
        {
            //string sSql = "";
            string sStudentID = "";

            lblMessage.Text = string.Empty;

            sPersonneID = txtPersonneID.Text;
            try
            {
                ToutbagayOk();
                SqlParameter paramPersonneID = new SqlParameter("@PersonneID", SqlDbType.Int);
                if (Request["pid"] != null) // Existing student
                {
                    sStudentID = Request["pid"].ToString();
                    paramPersonneID.Value = int.Parse(sStudentID);
                }
                else if (sPersonneID != String.Empty)
                {
                    sStudentID = sPersonneID; // Was selected in list box of existing students/personnes
                    paramPersonneID.Value = int.Parse(sStudentID);
                }

                if (sStudentID == String.Empty)
                {
                    methodesauvegarder();         
                }
                else
                {
                    Edit();

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERROR: " + ex.Message + string.Format("--Specific Error: ('{0} {1}') Dossier Non Modifié!", txtPrenom.Text, txtNom.Text); ;
            }

        }

        protected void Edit()
        {
            int etu = 1;
            int prof = 0;
            int addstaf = 0;
            string mydate;
            string sSql = "";
            string sStudentID = "";

            lblMessage.Text = string.Empty;

            sPersonneID = txtPersonneID.Text;
            try
            {
                // ToutbagayOk();
                SqlParameter paramPersonneID = new SqlParameter("@PersonneID", SqlDbType.Int);
                if (Request["pid"] != null) // Existing student
                {
                    sStudentID = Request["pid"].ToString();
                    paramPersonneID.Value = int.Parse(sStudentID);
                }
                else if (sPersonneID != String.Empty)
                {
                    sStudentID = sPersonneID; // Was selected in list box of existing students/personnes
                    paramPersonneID.Value = int.Parse(sStudentID);
                }
                mydate = DateTime.Now.ToString("MM.dd.yyyy");
                SqlParameter nomparam = new SqlParameter("@Nom", DbType.String.ToString());
                nomparam.Value = txtNom.Text;
                SqlParameter prenomparam = new SqlParameter("@Prenom", DbType.String.ToString());
                prenomparam.Value = txtPrenom.Text;
                SqlParameter ddnparam = new SqlParameter("@DDN", DbType.String.ToString());
                ddnparam.Value = txtdate.Text;
                SqlParameter niveauetudeparam = new SqlParameter("@NiveauEtude", DbType.String.ToString());
                niveauetudeparam.Value = txtetude.Text;
                SqlParameter telephoneparam = new SqlParameter("@Telephone1", DbType.String.ToString());
                telephoneparam.Value = txttelephone.Text;
                SqlParameter emailparam = new SqlParameter("@Email", DbType.String.ToString());
                emailparam.Value = txtemail.Text;
                SqlParameter numeromaisonparam = new SqlParameter("@AdresseExtra", DbType.String.ToString());
                numeromaisonparam.Value = txtnumeromaison.Text;
                SqlParameter Adresserueparam = new SqlParameter("@AdresseRue", DbType.String.ToString());
                Adresserueparam.Value = txtrue.Text;
                SqlParameter Villeparam = new SqlParameter("@Ville", DbType.String.ToString());
                Villeparam.Value = txtville.Text;
                SqlParameter Remarqueparam = new SqlParameter("@Remarque", DbType.String.ToString());
                Remarqueparam.Value = txtRemarque.InnerText;
                SqlParameter UserIdparam = new SqlParameter("@CreeParUsername", DbType.String.ToString());
                UserIdparam.Value = BaseDeDonnees.GetWindowsUser();
                SqlParameter datecreparam = new SqlParameter("@DateCreee", DbType.Date);
                datecreparam.Value = mydate;
                SqlParameter profparam = new SqlParameter("@Professeur", DbType.Int32.ToString());
                profparam.Value = prof;
                SqlParameter etudiantparam = new SqlParameter("@Etudiant", DbType.Int32.ToString());
                etudiantparam.Value = etu;
                SqlParameter AdminStafparam = new SqlParameter("@AdminStaff", DbType.Int32.ToString());
                AdminStafparam.Value = addstaf;

                // Current User
                SqlParameter paramCreeParUsername = new SqlParameter("@CreeParUsername", SqlDbType.VarChar);
                paramCreeParUsername.Value = BaseDeDonnees.GetWindowsUser();

                SqlParameter Sexeparam = new SqlParameter("@Sexe", DbType.String.ToString());
                Sexeparam.Value = DrpSexe.SelectedItem.Text;

                SqlParameter departementparam = new SqlParameter("@GroupeSanguin", DbType.String.ToString());
                departementparam.Value = DropDownDepartement.SelectedItem.Text;


                SqlParameter telephone2param = new SqlParameter("@Telephone2", DbType.String.ToString());
                telephone2param.Value = Txturgence.Text;

                sSql = "UPDATE Personnes SET Prenom = @Prenom, Nom = @Nom, Telephone1 = @Telephone1, DDN = @DDN, AdresseRue = @AdresseRue, AdresseExtra = @AdresseExtra, Ville = @Ville, NiveauEtude = @NiveauEtude,  Remarque = @Remarque, Etudiant = @Etudiant, Professeur = @Professeur,AdminStaff = @AdminStaff, CreeParUsername = @CreeParUsername, Email = @Email WHERE PersonneID = @PersonneID";
                if (donnees.IssueCommandWithParams(sSql, nomparam, prenomparam, ddnparam,
                niveauetudeparam, telephoneparam, emailparam, numeromaisonparam, Villeparam, datecreparam, Adresserueparam, UserIdparam, etudiantparam, profparam, AdminStafparam, Remarqueparam, paramPersonneID))
                {
                    lblSucces.Text = string.Format("'{0} {1}' est mis à jour !", txtPrenom.Text, txtNom.Text);
                    Nettoyer();
                }
                else
                {
                    lblMessage.Text = "ERREUR: Dossier n'est pas mis à jour !";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERROR: " + ex.Message + string.Format("--Specific Error: ('{0} {1}') Dossier Non Modifié!", txtPrenom.Text, txtNom.Text); ;
            }
        }
        internal void LoadJScript()
        {
            ClientScriptManager script = Page.ClientScript;
            //prevent duplicate script
            if (!script.IsStartupScriptRegistered(this.GetType(), "HideLabel"))
            {
                script.RegisterStartupScript(this.GetType(), "HideLabel",
                "<script type='text/javascript'>HideLabel('" + lblSucces.ClientID + "')</script>");
            }
        }
        void RemplirListeEtudiants(String sFirstName, String sLastName)
        {
            lblMessage.Text = "";

            try
            {
                //SELECT 0 As PersonneID, 'Choisissez Si Déjà Dans le Système' As NomComplet UNION 
                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Auth_connectionString"].ConnectionString);
                string sSql = String.Format("SELECT PersonneID, Nom + ', ' + Prenom  + '-' + replace(convert(nvarchar,Isnull(DDN,'')), '1900-01-01', 'N/A')  + '-' + Isnull(Telephone1,'N/A')  as NomComplet FROM Personnes WHERE Nom LIKE '{0}%' AND Prenom LIKE '{1}%'", sLastName, sFirstName);

                SqlDataAdapter da = new SqlDataAdapter(sSql, myConnection);
                DataTable dTable = new DataTable();
                da.Fill(dTable);

                lstTousEtudiants.DataSource = dTable;
                lstTousEtudiants.DataValueField = "PersonneID";
                lstTousEtudiants.DataTextField = "NomComplet";

                lstTousEtudiants.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERREUR: Contactez un techniciens: " + ex.Message;
            }
        }

        protected void lstEtudiant_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sPersonneID = lstTousEtudiants.SelectedValue.ToString();
                txtPrenom.Text = sPersonneID;
                SqlParameter paramPersonneID = new SqlParameter("@PersonneID", SqlDbType.BigInt);
                paramPersonneID.Value = int.Parse(sPersonneID);

                string sSql = "SELECT * FROM Personnes WHERE PersonneID = @PersonneID";
                RemplirInfoEtudiant(sSql, paramPersonneID);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        public void Dernier_Etudiant_Inscrit()
        {
            //String remplirdropop = "Select SessionID, JourRencontre + ': ' + Heures As SessionName From Sessions Where Actif = 1";
            //string sSql = "SELECT PersonneID, Nom + ', ' + Prenom as NomComplet FROM Personnes WHERE Etudiant = 1 ORDER BY Nom, Prenom";
            BaseDeDonnees donnees = new BaseDeDonnees();
            String user = BaseDeDonnees.GetWindowsUser();
            // String Administrator = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            //String sSql = "SELECT PersonneID, Nom + ', ' + Prenom as NomComplet From Personnes WHERE Etudiant = 1  AND CreeParUsername = '" + user.Trim() + "' AND PersonneID = (Select MAX(Personnes.PersonneID) From Personnes)";
            String sSql = ("SELECT PersonneID,Nom + '     ' + Prenom + '---' + replace(convert(nvarchar,Isnull(DDN,'')), '1900-01-01', 'N/A') as NomComplet From Personnes, DatesSessionCourante D WHERE Etudiant = 1 AND D.actif = 1 AND CreeParUsername = '" + user.Trim() + "' order by Personnes.PersonneID DESC");
            //'" + user.Trim();
            //String sSql = String.Format("SELECT P.PersonneID, P.Nom + ', ' + P.Prenom + '--' + replace(convert(nvarchar,Isnull(P.DDN,'')), '1900-01-01', 'N/A') as NomComplet " +
            //    "FROM Personnes P,EtudiantsCourants E,DatesSessionCourante D, Sessions S WHERE E.PersonneID = P.PersonneID AND E.SessionID = S.SessionID AND Etudiant = 1 AND D.actif = 1 ORDER BY NomComplet");

            DataSet dc = new DataSet();
            dc = donnees.GetDataSet(sSql);
            this.lstEtudiant.DataSource = dc;
            lstEtudiant.DataValueField = "PersonneID";
            lstEtudiant.DataTextField = "NomComplet";
            lstEtudiant.DataBind();
            this.lstEtudiant.SelectedIndex = 0;
        }


        void selectcount()
        {
            String user = BaseDeDonnees.GetWindowsUser().ToString().Trim();
            String sTemp = "";
            string sql = "SELECT count(CreeParUsername)  as countuser FROM Personnes   where DateCreee= CONVERT(date, getdate())  and CreeParUsername ='" + user.Trim() + "'";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, ChaineDeConnexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataTableReader dr = dt.CreateDataReader();
                if (dr != null)
                {
                    dr.Read();
                    sTemp = dr["countuser"].ToString().Trim();
                    LblCount.ForeColor = System.Drawing.Color.Green;
                    LblCount.Text = " Vous avez inscrit  " + sTemp + "  Etudiant(s) Pour Aujourd' ! ";

                }
            }catch(Exception e)
            {
                lblSucces.Text= ("Error: No database connection");
            }
        }

        protected void DrchoisirSujet_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void DropDownListNiveau_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void DropDownListOptionhoraire1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void lstTousEtudiants_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}