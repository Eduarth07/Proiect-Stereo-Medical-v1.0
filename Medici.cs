using System;
using System.Globalization;
using System.Windows.Forms;

namespace stereomedical
{
    public partial class Medici : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\eduar\Desktop\Proiect Stereo Medical v7 Beta\Database1.mdf"";Integrated Security=True";
        private DbFunctions dbFunctions;
        public Medici()
        {
            InitializeComponent();
            dbFunctions = new DbFunctions(connectionString); // Creare obiect pentru utilizarea metodelor din DbFunctii
            LoadMediciData();
            DbFunctions.MedicUpdated += DbFunctions_MedicUpdated;
            DbFunctions.MedicDeleted += DbFunctions_MedicDeleted;
            DbFunctions.MedicAdded += DbFunctions_MedicAdded;
        }
        #region// ----- [METODA] - POPULEAZA LISTA DE MEDICI ----- //
        private void LoadMediciData()
        {
            try
            {
                dbFunctions.LoadMediciData(listView_Medici);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region// ----- [METODA] - POPULEAZA TEXTBOX LA SELECTARE DIN LISTA ----- //
        private void listView_Medici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Medici.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView_Medici.SelectedItems[0];

                string[] numePrenume = selectedItem.SubItems[0].Text.Split(' ');
                string nume = numePrenume.Length > 0 ? numePrenume[1] : string.Empty;
                string prenume = numePrenume.Length > 1 ? numePrenume[2] : string.Empty;

                textBox_M_Nume.Text = nume;
                textBox_M_Prenume.Text = prenume;
                textBox_M_Specialitate.Text = selectedItem.SubItems[1].Text;
                textBox_M_Grad.Text = selectedItem.SubItems[2].Text;

                string program = selectedItem.SubItems[3].Text;
                string[] times = program.Split('-');

                if (times.Length == 2)
                {
                    textBox_M_OraInceput.Text = times[0].Trim();
                    textBox_M_OraSfarsit.Text = times[1].Trim();
                }

            }
        }
        #endregion

        #region// ----- [METODA-BUTON] - ADAUGA MEDIC ----- //
        private void btn_M_Adauga_Click(object sender, EventArgs e)
        {
            try
            {
                string numeMedic = textBox_M_Nume.Text;
                string prenumeMedic = textBox_M_Prenume.Text;
                string Specialitate = textBox_M_Specialitate.Text;
                string Grad = textBox_M_Grad.Text;

                if (string.IsNullOrWhiteSpace(numeMedic) || string.IsNullOrWhiteSpace(prenumeMedic))
                {
                    MessageBox.Show("Obligatoriu: Numele si prenume medicului.", "ATENTIONARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dbFunctions.IsMedicAlreadyExists(numeMedic, prenumeMedic)) // Verificare daca exista deja medicul in baza de date
                {
                    MessageBox.Show("Acest medic există deja în baza de date.", "ATENTIONARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Convert string in TimeSpan
                if (!TimeSpan.TryParse(textBox_M_OraInceput.Text, out TimeSpan oraInceput) ||
                    !TimeSpan.TryParse(textBox_M_OraSfarsit.Text, out TimeSpan oraSfarsit))
                {
                    MessageBox.Show("Obligatoriu: Programul medicului.", "ATENTIONARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (oraInceput == TimeSpan.Zero || oraSfarsit == TimeSpan.Zero)
                {
                    MessageBox.Show("Obligatoriu: Programul medicului.", "ATENTIONARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dbFunctions.AddMedic(numeMedic, prenumeMedic, Specialitate, Grad, oraInceput, oraSfarsit);

                // Goleste textbox-urile
                dbFunctions.RefreshMediciData(listView_Medici);
                ClearInputControls();
                MessageBox.Show("Medicul a fost adaugat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region// ----- [METODA-BUTON] - MODIFICA MEDIC ----- //
        private void btn_M_Modifica_Click(object sender, EventArgs e)
        {
            try
            {
                int medicId = Convert.ToInt32(listView_Medici.SelectedItems[0].Tag);
                string numeMedic = textBox_M_Nume.Text;
                string prenumeMedic = textBox_M_Prenume.Text;
                string Specialitate = textBox_M_Specialitate.Text;
                string Grad = textBox_M_Grad.Text;
                TimeSpan oraInceput = TimeSpan.Parse(textBox_M_OraInceput.Text);
                TimeSpan oraSfarsit = TimeSpan.Parse(textBox_M_OraSfarsit.Text);

                dbFunctions.UpdateMedic(medicId, numeMedic, prenumeMedic, Specialitate, Grad, oraInceput, oraSfarsit);

                dbFunctions.RefreshMediciData(listView_Medici);
                ClearInputControls();
                MessageBox.Show("Medicul a fost modificat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region// ----- [METODA-BUTON] - STERGE MEDIC ----- //
        private void btn_M_Sterge_Click(object sender, EventArgs e)
        {
            int medicId = Convert.ToInt32(listView_Medici.SelectedItems[0].Tag);
            dbFunctions.DeleteMedic(medicId);

            dbFunctions.RefreshMediciData(listView_Medici);
            ClearInputControls();
        }
        #endregion
        #region // ----- [METODA-BUTON] - Refresh LISTA MEDICI ----- //
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dbFunctions.RefreshMediciData(listView_Medici);
            ClearInputControls();
        }
        #endregion
        #region// ----- [METODA-BUTON] - CAUTA MEDIC ----- //
        private void btn_M_Cauta_Click(object sender, EventArgs e)
        {
            string nume = textBox_M_Nume.Text.Trim();
            string prenume = textBox_M_Prenume.Text.Trim();
            string specialitate = textBox_M_Specialitate.Text.Trim();
            string grad = textBox_M_Grad.Text.Trim();
            string oraInceputStr = textBox_M_OraInceput.Text.Trim();
            string oraSfarsitStr = textBox_M_OraSfarsit.Text.Trim();

            // Convert in TimeSpan (din string)
            TimeSpan? oraInceput = ConvertToTimeSpan(oraInceputStr); // Metoda pentru convert din string in TimeSpan
            TimeSpan? oraSfarsit = ConvertToTimeSpan(oraSfarsitStr);

            dbFunctions.SearchMediciAndUpdateUI(listView_Medici, nume, prenume, specialitate, grad, oraInceput, oraSfarsit);
        }

        private TimeSpan? ConvertToTimeSpan(string timeString)
        {
            if (int.TryParse(timeString, out int hour))
            {
                return new TimeSpan(hour, 0, 0);
            }

            if (TimeSpan.TryParse(timeString, out var result))
            {
                return result;
            }
            // Return null dacă nu se poate face conversia
            return null;
        }
        #endregion
        #region// ----- [METODA-BUTON] - CURATARE TEXTBOX & [METODA] CURATARE TEXTBOX ----- //
        private void btn_M_Clear_Click(object sender, EventArgs e)
        {
            ClearInputControls();
        }
        private void ClearInputControls()
        {
            textBox_M_Nume.Text = string.Empty;
            textBox_M_Prenume.Text = string.Empty;
            textBox_M_Specialitate.Text = string.Empty;
            textBox_M_Grad.Text = string.Empty;
            textBox_M_OraInceput.Text = string.Empty;
            textBox_M_OraSfarsit.Text = string.Empty;
        }
        #endregion

        #region // ----- *[METODA] - UPDATE celelalte view-uri deschise in acelasi timp ----- //
        private void DbFunctions_MedicUpdated(object sender, EventArgs e)
        {
            dbFunctions.RefreshMediciData(listView_Medici);
        }
        private void DbFunctions_MedicDeleted(object sender, EventArgs e)
        {
            dbFunctions.RefreshMediciData(listView_Medici);
        }
        private void DbFunctions_MedicAdded(object sender, EventArgs e)
        {
            dbFunctions.RefreshMediciData(listView_Medici);
        }
        #endregion
    }
}
