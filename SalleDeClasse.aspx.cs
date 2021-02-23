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
    public partial class SalleDeClasse : System.Web.UI.Page
    {
        BaseDeDonnees donnees = new BaseDeDonnees();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalleName_Click(object sender, EventArgs e)
        {
            String sqlAnn = "Insert into SalleDeClasses(NomSalle,SalleDescription) values(@NomSalle,@SalleDescription)";
            SqlParameter nParam = new SqlParameter("@NomSalle", DbType.String.ToString());
            nParam.Value = txtSallDeClasse.Text.Trim();
            SqlParameter dParam = new SqlParameter("@SalleDescription", DbType.String.ToString());
            dParam.Value = txtDescriptionSalle.Text.Trim();
            bool bRes;
            if (bRes = donnees.IssueCommandWithParams(sqlAnn, nParam, dParam))
            {
                txtSallDeClasse.Text = "";
                txtDescriptionSalle.Text = "";
            }
        }
    }
}