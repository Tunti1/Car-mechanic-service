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
    public partial class Racun : Form
    {
        long ukupno;
        public Racun()
        {
            InitializeComponent();
            popuni_combo();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var con = PozivBaze.konekcija();

            con.Open();
            string cijena = textBox5.Text;
            string vrijeme = textBox2.Text;

            string narucivanje = textBox3.Text;


            long cijena_ = long.Parse(cijena);
            long vrijeme_ = long.Parse(vrijeme);

            long narucivanje_ = long.Parse(narucivanje);
            ukupno = (vrijeme_ * cijena_) + narucivanje_;
            textBox6.Text = ukupno.ToString();

            string zadatak = "INSERT INTO Racun(Sati,Cijena_sata,Narucivanje,Sveukupno)  VALUES(" + this.textBox2.Text + " ," + this.textBox3.Text + " ,  " + this.textBox5.Text + " , " + this.textBox6.Text + ");";
            SqlCommand cmd = new SqlCommand(zadatak, con);

            cmd.ExecuteNonQuery();

            

            

            MessageBox.Show("Racun izdan!");
            string brisi= "DELETE  FROM Servis where Vlasnik= '"+comboBox1.Text+"'";
            SqlCommand cmd1 = new SqlCommand(brisi, con);

            cmd1.ExecuteNonQuery();
            con.Close();
            Menu otvori = new Menu();
            otvori.Show();
            this.Hide();
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
            var con = PozivBaze.konekcija();
            con.Open();
            string izvadi = "select Marka,djelovi from  Servis where Vlasnik = '" + comboBox1.Text + "';";
            SqlCommand izvadi_cmd1 = new SqlCommand(izvadi, con);
            SqlDataReader citac1;
            citac1 = izvadi_cmd1.ExecuteReader();


            while (citac1.Read())
            {

                textBox1.Text = (citac1["Marka"].ToString());
                textBox4.Text = (citac1["djelovi"].ToString());

            }
            con.Close();


        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string cijena = (textBox5.Text);
            string vrijeme = (textBox2.Text);
            
            string narucivanje = (textBox3.Text);


            int cijena_ = Convert.ToInt32(cijena);
            int vrijeme_ = Convert.ToInt32(vrijeme);
            
            int narucivanje_ = Convert.ToInt16(narucivanje);
            int ukupno = (vrijeme_*cijena_) + narucivanje_;
            textBox6.Text = ukupno.ToString();

          
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            var con = PozivBaze.konekcija();

            con.Open();
            string cijena = textBox5.Text;
            string vrijeme = textBox2.Text;

            string narucivanje = textBox3.Text;


            long cijena_ = long.Parse(cijena);
            long vrijeme_ = long.Parse(vrijeme);

            long narucivanje_ = long.Parse(narucivanje);
            ukupno = (vrijeme_ * cijena_) + narucivanje_;
            textBox6.Text = ukupno.ToString();
            
        }
    }
}
