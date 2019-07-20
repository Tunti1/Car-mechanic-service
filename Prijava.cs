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
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registracija otvori = new Registracija();
            otvori.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = PozivBaze.konekcija();
            con.Open();
            SqlDataAdapter prijava = new SqlDataAdapter("select count(*) from Korisnik where korisnicko_ime='" + textBox1.Text + "'and lozinka = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            prijava.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Menu otvori = new Menu();
                this.Hide();
                otvori.Show();

            }
            else MessageBox.Show("Pogresno korisnicko ime ili lozinka");
        }
    }
}
