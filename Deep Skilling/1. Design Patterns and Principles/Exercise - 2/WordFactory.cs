namespace FactoryMethodPatternExample
{
    public class WordFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }
}