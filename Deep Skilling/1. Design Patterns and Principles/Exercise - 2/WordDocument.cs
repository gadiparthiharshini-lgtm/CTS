using System;

namespace FactoryMethodPatternExample
{
    public class WordDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Word Document Opened");
        }
    }
}