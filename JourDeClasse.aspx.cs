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
    public partial class JourDeClasse : System.Web.UI.Page
    {
        BaseDeDonnees donnees = new BaseDeDonnees();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddJour_Click(object sender, EventArgs e)
        {
            String sql = "Insert into JoursDeClasses(JourDescription) values(@JourDescription)";
            SqlParameter jDesc = new SqlParameter("@JourDescription", DbType.String.ToString());
            jDesc.Value = txtJour.Text;
            bool bRes = donnees.IssueCommandWithParams(sql, jDesc);
        }
    }
}