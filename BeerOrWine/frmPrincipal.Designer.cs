namespace BeerOrWine
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblResultat = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnalyser = new System.Windows.Forms.Button();
            this.btnSauvegarder = new System.Windows.Forms.Button();
            this.txtSrcImage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNextImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 369);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblResultat
            // 
            this.lblResultat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultat.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblResultat.Location = new System.Drawing.Point(0, 76);
            this.lblResultat.Name = "lblResultat";
            this.lblResultat.Size = new System.Drawing.Size(800, 31);
            this.lblResultat.TabIndex = 2;
            this.lblResultat.Text = "{Résultat}";
            this.lblResultat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbMode
            // 
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Location = new System.Drawing.Point(65, 21);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(121, 24);
            this.cbMode.TabIndex = 3;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            this.cbMode.TextUpdate += new System.EventHandler(this.cbMode_TextUpdate);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(12, 24);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(47, 17);
            this.lblMode.TabIndex = 4;
            this.lblMode.Text = "Mode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 5;
            // 
            // btnAnalyser
            // 
            this.btnAnalyser.Location = new System.Drawing.Point(309, 487);
            this.btnAnalyser.Name = "btnAnalyser";
            this.btnAnalyser.Size = new System.Drawing.Size(158, 40);
            this.btnAnalyser.TabIndex = 6;
            this.btnAnalyser.Text = "Analyze";
            this.btnAnalyser.UseVisualStyleBackColor = true;
            this.btnAnalyser.Click += new System.EventHandler(this.btnAnalyser_Click);
            // 
            // btnSauvegarder
            // 
            this.btnSauvegarder.Location = new System.Drawing.Point(522, 487);
            this.btnSauvegarder.Name = "btnSauvegarder";
            this.btnSauvegarder.Size = new System.Drawing.Size(158, 40);
            this.btnSauvegarder.TabIndex = 7;
            this.btnSauvegarder.Text = "Save";
            this.btnSauvegarder.UseVisualStyleBackColor = true;
            this.btnSauvegarder.Click += new System.EventHandler(this.btnSauvegarder_Click);
            // 
            // txtSrcImage
            // 
            this.txtSrcImage.Location = new System.Drawing.Point(389, 21);
            this.txtSrcImage.Name = "txtSrcImage";
            this.txtSrcImage.ReadOnly = true;
            this.txtSrcImage.Size = new System.Drawing.Size(399, 22);
            this.txtSrcImage.TabIndex = 8;
            this.txtSrcImage.Text = "Click here to open";
            this.txtSrcImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSrcImage.Click += new System.EventHandler(this.txtSrcImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Source folder: ";
            // 
            // btnNextImage
            // 
            this.btnNextImage.Location = new System.Drawing.Point(93, 487);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(158, 40);
            this.btnNextImage.TabIndex = 11;
            this.btnNextImage.Text = "Next image";
            this.btnNextImage.UseVisualStyleBackColor = true;
            this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.btnNextImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSrcImage);
            this.Controls.Add(this.btnSauvegarder);
            this.Controls.Add(this.btnAnalyser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.lblResultat);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmPrincipal";
            this.Text = "Beer or Wine?";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblResultat;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnalyser;
        private System.Windows.Forms.Button btnSauvegarder;
        private System.Windows.Forms.TextBox txtSrcImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNextImage;
    }
}

