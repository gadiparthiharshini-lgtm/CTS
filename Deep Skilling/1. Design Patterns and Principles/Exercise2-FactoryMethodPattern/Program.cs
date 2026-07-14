using FactoryMethodPatternExample.Documents;
using FactoryMethodPatternExample.Factories;

// ---------------------------------------------------------------------------
// Test / demonstration of the Factory Method pattern.
//
// A document management system needs to create different document types
// (Word, PDF, Excel). The client code below works only with the abstract
// DocumentFactory and the IDocument interface — it never uses `new` on a
// concrete document, so adding a new document type later requires no change
// to this code.
// ---------------------------------------------------------------------------

Console.WriteLine("=== Factory Method Pattern Demo: Document Management ===\n");

// Map each factory to a friendly label for the demo loop.
DocumentFactory[] factories =
{
    new WordDocumentFactory(),
    new PdfDocumentFactory(),
    new ExcelDocumentFactory()
};

foreach (DocumentFactory factory in factories)
{
    Console.WriteLine($"Using {factory.GetType().Name}:");

    // The factory method does the creation; the client stays decoupled.
    IDocument document = factory.OpenNewDocument();

    Console.WriteLine($"Created object of CLR type: {document.GetType().Name}");
    Console.WriteLine();
}

Console.WriteLine("All document types were created via their factories successfully.");
