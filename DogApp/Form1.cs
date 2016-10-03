using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddNewDog_Click(object sender, EventArgs e)
        {
            ManageDogSpecies ms = new ManageDogSpecies();
            ms.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageDogAppearance dogAppearance = new ManageDogAppearance();
            dogAppearance.ShowDialog();
        }
    }
}
