#region USING

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

#endregion

namespace BeerOrWine
{
    public static class Utilitaire
    {
        public const string defaultFilePath = "C:\\";

        public static bool SaveData(string filePath, List<TrainingData> lstTrainingData)
        {
            //Verifications
            if(!File.Exists(filePath))
                File.Create(filePath);

            if (lstTrainingData != null)
            {
                XmlDocument xmlDoc = new XmlDocument();

                //Declaration
                XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDec);

                XmlElement elemDataList = xmlDoc.CreateElement("Liste-Data");
                xmlDoc.AppendChild(elemDataList);

                foreach (TrainingData data in lstTrainingData)
                {
                    XmlElement elemData, elemType, elemR, elemG, elemB;

                    elemData = xmlDoc.CreateElement("Data");

                    elemType = xmlDoc.CreateElement("Type");
                    elemType.InnerText = String.Format("{0}", (int)data.Type);
                    elemData.AppendChild(elemType);

                    elemR = xmlDoc.CreateElement("elemR");
                    elemR.InnerText = data.RedRate.ToString();
                    elemData.AppendChild(elemR);

                    elemG = xmlDoc.CreateElement("elemG");
                    elemG.InnerText = data.GreenRate.ToString();
                    elemData.AppendChild(elemG);

                    elemB = xmlDoc.CreateElement("elemB");
                    elemB.InnerText = data.BlueRate.ToString();
                    elemData.AppendChild(elemB);

                    elemDataList.AppendChild(elemData);
                }

                try
                {
                    xmlDoc.Save(filePath);
                }
                catch (XmlException)
                {
                    throw new XmlException("An error occured when saving the file.");
                }
                return true;
            }
            else
                return false;
        }
    }
}