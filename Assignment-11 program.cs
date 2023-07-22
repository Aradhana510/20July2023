using System;

namespace LargeDataCollectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the LargeDataCollection
            LargeDataCollection largeDataCollection = new LargeDataCollection(new object[] { 1, 2, 3 });

            // Add elements to the collection
            largeDataCollection.Add("Hello");
            largeDataCollection.Add(4);

            // Access elements from the collection
            Console.WriteLine("Elements in the collection:");
            for (int i = 0; i < largeDataCollection.GetLength(); i++)
            {
                Console.WriteLine(largeDataCollection.GetItem(i));
            }

            // Remove an element from the collection
            largeDataCollection.Remove(2);

            // Access elements after removal
            Console.WriteLine("\nElements in the collection after removal:");
            for (int i = 0; i < largeDataCollection.GetLength(); i++)
            {
                Console.WriteLine(largeDataCollection.GetItem(i));
            }

            // Save the data to a file
            string filename = "data.txt";
            FileHandler.SaveDataToFile(filename, largeDataCollection);

            // Load the data from the file
            LargeDataCollection loadedDataCollection = FileHandler.LoadDataFromFile(filename);

            // Access elements from the loaded collection
            Console.WriteLine("\nLoaded elements from the collection:");
            for (int i = 0; i < loadedDataCollection.GetLength(); i++)
            {
                Console.WriteLine(loadedDataCollection.GetItem(i));
            }

            // Dispose the LargeDataCollection to release resources
            largeDataCollection.Dispose();
        }
    }
}