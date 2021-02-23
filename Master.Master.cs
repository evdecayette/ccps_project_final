using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCPS_Web_Edu_Update
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddSession_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSession.aspx");
        }

        protected void btnClasse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Classe.aspx");
        }
        protected void btnSalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalleDeClasse.aspx");
        }

        protected void btnJourDeclasse_Click(object sender, EventArgs e)
        {
            Response.Redirect("JourDeClasse.aspx");
        }

        protected void btnAnnonce_Click(object sender, EventArgs e)
        {
            Response.Redirect("Annonce.aspx");
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditSessions.aspx");
        }


        protected void btnHeureDeClasse_Click(object sender, EventArgs e)
        {
            Response.Redirect("HeureDeClasse.aspx");
        }

        protected void btnChoixProf_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChoixProf.aspx");

        }
    }
}