using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cours_420_216;

namespace BeerOrWine
{
    public partial class FrmPrincipal : Form
    {
        private string _cheminDossierSrc = "";

        public string CheminDossierSrc
        {
            get { return this._cheminDossierSrc; }
            set { this._cheminDossierSrc = value; }
        }


        private List<TrainingData> _lstTrainingData;

        public List<TrainingData> LstTrainingData
        {
            get { return this._lstTrainingData; }
            set { this._lstTrainingData = value; }
        }

        private TrainingData _generalizedTrainingData;

        public TrainingData GeneralizedTrainingData
        {
            get { return this._generalizedTrainingData; }
            set { this._generalizedTrainingData = value; }
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
                this.Image = new Bitmap(System.Drawing.Image.FromFile(cheminFichierImage));
                this.Image.Tag = TypeEnum.Beer;
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

        private void GeneralizeData()
        {
        }

        private void AnalyzeImage()
        {
            if (this.Image != null)
            {
                ImageRecognition imageRecogn = new ImageRecognition(this.Image);

                if (this.Mode == ModeEnum.Training)
                {
                    TrainingData nouvData = imageRecogn.AnalyzeData();
                    this.LstTrainingData.Add(nouvData);
                }
                else
                {
                }
            }
        }

        private void btnAnalyser_Click(object sender, EventArgs e)
        {
            AnalyzeImage();
        }

        private void txtSrcImage_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private bool OpenFolder()
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                if (folderDialog.SelectedPath != null && Directory.Exists(folderDialog.SelectedPath))
                {
                    this.txtSrcImage.Text = folderDialog.SelectedPath;
                    this.CheminDossierSrc = folderDialog.SelectedPath;
                    return true;
                }
                else
                {
                    this.CheminDossierSrc = "";
                    return false;
                }
            }
            else return false;
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            bool response = true;

            if (this.CheminDossierSrc == "")
            {
                response = OpenFolder();
            }

            if (response)
            {
                //SAUVEGARDER
            }
        }

        private void cbMode_TextUpdate(object sender, EventArgs e)
        {
            this.cbMode.Text = UtilEnum.GetDescription(this.Mode);
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbMode != null)
            {
                this.Mode = (ModeEnum) this.cbMode.SelectedIndex;
            }
        }
    }
}