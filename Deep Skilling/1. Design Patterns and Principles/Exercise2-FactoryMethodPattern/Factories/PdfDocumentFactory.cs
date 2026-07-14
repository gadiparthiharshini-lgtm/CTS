using FactoryMethodPatternExample.Documents;

namespace FactoryMethodPatternExample.Factories;

/// <summary>
/// Concrete creator that produces <see cref="PdfDocument"/> instances.
/// </summary>
public class PdfDocumentFactory : DocumentFactory
{
    /// <inheritdoc />
    public override IDocument CreateDocument() => new PdfDocument();
}
