using System;
using System.IO;

namespace LargeDataCollectionExample
{
    static class FileHandler
    {
        public static void SaveDataToFile(string filename, LargeDataCollection dataCollection)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                for (int i = 0; i < dataCollection.GetLength(); i++)
                {
                    writer.WriteLine(dataCollection.GetItem(i).ToString());
                }
            }
        }

        public static LargeDataCollection LoadDataFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            object[] data = new object[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                // Parse the data into the appropriate type
                data[i] = ParseData(lines[i]); // Implement the ParseData method accordingly
            }

            return new LargeDataCollection(data);
        }

        private static object ParseData(string data)
        {
            if (int.TryParse(data, out int intValue))
            {
                return intValue;
            }

            return data;
        }
    }
}