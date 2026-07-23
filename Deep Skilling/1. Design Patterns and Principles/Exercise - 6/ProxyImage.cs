namespace ProxyPatternExample
{
    public class ProxyImage : Image
    {
        private RealImage? realImage;
        private string fileName;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }

            realImage.Display();
        }
    }
}