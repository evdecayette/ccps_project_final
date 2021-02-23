using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CCPS_Web_Edu_Update
{
    public partial class Classe : System.Web.UI.Page
    {
        private readonly BaseDeDonnees donnees = new BaseDeDonnees();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //RemplirDropDownClasse();
                lblError.InnerText = string.Empty;
            }
        }

        protected void btnClasse_Click(object sender, EventArgs e)
        {
            RemplirDropDownClasse();
        }

        public void RemplirDropDownClasse()
        {
            lblError.InnerText = string.Empty;
            try
            {
                if (txtNomClasse.Text == string.Empty)
                {
                    lblError.InnerText = ("Le Nom de la classe est obligatoire");
                }
                else if (txtDescClasse.Text == string.Empty)
                {
                    lblError.InnerText = ("La description est obligatoire");
                }
                else if (txtNiveau.Text == string.Empty)
                {
                    lblError.InnerText = ("Le Niveau est obligatoire");
                }
                else if (txtCategorie.Text == string.Empty)
                {
                    lblError.InnerText = ("Le champ du gategorie est obligatoire");
                }
                else
                {
                    String sql = "Insert into Classes(NomClasse,Description,NiveauClasse,Categorie) values(@NomClasse,@Description,@Niveau,@Categorie)";
                    SqlParameter nClasse = new SqlParameter("@NomClasse", DbType.String.ToString());
                    nClasse.Value = txtNomClasse.Text;
                    SqlParameter Descrip = new SqlParameter("@Description", DbType.String.ToString());
                    Descrip.Value = txtDescClasse.Text;
                    SqlParameter niveau = new SqlParameter("@Niveau", DbType.String.ToString());
                    niveau.Value = txtNiveau.Text;
                    SqlParameter categorie = new SqlParameter("@Categorie", DbType.String.ToString());
                    categorie.Value = txtCategorie.Text;
                    bool bRes = donnees.IssueCommandWithParams(sql, nClasse, Descrip, niveau, categorie);
                    if (bRes == true)
                    {
                        txtNomClasse.Text = string.Empty;
                        txtDescClasse.Text = string.Empty;
                        txtNiveau.Text = string.Empty;
                        txtCategorie.Text = string.Empty;
                        lblError.InnerText = string.Empty;
                        lblError.InnerText = "Sauvegarder Avec Succes...!!!";
                    }
                    else
                    {
                        lblError.InnerText = ("Error...!!");
                    }
                }
            }
            catch (Exception e)
            {
                lblError.InnerText = ("Error...!!" + e);
            }
        }
    }
}