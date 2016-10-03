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
    
    public partial class NewTrait : Form
    {
        string traitType;
        public NewTrait(string type)
        {
            
            traitType = type;

            
            InitializeComponent();
        }

        private void NewTrait_Load(object sender, EventArgs e)
        {
            if (traitType == "protection")
            {
                lblTrait.Text = "Protection Type : ";
                groupBox1.Text = "Add new dog protection type";
            }
            else if (traitType == "disposition")
            {
                lblTrait.Text = "Disposition Type : ";
                groupBox1.Text = "Add new dog disposotion type";
            }
            else if (traitType == "temperament")
            {
                lblTrait.Text = "Temperament Type : ";
                groupBox1.Text = "Add new dog temperament type";
            }
            else if (traitType == "training")
            {
                lblTrait.Text = "Training Category : ";
                groupBox1.Text = "Add new dog training category";
            }
            else if (traitType == "child")
            {
                lblTrait.Text = "Relation Type : ";
                groupBox1.Text = "Add new dog/child compatability type";
            }
            else if (traitType == "livingspace")
            {
                lblTrait.Text = "Livingspace Type : ";
                groupBox1.Text = "Add new dog livingspace type";
            }
            else if (traitType == "shedding")
            {
                lblTrait.Text = "Shedding Type : ";
                groupBox1.Text = "Add new dog shedding category";
            }
            else if (traitType == "climate")
            {
                lblTrait.Text = "Climate Type : ";
                groupBox1.Text = "Add new dog climate type";
            }
            else if (traitType == "exercise")
            {
                lblTrait.Text = "Exercise Type : ";
                groupBox1.Text = "Add new dog exercise type";
            }
            else // size
            {
                lblTrait.Text = "Size Category : ";
                groupBox1.Text = "Add new dog size type";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
