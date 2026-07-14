namespace FactoryMethodPatternExample.Documents;

/// <summary>
/// Concrete product representing a Microsoft Excel (.xlsx) document.
/// </summary>
public class ExcelDocument : IDocument
{
    /// <inheritdoc />
    public string GetDocumentType() => "Excel Document (.xlsx)";

    /// <inheritdoc />
    public void Open() =>
        Console.WriteLine($"Opening {GetDocumentType()} in the spreadsheet application...");
}
