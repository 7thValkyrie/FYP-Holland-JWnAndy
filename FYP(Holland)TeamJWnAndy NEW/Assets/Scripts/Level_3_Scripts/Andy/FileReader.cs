using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;  

public class FileReader : MonoBehaviour 
{
    public static List<string> Load(TextAsset File)
    {
        List<string> StringList = new List<string>();
        string Content = File.text;

        string[] entries = Content.Split('\n');

        //Add to String List
        for (short i = 0; i < entries.Length; ++i)
        {
            if (entries[i].Length > 0)
                StringList.Add(entries[i].Substring(0, entries[i].Length - 1)); //Rempves last '\n' from string
        }

        Debug.Log("COUNT: " + StringList.Count);
        return StringList;
    }

    public static List<string> Load(string fileName)
    {
        // Handle any problems that might arise when reading the text
        try
        {
            string line;
            // Create a new StreamReader, tell it which file to read and what encoding the file
            // was saved as
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
 
            // Immediately clean up the reader after this block of code is done.
            // You generally use the "using" statement for potentially memory-intensive objects
            // instead of relying on garbage collection.
            // (Do not confuse this with the using directive for namespace at the 
            // beginning of a class!)
            using (theReader)
            {
                List<string> StringList = new List<string>();

                // While there's lines left in the text file, do this:
                do
                {
                    line = theReader.ReadLine();
                     
                    if (line != null)
                    {
                        // Do whatever you need to do with the text line, it's a string now
                        string[] entries = line.Split('\n');

                        //Add to String List
                        for (short i = 0; i < entries.Length; ++i)
                            StringList.Add(entries[i]);
                    }
                }
                while (line != null);
 
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
                return StringList;
            }
        }
 
        // If anything broke in the try block, we throw an exception with information
        // on what didn't work
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
            return null;
        }
    }
}
