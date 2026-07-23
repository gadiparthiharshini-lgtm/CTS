using System;
using LibraryManagement;

Book[] books =
{
    new Book { BookId = 101, Title = "C Programming", Author = "Dennis Ritchie"},
    new Book { BookId = 102, Title = "Data Structures", Author = "Mark Allen"},
    new Book { BookId = 103, Title = "Operating Systems", Author = "Silberschatz"},
    new Book { BookId = 104, Title = "Python Basics", Author = "Guido"},
    new Book { BookId = 105, Title = "Software Engineering", Author = "Pressman"}
};

// ---------- Linear Search ----------
Book? LinearSearch(string title)
{
    foreach (var book in books)
    {
        if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            return book;
    }

    return null;
}

// ---------- Binary Search ----------
Array.Sort(books, (a, b) => a.Title.CompareTo(b.Title));

Book? BinarySearch(string title)
{
    int left = 0;
    int right = books.Length - 1;

    while (left <= right)
    {
        int mid = (left + right) / 2;

        int compare = string.Compare(books[mid].Title, title, true);

        if (compare == 0)
            return books[mid];

        if (compare < 0)
            left = mid + 1;
        else
            right = mid - 1;
    }

    return null;
}

// ----------------------------

Console.WriteLine("Linear Search");

Book? book1 = LinearSearch("Python Basics");

if (book1 != null)
    Console.WriteLine($"{book1.BookId} | {book1.Title} | {book1.Author}");
else
    Console.WriteLine("Book Not Found");

Console.WriteLine();

Console.WriteLine("Binary Search");

Book? book2 = BinarySearch("Python Basics");

if (book2 != null)
    Console.WriteLine($"{book2.BookId} | {book2.Title} | {book2.Author}");
else
    Console.WriteLine("Book Not Found");