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

    public partial class LogIn : Form
    {

        public Kupac noviKupac;
        public Prodavac noviProdavac;
        public Boolean kupac;
        public LogIn()
        {
            InitializeComponent();
        }
        public LogIn(Kupac k)
        {
            InitializeComponent();
            noviKupac = k;
            kupac = true;
            //lblGodine.Visible = true;
           // txtGodine.Visible = true;
        }
        public LogIn(Prodavac p)
        {
            InitializeComponent();
            noviProdavac = p;
           // lblGodine.Visible = false;
           // txtGodine.Visible = false;
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Email, Sifra;
            Email = txtUsername.Text;
            Sifra = txtPassword.Text;
            if (kupac == true)
            {
                noviKupac = DataProvider.proveriSifruKupca(txtUsername.Text, txtPassword.Text);
                if (noviKupac == null)
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    //forma za radnika
                    Pregled novi = new Pregled(noviKupac);
                    novi.ShowDialog();
                }
            }
            else
            {
                noviProdavac = DataProvider.proveriSifruProdavcu(txtUsername.Text, txtPassword.Text);
                if (noviProdavac == null)
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    //forma za potrazivaca
                    Pregled novi = new Pregled(noviProdavac);
                    novi.ShowDialog();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kupac == true)
            {
                Boolean tacno = DataProvider.emailZaRegistrovanjeKupca(txtNewUsername.Text);
                if (tacno == true)
                {
                    Kupac novi = new Kupac();
                    novi.ime = txtIme.Text;
                    if (radioMusko.Checked == true)
                        novi.pol = "Musko";
                    else novi.pol = "Zensko";
                    novi.prezime = txtPrezime.Text;
                    novi.brojgodina = Int32.Parse(txtGodine.Text);
                    novi.brtelefona = txtTelefon.Text;
                    novi.sifra = txtNewPassword.Text;
                    novi.email = txtNewUsername.Text;
                    noviKupac = novi;
                    DataProvider.AddKupac(noviKupac);
                    //forma za radnika
                    Pregled noviPregled = new Pregled(noviKupac);
                    noviPregled.ShowDialog();
                }
                else
                {
                    txtNewUsername.Text = "";
                    MessageBox.Show("Email vec postoji! Unesite drugi email.");
                }
            }
            else
            {
                Boolean tacno = DataProvider.emailZaRegistrovanjeProdavca(txtNewUsername.Text);
                if (tacno == true)
                {
                    Prodavac novi = new Prodavac();
                    novi.ime = txtIme.Text;
                    if (radioMusko.Checked == true)
                        novi.pol = "Musko";
                    else novi.pol = "Zensko";
                    novi.prezime = txtPrezime.Text;
                    novi.brtelefona = txtTelefon.Text;
                    novi.sifra = txtNewPassword.Text;
                    novi.email = txtNewUsername.Text;
                    noviProdavac = novi;
                    DataProvider.AddProdavac(noviProdavac);
                    //forma za potrazivaca
                    Pregled noviPregled = new Pregled(noviProdavac);
                    noviPregled.ShowDialog();
                }
                else
                {
                    txtNewUsername.Text = "";
                    MessageBox.Show("Email vec postoji! Unesite drugi email.");
                }
            }
        }
    }
}
