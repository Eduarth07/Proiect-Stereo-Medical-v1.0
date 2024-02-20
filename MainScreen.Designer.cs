using System.Drawing;
using System.Windows.Forms;

namespace stereomedical
{
    partial class Tab_Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tab_Principal));
            this.buttonProgramari = new System.Windows.Forms.Button();
            this.buttonPacienti = new System.Windows.Forms.Button();
            this.buttonMedici = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonProgramari
            // 
            this.buttonProgramari.Font = new System.Drawing.Font("Arial", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProgramari.Location = new System.Drawing.Point(88, 327);
            this.buttonProgramari.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonProgramari.Name = "buttonProgramari";
            this.buttonProgramari.Size = new System.Drawing.Size(198, 60);
            this.buttonProgramari.TabIndex = 1;
            this.buttonProgramari.Text = "Programări";
            this.buttonProgramari.UseVisualStyleBackColor = true;
            this.buttonProgramari.Click += new System.EventHandler(this.buttonProgramari_Click);
            // 
            // buttonPacienti
            // 
            this.buttonPacienti.Font = new System.Drawing.Font("Arial", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPacienti.Location = new System.Drawing.Point(329, 327);
            this.buttonPacienti.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonPacienti.Name = "buttonPacienti";
            this.buttonPacienti.Size = new System.Drawing.Size(198, 60);
            this.buttonPacienti.TabIndex = 2;
            this.buttonPacienti.Text = "Pacienți";
            this.buttonPacienti.UseVisualStyleBackColor = true;
            this.buttonPacienti.Click += new System.EventHandler(this.buttonPacienti_Click);
            // 
            // buttonMedici
            // 
            this.buttonMedici.Font = new System.Drawing.Font("Arial", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMedici.Location = new System.Drawing.Point(569, 327);
            this.buttonMedici.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonMedici.Name = "buttonMedici";
            this.buttonMedici.Size = new System.Drawing.Size(198, 60);
            this.buttonMedici.TabIndex = 3;
            this.buttonMedici.Text = "Medici";
            this.buttonMedici.UseVisualStyleBackColor = true;
            this.buttonMedici.Click += new System.EventHandler(this.buttonMedici_Click);
            // 
            // Tab_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(840, 454);
            this.Controls.Add(this.buttonMedici);
            this.Controls.Add(this.buttonPacienti);
            this.Controls.Add(this.buttonProgramari);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Tab_Principal";
            this.Text = "StereoM v2.4 beta";
            this.Load += new System.EventHandler(this.Tab_Principal_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonProgramari;
        private System.Windows.Forms.Button buttonPacienti;
        private System.Windows.Forms.Button buttonMedici;
    }
}

