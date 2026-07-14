namespace FactoryMethodPatternExample.Documents;

/// <summary>
/// Common abstraction for every document the management system can handle.
/// Concrete documents (Word, PDF, Excel) implement this interface, so the
/// rest of the application can work with documents without knowing their
/// concrete type — this is the "Product" role in the Factory Method pattern.
/// </summary>
public interface IDocument
{
    /// <summary>
    /// Opens the document (here: simulated by writing to the console).
    /// </summary>
    void Open();

    /// <summary>
    /// Returns a human-readable name of the document type, e.g. "Word Document".
    /// </summary>
    string GetDocumentType();
}
