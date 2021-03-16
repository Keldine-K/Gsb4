using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Gsb4
{
    public partial class Form1 : Form
    {
        private string provider = "localhost";
        private string dataBase = "gsb-v1";
        private string Uid = "root";
        private string mdp = "";

        private ConnexionSql maConnexion;

        MySqlCommand oCom;

        GestionDate date = new GestionDate();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                maConnexion = ConnexionSql.getInstance(provider, dataBase, Uid, mdp);

                maConnexion.openConnection();

                DataTable dt = new DataTable();
                MySqlCommand oCom1 = maConnexion.reqExec("Update testfichefrais set idEtat = 'CL' where idEtat ='CR' and mois =" + date.moisPrecedent());
                oCom1.ExecuteNonQuery();

                oCom = maConnexion.reqExec("Select * from testfichefrais where mois =" + date.moisPrecedent());
                dt.Load(oCom.ExecuteReader());

                dataGridView1.DataSource = dt;
                maConnexion.closeConnection();

            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }

        }
    }
}
