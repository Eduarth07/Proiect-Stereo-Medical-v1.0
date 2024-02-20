using System.Drawing;
using System;

namespace stereomedical
{
    partial class Pacienti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pacienti));
            this.listView_Pacienti = new System.Windows.Forms.ListView();
            this.btn_Pac_Clear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Pac_CNP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Pac_Prenume = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Pac_Nume = new System.Windows.Forms.TextBox();
            this.btn_Pac_Sterge = new System.Windows.Forms.Button();
            this.btn_Pac_Modifica = new System.Windows.Forms.Button();
            this.btn_Pac_Adauga = new System.Windows.Forms.Button();
            this.textBox_Pac_Telefon = new System.Windows.Forms.TextBox();
            this.textBox_Pac_Adresa = new System.Windows.Forms.TextBox();
            this.btn_Pac_Cauta = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_Pacienti
            // 
            this.listView_Pacienti.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Pacienti.FullRowSelect = true;
            this.listView_Pacienti.GridLines = true;
            this.listView_Pacienti.HideSelection = false;
            this.listView_Pacienti.Location = new System.Drawing.Point(17, 80);
            this.listView_Pacienti.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.listView_Pacienti.Name = "listView_Pacienti";
            this.listView_Pacienti.Size = new System.Drawing.Size(606, 375);
            this.listView_Pacienti.TabIndex = 19;
            this.listView_Pacienti.UseCompatibleStateImageBehavior = false;
            this.listView_Pacienti.View = System.Windows.Forms.View.Details;
            this.listView_Pacienti.SelectedIndexChanged += new System.EventHandler(this.listView_Pacienti_SelectedIndexChanged);
            // 
            // btn_Pac_Clear
            // 
            this.btn_Pac_Clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pac_Clear.Location = new System.Drawing.Point(649, 378);
            this.btn_Pac_Clear.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_Pac_Clear.Name = "btn_Pac_Clear";
            this.btn_Pac_Clear.Size = new System.Drawing.Size(290, 38);
            this.btn_Pac_Clear.TabIndex = 40;
            this.btn_Pac_Clear.Text = "Golește câmpuri";
            this.btn_Pac_Clear.UseVisualStyleBackColor = true;
            this.btn_Pac_Clear.Click += new System.EventHandler(this.btn_Pac_Clear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(653, 261);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 34;
            this.label5.Text = "Adresa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(653, 227);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "Telefon:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(653, 193);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "CNP:";
            // 
            // textBox_Pac_CNP
            // 
            this.textBox_Pac_CNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pac_CNP.Location = new System.Drawing.Point(734, 185);
            this.textBox_Pac_CNP.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_Pac_CNP.Name = "textBox_Pac_CNP";
            this.textBox_Pac_CNP.Size = new System.Drawing.Size(205, 26);
            this.textBox_Pac_CNP.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(653, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "Prenume:";
            // 
            // textBox_Pac_Prenume
            // 
            this.textBox_Pac_Prenume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pac_Prenume.Location = new System.Drawing.Point(734, 151);
            this.textBox_Pac_Prenume.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_Pac_Prenume.Name = "textBox_Pac_Prenume";
            this.textBox_Pac_Prenume.Size = new System.Drawing.Size(205, 26);
            this.textBox_Pac_Prenume.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(653, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nume:";
            // 
            // textBox_Pac_Nume
            // 
            this.textBox_Pac_Nume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pac_Nume.Location = new System.Drawing.Point(734, 117);
            this.textBox_Pac_Nume.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_Pac_Nume.Name = "textBox_Pac_Nume";
            this.textBox_Pac_Nume.Size = new System.Drawing.Size(205, 26);
            this.textBox_Pac_Nume.TabIndex = 27;
            // 
            // btn_Pac_Sterge
            // 
            this.btn_Pac_Sterge.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pac_Sterge.Location = new System.Drawing.Point(848, 418);
            this.btn_Pac_Sterge.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_Pac_Sterge.Name = "btn_Pac_Sterge";
            this.btn_Pac_Sterge.Size = new System.Drawing.Size(91, 37);
            this.btn_Pac_Sterge.TabIndex = 26;
            this.btn_Pac_Sterge.Text = "Șterge";
            this.btn_Pac_Sterge.UseVisualStyleBackColor = true;
            this.btn_Pac_Sterge.Click += new System.EventHandler(this.btn_Pac_Sterge_Click);
            // 
            // btn_Pac_Modifica
            // 
            this.btn_Pac_Modifica.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pac_Modifica.Location = new System.Drawing.Point(749, 418);
            this.btn_Pac_Modifica.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_Pac_Modifica.Name = "btn_Pac_Modifica";
            this.btn_Pac_Modifica.Size = new System.Drawing.Size(91, 37);
            this.btn_Pac_Modifica.TabIndex = 25;
            this.btn_Pac_Modifica.Text = "Modifică";
            this.btn_Pac_Modifica.UseVisualStyleBackColor = true;
            this.btn_Pac_Modifica.Click += new System.EventHandler(this.btn_Pac_Modifica_Click);
            // 
            // btn_Pac_Adauga
            // 
            this.btn_Pac_Adauga.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pac_Adauga.Location = new System.Drawing.Point(649, 418);
            this.btn_Pac_Adauga.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_Pac_Adauga.Name = "btn_Pac_Adauga";
            this.btn_Pac_Adauga.Size = new System.Drawing.Size(91, 37);
            this.btn_Pac_Adauga.TabIndex = 24;
            this.btn_Pac_Adauga.Text = "Adaugă";
            this.btn_Pac_Adauga.UseVisualStyleBackColor = true;
            this.btn_Pac_Adauga.Click += new System.EventHandler(this.btn_Pac_Adauga_Click);
            // 
            // textBox_Pac_Telefon
            // 
            this.textBox_Pac_Telefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pac_Telefon.Location = new System.Drawing.Point(734, 219);
            this.textBox_Pac_Telefon.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_Pac_Telefon.Name = "textBox_Pac_Telefon";
            this.textBox_Pac_Telefon.Size = new System.Drawing.Size(205, 26);
            this.textBox_Pac_Telefon.TabIndex = 41;
            // 
            // textBox_Pac_Adresa
            // 
            this.textBox_Pac_Adresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pac_Adresa.Location = new System.Drawing.Point(734, 253);
            this.textBox_Pac_Adresa.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_Pac_Adresa.Name = "textBox_Pac_Adresa";
            this.textBox_Pac_Adresa.Size = new System.Drawing.Size(205, 26);
            this.textBox_Pac_Adresa.TabIndex = 42;
            // 
            // btn_Pac_Cauta
            // 
            this.btn_Pac_Cauta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pac_Cauta.Location = new System.Drawing.Point(649, 319);
            this.btn_Pac_Cauta.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_Pac_Cauta.Name = "btn_Pac_Cauta";
            this.btn_Pac_Cauta.Size = new System.Drawing.Size(290, 57);
            this.btn_Pac_Cauta.TabIndex = 43;
            this.btn_Pac_Cauta.Text = "CAUTĂ";
            this.btn_Pac_Cauta.UseVisualStyleBackColor = true;
            this.btn_Pac_Cauta.Click += new System.EventHandler(this.btn_Pac_Cauta_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Wingdings 3", 20F, System.Drawing.FontStyle.Bold);
            this.btn_refresh.Location = new System.Drawing.Point(894, 61);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(47, 42);
            this.btn_refresh.TabIndex = 44;
            this.btn_refresh.Text = "Q";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // Pacienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(957, 483);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_Pac_Cauta);
            this.Controls.Add(this.textBox_Pac_Adresa);
            this.Controls.Add(this.textBox_Pac_Telefon);
            this.Controls.Add(this.btn_Pac_Clear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Pac_CNP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Pac_Prenume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Pac_Nume);
            this.Controls.Add(this.btn_Pac_Sterge);
            this.Controls.Add(this.btn_Pac_Modifica);
            this.Controls.Add(this.btn_Pac_Adauga);
            this.Controls.Add(this.listView_Pacienti);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Pacienti";
            this.Text = "StereoM v2.4 beta - PACIENTI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Pacienti;
        private System.Windows.Forms.Button btn_Pac_Clear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Pac_CNP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Pac_Prenume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Pac_Nume;
        private System.Windows.Forms.Button btn_Pac_Sterge;
        private System.Windows.Forms.Button btn_Pac_Modifica;
        private System.Windows.Forms.Button btn_Pac_Adauga;
        private System.Windows.Forms.TextBox textBox_Pac_Telefon;
        private System.Windows.Forms.TextBox textBox_Pac_Adresa;
        private System.Windows.Forms.Button btn_Pac_Cauta;
        private System.Windows.Forms.Button btn_refresh;
    }
}