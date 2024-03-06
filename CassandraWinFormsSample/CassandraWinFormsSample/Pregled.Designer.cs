namespace CassandraWinFormsSample
{
    partial class Pregled
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pregled));
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnPosaljiZahtev = new System.Windows.Forms.Button();
            this.btnZahtevi = new System.Windows.Forms.Button();
            this.btnLajk = new System.Windows.Forms.Button();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnObrisiOglas = new System.Windows.Forms.Button();
            this.btnSvojiZahtevi = new System.Windows.Forms.Button();
            this.btnDodajOglas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(9, 58);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(448, 366);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnPosaljiZahtev
            // 
            this.btnPosaljiZahtev.Location = new System.Drawing.Point(478, 180);
            this.btnPosaljiZahtev.Margin = new System.Windows.Forms.Padding(2);
            this.btnPosaljiZahtev.Name = "btnPosaljiZahtev";
            this.btnPosaljiZahtev.Size = new System.Drawing.Size(120, 48);
            this.btnPosaljiZahtev.TabIndex = 1;
            this.btnPosaljiZahtev.Text = "Napravi narudzbinu";
            this.btnPosaljiZahtev.UseVisualStyleBackColor = true;
            this.btnPosaljiZahtev.Click += new System.EventHandler(this.btnPosaljiZahtev_Click);
            // 
            // btnZahtevi
            // 
            this.btnZahtevi.Location = new System.Drawing.Point(620, 180);
            this.btnZahtevi.Margin = new System.Windows.Forms.Padding(2);
            this.btnZahtevi.Name = "btnZahtevi";
            this.btnZahtevi.Size = new System.Drawing.Size(112, 48);
            this.btnZahtevi.TabIndex = 2;
            this.btnZahtevi.Text = "Pregledaj narudzbine";
            this.btnZahtevi.UseVisualStyleBackColor = true;
            this.btnZahtevi.Click += new System.EventHandler(this.btnZahtevi_Click);
            // 
            // btnLajk
            // 
            this.btnLajk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLajk.BackgroundImage")));
            this.btnLajk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLajk.Location = new System.Drawing.Point(706, 367);
            this.btnLajk.Margin = new System.Windows.Forms.Padding(2);
            this.btnLajk.Name = "btnLajk";
            this.btnLajk.Size = new System.Drawing.Size(67, 55);
            this.btnLajk.TabIndex = 3;
            this.btnLajk.UseVisualStyleBackColor = true;
            this.btnLajk.Click += new System.EventHandler(this.btnLajk_Click);
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(525, 79);
            this.lblIme.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(35, 13);
            this.lblIme.TabIndex = 4;
            this.lblIme.Text = "label1";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(606, 79);
            this.lblPrezime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(35, 13);
            this.lblPrezime.TabIndex = 5;
            this.lblPrezime.Text = "label2";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(525, 120);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "label3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(668, 79);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(562, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "PROFIL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(163, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "AUTOMOBILI";
            // 
            // btnObrisiOglas
            // 
            this.btnObrisiOglas.Location = new System.Drawing.Point(478, 261);
            this.btnObrisiOglas.Margin = new System.Windows.Forms.Padding(2);
            this.btnObrisiOglas.Name = "btnObrisiOglas";
            this.btnObrisiOglas.Size = new System.Drawing.Size(120, 32);
            this.btnObrisiOglas.TabIndex = 10;
            this.btnObrisiOglas.Text = "Obrisi oglas";
            this.btnObrisiOglas.UseVisualStyleBackColor = true;
            this.btnObrisiOglas.Click += new System.EventHandler(this.btnObrisiOglas_Click);
            // 
            // btnSvojiZahtevi
            // 
            this.btnSvojiZahtevi.Location = new System.Drawing.Point(620, 241);
            this.btnSvojiZahtevi.Margin = new System.Windows.Forms.Padding(2);
            this.btnSvojiZahtevi.Name = "btnSvojiZahtevi";
            this.btnSvojiZahtevi.Size = new System.Drawing.Size(112, 51);
            this.btnSvojiZahtevi.TabIndex = 11;
            this.btnSvojiZahtevi.Text = "Pregledaj svoje narudzbine";
            this.btnSvojiZahtevi.UseVisualStyleBackColor = true;
            this.btnSvojiZahtevi.Click += new System.EventHandler(this.btnSvojiZahtevi_Click);
            // 
            // btnDodajOglas
            // 
            this.btnDodajOglas.Location = new System.Drawing.Point(566, 311);
            this.btnDodajOglas.Margin = new System.Windows.Forms.Padding(2);
            this.btnDodajOglas.Name = "btnDodajOglas";
            this.btnDodajOglas.Size = new System.Drawing.Size(103, 55);
            this.btnDodajOglas.TabIndex = 12;
            this.btnDodajOglas.Text = "Dodaj Oglas";
            this.btnDodajOglas.UseVisualStyleBackColor = true;
            this.btnDodajOglas.Click += new System.EventHandler(this.btnDodajOglas_Click);
            // 
            // Pregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 432);
            this.Controls.Add(this.btnDodajOglas);
            this.Controls.Add(this.btnSvojiZahtevi);
            this.Controls.Add(this.btnObrisiOglas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.btnLajk);
            this.Controls.Add(this.btnZahtevi);
            this.Controls.Add(this.btnPosaljiZahtev);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Pregled";
            this.Text = "Pregled";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnPosaljiZahtev;
        private System.Windows.Forms.Button btnZahtevi;
        private System.Windows.Forms.Button btnLajk;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnObrisiOglas;
        private System.Windows.Forms.Button btnSvojiZahtevi;
        private System.Windows.Forms.Button btnDodajOglas;
    }
}