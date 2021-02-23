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
    public partial class HeureDeClasse : System.Web.UI.Page
    {
        BaseDeDonnees donnees = new BaseDeDonnees();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Classe Categorie
            DroClasseCat.Items.Insert(0, new ListItem("Select Option", "0"));
            DroClasseCat.Items.Insert(1, new ListItem("Informatique", "1"));
            DroClasseCat.Items.Insert(2, new ListItem("Anglais", "2"));
        }

        protected void AddHeure_Click(object sender, EventArgs e)
        {
            String sql = "Insert into HeuresDeClasses(HeureDescription,Categorie) values(@HeureDescription,@Categorie)";
            SqlParameter HDesc = new SqlParameter("@HeureDescription", DbType.String.ToString());
            HDesc.Value = txtHeure.Text;
            SqlParameter HCategorie = new SqlParameter("@Categorie", DbType.String.ToString());
            HCategorie.Value = DroClasseCat.SelectedItem.Text;
            bool bRes = donnees.IssueCommandWithParams(sql, HDesc, HCategorie);
        }
    }
}