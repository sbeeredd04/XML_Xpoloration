using System;
using System.Xml.Schema;
using System.Xml;
using Newtonsoft.Json;
using System.IO;



/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 4.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/


namespace ConsoleApp1
{


    public class Program
    {
        public static string xmlURL = "https://sbeeredd04.github.io/XML_Xpoloration/Hotels.xml"; //Q1.2
        public static string xmlErrorURL = "https://sbeeredd04.github.io/XML_Xpoloration/HotelsErrors.xml"; //Q1.3
        public static string xsdURL = "https://sbeeredd04.github.io/XML_Xpoloration/Hotels.xsd"; //Q1.1
    
        public static void Main(string[] args)
        {
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result);


            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);


            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }

        // Q2.1
        public static string Verification(string xmlUrl, string xsdUrl)
        {
            string errorMessage = "";
            try
            {
                // settings for XML validation
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, xsdUrl);
                settings.ValidationType = ValidationType.Schema;

                // Set the validation event handler to capture validation errors.
                settings.ValidationEventHandler += (sender, args) =>
                {
                    // Append the error message to the errorMessage string.
                    errorMessage += $"Error: {args.Message}\n";
                };

                // Create an XmlReader with the settings and read the XML file.
                using (XmlReader reader = XmlReader.Create(xmlUrl, settings))
                {
                    // Read the XML document. This will trigger validation.
                    while (reader.Read()) { } 
                }

                // Check if there were any validation errors.
                return string.IsNullOrEmpty(errorMessage) ? "No Error" : errorMessage;
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the validation process.
                return $"Exception during validation: {ex.Message}";
            }
        }

        public static string Xml2Json(string xmlUrl)
        {
           try
            {
                // Load the XML document from the provided URL.
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlUrl);

                // Convert the XML document to JSON. Using JsonConvert from Newtonsoft.Json to handle the conversion.
                string jsonText = JsonConvert.SerializeXmlNode(doc.DocumentElement, Newtonsoft.Json.Formatting.Indented, false);


                // return the JSON string.
                return jsonText;
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the conversion process.
                return $"Exception during XML to JSON conversion: {ex.Message}";
            }

        }
    }

}
