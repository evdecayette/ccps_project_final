using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCPS_Web_Edu_Update
{
    public partial class ChoixProf : System.Web.UI.Page
    {
        private BaseDeDonnees donnees = new BaseDeDonnees();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectActifProf();
            }
        }

        protected void SaveProfChoisir_Click(object sender, EventArgs e)
        {
            if (donnees.IssueCommand(string.Format("UPDATE Personnes SET AdminStaff = 1 WHERE PersonneID = {0}", ChProfActifID.SelectedItem.Value)))
            {
                Textarea1.InnerText = "Succès !!!!";
                ChProfActifID.SelectedIndex = -1;

            }
        }

        public void SelectActifProf()
        {

            string sSql = "SELECT CONCAT (Nom,Prenom) , Nom +' '+ Prenom as NomProfActif,PersonneID FROM Personnes WHERE Professeur = 1 ";

            donnees = new BaseDeDonnees();
            //DataTable ds = new DataTable();
            DataSet ds = new DataSet();
            ds = donnees.GetDataSet(sSql);
            this.ChProfActifID.DataSource = ds;
            ChProfActifID.DataValueField = "PersonneID";
            ChProfActifID.DataTextField = "NomProfActif";
            ChProfActifID.DataBind();

        }

        protected void ChProfActifID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "";
            if (ChProfActifID.Items.Count > 0)
            {
                foreach (ListItem item in ChProfActifID.Items)
                {
                    if (item.Selected)
                    {

                        str += item.Text + "-";
                    }
                    donnees.IssueCommand(string.Format("UPDATE Personnes SET AdminStaff = 1 WHERE PersonneID = {0}", ChProfActifID.SelectedItem.Value));

                }

                List<ListItem> selected = ChProfActifID.Items.Cast<ListItem>().Where(li => li.Selected).ToList();

            }
            else if (ChProfActifID.SelectedIndex != -1)
            {

                ChProfActifID.SelectedIndex = -1;
            }
            Textarea1.InnerText = str;

        }
    }
}