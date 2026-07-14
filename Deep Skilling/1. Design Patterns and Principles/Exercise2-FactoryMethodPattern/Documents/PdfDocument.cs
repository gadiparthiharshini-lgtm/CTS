namespace FactoryMethodPatternExample.Documents;

/// <summary>
/// Concrete product representing a PDF (.pdf) document.
/// </summary>
public class PdfDocument : IDocument
{
    /// <inheritdoc />
    public string GetDocumentType() => "PDF Document (.pdf)";

    /// <inheritdoc />
    public void Open() =>
        Console.WriteLine($"Opening {GetDocumentType()} in the PDF viewer...");
}
