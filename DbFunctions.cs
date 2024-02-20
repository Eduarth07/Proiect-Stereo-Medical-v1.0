using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace stereomedical
{
    internal class DbFunctions
    {
        private readonly string connectionString;
        public DbFunctions(string connectionString)
        {
            this.connectionString = connectionString;

        }
        // ******************  PROGRAMARI  ****************** //

        #region //-----  INCARCA LISTA PROGRAMARI ----- //
        public void LoadProgramariData(ListView listView_Programari)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    myCon.Open();

                    DataSet dsProgramari = new DataSet();

                    using (SqlDataAdapter daProgramari = new SqlDataAdapter(
                        "SELECT " +
                        "   P.Id AS Id, " +
                        "   CONCAT(Pac.Nume, ' ', Pac.Prenume) AS NumePacient, " +
                        "   Pac.Telefon AS TelefonPacient, " +
                        "   P.Data AS Data, " +
                        "   CONCAT('Dr. ', Med.Nume , ' ', Med.Prenume) AS NumeMedic, " +
                        "   P.Confirmat AS Confirmare " +
                        "FROM " +
                        "   Programari P " +
                        "JOIN " +
                        "   Pacienti Pac ON P.Nume_pacient = Pac.Id " +
                        "JOIN " +
                        "   Medici Med ON P.Nume_medic = Med.Id " +
                        "ORDER BY P.Data ASC", myCon))
                    {
                        dsProgramari.Clear();

                        daProgramari.Fill(dsProgramari, "ProgramariData");

                        listView_Programari.Items.Clear();

                        listView_Programari.Columns.Add("Nume Pacient", -2);
                        listView_Programari.Columns.Add("Data si ora", -2);
                        listView_Programari.Columns.Add("Telefon", -2);
                        listView_Programari.Columns.Add("Medic", -2);
                        listView_Programari.Columns.Add("Confirmat", -2);

                        foreach (DataRow dr in dsProgramari.Tables["ProgramariData"].Rows)
                        {
                            ListViewItem item = new ListViewItem(dr["NumePacient"].ToString());
                            item.SubItems.Add(((DateTime)dr["Data"]).ToString("dd.MM.yyyy HH:mm"));
                            item.SubItems.Add(dr["TelefonPacient"].ToString());
                            item.SubItems.Add(dr["NumeMedic"].ToString());
                            bool confirmareValue = (bool)dr["Confirmare"];
                            item.SubItems.Add(confirmareValue ? "Da" : "Nu");

                            item.Tag = dr["Id"];

                            listView_Programari.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        #region // ----- REFRESH LISTA PROGRAMARI ----- //
        public void RefreshProgramariData(ListView listView_Programari)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();

                DataSet dsProgramari = new DataSet();

                using (SqlDataAdapter daProgramari = new SqlDataAdapter(
                    "SELECT " +
                    "   P.Id AS Id, " +
                    "   CONCAT(Pac.Nume, ' ', Pac.Prenume) AS NumePacient, " +
                    "   Pac.Telefon AS TelefonPacient, " +
                    "   P.Data AS Data, " +
                    "   CONCAT('Dr. ', Med.Nume , ' ', Med.Prenume) AS NumeMedic, " +
                    "   P.Confirmat AS Confirmare " +
                    "FROM " +
                    "   Programari P " +
                    "JOIN " +
                    "   Pacienti Pac ON P.Nume_pacient = Pac.Id " +
                    "JOIN " +
                    "   Medici Med ON P.Nume_medic = Med.Id " +
                    "ORDER BY P.Data ASC", myCon))
                {
                    dsProgramari.Clear();

                    daProgramari.Fill(dsProgramari, "ProgramariData");

                    listView_Programari.Items.Clear();

                    foreach (DataRow dr in dsProgramari.Tables["ProgramariData"].Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["NumePacient"].ToString());
                        item.SubItems.Add(((DateTime)dr["Data"]).ToString("dd.MM.yyyy HH:mm"));
                        item.SubItems.Add(dr["TelefonPacient"].ToString());
                        item.SubItems.Add(dr["NumeMedic"].ToString());
                        bool confirmareValue = (bool)dr["Confirmare"];
                        item.SubItems.Add(confirmareValue ? "Da" : "Nu");

                        item.Tag = dr["Id"];

                        listView_Programari.Items.Add(item);
                    }
                }
                myCon.Close();
            }
        }

        #endregion

        #region//-----  ADAUGARE PROGRAMARE ----- //
        public void AddProgramare(string numePacient, string prenumePacient, string telefonPacient, string numeMedic, DateTime data, bool confirmat)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();
                SqlTransaction transaction = myCon.BeginTransaction();

                try
                {
                    int pacientId = GetOrCreatePacientId(myCon, transaction, numePacient, prenumePacient, telefonPacient);
                    int medicId = GetOrCreateMedicId(myCon, transaction, numeMedic);

                    SqlCommand command = new SqlCommand(
                        "INSERT INTO Programari(Id, Nume_pacient, Nume_medic, Data, Confirmat) " +
                        "VALUES((SELECT ISNULL(MAX(Id), 0) + 1 FROM Programari), @Nume_pacient, @Nume_medic, @Data, @Confirmat);",
                        myCon, transaction);

                    command.Parameters.AddWithValue("@Nume_pacient", pacientId);
                    command.Parameters.AddWithValue("@Nume_medic", medicId);
                    command.Parameters.AddWithValue("@Data", data);
                    command.Parameters.AddWithValue("@Confirmat", confirmat);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                    OnItemAdded<Tab_Programari>(EventArgs.Empty, ProgramareAdded);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myCon.Close();
                }
            }
        }
        #endregion
        #region//-----  STERGE PROGRAMARE ----- //
        public void DeleteProgramare(int programareId)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();
                SqlTransaction transaction = myCon.BeginTransaction();

                try
                {
                    SqlDataAdapter adUniv = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("DELETE FROM Programari WHERE Id = @id", myCon, transaction);
                    command.Parameters.Add("@id", SqlDbType.Int).Value = programareId;
                    adUniv.DeleteCommand = command;
                    adUniv.DeleteCommand.ExecuteNonQuery();

                    transaction.Commit();
                    OnItemDeleted<Tab_Programari>(EventArgs.Empty, ProgramareDeleted);
                    MessageBox.Show("Programarea a fost ștearsă cu succes!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myCon.Close();
                }
            }
        }
        #endregion
        #region//-----  MODIFICA PROGRAMARE ----- //
        public void UpdateProgramare(int programareId, string numePacient, string prenumePacient, string telefonPacient, string numeMedic, DateTime data, bool confirmat)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();
                SqlTransaction transaction = myCon.BeginTransaction();

                try
                {
                    
                    int pacientId = GetOrCreatePacientId(myCon, transaction, numePacient, prenumePacient, telefonPacient);
                    int medicId = GetOrCreateMedicId(myCon, transaction, numeMedic);

                    SqlCommand command = new SqlCommand(
                "UPDATE Programari SET Nume_pacient=@Nume_pacient, Nume_medic=@Nume_medic, Data=@Data, Confirmat=@Confirmat WHERE Id=@Id;",
                myCon, transaction);

                    command.Parameters.Add("@Id", SqlDbType.Int).Value = programareId;
                    command.Parameters.AddWithValue("@Nume_pacient", pacientId);
                    command.Parameters.AddWithValue("@Nume_medic", medicId);
                    command.Parameters.AddWithValue("@Data", data);
                    command.Parameters.AddWithValue("@Confirmat", confirmat);

                    command.ExecuteNonQuery();


                    SqlCommand updateTelefonCommand = new SqlCommand(
               "UPDATE Pacienti SET Telefon=@Telefon_pacient WHERE Id=@PacientId;",
               myCon, transaction);

                    updateTelefonCommand.Parameters.AddWithValue("@PacientId", pacientId);
                    updateTelefonCommand.Parameters.AddWithValue("@Telefon_pacient", telefonPacient);

                    updateTelefonCommand.ExecuteNonQuery();

                    transaction.Commit();
                    OnItemUpdated<Tab_Programari>(EventArgs.Empty, ProgramareUpdated);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myCon.Close();
                }
            }
        }
        #endregion
        #region// ----- CAUTA PROGRAMARE ----- //
        public void SearchProgramariAndUpdateUI(ListView listView_Programari, string numePacient, string prenumePacient, string telefonPacient, string numeMedic, DateTime? data, string selectedHour, bool? confirmat)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    myCon.Open();

                    DataSet dsProgramari = new DataSet();
                    int? hour = null;

                    if (!string.IsNullOrEmpty(selectedHour))
                    {
                        // Assuming selectedHour is in the format "HH:mm"
                        hour = DateTime.Parse(selectedHour).Hour;
                    }

                    string query = "SELECT " +
                        "   P.Id AS Id, " +
                        "   CONCAT(Pac.Nume, ' ', Pac.Prenume) AS NumePacient, " +
                        "   Pac.Telefon AS TelefonPacient, " +
                        "   P.Data AS Data, " +
                        "   DATEPART(HOUR, P.Data) AS Hour, " +
                        "   CONCAT('Dr. ', Med.Nume , ' ', Med.Prenume) AS NumeMedic, " +
                        "   P.Confirmat AS Confirmare " +
                        "FROM " +
                        "   Programari P " +
                        "JOIN " +
                        "   Pacienti Pac ON Pac.Id = P.Nume_pacient " +
                        "JOIN " +
                        "   Medici Med ON Med.Id = P.Nume_medic " +
                        "WHERE " +
                        "   ((@NumePacient IS NULL OR CONCAT(Pac.Nume, ' ', Pac.Prenume) LIKE @NumePacient) OR (CONCAT(Pac.Nume, ' ', Pac.Prenume) = '')) AND " +
                        "   (Pac.Telefon LIKE @TelefonPacient OR @TelefonPacient = '') AND " +
                        "   ((@NumeMedic IS NULL OR CONCAT(Med.Nume, ' ', Med.Prenume) LIKE @NumeMedic) OR (CONCAT(Med.Nume, ' ', Med.Prenume) = '')) AND " +
                        "   (P.Data >= @Data) AND " +
                        "   ((@Hour IS NULL) OR (DATEPART(HOUR, P.Data) = @Hour)) AND " +
                        "   (@Confirmat IS NULL OR P.Confirmat = @Confirmat OR (P.Confirmat IS NULL AND @Confirmat IS NULL)) ";

                    using (SqlDataAdapter daProgramari = new SqlDataAdapter(query, myCon))
                    {
                        daProgramari.SelectCommand.Parameters.AddWithValue("@NumePacient", "%" + numePacient + "%");
                        daProgramari.SelectCommand.Parameters.AddWithValue("@PrenumePacient", "%" + prenumePacient + "%");
                        daProgramari.SelectCommand.Parameters.AddWithValue("@TelefonPacient", "%" + telefonPacient + "%");
                        daProgramari.SelectCommand.Parameters.AddWithValue("@NumeMedic", numeMedic ?? (object)DBNull.Value);
                        daProgramari.SelectCommand.Parameters.AddWithValue("@Data", data ?? (object)DBNull.Value);
                        daProgramari.SelectCommand.Parameters.AddWithValue("@Hour", hour ?? (object)DBNull.Value);
                        daProgramari.SelectCommand.Parameters.AddWithValue("@Confirmat", confirmat ?? (object)DBNull.Value);

                        Console.WriteLine("SQL Query: " + daProgramari.SelectCommand.CommandText);
                        Console.WriteLine($"Parameter values - @NumePacient: {daProgramari.SelectCommand.Parameters["@NumePacient"].Value}");
                        Console.WriteLine($"Parameter values - @PrenumePacient: {daProgramari.SelectCommand.Parameters["@PrenumePacient"].Value}");
                        Console.WriteLine($"Parameter values - @TelefonPacient: {daProgramari.SelectCommand.Parameters["@TelefonPacient"].Value}");
                        Console.WriteLine($"Parameter values - @NumeMedic: {daProgramari.SelectCommand.Parameters["@NumeMedic"].Value}");
                        Console.WriteLine($"Parameter values - @Data: {daProgramari.SelectCommand.Parameters["@Data"].Value}");
                        Console.WriteLine($"Parameter values - @Confirmat: {daProgramari.SelectCommand.Parameters["@Confirmat"].Value}");
                        Console.WriteLine($"Parameter values - @Hour: {daProgramari.SelectCommand.Parameters["@Hour"].Value}");

                        dsProgramari.Clear();
                        daProgramari.Fill(dsProgramari, "ProgramariData");
                        Console.WriteLine($"Number of rows retrieved: {dsProgramari.Tables["ProgramariData"].Rows.Count}");
                        listView_Programari.Items.Clear();

                        foreach (DataRow dr in dsProgramari.Tables["ProgramariData"].Rows)
                        {
                            ListViewItem item = new ListViewItem(dr["NumePacient"].ToString());
                            item.SubItems.Add(((DateTime)dr["Data"]).ToString("dd.MM.yyyy HH:mm"));
                            item.SubItems.Add(dr["TelefonPacient"].ToString());
                            item.SubItems.Add(dr["NumeMedic"].ToString());
                            bool confirmareValue = (bool)dr["Confirmare"];
                            item.SubItems.Add(confirmareValue ? "Da" : "Nu");

                            item.Tag = dr["Id"];

                            listView_Programari.Items.Add(item);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region// ----- GET or CREATE ID PACIENT & MEDIC -----//
        private int GetOrCreatePacientId(SqlConnection connection, SqlTransaction transaction, string nume, string prenume, string telefon)
        {
            using (SqlCommand checkPacientCommand = new SqlCommand(
                "SELECT Id FROM Pacienti WHERE CONCAT(Nume, ' ', Prenume) = @NumePacient",
                connection, transaction))
            {
                checkPacientCommand.Parameters.AddWithValue("@NumePacient", $"{nume} {prenume}");

                object pacientIdObj = checkPacientCommand.ExecuteScalar();
                if (pacientIdObj != null && int.TryParse(pacientIdObj.ToString(), out int pacientId))
                {
                    // Pacient already exists
                    return pacientId;
                }
                else
                {
                    using (SqlCommand insertPacientCommand = new SqlCommand(
                        "INSERT INTO Pacienti(Id, Nume, Prenume, Telefon) " +
                        "OUTPUT INSERTED.Id VALUES((SELECT ISNULL(MAX(Id), 0) + 1 FROM Pacienti), @Nume, @Prenume, @Telefon)",
                        connection, transaction))
                    {
                        insertPacientCommand.Parameters.AddWithValue("@Nume", nume);
                        insertPacientCommand.Parameters.AddWithValue("@Prenume", prenume);
                        insertPacientCommand.Parameters.AddWithValue("@Telefon", telefon);
                        // Retrieve the generated Id using ExecuteScalar
                        return (int)insertPacientCommand.ExecuteScalar();
                    }
                }
            }
        }

        private int GetOrCreateMedicId(SqlConnection connection, SqlTransaction transaction, string numeMedic)
        {
            using (SqlCommand checkMedicCommand = new SqlCommand(
                "SELECT Id FROM Medici WHERE CONCAT(Nume, ' ', Prenume) = @NumeMedic",
                connection, transaction))
            {
                checkMedicCommand.Parameters.AddWithValue("@NumeMedic", numeMedic);

                object medicIdObj = checkMedicCommand.ExecuteScalar();
                if (medicIdObj != null && int.TryParse(medicIdObj.ToString(), out int medicId))
                {
                    // Medic already exists
                    return medicId;
                }
                else
                {
                    // Medic does not exist, handle accordingly (e.g., show an error message)
                    MessageBox.Show("Medic does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1; // You might want to choose a better default value or handle it differently
                }
            }
        }
        #endregion
        #region// ----- CAUTA ORE VALABILE PENTRU MEDIC ( ORA-INCPEUT-...-ORA-SFARSIT) ----- //
        // Metoda pentru a obtine orele valabile pentru programare pentru un anumit medic
        public List<string> GetAvailableHoursForMedic(int medicId)
        {
            List<string> availableHours = new List<string>();

            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT Ora_inceput, Ora_sfarsit FROM Medici WHERE Id = @Id", myCon))
                {
                    cmd.Parameters.AddWithValue("@Id", medicId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Obtine program de lucru intre ora de inceput si ora de sfarsit
                            TimeSpan oraInceput = reader.GetTimeSpan(0);
                            TimeSpan oraSfarsit = reader.GetTimeSpan(1);

                            // Generare ore cuprinse intre oraInceput si oraSfarsit
                            while (oraInceput < oraSfarsit)
                            {
                                string currentHour = oraInceput.ToString("hh\\:mm");
                                availableHours.Add(currentHour);
                                oraInceput = oraInceput.Add(TimeSpan.FromMinutes(30));
                            }
                        }
                    }
                }
            }

            return availableHours;
        }
        #endregion
        #region // ----- VERIFICARE EXISTENTA PROGRAMRE ----- //
        public bool ProgramareExists(int medicId, DateTime data)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();

                // Verifica daca exista deja o programare in aceasta data si ora pentru un anumit medic
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Programari WHERE Nume_medic = @MedicId AND Data = @Data", myCon))
                {
                    cmd.Parameters.AddWithValue("@MedicId", medicId);
                    cmd.Parameters.AddWithValue("@Data", data);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        #endregion
        #region // ----- OBTINE DATA DIN TABELUL PROGRAMARI ----- //
        // Metoda pentru a obtine data din baza de date
        public DateTime GetProgramDataById(int programareId)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Data FROM Programari WHERE Id = @ProgramareId", myCon))
                {
                    cmd.Parameters.AddWithValue("@ProgramareId", programareId);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToDateTime(result);
                    }
                }
            }

            // Return a default value or handle the case where the program is not found
            return DateTime.MinValue;
        }
        #endregion
        #region // ----- OBTINE NUME COMPLET MEDIC ----- //
        // Obtinere nume medic in baza Id-ului
        public int GetMedicIdByName(string medicName)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT Id FROM Medici WHERE CONCAT(Nume, ' ', Prenume) = @MedicName", myCon))
                {
                    cmd.Parameters.AddWithValue("@MedicName", medicName);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            return -1; // Return a default value or handle the case where the medic is not found
        }
        #endregion

        // ******************  MEDICI  ****************** //

        #region// ----- INCARCA LISTA MEDICI ----- //
        public void LoadMediciData(ListView listView_Medici)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    myCon.Open();

                    DataSet dsMedici = new DataSet();

                    using (SqlDataAdapter daMedici = new SqlDataAdapter(
                    "SELECT " +
                    "   M.Id AS Id, " +
                    "   CONCAT('Dr. ', M.Nume, ' ', M.Prenume) AS NumeMedic, " +
                    "   M.Specialitate AS Specialitate, " +
                    "   M.Grad AS Grad, " +
                    "   M.Ora_inceput AS Ora_inceput, " +
                    "   M.Ora_sfarsit AS Ora_sfarsit " +
                    "FROM " +
                    "   Medici M ", myCon))
                    {
                        dsMedici.Clear();
                        daMedici.Fill(dsMedici, "MediciData");

                        listView_Medici.Items.Clear();

                        listView_Medici.Columns.Add("Nume ", -2);
                        listView_Medici.Columns.Add("Specialitate ", -2);
                        listView_Medici.Columns.Add("Grad ", -2);
                        listView_Medici.Columns.Add("Program", -2);

                        foreach (DataRow dr in dsMedici.Tables["MediciData"].Rows)
                        {
                            ListViewItem item = new ListViewItem(dr["NumeMedic"].ToString());
                            item.SubItems.Add(dr["Specialitate"].ToString());
                            item.SubItems.Add(dr["Grad"].ToString());

                            // Format the time values here
                            string startTime = ((TimeSpan)dr["Ora_inceput"]).ToString("hh\\:mm");
                            string endTime = ((TimeSpan)dr["Ora_sfarsit"]).ToString("hh\\:mm");
                            item.SubItems.Add($"{startTime} - {endTime}");

                            item.Tag = dr["Id"];
                            listView_Medici.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        #region // ----- REFRESH LISTA MEDICI ----- //
        public void RefreshMediciData(ListView listView_Medici)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    myCon.Open();

                    DataSet dsMedici = new DataSet();

                    using (SqlDataAdapter daMedici = new SqlDataAdapter(
                    "SELECT " +
                    "   M.Id AS Id, " +
                    "   CONCAT('Dr. ', M.Nume, ' ', M.Prenume) AS NumeMedic, " +
                    "   M.Specialitate AS Specialitate, " +
                    "   M.Grad AS Grad, " +
                    "   M.Ora_inceput AS Ora_inceput, " +
                    "   M.Ora_sfarsit AS Ora_sfarsit " +
                    "FROM " +
                    "   Medici M ", myCon))
                    {
                        dsMedici.Clear();
                        daMedici.Fill(dsMedici, "MediciData");

                        listView_Medici.Items.Clear();

                        foreach (DataRow dr in dsMedici.Tables["MediciData"].Rows)
                        {
                            ListViewItem item = new ListViewItem(dr["NumeMedic"].ToString());
                            item.SubItems.Add(dr["Specialitate"].ToString());
                            item.SubItems.Add(dr["Grad"].ToString());

                            // Format the time values here
                            string startTime = ((TimeSpan)dr["Ora_inceput"]).ToString("hh\\:mm");
                            string endTime = ((TimeSpan)dr["Ora_sfarsit"]).ToString("hh\\:mm");
                            item.SubItems.Add($"{startTime} - {endTime}");

                            item.Tag = dr["Id"];
                            listView_Medici.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region// ----- ADAUGARE MEDIC ----- //
        public void AddMedic(string numeMedic, string prenumeMedic, string Specialitate, string Grad, TimeSpan oraInceput, TimeSpan oraSfarsit)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();
                SqlTransaction transaction = myCon.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand(
                        "INSERT INTO Medici(Id, Nume, Prenume, Specialitate, Grad, Ora_inceput, Ora_sfarsit) " +
                        "VALUES((SELECT ISNULL(MAX(Id), 0) + 1 FROM Medici), @Nume_medic, @Prenume_medic, @Specialitate, @Grad, @Ora_inceput, @Ora_sfarsit);",
                        myCon, transaction);

                    command.Parameters.AddWithValue("@Nume_medic", numeMedic);
                    command.Parameters.AddWithValue("@Prenume_medic", prenumeMedic);
                    command.Parameters.AddWithValue("@Specialitate", Specialitate);
                    command.Parameters.AddWithValue("@Grad", Grad);
                    command.Parameters.AddWithValue("@Ora_inceput", oraInceput);
                    command.Parameters.AddWithValue("@Ora_sfarsit", oraSfarsit);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                    OnItemAdded<Medici>(EventArgs.Empty, MedicAdded);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myCon.Close();
                }
            }
        }

        #endregion
        #region// ----- STERGE MEDIC ----- //
        public void DeleteMedic(int medicId)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();
                SqlTransaction transaction = myCon.BeginTransaction();

                try
                {
                    SqlDataAdapter adMed = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("DELETE FROM Medici WHERE Id = @id", myCon, transaction);
                    command.Parameters.Add("@id", SqlDbType.Int).Value = medicId;
                    adMed.DeleteCommand = command;
                    adMed.DeleteCommand.ExecuteNonQuery();

                    transaction.Commit();
                    OnItemDeleted<Medici>(EventArgs.Empty, MedicDeleted);
                    MessageBox.Show("Medicul a fost șters cu succes!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myCon.Close();
                }
            }
        }
        #endregion
        #region// ----- MODIFICA MEDIC ----- //
        public void UpdateMedic(int medicId, string numeMedic, string prenumeMedic, string Specialitate, string Grad, TimeSpan oraInceput, TimeSpan oraSfarsit)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();
                SqlTransaction transaction = myCon.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand(
                        "UPDATE Medici SET Nume=@Nume_medic, Prenume=@Prenume_medic, Specialitate=@Specialitate, Grad=@Grad, Ora_inceput=@Ora_inceput, Ora_sfarsit=@Ora_sfarsit WHERE Id=@Id;",
                        myCon, transaction);

                    command.Parameters.Add("@Id", SqlDbType.Int).Value = medicId;
                    command.Parameters.AddWithValue("@Nume_medic", numeMedic);
                    command.Parameters.AddWithValue("@Prenume_medic", prenumeMedic);
                    command.Parameters.AddWithValue("@Specialitate", Specialitate);
                    command.Parameters.AddWithValue("@Grad", Grad);
                    command.Parameters.AddWithValue("@Ora_inceput", oraInceput);
                    command.Parameters.AddWithValue("@Ora_sfarsit", oraSfarsit);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                    OnItemUpdated<Medici>(EventArgs.Empty, MedicUpdated);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myCon.Close();
                }
            }
        }
        #endregion
        #region// ----- CAUTA MEDIC ----- //
        public void SearchMediciAndUpdateUI(ListView listView, string nume, string prenume, string specialitate, string grad, TimeSpan? oraInceput, TimeSpan? oraSfarsit)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    myCon.Open();

                    DataSet dsMedici = new DataSet();

                    string query = "SELECT " +
                    "   M.Id AS Id, " +
                    "   CONCAT('Dr. ', M.Nume, ' ', M.Prenume) AS NumeMedic, " +
                    "   M.Specialitate AS Specialitate, " +
                    "   M.Grad AS Grad, " +
                    "   M.Ora_inceput AS Ora_inceput, " +
                    "   M.Ora_sfarsit AS Ora_sfarsit " +
                    "FROM " +
                    "   Medici M " +
                    "WHERE " +
                    "   (M.Nume LIKE @Nume OR @Nume = '') AND " +
                    "   (M.Prenume LIKE @Prenume OR @Prenume = '') AND " +
                    "   (M.Specialitate LIKE @Specialitate OR @Specialitate = '') AND " +
                    "   (M.Grad LIKE @Grad OR @Grad = '') AND " +
                    "   (@Ora_inceput IS NULL OR M.Ora_inceput >= @Ora_inceput) AND " +
                    "   (@Ora_sfarsit IS NULL OR M.Ora_sfarsit <= @Ora_sfarsit)";


                    using (SqlDataAdapter daMedici = new SqlDataAdapter(query, myCon))
                    {
                        daMedici.SelectCommand.Parameters.AddWithValue("@Nume", "%" + nume + "%");
                        daMedici.SelectCommand.Parameters.AddWithValue("@Prenume", "%" + prenume + "%");
                        daMedici.SelectCommand.Parameters.AddWithValue("@Specialitate", "%" + specialitate + "%");
                        daMedici.SelectCommand.Parameters.AddWithValue("@Grad", "%" + grad + "%");
                        daMedici.SelectCommand.Parameters.AddWithValue("@Ora_inceput", oraInceput.HasValue ? (object)oraInceput.Value : DBNull.Value);
                        daMedici.SelectCommand.Parameters.AddWithValue("@Ora_sfarsit", oraSfarsit.HasValue ? (object)oraSfarsit.Value : DBNull.Value);

                        dsMedici.Clear();
                        daMedici.Fill(dsMedici, "MediciData");

                        listView.Items.Clear();

                        foreach (DataRow dr in dsMedici.Tables["MediciData"].Rows)
                        {
                            ListViewItem item = new ListViewItem(dr["NumeMedic"].ToString());
                            item.SubItems.Add(dr["Specialitate"].ToString());
                            item.SubItems.Add(dr["Grad"].ToString());

                            // Format the time values here
                            string startTime = ((TimeSpan)dr["Ora_inceput"]).ToString("hh\\:mm");
                            string endTime = ((TimeSpan)dr["Ora_sfarsit"]).ToString("hh\\:mm");
                            item.SubItems.Add($"{startTime} - {endTime}");

                            item.Tag = dr["Id"];
                            listView.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ****************** PACIENTI  ****************** //
        #endregion

        #region// ----- VERIFICARE DACA EXISTA ACELASI MEDIC IN BAZA DE DATE ----- //
        // Verificare daca exista deja medicul in baza de date
        public bool IsMedicAlreadyExists(string Nume, string Prenume)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Medici WHERE Nume = @Nume AND Prenume = @Prenume";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nume", Nume);
                        command.Parameters.AddWithValue("@Prenume", Prenume);

                        int count = (int)command.ExecuteScalar();

                        return count > 0; 
                    }
            }
        }
        #endregion
       

        // ******************  PACIENTI  ****************** //

        #region// ----- INCARCA LISTA PACIENTI ----- //
        public void LoadPacientiData(ListView listView_Pacienti)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    myCon.Open();

                    DataSet dsPacienti = new DataSet();

                    using (SqlDataAdapter daPacienti = new SqlDataAdapter(
                    "SELECT " +
                    "   PAC.Id AS Id, " +
                    "   CONCAT(PAC.Nume, ' ', PAC.Prenume) AS NumePacient, " +
                    "   PAC.CNP AS Cnp, " +
                    "   PAC.Telefon AS Telefon, " +
                    "   PAC.Adresa AS Adresa " +
                    "FROM " +
                    "   Pacienti PAC ", myCon))
                    {
                        dsPacienti.Clear();
                        daPacienti.Fill(dsPacienti, "PacientiData");

                        listView_Pacienti.Items.Clear();

                        listView_Pacienti.Columns.Add("Nume ", -2);
                        listView_Pacienti.Columns.Add("Cnp ", -2);
                        listView_Pacienti.Columns.Add("Telefon ", -2);
                        listView_Pacienti.Columns.Add("Adresa", -2);

                        foreach (DataRow dr in dsPacienti.Tables["PacientiData"].Rows)
                        {
                            ListViewItem item = new ListViewItem(dr["NumePacient"].ToString());
                            item.SubItems.Add(dr["Cnp"].ToString());
                            item.SubItems.Add(dr["Telefon"].ToString());
                            item.SubItems.Add(dr["Adresa"].ToString());

                            item.Tag = dr["Id"];
                            listView_Pacienti.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        #region // ----- REFRESH LISTA PACIENTI ----- //
        public void RefreshPacientiData(ListView listView_Pacienti)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    myCon.Open();

                    DataSet dsPacienti = new DataSet();

                    using (SqlDataAdapter daPacienti = new SqlDataAdapter(
                    "SELECT " +
                    "   PAC.Id AS Id, " +
                    "   CONCAT(PAC.Nume, ' ', PAC.Prenume) AS NumePacient, " +
                    "   PAC.CNP AS Cnp, " +
                    "   PAC.Telefon AS Telefon, " +
                    "   PAC.Adresa AS Adresa " +
                    "FROM " +
                    "   Pacienti PAC ", myCon))
                    {
                        dsPacienti.Clear();
                        daPacienti.Fill(dsPacienti, "PacientiData");

                        listView_Pacienti.Items.Clear();

                        foreach (DataRow dr in dsPacienti.Tables["PacientiData"].Rows)
                        {
                            ListViewItem item = new ListViewItem(dr["NumePacient"].ToString());
                            item.SubItems.Add(dr["Cnp"].ToString());
                            item.SubItems.Add(dr["Telefon"].ToString());
                            item.SubItems.Add(dr["Adresa"].ToString());

                            item.Tag = dr["Id"];
                            listView_Pacienti.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region// ----- ADAUGARE PACIENT ----- //
        public void AddPacient(string numePacient, string prenumePacient, long? cnp, string telefon, string adresa)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();
                SqlTransaction transaction = myCon.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand(
                        "INSERT INTO Pacienti(Id, Nume, Prenume, CNP, Telefon, Adresa) " +
                        "VALUES((SELECT ISNULL(MAX(Id), 0) + 1 FROM Pacienti), @Nume_pacient, @Prenume_pacient, @CNP, @Telefon, @Adresa);",
                        myCon, transaction);

                    command.Parameters.AddWithValue("@Nume_pacient", numePacient);
                    command.Parameters.AddWithValue("@Prenume_pacient", prenumePacient);
                    command.Parameters.AddWithValue("@CNP", cnp ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Telefon", telefon);
                    command.Parameters.AddWithValue("@Adresa", adresa);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                    OnItemUpdated<Pacienti>(EventArgs.Empty, PacientUpdated);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myCon.Close();
                }
            }
        }

        #endregion
        #region// ----- STERGE PACIENT ----- //
        public void DeletePacient(int pacientId)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();
                SqlTransaction transaction = myCon.BeginTransaction();

                try
                {
                    SqlDataAdapter adPac = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("DELETE FROM Pacienti WHERE Id = @id", myCon, transaction);
                    command.Parameters.Add("@id", SqlDbType.Int).Value = pacientId;
                    adPac.DeleteCommand = command;
                    adPac.DeleteCommand.ExecuteNonQuery();

                    transaction.Commit();
                    OnItemDeleted<Pacienti>(EventArgs.Empty, PacientDeleted);
                    MessageBox.Show("Pacientul a fost șters cu succes!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myCon.Close();
                }
            }
        }
        #endregion
        #region// ----- MODIFICA PACIENT ----- //
        public void UpdatePacient(int pacientId, string numePacient, string prenumePacient, long? cnp, string telefon, string adresa)
        {
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                myCon.Open();
                SqlTransaction transaction = myCon.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand(
                        "UPDATE Pacienti SET Nume=@Nume_pacient, Prenume=@Prenume_pacient, CNP=@CNP, Telefon=@Telefon, Adresa=@Adresa WHERE Id=@Id;",
                        myCon, transaction);

                    command.Parameters.Add("@Id", SqlDbType.Int).Value = pacientId;
                    command.Parameters.AddWithValue("@Nume_pacient", numePacient);
                    command.Parameters.AddWithValue("@Prenume_pacient", prenumePacient);
                    command.Parameters.AddWithValue("@CNP", cnp ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Telefon", telefon);
                    command.Parameters.AddWithValue("@Adresa", adresa);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                    OnItemAdded<Pacienti>(EventArgs.Empty, PacientAdded);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myCon.Close();
                }
            }
        }
        #endregion
        #region // ----- CAUTA PACIENT ----- //
        public void SearchPacientsAndUpdateUI(ListView listView, string nume, string prenume, string cnp, string telefon, string adresa)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    myCon.Open();

                    DataSet dsPacienti = new DataSet();

                    string query = "SELECT " +
                                   "   PAC.Id AS Id, " +
                                   "   CONCAT(PAC.Nume, ' ', PAC.Prenume) AS NumePacient, " +
                                   "   PAC.CNP AS Cnp, " +
                                   "   PAC.Telefon AS Telefon, " +
                                   "   PAC.Adresa AS Adresa " +
                                   "FROM " +
                                   "   Pacienti PAC " +
                                   "WHERE " +
                                   "   (PAC.Nume LIKE @Nume OR @Nume = '') AND " +
                                   "   (PAC.Prenume LIKE @Prenume OR @Prenume = '') AND " +
                                   "   (PAC.CNP LIKE @CNP OR @CNP = '') AND " +
                                   "   (PAC.Telefon LIKE @Telefon OR @Telefon = '') AND " +
                                   "   (PAC.Adresa LIKE @Adresa OR @Adresa = '') ";


                    using (SqlDataAdapter daPacienti = new SqlDataAdapter(query, myCon))
                    {
                        daPacienti.SelectCommand.Parameters.AddWithValue("@Nume", "%" + nume + "%");
                        daPacienti.SelectCommand.Parameters.AddWithValue("@Prenume", "%" + prenume + "%");
                        daPacienti.SelectCommand.Parameters.AddWithValue("@CNP", "%" + cnp + "%");
                        daPacienti.SelectCommand.Parameters.AddWithValue("@Telefon", "%" + telefon + "%");
                        daPacienti.SelectCommand.Parameters.AddWithValue("@Adresa", "%" + adresa + "%");

                        dsPacienti.Clear();
                        daPacienti.Fill(dsPacienti, "PacientiData");

                        listView.Items.Clear();

                        foreach (DataRow dr in dsPacienti.Tables["PacientiData"].Rows)
                        {
                            ListViewItem item = new ListViewItem(dr["NumePacient"].ToString());
                            item.SubItems.Add(dr["Cnp"].ToString());
                            item.SubItems.Add(dr["Telefon"].ToString());
                            item.SubItems.Add(dr["Adresa"].ToString());

                            item.Tag = dr["Id"];
                            listView.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region // ----- VERIFICARE DACA EXISTA ACELASI CNP IN BAZA DE DATE ----- //
        public bool IsCNPAlreadyExists(long? CNP)
        {
            string query = "SELECT COUNT(*) FROM Pacienti WHERE CNP = @CNP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CNP", CNP ?? (object)DBNull.Value);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
        #endregion

        // ******************  METODE GENERALE  ****************** //

        #region// ----- FUNCTII PENTRU ACTUALIZAREA TUTUROR VIEW-URILOR DESCHISE ----- //

        public delegate void ItemUpdatedEventHandler<T>(object sender, EventArgs e);
        public delegate void ItemAddedEventHandler<T>(object sender, EventArgs e);
        public delegate void ItemDeletedEventHandler<T>(object sender, EventArgs e);

        public static event ItemUpdatedEventHandler<Pacienti> PacientUpdated;
        public static event ItemAddedEventHandler<Pacienti> PacientAdded;
        public static event ItemDeletedEventHandler<Pacienti> PacientDeleted;

        public static event ItemUpdatedEventHandler<Medici> MedicUpdated;
        public static event ItemAddedEventHandler<Medici> MedicAdded;
        public static event ItemDeletedEventHandler<Medici> MedicDeleted;

        public static event ItemUpdatedEventHandler<Tab_Programari> ProgramareUpdated;
        public static event ItemAddedEventHandler<Tab_Programari> ProgramareAdded;
        public static event ItemDeletedEventHandler<Tab_Programari> ProgramareDeleted;

        public static event EventHandler RefreshData;

        public static void OnRefreshData(EventArgs e)
        {
            RefreshData?.Invoke(null, e);
        }
        public static void OnItemUpdated<T>(EventArgs e, ItemUpdatedEventHandler<T> handler) where T : class
        {
            handler?.Invoke(null, e);
        }

        public static void OnItemAdded<T>(EventArgs e, ItemAddedEventHandler<T> handler) where T : class
        {
            handler?.Invoke(null, e);
        }

        public static void OnItemDeleted<T>(EventArgs e, ItemDeletedEventHandler<T> handler) where T : class
        {
            handler?.Invoke(null, e);
        }
#endregion

    }
}
