using FactoryMethodPatternExample.Documents;

namespace FactoryMethodPatternExample.Factories;

/// <summary>
/// Concrete creator that produces <see cref="ExcelDocument"/> instances.
/// </summary>
public class ExcelDocumentFactory : DocumentFactory
{
    /// <inheritdoc />
    public override IDocument CreateDocument() => new ExcelDocument();
}
