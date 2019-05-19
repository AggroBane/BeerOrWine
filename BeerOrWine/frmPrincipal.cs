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
        private int _cptFichier;

        public int CptFichier
        {
            get { return this._cptFichier; }
            set { this._cptFichier = value; }
        }

        private string[] _evaluationImages;

        public string[] EvaluationImages
        {
            get { return this._evaluationImages; }
            set { this._evaluationImages = value; }
        }

        private string[] _trainingImages;

        public string[] TrainingImages
        {
            get { return this._trainingImages; }
            set { this._trainingImages = value; }
        }

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
                    this.lblResultat.Text = "Red Rate: " + nouvData.RedRate + " Green rate: " + nouvData.GreenRate + " Blue Rate: " + nouvData.BlueRate;
                }
                else
                {
                }
            }
        }

        private void btnAnalyser_Click(object sender, EventArgs e)
        {
            if (this.Image != null)
            {
                AnalyzeImage();
            }
            else MessageBox.Show("There are no image to analyze");
        }

        private void txtSrcImage_Click(object sender, EventArgs e)
        {
            OpenFolder();

            //Display the first image or an error if the folder is empty
            if (this.Mode == ModeEnum.Training)
            {
                if (this.TrainingImages.Length != 0)
                {
                    this.Image = new Bitmap(System.Drawing.Image.FromFile(this.TrainingImages[0]));
                    this.pictureBox1.Image = this.Image;
                    this.CptFichier = 1;
                }
                else MessageBox.Show("There are no images in the training folder");

            }
            else if (this.Mode == ModeEnum.Evaluation)
            {
                if (this.EvaluationImages.Length != 0)
                {
                    this.Image = new Bitmap(System.Drawing.Image.FromFile(this.EvaluationImages[0]));
                    this.pictureBox1.Image = this.Image;
                    this.CptFichier = 1;
                }
                else MessageBox.Show("There are no images in the evaluation folder");
            }
        }

        private bool OpenFolder()
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            //If the dialog result end with an OK
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                //If the path is not null and that the directory actually exists
                if (folderDialog.SelectedPath != null && Directory.Exists(folderDialog.SelectedPath))
                {
                    //If the training or evaluation folder don't exist, create them
                    if (!Directory.Exists(folderDialog.SelectedPath + "\\training"))
                    {
                        Directory.CreateDirectory(folderDialog.SelectedPath + "\\training");
                    }

                    if (!Directory.Exists(folderDialog.SelectedPath + "\\evaluation"))
                    {
                        Directory.CreateDirectory(folderDialog.SelectedPath + "\\evaluation");
                    }

                    //Change the texzt in the textbox
                    this.txtSrcImage.Text = folderDialog.SelectedPath;
                    //Update the path
                    this.CheminDossierSrc = folderDialog.SelectedPath;

                    //Get all the images in the training folder
                    this.TrainingImages =
                        Directory.GetFiles(this.CheminDossierSrc + "\\training\\", "*.png", SearchOption.AllDirectories);

                    //Get all the images in the evaluation folder
                    this.EvaluationImages =
                        Directory.GetFiles(this.CheminDossierSrc + "\\evaluation\\", "*.png", SearchOption.AllDirectories);
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

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            if (this.Mode == ModeEnum.Training)
            {
                if (this.TrainingImages != null)
                {
                    //Reset the cpt if its bigger than the lenght of the array
                    if (this.CptFichier >= this.TrainingImages.Length)
                    {
                        this.CptFichier = 0;
                    }

                    this.Image = new Bitmap(System.Drawing.Image.FromFile(this.TrainingImages[this.CptFichier]));
                    this.pictureBox1.Image = this.Image;
                    this.CptFichier++;
                }
                else MessageBox.Show("There are no images in the training folder");
            }
            else MessageBox.Show("Select a source folder first");
        }
    }
}