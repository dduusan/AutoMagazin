namespace CassandraWinFormsSample
{
    partial class Narudzbine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Narudzbine));
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnPrihvati = new System.Windows.Forms.Button();
            this.btnOdbij = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(52, 71);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(660, 227);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnPrihvati
            // 
            this.btnPrihvati.Location = new System.Drawing.Point(162, 327);
            this.btnPrihvati.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrihvati.Name = "btnPrihvati";
            this.btnPrihvati.Size = new System.Drawing.Size(82, 38);
            this.btnPrihvati.TabIndex = 1;
            this.btnPrihvati.Text = "PRIHVATI";
            this.btnPrihvati.UseVisualStyleBackColor = true;
            this.btnPrihvati.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOdbij
            // 
            this.btnOdbij.Location = new System.Drawing.Point(493, 327);
            this.btnOdbij.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOdbij.Name = "btnOdbij";
            this.btnOdbij.Size = new System.Drawing.Size(88, 38);
            this.btnOdbij.TabIndex = 2;
            this.btnOdbij.Text = "ODBIJ";
            this.btnOdbij.UseVisualStyleBackColor = true;
            this.btnOdbij.Click += new System.EventHandler(this.btnOdbij_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObrisi.BackgroundImage")));
            this.btnObrisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObrisi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnObrisi.Image = ((System.Drawing.Image)(resources.GetObject("btnObrisi.Image")));
            this.btnObrisi.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnObrisi.Location = new System.Drawing.Point(319, 327);
            this.btnObrisi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(92, 38);
            this.btnObrisi.TabIndex = 3;
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Moje Narudzbine";
            // 
            // Narudzbine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 417);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnOdbij);
            this.Controls.Add(this.btnPrihvati);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Narudzbine";
            this.Text = "Narudzbine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnPrihvati;
        private System.Windows.Forms.Button btnOdbij;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Label label1;
    }
}