using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace stereomedical
{
    public partial class Tab_Programari : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\eduar\Desktop\Proiect Stereo Medical v7 Beta\Database1.mdf"";Integrated Security=True";
        private DbFunctions dbFunctions;
        public Tab_Programari()
        {
            InitializeComponent();
            dbFunctions = new DbFunctions(connectionString); // Creare obiect pentru utilizarea metodelor din DbFunctii
            LoadProgramariData();
            PopulateMediciComboBox();
            PopulateHourComboBox();
            dateTimePicker_Data.Value = DateTime.Now;
            DbFunctions.ProgramareUpdated += DbFunctions_ProgramareUpdated;
            DbFunctions.ProgramareDeleted += DbFunctions_ProgramareDeleted;
            DbFunctions.ProgramareAdded += DbFunctions_ProgramareAdded;
            DbFunctions.RefreshData += DbFunctions_RefreshData;
        }
        #region// ----- [METODA] - POPULEAZA LISTA DE PROGRAMARI ----- //
        private void LoadProgramariData()
        {
            try
            {
                dbFunctions.LoadProgramariData(listView_Programari);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region// ----- [METODA] - POPULEAZA TEXTBOX LA SELECTARE PROGRAMARE ----- //
        private void listView_Programari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Programari.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView_Programari.SelectedItems[0];

                string[] numePrenume = selectedItem.SubItems[0].Text.Split(' ');
                string nume = numePrenume.Length > 0 ? numePrenume[0] : string.Empty;
                string prenume = numePrenume.Length > 1 ? numePrenume[1] : string.Empty;

                textBox_P_Nume.Text = nume;
                textBox_P_Prenume.Text = prenume;
                textBox_P_Telefon.Text = selectedItem.SubItems[2].Text;

                string[] numePrenumeMedic = selectedItem.SubItems[3].Text.Split(' ');
                string numeMedic = numePrenumeMedic.Length > 2 ? numePrenumeMedic[2] : string.Empty;
                string prenumeMedic = numePrenumeMedic.Length > 1 ? numePrenumeMedic[1] : string.Empty;

                // Verifica daca medicul este in ComboBox
                int indexOfMedic = comboBox_Medici.FindStringExact(prenumeMedic + " " + numeMedic);
                comboBox_Medici.SelectedIndex = indexOfMedic;

                string dateTimeString = selectedItem.SubItems[1].Text;

                if (DateTime.TryParseExact(dateTimeString, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
                {
                    // Set the date part of the DateTimePicker
                    dateTimePicker_Data.Value = parsedDateTime.Date;

                    // Set the selected hour in the comboBox_P_Ora
                    string selectedHour = parsedDateTime.ToString("HH:mm");
                    if (comboBox_P_Ora.Items.Contains(selectedHour))
                    {
                        comboBox_P_Ora.SelectedItem = selectedHour;
                    }
                    else
                    {
                        // Handle the case where the parsed hour is not in the ComboBox items
                        // You may want to add it to the ComboBox or handle it differently
                    }
                }
                else
                {
                    // Set default values if parsing fails
                    dateTimePicker_Data.Value = DateTime.Now.Date;
                    comboBox_P_Ora.SelectedIndex = -1; // Assuming you want to clear the selection in the ComboBox
                }


                bool confirmareValue = (selectedItem.SubItems[4].Text == "Da");
                checkBox_P_Confirmat.Checked = confirmareValue;
            }
        }
        #endregion

        #region// ----- [METODA-BUTON] - ADAUGARE PROGRAMARE ----- //

        private void btn_P_Adauga_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_P_Nume.Text) ||
                   string.IsNullOrWhiteSpace(textBox_P_Prenume.Text) ||
                   string.IsNullOrWhiteSpace(comboBox_Medici.SelectedItem?.ToString()) ||
                   string.IsNullOrWhiteSpace(comboBox_P_Ora.SelectedItem?.ToString()) ||
                   dateTimePicker_Data.Value == null)
                {
                    MessageBox.Show("Obligatoriu: Nume, Prenume, Medic, Data și Ora programării.", "ATENȚIONARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If the required fields are filled, proceed with adding a program
                string numePacient = textBox_P_Nume.Text;
                string prenumePacient = textBox_P_Prenume.Text;
                string telefonPacient = textBox_P_Telefon.Text;
                string numeMedic = comboBox_Medici.SelectedItem.ToString();
                string selectedHour = comboBox_P_Ora.SelectedItem.ToString();
                DateTime data = dateTimePicker_Data.Value.Date.Add(TimeSpan.Parse(selectedHour));
                bool confirmat = checkBox_P_Confirmat.Checked;
                
                int selectedMedicId = dbFunctions.GetMedicIdByName(numeMedic);

                if (dbFunctions.ProgramareExists(selectedMedicId, data))
                {
                    MessageBox.Show("Există deja o programare la această oră!", "ATENȚIONARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dbFunctions.AddProgramare(numePacient, prenumePacient, telefonPacient, numeMedic, data, confirmat);

                // Clear the textboxes and other controls
                dbFunctions.RefreshProgramariData(listView_Programari);
                ClearInputControls();
                MessageBox.Show("Programarea a fost adaugata cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region // ----- [METODA-BUTON] - MODIFICA PROGRAMARE ----- //
        private void btn_P_Modifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_P_Nume.Text) ||
                   string.IsNullOrWhiteSpace(textBox_P_Prenume.Text) ||
                   string.IsNullOrWhiteSpace(comboBox_Medici.SelectedItem?.ToString()) ||
                   string.IsNullOrWhiteSpace(comboBox_P_Ora.SelectedItem?.ToString()) ||
                   dateTimePicker_Data.Value == null)
                {
                    MessageBox.Show("Obligatoriu: Nume, Prenume, Medic, Data și Ora programării.", "ATENȚIONARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int programareId = Convert.ToInt32(listView_Programari.SelectedItems[0].Tag);
                string numePacient = textBox_P_Nume.Text;
                string prenumePacient = textBox_P_Prenume.Text;
                string telefonPacient = textBox_P_Telefon.Text;
                string numeMedic = comboBox_Medici.SelectedItem.ToString();
                string selectedHour = comboBox_P_Ora.SelectedItem.ToString();
                DateTime data = dateTimePicker_Data.Value.Date.Add(TimeSpan.Parse(selectedHour));
                bool confirmat = checkBox_P_Confirmat.Checked;

                if (IsTimeChanged(programareId, data))
                {
                    int selectedMedicId = dbFunctions.GetMedicIdByName(numeMedic);
                    if (dbFunctions.ProgramareExists(selectedMedicId, data))
                    {
                        MessageBox.Show("Programarea pentru această dată și oră există deja.", "ATENȚIONARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Update the program
                dbFunctions.UpdateProgramare(programareId, numePacient, prenumePacient, telefonPacient, numeMedic, data, confirmat);

                // Clear the textboxes and other controls
                dbFunctions.RefreshProgramariData(listView_Programari);

                ClearInputControls();
                MessageBox.Show("Programarea a fost modificata cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region // ----- [METODA-BUTON] - STERGE PROGRAMARE ----- //
        private void btn_P_Sterge_Click(object sender, EventArgs e)
        {
            int programareId = Convert.ToInt32(listView_Programari.SelectedItems[0].Tag);
            dbFunctions.DeleteProgramare(programareId);

            // Refresh the programari data after deletion
            dbFunctions.RefreshProgramariData(listView_Programari);
            ClearInputControls();
        }
        #endregion
        #region // ----- [METODA-BUTON] - REFRESH PROGRAMARI ----- //
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dbFunctions.RefreshProgramariData(listView_Programari);
            ClearInputControls();
            PopulateHourComboBox();
        }
        #endregion
        #region // ----- [METODA-BUTON] - CAUTA PROGRAMARE ----- //
        private void btn_P_Cauta_Click(object sender, EventArgs e)
        {
            // Get search parameters from your UI controls
            string numePacient = textBox_P_Nume.Text;
            string prenumePacient = textBox_P_Prenume.Text;
            string telefonPacient = textBox_P_Telefon.Text;

            string selectedHour = comboBox_P_Ora.SelectedItem != null ? comboBox_P_Ora.SelectedItem.ToString() : null;
            string numeMedic = comboBox_Medici.SelectedItem != null ? comboBox_Medici.SelectedItem.ToString() : null;
            DateTime data = (dateTimePicker_Data.Checked) ? dateTimePicker_Data.Value : DateTime.Now;
            bool? confirmat = (checkBox_P_Confirmat.Checked) ? (bool?)checkBox_P_Confirmat.Checked : null;

            // Call the search method
            dbFunctions.SearchProgramariAndUpdateUI(listView_Programari, numePacient, prenumePacient, telefonPacient, numeMedic, data, selectedHour, confirmat);
        }
        #endregion
        #region// ----- [METODA-BUTON] - CURATARE TEXTBOX & COMBOBOX ----- //
        private void ClearInputControls()
        {
            textBox_P_Nume.Text = string.Empty;
            textBox_P_Prenume.Text = string.Empty;
            textBox_P_Telefon.Text = string.Empty;
            comboBox_Medici.SelectedIndex = -1;
            dateTimePicker_Data.Value = DateTime.Now;
            comboBox_P_Ora.SelectedIndex = -1;
            checkBox_P_Confirmat.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputControls();
            PopulateHourComboBox();
        }
        #endregion

        #region// ----- *[METODA] - Populaeaza Combo Box - Ore disponibile medic ----- //
        private void PopulateAvailableHours(int selectedMedicId)
        {
            // Call the method to get available hours for the selected medic
            List<string> availableHours = dbFunctions.GetAvailableHoursForMedic(selectedMedicId);

            comboBox_P_Ora.Items.Clear();

            // Add the retrieved available hours to the ComboBox
            foreach (string hour in availableHours)
            {
                comboBox_P_Ora.Items.Add(hour);
            }
        }

        private void comboBox_Medici_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected medic's Id from the database
            if (comboBox_Medici.SelectedItem != null)
            {
                string selectedMedicName = comboBox_Medici.SelectedItem.ToString();
                int selectedMedicId = dbFunctions.GetMedicIdByName(selectedMedicName);

                // Call the method to populate available hours when the selected medic changes
                PopulateAvailableHours(selectedMedicId);
            }
        }
        #endregion
        #region// ----- *[METODA] - Populare Combo Box - Medici ----- //
        private void PopulateMediciComboBox()
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    myCon.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT CONCAT(Nume, ' ', Prenume) AS NumeMedic FROM Medici", myCon))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox_Medici.Items.Add(reader["NumeMedic"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", "Eoare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region // ----- *[METODA] - Populeaza Combo Box Ore - (Default/Neselectat) ----- //
        private void PopulateHourComboBox()
        {
            // Clear existing items
            comboBox_P_Ora.Items.Clear();

            // Start and end hours
            int startHour = 7;
            int endHour = 20;

            // Loop through each hour and add half-hour intervals
            for (int hour = startHour; hour <= endHour; hour++)
            {
                comboBox_P_Ora.Items.Add(hour.ToString("00") + ":00");
                comboBox_P_Ora.Items.Add(hour.ToString("00") + ":30");
            }
        }
        #endregion
        #region// ----- *[METODA] - Verificare daca timpul este modificat ----- //
        private bool IsTimeChanged(int programareId, DateTime newData)
        {
            DateTime oldData = dbFunctions.GetProgramDataById(programareId); // Metoda pentru a obtine data din baza de date

            // Compare the time parts only
            return oldData.TimeOfDay != newData.TimeOfDay;
        }
        #endregion
        #region // ----- *[METODA] - UPDATE celelalte view-uri deschise in acelasi timp ----- //
        private void DbFunctions_ProgramareUpdated(object sender, EventArgs e)
        {
            dbFunctions.RefreshProgramariData(listView_Programari);
            DbFunctions.OnRefreshData(EventArgs.Empty);
        }
        private void DbFunctions_ProgramareDeleted(object sender, EventArgs e)
        {
            dbFunctions.RefreshProgramariData(listView_Programari);
            DbFunctions.OnRefreshData(EventArgs.Empty);
        }
        private void DbFunctions_ProgramareAdded(object sender, EventArgs e)
        {
            dbFunctions.RefreshProgramariData(listView_Programari);
            DbFunctions.OnRefreshData(EventArgs.Empty);

        }
        #endregion
        #region // ----- *[METODA] - UPDATE la view PACIENTI deschis in acelasi timp cu PROGRAMARI ----- //
        private void DbFunctions_RefreshData(object sender, EventArgs e)
        {
            dbFunctions.RefreshProgramariData(listView_Programari);
        }
        #endregion

    }
}