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
    public partial class ManageDogSpecies : Form
    {
        public ManageDogSpecies()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnPreviousTab_Click(object sender, EventArgs e)
        {
            tabPage1.Show();
        }

        private void btnNextTab_Click(object sender, EventArgs e)
        {
            tabPage2.Select();
            tabPage2.Show();
            
        }

        private void protectionCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrait nt = new NewTrait("protection");
            nt.ShowDialog();
        }

        private void dispositionTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrait nt = new NewTrait("disposition");
            nt.ShowDialog();
        }

        private void temperamentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrait nt = new NewTrait("temperament");
            nt.ShowDialog();
        }

        private void livingspaceCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrait nt = new NewTrait("livingspace");
            nt.ShowDialog();
        }

        private void sheddingCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrait nt = new NewTrait("shedding");
            nt.ShowDialog();
        }

        private void climateTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrait nt = new NewTrait("climate");
            nt.ShowDialog();
        }

        private void exerciseCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrait nt = new NewTrait("exercise");
            nt.ShowDialog();
        }

        private void dogSizeCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrait nt = new NewTrait("size");
            nt.ShowDialog();
        }

        private void childCompatabilityTipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrait nt = new NewTrait("child");
            nt.ShowDialog();
        }

        private void trainingCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrait nt = new NewTrait("training");
            nt.ShowDialog();
        }
    }
}
