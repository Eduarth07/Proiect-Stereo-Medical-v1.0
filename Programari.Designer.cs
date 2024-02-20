using System.Windows.Forms;

namespace stereomedical
{
    partial class Tab_Programari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tab_Programari));
            this.btn_P_Adauga = new System.Windows.Forms.Button();
            this.btn_P_Modifica = new System.Windows.Forms.Button();
            this.btn_P_Sterge = new System.Windows.Forms.Button();
            this.textBox_P_Nume = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_P_Prenume = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_P_Telefon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listView_Programari = new System.Windows.Forms.ListView();
            this.checkBox_P_Confirmat = new System.Windows.Forms.CheckBox();
            this.comboBox_Medici = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_Data = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_P_Ora = new System.Windows.Forms.ComboBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_P_Cauta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_P_Adauga
            // 
            this.btn_P_Adauga.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_P_Adauga.Location = new System.Drawing.Point(579, 420);
            this.btn_P_Adauga.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_P_Adauga.Name = "btn_P_Adauga";
            this.btn_P_Adauga.Size = new System.Drawing.Size(93, 37);
            this.btn_P_Adauga.TabIndex = 3;
            this.btn_P_Adauga.Text = "Adaugă";
            this.btn_P_Adauga.UseVisualStyleBackColor = true;
            this.btn_P_Adauga.Click += new System.EventHandler(this.btn_P_Adauga_Click);
            // 
            // btn_P_Modifica
            // 
            this.btn_P_Modifica.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_P_Modifica.Location = new System.Drawing.Point(674, 420);
            this.btn_P_Modifica.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_P_Modifica.Name = "btn_P_Modifica";
            this.btn_P_Modifica.Size = new System.Drawing.Size(95, 37);
            this.btn_P_Modifica.TabIndex = 4;
            this.btn_P_Modifica.Text = "Modifică";
            this.btn_P_Modifica.UseVisualStyleBackColor = true;
            this.btn_P_Modifica.Click += new System.EventHandler(this.btn_P_Modifica_Click);
            // 
            // btn_P_Sterge
            // 
            this.btn_P_Sterge.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_P_Sterge.Location = new System.Drawing.Point(771, 420);
            this.btn_P_Sterge.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_P_Sterge.Name = "btn_P_Sterge";
            this.btn_P_Sterge.Size = new System.Drawing.Size(91, 37);
            this.btn_P_Sterge.TabIndex = 5;
            this.btn_P_Sterge.Text = "Șterge";
            this.btn_P_Sterge.UseVisualStyleBackColor = true;
            this.btn_P_Sterge.Click += new System.EventHandler(this.btn_P_Sterge_Click);
            // 
            // textBox_P_Nume
            // 
            this.textBox_P_Nume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_P_Nume.Location = new System.Drawing.Point(657, 107);
            this.textBox_P_Nume.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_P_Nume.Name = "textBox_P_Nume";
            this.textBox_P_Nume.Size = new System.Drawing.Size(205, 26);
            this.textBox_P_Nume.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(576, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nume:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(574, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Prenume:";
            // 
            // textBox_P_Prenume
            // 
            this.textBox_P_Prenume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_P_Prenume.Location = new System.Drawing.Point(657, 140);
            this.textBox_P_Prenume.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_P_Prenume.Name = "textBox_P_Prenume";
            this.textBox_P_Prenume.Size = new System.Drawing.Size(205, 26);
            this.textBox_P_Prenume.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(576, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Telefon:";
            // 
            // textBox_P_Telefon
            // 
            this.textBox_P_Telefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_P_Telefon.Location = new System.Drawing.Point(657, 174);
            this.textBox_P_Telefon.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox_P_Telefon.Name = "textBox_P_Telefon";
            this.textBox_P_Telefon.Size = new System.Drawing.Size(205, 26);
            this.textBox_P_Telefon.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(576, 218);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Medic:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(576, 248);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Data:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(576, 286);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ora:";
            // 
            // listView_Programari
            // 
            this.listView_Programari.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Programari.FullRowSelect = true;
            this.listView_Programari.GridLines = true;
            this.listView_Programari.HideSelection = false;
            this.listView_Programari.Location = new System.Drawing.Point(16, 79);
            this.listView_Programari.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.listView_Programari.Name = "listView_Programari";
            this.listView_Programari.Size = new System.Drawing.Size(541, 380);
            this.listView_Programari.TabIndex = 18;
            this.listView_Programari.UseCompatibleStateImageBehavior = false;
            this.listView_Programari.View = System.Windows.Forms.View.Details;
            this.listView_Programari.SelectedIndexChanged += new System.EventHandler(this.listView_Programari_SelectedIndexChanged);
            // 
            // checkBox_P_Confirmat
            // 
            this.checkBox_P_Confirmat.AutoSize = true;
            this.checkBox_P_Confirmat.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_P_Confirmat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_P_Confirmat.Location = new System.Drawing.Point(674, 75);
            this.checkBox_P_Confirmat.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.checkBox_P_Confirmat.Name = "checkBox_P_Confirmat";
            this.checkBox_P_Confirmat.Size = new System.Drawing.Size(95, 22);
            this.checkBox_P_Confirmat.TabIndex = 19;
            this.checkBox_P_Confirmat.Text = "Confirmat";
            this.checkBox_P_Confirmat.UseVisualStyleBackColor = false;
            // 
            // comboBox_Medici
            // 
            this.comboBox_Medici.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Medici.FormattingEnabled = true;
            this.comboBox_Medici.Location = new System.Drawing.Point(657, 210);
            this.comboBox_Medici.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.comboBox_Medici.Name = "comboBox_Medici";
            this.comboBox_Medici.Size = new System.Drawing.Size(205, 26);
            this.comboBox_Medici.TabIndex = 21;
            this.comboBox_Medici.SelectedIndexChanged += new System.EventHandler(this.comboBox_Medici_SelectedIndexChanged);
            // 
            // dateTimePicker_Data
            // 
            this.dateTimePicker_Data.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_Data.Location = new System.Drawing.Point(657, 246);
            this.dateTimePicker_Data.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.dateTimePicker_Data.Name = "dateTimePicker_Data";
            this.dateTimePicker_Data.Size = new System.Drawing.Size(205, 20);
            this.dateTimePicker_Data.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(579, 380);
            this.button1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(283, 38);
            this.button1.TabIndex = 23;
            this.button1.Text = "Golește câmpuri";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_P_Ora
            // 
            this.comboBox_P_Ora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_P_Ora.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_P_Ora.FormattingEnabled = true;
            this.comboBox_P_Ora.Location = new System.Drawing.Point(657, 278);
            this.comboBox_P_Ora.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.comboBox_P_Ora.Name = "comboBox_P_Ora";
            this.comboBox_P_Ora.Size = new System.Drawing.Size(205, 26);
            this.comboBox_P_Ora.TabIndex = 24;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Wingdings 3", 20F, System.Drawing.FontStyle.Bold);
            this.btn_refresh.Location = new System.Drawing.Point(812, 55);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(47, 42);
            this.btn_refresh.TabIndex = 45;
            this.btn_refresh.Text = "Q";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_P_Cauta
            // 
            this.btn_P_Cauta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_P_Cauta.Location = new System.Drawing.Point(579, 316);
            this.btn_P_Cauta.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_P_Cauta.Name = "btn_P_Cauta";
            this.btn_P_Cauta.Size = new System.Drawing.Size(283, 57);
            this.btn_P_Cauta.TabIndex = 61;
            this.btn_P_Cauta.Text = "CAUTĂ";
            this.btn_P_Cauta.UseVisualStyleBackColor = true;
            this.btn_P_Cauta.Click += new System.EventHandler(this.btn_P_Cauta_Click);
            // 
            // Tab_Programari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(883, 497);
            this.Controls.Add(this.btn_P_Cauta);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.comboBox_P_Ora);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker_Data);
            this.Controls.Add(this.comboBox_Medici);
            this.Controls.Add(this.checkBox_P_Confirmat);
            this.Controls.Add(this.listView_Programari);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_P_Telefon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_P_Prenume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_P_Nume);
            this.Controls.Add(this.btn_P_Sterge);
            this.Controls.Add(this.btn_P_Modifica);
            this.Controls.Add(this.btn_P_Adauga);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Tab_Programari";
            this.Text = "StereoM v2.4 beta - PROGRAMARI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_P_Adauga;
        private System.Windows.Forms.Button btn_P_Modifica;
        private System.Windows.Forms.Button btn_P_Sterge;
        private System.Windows.Forms.TextBox textBox_P_Nume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_P_Prenume;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_P_Telefon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView_Programari;
        private CheckBox checkBox_P_Confirmat;
        private ComboBox comboBox_Medici;
        private DateTimePicker dateTimePicker_Data;
        private Button button1;
        private ComboBox comboBox_P_Ora;
        private Button btn_refresh;
        private Button btn_P_Cauta;
    }
}