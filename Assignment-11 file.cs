using System;

namespace LargeDataCollectionExample
{
    class LargeDataCollection : IDisposable
    {
        private bool disposed = false;
        private object[] data; // You can replace 'object' with the appropriate data type for your collection

        public LargeDataCollection(object[] initialData)
        {
            data = new object[initialData.Length];
            Array.Copy(initialData, data, initialData.Length);
        }

        public void Add(object item)
        {
            // Add the item to the collection
            int newDataLength = data.Length + 1;
            object[] newData = new object[newDataLength];
            Array.Copy(data, newData, data.Length);
            newData[newDataLength - 1] = item;
            data = newData;
        }

        public void Remove(object item)
        {
            // Remove the item from the collection
            int index = Array.IndexOf(data, item);
            if (index >= 0)
            {
                int newDataLength = data.Length - 1;
                object[] newData = new object[newDataLength];
                Array.Copy(data, newData, index);
                Array.Copy(data, index + 1, newData, index, newDataLength - index);
                data = newData;
            }
        }

        public object GetItem(int index)
        {
            // Get an item from the collection by index
            if (index >= 0 && index < data.Length)
            {
                return data[index];
            }
            return null;
        }

        public int GetLength()
        {
            // Get the number of elements in the collection
            return data.Length;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Release managed resources here (if any)
                }

                // Release unmanaged resources here (if any)
                data = null; // Set the internal data structure to null to free up memory

                disposed = true;
            }
        }
    }
}