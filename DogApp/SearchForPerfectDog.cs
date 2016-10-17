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
    public partial class SearchForPerfectDog : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlConnection conn2 = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();

        SqlDataReader reader;
        SqlDataReader reader2;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlDataAdapter adapter2 = new SqlDataAdapter();

        public class DogScore
        {
            public int speciesID { get; set; }
            public int dogScore { get; set; }
        }

        List<DogScore> dogScoresList = new List<DogScore>();

        public SearchForPerfectDog()
        {
            InitializeComponent();
        }

        public void loadDogList()
        {
            dogScoresList.Clear();
            string getSpeciesType = "Select species_id FROM DogSpecies";
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getSpeciesType;
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dogScoresList.Add(new DogScore { speciesID = Convert.ToInt32(reader["species_id"]), dogScore = 0 });
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        public void rateDogs()
        {
            string getSpeciesType = "Select * FROM DogSpecies";

            loadDogList();

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getSpeciesType;
                conn.Open();

                reader = cmd.ExecuteReader();

                int currentDogScore = 0;

                int scoreTotal = getTotalpossibleScore();
                int x = -1;

                while (reader.Read())
                {
                    x++;
                    currentDogScore = 0;

                    currentDogScore += getScoreFromSpecies("size_id", "DogSizeTypes", "size_type", cbxUserSize.Text,Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromSpecies("livingspace_id", "LivingSpaceTypes", "livingspace_type", cbxUserLivingSpace.Text, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromSpecies("trainingType_id", "TrainingTypes", "training_type", cbxUserTraining.Text, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromSpecies("exercise_id", "ExerciseTypes", "exercise_type", cbxUserExercise.Text, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromSpecies("disposition_id", "DispositionTypes", "disposition_type", cbxUserDisposition.Text, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromSpecies("shedding_id", "SheddingTypes", "shedding_type", cbxUserShedding.Text, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromSpecies("childB_id", "DogChildBehaviour", "childbehavior_type", cbxUserChildFriendliness.Text, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromSpecies("protection_id", "ProtectionBehaviour", "protection_type", cbxUserProtection.Text, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromSpecies("temprament_id", "TempramentTypes", "temprament_type", cbxUserTemperament.Text, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromSpecies("climate_id", "ClimateTypes", "climate_type", cbxUserClimate.Text, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromApperance("bodytype_id", "BodyTypes", cbxUserBody, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromApperance("eartype_id", "EarTypes", cbxUserEar, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromApperance("headtype_id", "HeadTypes", cbxUserHead, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromApperance("coattype_id", "CoatTypes", cbxUserCoat, Convert.ToInt32(reader["species_id"]));

                    currentDogScore += getScoreFromApperance("tailtype_id", "TailTypes", cbxUserTail, Convert.ToInt32(reader["species_id"]));

                    dogScoresList[x].dogScore = currentDogScore;
                }

                reader.Close();
                conn.Close();

                foreach (var DogScore in dogScoresList)
                {
                    if (Convert.ToDouble(DogScore.dogScore) / Convert.ToDouble(scoreTotal) >= 0.5)
                    {
                        lbxDogFinderResults.Items.Add(getDogSpeciesName(DogScore.speciesID) + " (ID no: " + Convert.ToString(DogScore.speciesID) +  ") matches " + DogScore.dogScore + " of the " + scoreTotal + " specified criteria." + Environment.NewLine);
                    }
                }

                if (lbxDogFinderResults.Items.Count == 0)
                {
                    MessageBox.Show("No species match at least half of you criteria. Please try changing some of your criteria.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }

            reader.Close();
            conn.Close();
        }

        public int getTotalpossibleScore()
        {
            int total = 0;

            total += checkCriteriaCombobox(cbxUserSize);
            total += checkCriteriaCombobox(cbxUserLivingSpace);
            total += checkCriteriaCombobox(cbxUserTraining);
            total += checkCriteriaCombobox(cbxUserExercise);
            total += checkCriteriaCombobox(cbxUserDisposition);
            total += checkCriteriaCombobox(cbxUserShedding);
            total += checkCriteriaCombobox(cbxUserChildFriendliness);
            total += checkCriteriaCombobox(cbxUserProtection);
            total += checkCriteriaCombobox(cbxUserTemperament);
            total += checkCriteriaCombobox(cbxUserClimate);
            total += checkCriteriaCombobox(cbxUserBody);
            total += checkCriteriaCombobox(cbxUserEar);
            total += checkCriteriaCombobox(cbxUserHead);
            total += checkCriteriaCombobox(cbxUserCoat);
            total += checkCriteriaCombobox(cbxUserTail);

            return total;
        }

        public int checkCriteriaCombobox(ComboBox comboBox)
        {
            if (comboBox.Text == "**Not Important**")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public string getDogSpeciesName(int speciesID)
        {
            string result = "";
            string getSpeciesType = "Select species_name FROM DogSpecies WHERE species_id = " + speciesID;
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getSpeciesType;
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = Convert.ToString(reader["species_name"]);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }

            return result;
        }

        public int getScoreFromSpecies(string sqlID, string sqlTable, string sqlName, string nameValue, int speciesID)
        {
            int score = 0;
            string getSpeciesType = "Select " + sqlTable + "." + sqlID + " FROM " + sqlTable + ",DogSpecies WHERE " + sqlTable + "." + sqlName + " = '" + 
                                    nameValue + "' AND DogSpecies." + sqlID + " = " + sqlTable + "." + sqlID + " AND DogSpecies.species_id = '" + speciesID + "'";
            try
            {
                cmd2.Connection = conn2;
                cmd2.CommandText = getSpeciesType;
                conn2.Open();

                reader2 = cmd2.ExecuteReader();

                if (reader2.Read())
                {
                    score = 1;
                }

                reader2.Close();
                conn2.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }

            return score;
        }

        public int getScoreFromApperance(string sqlID, string sqlTable, ComboBox comboBox, int currentID)
        {
            int score = 0;
            string getSpeciesType = "Select DogAppearance.* FROM " + sqlTable + ",DogSpecies,DogAppearance WHERE " + sqlTable + ".type_name = '" +
                                    comboBox.Text + "' AND DogAppearance." + sqlID + " = " + sqlTable + "." + sqlID + " AND DogSpecies.species_id = " + currentID + " AND DogSpecies.appearance_id = DogAppearance.appearance_id";
            try
            {
                cmd2.Connection = conn2;
                cmd2.CommandText = getSpeciesType;
                conn2.Open();

                reader2 = cmd2.ExecuteReader();

                if (reader2.Read())
                {
                    score = 1;
                }

                reader2.Close();
                conn2.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }

            return score;
        }

        private void btnDogPersonalityToFinder_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnSpeciesInfoToDogFinder_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnDogSpeciesInfoToPersonality_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void btnSelectedPersonalityToFinder_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnSelectedPersonalityToDogSpeciesInfo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void SearchForPerfectDog_Load(object sender, EventArgs e)
        {
            loadDogList();
            populateAllComboboxes();
        }

        public void populateCombobox(string sqlName, string sqlTable, ComboBox comboBox)
        {
            string getType = "Select " + sqlName + " FROM " + sqlTable;
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getType;
                conn.Open();

                reader = cmd.ExecuteReader();

                comboBox.Items.Clear();
                comboBox.Items.Add("**Not Important**");

                while (reader.Read())
                {
                    comboBox.Items.Add(reader[sqlName].ToString());
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

        public void populateAllComboboxes()
        {
            populateCombobox("size_type", "DogSizeTypes", cbxUserSize);
            populateCombobox("livingspace_type", "LivingSpaceTypes", cbxUserLivingSpace);
            populateCombobox("shedding_type", "SheddingTypes", cbxUserShedding);
            populateCombobox("exercise_type", "ExerciseTypes", cbxUserExercise);
            populateCombobox("training_type", "TrainingTypes", cbxUserTraining);
            populateCombobox("childbehavior_type", "DogChildBehaviour", cbxUserChildFriendliness);
            populateCombobox("protection_type", "ProtectionBehaviour", cbxUserProtection);
            populateCombobox("disposition_type", "DispositionTypes", cbxUserDisposition);
            populateCombobox("temprament_type","TempramentTypes",cbxUserTemperament);
            populateCombobox("climate_type","ClimateTypes",cbxUserClimate);

            populateCombobox("type_name","BodyTypes",cbxUserBody);
            populateCombobox("type_name", "EarTypes", cbxUserEar);
            populateCombobox("type_name", "HeadTypes", cbxUserHead);
            populateCombobox("type_name", "CoatTypes", cbxUserCoat);
            populateCombobox("type_name", "TailTypes", cbxUserTail);
        }

        private void btnDisplayPotentialMatches_Click(object sender, EventArgs e)
        {
            lbxDogFinderResults.Items.Clear();
            rateDogs();
        }

        private void btnDogInfo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
    }
}
