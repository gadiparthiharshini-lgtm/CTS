using System;

namespace ProxyPatternExample
{
    public class RealImage : Image
    {
        private string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            LoadFromServer();
        }

        private void LoadFromServer()
        {
            Console.WriteLine($"Loading {fileName} from remote server...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {fileName}");
        }
    }
}