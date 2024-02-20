using System;
using System.Windows.Forms;

namespace stereomedical
{
    public partial class Pacienti : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\eduar\Desktop\Proiect Stereo Medical v7 Beta\Database1.mdf"";Integrated Security=True";
        private DbFunctions dbFunctions;
        public Pacienti()
        {
            InitializeComponent();
            dbFunctions = new DbFunctions(connectionString);
            LoadPacientiData();
            DbFunctions.PacientUpdated += DbFunctions_PacientUpdated;
            DbFunctions.PacientDeleted += DbFunctions_PacientDeleted;
            DbFunctions.PacientAdded += DbFunctions_PacientAdded;
            DbFunctions.RefreshData += DbFunctions_RefreshData;
        }
        #region// ----- [METODA] - POPULEAZA LISTA DE PACIENTI ----- //
        private void LoadPacientiData()
        {
            try
            {
                dbFunctions.LoadPacientiData(listView_Pacienti);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region// ----- [METODA] - POPULEAZA TEXTBOX LA SELECTARE ----- //
        private void listView_Pacienti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Pacienti.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView_Pacienti.SelectedItems[0];

                string[] numePrenume = selectedItem.SubItems[0].Text.Split(' ');
                string nume = numePrenume.Length > 0 ? numePrenume[0] : string.Empty;
                string prenume = numePrenume.Length > 1 ? numePrenume[1] : string.Empty;

                textBox_Pac_Nume.Text = nume;
                textBox_Pac_Prenume.Text = prenume;
                textBox_Pac_CNP.Text = selectedItem.SubItems[1].Text;
                textBox_Pac_Telefon.Text = selectedItem.SubItems[2].Text;
                textBox_Pac_Adresa.Text = selectedItem.SubItems[3].Text;

            }
        }
        #endregion

        #region// ----- [METODA-BUTON] - ADAUGA PACIENT ----- //
        private void btn_Pac_Adauga_Click(object sender, EventArgs e)
        {
            try
            {
                string numePacient = textBox_Pac_Nume.Text;
                string prenumePacient = textBox_Pac_Prenume.Text;
                long? CNP = null;

                // Validate input
                if (string.IsNullOrWhiteSpace(numePacient) || string.IsNullOrWhiteSpace(prenumePacient))
                {
                    MessageBox.Show("Obligatoriu: Nume și prenume pacient.", "ATENTIONARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Attempt to parse the CNP from the text box
                if (!string.IsNullOrWhiteSpace(textBox_Pac_CNP.Text))
                {
                    if (!long.TryParse(textBox_Pac_CNP.Text, out long parsedCNP))
                    {
                        MessageBox.Show("Obligatoriu: CNP sau alt cod de identificare", "ATENTIONARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CNP = parsedCNP;
                }

                string Telefon = textBox_Pac_Telefon.Text;
                string Adresa = textBox_Pac_Adresa.Text;

                if (dbFunctions.IsCNPAlreadyExists(CNP))
                {
                    MessageBox.Show("Acest CNP există deja în baza de date.", "ATENTIONARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Call AddPacient with the nullable CNP
                dbFunctions.AddPacient(numePacient, prenumePacient, CNP, Telefon, Adresa);

                dbFunctions.RefreshPacientiData(listView_Pacienti);
                ClearInputControls();
                MessageBox.Show("Pacientul a fost adăugat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region// ----- [METODA-BUTON] - STERGE PACIENT ----- //
        private void btn_Pac_Sterge_Click(object sender, EventArgs e)
        {
            int pacientId = Convert.ToInt32(listView_Pacienti.SelectedItems[0].Tag);
            dbFunctions.DeletePacient(pacientId);

            dbFunctions.RefreshPacientiData(listView_Pacienti);
            ClearInputControls();
        }
        #endregion
        #region// ----- [METODA-BUTON] - MODIFICA PACIENT ----- //
        private void btn_Pac_Modifica_Click(object sender, EventArgs e)
        {
            try
            {
                int pacientId = Convert.ToInt32(listView_Pacienti.SelectedItems[0].Tag);
                string numePacient = textBox_Pac_Nume.Text;
                string prenumePacient = textBox_Pac_Prenume.Text;
                long? CNP = null;

                // Allow CNP to be null or attempt to parse it from the text box
                if (string.IsNullOrWhiteSpace(textBox_Pac_CNP.Text))
                {
                    // CNP is null, no action needed
                }
                else
                {
                    if (!long.TryParse(textBox_Pac_CNP.Text, out long parsedCNP))
                    {
                        MessageBox.Show("Obligatoriu: CNP sau alt cod de identificare", "ATENTIONARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CNP = parsedCNP;
                }
                string Telefon = textBox_Pac_Telefon.Text;
                string Adresa = textBox_Pac_Adresa.Text;

                dbFunctions.UpdatePacient(pacientId, numePacient, prenumePacient, CNP, Telefon, Adresa);

                dbFunctions.RefreshPacientiData(listView_Pacienti);

                ClearInputControls();
                MessageBox.Show("Pacientul a fost modificat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region// ----- [METODA-BUTON] - CAUTA PACIENT ----- //
        private void btn_Pac_Cauta_Click(object sender, EventArgs e)
        {
            // Get the search criteria from the textBox_P_Nume
            string nume = textBox_Pac_Nume.Text.Trim();
            string prenume = textBox_Pac_Prenume.Text.Trim();
            string cnp = textBox_Pac_CNP.Text.Trim();
            string telefon = textBox_Pac_Telefon.Text.Trim();
            string adresa = textBox_Pac_Adresa.Text.Trim();
            // Pass the search criteria to the method to perform the search
            dbFunctions.SearchPacientsAndUpdateUI(listView_Pacienti, nume, prenume, cnp, telefon, adresa);
        }
        #endregion
        #region // ----- [METODA-BUTON] - Refresh LISTA PACIENTI ----- //
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dbFunctions.RefreshPacientiData(listView_Pacienti);
            ClearInputControls();
        }
        #endregion
        #region// ----- [METODA-BUTON] - CURATARE TEXTBOX ----- //
        private void btn_Pac_Clear_Click(object sender, EventArgs e)
        {
            ClearInputControls();
        }
        private void ClearInputControls()
        {
            textBox_Pac_Nume.Text = string.Empty;
            textBox_Pac_Prenume.Text = string.Empty;
            textBox_Pac_CNP.Text = string.Empty;
            textBox_Pac_Telefon.Text = string.Empty;
            textBox_Pac_Adresa.Text = string.Empty;
        }
        #endregion

        #region // ----- *[METODA] - UPDATE celelalte view-uri deschise in acelasi timp ----- //
        private void DbFunctions_PacientUpdated(object sender, EventArgs e)
        {
            dbFunctions.RefreshPacientiData(listView_Pacienti);
            DbFunctions.OnRefreshData(EventArgs.Empty);
        }
        private void DbFunctions_PacientDeleted(object sender, EventArgs e)
        {
            dbFunctions.RefreshPacientiData(listView_Pacienti);
            DbFunctions.OnRefreshData(EventArgs.Empty);
        }
        private void DbFunctions_PacientAdded(object sender, EventArgs e)
        {
            dbFunctions.RefreshPacientiData(listView_Pacienti);
            DbFunctions.OnRefreshData(EventArgs.Empty);
        }
        #endregion
        #region // ----- *[METODA] - UPDATE la view PROGRAMARI deschis in acelasi timp cu PACIENTI ----- //
        private void DbFunctions_RefreshData(object sender, EventArgs e)
        {
            // Handle the event, for example, refresh Pacienti data
            dbFunctions.RefreshPacientiData(listView_Pacienti);
            // Add any other necessary refresh logic for Programari or other components
        }
        #endregion

    }
}
