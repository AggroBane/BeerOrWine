#region USING

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

#endregion

namespace BeerOrWine
{
    public static class Utility
    {
        public const string defaultFilePath = "C:\\";

        public static bool SaveData(string filePath, List<TrainingData> lstTrainingData)
        {
            //Verifications
            if (!File.Exists(filePath))
                File.Create(filePath);

            if (lstTrainingData != null)
            {
                XmlDocument xmlDoc = new XmlDocument();

                //Declaration
                XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDec);

                XmlElement elemDataList = xmlDoc.CreateElement("List-Data");
                xmlDoc.AppendChild(elemDataList);

                foreach (TrainingData data in lstTrainingData)
                {
                    XmlElement elemData, elemType, elemR, elemG, elemB;

                    elemData = xmlDoc.CreateElement("Data");

                    elemType = xmlDoc.CreateElement("type");
                    elemType.InnerText = String.Format("{0}", (int) data.Type);
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

        /// <summary>
        /// This method takes for granted that the XML file it is fed is formatted correctly, or else it will crash. :o)
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="tdList"></param>
        /// <returns></returns>
        public static void LoadData(string filePath, out List<TrainingData> tdList)
        {
            //Loading the xmldoc
            if(filePath == null || !File.Exists(filePath)) 
                throw new ArgumentNullException("The path is null or does not exist.");

            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(filePath);
            }
            catch (Exception e)
            {
                throw new ArgumentException("There was a problem loading the XML document.");
            }

            tdList = new List<TrainingData>();

            XmlElement lstTrainingData = (XmlElement) xmlDoc.GetElementsByTagName("List-Data")[0];

            foreach (XmlElement data in lstTrainingData.GetElementsByTagName("Data"))
            {
                TypeEnum type;
                byte r, g, b;

                r = byte.Parse(data.GetElementsByTagName("elemR")[0].InnerText);
                g = byte.Parse(data.GetElementsByTagName("elemG")[0].InnerText);
                b = byte.Parse(data.GetElementsByTagName("elemB")[0].InnerText);
                type = (TypeEnum)Enum.Parse(typeof (TypeEnum), data.GetElementsByTagName("type")[0].InnerText);

                TrainingData newData = new TrainingData(type,r,g,b);
                tdList.Add(newData);
            }
        }
    }
}