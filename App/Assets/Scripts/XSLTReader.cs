using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using UnityEditor;
using UnityEngine;

public class XSLTReader : MonoBehaviour
{
    public void ClickXSLTButton()
    {

        string xmlPath = EditorUtility.OpenFilePanel("Select XML File", "", "xml");
        if (string.IsNullOrEmpty(xmlPath))
            return;

        // Select XSLT file
        string xsltPath = EditorUtility.OpenFilePanel("Select XSLT File", "", "xslt");
        if (string.IsNullOrEmpty(xsltPath))
            return;

        // Load XML and XSLT documents
        XmlDocument xml = new XmlDocument();
        xml.Load(xmlPath);
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(xsltPath);

        // Transform XML with XSLT and create HTML output
        using (StringWriter sw = new StringWriter())
        using (XmlWriter xw = XmlWriter.Create(sw, xslt.OutputSettings))
        {
            xslt.Transform(xml, xw);
            string html = sw.ToString();

            // Save HTML output to file
            string outputPath = Path.Combine(Path.GetDirectoryName(xmlPath), Path.GetFileNameWithoutExtension(xmlPath) + ".html");
            File.WriteAllText(outputPath, html);

            // Open HTML file in default application
            Application.OpenURL("file://" + outputPath);
        }
    }
}