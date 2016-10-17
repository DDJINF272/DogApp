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
    public partial class ManageDogSpeciesTraits : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();

        public ManageDogSpeciesTraits()
        {
            InitializeComponent();
        }

        private void loadComboboxes(string sqlTable, ComboBox comboBox, string sqlID)
        {
            string getType = "Select " + sqlID + " FROM " + sqlTable;
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getType;
                conn.Open();

                reader = cmd.ExecuteReader();

                comboBox.Items.Add("**New Type**");

                while (reader.Read())
                {
                    comboBox.Items.Add(reader[sqlID].ToString());
                }

                comboBox.SelectedIndex = 0;

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void ManageDogSpeciesTraits_Load(object sender, EventArgs e)
        {
            loadComboboxes("ProtectionBehaviour", cbxProtectionTypeID, "protection_id");
            loadComboboxes("DispositionTypes", cbxDispositionTypeID, "disposition_id");
            loadComboboxes("LivingSpaceTypes", cbxLivingSpaceTypeID, "livingspace_id");
            loadComboboxes("TrainingTypes", cbxTrainingTypeID, "trainingType_id");
            loadComboboxes("DogChildBehaviour", cbxChildFriendlinessTypeID, "childB_id");
            loadComboboxes("DogSizeTypes", cbxSizeTypeID, "size_id");
            loadComboboxes("ExerciseTypes", cbxExerciseTypeID, "exercise_id");
            loadComboboxes("ClimateTypes", cbxClimateTypeID, "climate_id");
            loadComboboxes("SheddingTypes", cbxSheddingTypeID, "shedding_id");
            loadComboboxes("TempramentTypes", cbxTemperamentTypeID, "temprament_id");
        }

        public void populateForms(string sqlTable, string sqlId, string sqlName, string sqlDescription, ComboBox comboBox, 
                                  TextBox nameBox, RichTextBox descriptionBox, Button newTypeBtn, 
                                  Button updateTypeBtn, Button deleteTypeBtn)
        {
            string populateFields = "SELECT * FROM " + sqlTable + " WHERE " + sqlId + " = " + comboBox.Text;

            if (comboBox.Text == "**New Type**" || comboBox.Text == "")
            {
                nameBox.Text = "";
                descriptionBox.Text = "";

                newTypeBtn.Enabled = true;
                updateTypeBtn.Enabled = false;
                deleteTypeBtn.Enabled = false;
            }
            else
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = populateFields;
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        nameBox.Text = reader[sqlName].ToString();
                        descriptionBox.Text = reader[sqlDescription].ToString();
                    }

                    reader.Close();
                    conn.Close();

                    newTypeBtn.Enabled = false;
                    updateTypeBtn.Enabled = true;
                    deleteTypeBtn.Enabled = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        public void AddData(string sqlID, string sqlTable, string sqlName, string sqlDescription, string nameText, string descriptionText)
        {
            string checkforDuplicates = "SELECT " + sqlID + " FROM " + sqlTable + " WHERE " + sqlName + " = @type_name OR " +
                                        sqlDescription +  " = @type_description";

            try
            {
                cmd.Connection = conn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@type_name", nameText));
                cmd.Parameters.Add(new SqlParameter("@type_description", descriptionText));
                cmd.CommandText = checkforDuplicates;

                conn.Open();

                reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    reader.Close();
                    conn.Close();

                    try
                    {
                        string insertData = "INSERT INTO " + sqlTable + "("+ sqlName + ", " + sqlDescription + ") " +
                                            "VALUES(@type_name, @type_description)";
                        cmd.Connection = conn;
                        cmd.CommandText = insertData;

                        cmd.Parameters["@type_name"].Value = nameText;
                        cmd.Parameters["@type_description"].Value = descriptionText;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Added The New Type");
                        conn.Close();

                        this.Refresh();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error.Message);
                    }
                }
                else
                {
                    MessageBox.Show("This type name or description already exists.");
                    conn.Close();
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        public void UpdateData(string sqlID, string sqlTable, string sqlName, string sqlDescription, string nameText, string descriptionText, string comboBoxVal)
        {
            try
            {
                string updateType = "UPDATE " + sqlTable + " SET " + sqlName + " = @type_name, " + sqlDescription + " = @type_description " +
                                    "WHERE " + sqlID + " = " + comboBoxVal;

                cmd.Connection = conn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@type_name", nameText));
                cmd.Parameters.Add(new SqlParameter("@type_description", descriptionText));

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

        public void DeleteData(string sqlID, string sqlTable, string comboBoxVal)
        {
            try
            {
                string DeleteType = "DELETE FROM " + sqlTable + " WHERE " + sqlID + " = " + comboBoxVal;

                cmd.Connection = conn;

                cmd.CommandText = DeleteType;

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Type successfully deleted.");
                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        //CRUD for Protection
        private void cbxProtectionTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateForms("ProtectionBehaviour", "protection_id", "protection_type", "protection_description", cbxProtectionTypeID,
                          tbxProtectionName, rtbProtectionDescription, btnNewProtection, btnUpdateProtection, btnDeleteProtection);
        }

        private void btnNewProtection_Click(object sender, EventArgs e)
        {
            AddData("protection_id", "ProtectionBehaviour","protection_type", "protection_description", tbxProtectionName.Text, rtbProtectionDescription.Text);

            tbxProtectionName.Text = "";
            rtbProtectionDescription.Text = "";
            cbxProtectionTypeID.Items.Clear();
            loadComboboxes("ProtectionBehaviour", cbxProtectionTypeID, "protection_id");
        }

        private void btnUpdateProtection_Click(object sender, EventArgs e)
        {
            UpdateData("protection_id", "ProtectionBehaviour", "protection_type", "protection_description", tbxProtectionName.Text, rtbProtectionDescription.Text, cbxProtectionTypeID.Text);
        }

        private void btnDeleteProtection_Click(object sender, EventArgs e)
        {
            DeleteData("protection_id", "ProtectionBehaviour", cbxProtectionTypeID.Text);
            tbxProtectionName.Text = "";
            rtbProtectionDescription.Text = "";
            cbxProtectionTypeID.Items.Clear();
            loadComboboxes("ProtectionBehaviour", cbxProtectionTypeID, "protection_id");
        }

        //CRUD for Disposition
        private void cbxDispositionTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateForms("DispositionTypes", "disposition_id", "disposition_type", "disposition_description", cbxDispositionTypeID,
                         tbxDispositionName, rtbDispositionDescription, btnNewDisposition, btnUpdateDisposition, btnDeleteDisposition);
        }

        private void btnNewDisposition_Click(object sender, EventArgs e)
        {
            AddData("disposition_id", "DispositionTypes", "disposition_type", "disposition_description", tbxDispositionName.Text, rtbDispositionDescription.Text);

            tbxDispositionName.Text = "";
            rtbDispositionDescription.Text = "";
            cbxDispositionTypeID.Items.Clear();
            loadComboboxes("DispositionTypes", cbxDispositionTypeID, "disposition_id");
        }

        private void btnUpdateDisposition_Click(object sender, EventArgs e)
        {
            UpdateData("disposition_id", "DispositionTypes", "disposition_type", "disposition_description", tbxDispositionName.Text, rtbDispositionDescription.Text, cbxDispositionTypeID.Text);
        }

        private void btnDeleteDisposition_Click(object sender, EventArgs e)
        {
            DeleteData("disposition_id", "DispositionTypes", cbxDispositionTypeID.Text);
            tbxDispositionName.Text = "";
            rtbDispositionDescription.Text = "";
            cbxDispositionTypeID.Items.Clear();
            loadComboboxes("DispositionTypes", cbxDispositionTypeID, "disposition_id");
        }


        //CRUD for Living Space
        private void cbxLivingSpaceTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateForms("LivingSpaceTypes", "livingspace_id", "livingspace_type", "livingspace_description", cbxLivingSpaceTypeID,
                     tbxLivingSpaceName, rtbLivingSpaceDescription, btnNewLivingSpace, btnUpdateLivingSpace, btnDeleteLivingSpace);
        }

        private void btnNewLivingSpace_Click(object sender, EventArgs e)
        {
            AddData("livingspace_id", "LivingSpaceTypes", "livingspace_type", "livingspace_description", tbxLivingSpaceName.Text, rtbLivingSpaceDescription.Text);

            tbxLivingSpaceName.Text = "";
            rtbLivingSpaceDescription.Text = "";
            cbxLivingSpaceTypeID.Items.Clear();
            loadComboboxes("LivingSpaceTypes", cbxLivingSpaceTypeID, "livingspace_id");
        }

        private void btnUpdateLivingSpace_Click(object sender, EventArgs e)
        {
            UpdateData("livingspace_id", "LivingSpaceTypes", "livingspace_type", "livingspace_description", tbxLivingSpaceName.Text, rtbLivingSpaceDescription.Text, cbxLivingSpaceTypeID.Text);
        }

        private void btnDeleteLivingSpace_Click(object sender, EventArgs e)
        {
            DeleteData("livingspace_id", "LivingSpaceTypes", cbxLivingSpaceTypeID.Text);
            tbxLivingSpaceName.Text = "";
            rtbLivingSpaceDescription.Text = "";
            cbxLivingSpaceTypeID.Items.Clear();
            loadComboboxes("LivingSpaceTypes", cbxLivingSpaceTypeID, "livingspace_id");
        }

        //CRUD for Training
        private void cbxTrainingTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateForms("TrainingTypes", "trainingtype_id", "training_type", "training_description", cbxTrainingTypeID,
                     tbxTrainingName, rtbTrainingDescription, btnNewTraining, btnUpdateTraining, btnDeleteTraining);
        }

        private void btnNewTraining_Click(object sender, EventArgs e)
        {
            AddData("trainingtype_id", "TrainingTypes", "training_type", "training_description", tbxTrainingName.Text, rtbTrainingDescription.Text);

            tbxTrainingName.Text = "";
            rtbTrainingDescription.Text = "";
            cbxTrainingTypeID.Items.Clear();
            loadComboboxes("TrainingTypes", cbxTrainingTypeID, "trainingtype_id");
        }

        private void btnUpdateTraining_Click(object sender, EventArgs e)
        {
            UpdateData("trainingtype_id", "TrainingTypes", "training_type", "training_description", tbxTrainingName.Text, rtbTrainingDescription.Text, cbxTrainingTypeID.Text);
        }

        private void btnDeleteTraining_Click(object sender, EventArgs e)
        {
            DeleteData("trainingtype_id", "TrainingTypes", cbxTrainingTypeID.Text);
            tbxTrainingName.Text = "";
            rtbTrainingDescription.Text = "";
            cbxTrainingTypeID.Items.Clear();
            loadComboboxes("TrainingTypes", cbxTrainingTypeID, "trainingtype_id");
        }

        //CRUD for Child Friendliness
        private void cbxChildFriendlinessTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateForms("DogChildBehaviour", "childB_id", "childbehavior_type", "behaviour_description", cbxChildFriendlinessTypeID,
                     tbxChildFriendlinessName, rtbChildFriendlinessDescription, btnNewChildFriendliness, btnUpdateChildFriendliness, btnDeleteChildFriendliness);
        }

        private void btnNewChildFriendliness_Click(object sender, EventArgs e)
        {
            AddData("childB_id", "DogChildBehaviour", "childbehavior_type", "behaviour_description", tbxChildFriendlinessName.Text, rtbChildFriendlinessDescription.Text);

            tbxChildFriendlinessName.Text = "";
            rtbChildFriendlinessDescription.Text = "";
            cbxChildFriendlinessTypeID.Items.Clear();
            loadComboboxes("DogChildBehaviour", cbxChildFriendlinessTypeID, "childB_id");
        }

        private void btnUpdateChildFriendliness_Click(object sender, EventArgs e)
        {
            UpdateData("childB_id", "DogChildBehaviour", "childbehavior_type", "behaviour_description", tbxChildFriendlinessName.Text, rtbChildFriendlinessDescription.Text, cbxChildFriendlinessTypeID.Text);
        }

        private void btnDeleteChildFriendliness_Click(object sender, EventArgs e)
        {
            DeleteData("childB_id", "DogChildBehaviour", cbxChildFriendlinessTypeID.Text);
            tbxChildFriendlinessName.Text = "";
            rtbChildFriendlinessDescription.Text = "";
            cbxChildFriendlinessTypeID.Items.Clear();
            loadComboboxes("DogChildBehaviour", cbxChildFriendlinessTypeID, "childB_id");
        }

        //CRUD for Size
        private void cbxSizeTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateForms("DogSizeTypes", "size_id", "size_type", "size_description", cbxSizeTypeID,
                     tbxSizeName, rtbSizeDescription, btnNewSize, btnUpdateSize, btnDeleteSize);
        }

        private void btnNewSize_Click(object sender, EventArgs e)
        {
            AddData("size_id", "DogSizeTypes", "size_type", "size_description", tbxSizeName.Text, rtbSizeDescription.Text);

            tbxSizeName.Text = "";
            rtbSizeDescription.Text = "";
            cbxSizeTypeID.Items.Clear();
            loadComboboxes("DogSizeTypes", cbxSizeTypeID, "size_id");
        }

        private void btnUpdateSize_Click(object sender, EventArgs e)
        {
            UpdateData("size_id", "DogSizeTypes", "size_type", "size_description", tbxSizeName.Text, rtbSizeDescription.Text, cbxSizeTypeID.Text);
        }

        private void btnDeleteSize_Click(object sender, EventArgs e)
        {
            DeleteData("size_id", "DogSizeTypes", cbxSizeTypeID.Text);
            tbxSizeName.Text = "";
            rtbSizeDescription.Text = "";
            cbxSizeTypeID.Items.Clear();
            loadComboboxes("DogSizeTypes", cbxSizeTypeID, "size_id");
        }

        //CRUD for Exercise
        private void cbxExerciseTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateForms("ExerciseTypes", "exercise_id", "exercise_type", "exercise_description", cbxExerciseTypeID,
                     tbxExerciseName, rtbExerciseDescription, btnNewExercise, btnUpdateExercise, btnDeleteExercise);
        }

        private void btnNewExercise_Click(object sender, EventArgs e)
        {
            AddData("exercise_id", "ExerciseTypes", "exercise_type", "exercise_description", tbxExerciseName.Text, rtbExerciseDescription.Text);

            tbxExerciseName.Text = "";
            rtbExerciseDescription.Text = "";
            cbxExerciseTypeID.Items.Clear();
            loadComboboxes("ExerciseTypes", cbxExerciseTypeID, "exercise_id");
        }

        private void btnUpdateExercise_Click(object sender, EventArgs e)
        {
            UpdateData("exercise_id", "ExerciseTypes", "exercise_type", "exercise_description", tbxExerciseName.Text, rtbExerciseDescription.Text, cbxExerciseTypeID.Text);
        }

        private void btnDeleteExercise_Click(object sender, EventArgs e)
        {
            DeleteData("exercise_id", "ExerciseTypes", cbxExerciseTypeID.Text);
            tbxExerciseName.Text = "";
            rtbExerciseDescription.Text = "";
            cbxExerciseTypeID.Items.Clear();
            loadComboboxes("ExerciseTypes", cbxExerciseTypeID, "exercise_id");
        }

        //CRUD for Climate
        private void cbxClimateTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateForms("ClimateTypes", "climate_id", "climate_type", "climate_description", cbxClimateTypeID,
                     tbxClimateName, rtbClimateDescription, btnNewClimate, btnUpdateClimate, btnDeleteClimate);
        }

        private void btnNewClimate_Click(object sender, EventArgs e)
        {
            AddData("climate_id", "ClimateTypes", "climate_type", "climate_description", tbxClimateName.Text, rtbClimateDescription.Text);

            tbxClimateName.Text = "";
            rtbClimateDescription.Text = "";
            cbxClimateTypeID.Items.Clear();
            loadComboboxes("ClimateTypes", cbxClimateTypeID, "climate_id");
        }

        private void btnUpdateClimate_Click(object sender, EventArgs e)
        {
            UpdateData("climate_id", "ClimateTypes", "climate_type", "climate_description", tbxClimateName.Text, rtbClimateDescription.Text, cbxClimateTypeID.Text);
        }

        private void btnDeleteClimate_Click(object sender, EventArgs e)
        {
            DeleteData("climate_id", "ClimateTypes", cbxClimateTypeID.Text);
            tbxClimateName.Text = "";
            rtbClimateDescription.Text = "";
            cbxClimateTypeID.Items.Clear();
            loadComboboxes("ClimateTypes", cbxClimateTypeID, "climate_id");
        }

        //CRUD for Shedding
        private void cbxSheddingTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateForms("SheddingTypes", "shedding_id", "shedding_type", "shedding_description", cbxSheddingTypeID,
                     tbxSheddingName, rtbSheddingDescription, btnNewShedding, btnUpdateShedding, btnDeleteShedding);
        }

        private void btnNewShedding_Click(object sender, EventArgs e)
        {
            AddData("shedding_id", "SheddingTypes", "shedding_type", "shedding_description", tbxSheddingName.Text, rtbSheddingDescription.Text);

            tbxSheddingName.Text = "";
            rtbSheddingDescription.Text = "";
            cbxSheddingTypeID.Items.Clear();
            loadComboboxes("SheddingTypes", cbxSheddingTypeID, "shedding_id");
        }

        private void btnUpdateShedding_Click(object sender, EventArgs e)
        {
            UpdateData("shedding_id", "SheddingTypes", "shedding_type", "shedding_description", tbxSheddingName.Text, rtbSheddingDescription.Text, cbxSheddingTypeID.Text);
        }

        private void btnDeleteShedding_Click(object sender, EventArgs e)
        {
            DeleteData("shedding_id", "SheddingTypes", cbxSheddingTypeID.Text);
            tbxSheddingName.Text = "";
            rtbSheddingDescription.Text = "";
            cbxSheddingTypeID.Items.Clear();
            loadComboboxes("SheddingTypes", cbxSheddingTypeID, "shedding_id");
        }

        //CRUD for Temperament
        private void cbxTemperamentTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateForms("TempramentTypes", "temprament_id", "temprament_type", "temprament_description", cbxTemperamentTypeID,
                     tbxTemperamentName, rtbTemperamentDescription, btnNewTemperament, btnUpdateTemperament, btnDeleteTemperament);
        }

        private void btnNewTemperament_Click(object sender, EventArgs e)
        {
            AddData("temprament_id", "TempramentTypes", "temprament_type", "temprament_description", tbxTemperamentName.Text, rtbTemperamentDescription.Text);

            tbxTemperamentName.Text = "";
            rtbTemperamentDescription.Text = "";
            cbxTemperamentTypeID.Items.Clear();
            loadComboboxes("TempramentTypes", cbxTemperamentTypeID, "temprament_id");
        }

        private void btnUpdateTemperament_Click(object sender, EventArgs e)
        {
            UpdateData("temprament_id", "TempramentTypes", "temprament_type", "temprament_description", tbxTemperamentName.Text, rtbTemperamentDescription.Text, cbxTemperamentTypeID.Text);
        }

        private void btnDeleteTemperament_Click(object sender, EventArgs e)
        {
            DeleteData("temprament_id", "TempramentTypes", cbxTemperamentTypeID.Text);
            tbxTemperamentName.Text = "";
            rtbTemperamentDescription.Text = "";
            cbxTemperamentTypeID.Items.Clear();
            loadComboboxes("TempramentTypes", cbxTemperamentTypeID, "temprament_id");
        }
    }
}
