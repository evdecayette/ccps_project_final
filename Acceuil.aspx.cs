using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCPS_Web_Edu_Update
{
    public partial class Acceuil : System.Web.UI.Page
    {

        BaseDeDonnees baseDeDonnees = new BaseDeDonnees();
        protected void Page_Load(object sender, EventArgs e)
        {
            Annonce();
            Literal1.Mode = LiteralMode.Encode;
            Literal1.Mode = LiteralMode.PassThrough;
            Literal1.Mode = LiteralMode.Transform;

        }
        /// <summary>
        /// cette methode prendre les annonce dans la base de données pour ensuite l afficher sur l'ecran
        /// </summary>
        public void Annonce()
        {
            try
            {
                int iRowIndex = 0;

                Literal1.Text = "<table id='Annonces' width='100%' font-size='20px' align='center'><tr><th></th></tr>";
                string sSql = "SELECT * FROM Annonces WHERE Actif = 1";
                SqlDataReader dt = baseDeDonnees.GetDataReader(sSql);
                if (dt != null)
                {
                    while (dt.Read())
                    {
                        if ((iRowIndex++ % 2) == 0)
                        {
                            Literal1.Text += string.Format("<tr ><td>{0}</td></tr>", dt["Annonce"].ToString());
                        }
                        else
                        {
                            Literal1.Text += string.Format("<tr class='alt'><td>{0}</td></tr>", dt["Annonce"].ToString());
                        }
                    }
                }
                Literal1.Text += "</table>";
            }
            catch (Exception ex)
            {
                Response.Write("Error " + ex.Message);
            }
        }
    }
}