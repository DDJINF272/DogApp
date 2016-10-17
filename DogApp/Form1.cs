using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/***********************
 * Dagan Camps - u14033781
 * John van Schalkwyk - u14307317
 * Darren Adams - u14256232
 * *********************/
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

        private void btnManagePersonalityAndTraits_Click(object sender, EventArgs e)
        {
            ManageDogAppearanceTraits dogAppearanceTraits = new ManageDogAppearanceTraits();
            dogAppearanceTraits.ShowDialog();
        }

        private void btnManageDogSpeciesTraits_Click(object sender, EventArgs e)
        {
            ManageDogSpeciesTraits dogSpeciesTraits = new ManageDogSpeciesTraits();
            dogSpeciesTraits.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SearchForPerfectDog searchForDog = new SearchForPerfectDog();
            searchForDog.ShowDialog();
        }
    }
}
