namespace FactoryMethodPatternExample.Documents;

/// <summary>
/// Concrete product representing a Microsoft Word (.docx) document.
/// </summary>
public class WordDocument : IDocument
{
    /// <inheritdoc />
    public string GetDocumentType() => "Word Document (.docx)";

    /// <inheritdoc />
    public void Open() =>
        Console.WriteLine($"Opening {GetDocumentType()} in the word processor...");
}
