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
    public partial class Novi : Form
    {
        public Novi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = PozivBaze.konekcija();

            con.Open();




            string zadatak = "INSERT INTO Servis(Vlasnik,Marka,Model,Djelovi,Rok)  VALUES('" + this.textBox4.Text + "' ,'" + this.textBox1.Text + "' , ' " + this.textBox2.Text + "' , '" + this.textBox3.Text + "', '" + this.dateTimePicker1.Text + "'  );";
            SqlCommand cmd = new SqlCommand(zadatak, con);

            cmd.ExecuteNonQuery();

            con.Close();

            this.textBox1.Text = " ";
            this.textBox2.Text = " ";
            this.textBox3.Text = " ";
            this.textBox4.Text = " ";

            MessageBox.Show("Servis spremljen!");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu otvori = new Menu();
            this.Hide();
            otvori.Show();
        }
    }
 }

