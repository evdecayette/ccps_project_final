using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCPS_Web_Edu_Update
{
    public partial class AddSession : System.Web.UI.Page
    {
        private readonly BaseDeDonnees donnees = new BaseDeDonnees();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnAddSession_Click(object sender, EventArgs e)
        {
            String sSql = String.Empty;
            String sID = String.Empty;

            if (CheckBox1.Checked == false)
            {
                String sqlup = "Update DatesSessionCourante set Actif =0 WHERE Actif = 1";
                donnees.IssueCommand(sqlup);
                String sql = "Insert into DatesSessionCourante (SessionDateDebut,SessionDateFin,Remarque) values(@DateDebut,@DateFin,@Remarque)";
                SqlParameter dateDebut = new SqlParameter("@DateDebut", DbType.String.ToString());
                dateDebut.Value = DateDebut.Text;
                SqlParameter dateFin = new SqlParameter("@DateFin", DbType.String.ToString());
                dateFin.Value = DateFin.Text;
                SqlParameter remarque = new SqlParameter("@Remarque", DbType.String.ToString());
                remarque.Value = SessionRemarque.Text;
                bool bResult;//= donnees.IssueCommandWithParams(sql, dateDebut, dateFin, remarque);
                if (bResult = donnees.IssueCommandWithParams(sql, dateDebut, dateFin, remarque))
                {
                    // //sID = "lblSessionDateID";
                    //// sSql = "UPDATE DatesSessionCourante SET Actif = 0 WHERE SessionDateID = @SessionDateID";
                    // SqlParameter ParamSessionDateID = new SqlParameter("@SessionDateID", SqlDbType.Int);
                    // ParamSessionDateID.Value = Int32.Parse(sID);
                    // if (!DB_Access.IssueCommandWithParams(sSql, ParamSessionDateID))
                    // {
                    //     lblError.InnerText = "ERREUR Technique !!!!";
                    // }

                    // Update Table Sessions pour réfléter le changement
                    //sSql = "UPDATE Sessions SET Actif = 0 WHERE DateCommence IN (SELECT SessionDateDebut FROM DatesSessionCourante WHERE SessionDateID = @SessionDateID) AND DateFin IN (SELECT SessionDateFin FROM DatesSessionCourante WHERE SessionDateID = @SessionDateID)";
                    sSql = "UPDATE Sessions SET Actif = 0 WHERE Actif =1";
                    if (!donnees.IssueCommand(sSql))
                    {
                        lblError.InnerText = "ERREUR Les Classes sont toujours actives !!";
                    }


                    CheckBox1.Checked = false;
                    DateDebut.Text = ("");
                    DateFin.Text = ("");
                    SessionRemarque.Text = ("");
                }
            }
            else if (CheckBox1.Checked == true)
            {
                String sql = "Update AddSession set DateDebut =@DateDebut,DateFin=@DateFin,Remarque=@Remarque WHERE Actif = 1";
                SqlParameter dateDebut = new SqlParameter("@DateDebut", DbType.String.ToString());
                dateDebut.Value = DateDebut.Text;
                SqlParameter dateFin = new SqlParameter("@DateFin", DbType.String.ToString());
                dateFin.Value = DateFin.Text;
                SqlParameter remarque = new SqlParameter("@Remarque", DbType.String.ToString());
                remarque.Value = SessionRemarque.Text;
                bool bResult;//= donnees.IssueCommandWithParams(sql, dateDebut, dateFin, remarque);
                if (bResult = donnees.IssueCommandWithParams(sql, dateDebut, dateFin, remarque))
                {
                    CheckBox1.Checked = false;
                    DateDebut.Text = ("");
                    DateFin.Text = ("");
                    SessionRemarque.Text = ("");
                    debuSessionCourante.InnerText = "";
                    FinSessionCourante.InnerText = "";
                }

            }
            else
            {
                Response.Write("Les dates sont obligatoires");
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            SelectDate();
        }

        private void SelectDate()
        {
            String ChaineDeConnexion = ConfigurationManager.ConnectionStrings["connection"].ToString();
            string sSql = "SELECT SessionDateID, Convert(varchar, SessionDateDebut) + ' - ' + Convert(varchar,SessionDateFin) AS SessionDate from DatesSessionCourante WHERE Actif = 1  ORDER BY SessionDateDebut DESC";
            donnees.GetDataReader(sSql);
            SqlDataAdapter da = new SqlDataAdapter(sSql, ChaineDeConnexion);
            DataTable dTable = new DataTable();
            da.Fill(dTable);

            //DataTableReader dt = donnees;

            DataTableReader dr = dTable.CreateDataReader();


            if (dr != null)
            {
                dr.Read();
                string[] sTemp = dr["SessionDate"].ToString().Split('-');
                debuSessionCourante.InnerText = " ====> de la session : " + sTemp[0].Trim();
                FinSessionCourante.InnerText = "  ====>  de La session : " + sTemp[1].Trim();
            }

        }
    }
}