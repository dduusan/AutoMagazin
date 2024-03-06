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
    public partial class Narudzbine : Form
    {
        List<Narudzbina> narudzbine = new List<Narudzbina>();
        Kupac globalniKupac;
        Prodavac globalniProdavac;
        public Narudzbine()
        {
            InitializeComponent();
            popuniInicijalno();
        }
        public Narudzbine(Prodavac novi)
        {
            InitializeComponent();
            popuniInicijalno();
            globalniProdavac = novi;
            narudzbine = DataProvider.vratiNarudzbineZaIzabranogProdavca(globalniProdavac.email);
            foreach (Narudzbina narudzbina in narudzbine)
            {
                Kupac kupac = new Kupac();
                kupac = DataProvider.GetKupac(narudzbina.kupacId); //radnikId je zapravo email za radnika
                Oglas oglas = new Oglas();
                oglas = DataProvider.GetOglas(novi.email, narudzbina.oglasId);
                this.add(kupac.ime, kupac.prezime, kupac.email, oglas.nazivAutomobila, oglas.mestoprodaje, novi.email, narudzbina.narudzbinaId, narudzbina.odobrena);
            }
            //naziv oglasa je zapravo id od oglasa,tj clustering key

            #region potrazivac deo
            btnPrihvati.Visible = true;
            btnOdbij.Visible = true;
            btnObrisi.Visible = false;
            #endregion
        }

        public Narudzbine(Kupac novi)
        {
            InitializeComponent();
            popuniInicijalno();
            globalniKupac = novi;
            //ovo popravi
            narudzbine = DataProvider.vratiNarudzbineZaIzabranogKupca(globalniKupac.email);
            foreach (Narudzbina narudzbina in narudzbine)
            {
                Prodavac noviProdavac = new Prodavac();
                noviProdavac = DataProvider.GetProdavac(narudzbina.prodavacId);
                Oglas oglas = new Oglas();
                oglas = DataProvider.GetOglas(noviProdavac.email, narudzbina.oglasId);
                this.add(globalniKupac.ime, globalniKupac.prezime, globalniKupac.email, oglas.nazivAutomobila, oglas.mestoprodaje, noviProdavac.email, narudzbina.narudzbinaId, narudzbina.odobrena);
            }
            //naziv oglasa je zapravo id od oglasa,tj clustering key

            #region radnik deo
            btnPrihvati.Visible = false;
            btnOdbij.Visible = false;
            btnObrisi.Visible = true;
            #endregion
        }


        public void popuniInicijalno()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Ime kupca", 90);
            listView1.Columns.Add("Prezime kupca", 90);
            listView1.Columns.Add("Email Kupca", 100); //radnikId kolona
            listView1.Columns.Add("Naziv oglasa", 110); //oglasId
            listView1.Columns.Add("Mesto oglasa", 110);
            listView1.Columns.Add("Email prodavca", 100); //potrazivacId
            listView1.Columns.Add("Id Narudzbine", 10); //zahtevId
        }


        public void add(string ime, string prezime, string emailKupca, string nazivOglasa, string mestoPosla, string emailProdavca, string idNarudzbine, int odobren)
        {
            String[] row = { ime, prezime, emailKupca, nazivOglasa, mestoPosla, emailProdavca, idNarudzbine };
            ListViewItem item = new ListViewItem(row);
            if (odobren == 1)
                item.BackColor = Color.Green;
            if (odobren == 2)
                item.BackColor = Color.DarkRed;
            listView1.Items.Add(item);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                String kupacId = this.listView1.SelectedItems[0].SubItems[2].Text;
                String oglasId = this.listView1.SelectedItems[0].SubItems[3].Text;
                String prodavacId = this.listView1.SelectedItems[0].SubItems[5].Text;
                String narudzbinaId = this.listView1.SelectedItems[0].SubItems[6].Text;
                Narudzbina odobrenaNarudzbina = new Narudzbina();
                odobrenaNarudzbina.oglasId = oglasId;
                odobrenaNarudzbina.narudzbinaId = narudzbinaId;
                odobrenaNarudzbina.prodavacId = prodavacId;
                odobrenaNarudzbina.kupacId = kupacId;
                odobrenaNarudzbina.odobrena = 1;
                DataProvider.updateNarudzbinu(odobrenaNarudzbina);
                this.listView1.SelectedItems[0].BackColor = Color.LightBlue;
                MessageBox.Show("Narudzbina prihvacena!");
            }
            else MessageBox.Show("Niste selektovali nijedan zahtev.");
        }

        private void btnOdbij_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
            String kupacId = this.listView1.SelectedItems[0].SubItems[2].Text;
            String oglasId = this.listView1.SelectedItems[0].SubItems[3].Text;
            String prodavacId = this.listView1.SelectedItems[0].SubItems[5].Text;
            String narudzbinaId = this.listView1.SelectedItems[0].SubItems[6].Text;
            Narudzbina odobrenaNarudzbina = new Narudzbina();
            odobrenaNarudzbina.oglasId = oglasId;
            odobrenaNarudzbina.narudzbinaId = narudzbinaId;
            odobrenaNarudzbina.prodavacId = prodavacId;
            odobrenaNarudzbina.kupacId = kupacId;
            odobrenaNarudzbina.odobrena = 2;
            DataProvider.updateNarudzbinu(odobrenaNarudzbina);
            this.listView1.SelectedItems[0].BackColor = Color.LightBlue;
            MessageBox.Show("Narudzbina odbijena!");
        }
            else MessageBox.Show("Niste selektovali nijedan zahtev.");
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                String oglasId = this.listView1.SelectedItems[0].SubItems[3].Text;
                String prodavacId = this.listView1.SelectedItems[0].SubItems[5].Text;
                DataProvider.DeleteNarudzbinu(prodavacId, oglasId);
                this.listView1.SelectedItems[0].Remove();
                MessageBox.Show("Narudzbina je obrisana!");
            }
            else MessageBox.Show("Niste selektovali nijedan zahtev.");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

