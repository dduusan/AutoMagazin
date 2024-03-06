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
    public partial class Pregled : Form
    {

        Prodavac globalniProdavac;
        Kupac globalniKupac;
        List<Oglas> oglasi = new List<Oglas>();
        Boolean KupacBoolean = false;
        public Pregled()
        {
            InitializeComponent();
        }
        public Pregled(Kupac kupac)
        {
            InitializeComponent();
            globalniKupac = kupac;
            KupacBoolean = true;
            this.refreshFunkcija();

            #region visible
            btnDodajOglas.Visible = false;
            btnObrisiOglas.Visible = false;
            btnZahtevi.Visible = false;
            btnLajk.Visible = true;
            btnSvojiZahtevi.Visible = true;
            btnPosaljiZahtev.Visible = true;

            #endregion
        }
        public Pregled(Prodavac prodavac)
        {
            InitializeComponent();
            globalniProdavac = prodavac;
            KupacBoolean = false;
            this.refreshFunkcija();

            #region visible
            btnDodajOglas.Visible = true;
            btnObrisiOglas.Visible = true;
            btnZahtevi.Visible = true;

            btnLajk.Visible = false;
            btnSvojiZahtevi.Visible = false;
            btnPosaljiZahtev.Visible = false;
            #endregion
        }

        public void refreshFunkcija()
        {
            listView1.Clear();
            this.popuniInicijalno();
            if (this.KupacBoolean == true)
                this.popuniZaKupca();
            else this.popuniZaProdavca();
        }
        public void popuniInicijalno()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Naziv oglasa", 90);
            listView1.Columns.Add("Mesto posla", 90);
            listView1.Columns.Add("Email potrazivaca", 100);
            listView1.Columns.Add("Lajkovi", 60);
        }

        private void btnPosaljiZahtev_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                Narudzbina novi = new Narudzbina();
                novi.kupacId = this.globalniKupac.email;
                novi.oglasId = this.listView1.SelectedItems[0].SubItems[0].Text;
                novi.prodavacId = this.listView1.SelectedItems[0].SubItems[2].Text;
                DataProvider.AddNarudzbina(novi);
                this.listView1.SelectedItems[0].BackColor = Color.Green;
                MessageBox.Show("Narudzbina je poslata na oglas " + novi.oglasId + ". Sacekajte potvrdu osobe koja je izdala oglas.");

            }
            else MessageBox.Show("Niste selektovali ni jedan oglas.");
        }

        private void btnZahtevi_Click(object sender, EventArgs e)
        {
            Narudzbine novo = new Narudzbine(globalniProdavac);
            novo.ShowDialog();
            this.refreshFunkcija();
        }

        private void btnSvojiZahtevi_Click(object sender, EventArgs e)
        {
            Narudzbine novo = new Narudzbine(globalniKupac);
            novo.ShowDialog();
            this.refreshFunkcija();
        }

        private void btnDodajOglas_Click(object sender, EventArgs e)
        {
            NoviOglas novi = new NoviOglas(globalniProdavac);
            novi.ShowDialog();
            this.refreshFunkcija();
        }

        private void btnObrisiOglas_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                String imeOglasa = this.listView1.SelectedItems[0].SubItems[0].Text;
                String username = this.listView1.SelectedItems[0].SubItems[2].Text;
                if (imeOglasa != null)
                {
                    DataProvider.DeleteOglas(username, imeOglasa);
                    MessageBox.Show("Obrisan je oglas " + imeOglasa);
                }
                this.refreshFunkcija();
            }
            else MessageBox.Show("Niste selektovali nijedan oglas.");
        }

        private void btnLajk_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                String nazivoglasa = this.listView1.SelectedItems[0].SubItems[0].Text;
                String prodavacMejl = this.listView1.SelectedItems[0].SubItems[2].Text;
                DataProvider.updateLike(prodavacMejl, nazivoglasa);
                this.listView1.SelectedItems[0].BackColor = Color.Aqua;
                this.refreshFunkcija();
            }
            else MessageBox.Show("Niste selektovali nijedan oglas.");
        }



        public void popuniZaKupca()
        {
            oglasi = DataProvider.vratiSveOglase();
            foreach (Oglas oglas in oglasi)
            {
                this.add(oglas.nazivAutomobila, oglas.mestoprodaje, oglas.prodavacMejl.ToString(), oglas.brojlajkova.ToString());

            }
            lblIme.Text = globalniKupac.ime;
            lblPrezime.Text = globalniKupac.prezime;
            lblEmail.Text = "Email: " + globalniKupac.email;


        }


        public void popuniZaProdavca()
        {
            oglasi = DataProvider.vratiSveOglasePrekoMejla(globalniProdavac.email);
            foreach (Oglas oglas in oglasi)
            {

                this.add(oglas.nazivAutomobila, oglas.mestoprodaje, oglas.prodavacMejl.ToString(), oglas.brojlajkova.ToString());
            }
            lblIme.Text = globalniProdavac.ime;
            lblPrezime.Text = globalniProdavac.prezime;
            lblEmail.Text = "Email: " + globalniProdavac.email;

        }
        public void add(string naziv, string mesto, string prodavacMejl, string brojLajkova)
        {
            String[] row = { naziv, mesto, prodavacMejl, brojLajkova };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
