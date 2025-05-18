using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace hastane_randevu_sistemi_alperensaricayir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider= Microsoft.Ace.OleDb.12.0; Data Source= branslar-doktorlar-randevular.accdb");

        void randevulartablosunakaydet()
        {

            OleDbCommand komut2 = new OleDbCommand("INSERT INTO Randevular(hastaAdi, hastaSoyadi, tarih, saat, [randevu-alis-saati], bransID, secilenDoktorAdiSoyadi) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7)", baglan);
            //bransID, doktorID,
            komut2.Parameters.AddWithValue("@P1", textBox1.Text);
            komut2.Parameters.AddWithValue("@P2", textBox2.Text);
            komut2.Parameters.AddWithValue("@P3", dateTimePicker1.Value.ToString());
            komut2.Parameters.AddWithValue("@P4", comboBox3.SelectedItem.ToString()); //?comboBox1.SelectedIndex.Value.ToString()?
            komut2.Parameters.AddWithValue("@P5", DateTime.Now.ToString()); //?DateTime.Now.AddHours?
            komut2.Parameters.AddWithValue("@P6", secilibransid);
            komut2.Parameters.AddWithValue("@P7", comboBox2.SelectedItem.ToString());

            baglan.Open();
            komut2.ExecuteNonQuery();
            baglan.Close();
        }

        void doktorlartablosunuguncelle()
        {
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SELECT * FROM Doktorlar", baglan);
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);
            dataGridView2.DataSource = tablo;
        }

        void randevulartablosunuguncelle()
        {
            DataTable tablo2 = new DataTable();
            OleDbDataAdapter adaptor2 = new OleDbDataAdapter("SELECT * FROM Randevular", baglan);
            adaptor2.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
        }

        void branslartablosunuguncelle()
        {
            DataTable tablo3 = new DataTable();
            OleDbDataAdapter adaptor3 = new OleDbDataAdapter("SELECT * FROM Branslar", baglan);
            adaptor3.Fill(tablo3);
            dataGridView3.DataSource = tablo3;
        }

        void branslariokuvecombobox1ecek()
        {
            //int branssayisi = 7;
            //string[] branslar = new string[7];
            //OleDbDataAdapter adaptor3 = new OleDbDataAdapter("SELECT * FROM Branslar", baglan);
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("SELECT bransAdi FROM Branslar", baglan);
            
            OleDbDataReader okuyucu = komut.ExecuteReader();
            
            while (okuyucu.Read())
            {
                string bransismi = okuyucu["bransAdi"].ToString();
                comboBox1.Items.Add(bransismi);
            }
            okuyucu.Close();
            baglan.Close();

        }

        DateTime varsayilantarihdegeri;
        bool tarihdegistimi;
        
        //bool branssecildimi;

        private void Form1_Load(object sender, EventArgs e)
        {
            varsayilantarihdegeri = dateTimePicker1.Value;

            //comboBox1.Items.AddRange(); //uygulama açıldığında combobox1'e branşlar tablosundan branşlar gelsin
            
            string[] saatler = File.ReadAllLines("saatler.txt");
            comboBox3.Items.AddRange(saatler);

            doktorlartablosunuguncelle();
            randevulartablosunuguncelle();
            branslartablosunuguncelle();
            branslariokuvecombobox1ecek();





            //if (branssecildimi)
            //{
            //    if (comboBox1.SelectedIndex == 0)
            //    {
            //        baglan.Open();
            //        OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //        OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //        while (okuyucu2.Read())
            //        {
            //            string doktor = okuyucu2[""].ToString();
            //            comboBox2.Items.Add(doktor);
            //        }
            //        okuyucu2.Close();
            //        baglan.Close();
            //    }
            //    if (comboBox1.SelectedIndex == 1)
            //    {
            //        baglan.Open();
            //        OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=2", baglan);
            //        OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //        while (okuyucu2.Read())
            //        {
            //            string doktor = okuyucu2[""].ToString();
            //            comboBox2.Items.Add(doktor);
            //        }
            //        okuyucu2.Close();
            //        baglan.Close();
            //    }
            //    if (comboBox1.SelectedIndex == 2)
            //    {
            //        baglan.Open();
            //        OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //        OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //        while (okuyucu2.Read())
            //        {
            //            string doktor = okuyucu2[""].ToString();
            //            comboBox2.Items.Add(doktor);
            //        }
            //        okuyucu2.Close();
            //        baglan.Close();
            //    }
            //    if (comboBox1.SelectedIndex == 3)
            //    {
            //        baglan.Open();
            //        OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //        OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //        while (okuyucu2.Read())
            //        {
            //            string doktor = okuyucu2[""].ToString();
            //            comboBox2.Items.Add(doktor);
            //        }
            //        okuyucu2.Close();
            //        baglan.Close();
            //    }
            //    if (comboBox1.SelectedIndex == 4)
            //    {
            //        baglan.Open();
            //        OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //        OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //        while (okuyucu2.Read())
            //        {
            //            string doktor = okuyucu2[""].ToString();
            //            comboBox2.Items.Add(doktor);
            //        }
            //        okuyucu2.Close();
            //        baglan.Close();
            //    }
            //    if (comboBox1.SelectedIndex == 5)
            //    {
            //        baglan.Open();
            //        OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //        OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //        while (okuyucu2.Read())
            //        {
            //            string doktor = okuyucu2[""].ToString();
            //            comboBox2.Items.Add(doktor);
            //        }
            //        okuyucu2.Close();
            //        baglan.Close();
            //    }
            //    if (comboBox1.SelectedIndex == 6)
            //    {
            //        baglan.Open();
            //        OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //        OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //        while (okuyucu2.Read())
            //        {
            //            string doktor = okuyucu2[""].ToString();
            //            comboBox2.Items.Add(doktor);
            //        }
            //        okuyucu2.Close();
            //        baglan.Close();
            //    }
            //}
            

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || tarihdegistimi == false || varsayilantarihdegeri == dateTimePicker1.Value)
            //|| dateTimePicker1.ValueChanged == false 
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurunuz ve randevu gününü bugün seçmeyiniz.");
            }
            else
            {
                randevulartablosunakaydet();
                randevulartablosunuguncelle();
            }
            randevulartablosunuguncelle();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tarihdegistimi = true;

        }

        int secilibransid;
        int secilidoktorid;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                secilibransid = 1;
                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
                OleDbDataReader okuyucu2 = komut3.ExecuteReader();
                while (okuyucu2.Read())
                {
                    string doktorAdi = okuyucu2["doktorAdi"].ToString();
                    string doktorSoyadi = okuyucu2["doktorSoyadi"].ToString();
                    comboBox2.Items.Add(doktorAdi+" "+doktorSoyadi);
                }
                okuyucu2.Close();
                baglan.Close();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                secilibransid = 2;
                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=2", baglan);
                OleDbDataReader okuyucu2 = komut3.ExecuteReader();
                while (okuyucu2.Read())
                {
                    string doktorAdi = okuyucu2["doktorAdi"].ToString();
                    string doktorSoyadi = okuyucu2["doktorSoyadi"].ToString();
                    comboBox2.Items.Add(doktorAdi + " " + doktorSoyadi);
                }
                okuyucu2.Close();
                baglan.Close();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                secilibransid = 3;
                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=3", baglan);
                OleDbDataReader okuyucu2 = komut3.ExecuteReader();
                while (okuyucu2.Read())
                {
                    string doktorAdi = okuyucu2["doktorAdi"].ToString();
                    string doktorSoyadi = okuyucu2["doktorSoyadi"].ToString();
                    comboBox2.Items.Add(doktorAdi + " " + doktorSoyadi);
                }
                okuyucu2.Close();
                baglan.Close();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                secilibransid = 4;
                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=4", baglan);
                OleDbDataReader okuyucu2 = komut3.ExecuteReader();
                while (okuyucu2.Read())
                {
                    string doktorAdi = okuyucu2["doktorAdi"].ToString();
                    string doktorSoyadi = okuyucu2["doktorSoyadi"].ToString();
                    comboBox2.Items.Add(doktorAdi + " " + doktorSoyadi);
                }
                okuyucu2.Close();
                baglan.Close();
            }
            if (comboBox1.SelectedIndex == 4)
            {
                secilibransid = 5;
                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=5", baglan);
                OleDbDataReader okuyucu2 = komut3.ExecuteReader();
                while (okuyucu2.Read())
                {
                    string doktorAdi = okuyucu2["doktorAdi"].ToString();
                    string doktorSoyadi = okuyucu2["doktorSoyadi"].ToString();
                    comboBox2.Items.Add(doktorAdi + " " + doktorSoyadi);
                }
                okuyucu2.Close();
                baglan.Close();
            }
            if (comboBox1.SelectedIndex == 5)
            {
                secilibransid = 6;
                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=6", baglan);
                OleDbDataReader okuyucu2 = komut3.ExecuteReader();
                while (okuyucu2.Read())
                {
                    string doktorAdi = okuyucu2["doktorAdi"].ToString();
                    string doktorSoyadi = okuyucu2["doktorSoyadi"].ToString();
                    comboBox2.Items.Add(doktorAdi + " " + doktorSoyadi);
                }
                okuyucu2.Close();
                baglan.Close();
            }
            if (comboBox1.SelectedIndex == 6)
            {
                secilibransid = 7;
                comboBox2.Items.Clear();
                baglan.Open();
                OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=7", baglan);
                OleDbDataReader okuyucu2 = komut3.ExecuteReader();
                while (okuyucu2.Read())
                {
                    string doktorAdi = okuyucu2["doktorAdi"].ToString();
                    string doktorSoyadi = okuyucu2["doktorSoyadi"].ToString();
                    comboBox2.Items.Add(doktorAdi + " " + doktorSoyadi);
                }
                okuyucu2.Close();
                baglan.Close();
            }
            //if (comboBox1.SelectedIndex == 1)
            //{
            //    baglan.Open();
            //    OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=2", baglan);
            //    OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //    while (okuyucu2.Read())
            //    {
            //        string doktor = okuyucu2[""].ToString();
            //        comboBox2.Items.Add(doktor);
            //    }
            //    okuyucu2.Close();
            //    baglan.Close();
            //}
            //if (comboBox1.SelectedIndex == 2)
            //{
            //    baglan.Open();
            //    OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //    OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //    while (okuyucu2.Read())
            //    {
            //        string doktor = okuyucu2[""].ToString();
            //        comboBox2.Items.Add(doktor);
            //    }
            //    okuyucu2.Close();
            //    baglan.Close();
            //}
            //if (comboBox1.SelectedIndex == 3)
            //{
            //    baglan.Open();
            //    OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //    OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //    while (okuyucu2.Read())
            //    {
            //        string doktor = okuyucu2[""].ToString();
            //        comboBox2.Items.Add(doktor);
            //    }
            //    okuyucu2.Close();
            //    baglan.Close();
            //}
            //if (comboBox1.SelectedIndex == 4)
            //{
            //    baglan.Open();
            //    OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //    OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //    while (okuyucu2.Read())
            //    {
            //        string doktor = okuyucu2[""].ToString();
            //        comboBox2.Items.Add(doktor);
            //    }
            //    okuyucu2.Close();
            //    baglan.Close();
            //}
            //if (comboBox1.SelectedIndex == 5)
            //{
            //    baglan.Open();
            //    OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //    OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //    while (okuyucu2.Read())
            //    {
            //        string doktor = okuyucu2[""].ToString();
            //        comboBox2.Items.Add(doktor);
            //    }
            //    okuyucu2.Close();
            //    baglan.Close();
            //}
            //if (comboBox1.SelectedIndex == 6)
            //{
            //    baglan.Open();
            //    OleDbCommand komut3 = new OleDbCommand("SELECT doktorAdi,doktorSoyadi FROM Doktorlar WHERE BransID=1", baglan);
            //    OleDbDataReader okuyucu2 = komut3.ExecuteReader();
            //    while (okuyucu2.Read())
            //    {
            //        string doktor = okuyucu2[""].ToString();
            //        comboBox2.Items.Add(doktor);
            //    }
            //    okuyucu2.Close();
            //    baglan.Close();
            //}
        }
    }
}
