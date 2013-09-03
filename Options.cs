using System;
using System.IO;
using System.Xml.Serialization;

namespace RightSideUp
{
    internal class Options
    {
        const string optionsFilename = "options.xml";

        // Options variables
        internal static bool EnableShellExtFolders;
        internal static bool EnableShellExtJpegs;

        /// <summary>
        /// Saves settings to options.xml file
        /// </summary>
        internal static void Save()
        {
            // Set up an instance of OptionsData to serialize
            OptionsData od = new OptionsData();
            od.EnableShellExtFolders = EnableShellExtFolders;
            od.EnableShellExtJpegs = EnableShellExtJpegs;
            
            // Save the data to disk
            XmlSerializer serializer = new XmlSerializer(typeof(OptionsData));
            using (FileStream fs = new FileStream(optionsFilename, FileMode.Create))
            {
                serializer.Serialize(fs, od);
            }
        }

        /// <summary>
        /// Loads settings from options.xml file
        /// </summary>
        internal static void Load()
        {
            // Make sure a options.xml file exists before proceeding
            if (!File.Exists(optionsFilename)) 
                return;
            
            // Set up an instance of OptionsData to deserialize
            OptionsData od = new OptionsData();
            
            // Load the data from disk
            XmlSerializer serializer = new XmlSerializer(typeof(OptionsData));
            using (FileStream fs = new FileStream(optionsFilename, FileMode.Open))
            {
                od = (OptionsData)serializer.Deserialize(fs);
            }

            // Populate the options object with settings just read in
            EnableShellExtFolders = od.EnableShellExtFolders;
            EnableShellExtJpegs = od.EnableShellExtJpegs;
        }       
    }
}
