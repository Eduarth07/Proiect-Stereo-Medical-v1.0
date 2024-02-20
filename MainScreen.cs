using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stereomedical
{
    public partial class Tab_Principal : Form
    {
        public Tab_Principal()
        {
            InitializeComponent();
        }

        private void buttonProgramari_Click(object sender, EventArgs e)
        {
            Tab_Programari tab = new Tab_Programari();
            tab.Show();
        }

        private void Tab_Principal_Load(object sender, EventArgs e)
        {

        }

        private void buttonPacienti_Click(object sender, EventArgs e)
        {
            Pacienti tab = new Pacienti();
            tab.Show();
        }

        private void buttonMedici_Click(object sender, EventArgs e)
        {
            Medici tab = new Medici();
            tab.Show();
        }

        private void titlu_Click(object sender, EventArgs e)
        {

        }
    }
}
