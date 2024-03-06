using CassandraDataLayer;
using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CassandraWinFormsSample
{
    public partial class NoviOglas : Form
    {
        Prodavac globalniProdavac;
        Oglas noviOglas;
        public NoviOglas()
        {
            InitializeComponent();
        }
        public NoviOglas(Prodavac novi)
        {
            InitializeComponent();
            globalniProdavac = novi;
           
        }


        private void btnDodaj_Click(object sender, EventArgs e)
        {
            noviOglas = new Oglas();
            noviOglas.brojlajkova = 0;
            noviOglas.mestoprodaje = txtMesto.Text;
            noviOglas.prodavacMejl = txtMejl.Text;
            noviOglas.nazivAutomobila = txtMarka.Text;
            noviOglas.modelAutomobila = txtModel.Text;
            noviOglas.tipMotora = txtMotor.Text;
            noviOglas.kubikaza = double.Parse(txtKubikaza.Text);
            noviOglas.godisteAutomobila = Int32.Parse(txtGodiste.Text);
            DataProvider.AddOglas(noviOglas);
            this.Close();
        }
    }
}
