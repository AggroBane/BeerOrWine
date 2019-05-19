using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOrWine
{
    public class TrainingData
    {
        private byte _redRate, _greenRate, _blueRate;
        private TypeEnum _type;

        public byte RedRate
        {
            get { return this._redRate; }
            private set { this._redRate = value; }
        }
       
        public byte GreenRate
        {
            get { return this._greenRate; }
            private set { this._greenRate = value; }
        }

        public byte BlueRate
        {
            get { return this._blueRate; }
            private set { this._blueRate = value; }
        }

        public TypeEnum Type
        {
            get { return this._type; }
            private set { this._type = value; }
        }


        public TrainingData(TypeEnum type, byte r, byte g, byte b)
        {
            this.Type = type;
            this.RedRate = r;
            this.GreenRate = g;
            this.BlueRate = b;
        }
    }
}
