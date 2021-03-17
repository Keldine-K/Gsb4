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

       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void InitializeTimer()
        {
            timer1.Interval = 10000;
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                timer1.Start();

                GestionDate date = new GestionDate();
                String ajd = date.dateJour();
                int a = int.Parse(ajd.Substring(0, 1));

                maConnexion = ConnexionSql.getInstance(provider, dataBase, Uid, mdp);

                
                if (a >= 1 && a <= 10)
                {

                    maConnexion.openConnection();
                    DataTable dt = new DataTable();
                    MySqlCommand oCom1 = maConnexion.reqExec("Update testfichefrais set idEtat = 'CL' where idEtat ='CR' and mois =" + date.moisPrecedent());
                    oCom1.ExecuteNonQuery();

                   /* oCom = maConnexion.reqExec("Select * from testfichefrais where mois =" + date.moisPrecedent());
                    dt.Load(oCom.ExecuteReader());

                    dataGridView1.DataSource = dt;*/
                }
                if (a > 20)
                {
                    maConnexion.openConnection();

                    DataTable dt = new DataTable();
                    MySqlCommand oCom1 = maConnexion.reqExec("Update testfichefrais set idEtat = 'RB' where idEtat ='VA' and mois =" + date.moisPrecedent());
                    oCom1.ExecuteNonQuery();

                    /*oCom = maConnexion.reqExec("Select * from testfichefrais where mois =" + date.moisPrecedent());
                    dt.Load(oCom.ExecuteReader());

                    dataGridView1.DataSource = dt;*/
                    maConnexion.closeConnection();
                    
                }
                timer1.Stop();
            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }

        }
    }
}
