using FactoryMethodPatternExample.Documents;

namespace FactoryMethodPatternExample.Factories;

/// <summary>
/// Abstract creator that declares the <see cref="CreateDocument"/> factory
/// method. Subclasses decide which concrete <see cref="IDocument"/> to create.
/// This is the "Creator" role in the Factory Method pattern.
/// </summary>
public abstract class DocumentFactory
{
    /// <summary>
    /// The factory method. Each concrete factory overrides this to return its
    /// own document type. Returning the <see cref="IDocument"/> abstraction
    /// keeps callers decoupled from the concrete classes.
    /// </summary>
    /// <returns>A newly created document.</returns>
    public abstract IDocument CreateDocument();

    /// <summary>
    /// Example of shared creator logic that relies on the factory method.
    /// It creates a document via <see cref="CreateDocument"/> and opens it,
    /// without ever needing to know the concrete type.
    /// </summary>
    /// <returns>The document that was created and opened.</returns>
    public IDocument OpenNewDocument()
    {
        IDocument document = CreateDocument();
        Console.WriteLine($"Factory produced a: {document.GetDocumentType()}");
        document.Open();
        return document;
    }
}
