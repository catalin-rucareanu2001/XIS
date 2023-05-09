using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using System.Xml.Serialization;


#pragma warning disable IDE1006 // Naming Styles

[System.Serializable]
public class Coordonator
{
    public string nume;
    public string prenume;
}

[System.Serializable]
public class Interventie
{
    public string ora_interventie;
    public int durata;
    public string echipa;
    public string activitate;
    public Coordonator coordonator;
}

[System.Serializable]
public class Dispecer
{
    public string nume;
    public string prenume;
}

[System.Serializable]
public class Apel
{
    public string data;
    public string ora_apel;
    public Dispecer dispecer;
    public string nume_apelant;
    public string prenume_apelant;
    public string adresa;
    public string descriere;
    public Interventie interventie;
}

[System.Serializable]
public class Apeluri
{
    public Apel[] apel;
}

[System.Serializable]
[XmlRoot("serviciul_112")]
public class Serviciul112
{
    public Apeluri apeluri;
}

[System.Serializable]
public class MyData
{
    public Serviciul112 serviciul_112;
}

public class JsonReader : MonoBehaviour
{
    MyData data;
    public Text textArea;
    public void ClickJSONButton()
    {
        string filePath = EditorUtility.OpenFilePanel("Select JSON file", "", "json");
        if (!string.IsNullOrEmpty(filePath))
        {
            if (File.Exists(filePath))
            {
                //Read the string from the JSON file
                string jsonString = File.ReadAllText(filePath);

                //Add the data from that file to the data object of class MyData
                data = JsonUtility.FromJson<MyData>(jsonString);
                
            }
            else
            {
                Debug.LogError("JSON file not found at path: " + filePath);
            }
        }
        else
        {
            Debug.LogError("JSON file not selected " );
        }
        WriteDataJSONToDisplay();
    } 

    public void WriteDataJSONToDisplay()
    {
        string str = "";
        Apel[] apel = data.serviciul_112.apeluri.apel;
        Debug.Log(apel.Length);
        int i = 1;
        foreach (var apelul in apel)
        {
            Interventie interventie = apelul.interventie;
            //Set the value to str that will be displayed in the Text area
            str = str + " apel " + (i++) + ":\ndata: " + apelul.data + "\nora_apel: " + apelul.ora_apel +
                "\ndispecer:\nnume: " + apelul.dispecer.nume + " prenume: " + apelul.dispecer.prenume +
                "\nnume apelant: " + apelul.nume_apelant + " prenume apelant: " + apelul.prenume_apelant +
                "\nadresa: " + apelul.adresa + "\ndescriere: " + apelul.descriere +
                "\ninterventie:\nora interventie: " + interventie.ora_interventie +
                "\ndurata: " + interventie.durata + "\nechipa: " + interventie.echipa + "\nactivitate: " + interventie.activitate +
                "\ncoordonator:\nnume: " + interventie.coordonator.nume + "\nprenume: " + interventie.coordonator.prenume + "\n\n";
        }
        textArea.text = str;
    }
}
