using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RobertTomic
{
    public partial class Narucivanje : Form
    {
        public Narucivanje()
        {
            InitializeComponent();
            popuni_combo();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = PozivBaze.konekcija();

            con.Open();




            string zadatak = "INSERT INTO Narucivanje(Vlasnik,Dijelovi,Kooperant)  VALUES('" + this.comboBox1.Text + "' ,'" + this.textBox1.Text + "' , ' " + this.comboBox2.Text + "'   );";
            SqlCommand cmd = new SqlCommand(zadatak, con);

            cmd.ExecuteNonQuery();

            con.Close();

            this.textBox1.Text = " ";
            comboBox1.Text = "";

        }

        private void popuni_combo()
        {
            var con = PozivBaze.konekcija();
            con.Open();
            string izvadi = "select * from  Servis;";
            SqlCommand izvadi_cmd = new SqlCommand(izvadi, con);
            SqlDataReader citac;
            citac = izvadi_cmd.ExecuteReader();


            while (citac.Read())
            {

                string Vlasnik = citac.GetString(0);

                comboBox1.Items.Add(Vlasnik);
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                var con = PozivBaze.konekcija();
                con.Open();
                string izvadi = "select djelovi from  Servis where Vlasnik = '" + comboBox1.Text + "';";
                SqlCommand izvadi_cmd1 = new SqlCommand(izvadi, con);
                SqlDataReader citac1;
                citac1 = izvadi_cmd1.ExecuteReader();


                while (citac1.Read())
                {

                    textBox1.Text = (citac1["djelovi"].ToString());


                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu otvori = new Menu();
            otvori.Show();
        }
    }
}
