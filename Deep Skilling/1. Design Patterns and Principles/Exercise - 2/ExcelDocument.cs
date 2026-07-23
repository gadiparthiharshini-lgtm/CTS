using System;

namespace FactoryMethodPatternExample
{
    public class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Excel Document Opened");
        }
    }
}