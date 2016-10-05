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
    public partial class ManageDogAppearanceTraits : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();

        public ManageDogAppearanceTraits()
        {
            InitializeComponent();
        }

        private void ManageDogAppearanceTraits_Load(object sender, EventArgs e)
        {
            loadComboboxes();
        }

        private void cbxBodyTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string populateFields = "SELECT * FROM BodyTypes WHERE bodytype_id = " + cbxBodyTypeID.Text;

            if (cbxBodyTypeID.Text == "**New Body Type**" || cbxBodyTypeID.Text == "")
            {
                tbxBodyName.Text = "";
                rtbBodyDescription.Text = "";

                btnNewBody.Enabled = true;
                btnUpdateBody.Enabled = false;
                btnDeleteBody.Enabled = false;
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
                        tbxBodyName.Text = reader["type_name"].ToString();
                        rtbBodyDescription.Text = reader["type_description"].ToString();
                    }

                    reader.Close();
                    conn.Close();

                    btnNewBody.Enabled = false;
                    btnUpdateBody.Enabled = true;
                    btnDeleteBody.Enabled = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        private void cbxTailTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string populateFields = "SELECT * FROM TailTypes WHERE tailtype_id = " + cbxTailTypeID.Text;

            if (cbxTailTypeID.Text == "**New Tail Type**" || cbxTailTypeID.Text == "")
            {
                tbxTailName.Text = "";
                rtbTailDescription.Text = "";

                btnNewTail.Enabled = true;
                btnUpdateTail.Enabled = false;
                btnDeleteTail.Enabled = false;
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
                        tbxTailName.Text = reader["type_name"].ToString();
                        rtbTailDescription.Text = reader["type_description"].ToString();
                    }

                    reader.Close();
                    conn.Close();

                    btnNewTail.Enabled = false;
                    btnUpdateTail.Enabled = true;
                    btnDeleteTail.Enabled = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        private void cbxEarTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string populateFields = "SELECT * FROM EarTypes WHERE eartype_id = " + cbxEarTypeID.Text;

            if (cbxEarTypeID.Text == "**New Ear Type**" || cbxEarTypeID.Text == "")
            {
                tbxEarName.Text = "";
                rtbEarDescription.Text = "";

                btnNewEar.Enabled = true;
                btnUpdateEar.Enabled = false;
                btnDeleteEar.Enabled = false;
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
                        tbxEarName.Text = reader["type_name"].ToString();
                        rtbEarDescription.Text = reader["type_description"].ToString();
                    }

                    reader.Close();
                    conn.Close();

                    btnNewEar.Enabled = false;
                    btnUpdateEar.Enabled = true;
                    btnDeleteEar.Enabled = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        private void cbxCoatTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string populateFields = "SELECT * FROM CoatTypes WHERE coattype_id = " + cbxCoatTypeID.Text;

            if (cbxCoatTypeID.Text == "**New Coat Type**" || cbxCoatTypeID.Text == "")
            {
                tbxCoatName.Text = "";
                rtbCoatDescription.Text = "";

                btnNewCoat.Enabled = true;
                btnUpdateCoat.Enabled = false;
                btnDeleteCoat.Enabled = false;
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
                        tbxCoatName.Text = reader["type_name"].ToString();
                        rtbCoatDescription.Text = reader["type_description"].ToString();
                    }

                    reader.Close();
                    conn.Close();

                    btnNewCoat.Enabled = false;
                    btnUpdateCoat.Enabled = true;
                    btnDeleteCoat.Enabled = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        private void cbxHeadTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string populateFields = "SELECT * FROM HeadTypes WHERE headtype_id = " + cbxHeadTypeID.Text;

            if (cbxHeadTypeID.Text == "**New Head Type**" || cbxHeadTypeID.Text == "")
            {
                tbxHeadName.Text = "";
                rtbHeadDescription.Text = "";

                btnNewHead.Enabled = true;
                btnUpdateHead.Enabled = false;
                btnDeleteHead.Enabled = false;
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
                        tbxHeadName.Text = reader["type_name"].ToString();
                        rtbHeadDescription.Text = reader["type_description"].ToString();
                    }

                    reader.Close();
                    conn.Close();

                    btnNewHead.Enabled = false;
                    btnUpdateHead.Enabled = true;
                    btnDeleteHead.Enabled = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        public void AddData(string sqlID, string sqlTable, string nameText, string descriptionText)
        {
            string checkforDuplicates = "SELECT " + sqlID + " FROM " + sqlTable + " WHERE type_name = @type_name OR " +
                                        "type_description = @type_description";

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
                        string insertData = "INSERT INTO " + sqlTable + "(type_name, type_description) " +
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

        public void UpdateData(string sqlID, string sqlTable, string nameText, string descriptionText, string comboBoxVal)
        {
            try
            {
                string updateType = "UPDATE " + sqlTable + " SET type_name = @type_name, type_description = @type_description " +
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

        private void loadComboboxes()
        {
            string getBody = "SELECT bodytype_id FROM BodyTypes";
            string getTail = "SELECT tailtype_id FROM TailTypes";
            string getEar = "SELECT eartype_id FROM EarTypes";
            string getCoat = "SELECT coattype_id FROM CoatTypes";
            string getHead = "SELECT headtype_id FROM HeadTypes";

            //Body
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getBody;
                conn.Open();

                reader = cmd.ExecuteReader();

                cbxBodyTypeID.Items.Add("**New Body Type**");

                while (reader.Read())
                {
                    cbxBodyTypeID.Items.Add(reader["bodytype_id"].ToString());
                }

                cbxBodyTypeID.SelectedIndex = 0;

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }

            //Tail
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getTail;
                conn.Open();

                reader = cmd.ExecuteReader();

                cbxTailTypeID.Items.Add("**New Tail Type**");

                while (reader.Read())
                {
                    cbxTailTypeID.Items.Add(reader["tailtype_id"].ToString());
                }

                cbxTailTypeID.SelectedIndex = 0;

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }

            //Ear
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getEar;
                conn.Open();

                reader = cmd.ExecuteReader();

                cbxEarTypeID.Items.Add("**New Ear Type**");

                while (reader.Read())
                {
                    cbxEarTypeID.Items.Add(reader["eartype_id"].ToString());
                }

                cbxEarTypeID.SelectedIndex = 0;

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }

            //Coat
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getCoat;
                conn.Open();

                reader = cmd.ExecuteReader();

                cbxCoatTypeID.Items.Add("**New Coat Type**");

                while (reader.Read())
                {
                    cbxCoatTypeID.Items.Add(reader["coattype_id"].ToString());
                }

                cbxCoatTypeID.SelectedIndex = 0;

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }

            //Head
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getHead;
                conn.Open();

                reader = cmd.ExecuteReader();

                cbxHeadTypeID.Items.Add("**New Head Type**");

                while (reader.Read())
                {
                    cbxHeadTypeID.Items.Add(reader["headtype_id"].ToString());
                }

                cbxHeadTypeID.SelectedIndex = 0;

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
        }
        private void ResetForm()
        {
            cbxBodyTypeID.Items.Clear();
            cbxTailTypeID.Items.Clear();
            cbxEarTypeID.Items.Clear();
            cbxCoatTypeID.Items.Clear();
            cbxHeadTypeID.Items.Clear();

            loadComboboxes();
        }

        //Body Type CRUD
        private void btnNewBody_Click(object sender, EventArgs e)
        {
            AddData("bodytype_id", "BodyTypes", tbxBodyName.Text, rtbBodyDescription.Text);
            tbxBodyName.Text = "";
            rtbBodyDescription.Text = "";
            ResetForm();
        }

        private void btnDeleteBody_Click(object sender, EventArgs e)
        {
            DeleteData("bodytype_id", "BodyTypes", cbxBodyTypeID.Text);
            tbxBodyName.Text = "";
            rtbBodyDescription.Text = "";
            ResetForm();
        }

        private void btnUpdateBody_Click(object sender, EventArgs e)
        {
            UpdateData("bodytype_id", "BodyTypes", tbxBodyName.Text, rtbBodyDescription.Text, cbxBodyTypeID.Text);
        }

        //Tail Type CRUD
        private void btnNewTail_Click(object sender, EventArgs e)
        {
            AddData("tailtype_id", "TailTypes", tbxTailName.Text, rtbTailDescription.Text);
            tbxTailName.Text = "";
            rtbTailDescription.Text = "";
            ResetForm();
        }

        private void btnDeleteTail_Click(object sender, EventArgs e)
        {
            DeleteData("tailtype_id", "TailTypes", cbxTailTypeID.Text);
            tbxTailName.Text = "";
            rtbTailDescription.Text = "";
            ResetForm();
        }

        private void btnUpdateTail_Click(object sender, EventArgs e)
        {
            UpdateData("tailtype_id", "TailTypes", tbxTailName.Text, rtbTailDescription.Text, cbxTailTypeID.Text);
        }

        //Ear
        private void btnNewEar_Click(object sender, EventArgs e)
        {
            AddData("eartype_id", "EarTypes", tbxEarName.Text, rtbEarDescription.Text);
            tbxEarName.Text = "";
            rtbEarDescription.Text = "";
            ResetForm();
        }

        private void btnDeleteEar_Click(object sender, EventArgs e)
        {
            DeleteData("eartype_id", "EarTypes", cbxEarTypeID.Text);
            tbxEarName.Text = "";
            rtbEarDescription.Text = "";
            ResetForm();
        }

        private void btnUpdateEar_Click(object sender, EventArgs e)
        {
            UpdateData("eartype_id", "EarTypes", tbxEarName.Text, rtbEarDescription.Text, cbxEarTypeID.Text);
        }

        //Coat
        private void btnNewCoat_Click(object sender, EventArgs e)
        {
            AddData("coattype_id", "CoatTypes", tbxCoatName.Text, rtbCoatDescription.Text);
            tbxCoatName.Text = "";
            rtbCoatDescription.Text = "";
            ResetForm();
        }

        private void btnDeleteCoat_Click(object sender, EventArgs e)
        {
            DeleteData("coattype_id", "CoatTypes", cbxCoatTypeID.Text);
            tbxCoatName.Text = "";
            rtbCoatDescription.Text = "";
            ResetForm();
        }

        private void btnUpdateCoat_Click(object sender, EventArgs e)
        {
            UpdateData("coattype_id", "CoatTypes", tbxCoatName.Text, rtbCoatDescription.Text, cbxCoatTypeID.Text);
        }

        //Head
        private void btnNewHead_Click(object sender, EventArgs e)
        {
            AddData("headtype_id", "HeadTypes", tbxHeadName.Text, rtbHeadDescription.Text);
            tbxHeadName.Text = "";
            rtbHeadDescription.Text = "";
            ResetForm();
        }

        private void btnDeleteHead_Click(object sender, EventArgs e)
        {
            DeleteData("headtype_id", "HeadTypes", cbxHeadTypeID.Text);
            tbxHeadName.Text = "";
            rtbHeadDescription.Text = "";
            ResetForm();
        }

        private void btnUpdateHead_Click(object sender, EventArgs e)
        {
            UpdateData("headtype_id", "HeadTypes", tbxHeadName.Text, rtbHeadDescription.Text, cbxHeadTypeID.Text);
        }
    }
}
