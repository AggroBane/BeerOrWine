using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;

namespace BeerOrWine
{
    class ImageRecognition
    {
        #region ATTRIBUTS

        /// <summary>
        /// Image bitmap
        /// </summary>
        private Bitmap _imageBitmap;

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

        /// <summary>
        /// Indexer allowing access to the pixels of the image
        /// </summary>
        /// <param name="j">X coordinates of the pixel</param>
        /// <param name="i">Y coordinates of the pixel</param>
        /// <returns></returns>
        public Color this[int j, int i]
        {
            get
            {
                VerifyDimensions(j, i);

                return this.ImageBitmap.GetPixel(j, i);
            }
            set
            {
                VerifyDimensions(j, i);

                this.ImageBitmap.SetPixel(j, i, value);
            }
        }


        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Constructor for an object using a bitmap recieved through its parameter.
        /// </summary>
        public ImageRecognition(Bitmap bitmapImage)
        {
            this.ImageBitmap = null;
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

        #endregion
    }
}
