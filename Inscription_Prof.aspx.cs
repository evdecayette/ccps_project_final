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
    public partial class Inscription_Prof : System.Web.UI.Page
    {
        BaseDeDonnees donnees = new BaseDeDonnees();
        private String ChaineDeConnexion = ConfigurationManager.ConnectionStrings["connection"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void methodesauvegarder()
        {

            if (txtNom.Text == "" || txtdate.Text == "" || txtetude.Text == "" || txtPrenom.Text == ""
                || txtrue.Text == "" || txtville.Text == "")
            {

                lblerror.Text = "Remplissez tout les champs Svp !!!";


                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('Remplissez tout les champs Svp !!! ');", true);
            }
            else
            {
                lblerror.Text = "";
                int prof = 1;
                int etu = 0;
                int addstaf = 0;
                nettoyertextbox();
                //lowertoupper();


                try
                {
                    //    String insereEtudiant = "INSERT INTO Personnes (Prenom,Nom,Telephone1,DDN,AdresseRue,AdresseExtra,Ville,NiveauEtude,DateCreee,Remarque,Etudiant,Professeur,AdminStaff,CreeParUsername,Email" +
                    //                           "values(@Prenom,@Nom,@Telephone1,@DDN,@AdresseRue,@AdresseExtra,@Ville,@NiveauEtude,@DateCreee,@Remarque,@Etudiant,@Professeur,@AdminStaff,@CreeParUsername,@Email)";
                    String insereEtudiant = "INSERT INTO Personnes (Prenom, Nom, Telephone1, DDN, AdresseRue, AdresseExtra, Ville, NiveauEtude, Remarque, Etudiant, Professeur, AdminStaff, CreeParUsername,Email) VALUES (" +
                       "@Prenom, @Nom, @Telephone1,@DDN, @AdresseRue, @AdresseExtra, @Ville, @NiveauEtude, @Remarque, @Etudiant, @Professeur, @AdminStaff, @CreeParUsername,@Email)";

                    string mydate;
                    mydate = DateTime.Now.ToString("MM.dd.yyyy");
                    string nom = formaterNom(txtNom.Text);
                    string prenom = formaterNom(txtPrenom.Text);
                    SqlParameter nomparam = new SqlParameter("@Nom", DbType.String.ToString());
                    nomparam.Value = nom;
                    SqlParameter prenomparam = new SqlParameter("@Prenom", DbType.String.ToString());
                    prenomparam.Value = prenom;
                    SqlParameter ddnparam = new SqlParameter("@DDN", DbType.String.ToString());
                    ddnparam.Value = txtdate.Text;
                    SqlParameter niveauetudeparam = new SqlParameter("@NiveauEtude", DbType.String.ToString());
                    niveauetudeparam.Value = txtetude.Text;
                    SqlParameter telephoneparam = new SqlParameter("@Telephone1", DbType.String.ToString());
                    telephoneparam.Value = txtTelephone.Text;
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
                    // SqlParameter Nifparam = new SqlParameter("@Etudiant", DbType.Int32.ToString());
                    //  Nifparam.Value = TextnifOuCin.Text; ;


                    bool bResult = donnees.IssueCommandWithParams(insereEtudiant, nomparam, prenomparam, ddnparam,
                        niveauetudeparam, telephoneparam, emailparam, numeromaisonparam, Villeparam, datecreparam, Adresserueparam, UserIdparam, etudiantparam, profparam, AdminStafparam, Remarqueparam);

                }
                catch (Exception e)
                {
                    Response.Write("Ërror..." + e);
                }

                lblerror.Text = "Professeur Enregistrer avec Succes  !!! ";

                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert(' Professeur Enregistrer avec Succes  !!! ');", true);
                Nettoyer();
            }
        }

        void nettoyertextbox()
        {

            txtNom.Text = Regex.Replace(txtNom.Text, " ", "");
            txtPrenom.Text = Regex.Replace(txtPrenom.Text, " ", "");
            txtdate.Text = Regex.Replace(txtdate.Text, " ", "");
            txtetude.Text = Regex.Replace(txtetude.Text, " ", "");
            txtTelephone.Text = Regex.Replace(txtTelephone.Text, " ", "");
            txtemail.Text = Regex.Replace(txtemail.Text, " ", "");
            txtnumeromaison.Text = Regex.Replace(txtnumeromaison.Text, " ", "");
            txtrue.Text = Regex.Replace(txtrue.Text, " ", "");
            txtville.Text = Regex.Replace(txtville.Text, " ", "");
            lblerror.Text = "";

        }

        String formaterNom(String value)
        {
            String valRetourne = value.Trim();
            valRetourne = value.Substring(0, 1).ToUpper() +
                   value.Substring(1).ToLower();
            int index = valRetourne.IndexOf(" ");
            if (index > 1)
            {
                String moso1 = valRetourne.Substring(0, index) + " ";
                String moso2 = valRetourne.Substring(index + 1).Trim();
                valRetourne = moso1 + moso2.Substring(0, 1).ToUpper() +
                    moso2.Substring(1).ToLower();
            }

            return valRetourne;



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


                    txtNom.Text = formaterNom(txtNom.Text.ToString());


                }
                catch (EvaluateException e2)
                {

                }
                try
                {


                    txtPrenom.Text = formaterNom(txtPrenom.Text.ToString());


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
                catch (EvaluateException e6) { }

            }
            catch

                (EvaluateException e)
            {

            }

        }

        public void Nettoyer()
        {

            txtNom.Text = "";
            txtdate.Text = "";
            txtetude.Text = "";
            txtPrenom.Text = "";
            txtTelephone.Text = "";
            txtemail.Text = "";
            txtnumeromaison.Text = "";
            txtrue.Text = "";
            txtville.Text = "";
            txtRemarque.InnerText = "";
            TextnifOuCin.Text = "";

            lblerror.Text = "";

        }

        protected void btnsauvegarder_Click(object sender, EventArgs e)
        {
            methodesauvegarder();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Nettoyer();
        }
    }
}