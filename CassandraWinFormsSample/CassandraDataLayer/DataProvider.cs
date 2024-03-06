using Cassandra;
using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CassandraDataLayer
{
    public static class DataProvider
    {

        public static Kupac GetKupac(string kupacMejl)
        {
            ISession session = SessionManager.GetSession();
            Kupac kupac = new Kupac();

            if (session == null)
                return null;

            Row kupacData = session.Execute("select * from \"Kupac\" where \"email\"='" + kupacMejl + "'").FirstOrDefault();

            if (kupacData != null)
            {
                kupac.brojgodina = kupacData["brojgodina"] != null ? kupacData["brojgodina"].GetHashCode() : 0;
                kupac.ime = kupacData["ime"] != null ? kupacData["ime"].ToString() : string.Empty;
                kupac.pol = kupacData["pol"] != null ? kupacData["pol"].ToString() : string.Empty;
                kupac.prezime = kupacData["prezime"] != null ? kupacData["prezime"].ToString() : string.Empty;
                kupac.brtelefona = kupacData["brtelefona"] != null ? kupacData["brtelefona"].ToString() : string.Empty;
                kupac.email = kupacData["email"] != null ? kupacData["email"].ToString() : string.Empty;
                kupac.sifra = kupacData["sifra"] != null ? kupacData["sifra"].ToString() : string.Empty;
            }
            return kupac;
        }



        public static Kupac proveriSifruKupca(string emailZaProveru, string sifraZaProveru)
        {
            ISession session = SessionManager.GetSession();
            List<Kupac> kupci = new List<Kupac>();
            Kupac kupacZaVracanje = new Kupac();

            if (session == null)
                return null;

            var kupciData = session.Execute("select * from \"Kupac\" where \"email\"='" + emailZaProveru + "'");


            foreach (var kupacData in kupciData)
            {
                Kupac kupac = new Kupac();
                kupac.brojgodina = kupacData["brojgodina"] != null ? kupacData["brojgodina"].GetHashCode() : 0;
                kupac.ime = kupacData["ime"] != null ? kupacData["ime"].ToString() : string.Empty;
                kupac.pol = kupacData["pol"] != null ? kupacData["pol"].ToString() : string.Empty;
                kupac.prezime = kupacData["prezime"] != null ? kupacData["prezime"].ToString() : string.Empty;
                kupac.brtelefona = kupacData["brtelefona"] != null ? kupacData["brtelefona"].ToString() : string.Empty;
                kupac.email = kupacData["email"] != null ? kupacData["email"].ToString() : string.Empty;
                kupac.sifra = kupacData["sifra"] != null ? kupacData["sifra"].ToString() : string.Empty;
                kupci.Add(kupac);
                if (kupac.email == emailZaProveru)
                {
                    kupacZaVracanje = kupac;
                }
            }
            //Row radnikData = session.Execute("select * from \"Radnik\" where email='"+email+"' and sifra='"+sifra+"'").FirstOrDefault();
            //ovo ne moze jer nas cassandra upozorava!
            if (kupacZaVracanje.email == null)
            {
                MessageBox.Show("Ne postoji takav email.");
                return null;
            }
            else
            {
                if (kupacZaVracanje.sifra != sifraZaProveru)
                {
                    MessageBox.Show("Nije tacna sifra.");
                    return null;
                }
            }

            return kupacZaVracanje;
        }

        public static Boolean emailZaRegistrovanjeKupca(string noviEmail)
        {
            Boolean tacno = true;

            ISession session = SessionManager.GetSession();

            if (session == null)
                return false;

            var kupciData = session.Execute("select * from \"Kupac\"");

            foreach (var kupacData in kupciData)
            {
                Kupac kupac = new Kupac();
                kupac.brojgodina = kupacData["brojgodina"] != null ? kupacData["brojgodina"].GetHashCode() : 0;
                kupac.ime = kupacData["ime"] != null ? kupacData["ime"].ToString() : string.Empty;
                kupac.pol = kupacData["pol"] != null ? kupacData["pol"].ToString() : string.Empty;
                kupac.prezime = kupacData["prezime"] != null ? kupacData["prezime"].ToString() : string.Empty;
                kupac.brtelefona = kupacData["brtelefona"] != null ? kupacData["brtelefona"].ToString() : string.Empty;
                kupac.email = kupacData["email"] != null ? kupacData["email"].ToString() : string.Empty;
                kupac.sifra = kupacData["sifra"] != null ? kupacData["sifra"].ToString() : string.Empty;
                if (kupac.email == noviEmail)
                {
                    tacno = false;
                }
            }

            return tacno;
        }

        public static List<Kupac> GetKupce()
        {
            ISession session = SessionManager.GetSession();
            List<Kupac> kupci = new List<Kupac>();


            if (session == null)
                return null;

            var kupciData = session.Execute("select * from \"Kupac\"");


            foreach (var kupacData in kupciData)
            {
                Kupac kupac = new Kupac();
                kupac.brojgodina = kupacData["brojgodina"] != null ? kupacData["brojgodina"].GetHashCode() : 0;
                kupac.ime = kupacData["ime"] != null ? kupacData["ime"].ToString() : string.Empty;
                kupac.pol = kupacData["pol"] != null ? kupacData["pol"].ToString() : string.Empty;
                kupac.prezime = kupacData["prezime"] != null ? kupacData["prezime"].ToString() : string.Empty;
                kupac.brtelefona = kupacData["brtelefona"] != null ? kupacData["brtelefona"].ToString() : string.Empty;
                kupac.email = kupacData["email"] != null ? kupacData["email"].ToString() : string.Empty;
                kupac.sifra = kupacData["sifra"] != null ? kupacData["sifra"].ToString() : string.Empty;
                kupci.Add(kupac);
            }
            return kupci;
        }



        public static void AddKupac(Kupac novi)
        {
            //string radnikId = generateID();
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;
            RowSet kupacData = session.Execute("insert into \"Kupac\" (\"email\", brojgodina, brtelefona, ime, pol, prezime, sifra)  values ('" + novi.email + "', " + novi.brojgodina + ", '" + novi.brtelefona + "', '" + novi.ime + "', '" + novi.pol + "' , '" + novi.prezime + "', '" + novi.sifra + "')");
            MessageBox.Show("Napravljen je novi nalog s mejlom: " + novi.email + ".");
        }


        public static void DeleteKupac(string kupacMejl)
        {
            ISession session = SessionManager.GetSession();
            Kupac kupac = new Kupac();

            if (session == null)
                return;

            RowSet kupacData = session.Execute("delete from \"Kupac\" where \"email\" = '" + kupacMejl + "'");

        }



        public static Prodavac GetProdavac(string prodavacMejl)
        {
            ISession session = SessionManager.GetSession();
            Prodavac prodavac = new Prodavac();

            if (session == null)
                return null;

            Row prodavacEmailata = session.Execute("select * from \"Prodavac\" where email='" + prodavacMejl + "'").FirstOrDefault();
            if (prodavacEmailata != null)
            {
                prodavac.ime = prodavacEmailata["ime"] != null ? prodavacEmailata["ime"].ToString() : string.Empty;
                prodavac.pol = prodavacEmailata["pol"] != null ? prodavacEmailata["pol"].ToString() : string.Empty;
                prodavac.prezime = prodavacEmailata["prezime"] != null ? prodavacEmailata["prezime"].ToString() : string.Empty;
                prodavac.brtelefona = prodavacEmailata["brtelefona"] != null ? prodavacEmailata["brtelefona"].ToString() : string.Empty;
                prodavac.email = prodavacEmailata["email"] != null ? prodavacEmailata["email"].ToString() : string.Empty;
                prodavac.sifra = prodavacEmailata["sifra"] != null ? prodavacEmailata["sifra"].ToString() : string.Empty;
            }
            return prodavac;
        }


        public static Prodavac proveriSifruProdavcu(string emailZaProveru, string sifraZaProveru)
        {
            ISession session = SessionManager.GetSession();

            Prodavac prodavacZaVracanje = new Prodavac();

            if (session == null)
                return null;

            var prodavacEmailata = session.Execute("select * from \"Prodavac\" where \"email\"='" + emailZaProveru + "' and sifra='" + sifraZaProveru + "'ALLOW FILTERING");


            foreach (var potrazivacData in prodavacEmailata)
            {
                Prodavac prodavac = new Prodavac();
                prodavac.email = potrazivacData["email"] != null ? potrazivacData["email"].ToString() : string.Empty;
                prodavac.ime = potrazivacData["ime"] != null ? potrazivacData["ime"].ToString() : string.Empty;
                prodavac.pol = potrazivacData["pol"] != null ? potrazivacData["pol"].ToString() : string.Empty;
                prodavac.prezime = potrazivacData["prezime"] != null ? potrazivacData["prezime"].ToString() : string.Empty;
                prodavac.brtelefona = potrazivacData["brtelefona"] != null ? potrazivacData["brtelefona"].ToString() : string.Empty;
                prodavac.sifra = potrazivacData["sifra"] != null ? potrazivacData["sifra"].ToString() : string.Empty;
                prodavacZaVracanje = prodavac;
            }
            if (prodavacZaVracanje.email == null)
            {
                MessageBox.Show("Uneti mejl nije pronadjen!");
                return null;
            }

            if (prodavacZaVracanje.sifra != sifraZaProveru)
            {
                MessageBox.Show("Pogresna sifra!");
                return null;
            }
            return prodavacZaVracanje;
        }


        public static Boolean emailZaRegistrovanjeProdavca(string noviEmail)
        {
            Boolean tacno = true;

            ISession session = SessionManager.GetSession();

            if (session == null)
                return false;

            var prodavacEmailata = session.Execute("select * from \"Prodavac\"");


            foreach (var prodavacData in prodavacEmailata)
            {
                Prodavac prodavac = new Prodavac();
                prodavac.ime = prodavacData["ime"] != null ? prodavacData["ime"].ToString() : string.Empty;
                prodavac.pol = prodavacData["pol"] != null ? prodavacData["pol"].ToString() : string.Empty;
                prodavac.prezime = prodavacData["prezime"] != null ? prodavacData["prezime"].ToString() : string.Empty;
                prodavac.brtelefona = prodavacData["brtelefona"] != null ? prodavacData["brtelefona"].ToString() : string.Empty;
                prodavac.email = prodavacData["email"] != null ? prodavacData["email"].ToString() : string.Empty;
                prodavac.sifra = prodavacData["sifra"] != null ? prodavacData["sifra"].ToString() : string.Empty;
                if (prodavac.email == noviEmail)
                {
                    tacno = false;
                }
            }

            return tacno;
        }


        public static List<Prodavac> GetProdavce()
        {
            ISession session = SessionManager.GetSession();
            List<Prodavac> prodavci = new List<Prodavac>();

            if (session == null)
                return null;

            var prodavacEmailata = session.Execute("select * from \"Prodavac\"");

            foreach (var prodavacData in prodavacEmailata)
            {
                Prodavac prodavac = new Prodavac();
                prodavac.ime = prodavacData["ime"] != null ? prodavacData["ime"].ToString() : string.Empty;
                prodavac.pol = prodavacData["pol"] != null ? prodavacData["pol"].ToString() : string.Empty;
                prodavac.prezime = prodavacData["prezime"] != null ? prodavacData["prezime"].ToString() : string.Empty;
                prodavac.brtelefona = prodavacData["brtelefona"] != null ? prodavacData["brtelefona"].ToString() : string.Empty;
                prodavac.email = prodavacData["email"] != null ? prodavacData["email"].ToString() : string.Empty;
                prodavac.sifra = prodavacData["sifra"] != null ? prodavacData["sifra"].ToString() : string.Empty;
                prodavci.Add(prodavac);
            }
            return prodavci;
        }

        public static void AddProdavac(Prodavac novi)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet prodavacData = session.Execute("insert into \"Prodavac\" (\"email\", brtelefona, ime, pol, prezime, sifra)  values ('" + novi.email + "', '" + novi.brtelefona + "', '" + novi.ime + "', '" + novi.pol + "' , '" + novi.prezime + "', '" + novi.sifra + "')");
            MessageBox.Show("Napravljen je novi nalog " + novi.email + ".");
        }

        public static void DeletePotrazivac(string email)
        {
            ISession session = SessionManager.GetSession();
            Prodavac prodavac = new Prodavac();

            if (session == null)
                return;

            RowSet prodavacData = session.Execute("delete from \"Prodavac\" where \"email\" = '" + email + "'");
        }

        public static void AddOglas(Oglas oglas)
        {
            //string oglasId = generateID();
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;
            //  MessageBox.Show("Napravljen je novi nalog " + oglas.nazivAutomobila + "," + oglas.prodavacMejl + "," + oglas.brojlajkova + "," + oglas.godisteAutomobila + "," + oglas.kubikaza + "," + oglas.mestoprodaje + "," + oglas.modelAutomobila + "," + oglas.tipMotora);
            //RowSet oglasData = session.Execute("insert into \"Oglas\" (\"nazivAutomobila\", \"prodavacMejl\", brojlajkova, godisteautomobila, kubikaza, mestoprodaje, modelautomobila, tipmotora) values ('" + oglas.nazivAutomobila + "', '" + oglas.prodavacMejl + "', 0, " + oglas.godisteAutomobila + ", " + oglas.kubikaza + ", '" + oglas.mestoprodaje + "','" + oglas.modelAutomobila + "', '" + oglas.tipMotora + "' )");
            RowSet oglasData = session.Execute("insert into \"Oglas\" (\"nazivAutomobila\", \"prodavacMejl\", mestoprodaje, modelautomobila, godisteautomobila, tipMotora, kubikaza, brojlajkova ) values ('" + oglas.nazivAutomobila + "', '" + oglas.prodavacMejl + "','" + oglas.mestoprodaje + "','" + oglas.modelAutomobila + "'," + oglas.godisteAutomobila + ",'" + oglas.tipMotora + "' , " + oglas.kubikaza + ", 0)");

        }

        public static List<Oglas> vratiSveOglasePrekoMejla(string prodavacMejl)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return null;


            List<Oglas> oglasi = new List<Oglas>();
            var oglasiData = session.Execute("select * from \"Oglas\" where \"prodavacMejl\"='" + prodavacMejl + "'ALLOW FILTERING");

            foreach (var oglasData in oglasiData)
            {
                Oglas oglas = new Oglas();
                oglas.nazivAutomobila = oglasData["nazivAutomobila"] != null ? oglasData["nazivAutomobila"].ToString() : string.Empty;
                oglas.mestoprodaje = oglasData["mestoprodaje"] != null ? oglasData["mestoprodaje"].ToString() : string.Empty;
                oglas.prodavacMejl = oglasData["prodavacMejl"] != null ? oglasData["prodavacMejl"].ToString() : string.Empty;
                oglas.modelAutomobila = oglasData["modelautomobila"] != null ? oglasData["modelautomobila"].ToString() : string.Empty;
                oglas.godisteAutomobila = oglasData["godisteautomobila"] != null ? oglasData["godisteautomobila"].GetHashCode() : 0;
                oglas.tipMotora = oglasData["tipmotora"] != null ? oglasData["tipmotora"].ToString() : string.Empty;
                oglas.kubikaza = oglasData["kubikaza"] != null ? oglasData["kubikaza"].GetHashCode() : 0;
                oglas.brojlajkova = oglasData["brojlajkova"] != null ? oglasData["brojlajkova"].GetHashCode() : 0;
                oglasi.Add(oglas);
            }
            return oglasi;
        }


        public static List<Oglas> vratiSveOglase()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return null;


            List<Oglas> oglasi = new List<Oglas>();
            var oglasiData = session.Execute("select * from \"Oglas\"");

            foreach (var oglasData in oglasiData)
            {
                Oglas oglas = new Oglas();
                oglas.nazivAutomobila = oglasData["nazivAutomobila"] != null ? oglasData["nazivAutomobila"].ToString() : string.Empty;
                oglas.mestoprodaje = oglasData["mestoprodaje"] != null ? oglasData["mestoprodaje"].ToString() : string.Empty;
                oglas.prodavacMejl = oglasData["prodavacMejl"] != null ? oglasData["prodavacMejl"].ToString() : string.Empty;
                oglas.modelAutomobila = oglasData["modelautomobila"] != null ? oglasData["modelautomobila"].ToString() : string.Empty;
                oglas.godisteAutomobila = oglasData["godisteautomobila"] != null ? oglasData["godisteautomobila"].GetHashCode() : 0;
                oglas.tipMotora = oglasData["tipmotora"] != null ? oglasData["tipmotora"].ToString() : string.Empty;
                oglas.kubikaza = oglasData["kubikaza"] != null ? oglasData["kubikaza"].GetHashCode() : 0;
                oglas.brojlajkova = oglasData["brojlajkova"] != null ? oglasData["brojlajkova"].GetHashCode() : 0;
                oglasi.Add(oglas);
            }
            return oglasi;
        }

        public static void DeleteOglas(string prodavacMejl, string imeOglasa)
        {
            ISession session = SessionManager.GetSession();
            Oglas oglas = new Oglas();

            if (session == null)
                return;

            RowSet oglasData = session.Execute("delete from \"Oglas\" where \"prodavacMejl\" = '" + prodavacMejl + "' and \"nazivAutomobila\"='" + imeOglasa + "'");

        }



        public static Oglas GetOglas(string prodavacId, string naziv)
        {
            ISession session = SessionManager.GetSession();
            Oglas oglas = new Oglas();

            if (session == null)
                return null;

            Row oglasData = session.Execute("select * from \"Oglas\" where \"prodavacMejl\"='" + prodavacId + "' and \"nazivAutomobila\"='" + naziv + "'").FirstOrDefault();

            if (oglasData != null)
            {
                oglas.nazivAutomobila = oglasData["nazivAutomobila"] != null ? oglasData["nazivAutomobila"].ToString() : string.Empty;
                oglas.mestoprodaje = oglasData["mestoprodaje"] != null ? oglasData["mestoprodaje"].ToString() : string.Empty;
                oglas.prodavacMejl = oglasData["prodavacMejl"] != null ? oglasData["prodavacMejl"].ToString() : string.Empty;
                oglas.modelAutomobila = oglasData["modelautomobila"] != null ? oglasData["modelautomobila"].ToString() : string.Empty;
                oglas.godisteAutomobila = oglasData["godisteautomobila"] != null ? oglasData["godisteautomobila"].GetHashCode() : 0;
                oglas.tipMotora = oglasData["tipmotora"] != null ? oglasData["tipmotora"].ToString() : string.Empty;
                oglas.kubikaza = oglasData["kubikaza"] != null ? oglasData["kubikaza"].GetHashCode() : 0;
                oglas.brojlajkova = oglasData["brojlajkova"] != null ? oglasData["brojlajkova"].GetHashCode() : 0;
            }
            return oglas;
        }

        public static void updateLike(string prodavacId, string naziv)
        {
            Oglas oglas = GetOglas(prodavacId, naziv);

            ISession session = SessionManager.GetSession();

            if (session == null)
                return;
            oglas.brojlajkova += 1;
            RowSet likeUpdateData = session.Execute("update \"Oglas\" set brojlajkova=" + oglas.brojlajkova
                + " where \"prodavacMejl\"='" + oglas.prodavacMejl + "' and \"nazivAutomobila\"='" + oglas.nazivAutomobila + "' ");
        }

        public static string generateID()
        {
            return Guid.NewGuid().ToString("N"); // ZASTO N??????
        }
        public static void AddNarudzbina(Narudzbina narudzbina)
        {
            narudzbina.narudzbinaId = generateID();
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet zahtevData = session.Execute("insert into \"Narudzbina\" (\"narudzbinaId\", \"prodavacId\", \"kupacId\",  \"oglasId\",  odobrena)  values ('" + narudzbina.narudzbinaId + "', '" + narudzbina.prodavacId + "', '" + narudzbina.kupacId + "', '" + narudzbina.oglasId + "', 0)");
        }

        public static List<Narudzbina> vratiNarudzbineZaIzabranogProdavca(string username)
        {
            ISession session = SessionManager.GetSession();
            List<Narudzbina> narudzbine = new List<Narudzbina>();

            if (session == null)
                return null;

            var narudzbineData = session.Execute("select * from \"Narudzbina\" where \"prodavacId\"='" + username + "'ALLOW FILTERING");

            foreach (var narudzbinaData in narudzbineData)
            {
                Narudzbina narudzbina = new Narudzbina();
                narudzbina.prodavacId = narudzbinaData["prodavacId"] != null ? narudzbinaData["prodavacId"].ToString() : string.Empty;
                narudzbina.oglasId = narudzbinaData["oglasId"] != null ? narudzbinaData["oglasId"].ToString() : string.Empty;
                narudzbina.kupacId = narudzbinaData["kupacId"] != null ? narudzbinaData["kupacId"].ToString() : string.Empty;
                narudzbina.narudzbinaId = narudzbinaData["narudzbinaId"] != null ? narudzbinaData["narudzbinaId"].ToString() : string.Empty;
                narudzbina.odobrena = narudzbinaData["odobrena"] != null ? narudzbinaData["odobrena"].GetHashCode() : 0;
                narudzbine.Add(narudzbina);
            }
            return narudzbine;
        }

        public static List<Narudzbina> vratiNarudzbineZaIzabranogKupca(string username)
        {
            ISession session = SessionManager.GetSession();
            List<Narudzbina> narudzbine = new List<Narudzbina>();

            if (session == null)
                return null;

            var narudzbineData = session.Execute("select * from \"Narudzbina\"");

            foreach (var narudzbinaData in narudzbineData)
            {
                Narudzbina narudzbina = new Narudzbina();
                narudzbina.prodavacId = narudzbinaData["prodavacId"] != null ? narudzbinaData["prodavacId"].ToString() : string.Empty;
                narudzbina.oglasId = narudzbinaData["oglasId"] != null ? narudzbinaData["oglasId"].ToString() : string.Empty;
                narudzbina.kupacId = narudzbinaData["kupacId"] != null ? narudzbinaData["kupacId"].ToString() : string.Empty;
                narudzbina.narudzbinaId = narudzbinaData["narudzbinaId"] != null ? narudzbinaData["narudzbinaId"].ToString() : string.Empty;
                narudzbina.odobrena = narudzbinaData["odobrena"] != null ? narudzbinaData["odobrena"].GetHashCode() : 0;
                if (narudzbina.kupacId == username)
                {
                    narudzbine.Add(narudzbina);
                }
            }
            return narudzbine;
        }

        public static void updateNarudzbinu(Narudzbina narudzbina)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet zahtevUpdateData = session.Execute("update \"Narudzbina\" set odobrena=" + narudzbina.odobrena + " where \"prodavacId\"='" + narudzbina.prodavacId + "' and \"oglasId\" = '" + narudzbina.oglasId + "' and \"narudzbinaId\"='" + narudzbina.narudzbinaId + "' and \"kupacId\"='" + narudzbina.kupacId + "'");
        }

        public static void DeleteNarudzbinu(string prodavacId, string narudzbinaId)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet narudzbinaData = session.Execute("delete from \"Narudzbina\" where \"prodavacId\"='" + prodavacId + "' and \"narudzbinaId\" = '" + narudzbinaId + "'");
        }


    }
}
/*#region Hotel
public static Hotel GetHotel(string hotelID)
{
    ISession session = SessionManager.GetSession();
    Hotel hotel = new Hotel();

    if (session == null)
        return null;

    Row hotelData = session.Execute("select * from \"Hotel\" where \"hotelID\"='1'").FirstOrDefault();

    if(hotelData != null)
    {
        hotel.hotelID = hotelData["hotelID"] != null ? hotelData["hotelID"].ToString() : string.Empty;
        hotel.name = hotelData["name"] != null ? hotelData["name"].ToString() : string.Empty;
        hotel.address = hotelData["address"] != null ? hotelData["address"].ToString() : string.Empty;
        hotel.city = hotelData["city"] != null ? hotelData["city"].ToString() : string.Empty;
        hotel.phone = hotelData["phone"] != null ? hotelData["phone"].ToString() : string.Empty;
        hotel.state = hotelData["state"] != null ? hotelData["state"].ToString() : string.Empty;
        hotel.zip = hotelData["zip"] != null ? hotelData["zip"].ToString() : string.Empty;
    }

    return hotel;
}

public static List<Hotel> GetHotels()
{
    ISession session = SessionManager.GetSession();
    List<Hotel> hotels = new List<Hotel>();


    if (session == null)
        return null;

    var hotelsData = session.Execute("select * from \"Hotel\"");


    foreach(var hotelData in hotelsData)
    {
        Hotel hotel = new Hotel();
        hotel.hotelID = hotelData["hotelID"] != null ? hotelData["hotelID"].ToString() : string.Empty;
        hotel.name = hotelData["name"] != null ? hotelData["name"].ToString() : string.Empty;
        hotel.address = hotelData["address"] != null ? hotelData["address"].ToString() : string.Empty;
        hotel.city = hotelData["city"] != null ? hotelData["city"].ToString() : string.Empty;
        hotel.phone = hotelData["phone"] != null ? hotelData["phone"].ToString() : string.Empty;
        hotel.state = hotelData["state"] != null ? hotelData["state"].ToString() : string.Empty;
        hotel.zip = hotelData["zip"] != null ? hotelData["zip"].ToString() : string.Empty;
        hotels.Add(hotel);
    }



    return hotels;
}

public static void AddHotel(string hotelID)
{
    ISession session = SessionManager.GetSession();

    if (session == null)
        return;

    RowSet hotelData = session.Execute("insert into \"Hotel\" (\"hotelID\", address, city, name, phone, state, zip)  values ('" + hotelID +"', 'Vozda Karadjordja 12', 'Nis', 'Grand', '123', 'Srbija', '18000')");

}

public static void DeleteHotel(string hotelID)
{
    ISession session = SessionManager.GetSession();
    Hotel hotel = new Hotel();

    if (session == null)
        return;

    RowSet hotelData = session.Execute("delete from \"Hotel\" where \"hotelID\" = '" + hotelID + "'");

}

#endregion

#region Room

public static Room GetRoom(string hotelID, string roomID)
{
    ISession session = SessionManager.GetSession();
    Room room = new Room();

    if (session == null)
        return null;

    Row roomData = session.Execute("select * from \"Room\" where \"hotelID\"='" + hotelID +"' and \"roomID\"='" + roomID + "'").FirstOrDefault();

    if (roomData != null)
    {
        room.hotelID = roomData["hotelID"] != null ? roomData["hotelID"].ToString() : string.Empty;
        room.roomID = roomData["roomID"] != null ? roomData["roomID"].ToString() : string.Empty;
        room.hottub = roomData["hottub"] != null ? roomData["hottub"].ToString() : string.Empty;
        room.num = roomData["num"] != null ? roomData["num"].ToString() : string.Empty;
        room.rate = roomData["rate"] != null ? roomData["rate"].ToString() : string.Empty;
        room.tv = roomData["tv"] != null ? roomData["tv"].ToString() : string.Empty;
        room.type = roomData["type"] != null ? roomData["type"].ToString() : string.Empty;
    }

    return room;
}

public static List<Room> GetRooms()
{
    ISession session = SessionManager.GetSession();
    List<Room> rooms = new List<Room>();

    if (session == null)
        return null;

    var roomsData = session.Execute("select * from \"Room\"");

    foreach(var row in roomsData)
    {
        Room room = new Room();
        room.hotelID = row["hotelID"] != null ? row["hotelID"].ToString() : string.Empty;
        room.roomID = row["roomID"] != null ? row["roomID"].ToString() : string.Empty;
        room.hottub = row["hottub"] != null ? row["hottub"].ToString() : string.Empty;
        room.num = row["num"] != null ? row["num"].ToString() : string.Empty;
        room.rate = row["rate"] != null ? row["rate"].ToString() : string.Empty;
        room.tv = row["tv"] != null ? row["tv"].ToString() : string.Empty;
        room.type = row["type"] != null ? row["type"].ToString() : string.Empty;

        rooms.Add(room);
    }

    return rooms;
}

public static void AddRoom(string hotelID, string roomID)
{
    ISession session = SessionManager.GetSession();

    if (session == null)
        return;

    RowSet roomData = session.Execute("insert into \"Room\"(\"hotelID\",\"roomID\", hottub, num, rate, tv, \"type\") values ('" + hotelID + "', '" + roomID + "', 'yes', '101', '25', 'yes', 'appartment')");

}

public static void DeleteRoom(string hotelID, string roomID)
{
    ISession session = SessionManager.GetSession();

    if (session == null)
        return;

    RowSet roomData = session.Execute("delete from \"Room\" where \"hotelID\" = '" + hotelID + "' and \"roomID\" = '" + roomID + "'");

}

#endregion

#region Geust

public static Guest GetGuest(string phone)
{
    ISession session = SessionManager.GetSession();
    Guest guest = new Guest();

    if (session == null)
        return null;

    Row guestData = session.Execute("select * from \"Guest\" where phone='" + phone + "'").FirstOrDefault();

    if (guestData != null)
    {
        guest.phone = guestData["phone"] != null ? guestData["phone"].ToString() : string.Empty;
        guest.email = guestData["email"] != null ? guestData["email"].ToString() : string.Empty;
        guest.fname = guestData["fname"] != null ? guestData["fname"].ToString() : string.Empty;
        guest.lname = guestData["lname"] != null ? guestData["lname"].ToString() : string.Empty;
    }

    return guest;
}

public static List<Guest> GetGuests()
{
    ISession session = SessionManager.GetSession();
    List<Guest> guests = new List<Guest>();

    if (session == null)
        return null;

    var guestsData = session.Execute("select * from \"Guest\"");


    foreach (var guestData in guestsData)
    {
        Guest guest = new Guest();
        guest.phone = guestData["phone"] != null ? guestData["phone"].ToString() : string.Empty;
        guest.email = guestData["email"] != null ? guestData["email"].ToString() : string.Empty;
        guest.fname = guestData["fname"] != null ? guestData["fname"].ToString() : string.Empty;
        guest.lname = guestData["lname"] != null ? guestData["lname"].ToString() : string.Empty;

        guests.Add(guest);
    }


    return guests;
}

public static void AddGuest(string phone)
{
    ISession session = SessionManager.GetSession();

    if (session == null)
        return;

    RowSet guestData = session.Execute("insert into \"Guest\"(phone, email, fname, lname) values ('" + phone + "', 'email@email.com', 'test', 'test')");

}

public static void DeleteGuest(string phone)
{
    ISession session = SessionManager.GetSession();

    if (session == null)
        return;

    RowSet guestData = session.Execute("delete from \"Guest\" where phone = '" + phone + "'");

}

#endregion

#region Reservation

public static Reservation GetReservation(string resID)
{
    ISession session = SessionManager.GetSession();
    Reservation reservation = new Reservation();

    if (session == null)
        return null;

    Row reservationData = session.Execute("select * from \"Reservation\" where \"resID\"='" + resID +"'").FirstOrDefault();

    if (reservationData != null)
    {
        reservation.hotelID = reservationData["hotelID"] != null ? reservationData["hotelID"].ToString() : string.Empty;
        reservation.roomID = reservationData["roomID"] != null ? reservationData["roomID"].ToString() : string.Empty;
        reservation.resID = reservationData["resID"] != null ? reservationData["resID"].ToString() : string.Empty;
        reservation.arrive = reservationData["arrive"] != null ? reservationData["arrive"].ToString() : string.Empty;
        reservation.depart = reservationData["depart"] != null ? reservationData["depart"].ToString() : string.Empty;
        reservation.name = reservationData["name"] != null ? reservationData["name"].ToString() : string.Empty;
        reservation.phone = reservationData["phone"] != null ? reservationData["phone"].ToString() : string.Empty;
        reservation.rate = reservationData["rate"] != null ? reservationData["rate"].ToString() : string.Empty;
    }

    return reservation;
}

public static List<Reservation> GetReservations()
{
    ISession session = SessionManager.GetSession();
    List<Reservation> reservations = new List<Reservation>();

    if (session == null)
        return null;

    var reservationsData = session.Execute("select * from \"Reservation\"");


    foreach (Row reservationData in reservationsData)
    {
        Reservation reservation = new Reservation();
        reservation.hotelID = reservationData["hotelID"] != null ? reservationData["hotelID"].ToString() : string.Empty;
        reservation.roomID = reservationData["roomID"] != null ? reservationData["roomID"].ToString() : string.Empty;
        reservation.resID = reservationData["resID"] != null ? reservationData["resID"].ToString() : string.Empty;
        reservation.arrive = reservationData["arrive"] != null ? reservationData["arrive"].ToString() : string.Empty;
        reservation.depart = reservationData["depart"] != null ? reservationData["depart"].ToString() : string.Empty;
        reservation.name = reservationData["name"] != null ? reservationData["name"].ToString() : string.Empty;
        reservation.phone = reservationData["phone"] != null ? reservationData["phone"].ToString() : string.Empty;
        reservation.rate = reservationData["rate"] != null ? reservationData["rate"].ToString() : string.Empty;

        reservations.Add(reservation);
    }


    return reservations;
}

public static void AddReservation(string resID)
{
    ISession session = SessionManager.GetSession();

    if (session == null)
        return;

    RowSet reservationData = session.Execute("insert into \"Reservation\"(\"resID\", \"hotelID\",\"roomID\", arrive, depart, name, phone, rate) values ('" + resID + "', '1', '101', 'date', 'date', 'test', '018181818', '25')");

}

public static void DeleteReservation(string resID)
{
    ISession session = SessionManager.GetSession();

    if (session == null)
        return;

    RowSet reservationData = session.Execute("delete from \"Reservation\" where \"resID\" = '" + resID + "'");

}

#endregion

}
*/

