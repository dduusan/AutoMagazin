using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CassandraDataLayer.QueryEntities;

namespace CassandraWinFormsSample
{
    public partial class FormaZaOdabir : Form
    {

        public Kupac noviKupac;
        public Prodavac noviProdavac;
        public FormaZaOdabir()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            noviProdavac = new Prodavac();
            LogIn logovanje = new LogIn(noviProdavac);
            logovanje.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            noviKupac = new Kupac();
            LogIn logovanje = new LogIn(noviKupac);
            logovanje.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
