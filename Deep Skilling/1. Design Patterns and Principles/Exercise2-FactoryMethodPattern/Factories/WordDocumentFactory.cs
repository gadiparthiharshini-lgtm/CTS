using FactoryMethodPatternExample.Documents;

namespace FactoryMethodPatternExample.Factories;

/// <summary>
/// Concrete creator that produces <see cref="WordDocument"/> instances.
/// </summary>
public class WordDocumentFactory : DocumentFactory
{
    /// <inheritdoc />
    public override IDocument CreateDocument() => new WordDocument();
}
