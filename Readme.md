# Distributed Software Systems 

Below is a comprehensive rundown of the project along with a detailed, step‐by‐step implementation guide including pseudo-code and examples.

---

## 1. Project Rundown

### Overview
Understanding of XML, XML Schema (XSD), XML validation, and XML-to-JSON transformation. The project has several major parts:

  1. **XML Files and Schema:**  
     - **Hotels.xsd:** An XML Schema that defines the structure of a hotel directory.  
     - **Hotels.xml:** A valid XML instance file conforming to the schema, including at least 10 hotels.  
     - **HotelsErrors.xml:** An intentionally modified (faulty) version of the XML file with five specific errors (wrong root element, missing required attribute, missing phone element, an unclosed tag, and duplicate element content).
     
  2. **C# Program:**  
     - **Verification Method:**  
       `public static string Verification(string xmlUrl, string xsdUrl)`  
       This method loads the XML file from the URL, validates it against the XSD, and returns either `"No Error"` (if valid) or an error message detailing the issues.
     
     - **Xml2Json Method:**  
       `public static string Xml2Json(string xmlUrl)`  
       This method converts a valid XML file into a JSON format with a prescribed structure. If an element like _Rating_ is missing, it should not appear in the JSON.
     
     - **Main Method:**  
       A `Main` method that calls the above methods using the URLs of the hosted XML and XSD files (deployed via GitHub Pages or another public server).


