using System;

namespace FactoryMethodPatternExample
{
    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("PDF Document Opened");
        }
    }
}