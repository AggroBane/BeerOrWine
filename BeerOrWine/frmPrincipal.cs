using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cours_420_216;

namespace BeerOrWine
{
    public partial class FrmPrincipal : Form
    {
        private List<TrainingData> _lstTrainingData;

        public List<TrainingData> LstTrainingData
        {
            get { return this._lstTrainingData; }
            set { this._lstTrainingData = value; }
        }

        private ModeEnum _mode;

        public ModeEnum Mode
        {
            get { return this._mode; }
            set { this._mode = value; }
        }


        private Bitmap _image;

        public Bitmap Image
        {
            get { return this._image; }
            set { this._image = value; }
        }

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            foreach (string str in UtilEnum.GetAllDescriptions<ModeEnum>())
            {
                this.cbMode.Items.Add(str);
            }

            this.cbMode.SelectedIndex = 0;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cheminFichierImage;

            if (Utilitaire.DemanderSelectionnerFichierImage(out cheminFichierImage))
            {
                //IMAGE LOADING VIA IMPORT
            }
        }

        private void cbMode_TextUpdate(object sender, EventArgs e)
        {
            if (this.cbMode.SelectedItem != null)
            {
                this.Mode = (ModeEnum)this.cbMode.SelectedIndex;
            }
        }

        private bool LoadTrainingData()
        {
            return false;
        }

        private bool SaveTrainingData()
        {
            return false;
        }

        private TrainingData AnalyzeImage()
        {
            return null;
        }
    }
}
