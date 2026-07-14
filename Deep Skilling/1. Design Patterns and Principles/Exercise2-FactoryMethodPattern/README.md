# Exercise 2 — Implementing the Factory Method Pattern

## Scenario / Goal
Build a **document management system** that can create different document
types — **Word, PDF, and Excel** — without the client code being tied to the
concrete classes. New document types should be easy to add later.

## Concept — The Factory Method Pattern

**Problem it solves:** Client code often needs to create objects, but using
`new ConcreteClass()` everywhere couples the client tightly to specific
implementations. Adding a new type then means editing many places.

**Idea:** Define a *factory method* in a base "creator" class that returns a
*product* through an abstraction (interface/abstract class). Subclasses
override the factory method to decide which concrete product to instantiate.
The client talks only to the abstractions.

**UML-ish structure (text):**

```
        «interface»                         DocumentFactory (abstract)
         IDocument                          + CreateDocument() : IDocument   <-- factory method
   + Open()                                 + OpenNewDocument() : IDocument
   + GetDocumentType()                                 ^
          ^                                            |
          |  implements                  +-------------+--------------+
  +-------+--------+--------+             |             |              |
  |       |        |        |     WordDocumentFactory  Pdf...Factory  Excel...Factory
Word    Pdf     Excel               (returns           (returns       (returns
Document Document Document           WordDocument)      PdfDocument)   ExcelDocument)
```

- **Product:** `IDocument`
- **Concrete Products:** `WordDocument`, `PdfDocument`, `ExcelDocument`
- **Creator:** `DocumentFactory` (abstract, declares `CreateDocument()`)
- **Concrete Creators:** `WordDocumentFactory`, `PdfDocumentFactory`,
  `ExcelDocumentFactory`

**When to use it:**
- A class can't anticipate the exact type of objects it must create.
- You want to localize "which concrete class" knowledge in one place.
- You expect to add new product variants over time (Open/Closed Principle).

## Project Structure

```
Exercise2-FactoryMethodPattern/
├── Documents/
│   ├── IDocument.cs                # Product abstraction
│   ├── WordDocument.cs             # Concrete product
│   ├── PdfDocument.cs              # Concrete product
│   └── ExcelDocument.cs            # Concrete product
├── Factories/
│   ├── DocumentFactory.cs          # Abstract creator + factory method
│   ├── WordDocumentFactory.cs      # Concrete creator
│   ├── PdfDocumentFactory.cs       # Concrete creator
│   └── ExcelDocumentFactory.cs     # Concrete creator
├── Program.cs                      # Test/demo driver
├── FactoryMethodPatternExample.csproj
└── README.md                       # This file
```

## How to Run

Requires the **.NET SDK (8.0 or later)**.

```bash
cd Exercise2-FactoryMethodPattern
dotnet run
```

## Expected Output

```
=== Factory Method Pattern Demo: Document Management ===

Using WordDocumentFactory:
Factory produced a: Word Document (.docx)
Opening Word Document (.docx) in the word processor...
Created object of CLR type: WordDocument

Using PdfDocumentFactory:
Factory produced a: PDF Document (.pdf)
Opening PDF Document (.pdf) in the PDF viewer...
Created object of CLR type: PdfDocument

Using ExcelDocumentFactory:
Factory produced a: Excel Document (.xlsx)
Opening Excel Document (.xlsx) in the spreadsheet application...
Created object of CLR type: ExcelDocument

All document types were created via their factories successfully.
```

## Key Takeaways
- The factory method **defers instantiation** to subclasses.
- Client code depends on **abstractions** (`IDocument`, `DocumentFactory`),
  not concrete classes — this is the Dependency Inversion idea in action.
- Adding a new document type (e.g. `TextDocument`) means adding two new
  classes and **zero changes** to existing client code — the Open/Closed
  Principle.
- The abstract creator can also contain shared logic (`OpenNewDocument`) that
  uses the factory method, so subclasses only supply the "what to create" part.
