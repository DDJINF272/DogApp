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

        string bodyID = "";
        string tailID = "";
        string earID = "";
        string coatID = "";
        string headID = "";

        public ManageDogAppearanceTraits()
        {
            InitializeComponent();
        }

        private void ManageDogAppearanceTraits_Load(object sender, EventArgs e)
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
    }
}
