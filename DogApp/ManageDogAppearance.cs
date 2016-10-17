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
    public partial class ManageDogAppearance : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();

        int bodyID = 0;
        int earID = 0;
        int headID = 0;
        int coatID = 0;
        int tailID = 0;

        public ManageDogAppearance()
        {
            InitializeComponent();
        }

        public void populateAppearanceIDs()
        {
            cbxAppearanceID.Items.Clear();
            string getSpeciesType = "Select appearance_id FROM DogAppearance";
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getSpeciesType;
                conn.Open();

                reader = cmd.ExecuteReader();

                cbxAppearanceID.Items.Add("**New Appearance**");

                while (reader.Read())
                {
                    cbxAppearanceID.Items.Add(reader["appearance_id"].ToString());
                }

                cbxAppearanceID.SelectedIndex = 0;

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
        }

        public void populateOtherComboxes(string sqlTable, ComboBox comboBox)
        {
            string getType = "Select type_name FROM " + sqlTable;
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getType;
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox.Items.Add(reader["type_name"].ToString());
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

        public void populateUsingID()
        {
            if (cbxAppearanceID.Text == "**New Appearance**" || cbxAppearanceID.Text == "")
            {
                cbxBodyType.ResetText();
                cbxBodyType.SelectedIndex = -1;
                cbxEarType.ResetText();
                cbxEarType.SelectedIndex = -1;
                cbxHeadType.ResetText();
                cbxHeadType.SelectedIndex = -1;
                cbxCoatType.ResetText();
                cbxCoatType.SelectedIndex = -1;
                cbxTailType.ResetText();
                cbxTailType.SelectedIndex = -1;

                btnAddAppearance.Enabled = true;
                btnUpdateAppearance.Enabled = false;
                btnDeleteAppearance.Enabled = false;
            }
            else
            {
                try
                {
                    populateAppearanceTraits(sqlCommandStringAppearance("BodyTypes","bodytype_id"), cbxBodyType);
                    populateAppearanceTraits(sqlCommandStringAppearance("EarTypes", "eartype_id"), cbxEarType);
                    populateAppearanceTraits(sqlCommandStringAppearance("HeadTypes", "headtype_id"), cbxHeadType);
                    populateAppearanceTraits(sqlCommandStringAppearance("CoatTypes", "coattype_id"), cbxCoatType);
                    populateAppearanceTraits(sqlCommandStringAppearance("TailTypes", "tailtype_id"), cbxTailType);

                    btnAddAppearance.Enabled = false;
                    btnUpdateAppearance.Enabled = true;
                    btnDeleteAppearance.Enabled = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        public void populateAppearanceTraits(string sqlCommandString, ComboBox comboBox)
        {
            cmd.Connection = conn;
            cmd.CommandText = sqlCommandString;
            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                int index = comboBox.Items.IndexOf(reader["type_name"].ToString());
                comboBox.SelectedIndex = index;
            }

            reader.Close();
            conn.Close();
        }

        public string sqlCommandStringAppearance(string sqlTable, string sqlID)
        {
            string populateFieldsString = "SELECT " + sqlTable + ".type_name FROM " + sqlTable + ",DogAppearance WHERE " +
                                          sqlTable + "." + sqlID + " = DogAppearance." + sqlID + " AND DogAppearance.appearance_id = " + cbxAppearanceID.Text; 
            return populateFieldsString;
        }

        public int getId(ComboBox comboBox, string sqlTable, string sqlID)
        {
            string sqlCommandString = "SELECT " + sqlID + " FROM " + sqlTable + " WHERE type_name = '" + comboBox.Text +"'";
            int index;

            cmd.Connection = conn;
            cmd.CommandText = sqlCommandString;
            conn.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                index = Convert.ToInt32(reader[sqlID].ToString());
            }
            else
            {
                index = -1;
            }

            reader.Close();
            conn.Close();

            return index;
        }

        public void setIds()
        {
            bodyID = getId(cbxBodyType,"BodyTypes","bodytype_id");
            earID = getId(cbxEarType, "EarTypes", "eartype_id");
            headID = getId(cbxHeadType, "HeadTypes", "headtype_id");
            coatID = getId(cbxCoatType, "CoatTypes", "coattype_id");
            tailID = getId(cbxTailType, "TailTypes", "tailtype_id");
        }

        private void ManageDogAppearance_Load(object sender, EventArgs e)
        {
            populateAppearanceIDs();
            populateOtherComboxes("BodyTypes",cbxBodyType);
            populateOtherComboxes("EarTypes", cbxEarType);
            populateOtherComboxes("HeadTypes", cbxHeadType);
            populateOtherComboxes("CoatTypes", cbxCoatType);
            populateOtherComboxes("TailTypes", cbxTailType);
        }

        private void cbxAppearanceID_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateUsingID();
        }

        private void btnAddAppearnace_Click(object sender, EventArgs e)
        {
            setIds();

            string checkforDuplicates = "SELECT appearance_id FROM DogAppearance WHERE bodytype_id = @bodytype_id AND " +
                                        "eartype_id = @eartype_id AND headtype_id = @headtype_id AND coattype_id = @coattype_id AND " + 
                                        "tailtype_id = @tailtype_id";

            try
            {
                cmd.Connection = conn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@bodytype_id", bodyID));
                cmd.Parameters.Add(new SqlParameter("@eartype_id", earID));
                cmd.Parameters.Add(new SqlParameter("@headtype_id", headID));
                cmd.Parameters.Add(new SqlParameter("@coattype_id", coatID));
                cmd.Parameters.Add(new SqlParameter("@tailtype_id", tailID));
                cmd.CommandText = checkforDuplicates;

                conn.Open();

                reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    reader.Close();
                    conn.Close();

                    try
                    {
                        string insertData = "INSERT INTO DogAppearance(bodytype_id,eartype_id,headtype_id,coattype_id,tailtype_id)" +
                                            "VALUES(@bodytype_id,@eartype_id,@headtype_id,@coattype_id,@tailtype_id)";
                        cmd.Connection = conn;
                        cmd.CommandText = insertData;

                        cmd.Parameters["@bodytype_id"].Value = bodyID;
                        cmd.Parameters["@eartype_id"].Value = earID;
                        cmd.Parameters["@headtype_id"].Value = headID;
                        cmd.Parameters["@coattype_id"].Value = coatID;
                        cmd.Parameters["@tailtype_id"].Value = tailID;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Added The New Type");
                        conn.Close();

                        populateAppearanceIDs();
                        cbxBodyType.SelectedIndex = -1;
                        cbxEarType.SelectedIndex = -1;
                        cbxHeadType.SelectedIndex = -1;
                        cbxTailType.SelectedIndex = -1;
                        cbxCoatType.SelectedIndex = -1;

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
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void btnUpdateAppearance_Click(object sender, EventArgs e)
        {
            setIds();

            try
            {
                string updateType = "UPDATE DogAppearance SET bodytype_id = @bodytype_id, eartype_id = @eartype_id, headtype_id = @headtype_id, " +
                                    "coattype_id = @coattype_id, tailtype_id = @tailtype_id WHERE appearance_id = " + cbxAppearanceID.Text;

                cmd.Connection = conn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@bodytype_id", bodyID));
                cmd.Parameters.Add(new SqlParameter("@eartype_id", earID));
                cmd.Parameters.Add(new SqlParameter("@headtype_id", headID));
                cmd.Parameters.Add(new SqlParameter("@coattype_id", coatID));
                cmd.Parameters.Add(new SqlParameter("@tailtype_id", tailID));

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

        private void btnDeleteAppearance_Click(object sender, EventArgs e)
        {
            try
            {
                string DeleteType = "DELETE FROM DogAppearance WHERE appearance_id = " + cbxAppearanceID.Text;

                cmd.Connection = conn;

                cmd.CommandText = DeleteType;

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Type successfully deleted.");
                reader.Close();
                conn.Close();

                populateAppearanceIDs();
                cbxBodyType.SelectedIndex = -1;
                cbxEarType.SelectedIndex = -1;
                cbxHeadType.SelectedIndex = -1;
                cbxTailType.SelectedIndex = -1;
                cbxCoatType.SelectedIndex = -1;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }
    }
}
