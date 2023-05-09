using System.Xml;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class XMLReader : MonoBehaviour
{
    XmlSerializer serializer = new XmlSerializer(typeof(MyData));
    Serviciul112 data2;
    public Text textArea;
    public void ClickXMLutton()
    {
        string str = "";
        string filePath = EditorUtility.OpenFilePanel("Select XML file", "", "xml");
        if (!string.IsNullOrEmpty(filePath))
        {
            // Create a new XML document
            XmlDocument xmlDoc = new XmlDocument();

            // Load the XML file from the specified file path
            xmlDoc.Load(filePath);

            // Get the root element of the XML document
            XmlElement rootElement = xmlDoc.DocumentElement;
            int i = 1;
            // Loop through all "apel" elements
            foreach (XmlNode apelNode in rootElement.SelectNodes("apeluri/apel"))
            {
                // Get the "data" element value
                string data = apelNode.SelectSingleNode("data").InnerText;

                // Get the "ora_apel" element value
                string oraApel = apelNode.SelectSingleNode("ora_apel").InnerText;

                // Get the "dispecer" element values
                string dispecerNume = apelNode.SelectSingleNode("dispecer").Attributes["nume"].Value;
                string dispecerPrenume = apelNode.SelectSingleNode("dispecer").Attributes["prenume"].Value;

                // Get the "nume_apelant" element value
                string numeApelant = apelNode.SelectSingleNode("nume_apelant").InnerText;

                // Get the "prenume_apelant" element value
                string prenumeApelant = apelNode.SelectSingleNode("prenume_apelant").InnerText;

                // Get the "adresa" element value
                string adresa = apelNode.SelectSingleNode("adresa").InnerText;

                // Get the "descriere" element value
                string descriere = apelNode.SelectSingleNode("descriere").InnerText;

                // Get the "interventie" element values
                string oraInterventie = apelNode.SelectSingleNode("interventie/ora_interventie").InnerText;
                string durata = apelNode.SelectSingleNode("interventie/durata").InnerText;
                string echipa = apelNode.SelectSingleNode("interventie/echipa").InnerText;
                string activitate = apelNode.SelectSingleNode("interventie/activitate").InnerText;
                string coordonatorNume = apelNode.SelectSingleNode("interventie/coordonator").Attributes["nume"].Value;
                string coordonatorPrenume = apelNode.SelectSingleNode("interventie/coordonator").Attributes["prenume"].Value;

                //Construct the str that will be displayed in the interface
                str = str + " apel " + (i++) + ":\ndata: " + data + "\nora_apel: " + oraApel +
                "\ndispecer:\nnume: " + dispecerNume + " prenume: " + dispecerPrenume +
                "\nnume apelant: " + numeApelant + " prenume apelant: " + prenumeApelant +
                "\nadresa: " + adresa + "\ndescriere: " + descriere +
                "\ninterventie:\nora interventie: " + oraInterventie +
                "\ndurata: " + durata + "\nechipa: " + echipa + "\nactivitate: " + activitate +
                "\ncoordonator:\nnume: " + coordonatorNume + "\nprenume: " + coordonatorPrenume + "\n\n";
            }
            textArea.text = str;
        }
        else
        {
            Debug.LogError("XML file not selected ");
        }
    }
    
}
