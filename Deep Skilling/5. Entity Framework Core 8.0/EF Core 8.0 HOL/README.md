# EF Core 8.0 HOL — Retail Inventory System

Guided hands-on labs for the Cognizant **Digital Nurture — .NET FSE Deepskilling**
program. A single **.NET 8 console app** (`RetailInventory`) is built up lab by
lab into an inventory system for a retail store that tracks **products**,
**categories**, and stock in **SQL Server** using **Entity Framework Core 8.0**.

> **Labs covered:** 1–5 (mandatory) and 6–7 (additional important) — exactly the
> rows listed for *EF Core 8.0 HOL* in the tasks sheet.

| Lab | Title | Type |
|-----|-------|------|
| 1 | Understanding ORM with a Retail Inventory System | Mandatory |
| 2 | Setting Up the Database Context for a Retail Store | Mandatory |
| 3 | Using EF Core CLI to Create and Apply Migrations | Mandatory |
| 4 | Inserting Initial Data into the Database | Mandatory |
| 5 | Retrieving Data from the Database | Mandatory |
| 6 | Updating and Deleting Records | Additional |
| 7 | Writing Queries with LINQ | Additional |

---

## Project structure

```
RetailInventory/
├── RetailInventory.csproj        # net8.0 console app + EF Core 8 packages
├── Program.cs                    # Demo of Labs 4–7 (insert / read / update / delete / LINQ)
├── Models/
│   ├── Category.cs               # Category entity (1..* Products)
│   └── Product.cs                # Product entity (FK -> Category)
├── Data/
│   └── AppDbContext.cs           # DbContext: DbSets + SQL Server connection
└── Migrations/                   # Lab 3 – generated schema (InitialCreate)
    ├── 20250701120000_InitialCreate.cs
    ├── 20250701120000_InitialCreate.Designer.cs
    └── AppDbContextModelSnapshot.cs
```

---

## Lab 1 — Understanding ORM with a Retail Inventory System

**Scenario:** we are building an inventory management system for a retail store
that tracks products, categories, and stock levels in SQL Server.

**What is ORM?**
Object–Relational Mapping maps C# **classes → tables**, **properties → columns**,
and **objects → rows**. Instead of writing SQL by hand, we work with strongly-typed
objects and let the ORM translate LINQ into SQL. Benefits:

- **Productivity** — no repetitive `INSERT/SELECT/UPDATE` boilerplate.
- **Maintainability** — the schema follows the C# model; changes flow through migrations.
- **Abstraction from SQL** — the same code can target different providers.

**EF Core vs EF6:** EF Core is **cross-platform**, lightweight, and supports modern
features (LINQ, async queries, compiled queries). EF6 is Windows-only, more mature
but less flexible.

**EF Core 8.0 highlights:** JSON column mapping, compiled models for faster startup,
interceptors, and better bulk operations.

**Create the console app and install packages (Lab 1 steps 4–5):**

```bash
dotnet new console -n RetailInventory
cd RetailInventory
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

These package references are already captured in `RetailInventory.csproj`.

## Lab 2 — Setting Up the Database Context

Defines the two model classes (`Models/Category.cs`, `Models/Product.cs`) and the
`AppDbContext` (`Data/AppDbContext.cs`) with `DbSet<Product>` and `DbSet<Category>`.
As in the HOL, the connection string is supplied in `OnConfiguring`:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer(
        "Server=localhost;Database=RetailInventoryDb;Trusted_Connection=True;TrustServerCertificate=True;");
}
```

> Edit the `Server=` value to match your SQL Server instance (e.g.
> `localhost\\SQLEXPRESS`, or use `User Id=...;Password=...` instead of
> `Trusted_Connection=True`).

## Lab 3 — Using EF Core CLI to Create and Apply Migrations

```bash
# one-time: install the CLI tool if you don't have it
dotnet tool install --global dotnet-ef

# create the migration (already committed in Migrations/)
dotnet ef migrations add InitialCreate

# apply it – creates RetailInventoryDb with Products + Categories tables
dotnet ef database update
```

Then verify in **SSMS / Azure Data Studio** that the `Products` and `Categories`
tables exist. The committed migration creates both tables, the
`FK_Products_Categories_CategoryId` foreign key, and the `IX_Products_CategoryId`
index.

## Lab 4 — Inserting Initial Data

`Program.cs` inserts two categories (Electronics, Groceries) and two products
(Laptop ₹75000, Rice Bag ₹1200) using `AddRangeAsync` + `SaveChangesAsync`.

## Lab 5 — Retrieving Data

Demonstrates the three common read patterns:

- `ToListAsync()` — all products.
- `FindAsync(1)` — by primary key.
- `FirstOrDefaultAsync(p => p.Price > 50000)` — first match for a condition.

## Lab 6 — Updating and Deleting Records

- **Update:** load *Laptop*, set `Price = 70000`, `SaveChangesAsync()` — EF's change
  tracker emits an `UPDATE`.
- **Delete:** load *Rice Bag*, `Remove(...)`, `SaveChangesAsync()` — emits a `DELETE`.

## Lab 7 — Writing Queries with LINQ

- **Filter + sort:** `Where(p => p.Price > 1000).OrderByDescending(p => p.Price)`.
- **Project into a DTO:** `Select(p => new { p.Name, p.Price })` so only the needed
  columns are pulled from the database.

---

## How to run

**Prerequisites:** [.NET 8 SDK](https://dotnet.microsoft.com/download) and a
reachable **SQL Server** instance (LocalDB, Express, or full).

```bash
cd RetailInventory
dotnet restore
dotnet ef database update   # Lab 3 – create/upgrade the database schema
dotnet run                  # Labs 4–7 – seed, read, update, delete, query
```

## Expected output

```
=== Lab 4: Inserting Initial Data ===
Inserted 2 categories and 2 products.

=== Lab 5: Retrieving Data ===
All products:
  Laptop - ₹75000
  Rice Bag - ₹1200
Find(1): Laptop
First product over 50000: Laptop

=== Lab 6: Updating and Deleting ===
Updated Laptop price to ₹70000
Deleted 'Rice Bag'.

=== Lab 7: LINQ Queries ===
Products over 1000 (desc by price):
  Laptop - ₹70000
Projected DTOs (Name, Price):
  Laptop, 70000

Done.
```

> After Lab 6 deletes *Rice Bag*, only *Laptop* remains, so Lab 7's filtered list
> and projection each show a single row.
>
> Re-running seeds a fresh copy each time (the HOL inserts unconditionally), so
> reset the database with `dotnet ef database update` after `dotnet ef database drop`
> if you want a clean run.

## Key takeaways

- EF Core is an ORM: LINQ over C# objects is translated to SQL, so you rarely write SQL.
- `DbContext` + `DbSet<T>` model the database; the connection string wires it to SQL Server.
- **Migrations** version the schema — `migrations add` describes a change, `database update` applies it.
- `AddAsync`/`SaveChangesAsync` write; `ToListAsync`/`FindAsync`/`FirstOrDefaultAsync` read.
- The change tracker turns simple property edits and `Remove(...)` calls into `UPDATE`/`DELETE`.
- LINQ `Where`/`OrderBy`/`Select` compose server-side queries and project into DTOs.
