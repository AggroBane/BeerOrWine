using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;

namespace BeerOrWine
{
    class ImageRecognition
    {
        #region ATTRIBUTES

        /// <summary>
        /// Image bitmap
        /// </summary>
        private Bitmap _imageBitmap;
        private TypeEnum _type;

        #endregion

        #region PROPRIÉTÉS ET INDEXEURS

        public Bitmap ImageBitmap
        {
            get { return this._imageBitmap; }
            set { this._imageBitmap = value; }
        }

        public int Height
        {
            get
            {
                if (this.ImageBitmap == null)
                    throw new NullReferenceException("The image selected is null");
                return this.ImageBitmap.Height;
            }
        }

        public int Width
        {
            get
            {
                if (this.ImageBitmap == null)
                    throw new NullReferenceException("The image selected is null");
                return this.ImageBitmap.Width;
            }
        }

        public TypeEnum Type
        {
            get { return this._type; }
            private set { this._type = value; }
        }

        /// <summary>
        /// Indexer allowing access to the pixels of the image
        /// </summary>
        /// <param name="j">X coordinates of the pixel</param>
        /// <param name="i">Y coordinates of the pixel</param>
        /// <returns></returns>
        private Color this[int j, int i]
        {
            get
            {
                VerifyDimensions(j, i);

                return this.ImageBitmap.GetPixel(j, i);
            }
        }


        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Constructor for an object using a bitmap recieved through its parameter, WITHOUT the type of image given.
        /// </summary>
        public ImageRecognition(Bitmap bitmapImage)
        {
            this.ImageBitmap = bitmapImage;
            this.Type = TypeEnum.Undetermined;
        }

        /// <summary>
        /// Constructor for an object using a bitmap recieved through its parameter, WITH the type of image given.
        /// </summary>
        public ImageRecognition(Bitmap bitmapImage, TypeEnum imageType)
        {
            this.ImageBitmap = bitmapImage;
            this.Type = imageType;
        }
        #endregion

        #region MÉTHODES ET OPÉRATEURS
        /// <summary>
        /// Methode 
        /// </summary>
        /// <param name="j">X coordinates of the pixel</param>
        /// <param name="i">Y coordinates of the pixel</param>
        private void VerifyDimensions(int j, int i)
        {
            if (i >= this.Height && i > 0)
                throw new ArgumentOutOfRangeException("The i paremeter cannot be greater than the height of the image.");

            if (j >= this.Width && j > 0)
                throw new ArgumentOutOfRangeException("The j parameter cannot be greater than the width of the image.");
        }

        public Data AnalyzeData()
        {
            if (this.ImageBitmap == null)
                throw new ArgumentNullException("The image is null, it cannot be analyzed.");
            int nbPixels = this.Width * this.Height;
            double pixelR = 0;
            double pixelG = 0;
            double pixelB = 0;

            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    if (this[j, i] != Color.FromArgb(255, 255, 255))
                    {
                        pixelR = this[j, i].R;
                        pixelG = this[j, i].G;
                        pixelB = this[j, i].B;
                    }
                    else
                        nbPixels--;
                }
            }

            pixelR = pixelR / nbPixels;
            pixelG = pixelG / nbPixels;
            pixelB = pixelB / nbPixels;

            return Data(this.Type, pixelR, pixelG, pixelB);
        }
        #endregion
    }
}
