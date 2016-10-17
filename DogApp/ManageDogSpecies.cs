using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DogApp
{
    public partial class ManageDogSpecies : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();

        int appearanceID = 0;
        int sizeID = 0;
        int livingSpaceID = 0;
        int sheddingID = 0;
        int exerciseID = 0;
        int trainingID = 0;
        int childID = 0;
        int protectionID = 0;
        int dispositionID = 0;
        int tempramentID = 0;
        int climateID = 0;

        public ManageDogSpecies()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnPreviousTab_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnNextTab_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        public int getSpeciesTraitID(ComboBox comboBox, string sqlTable, string sqlID, string sqlName)
        {
            string sqlCommandString = "SELECT " + sqlID + " FROM " + sqlTable + " WHERE " + sqlName + " = '" + comboBox.Text + "'";
            int indexInTable;

            cmd.Connection = conn;
            cmd.CommandText = sqlCommandString;
            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                indexInTable = Convert.ToInt32(reader[sqlID].ToString());
            }
            else
            {
                indexInTable = -1;
            }

            reader.Close();
            conn.Close();

            return indexInTable;
        }

        public void setSpeciesTraitsIds()
        {
            appearanceID = getSpeciesTraitID(cbxAppearanceID,"DogAppearance","appearance_id","appearance_id");
            sizeID = getSpeciesTraitID(cbxSize, "DogSizeTypes", "size_id","size_type");
            livingSpaceID = getSpeciesTraitID(cbxLivingSpace, "LivingSpaceTypes", "livingspace_id","livingspace_type");
            sheddingID = getSpeciesTraitID(cbxShedding, "SheddingTypes", "shedding_id","shedding_type");
            exerciseID = getSpeciesTraitID(cbxExercise, "ExerciseTypes", "exercise_id","exercise_type");
            trainingID = getSpeciesTraitID(cbxTraining, "TrainingTypes", "trainingType_id","training_type");
            childID = getSpeciesTraitID(cbxChildFriendliness, "DogChildBehaviour", "childB_id", "childbehavior_type");
            protectionID = getSpeciesTraitID(cbxProtection, "ProtectionBehaviour", "protection_id","protection_type");
            dispositionID = getSpeciesTraitID(cbxDisposition, "DispositionTypes", "disposition_id","disposition_type");
            tempramentID = getSpeciesTraitID(cbxTemperament, "TempramentTypes","temprament_id","temprament_type");
            climateID = getSpeciesTraitID(cbxClimate, "ClimateTypes","climate_id","climate_type");
        }

        private void loadSpeciesCombobox()
        {
            //Species
            string getSpeciesType = "Select species_id FROM DogSpecies";
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getSpeciesType;
                conn.Open();

                reader = cmd.ExecuteReader();

                cbxSpeciesID.Items.Clear();
                cbxSpeciesID.Items.Add("**New Species**");

                while (reader.Read())
                {
                    cbxSpeciesID.Items.Add(reader["species_id"].ToString());
                }

                cbxSpeciesID.SelectedIndex = 0;

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
        }

        public void loadOtherComboxes(string sqlName, string sqlTable, ComboBox comboBox)
        {
            string getType = "Select " + sqlName + " FROM " + sqlTable;
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getType;
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox.Items.Add(reader[sqlName].ToString());
                }

                comboBox.SelectedIndex = -1;

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
        }

        public void populateSpeciesTabs()
        {
            if (cbxSpeciesID.Text == "**New Species**" || cbxSpeciesID.Text == "")
            {
                tbxSpeciesName.Text = "";
                tbxOriginCountry.Text = "";
                tbxSpeciesAge.Text = "";
                tbxLifeExpectancy.Text = "# to #";
                cbxAppearanceID.ResetText();
                cbxAppearanceID.SelectedIndex = -1;
                rtbOtherNames.Text = "";
                rtbHistory.Text = "";
                rtbAbout.Text = "";

                cbxSize.ResetText();
                cbxSize.SelectedIndex = -1;
                tbxSizeDescription.Text = "";
                cbxLivingSpace.ResetText();
                cbxLivingSpace.SelectedIndex = -1;
                tbxLivingSpaceDescription.Text = "";
                cbxShedding.ResetText();
                cbxShedding.SelectedIndex = -1;
                tbxSheddingDescription.Text = "";
                cbxExercise.ResetText();
                cbxExercise.SelectedIndex = -1;
                tbxExerciseDescription.Text = "";
                cbxTraining.ResetText();
                cbxTraining.SelectedIndex = -1;
                tbxTrainingDescription.Text = "";
                cbxChildFriendliness.ResetText();
                cbxChildFriendliness.SelectedIndex = -1;
                tbxChildDescription.Text = "";
                cbxProtection.ResetText();
                cbxProtection.SelectedIndex = -1;
                tbxProtectionDescription.Text = "";
                cbxDisposition.ResetText();
                cbxDisposition.SelectedIndex = -1;
                tbxDispositionDescription.Text = "";
                cbxTemperament.ResetText();
                cbxTemperament.SelectedIndex = -1;
                tbxTemperamentDescription.Text = "";
                cbxClimate.ResetText();
                cbxClimate.SelectedIndex = -1;
                tbxClimateDescription.Text = "";

                btnAddSpecies.Enabled = true;
                btnUpdateSpecies.Enabled = false;
                btnDeleteSpecies.Enabled = false;
            }
            else
            {
                try
                {
                    string populateSpeciesFields = "SELECT * FROM DogSpecies WHERE species_id = " + cbxSpeciesID.Text;

                    cmd.Connection = conn;
                    cmd.CommandText = populateSpeciesFields;
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        tbxSpeciesName.Text = reader["species_name"].ToString();
                        tbxOriginCountry.Text = reader["origin_country"].ToString();
                        tbxSpeciesAge.Text = reader["species_age"].ToString();
                        tbxLifeExpectancy.Text = reader["life_expectence"].ToString();
                        rtbOtherNames.Text = reader["dog_otherNames"].ToString();
                        rtbHistory.Text = reader["history_description"].ToString();
                        rtbAbout.Text = reader["about_description"].ToString();
                    }

                    reader.Close();
                    conn.Close();

                    populateAppearanceID();
                    populateSpeciesTraits(sqlCommandStringBuilder("DogSizeTypes","size_id","size_type","size_description"),"size_type","size_description",cbxSize,tbxSizeDescription);
                    populateSpeciesTraits(sqlCommandStringBuilder("LivingSpaceTypes", "livingspace_id", "livingspace_type", "livingspace_description"), "livingspace_type", "livingspace_description", cbxLivingSpace, tbxLivingSpaceDescription);
                    populateSpeciesTraits(sqlCommandStringBuilder("SheddingTypes", "shedding_id", "shedding_type", "shedding_description"), "shedding_type", "shedding_description", cbxShedding, tbxSheddingDescription);
                    populateSpeciesTraits(sqlCommandStringBuilder("ExerciseTypes", "exercise_id", "exercise_type", "exercise_description"), "exercise_type", "exercise_description", cbxExercise, tbxExerciseDescription);
                    populateSpeciesTraits(sqlCommandStringBuilder("TrainingTypes", "trainingType_id", "training_type", "training_description"), "training_type", "training_description", cbxTraining, tbxTrainingDescription);
                    populateSpeciesTraits(sqlCommandStringBuilder("DogChildBehaviour", "childB_id", "childbehavior_type", "behaviour_description"), "childbehavior_type", "behaviour_description", cbxChildFriendliness, tbxChildDescription);
                    populateSpeciesTraits(sqlCommandStringBuilder("ProtectionBehaviour", "protection_id", "protection_type", "protection_description"), "protection_type", "protection_description", cbxProtection, tbxProtectionDescription);
                    populateSpeciesTraits(sqlCommandStringBuilder("DispositionTypes", "disposition_id", "disposition_type", "disposition_description"), "disposition_type", "disposition_description", cbxDisposition, tbxDispositionDescription);
                    populateSpeciesTraits(sqlCommandStringBuilder("TempramentTypes", "temprament_id", "temprament_type", "temprament_description"), "temprament_type", "temprament_description", cbxTemperament, tbxTemperamentDescription);
                    populateSpeciesTraits(sqlCommandStringBuilder("ClimateTypes", "climate_id", "climate_type", "climate_description"), "climate_type", "climate_description", cbxClimate, tbxClimateDescription);

                    btnAddSpecies.Enabled = false;
                    btnUpdateSpecies.Enabled = true;
                    btnDeleteSpecies.Enabled = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        public string sqlCommandStringBuilder(string sqlTable, string sqlID, string sqlName, string sqlDescription)
        {
            string populateFieldsString = "SELECT " + sqlTable + "." + sqlName + ", " + sqlTable + "." + sqlDescription + " FROM " + sqlTable + ",DogSpecies WHERE " +
                                    "DogSpecies." + sqlID + " = " + sqlTable + "." + sqlID + " AND DogSpecies.species_id = " + cbxSpeciesID.Text;
            return populateFieldsString;
        }

        public void populateSpeciesTraits(string sqlCommandString, string sqlName, string sqlDescription, ComboBox comboBox, TextBox textBox)
        {
            int index = -1;

            cmd.Connection = conn;
            cmd.CommandText = sqlCommandString;
            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                index = comboBox.Items.IndexOf(reader[sqlName].ToString());
            }

            reader.Close();
            conn.Close();

            comboBox.SelectedIndex = index;
        }

        public void populateAppearanceID()
        {
            string sqlAppearanceString = "Select DogAppearance.appearance_id FROM DogAppearance, DogSpecies WHERE DogSpecies.appearance_id = DogAppearance.appearance_id"; ;
            
            cmd.Connection = conn;
            cmd.CommandText = sqlAppearanceString;
            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                int index = cbxAppearanceID.Items.IndexOf(reader["appearance_id"].ToString());
                cbxAppearanceID.SelectedIndex = index;
            }

            reader.Close();
            conn.Close();
        }

        private void ManageDogSpecies_Load(object sender, EventArgs e)
        {
            loadSpeciesCombobox();
            loadOtherComboxes("appearance_id","DogAppearance",cbxAppearanceID);
            loadOtherComboxes("size_type","DogSizeTypes",cbxSize);
            loadOtherComboxes("livingspace_type","LivingSpaceTypes",cbxLivingSpace);
            loadOtherComboxes("shedding_type","SheddingTypes",cbxShedding);
            loadOtherComboxes("exercise_type","ExerciseTypes",cbxExercise);
            loadOtherComboxes("training_type", "TrainingTypes", cbxTraining);
            loadOtherComboxes("childbehavior_type", "DogChildBehaviour", cbxChildFriendliness);
            loadOtherComboxes("protection_type", "ProtectionBehaviour", cbxProtection);
            loadOtherComboxes("disposition_type", "DispositionTypes", cbxDisposition);
            loadOtherComboxes("temprament_type", "TempramentTypes", cbxTemperament);
            loadOtherComboxes("climate_type", "ClimateTypes", cbxClimate);
        }

        private void cbxSpeciesID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateSpeciesTabs();
        }

        public void populateDescriptionOnChange(string sqlName, string sqlTable, string sqlDescription, ComboBox comboBox, TextBox textBox)
        {
            string commandString = "SELECT " + sqlDescription + " FROM " + sqlTable + " WHERE " + sqlName + " = '" + comboBox.Text + "'";

            cmd.Connection = conn;
            cmd.CommandText = commandString;
            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                textBox.Text = reader[sqlDescription].ToString();
            }

            reader.Close();
            conn.Close();
        }

        private void cbxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDescriptionOnChange("size_type","DogSizeTypes","size_description",cbxSize,tbxSizeDescription);
        }

        private void cbxLivingSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDescriptionOnChange("livingspace_type", "LivingSpaceTypes", "livingspace_description", cbxLivingSpace, tbxLivingSpaceDescription);
        }

        private void cbxShedding_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDescriptionOnChange("shedding_type", "SheddingTypes", "shedding_description", cbxShedding, tbxSheddingDescription);
        }

        private void cbxExercise_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDescriptionOnChange("exercise_type", "ExerciseTypes", "exercise_description", cbxExercise, tbxExerciseDescription);
        }

        private void cbxTraining_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDescriptionOnChange("training_type", "TrainingTypes", "training_description", cbxTraining, tbxTrainingDescription);
        }

        private void cbxChildFriendliness_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDescriptionOnChange("childbehavior_type", "DogChildBehaviour", "behaviour_description", cbxChildFriendliness, tbxChildDescription);
        }

        private void cbxProtection_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDescriptionOnChange("protection_type", "ProtectionBehaviour", "protection_description", cbxProtection, tbxProtectionDescription);
        }

        private void cbxDisposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDescriptionOnChange("disposition_type", "DispositionTypes", "disposition_description", cbxDisposition, tbxDispositionDescription);
        }

        private void cbxTemperament_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDescriptionOnChange("temprament_type", "TempramentTypes", "temprament_description", cbxTemperament, tbxTemperamentDescription);
        }

        private void cbxClimate_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateDescriptionOnChange("climate_type", "ClimateTypes", "climate_description", cbxClimate, tbxClimateDescription);
        }

        private void btnAddSpecies_Click(object sender, EventArgs e)
        {
            
            setSpeciesTraitsIds();

            string checkforDuplicates = "SELECT species_id FROM DogSpecies WHERE species_name = @species_name AND " +
                                        "history_description = @history_description AND about_description = @about_description AND " + 
                                        "appearance_id = @appearance_id AND origin_country = @origin_country AND species_age = @species_age AND " +
                                        "life_expectence = @life_expectence AND dog_otherNames = @dog_otherNames AND size_id = @size_id AND " +
                                        "livingspace_id = @livingspace_id AND trainingType_id = @trainingType_id AND exercise_id = exercise_id AND " +
                                        "disposition_id = @disposition_id AND shedding_id = @shedding_id AND childB_id = @childB_id AND protection_id = @protection_id AND " +
                                        "temprament_id = @temprament_id AND climate_id = @climate_id";

            try
            {
                cmd.Connection = conn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@species_name", tbxSpeciesName.Text));
                cmd.Parameters.Add(new SqlParameter("@history_description", rtbHistory.Text));
                cmd.Parameters.Add(new SqlParameter("@about_description", rtbAbout.Text));
                cmd.Parameters.Add(new SqlParameter("@appearance_id", appearanceID));
                cmd.Parameters.Add(new SqlParameter("@origin_country", tbxOriginCountry.Text));
                cmd.Parameters.Add(new SqlParameter("@species_age", tbxSpeciesAge.Text));
                cmd.Parameters.Add(new SqlParameter("@life_expectence", tbxLifeExpectancy.Text));
                cmd.Parameters.Add(new SqlParameter("@dog_otherNames", rtbOtherNames.Text));
                cmd.Parameters.Add(new SqlParameter("@size_id", sizeID));
                cmd.Parameters.Add(new SqlParameter("@livingspace_id", livingSpaceID));
                cmd.Parameters.Add(new SqlParameter("@trainingType_id", trainingID));
                cmd.Parameters.Add(new SqlParameter("@exercise_id", exerciseID));
                cmd.Parameters.Add(new SqlParameter("@disposition_id", dispositionID));
                cmd.Parameters.Add(new SqlParameter("@shedding_id", sheddingID));
                cmd.Parameters.Add(new SqlParameter("@childB_id", childID));
                cmd.Parameters.Add(new SqlParameter("@protection_id", protectionID));
                cmd.Parameters.Add(new SqlParameter("@temprament_id", tempramentID));
                cmd.Parameters.Add(new SqlParameter("@climate_id", climateID));
                cmd.CommandText = checkforDuplicates;

                conn.Open();

                reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    reader.Close();
                    conn.Close();

                    try
                    {
                        string insertData = "INSERT INTO DogSpecies(species_name,history_description,about_description," +
                                            "appearance_id,origin_country,species_age,life_expectence,dog_otherNames,size_id,livingspace_id,trainingType_id," +
                                            "exercise_id,disposition_id,shedding_id,childB_id,protection_id,temprament_id,climate_id)" +
                                            "VALUES(@species_name,@history_description,@about_description," +
                                            "@appearance_id,@origin_country,@species_age,@life_expectence,@dog_otherNames,@size_id,@livingspace_id,@trainingType_id," +
                                            "@exercise_id,@disposition_id,@shedding_id,@childB_id,@protection_id,@temprament_id,@climate_id)";
                        cmd.Connection = conn;
                        cmd.CommandText = insertData;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        reader.Close();
                        conn.Close();

                        MessageBox.Show("Successfully Added The New Type");

                        cbxSpeciesID.SelectedIndex = 0;
                        populateSpeciesTabs();

                        this.Refresh();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error.Message);
                    }
                }
                else
                {
                    MessageBox.Show("This appearance type already exists.");
                    conn.Close();
                }

                reader.Close();
                conn.Close();

                populateSpeciesTabs();
                loadSpeciesCombobox();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void btnUpdateSpecies_Click(object sender, EventArgs e)
        {
            setSpeciesTraitsIds();

            try
            {
                string updateType = "UPDATE DogSpecies SET species_name = @species_name," +
                                    "history_description = @history_description, about_description = @about_description, " +
                                    "appearance_id = @appearance_id, origin_country = @origin_country, species_age = @species_age, " +
                                    "life_expectence = @life_expectence, dog_otherNames = @dog_otherNames, size_id = @size_id, " +
                                    "livingspace_id = @livingspace_id, trainingType_id = @trainingType_id, exercise_id = exercise_id, " +
                                    "disposition_id = @disposition_id, shedding_id = @shedding_id, childB_id = @childB_id, " + 
                                    "protection_id = @protection_id,temprament_id = @temprament_id,climate_id = @climate_id WHERE species_id = " + cbxSpeciesID.Text;

                cmd.Connection = conn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@species_name", tbxSpeciesName.Text));
                cmd.Parameters.Add(new SqlParameter("@history_description", rtbHistory.Text));
                cmd.Parameters.Add(new SqlParameter("@about_description", rtbAbout.Text));
                cmd.Parameters.Add(new SqlParameter("@appearance_id", appearanceID));
                cmd.Parameters.Add(new SqlParameter("@origin_country", tbxOriginCountry.Text));
                cmd.Parameters.Add(new SqlParameter("@species_age", tbxSpeciesAge.Text));
                cmd.Parameters.Add(new SqlParameter("@life_expectence", tbxLifeExpectancy.Text));
                cmd.Parameters.Add(new SqlParameter("@dog_otherNames", rtbOtherNames.Text));
                cmd.Parameters.Add(new SqlParameter("@size_id", sizeID));
                cmd.Parameters.Add(new SqlParameter("@livingspace_id", livingSpaceID));
                cmd.Parameters.Add(new SqlParameter("@trainingType_id", trainingID));
                cmd.Parameters.Add(new SqlParameter("@exercise_id", exerciseID));
                cmd.Parameters.Add(new SqlParameter("@disposition_id", dispositionID));
                cmd.Parameters.Add(new SqlParameter("@shedding_id", sheddingID));
                cmd.Parameters.Add(new SqlParameter("@childB_id", childID));
                cmd.Parameters.Add(new SqlParameter("@protection_id", protectionID));
                cmd.Parameters.Add(new SqlParameter("@temprament_id", tempramentID));
                cmd.Parameters.Add(new SqlParameter("@climate_id", climateID));

                cmd.CommandText = updateType;

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Type successfully updated.");
                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void btnDeleteSpecies_Click(object sender, EventArgs e)
        {
            try
            {
                string DeleteType = "DELETE FROM DogSpecies WHERE species_id = " + cbxSpeciesID.Text;

                cmd.Connection = conn;

                cmd.CommandText = DeleteType;

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Type successfully deleted.");
                reader.Close();
                conn.Close();

                populateSpeciesTabs();
                loadSpeciesCombobox(); 
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }
    }
}
