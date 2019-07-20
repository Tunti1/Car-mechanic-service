using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobertTomic
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Novi otvori = new Novi();
            this.Hide();
            otvori.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Narucivanje otvori = new Narucivanje();
            otvori.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Racun otvori = new Racun();
            this.Hide();
            otvori.Show();
        }
    }
}
