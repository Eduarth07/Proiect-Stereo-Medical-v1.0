using System.Drawing;
using System.Windows.Forms;

namespace stereomedical
{
    partial class Medici
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Medici));
            this.btn_M_Cauta = new System.Windows.Forms.Button();
            this.textBox_M_Grad = new System.Windows.Forms.TextBox();
            this.btn_M_Clear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_M_Specialitate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_M_Prenume = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_M_Nume = new System.Windows.Forms.TextBox();
            this.btn_M_Sterge = new System.Windows.Forms.Button();
            this.btn_M_Modifica = new System.Windows.Forms.Button();
            this.btn_M_Adauga = new System.Windows.Forms.Button();
            this.listView_Medici = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_M_OraInceput = new System.Windows.Forms.TextBox();
            this.textBox_M_OraSfarsit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_M_Cauta
            // 
            this.btn_M_Cauta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_M_Cauta.Location = new System.Drawing.Point(550, 339);
            this.btn_M_Cauta.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_M_Cauta.Name = "btn_M_Cauta";
            this.btn_M_Cauta.Size = new System.Drawing.Size(290, 57);
            this.btn_M_Cauta.TabIndex = 60;
            this.btn_M_Cauta.Text = "CAUTĂ";
            this.btn_M_Cauta.UseVisualStyleBackColor = true;
            this.btn_M_Cauta.Click += new System.EventHandler(this.btn_M_Cauta_Click);
            // 
            // textBox_M_Grad
            // 
            this.textBox_M_Grad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_M_Grad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_M_Grad.Location = new System.Drawing.Point(637, 200);
            this.textBox_M_Grad.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_M_Grad.Name = "textBox_M_Grad";
            this.textBox_M_Grad.Size = new System.Drawing.Size(205, 26);
            this.textBox_M_Grad.TabIndex = 58;
            // 
            // btn_M_Clear
            // 
            this.btn_M_Clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_M_Clear.Location = new System.Drawing.Point(550, 402);
            this.btn_M_Clear.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_M_Clear.Name = "btn_M_Clear";
            this.btn_M_Clear.Size = new System.Drawing.Size(290, 38);
            this.btn_M_Clear.TabIndex = 57;
            this.btn_M_Clear.Text = "Golește câmpuri";
            this.btn_M_Clear.UseVisualStyleBackColor = true;
            this.btn_M_Clear.Click += new System.EventHandler(this.btn_M_Clear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(539, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 55;
            this.label4.Text = "Grad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(539, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 54;
            this.label3.Text = "Specialitate:";
            // 
            // textBox_M_Specialitate
            // 
            this.textBox_M_Specialitate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_M_Specialitate.Location = new System.Drawing.Point(637, 166);
            this.textBox_M_Specialitate.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_M_Specialitate.Name = "textBox_M_Specialitate";
            this.textBox_M_Specialitate.Size = new System.Drawing.Size(205, 26);
            this.textBox_M_Specialitate.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(539, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 52;
            this.label2.Text = "Prenume:";
            // 
            // textBox_M_Prenume
            // 
            this.textBox_M_Prenume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_M_Prenume.Location = new System.Drawing.Point(637, 132);
            this.textBox_M_Prenume.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_M_Prenume.Name = "textBox_M_Prenume";
            this.textBox_M_Prenume.Size = new System.Drawing.Size(205, 26);
            this.textBox_M_Prenume.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(539, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 50;
            this.label1.Text = "Nume:";
            // 
            // textBox_M_Nume
            // 
            this.textBox_M_Nume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_M_Nume.Location = new System.Drawing.Point(637, 98);
            this.textBox_M_Nume.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_M_Nume.Name = "textBox_M_Nume";
            this.textBox_M_Nume.Size = new System.Drawing.Size(205, 26);
            this.textBox_M_Nume.TabIndex = 49;
            // 
            // btn_M_Sterge
            // 
            this.btn_M_Sterge.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_M_Sterge.Location = new System.Drawing.Point(748, 445);
            this.btn_M_Sterge.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_M_Sterge.Name = "btn_M_Sterge";
            this.btn_M_Sterge.Size = new System.Drawing.Size(91, 37);
            this.btn_M_Sterge.TabIndex = 48;
            this.btn_M_Sterge.Text = "Șterge";
            this.btn_M_Sterge.UseVisualStyleBackColor = true;
            this.btn_M_Sterge.Click += new System.EventHandler(this.btn_M_Sterge_Click);
            // 
            // btn_M_Modifica
            // 
            this.btn_M_Modifica.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_M_Modifica.Location = new System.Drawing.Point(649, 445);
            this.btn_M_Modifica.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_M_Modifica.Name = "btn_M_Modifica";
            this.btn_M_Modifica.Size = new System.Drawing.Size(91, 37);
            this.btn_M_Modifica.TabIndex = 47;
            this.btn_M_Modifica.Text = "Modifică";
            this.btn_M_Modifica.UseVisualStyleBackColor = true;
            this.btn_M_Modifica.Click += new System.EventHandler(this.btn_M_Modifica_Click);
            // 
            // btn_M_Adauga
            // 
            this.btn_M_Adauga.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_M_Adauga.Location = new System.Drawing.Point(550, 445);
            this.btn_M_Adauga.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_M_Adauga.Name = "btn_M_Adauga";
            this.btn_M_Adauga.Size = new System.Drawing.Size(91, 37);
            this.btn_M_Adauga.TabIndex = 46;
            this.btn_M_Adauga.Text = "Adaugă";
            this.btn_M_Adauga.UseVisualStyleBackColor = true;
            this.btn_M_Adauga.Click += new System.EventHandler(this.btn_M_Adauga_Click);
            // 
            // listView_Medici
            // 
            this.listView_Medici.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Medici.FullRowSelect = true;
            this.listView_Medici.GridLines = true;
            this.listView_Medici.HideSelection = false;
            this.listView_Medici.Location = new System.Drawing.Point(23, 86);
            this.listView_Medici.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.listView_Medici.Name = "listView_Medici";
            this.listView_Medici.Size = new System.Drawing.Size(491, 396);
            this.listView_Medici.TabIndex = 44;
            this.listView_Medici.UseCompatibleStateImageBehavior = false;
            this.listView_Medici.View = System.Windows.Forms.View.Details;
            this.listView_Medici.SelectedIndexChanged += new System.EventHandler(this.listView_Medici_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(537, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 61;
            this.label5.Text = "Ora inceput:";
            // 
            // textBox_M_OraInceput
            // 
            this.textBox_M_OraInceput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_M_OraInceput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_M_OraInceput.Location = new System.Drawing.Point(637, 234);
            this.textBox_M_OraInceput.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_M_OraInceput.Name = "textBox_M_OraInceput";
            this.textBox_M_OraInceput.Size = new System.Drawing.Size(205, 26);
            this.textBox_M_OraInceput.TabIndex = 62;
            // 
            // textBox_M_OraSfarsit
            // 
            this.textBox_M_OraSfarsit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_M_OraSfarsit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_M_OraSfarsit.Location = new System.Drawing.Point(637, 266);
            this.textBox_M_OraSfarsit.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_M_OraSfarsit.Name = "textBox_M_OraSfarsit";
            this.textBox_M_OraSfarsit.Size = new System.Drawing.Size(205, 26);
            this.textBox_M_OraSfarsit.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(539, 274);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 18);
            this.label6.TabIndex = 63;
            this.label6.Text = "Ora sfarsit:";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Wingdings 3", 20F, System.Drawing.FontStyle.Bold);
            this.btn_refresh.Location = new System.Drawing.Point(793, 44);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(47, 42);
            this.btn_refresh.TabIndex = 65;
            this.btn_refresh.Text = "Q";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // Medici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(862, 505);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.textBox_M_OraSfarsit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_M_OraInceput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_M_Cauta);
            this.Controls.Add(this.textBox_M_Grad);
            this.Controls.Add(this.btn_M_Clear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_M_Specialitate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_M_Prenume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_M_Nume);
            this.Controls.Add(this.btn_M_Sterge);
            this.Controls.Add(this.btn_M_Modifica);
            this.Controls.Add(this.btn_M_Adauga);
            this.Controls.Add(this.listView_Medici);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Medici";
            this.Text = "StereoM v2.4 beta - MEDICI";
            this.TransparencyKey = System.Drawing.Color.LimeGreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_M_Cauta;
        private System.Windows.Forms.TextBox textBox_M_Grad;
        private System.Windows.Forms.Button btn_M_Clear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_M_Specialitate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_M_Prenume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_M_Nume;
        private System.Windows.Forms.Button btn_M_Sterge;
        private System.Windows.Forms.Button btn_M_Modifica;
        private System.Windows.Forms.Button btn_M_Adauga;
        private System.Windows.Forms.ListView listView_Medici;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_M_OraInceput;
        private System.Windows.Forms.TextBox textBox_M_OraSfarsit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_refresh;
    }
}